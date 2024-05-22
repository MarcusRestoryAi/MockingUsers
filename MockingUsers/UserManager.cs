using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingUsers
{
    public class UserManager
    {
        public UserDatabase UserDatabase { get; set; }
        public User CurrentUser { get; set; }


        public string Login(int id, string password)
        {
            //Hämta User från DB
            User user = UserDatabase.GetUserById(id);

            //Jämnför Password
            if (user.Password.Equals(password))
            {
                //Inloggning har lyckats
                CurrentUser = user;
                return "Inloggning Successfull!";
            }
            return "Inloggning Failed!";
        }

        public string SaveUser(User user)
        {
            if (user != null)
            {
                User userWithId = UserDatabase.GetUserById(user.Id);
                if (userWithId != null)
                {
                    return "User with that id already exists.";
                }
                UserDatabase.SaveNewUser(user);
                return "Save successful";
            }
            return "Invalid info";
        }
    }
}
