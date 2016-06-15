using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// classe de User
    /// utilisée pour la connexion à l'application
    /// implements : IEquatable pour protocole d'égalité
    ///            : IUser : interface de facade pour wrapper User en classe immuable
    /// </summary>
    [DataContract]
    class User : IEquatable<User>, IUser, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
            }
        }

        /// <summary>
        /// Pseudo : pseudo de l'utilisateur, identifiant discriminant
        /// ne peut pas être nul (exception)
        /// </summary>
        [DataMember (Order = 0)]
        public string Pseudo
        {
            get { return pseudo; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Le pseudo ne peut pas être nul");
                }
                    pseudo = value;
                //OnPropertyChanged("Pseudo");
            }
        }
        private string pseudo;

        /// <summary>
        /// Mdp : mot de passe de l'utilisateur, utilisé pour la connexion permettant de vérifier l'authenticité de l'utilisateur
        /// Ne peut pas être nul (exception)
        /// </summary>
        [DataMember (Name = "motDePasse", Order = 7)]
        public string Mdp
        {
            get { return mdp; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Le mot de passe ne peut pas être nul");
                }
                    mdp = value;
            }
        }
        private string mdp;

        /// <summary>
        /// Nom : nom de l'utilisateur
        /// ne peut pas être nul (exception)
        /// </summary>
        [DataMember (Order = 1)]
        public string Nom
        {
            get { return nom; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Le nom ne peut pas être nul");
                }
                nom = value;
                OnPropertyChanged("Nom");
            }
        }
        private string nom;
        
        /// <summary>
        /// Prenom : prénom de l'utilisateur
        /// Ne peut pas être nul (exception)
        /// </summary>
        [DataMember (Order = 1)]
        public string Prenom
        {
            get { return prenom; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Le prenom ne peut pas être nul");
                }
                prenom = value;
                OnPropertyChanged("Prenom");
            }
        }
        private string prenom;
        
        /// <summary>
        /// Sexe : sexe de l'utilisateur (homme ou femme)
        /// </summary>
        [DataMember (Order = 2)]
        public Sexe Sexe { get; set; }

        /// <summary>
        /// DdN : date de naissance de l'utilisateur 
        /// </summary>
        [DataMember (Name = "dateDeNaissance", Order = 3)]
        public DateTime DdN
        {
            get
            {
                return ddN;
            }
            set
            {
                ddN = value;
                OnPropertyChanged("Ddn");
            }
        }
        private DateTime ddN;
        
        /// <summary>
        /// NumTel : numero de téléphone de l'utilisateur (optionnel)
        /// doit contenir 10 caractères et seulement des chiffres
        /// </summary>
        [DataMember (Name = "NumeroTelephone", Order = 4)]
        public string NumTel
        {
            get
            {
                return mNumTel;
            }
            set
            {
                if(!string.IsNullOrEmpty(value))
                {
                    if (value.Length != 10)
                    {
                        throw new Exception("le numéro de télephone doit être de la forme XX-XX-XX-XX-XX");
                    }
                    if(!Regex.IsMatch(value, @"^\d+$"))
                    {
                        throw new Exception("le numéro de téléphone doit contenir uniquement des chiffres");
                    }
                    }
                mNumTel = value;
                OnPropertyChanged("NumTel");
            }
        }
        private string mNumTel;

        /// <summary>
        /// Ville : ville d'habitation de l'utilisateur (optionnel)
        /// </summary>
        [DataMember (Order = 4)]
        public string Ville
        {
            get
            {
                return mVille;
            }
            set
            {
                mVille = value;
                OnPropertyChanged("Ville");
            }
        }
        private string mVille;

        /// <summary>
        /// BoissonPref : boisson préférée de l'utilisateur parmi les éléments de l'enum Type (bière, vin, etc) (optionnel) 
        /// Si champ non renseigné = null
        /// </summary>
        [DataMember(EmitDefaultValue = false, Order = 5)]
        public TypeBoisson? BoissonPref
        {
            get
            {
                return mBoissonPref;
            }
            set
            {
                mBoissonPref = value;
                OnPropertyChanged("BoissonPref");
            }
        }
        private TypeBoisson? mBoissonPref;

        /// <summary>
        /// PhotoDeProfil : chemin pour accéder a la photo de profil de l'utilisateur (optionnel)
        /// </summary>
        [DataMember (Order = 6)]
        public string PhotoDeProfil { get; set; }

        /// <summary>
        /// Constructeur d'un utilisateur 
        /// </summary>
        /// <param name="pseudo">pseudo de l'utilisateur à créer</param>
        /// <param name="mdp">mot de passe de l'utilisateur à créer</param>
        /// <param name="nom">nom de l'utilisateur à créer</param>
        /// <param name="prenom">prenom de l'utilisateur à créer</param>
        /// <param name="sexe">sexe de l'utilisateur à créer</param>
        /// <param name="ddN">date de naissance de l'utilisateur à créer</param>
        /// <param name="numTel">numéro de téléphone de l'utilisateur à créer (optionel)</param>
        /// <param name="ville">ville d'habitation de l'utilisateur à créer (optionel)</param>
        /// <param name="boissonPref">type de boisson préférée de l'utilisateur à créer (optionel)</param>
        /// <param name="photo">chemin de la photo à ajouter pour le profil de l'utilisateur(optionel)</param>
        public User(string pseudo, string mdp, string nom, string prenom, Sexe sexe, DateTime ddN, string numTel = "", string ville = "", TypeBoisson? boissonPref = null, string photo = "Images/photoprofil.jpg")
        {
            Pseudo = pseudo;
            Mdp = mdp;
            Nom = nom;
            Prenom = prenom;
            Sexe = sexe;
            DdN = ddN;
            NumTel = numTel;
            Ville = ville;
            BoissonPref = boissonPref;
            PhotoDeProfil = photo;
        }

        /// <summary>
        /// returns a hash code in order to use this class in hash table
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Pseudo.GetHashCode();
        }

        /// <summary>
        /// checks if the "right" object is equal to this User or not
        /// </summary>
        /// <param name="right">the other object to be compared with this User</param>
        /// <returns>true if equals, false if not</returns>
        public override bool Equals(object right)
        {
            //check null
            if (object.ReferenceEquals(right, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, right))
            {
                return true;
            }

            if (this.GetType() != right.GetType())
            {
                return false;
            }

            return this.Equals(right as User);
        }

        /// <summary>
        /// checks if this User is equal to the other User
        /// </summary>
        /// <param name="other">the other User to be compared with</param>
        /// <returns>true if equals</returns>
        public bool Equals(User other)
        {
            return (this.Pseudo.Equals(other.Pseudo));
        }

        /// <summary>
        /// Redéfinition de la méthode ToString()
        /// Retourne le pseudo
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Pseudo;
        }
    }
}
