using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWorkWpfApp.DefendClasses
{
    public static class AuthorizationDefend
    {
        public static bool EntranceToSystem(string login, string password)
        {
            if ((login.Length > 10) || (password.Length > 4)) return false;

            try
            {
                using (var DB = new DatabaseContext())
                {
                    if((DB.User.Where(x => x.login.Equals(login)).Count()!=1)||
                    (DB.User.Where(y => y.password.Equals(password)).Count()!=1))
                        return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return true;
        }
    }
}
