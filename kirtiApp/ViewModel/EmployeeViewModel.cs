using System.ComponentModel.DataAnnotations;

namespace kirtiApp.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Mobile { get; set; }
        public string Address { get; set; }
        public bool C { get; set; }
        public bool Python { get; set; }
        public bool Cshrap { get; set; }
        public bool Java { get; set; }
        public bool PHP { get; set; }
        public bool Angular { get; set; }
        public string Gender { get; set; }
        public DateTime JoiningDate { get; set; }
       
        public string? ImagePath { get; set; }
        public List<AddressViewModel> AddressList { get; set; }


    }
}
