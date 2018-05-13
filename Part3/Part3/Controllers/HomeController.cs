using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Part3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "This is my first MVC Application";
        }
        public string GetDetails()
        {
            return "Get details Invoked";
        }
        public string RollName(string id)
        {
            return "my roll no is " + id+" Name= "+Request.QueryString["name"];
        }
        public string RollParameter(string id, string name)
        {
            return "my name is "+name+" and my roll no is " + id;
        } 
        public ViewResult ContryList()
        {
            ViewBag.countires = new List<string>()
            {
                "Nepal",
                "China",
                "US"
            };
            return View();
        }
        public ActionResult BookList()
        {
            ViewData["books"] = new List<string>
            {
                "Maths",
                "Science",
                "English"
            };
            return View();
        }
    }
}