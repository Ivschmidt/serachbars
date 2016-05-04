using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class UserManager
    {
        private HashSet<User> listUsers;

        public UserManager()
        { 
            listUsers = new HashSet<User>(); 
        }

        public User rechercherUser(string pseudo)
        {
            foreach (User user in listUsers)
                if (user.Pseudo.Equals(pseudo))
                    return user;
            return null;
        }
    }
}
