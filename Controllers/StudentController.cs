using Microsoft.AspNetCore.Mvc;
using StudentsEnrollment.Data;
using StudentsEnrollment.Models;
using System.Collections.Generic;

namespace StudentsEnrollment.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            IEnumerable<StudentDetail> objStudentList = _db.StudentDetails;
            return View(objStudentList);
        }
    }
}
