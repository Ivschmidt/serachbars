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
        public IUser CurrentUser
        {
            get
            {
                return mCurrentUser;
            }
        }
        private User mCurrentUser;

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
            mCurrentUser = null;
        }

        private bool rechercherUser(string pseudo)
        {
            mCurrentUser = listUsers.Single(user => user.Pseudo.Equals(pseudo));
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
            mCurrentUser = null;
        }

        public IEnumerable<IBar> rechercherBars(IVille ville, bool restauration = false, List<TypeBoisson> listTypeBoisson = null, float noteMin = 0)
        {
            IEnumerable<IBar> temp = ville.ListBar;

            if (restauration)
            {
                temp = temp.Where(bars => bars.Restauration == true);
            }

            temp = temp.Where(bars => bars.NoteMoyenne >= noteMin);

            if (listTypeBoisson != null && listTypeBoisson.Count()>0)
            {
                //easy
                temp.Where(bars => bars.ListBoisson.Select(types => types.Type).Distinct().Count() > 0);
                
            }

            return temp;
        }
    }
}
