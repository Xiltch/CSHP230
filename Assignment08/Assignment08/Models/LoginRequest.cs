using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment08.Models
{
    public class LoginRequest
    {
        public int LoginId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }
        [Display(Name="Type")]
        public string NewOrReactivate { get; set; }
        [Display(Name = "Reason for Access")]
        public string ReasonForAccess { get; set; }
        [Display(Name = "Date required by")]
        public DateTime DateRequiredBy { get; set; }
    }
}