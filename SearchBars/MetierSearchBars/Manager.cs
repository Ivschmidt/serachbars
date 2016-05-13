using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Manager
    {
        private IDataManager dataMgr;
        public User CurrentUser { get; private set; }
        private HashSet<User> listUsers = new HashSet<User>();
        private List<Bar> listBar = new List<Bar>();

        public Manager(IDataManager dataManager)
        {
            dataMgr = dataManager;
            CurrentUser = null;
        }

        private bool rechercherUser(string pseudo)
        {
            foreach (User user in listUsers)
                if (user.Pseudo.Equals(pseudo))
                {
                    CurrentUser = user;
                    return true;
                }
            return false;
        }

        public bool seConnecter(string pseudo, string mdp) //il faudra faire avec un event et non un bool
        {
            if(!this.rechercherUser(pseudo))
                return false;
            else 
                return (CurrentUser.Mdp.Equals(mdp));    
        }

        public void sInscrire(string pseudo, string mdp, string nom, string prenom, Sexe sexe, DateTime ddN, string numTel = "", string ville = "", Boisson boissonPref = null)
        {
            if(rechercherUser(pseudo))
            {
                throw new Exception("Cet user existe déja");
            }
            User newUser = new User(pseudo, mdp, nom, prenom, sexe, ddN, numTel, ville, boissonPref);
            listUsers.Add(newUser);
        }

        public void seDeconnecter()
        {
            CurrentUser = null;
        }
    }
}
