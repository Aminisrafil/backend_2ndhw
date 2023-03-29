using lesson02_hw.Model;
using lesson02_hw.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace lesson02_hw.Controllers
{
    public class StudentController : Controller
    {
        List<Student> _students;
        List<Group> _groups;
        public StudentController()
        {
            _students= new List<Student>
            {
                new Student {FullName = "Amin", Id = 1, Point = 95 },
                new Student {FullName = "Elvin", Id = 2, Point = 85},
                new Student {FullName = "Maqsud", Id = 3, Point = 70 }
            };
            _groups = new List<Group>
            {
                new Group {Id = 1, Name = "P232"},
                new Group {Id = 2,Name = "D232"}
            };

            
        }

        public IActionResult Index()
        {

            StudentGroup studentgroups = new StudentGroup()
            {
                Groups = _groups,
                Students = _students

            };
            

            return View(studentgroups);

        }
        public ViewResult Error()
        {
            return View();
        }
        
        public ActionResult Detail(int id)
        {
            if (id < 1 || id >3)
                return RedirectToAction("Error");

            Student std = _students.Find(x => x.Id == id);
            return View(std);
        }

    }
}
