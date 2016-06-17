using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Classe concrète dérivant de la classe abstraite Boisson
    /// Définit une boisson simple (à l'inverse d'une boisson composée)
    /// Rajoute une propriété Marque
    /// </summary>
    [DataContract]
    class BoissonSimple : Boisson
    { 
        /// <summary>
        /// Propriété comprenant la marque de la boisson
        /// </summary>
        [DataMember]
        public string Marque { get; set; }

        /// <summary>
        /// Constructeur d'une boisson simple
        /// </summary>
        /// <param name="nom">Nom de la boisson à créer</param>
        /// <param name="prix">Prix de la boisson à  créer</param>
        /// <param name="degreA">Degré d'alcool de la boisson à créer</param>
        /// <param name="type">Type de la boisson à créer</param>
        /// <param name="marque">Marque de la boisson à créer</param>
        public BoissonSimple(string nom, double prix, string marque, double degreA, TypeBoisson type) : base(nom, prix, degreA, type)
        {
            Marque = marque;
        }

        /// <summary>
        /// Redéfintion de la méthode ToString()
        /// </summary>
        /// <returns>Le résultat du ToString() de Boisson suivi de la marque</returns>
        public override string ToString()
        {
            return base.ToString() + "marque : " + Marque + "\n";
        }
    }
}
