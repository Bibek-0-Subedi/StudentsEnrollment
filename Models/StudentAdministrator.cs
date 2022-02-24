using System.ComponentModel.DataAnnotations;

namespace StudentsEnrollment.Models
{
    public class StudentAdministrator
    {
        [Key]
        public int AdministratorId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int ContactNumber { get; set; }
    }
}
