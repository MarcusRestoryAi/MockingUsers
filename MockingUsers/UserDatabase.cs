using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingUsers
{
    public class UserDatabase
    {
        public virtual User GetUserById(int id)
        {
            //Anropa DB och hämta User objekt. Returnera det
            //Nedanstående objekt kommer aldrig att användas i test-sammanhang
            return new User(1, "Whatever", "Whatever");
        }

        public virtual void SaveNewUser(User user)
        {
            //Spara ny användare till DB
        }
    }
}
