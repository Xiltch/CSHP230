using Assignment08.Domain.Interfaces;
using Assignment08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment08.Controllers
{
    public class ClassController : Controller
    {
        private IClassRepository context;

        public ClassController(IClassRepository context)
        {
            this.context = context;
        }

        // GET: Class
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Mine()
        {
            if (this.Session["currentUser"] is User user)
            {
                var classes = context.GetClasses(user.Id)
                    .Select(x => new Class(x));
                return View(classes);
            }

            return RedirectToAction("Index", "Login");
        }
    }
}