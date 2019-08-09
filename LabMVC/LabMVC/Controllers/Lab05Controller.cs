using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabMVC.Controllers
{
    public class Lab05Controller : Controller
    {
        // GET: Lab05
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateSum(string Value1, string Value2)
        {
            ViewData["Value1"] = Value1;
            ViewData["Value2"] = Value2;
            float fltSum = float.Parse(Value1) + float.Parse(Value2);
            ViewData["ResultingSum"] = fltSum.ToString();
            return View();
        }
    }
}