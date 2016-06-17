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
    /// Définit une boisson composée d'autres boissons et d'ingrédients
    /// Idéalement utiliser pour des cocktails
    /// Utilisation du patron de conception Composite
    /// </summary>
    [DataContract]
    class BoissonComposee : Boisson
    {
        /// <summary>
        /// La liste des boissons dont est composée la boisson 
        /// </summary>
        [DataMember (Order = 0, Name = "listeDesBoissons")]
        private List<Boisson> listBoissons = new List<Boisson>();

        /// <summary>
        /// Une liste d'ingrédients permettant de rajouter des ingrédients (tels que du citron, de la menthe,..) à la boisson
        /// </summary>
        [DataMember (Order = 1, Name = "listeDesIngredients")]
        private List<Ingredient> listIng = new List<Ingredient>();

        /// <summary>
        /// Constructeur d'une boisson composée
        /// </summary>
        /// <param name="nom">Nom de la boisson à créer</param>
        /// <param name="prix">Prix de la boisson à  créer</param>
        /// <param name="degreA">Degré d'alcool de la boisson à créer</param>
        /// <param name="type">Type de la boisson à créer</param>
        /// <param name="boissonList">Liste de boissons dont sera composée la boisson à créer</param>
        /// <param name="ingrList">Liste d'ingrédients dont sera composée la boisson à créer</param>
        public BoissonComposee(string nom, double prix, double degreA, TypeBoisson type, List<Boisson> boissonList, List<Ingredient> ingrList)
            : base(nom, prix, degreA, type)
        {
            listBoissons.AddRange(boissonList);
            listIng.AddRange(ingrList);
        }

        /// <summary>
        /// Redéfintion de la méthode ToString()
        /// </summary>
        /// <returns>le résultat du ToString() de Boisson suivi de la liste des boissons (s'il y en a) et la liste des ingrédients (s'il y en a) qui composent cette boisson</returns>
        public override string ToString()
        {
            string temp = base.ToString();
            if (listBoissons != null && listBoissons.Count > 0)
            {
                temp += "Liste des boissons incluses dans cette boisson :\n";
                foreach (Boisson boissComp in listBoissons)
                {
                    temp += boissComp.ToString();
                }
            }

            if(listIng != null && listIng.Count > 0)
            {
                temp += "Liste des ingrédients inclus dans cette boisson :\n";
                foreach (Ingredient ingred in listIng)
                {
                    temp += ingred.ToString();
                }
            }
            return temp;
        }
    }
}
