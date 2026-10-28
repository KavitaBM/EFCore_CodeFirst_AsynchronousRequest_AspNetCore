using System.ComponentModel.DataAnnotations;
namespace EFCore_CodeFirst_AsynchronousRequest_AspNetCore.Models
{
    public class EmpModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
