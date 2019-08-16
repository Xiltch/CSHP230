using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment08.Domain.Exceptions
{
    class UpdateException : Exception
    {
        public UpdateException(string message) : base(message)
        {
        }
    }

}
