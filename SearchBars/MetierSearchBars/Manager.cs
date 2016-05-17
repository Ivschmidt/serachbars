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
        public IUser CurrentUser { get; private set; } //demander prof pq mettre IUser

        private HashSet<User> listUsers = new HashSet<User>(); 
        //public IEnumerable<IUser> ListUsers
        //{
        //    get
        //    {
        //        return listUsers;
        //    }
        //}

        private List<Ville> listVille = new List<Ville>();
        //public IEnumerable<IVille> ListVilles
        //{
        //    get
        //    {
        //        return listVille;
        //    }
        //}

        public Manager(IDataManager dataManager)
        {
            dataMgr = dataManager;
            CurrentUser = null;
        }

        private bool rechercherUser(string pseudo)
        {
            CurrentUser = listUsers.Single(user => user.Pseudo.Equals(pseudo));
            return (CurrentUser == null);
        }

        public bool seConnecter(string pseudo, string mdp) //il faudra faire avec un event et non un bool
        {
            if(!this.rechercherUser(pseudo))
                return false;
            else 
                return (CurrentUser.Mdp.Equals(mdp));    
        }

        public void sInscrire(string pseudo, string mdp, string nom, string prenom, Sexe sexe, DateTime ddN, string numTel = "", string ville = "", TypeBoisson boissonPref = TypeBoisson.None)
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

        //public IEnumerable<IBar> rechercherBars(IVille ville, bool restauration = false, List<Boisson> list = null, float noteMin = -1)
        //{

        //}
    }
}
