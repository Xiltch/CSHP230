using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabMVC.Controllers
{
    public class Lab06Controller : Controller
    {
        // GET: Lab06
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateValues(string Value1, string Value2)
        {
            float fltV1 = float.Parse(Value1);
            float fltV2 = float.Parse(Value2);
            float fltSum = fltV1 + fltV2;
            float fltDif = Math.Abs(fltV1 - fltV2);
            float fltPro = fltV1 * fltV2;
            float fltQuo = fltV1 / fltV2;
            LabMVC.Models.MathData objMD;
            objMD = new Models.MathData(fltV1, fltV2, fltSum, fltDif, fltPro, fltQuo);
            return View(objMD);
        }
    }
}