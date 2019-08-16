using Assignment08.Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment08.Models
{
    public class Student : IComparable, IEqualityComparer
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool isAdmin { get; private set; }
        public IEnumerable<Class> Classes { get; set; }

        public Student()
        {
        }

        public Student(IStudent student)
        {
            this.Id = student.Id;
            this.Login = student.Login;
            this.Password = student.Password;
            this.Name = student.Name;
            this.isAdmin = student.Id == 0;
        }

        // Used to create an instance of Admin user
        public Student(bool admin)
        {
            this.isAdmin = admin;
        }

        public int CompareTo(object obj)
        {
            return Id.CompareTo(obj);
        }

        public new bool Equals(object x, object y)
        {
            if (x is null && y is null)
                return true;

            if (x is null)
                return false;

            if (!(x is Student) || !(y is Student))
                return false;

            return ((Student)x).CompareTo(y) == 0;

        }

        public int GetHashCode(object obj)
        {
            return Id.GetHashCode();
        }
    }
}