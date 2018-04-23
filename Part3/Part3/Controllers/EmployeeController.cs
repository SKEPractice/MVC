using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Part3.Models;
namespace Part3.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Details(int id)
        {
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employee = employeeContext.employees.Single(emp => emp.EmployeeID == id);
            //Employee employee = new Employee();
            //employee.EmployeeID = 01;
            //employee.Name = "yugesh";
            //employee.Gender = "Male";
            //employee.City = "Kathmandu"; 
            return View(employee);
        }
    }
}