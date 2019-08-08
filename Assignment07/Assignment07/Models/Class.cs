using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment07.Models
{
    public class Class
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public List<Student> Students {get; set; }

        public Class()
        {
            this.Students = new List<Student>();
        }
    }
}