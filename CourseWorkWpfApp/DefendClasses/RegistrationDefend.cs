using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkWpfApp.DefendClasses
{
    public static class RegistrationDefend
    {
        public static bool Password(string password, string repeatPassw)
        {
            bool flag = false;
            if (password.Equals(repeatPassw)) flag = true;
            return flag;
        }
    }
}
