using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Manager
    {
        internal User CurrentUser { get; private set; }
        private HashSet<User> listUsers = new HashSet<User>();
        private List<Bar> listBar = new List<Bar>();

        public Manager()
        {
            CurrentUser = null;
        }

        private User rechercherUser(string pseudo)
        {
            foreach (User user in listUsers)
                if (user.Pseudo.Equals(pseudo))
                    return user;
            return null;
        }

        public bool seConnecter(string pseudo, string mdp) //il faudra faire avec un event et non un bool
        {
            CurrentUser = this.rechercherUser(pseudo);
            if (CurrentUser != null)
                return false;
            else 
                return (CurrentUser.Mdp.Equals(mdp);    
        }
    }
}
