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
            var classes = context.GetClasses()
                     .Select(x => new Class(x));
            return View(classes);
        }

        public ActionResult Details(int classId)
        {
            var classInfo = context.ClassDetails(classId);

            return View(new Class(classInfo));
        }

        public ActionResult Register(int classId)
        {
            if (this.Session["currentUser"] is Models.Student user)
            {
                context.RegisterForClass(classId, user.Id);
                return RedirectToAction("Details", "Class", new { classId = classId });
            }
            
            return RedirectToAction("Index", "Login");
        }

        public ActionResult UnRegister(int classId)
        {
            if (this.Session["currentUser"] is Models.Student user)
            {
                context.DeRegisterFromClass(classId, user.Id);
                return RedirectToAction("Details", "Class", new { classId = classId });
            }

            return RedirectToAction("Index", "Login");
        }

        public ActionResult Mine()
        {
            if (this.Session["currentUser"] is Student user)
            {
                var classes = context.GetClasses(user.Id)
                    .Select(x => new Class(x));
                return View(classes);
            }

            return RedirectToAction("Index", "Login");
        }
    }
}