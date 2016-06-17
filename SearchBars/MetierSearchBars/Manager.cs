using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Façade du projet, classe centrale
    /// Unique classe publique
    /// C'est par cette classe que devront passer tous les assemblages externes aux Métier souhaitant intéragir avec le Métier
    /// </summary>
    public class Manager : System.Collections.ObjectModel.ObservableCollection<IVille>
    {
        /// <summary>
        /// Propriété privée contenant le type de persistance choisie permettant le chargement et la sauvegarde par ce type de persistance
        /// Cette propriété est définie à l'instanciation du Manager uniquement
        /// </summary>
        private IDataManager DataManager
        {
            get;
            set;
        }

        /// <summary>
        /// L'utilisateur actuellement connecté
        /// </summary>
        public IUser CurrentUser
        {
            get
            {
                return mCurrentUser;
            }
        }
        private User mCurrentUser;
 
        /// <summary>
        /// La liste de tous les utilisateurs de l'application
        /// </summary>
        private List<User> listUsers = new List<User>();

        /// <summary>
        /// La liste privée de toutes les villes gérées par l'application
        /// </summary>
        private List<Ville> listVille = new List<Ville>();
        
        /// <summary>
        /// Encapsulation de la liste privée des Villes pour qu'elle puisse être afficher de l'extérieur
        /// </summary>
        public IEnumerable<IVille> ListVilles
        {
            get
            {
                return listVille;
            }
        }

        /// <summary>
        /// Liste privée des bars qui ont été recherchés selon certains critères
        /// </summary>
        private List<Bar> barRecherches = new List<Bar>();

        /// <summary>
        /// Encapsulation de la liste privée des bars recherchés pour permettre leur affichage
        /// </summary>
        public IEnumerable<IBar> BarRecherches
        {
            get
            {
                return barRecherches;
            }
        }

        /// <summary>
        /// Constructeur du Manager appelé pour commencer à interagir avec le Métier
        /// Charge le type de persistance choisi dans le DataManager
        /// Charge les données par appel à ChargerDonnees()
        /// Initialise l'utilisateur courant à aucun
        /// </summary>
        /// <param name="dataManager"></param>
        public Manager(IDataManager dataManager)
        {
            DataManager = dataManager;
            mCurrentUser = null;
            ChargerDonnees();
        }

        /// <summary>
        /// Charge la liste de villes et la liste de users à partir du type de persistance choisi
        /// Vides les listes auparavant pour supprimer tous les résidus
        /// </summary>
        public void ChargerDonnees()
        {
            listUsers.Clear();
            listVille.Clear();
            listVille.AddRange(DataManager.loadVilles().Select(iVille => iVille as Ville));
            listUsers.AddRange(DataManager.loadUsers().Select(iUser => iUser as User));
        }

        /// <summary>
        /// Enregistre les listes de Users et de Villes selon le type de persistance choisie
        /// </summary>
        public void EnregistrerDonnees()
        {
              DataManager.saveUsers(listUsers.Select(user => user as IUser).ToList());
              DataManager.saveVille(listVille.Select(ville => ville as IVille).ToList());
        }

        /// <summary>
        /// Copie les données depuis un autre type de persistance dans le type de persistance en cours
        /// La copie est possible uniquement lorsque aucun utilisateur est connecté 
        /// </summary>
        /// <param name="dataManagerSource">le type de persistance source depuis lequel on copie</param>
        public void copierDonner(IDataManager dataManagerSource)
        {
            if(CurrentUser == null)
            {
                IDataManager lastDataManager = DataManager;
                DataManager = dataManagerSource;
                ChargerDonnees();
                DataManager = lastDataManager;
                EnregistrerDonnees();
            }
        }

        /// <summary>
        /// Recherche un utilisateur dans la liste à partir de son pseudo
        /// Si l'utilisateur existe alors l'utilisateur courant devient cet utilisateur
        /// </summary>
        /// <param name="pseudo">Pseudo de l'utilisateur à rechercher</param>
        /// <returns>true si le User recherché existe</returns>
        private bool rechercherUser(string pseudo)
        {
            mCurrentUser = listUsers.SingleOrDefault(user => user.Pseudo.Equals(pseudo));
            return (CurrentUser != null);
        }

        /// <summary>
        /// Permet de se connecter à l'application si le pseudo correspond à un utilisateur existant et que les mots de passe sont identiques
        /// </summary>
        /// <param name="pseudo">Pseudo de l'utilisateur souhaitant ce connecter</param>
        /// <param name="mdp">Mot de passe de l'utilisateur souhaitant ce connecter</param>
        /// <returns>true si la connection à pût être effectuée (utilisteur existant et mot de passe correct)</returns>
        public bool seConnecter(string pseudo, string mdp)
        {
            if(!rechercherUser(pseudo))
                return false;
            else
                return (CurrentUser.Mdp.Equals(mdp));
        }

        /// <summary> ans
        /// Permet à un utilisateur de s'inscrire à condition qu'il n'existe pas déja (pseudos différents) et qu'il est plus de 18 ans
        /// </summary>
        /// <param name="pseudo">Pseudo de l'utilisateur souhaitant être ajouté</param>
        /// <param name="mdp">Mot de passe de l'utilisateur souhaitant être ajouté</param>
        /// <param name="nom">Nom de l'utilisateur souhaitant être ajouté</param>
        /// <param name="prenom">Prénom de l'utilisateur souhaitant être ajouté</param>
        /// <param name="sexe">Sexe de l'utilisateur souhaitant être ajouté</param>
        /// <param name="ddN">Date de naissance de l'utilisateur souhaitant être ajouté</param>
        /// <param name="numTel">Numéro de téléphone de l'utilisateur souhaitant être ajouté (optionnel)</param>
        /// <param name="ville">Ville de l'utilisateur souhaitant être ajouté (optionnel)</param>
        /// <param name="boissonPref">Type de boisson préféré par l'utilisateur souhaitant être ajouté (optionnel)</param>
        /// <param name="photo">Photo de profil  de l'utilisateur souhaitant être ajouté (optionnel) si rien de préciser photo par défaut</param>
        public void sInscrire(string pseudo, string mdp, string nom, string prenom, Sexe sexe, DateTime ddN, string numTel = "", string ville = "", TypeBoisson? boissonPref = null, string photo="")
        {
            if (this.CalculAge(ddN) < 18)
                throw new Exception("vous n'avez pas l'age requis");

            if(rechercherUser(pseudo))
            {
                throw new Exception("Ce user existe déja");
            }
            User newUser = new User(pseudo, mdp, nom, prenom, sexe, ddN, numTel, ville, boissonPref, photo);
            listUsers.Add(newUser);
        }

        /// <summary>
        /// Fontction qui calcule un âge à partir d'une date de naissance 
        /// </summary>
        /// <param name="anniversaire">Date de naissance à partir de laquelle il faut calculer l'âge</param>
        /// <returns>L'âge correcpondant à la date de naissance passée en paramètre</returns>
        public int CalculAge(DateTime anniversaire)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - anniversaire.Year;
            if (anniversaire > now.AddYears(-age))
                age--;
            return age;
        }

        /// <summary>
        /// Fonction de déconnexion 
        /// L'utilisateur courant est positionné à aucun
        /// On enregistre les données dans le type de persistance choisie par appel à EnregistrerDonnees()
        /// </summary>
        public void seDeconnecter()
        {
            mCurrentUser = null;
            EnregistrerDonnees();
        }

        /// <summary>
        /// Recherche des bars selon plusieurs critères et les met dans la liste des Bars recherchés
        /// </summary>
        /// <param name="ville">La ville où doivent être situés les bars</param>
        /// <param name="restauration">Si les bars servent à manger ou non (si rien n'est précisé : par défaut, recherche tous les bars avec ou sans restauration)</param>
        /// <param name="listTypeBoissonPref">une liste de type de boissons que doivent servir les bars (si rien n'est précisé : recherche des bars sans tenir compte des types de boissons servies)</param>
        /// <param name="noteMin">une note minimale que doivent avoir les bars (si rien n'est précisé recherche des bars sans tenir compte de la note)
        /// Les bars sans note correspondants aux autres critères seront séléctionnés aussi</param>
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
        /// Envoie des exceptions si certains critères ne sont pas respectés
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
        public void modifierUser(string npseudo = "", string nmdp = "", string nprenom = "", string nnom = "", DateTime? nddn = null, string nnumTel = "", string nville = "", TypeBoisson? nBoissonPref = null, string nphoto = "")
        {
            if (!string.IsNullOrEmpty(npseudo) && !npseudo.Equals(CurrentUser.Pseudo))
            {
                if (rechercherUser(npseudo))
                {
                    throw new Exception("Ce user existe déja");
                }
                mCurrentUser.Pseudo = npseudo;
            }

            if (!string.IsNullOrEmpty(nmdp) && !nmdp.Equals(CurrentUser.Mdp))
            {
                mCurrentUser.Mdp = nmdp;
            }

            if (!nprenom.Equals(CurrentUser.Prenom))
            {
                mCurrentUser.Prenom = nprenom;
            }

            if (!nnom.Equals(CurrentUser.Nom))
            {
                mCurrentUser.Nom = nnom;
            }

            if (nddn != null && !nddn.Equals(CurrentUser.DdN))
            {
                if (this.CalculAge((DateTime)nddn) < 18)
                    throw new Exception("vous n'avez pas l'age requis");
                mCurrentUser.DdN = (DateTime)nddn;
            }

            if (!nnumTel.Equals(CurrentUser.NumTel))
            {
                mCurrentUser.NumTel = nnumTel;
            }

            if (!nville.Equals(CurrentUser.Ville))
            {
                mCurrentUser.Ville = nville;
            }

            if (nBoissonPref != null && !nBoissonPref.Equals(CurrentUser.BoissonPref)) 
            {
                mCurrentUser.BoissonPref = nBoissonPref;
            }

            if (!string.IsNullOrEmpty(nphoto) && !nphoto.Equals(CurrentUser.PhotoDeProfil))
            {
                mCurrentUser.PhotoDeProfil = nphoto;
            }
        }

        /// <summary>
        /// Méthode qui vise à vérifier le mot de passe de l'utilisateur connecté
        /// </summary>
        /// <param name="mdp">Mot de passe transmis pour vérifier son identité</param>
        /// <returns>true si les mots de passe sont les mêmes</returns>
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

            Avis avis;
            if(desc.Equals(""))
            {
                avis = new Avis(note);
            }
            else
            {
                avis = new Avis(note, desc);
            }

            Bar b = (Bar)v.ListBar.Single(bars => bars.Equals(bar));
            b.laisserAvis(avis , mCurrentUser);
        }

        
    }
}
