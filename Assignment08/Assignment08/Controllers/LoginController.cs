using Assignment08.DAL;
using Assignment08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment08.Controllers
{
    public class LoginController : Controller
    {

        private readonly ProjectRepository context;

        public LoginController(ProjectRepository context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User user)
        {

            if (!ModelState.IsValid)
                return View();

            try
            {
                user.Id = context.Authenticate(user.Login, user.Password);
                user.Authenticated = true;

                // need to store the user in a session
                this.Session["currentUser"] = user;

            }
            catch (AuthenticationException e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }



            return RedirectToAction("Mine", "Class");
        }

        [ActionName("Request")]
        public ActionResult RequestLogin()
        {
            return View("RequestLogin");
        }
    }
}