
using System.ComponentModel.DataAnnotations;


namespace RollOff_Test4API.Models.Domain
{
    public class Register
    {
        [Key]
        public int Empid { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }

        [Required]
        public string PWD { get; set; }
    }
}
