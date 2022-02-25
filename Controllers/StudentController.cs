using Microsoft.AspNetCore.Mvc;
using StudentsEnrollment.Data;
using StudentsEnrollment.Models;
using System.Collections.Generic;

namespace StudentsEnrollment.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;

        //Fetching the files from the database
        public StudentController(ApplicationDbContext db)
        {
            _db = db;   
        }
        public IActionResult Index()
        {
            IEnumerable<StudentDetail> objStudentList = _db.StudentDetails;
            return View(objStudentList);
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var studentDetailsFromDb = _db.StudentDetails.Find(id);

            if (studentDetailsFromDb == null)
            {
                return NotFound();
            }

            return View(studentDetailsFromDb);
        }

        //GET request
        public IActionResult Create()
        {
            return View();
        }

        //POST request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentDetail obj)
        {
            if (ModelState.IsValid)
            {
                _db.StudentDetails.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Student details added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET request
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var studentDetailsFromDb = _db.StudentDetails.Find(id);

            if(studentDetailsFromDb == null)
            {
                return NotFound();
            }

            return View(studentDetailsFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentDetail obj)
        {
            if (ModelState.IsValid)
            {
                _db.StudentDetails.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Student details updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if(id ==null || id == 0)
            {
                return NotFound();
            }

            var studentDetailsFromDb = _db.StudentDetails.Find(id);

            if (studentDetailsFromDb == null)
            {
                return NotFound();
            }

            return View(studentDetailsFromDb);
        }

        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.StudentDetails.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.StudentDetails.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Student detail removed successfully";
            return RedirectToAction("Index");
        }
    }
}
