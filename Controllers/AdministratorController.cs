using Microsoft.AspNetCore.Mvc;
using StudentsEnrollment.Data;
using StudentsEnrollment.Models;
using System.Collections.Generic;

namespace StudentsEnrollment.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdministratorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<StudentAdministrator> objStudentAdministratorList = _db.StudentAdministrators;
            return View(objStudentAdministratorList);
        }
    }
}
