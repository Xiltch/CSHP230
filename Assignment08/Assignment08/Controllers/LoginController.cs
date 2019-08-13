using Assignment08.Domain.Entities;
using Assignment08.Domain.Exceptions;
using Assignment08.Domain.Interfaces;
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

        private readonly IStudentRepository context;

        public LoginController(IStudentRepository context)
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
                var student = context.Authenticate(user.Login, user.Password);

                if (student != null)
                {
                    // need to store the user in a session
                    this.Session["currentUser"] = student;
                    return RedirectToAction("Mine", "Class");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to login");
                    return View();
                }

            } catch (AuthenticationException e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }

        }

        [ActionName("Request")]
        public ActionResult RequestLogin()
        {
            return View("RequestLogin");
        }
    }
}