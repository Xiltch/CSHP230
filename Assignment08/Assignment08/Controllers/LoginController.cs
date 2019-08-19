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
            if (this.Session["currentUser"] is Models.Student user)
            {
                return RedirectToAction("LoggedIn");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.Student user)
        {

            if (!ModelState.IsValid)
                return View();


            try
            {
                var student = context.Authenticate(user.Login, user.Password);

                if (student != null)
                {
                    // need to store the user in a session
                    this.Session["currentUser"] = new Models.Student(student);
                    return RedirectToAction("Mine", "Class");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to login");
                    return View();
                }

            }
            catch (AuthenticationException e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }

        }

        public ActionResult LoggedIn()
        {
            if (this.Session["currentUser"] is Models.Student user)
            {
                return View(user);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Logout()
        {
            if (this.Session["currentUser"] is Models.Student user)
            {
                return View(user);
            }

            return RedirectToAction("Index");
        }

        public ActionResult LoggedOut()
        {
            this.Session.Remove("currentUser");

            return RedirectToAction("Index");
        }

        [ActionName("Request")]
        [HttpGet]
        public ActionResult RequestLogin()
        {
            return View();
        }

        [ActionName("Request")]
        [HttpPost]
        public ActionResult RequestLogin(Request request)
        {
            if (!ModelState.IsValid)
                return View("Request");

            this.context.NewLogin(new LoginRequest()
            {
                Name = request.Name,
                LoginName = request.LoginName,
                EmailAddress = request.EmailAddress,
                NewOrReactivate = request.NewOrReactivate,
                ReasonForAccess = request.ReasonForAccess,
                DateRequiredBy = request.DateRequiredBy
            });

            return View("RequestSent");
        }
    }
}