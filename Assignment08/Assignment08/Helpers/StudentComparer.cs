using Assignment08.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment08.Helpers
{
    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            //Check whether the compared objects reference the same data.
            if (Object.ReferenceEquals(x, y)) return true;

            //Check whether any of the compared objects is null.
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(Student obj)
        {
            //Check whether the object is null
            if (Object.ReferenceEquals(obj, null))
                return 0;

            return obj.Id.GetHashCode();
        }
    }
}