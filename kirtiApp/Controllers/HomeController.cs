using kirtiApp.db_conn;
using kirtiApp.Models;
using kirtiApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SkiaSharp;
using System.Diagnostics;
using System.Drawing;

namespace kirtiApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext db;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment env;

        public HomeController(ApplicationDbContext _db, Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
                db = _db;
            env = environment;
        }
        public IActionResult Index()
        {
            return View();
        }  
        public IActionResult Edit(int Id)
        
        {          

            HttpClient httpClient = new HttpClient();
            EmployeeViewModel emp = new EmployeeViewModel();

            var data = httpClient.GetAsync("http://localhost:5202/api/CoreApi/EditData?Id=" + Id).Result;
            var datajson = data.Content.ReadAsStringAsync().Result;
           
            
             emp = JsonConvert.DeserializeObject<EmployeeViewModel>(datajson);
            emp.AddressList = db.Cites.Select(m => new AddressViewModel
            {
                Addresses = m.Addresses,
            }).ToList();
            //return View("AddData",emp);
            return View("AddData", emp);
        }
        public IActionResult Delete(int Id)
        {
            HttpClient httpClient = new HttpClient();
            var data = httpClient.GetAsync("http://localhost:5202/api/CoreApi/Deletedata?Id="+Id).Result;
            
           
            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            HttpClient httpClient = new HttpClient();
            var data = httpClient.GetAsync("http://localhost:5202/api/CoreApi/GetEmpData").Result;
            var datajson = data.Content.ReadAsStringAsync().Result;
            var finaldata =JsonConvert.DeserializeObject<List<Employee>>(datajson);

            return View(finaldata);
        }
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }
            else
            {
                var employee = await db.employees.FirstOrDefaultAsync(m => m.Id == Id);
                if (employee == null)
                {
                    return NotFound();
                }

                return View("Details",employee);
            }
                 
        }
        [HttpGet]
        public IActionResult AddData()
        {
            EmployeeViewModel emp = new EmployeeViewModel();
            emp.AddressList = db.Cites.Select(m => new AddressViewModel
            {
                Addresses = m.Addresses,
            }).ToList();
            return View(emp);
        }
        [HttpPost]
        public async Task<IActionResult> AddData(EmployeeViewModel obj, IFormFile file)
        {
            string unique=string.Empty;
            obj.ImagePath = file.FileName;
                string uploadFolder = Path.Combine(env.WebRootPath, "image/");
                
            unique = Guid.NewGuid().ToString()+"_"+file.FileName;
            
            string filepath = Path.Combine(uploadFolder, unique);
            
                using(var fileStream =new FileStream(filepath,FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
                var data2 = new Employee()
                {
                    Id=obj.Id,
                    Name=obj.Name,
                    Email=obj.Email,
                    Mobile=obj.Mobile,
                    Address=obj.Address,
                    C=obj.C,
                    Python=obj.Python,
                    Cshrap=obj.Cshrap,
                    Java=obj.Java,
                    PHP=obj.PHP,
                    Angular=obj.Angular,  
                    Gender=obj.Gender,
                    JoiningDate=obj.JoiningDate,
                    ImagePath = unique,
                };
                
        
                HttpClient httpClient = new HttpClient();
                var data = JsonConvert.SerializeObject(data2);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                var res = await httpClient.PostAsync("http://localhost:5202/api/CoreApi/AddData", content);
                return RedirectToAction("Dashboard");
            
         

        }
        //public void UploadFile(IFormFile file, string path)
        //{
        //    FileStream fileStream = new FileStream(path, FileMode.Create);
        //    file.CopyTo(fileStream);
        //}
        [AllowAnonymous]
            public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}