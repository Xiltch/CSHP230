using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment08.Models
{
    public class User
    {

        private string password;
        private bool authorized;

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password
        {
            get { if (authorized) return null; return password; }
            set { password = value; }
        }
        public bool Authenticated
        {
            get { return authorized; }
            set { authorized = value; if (authorized) password = null; }
        }

        public User()
        {
            this.Id = -1; // Default ID to ensure not an admin
        }
    }
}