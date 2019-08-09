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
            InsertData(fltV1, fltV2, fltSum, fltDif, fltPro, fltQuo);
            return View(objMD);
        }

        public void InsertData(float V1, float V2, float Sum, float Dif, float Pro, float Quo)
        {
            string strPath = Server.MapPath(@"~\App_Data\MathDB.mdf");
            string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""" + strPath + @"""; Integrated Security = True";
            //strCon = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename = E:\UW\CSHP230\LabMVC\LabMVC\App_Data\MathDB.mdf; Integrated Security = True";
            string strCmd = @"Exec pInsMathData " +
                            " @Value1 = " + V1.ToString() +
                            ",@Value2 = " + V2.ToString() +
                            ",@Sum = " + Sum.ToString() +
                            ",@Differnce = " + Dif.ToString() +
                            ",@Product = " + Pro.ToString() +
                            ",@Quotient = " + Quo.ToString();
            System.Data.SqlClient.SqlConnection objCon;
            System.Data.SqlClient.SqlCommand objCmd;
            objCon = new System.Data.SqlClient.SqlConnection(strCon);
            objCmd = new System.Data.SqlClient.SqlCommand(strCmd, objCon);
            objCon.Open();
            objCmd.ExecuteNonQuery();
            objCon.Close();
        }
    }
}