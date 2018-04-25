using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Part11_Creating_Views_To_insert_data.Models;
namespace Part11_Creating_Views_To_insert_data.Controllers
{
    public class HomeController : Controller
    {
        EmployeeContext employeeContext = new EmployeeContext();
        // GET: Home
        public ActionResult Index()
        {
            List<Employee> employeeList = employeeContext.Employees.ToList();
            return View(employeeList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}