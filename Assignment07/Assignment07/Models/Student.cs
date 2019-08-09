using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment07.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Class> Classes { get; set; }

        public Student()
        {
            this.Classes = new List<Class>();
        }
    }
}