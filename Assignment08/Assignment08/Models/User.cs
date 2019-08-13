using Assignment08.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment08.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; private set; }

        public User()
        {
        }

        public User(IStudent student)
        {
            this.Id = student.Id;
            this.Login = student.Login;
            this.Password = student.Password;
            this.isAdmin = student.Id == 0;
        }

        // Used to create an instance of Admin user
        public User(bool admin)
        {
            this.isAdmin = admin;
        }

    }
}