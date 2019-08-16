﻿using Assignment08.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment08.Domain.Entities
{
    public class Student : IStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public IEnumerable<IClass> Classes { get; set; }
    }
}