using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Classe abstraite représentant une boisson
    /// implémente IBoisson qui est une facade immuable permettant d'encapsuler une Boisson
    /// implémente IEquatable pour comparer 2 Boissons entre elles
    /// </summary>
    [DataContract]
    abstract class Boisson : IBoisson, IEquatable<Boisson>
    {
        /// <summary>
        /// Type de la boisson (défini selon les éléments de l'énumération TypeBoisson)
        /// </summary>
        [DataMember (Order = 0, Name = "typeDeLaBoisson")]
        public TypeBoisson Type{ get; set; }

        /// <summary>
        /// Nom de la boisson 
        /// </summary>
        [DataMember (Order = 1)]
        public string Nom { get; set; }

        /// <summary>
        /// Prix de la boisson fixé par le bar qui vend cette boisson 
        /// </summary>
        [DataMember (Order = 2)]
        public double Prix { get; set; }
        
        /// <summary>
        /// Degré d'alcool de la boisson 
        /// Egal à 0 si c'est une boisson non-alcoolisée
        /// </summary>
        [DataMember (Order = 3)]
        public double DegreAlcool { get; set; }

        /// <summary>
        /// Constructeur d'une boisson (appelé par les classes dérivées de Boisson)
        /// </summary>
        /// <param name="nom">Nom de la boisson à créer</param>
        /// <param name="prix">Prix de la boisson à créer</param>
        /// <param name="degreA">Degré d'alcool de la boisson à créer</param>
        /// <param name="type">Type de la boisson à créer</param>
        public Boisson(string nom, double prix, double degreA, TypeBoisson type)
        {
            Nom = nom;
            Prix = prix;
            DegreAlcool = degreA;
            Type = type;
        }


        /// <summary>
        /// returns a hash code in order to use this class in hash table
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return Nom.GetHashCode() + Prix.GetHashCode() + DegreAlcool.GetHashCode();
        }

        /// <summary>
        /// checks if the "right" object is equal to this Boisson or not
        /// </summary>
        /// <param name="right">the other object to be compared with this Boisson</param>
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

            return this.Equals(right as Boisson);
        }

        /// <summary>
        /// checks if this Boisson is equal to the other Boisson
        /// </summary>
        /// <param name="other">the other Boisson to be compared with</param>
        /// <returns>true if equals</returns>
        public bool Equals(Boisson other)
        {
            return (this.Prix == other.Prix && this.DegreAlcool == other.DegreAlcool && this.Nom.Equals(other.Nom));
        }

        /// <summary>
        /// redéfinition de la méthode ToString()
        /// </summary>
        /// <returns>Le type de boisson suivi du nom, du volume d'alcool et du prix en euros</returns>
        public override string ToString()
        {
            return Type + " : " + Nom + "(" + DegreAlcool + "°) : " + Prix + " euros\n";
        }
    }
}