using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Part11_Creating_Views_To_insert_data.Models;

namespace Part11_Creating_Views_To_insert_data.Controllers
{
    public class StudentController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        // GET: Student
        public ActionResult Index()
        {
            List<Student> studentList = db.students.ToList();
            return View(studentList);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection frmCollection)
        {
            Student student = new Student();
            student.Name = frmCollection["Name"];
            student.Gender = frmCollection["Gender"];
            student.Address = frmCollection["Address"];
            student.DateOfBirth = Convert.ToDateTime(frmCollection["DateOfBirth"]);
            db.students.Add(student);
            db.SaveChanges();
            return Redirect("Index");
        }
    }
}