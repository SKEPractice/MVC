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
    }
}