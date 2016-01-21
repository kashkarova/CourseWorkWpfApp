using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseWorkWpfApp.DefendClasses
{
    public static class AddDefend
    {
        public static bool AddClientDefend(string surname, string name, int sex, string passport, string address, string telephone)
        {
            if (surname.Equals(null) || (name.Equals(null)) || (sex.Equals(null)) || (passport.Equals(null)) || (address.Equals(null)))return false;

            if (telephone.Equals(null)) return true;

            double i = 0;
            try
            {
                i = Convert.ToDouble(telephone);
            }
            catch { return false; }

            return true;
        }

        public static bool AddCoachDefend(string surname, string name, int sex, string passport, string address)
        {
            if ((surname.Equals(null) || (name.Equals(null)) || (sex.Equals(null)) || (passport.Equals(null)) || (address.Equals(null)))) return false;

            return true;
        }

        public static bool AddPersonalServiceDefend(string title, string price, string addPayment)
        {
            if ((title.Equals(null)) || (price.Equals(null)) || (addPayment.Equals(null))) return false;

            try
            {
                Convert.ToDouble(price);
                Convert.ToDouble(addPayment);
            }
            catch { return false; }

            return true;
        }

        public static bool AddGroupService(string title, string price, string roomNum)
        {
            if ((title.Equals(null)) || (price.Equals(null)) || (roomNum.Equals(null))) return false;

            try
            {
                Convert.ToDouble(price);
                Convert.ToInt32(roomNum);
            }
            catch { return false; }

            return true;
        }

        public static bool AddContract(string salary)
        {
            if (salary.Equals(null)) return false;

            try
            {
                Convert.ToDouble(salary);
            }
            catch { return false; }

            return true;
        }

        public static bool AddPostTitle(string title)
        {
            if(title.Equals(null)) return false;

            return true;
        }

        public static bool PriceParameter(string parameter)
        {
            try
            {
                Convert.ToDouble(parameter);
            }
            catch { return false; }

            return true;
        }

        public static bool ChangePassword(string new_passw, string repeat_new_passw)
        {
            if (!new_passw.Equals(repeat_new_passw)) return false;

            return true;
        }

        public static bool AddAbonementDefend(string client, DateTime date)
        {
            if ((client.Equals(null)) || (date.Equals(null)))return false;

            return true;
        }

        public static bool AddServicePositionDefendPersonal(string type, string title, string coach)
        {
            if ((type.Equals(null)) || (title.Equals(null)) || (coach.Equals(null))) return false;

            return true;
        }

        public static bool AddServicePositionDefendGroup(string type, string title, string roomnum)
        {
            if ((type.Equals(null)) || (title.Equals(null)) || (roomnum.Equals(null))) return false;

            try { Convert.ToInt32(roomnum); } catch { return false; }

            return true;
        }
    }
}
