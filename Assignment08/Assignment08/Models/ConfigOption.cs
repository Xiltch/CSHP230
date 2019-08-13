using Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment08.Models
{
    public class ConfigOption : IConfigOption
    {
        public string ConnectionStringProjectContext { get; set; }
    }
}