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
    /// implémente IBar qui est une facade immuable permettant d'encapsuler un Bar
    /// implémente IEquatable pour implémenter les protocoles d'égalité entre 2 Bars
    /// implémente INotifyPropertyChanged pour l'envoi d'événements lorsqu'une propriété est modifiée
    /// </summary>
    [DataContract]
    class Bar : IEquatable<Bar>, IBar, INotifyPropertyChanged
    {
        /// <summary>
        /// Evenement envoyé lorsque qu'une propriété est modifiée
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// méthode privée qui envoie l'événement PropertyChanged
        /// </summary>
        /// <param name="info">Nom de la propriété qui a été modifiée</param>
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
        /// Encapsulation de la liste de boissons privée par un IEnumerable
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
        /// <summary>
        /// Photo du bar
        /// </summary>
        [DataMember (Order = 4)]
        public string Photo { get; set; }

        /// <summary>
        /// Nom du bar permettant de le distinguer
        /// </summary>
        [DataMember (Order = 0)]
        public string Nom { get; set; }
        
        /// <summary>
        /// note moyenne du bar
        /// propriété calculée automatiquement à l'aide de tous ls commentaires laissés sur le bar
        /// Cette note est nulle si il n'y a aucun commentaire
        /// </summary>
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

        /// <summary>
        /// Coordonnées GPS permmettant de repérer le bar géographiquement
        /// </summary>
        [DataMember (Order = 1)]
        public CoordonneesGPS GPSBar{ get; set; }

        /// <summary>
        ///propriété permettant de savoir si le bar sert à manger ou non
        /// </summary>
        [DataMember (Order = 2)]
        public bool Restauration { get; set; }

        /// <summary>
        /// numéro de téléphone du bar pour pouvoir le contacter
        /// </summary>
        [DataMember (Order = 3)]
        public string Numero { get; set; }

        /// <summary>
        /// adresse du bar permettant de le situer et de s'y rendre
        /// </summary>
        [DataMember (Order = 3)]
        public string Adresse { get; set; }

        /// <summary>
        /// Constructeur d'un bar
        /// </summary>
        /// <param name="nom">nom que l'on souhaite donner aux bars</param>
        /// <param name="gps">coordonnées GPS du bar que l'on souhaite créer</param>
        /// <param name="numero">numéro de téléphone du bar à ajouter</param>
        /// <param name="adresse">adresse du bar à ajouter</param>
        /// <param name="restauration">paramètre falcutatif indiquant si le bar sert à manger, "pas de restauration" par défaut si rien n'est indiqué lors de l'instanciation</param>
        /// <param name="photo">paramètre facultatif permettant d'ajouter une unique photo au bar, photo par défaut si rien n'est indiqué lors de l'instanciation</param>
        public Bar(string nom, CoordonneesGPS gps, string numero, string adresse, bool restauration = false, string photo = "Images/ImagesBars/defaut.jpg") 
        {
            Nom = nom;
            GPSBar = gps;
            Restauration = restauration;
            Adresse = adresse;
            Numero = numero;
            Photo = photo;
        }

        /// <summary>
        /// méthode permettant d'ajouter une boisson à la liste des boissons servies par la bar
        /// </summary>
        /// <param name="b">la boisson à ajouter</param>
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
            return GPSBar.GetHashCode() + Nom.GetHashCode();
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
            return (this.GPSBar.Equals(other.GPSBar) && this.Nom.Equals(other.Nom));
        }

        /// <summary>
        /// permettant de laisser un avis sur ce bar 
        /// envoie des événements indiquants que la noteMoyenne et les commentaires ont été mis à jour
        /// </summary>
        /// <param name="avis">Avis a laisser sur ce bar</param>
        /// <param name="user">User qui laisse la vie</param>
        public void laisserAvis(Avis avis, User user)
        {
            commentaires.Add(user, avis);
            OnPropertyChanged("NoteMoyenne");
            OnPropertyChanged("Commentaires");
        }

        /// <summary>
        /// redéfinition de la méthode ToString()
        /// </summary>
        /// <returns>Le nom suivi de la note moyenne si elle existe, de la liste de boissons si elle n'est pas vide,
        /// puis la liste des avis s'il y en a </returns>
        public override string ToString()
        {
            string temp = Nom + "\n";
            if(NoteMoyenne != null)
            {
                temp += "note moyenne : " + NoteMoyenne.ToString() + "/5\n";
            }
            if(ListBoisson != null && ListBoisson.Count() > 0)
            {
                foreach(Boisson boiss in ListBoisson)
                {
                    temp += boiss.ToString() + "\n";
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
