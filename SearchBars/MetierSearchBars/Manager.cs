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
            mCurrentUser = listUsers.SingleOrDefault(user => user.Pseudo.Equals(pseudo));
            return (CurrentUser != null);
        }

        public bool seConnecter(string pseudo, string mdp) //il faudra faire avec un event et non un bool
        {
            if(!rechercherUser(pseudo))
                return false;
            else
                return (CurrentUser.Mdp.Equals(mdp));
        }


        public void sInscrire(string pseudo, string mdp, string nom, string prenom, Sexe sexe, DateTime ddN, string numTel = "", string ville = "", TypeBoisson? boissonPref = null)
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


        public IEnumerable<IBar> rechercherBars(IVille ville, bool restauration = false, List<TypeBoisson> listTypeBoissonPref = null, float noteMin = 0)
        {
            IEnumerable<IBar> temp = ville.ListBar;

            if (restauration)
            {
                temp = temp.Where(bars => bars.Restauration == true);
            }

            temp = temp.Where(bars => bars.NoteMoyenne >= noteMin);

            if (listTypeBoissonPref != null && listTypeBoissonPref.Count()>0)
            {
                temp.Where(bars => bars.ListBoisson.Select(types => types.Type).Distinct().Intersect(listTypeBoissonPref).Count() > 0);
                
            }

            return temp;
        }

        /// <summary>
        /// Méthode qui modifie les paramètres utilisateurs
        /// </summary>
        /// <param name="npseudo"></param>
        /// <param name="nmdp"></param>
        /// <param name="nprenom"></param>
        /// <param name="nnom"></param>
        /// <param name="nddn"></param>
        /// <param name="nnumTel"></param>
        /// <param name="nville"></param>
        /// <param name="nBoissonPref"></param>
        public void modifierUser(string npseudo="", string nmdp="", string nprenom="", string nnom="", DateTime? nddn = null, string nnumTel="", string nville="", TypeBoisson? nBoissonPref = null)
        {
            if(npseudo != null)             //Vérifie si le pseudo doit être modifié
            {
                mCurrentUser.Pseudo = npseudo;
            }

            if(nmdp != null)             //Vérifie si le mot de passe doit être modifié
            {
                mCurrentUser.Mdp = nmdp;
            }

            if(nprenom != null)             //Vérifie si le prénom doit être modifié
            {
                mCurrentUser.Prenom = nprenom;
            }

            if(nnom != null)             //Vérifie si le nom doit être modifié
            {
                mCurrentUser.Nom = nnom;
            }

            if(nddn != null)             //Vérifie si la date de naissance doit être modifié
            {
                mCurrentUser.DdN = (DateTime)nddn;
            }

            if(nnumTel != null)             //Vérifie si le numéro de téléphone doit être modifié
            {
                mCurrentUser.NumTel = nnumTel;
            }

            if(nville != null)             //Vérifie si la ville doit être modifié
            {
                mCurrentUser.Ville = nville;
            }

            if(nBoissonPref != null)             //Vérifie si la boisson préférée doit être modifié
            {
                mCurrentUser.BoissonPref = nBoissonPref;
            }
        }

        //Méthode qui vise à vérifier le mot de passe de l'utilisateur connecté
        public bool verifierMotDePasse(string mdp)
        {
            return mdp.Equals(mCurrentUser.Mdp);
        }
    }
}
