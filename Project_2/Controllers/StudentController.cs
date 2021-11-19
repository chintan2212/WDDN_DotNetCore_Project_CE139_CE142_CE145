using Microsoft.AspNetCore.Mvc;
using Project_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_2.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Project_2.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentrepository;
        public StudentController(IStudentRepository studentrepository)
        {
            _studentrepository = studentrepository;
        }
        public ViewResult Index()
        {

            var model =_studentrepository.GetAllStudents();
            return View(model);
        }

        public ViewResult Details(int id)
        {

            Student model = _studentrepository.GetStudent(id);
            return View(model);
        }
        
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Student stu = _studentrepository.GetStudent(id);
            StudentEditViewModel studentEditViewModel = new StudentEditViewModel
            {
                Id = stu.Id,
                name = stu.name,
                sem = stu.sem,
                email = stu.email,
                department = stu.department,
                gender = stu.gender
            };
            return View(studentEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(StudentEditViewModel stu)
        {
            Student s = _studentrepository.GetStudent(stu.Id);
            s.name = stu.name;
            s.email = stu.email;
            s.sem = stu.sem;
            s.department = stu.department;
            s.gender = stu.gender;
            _studentrepository.Update(s);
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student s = _studentrepository.GetStudent(id);
            if (s == null)
            {
                return NotFound();
            }
            return View(s);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Student stu = _studentrepository.GetStudent(id);
            _studentrepository.Delete(stu.Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Student stu)
        {
            if (ModelState.IsValid)
            {
                Student newstudent = _studentrepository.Addstudent(stu);
                return RedirectToAction("Details", new { id = newstudent.Id });
            }
            else
            {
                return View();
            }
        }

    }
}
