using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment08.Domain.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<IStudent> AllStudents();
        bool Validate(IStudent student);
    }
}
