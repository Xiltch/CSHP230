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
        IStudent Authenticate(string login, string password);
        IStudent GetStudent(int StudentId);
        int NewLogin(ILoginRequest request);
    }
}
