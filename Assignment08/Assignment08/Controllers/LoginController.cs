using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment08.Controllers
{
    public class LoginController : Controller
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string login, string password)
        {
            return View();
        }

        [ActionName("Request")]
        public ActionResult RequestLogin()
        {
            return View("RequestLogin");
        }
    }
}