using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabMVC.Models
{
    public class MathData
    {
        public float Value1 { get; set; }
        public float Value2 { get; set; }
        public float Sum { get; set; }
        public float Differnce { get; set; }
        public float Product { get; set; }
        public float Quotient { get; set; }
        public MathData
            (float Value1
            , float Value2
            , float Sum
            , float Differnce
            , float Product
            , float Quotient)
        {
            this.Value1 = Value1;
            this.Value2 = Value2;
            this.Sum = Sum;
            this.Differnce = Differnce;
            this.Product = Product;
            this.Quotient = Quotient;
        }
    }
}