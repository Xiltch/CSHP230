using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment08.Domain.Interfaces
{
    public interface IClassRepository
    {
        IEnumerable<IClass> GetClasses();
        IEnumerable<IClass> GetClasses(int studentId);
        IEnumerable<IClass> RegisterForClass(int classId, int studentId);

    }
}
