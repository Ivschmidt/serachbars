using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Manager
    {
        public User CurrentUser { get; set; }
        private UserManager useMan;

        public Manager()
        {
            CurrentUser = null;
            useMan = new UserManager();
        }
        public bool seConnecter(string pseudo, string mdp)
        {
            CurrentUser = useMan.rechercherUser(pseudo);
            if (CurrentUser != null)
                return false;
            else 
                return (CurrentUser.Mdp.Equals(mdp);    
        }
    }
}
