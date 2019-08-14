using Assignment08.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment08.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public Class()
        {
        }

        public Class(IClass obj)
        {
            this.Id = obj.Id;
            this.Name = obj.Name;
            this.Date = obj.Date;
            this.Description = obj.Description;
        }
    }
}