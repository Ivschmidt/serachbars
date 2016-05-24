using System;
using System.Collections.Generic;
using System.Linq;
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
    class User : IEquatable<User>, IUser
    {
        /// <summary>
        /// Pseudo : pseudo de l'utilisateur, identifiant discriminant
        /// </summary>
        private string pseudo;

        public string Pseudo
        {
            get { return pseudo; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Le pseudo ne peut être nul");
                }
                    pseudo = value;
            }
        }


        /// <summary>
        /// Mdp : mot de passe de l'utilisateur, utilisé pour la connexion permettant de vérifier l'authenticité de l'utilisateur
        /// </summary>
        private string mdp;

        public string Mdp
        {
            get { return mdp; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Le mot de passe ne peut être null");
                }
                    mdp = value;
            }
        }


        /// <summary>
        /// Nom : nom de l'utilisateur
        /// </summary>
        private string nom;

        public string Nom
        {
            get { return nom; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Le nom ne peut être null");
                }
                nom = value;
            }
        }


        /// <summary>
        /// Prenom : prénom de l'utilisateur
        /// </summary>
        private string prenom;

        public string Prenom
        {
            get { return prenom; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Le prenom ne peut être null");
                }
                prenom = value;
            }
        }


        /// <summary>
        /// Sexe : sexe de l'utilisateur (homme ou femme)
        /// </summary>
        public Sexe Sexe { get; set; }

        /// <summary>
        /// DdN : date de naissance de l'utilisateur 
        /// </summary>
        public DateTime DdN { get; set; }

        /// <summary>
        /// NumTel : numero de téléphone de l'utilisateur (optionnel)
        /// </summary>
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
            }
        }
        private string mNumTel;

        /// <summary>
        /// Ville : ville d'habitation de l'utilisateur (optionnel)
        /// </summary>
        public string Ville { get; set; }

        /// <summary>
        /// BoissonPref : boisson préférée de l'utilisateur parmi les éléments de l'enum Type (bière, vin, etc) (optionnel) 
        /// Si champ non renseigné = null
        /// </summary>
        public TypeBoisson? BoissonPref { get; set; }

        /// <summary>
        /// PhotoDeProfil : chemin pour accéder a la photo de profil de l'utilisateur (optionnel)
        /// </summary>
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
        public User(string pseudo, string mdp, string nom, string prenom, Sexe sexe, DateTime ddN, string numTel = "", string ville = "", TypeBoisson? boissonPref = null, string photo="" )
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

        public override string ToString()
        {
            return Pseudo;
        }
    }
}
