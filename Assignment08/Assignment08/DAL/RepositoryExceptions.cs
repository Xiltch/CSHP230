using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment08.DAL
{
    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message) : base(message)
        {
        }
    }
}