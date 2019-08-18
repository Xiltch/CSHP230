using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment08.Domain.Interfaces
{
    public interface ILoginRequest
    {
        int LoginId { get; set; }
        string Name { get; set; }
        string EmailAddress { get; set; }
        string LoginName { get; set; }
        string NewOrReactivate { get; set; }
        string ReasonForAccess { get; set; }
        DateTime DateRequiredBy { get; set; }
    }
}
