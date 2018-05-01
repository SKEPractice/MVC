using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Part11_Creating_Views_To_insert_data.Models;
using Part11_Creating_Views_To_insert_data.Models.Interfaces;

namespace Part11_Creating_Views_To_insert_data.Controllers
{
    public class StudentController : Controller
    {
        EmployeeContext db = new EmployeeContext();
        // GET: Student
        public ActionResult Index()
        {
            List<Student> studentList = db.Students.ToList();
            return View(studentList);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Create(FormCollection frmCollection)
        //{
        //    Student student = new Student();
        //    student.Name = frmCollection["Name"];
        //    student.Gender = frmCollection["Gender"];
        //    student.Address = frmCollection["Address"];
        //    student.DateOfBirth = Convert.ToDateTime(frmCollection["DateOfBirth"]);
        //    db.students.Add(student);
        //    db.SaveChanges();
        //    return Redirect("Index");
        //}

        //Using parameter insted of form collection object
        //[HttpPost]
        //public ActionResult Create(string name,string gender,string address,DateTime dateOfBirth)
        //{
        //    Student student = new Student();
        //    student.Name = name;
        //    student.Gender = gender;
        //    student.Address = address;
        //    student.DateOfBirth = Convert.ToDateTime(dateOfBirth);
        //    db.students.Add(student);
        //    db.SaveChanges();
        //    return Redirect("Index");
        //}


        //We can also take object as a parameter
        //[HttpPost]
        //public ActionResult create(Student student)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.students.Add(student);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        /* save operation can be done without passing any parameters using modelupdate object and eleminate method overloading using 
         * renaming the method name and using action name attribute */
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Student student = new Student();
            UpdateModel(student);
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(int id)
        {
            Student student = db.Students.Single(stu => stu.ID == id);
            return View(student);
        }

        //edit post using mode as  parameter this may caus unintended update
        //[HttpPost]
        //public ActionResult Edit(Student studentUpdate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Student student = db.students.Single(stu => stu.ID == studentUpdate.ID);
        //        student.Name = studentUpdate.Name;
        //        student.Address = studentUpdate.Address;
        //        student.Gender = studentUpdate.Gender;
        //        student.DateOfBirth = studentUpdate.DateOfBirth;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(studentUpdate);
        //}

        //To avoid unintended update we explicitly the properties that we want to in model binding
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post(int id)
        //{
        //    Student student = db.students.Single(stu => stu.ID == id);
        //    //Black list model binding
        //    UpdateModel(student, null, null, new string[] { "Name" });
        //    if (ModelState.IsValid)
        //    {
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //Using Bind attribute we are abale to specify our include or exclude list insted of using 
        //string arry in update model function
        [HttpPost]
        [ActionName("Edit")]
        //public ActionResult Edit_Post([Bind(Include = "ID,Gender,Address,DateOfBirth")] Student studentUpdate)
        //{
        //public ActionResult Edit_Post([Bind(Exclude = "Name")] Student studentUpdate)
        //{
        //    studentUpdate.Name = db.students.Single(stu => stu.ID == studentUpdate.ID).Name;
        //    if (ModelState.IsValid)
        //    {
        //        Student student = db.students.Single(stu => stu.ID == studentUpdate.ID);
        //        student.Address = studentUpdate.Address;
        //        student.Gender = studentUpdate.Gender;
        //        student.DateOfBirth = studentUpdate.DateOfBirth;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(studentUpdate);
        //}

            //using Interfaces to include or exclude properties from model binding
        public ActionResult Edit_Post(int id)
        {
            Student student = db.Students.Single(stu => stu.ID == id);
            UpdateModel<IStudent>(student);
            if (ModelState.IsValid)
            {
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

    }
}