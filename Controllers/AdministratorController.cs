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

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var studentAdministratorFromDb = _db.StudentAdministrators.Find(id);

            if (studentAdministratorFromDb == null)
            {
                return NotFound();
            }

            return View(studentAdministratorFromDb);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentAdministrator obj)
        {
            if (ModelState.IsValid)
            {
                _db.StudentAdministrators.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Student administrator added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET request
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var studentAdministratorFromDb = _db.StudentAdministrators.Find(id);

            if (studentAdministratorFromDb == null)
            {
                return NotFound();
            }

            return View(studentAdministratorFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(StudentAdministrator obj)
        {
            if (ModelState.IsValid)
            {
                _db.StudentAdministrators.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Student administrator updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var studentAdministratorFromDb = _db.StudentAdministrators.Find(id);

            if (studentAdministratorFromDb == null)
            {
                return NotFound();
            }

            return View(studentAdministratorFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.StudentAdministrators.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _db.StudentAdministrators.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Student administrator removed successfully";
            return RedirectToAction("Index");
        }
    }
}
