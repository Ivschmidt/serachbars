using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Classe dérivant de BoissonSimple
    /// Permet de définir un Vin avec des informations propres aux vins en plus
    /// </summary>
    [DataContract]
    class Vin : BoissonSimple
    {
        /// <summary>
        /// Millésime du Vin
        /// Année désignant l'âge du vin
        /// </summary>
        [DataMember (Order = 0)]
        public int Millesime { get; set; }

        /// <summary>
        /// Robe du vin
        /// Si c'est un rouge, blanc, rose, ...
        /// </summary>
        [DataMember (Order = 1)]
        public string Robe { get; set; }

        /// <summary>
        /// Constructeur d'un vin
        /// </summary>
        /// <param name="nom">Nom du vin à créer</param>
        /// <param name="prix">Prix du vin à créer</param>
        /// <param name="degreA">Degré d'alcool du vin à créer</param>
        /// <param name="type">Type du vin à créer</param>
        /// <param name="marque">Nom de domaine du vin à créer</param>
        /// <param name="millesime">Année désignant l'age du vin à créer</param>
        /// <param name="robe">Robe du vin à créer</param>
        public Vin(string nom, double prix, string marque, double degreA, TypeBoisson type, int millesime, string robe) : base(nom, prix, marque, degreA, type)
        {
            Millesime = millesime;
            Robe = robe;
        }

        /// <summary>
        /// Redéfintion de la méthode ToString()
        /// </summary>
        /// <returns>Le résultat du ToString() de BoissonSimple suivi du millésime et de la robe</returns>
        public override string ToString()
        {
            return base.ToString() + "millésime : " + Millesime + "\nrobe : " + Robe + "\n";
        }
    }
}
