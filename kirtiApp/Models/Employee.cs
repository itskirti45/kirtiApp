

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kirtiApp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public long Mobile { get; set; }
       
        public string Address { get; set; }
        public bool C {  get; set; }    
        public bool Python {  get; set; }    
        public bool Cshrap {  get; set; }    
        public bool Java {  get; set; }    
        public bool PHP {  get; set; }    
        public bool Angular {  get; set; }    
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        
        public string? ImagePath { get; set; }
      
    }
}
