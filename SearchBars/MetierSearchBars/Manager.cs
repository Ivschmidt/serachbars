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


        public void sInscrire(string pseudo, string mdp, string nom, string prenom, Sexe sexe, DateTime ddN, string numTel = "", string ville = "", TypeBoisson? boissonPref = null, string photo="")
        {
            if(rechercherUser(pseudo))
            {
                throw new Exception("Ce user existe déja");
            }
            User newUser = new User(pseudo, mdp, nom, prenom, sexe, ddN, numTel, ville, boissonPref, photo);
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
        /// <param name="npseudo">nouveau pseudo à modifier(optionnel)</param>
        /// <param name="nmdp">nouveau mot de passe à modifier(optionnel)</param>
        /// <param name="nprenom">nouveau prenom à modifier(optionnel)</param>
        /// <param name="nnom">nouveau nom à modifier(optionnel)</param>
        /// <param name="nddn">nouvelle date de naissance à modifier(optionnel)</param>
        /// <param name="nnumTel">nouveau numéro de téléphone à modifier(optionnel)</param>
        /// <param name="nville">nouvelle ville à modifier(optionnel)</param>
        /// <param name="nBoissonPref">nouvelle boisson préférée à modifier(optionnel)</param>
        /// <param name="nphoto">nouveau chemin de photo à modifier(optionnel)</param>
        /// <param name="mdpactuel">Mot de passe pour vérifier l'identité de l'utilisateur</param>
        public void modifierUser(string mdpactuel, string npseudo = "", string nmdp = "", string nprenom = "", string nnom = "", DateTime? nddn = null, string nnumTel = "", string nville = "", TypeBoisson? nBoissonPref = null, string nphoto = "")
        {
            if (!verifierMotDePasse(mdpactuel))
            {
                throw new Exception("Mot de passe incorrect");
            }
            if (!string.IsNullOrEmpty(npseudo))
            {
                mCurrentUser.Pseudo = npseudo;
            }

            if (!string.IsNullOrEmpty(nmdp))
            {
                mCurrentUser.Mdp = nmdp;
            }

            if (!string.IsNullOrEmpty(nprenom))
            {
                mCurrentUser.Prenom = nprenom;
            }

            if (!string.IsNullOrEmpty(nnom))
            {
                mCurrentUser.Nom = nnom;
            }

            if (nddn != null)
            {
                mCurrentUser.DdN = (DateTime)nddn;
            }

            if (!string.IsNullOrEmpty(nnumTel))
            {
                mCurrentUser.NumTel = nnumTel;
            }

            if (!string.IsNullOrEmpty(nville))
            {
                mCurrentUser.Ville = nville;
            }

            if (nBoissonPref != null)
            {
                mCurrentUser.BoissonPref = nBoissonPref;
            }

            if (!string.IsNullOrEmpty(nphoto))
            {
                mCurrentUser.PhotoDeProfil = nphoto;
            }
        }

        /// <summary>
        /// Méthode qui vise à vérifier le mot de passe de l'utilisateur connecté
        /// </summary>
        /// <param name="mdp">Mot de passe transmis pour vérifier son identité</param>
        /// <returns></returns>
        public bool verifierMotDePasse(string mdp)
        {
            return mdp.Equals(mCurrentUser.Mdp);
        }

        
        public void laisserUnAvis(Bar bar, String desc, int note)
        {
            Ville v = listVille.SingleOrDefault(ville => ville.ListBar.Contains(bar));
            if (v != null)
            {
                Bar b = (Bar)v.ListBar.Single(bars => bars.Equals(bar));
                b.laisserAvis(new Avis(note,desc),mCurrentUser);
            }
        }
    }
}
