using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Classe représentant un Bar 
    /// </summary>
    [DataContract]
    class Bar : IEquatable<Bar>, IBar, INotifyPropertyChanged
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
        /// Représente tous les commentaires laissés pour ce Bar
        /// La clé est un User pour avoir l'émetteur de l'Avis
        /// La valeur est l'Avis laissé par cet User
        /// Un User ne peut laissé qu'un seul Avis par Bar
        /// dictionnaire privé pour être correctement protégé
        /// </summary>
        [DataMember (Order = 6, Name = "listeDesAvisLaissés")]
        private Dictionary<User, Avis> commentaires = new Dictionary<User, Avis>();
        /// <summary>
        /// Encapsulation du dictionnaire privé par un ReadOnlyDictionnary
        /// La clé de ce ROD est IUser pour encapsuler la clé User en lecture seule
        /// peut être set uniquement dans cette classe
        /// initialisé dans le contructeur à base du dictionnaire privé "commentaires"
        /// </summary>
        public ReadOnlyDictionary<IUser, Avis> Commentaires
        {
            get
            {
                return new ReadOnlyDictionary<IUser, Avis>(commentaires.ToDictionary(kvp => kvp.Key as IUser, kvp => kvp.Value));
            }
        }

        /// <summary>
        /// liste des Boissons servies par ce Bar
        /// liste privée pour être correctement protégée
        /// </summary>
        [DataMember (Order = 5, Name = "listeDesBoissonsDuBar")]
        private List<Boisson> listBoissons = new List<Boisson>();
        /// <summary>
        /// Encapsulation de la liste privée par un IEnumerable
        /// IBoisson encapusle les boissons en lecture seule
        /// </summary>
        public IEnumerable<IBoisson> ListBoisson
        {
            get
            {
                return listBoissons;
            }
        }

        //[DataMember]
        //private List<string> listCheminPhoto = new List<string>();
        //public ReadOnlyCollection<string> CheminPhotoROC
        //{
        //    get
        //    {
        //        return new ReadOnlyCollection<string>(listCheminPhoto);
        //    }
        //}
        [DataMember (Order = 4)]
        public string Photo { get; set; }

        [DataMember (Order = 0)]
        public string Nom { get; set; }
        public double? NoteMoyenne
        {
            get
            {
                if (commentaires == null || commentaires.Count == 0)
                {
                    return null;
                }
                return (double) Math.Round(commentaires.Average(kvp => kvp.Value.Note), 2);
            }
        }
        [DataMember (Order = 1)]
        public CoordonneesGPS GPS{ get; set; }
        [DataMember (Order = 2)]
        public bool Restauration { get; set; }
        [DataMember (Order = 3)]
        public string Numero { get; set; }
        [DataMember (Order = 3)]
        public string Adresse { get; set; }

        public Bar(string nom, CoordonneesGPS gps, string numero, string adresse, bool restauration = false, string photo = "Images/ImagesBars/defaut.jpg") 
        {
            Nom = nom;
            GPS = gps;
            Restauration = restauration;
            Adresse = adresse;
            Numero = numero;
            Photo = photo;
        }

        public void ajouterBoisson(Boisson b)
        {
            listBoissons.Add(b);
        }

        //public void ajouterPhoto(string chemin)
        //{
        //    listCheminPhoto.Add(chemin);
        //}

        /// <summary>
        /// returns a hash code in order to use this class in hash table
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return GPS.GetHashCode() + Nom.GetHashCode();
        }

        /// <summary>
        /// checks if the "right" object is equal to this Bar or not
        /// </summary>
        /// <param name="right">the other object to be compared with this Bar</param>
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

            return this.Equals(right as Bar);
        }

        /// <summary>
        /// checks if this Bar is equal to the other Bar
        /// </summary>
        /// <param name="other">the other Bar to be compared with</param>
        /// <returns>true if equals</returns>
        public bool Equals(Bar other)
        {
            return (this.GPS.Equals(other.GPS) && this.Nom.Equals(other.Nom));
        }

        public void laisserAvis(Avis avis, User user)
        {
            commentaires.Add(user, avis);
            OnPropertyChanged("NoteMoyenne");
            OnPropertyChanged("Commentaires");
        }

        public override string ToString()
        {
            string temp = Nom + "\n";
            if(NoteMoyenne != null)
            {
                temp += "note moyenne : " + NoteMoyenne.ToString() + "/5\n";
            }
            if(ListBoisson != null)
            {
                foreach(Boisson boiss in ListBoisson)
                {
                    temp += boiss.ToString();
                }
                temp += "\n";
            }
            if(commentaires != null && commentaires.Count > 0)
            {
                temp += "Liste des avis :\n";
                foreach(KeyValuePair<User,Avis> kvp in commentaires)
                {
                    temp += kvp.Key.Pseudo + " : " + kvp.Value.Note + "/5\n" + kvp.Value.Description + "\n"; 
                }
            }
            return temp;
        }
    }
}
