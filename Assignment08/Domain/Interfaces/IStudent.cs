using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment08.Domain.Interfaces
{
    public interface IStudent
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        IEnumerable<IClass> Classes { get; set; }
    }
}
