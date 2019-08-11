using Assignment08.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment08.Controllers
{
    public class ClassController : Controller
    {
        private ProjectRepository repository;

        public ClassController(ProjectRepository projectRepository)
        {
            this.repository = projectRepository;
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
            return View();
        }
    }
}