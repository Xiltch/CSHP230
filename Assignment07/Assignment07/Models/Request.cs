using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment07.Models
{
    public class Request
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Type { get; set; }
        public string Reason { get; set; }
        public DateTime RequiredBy { get; set; }
    }
}