using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment08.Domain.Interfaces
{
    public interface IConfigOption
    {
        string ConnectionStringProjectContext { get; set; }
    }
}
