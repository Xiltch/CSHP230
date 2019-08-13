using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment08.Domain.Interfaces
{
    public interface IClass
    {
        int Id { get; set; }
        string Name { get; set; }
        DateTime Date { get; set; }
        string Description { get; set; }
    }
}
