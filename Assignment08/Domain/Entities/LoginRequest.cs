using Assignment08.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment08.Domain.Entities
{
    public class LoginRequest : ILoginRequest
    {
        public int LoginId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string LoginName { get; set; }
        public string NewOrReactivate { get; set; }
        public string ReasonForAccess { get; set; }
        public DateTime DateRequiredBy { get; set; }
    }
}
