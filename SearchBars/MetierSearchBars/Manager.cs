using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Manager : System.Collections.ObjectModel.ObservableCollection<IVille>
    {
        private IDataManager DataManager
        {
            get;
            set;
        }

        public IUser CurrentUser
        {
            get
            {
                return mCurrentUser;
            }
        }
        private User mCurrentUser;
 
        private List<User> listUsers = new List<User>();
        //public IEnumerable<IUser> ListUsers
        //{
        //    get
        //    {
        //        return listUsers;
        //    }
        //}

        private List<Ville> listVille = new List<Ville>();
        public IEnumerable<IVille> ListVilles
        {
            get
            {
                return listVille;
            }
        }

        private List<Bar> barRecherches = new List<Bar>();
        public IEnumerable<IBar> BarRecherches
        {
            get
            {
                return barRecherches;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="dataManager"></param>
        public Manager(IDataManager dataManager)
        {
            DataManager = dataManager;
            mCurrentUser = null;
            ChargerDonnees();
        }

        /// <summary>
        /// Charge la liste de villes et la liste de users
        /// </summary>
        public void ChargerDonnees()
        {
            listVille.AddRange(DataManager.loadVilles().Select(iVille => iVille as Ville));
            listUsers.AddRange(DataManager.loadUsers().Select(iUser => iUser as User));
        }

        public void EnregistrerDonnees()
        {
        //    listVille = 
        //    DataManager.saveUsers(listUsers.Select(user => user as IUser));
        //    DataManager.saveVille(listVille.Select(ville => ville as IVille);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pseudo"></param>
        /// <returns></returns>
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
            //vérifier que ddn > 18 ans
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
            EnregistrerDonnees();
        }


        public void rechercherBars(IVille ville, bool restauration = false, List<TypeBoisson> listTypeBoissonPref = null, double noteMin = 0)
        {
            barRecherches.Clear();
            IEnumerable<Bar> temp = ville.ListBar.Select(ibar => ibar as Bar);

            if (restauration)
            {
                temp = temp.Where(bars => bars.Restauration == true);
            }

            temp = temp.Where(bars => bars.NoteMoyenne >= noteMin || bars.NoteMoyenne == null);

            if (listTypeBoissonPref != null && listTypeBoissonPref.Count() > 0)
            {
                temp = temp.Where(bars => bars.ListBoisson.Select(types => types.Type).Distinct().Intersect(listTypeBoissonPref).Count() > 0);

            }

            barRecherches = temp.ToList();
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

        /// <summary>
        /// Méthode qui vise à laisser un avis sur un bar donnée, cet avis contient une note et une description du bar(donc l'avis du client)
        /// Envoi une exception si il n'y a pas de CurrentUser
        /// Envoi une exception si le bar passé en paramètres n'existe pas
        /// </summary>
        /// <param name="bar">Bar qui doit recevoir un commentaire</param>
        /// <param name="desc">Description du bar par le Current User</param>
        /// <param name="note">Note attribuée au bar</param>
        public void laisserUnAvis(IBar bar, int note, String desc="")
        {
            if(CurrentUser == null)
            {
                throw new Exception("aucun User connecté");
            }

            Ville v = listVille.SingleOrDefault(ville => ville.ListBar.Contains(bar));
            if (v == null)
            {
                throw new Exception("Ce bar n'existe pas");
            }

            Bar b = (Bar)v.ListBar.Single(bars => bars.Equals(bar));
            b.laisserAvis(new Avis(note, desc), mCurrentUser);
        }
    }
}
