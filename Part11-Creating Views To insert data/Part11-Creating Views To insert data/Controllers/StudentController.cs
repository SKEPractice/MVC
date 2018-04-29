﻿using System;
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
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}