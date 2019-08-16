using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DataReadException : Exception
    {
        public DataReadException(string message) : base(message)
        {

        }
    }
}
