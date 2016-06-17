using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    ///  Classe repésentant une ville
    ///  Implémente IVille pour avoir une façade immuable de Ville
    ///  Implémente IEquatable pour pouvoir comparer l'égalité entre Villes
    /// </summary> 
    [DataContract]
    class Ville : IVille, IEquatable<Ville>
    {
        /// <summary>
        /// Nom de la ville
        /// </summary>
        [DataMember (Order = 0)]
        public string Nom { get; private set; }

        /// <summary>
        /// La localisation de la ville sous forme de Coordonnées GPS
        /// </summary>
        [DataMember (Order = 1)]
        public CoordonneesGPS GPSVille { get; private set; }

        /// <summary>
        /// liste des Bars présents dans cette ville
        /// liste privée pour être correctement protégée
        /// </summary>
        [DataMember (Order = 2, Name = "listeDesBarsDeLaVille")]
        private List<Bar> listBar = new List<Bar>();

        /// <summary>
        /// Encapsulation de la liste de bars privée par un IEnumerable
        /// IBar encapusle les bars en lecture seule
        /// </summary>
        public IEnumerable<IBar> ListBar
        {
            get
            {
                return listBar;
            }
        }

        /// <summary>
        /// Constructeur d'une Ville
        /// </summary>
        /// <param name="nom">Nom de la ville à créer</param>
        /// <param name="gps">Les coordonnées GPS de la ville à  créer</param>
        public Ville(string nom, CoordonneesGPS gps)
        {
            Nom = nom;
            GPSVille = gps;
        }

        /// <summary>
        /// Méthode ajoutant un Bar à la liste des bars présents dans cette ville
        /// </summary>
        /// <param name="bar"></param>
        public void ajouterBar(Bar bar)
        {
            listBar.Add(bar);
        }

        /// <summary>
        /// Redéfintion de la méthode ToString()
        /// </summary>
        /// <returns>Le nom de la ville suivi de la liste des bars présents dans cette ville</returns>
        public override string ToString()
        {
            string temp = Nom + "\n";
            foreach (Bar bar in listBar)
            {
                temp += bar.ToString();
            }
            return temp;
        }


        /// <summary>
        /// returns a hash code in order to use this class in hash table
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode() + GPSVille.GetHashCode();
        }

        /// <summary>
        /// checks if the "right" object is equal to this Ville or not
        /// </summary>
        /// <param name="right">the other object to be compared with this Ville</param>
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

            return this.Equals(right as Ville);
        }

        /// <summary>
        /// checks if this Ville is equal to the other Ville
        /// </summary>
        /// <param name="other">the other Ville to be compared with</param>
        /// <returns>true if equals</returns>
        public bool Equals(Ville other)
        {
            return (this.Nom.Equals(other.Nom) && this.GPSVille.Equals(other.GPSVille));
        }

    }
}
