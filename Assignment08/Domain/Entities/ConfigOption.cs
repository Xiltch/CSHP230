using Assignment08.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment08.Domain.Entities
{
    public class ConfigOption : IConfigOption
    {
        public string ConnectionStringProjectContext { get; set; }
    }
}