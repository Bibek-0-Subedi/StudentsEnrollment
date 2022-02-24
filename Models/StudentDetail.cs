using System.ComponentModel.DataAnnotations;

namespace StudentsEnrollment.Models
{
    public class StudentDetail
    {
        [Key]
        public int StudentId { get; set; }
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
        [Required]
        public string Address { get; set; }
        [Required]
        [Range(0,4, ErrorMessage = "GPA must be between 0 and 4")]
        public decimal GPA { get; set; }
        [Required]
        public string Stream { get; set; }
        public bool EnrollmentStatus { get; set; } = false;

    }
}
