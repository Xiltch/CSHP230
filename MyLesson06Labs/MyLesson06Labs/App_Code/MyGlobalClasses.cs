using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLesson06Labs.App_Code
{
    [Serializable]
    public class Person
    {
        public string FirstName, LastName;

        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

    }

}