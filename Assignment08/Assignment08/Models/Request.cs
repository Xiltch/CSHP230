using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment08.Models
{
    public class Request
    {
        public int LoginId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }
        [Required]
        [Display(Name="Type")]
        public string NewOrReactivate { get; set; }
        [Required]
        [Display(Name = "Reason for Access")]
        public string ReasonForAccess { get; set; }
        [Required]
        [Display(Name = "Date required by")]
        public DateTime DateRequiredBy { get; set; }
    }
}