using Microsoft.EntityFrameworkCore;
using StudentsEnrollment.Models;

namespace StudentsEnrollment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<StudentDetail> StudentDetails { get; set; }
        public DbSet<StudentAdministrator> StudentAdministrators { get; set; }
    }
}
