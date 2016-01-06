using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkWpfApp.DefendClasses
{
    public static class AddDefend
    {
        public static bool AddClientDefend(string surname, string name, int sex, string passport, string address)
        {
            if ((surname.Equals(null) || (name.Equals(null)) || (sex.Equals(null)) || (passport.Equals(null)) || (address.Equals(null))))return false;

            return true;
        }

        public static bool AddCoachDefend(string surname, string name, int sex, string passport, string address)
        {
            if ((surname.Equals(null) || (name.Equals(null)) || (sex.Equals(null)) || (passport.Equals(null)) || (address.Equals(null)))) return false;

            return true;
        }

        public static bool AddPersonalServiceDefend(string title, double price, double addPayment)
        {
            if ((title.Equals(null)) || (price.Equals(null)) || (addPayment.Equals(null))) return false;

            return true;
        }

        public static bool AddGroupService(string title, double price, int roomNum)
        {
            if ((title.Equals(null)) || (price.Equals(null)) || (roomNum.Equals(null))) return false;

            return true;
        }

        public static bool AddContract(double salary)
        {
            if (salary.Equals(null)) return false;

            return true;
        }

    }
}
