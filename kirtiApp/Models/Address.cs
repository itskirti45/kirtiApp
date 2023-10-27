using System.ComponentModel.DataAnnotations;

namespace kirtiApp.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Addresses { get; set; }
    }
}
