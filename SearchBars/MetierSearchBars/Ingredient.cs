using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Strucuture représentant un ingrédient
    /// </summary>
    [DataContract]
    struct Ingredient
    {
        /// <summary>
        /// Le nom de l'ingrédient
        /// </summary>
        [DataMember]
        public string Nom
        {
            get
            {
                return mNom;
            }
            private set
            {
                mNom = value;
            }
        }
        private string mNom;

        /// <summary>
        /// Constructeur d'un ingrédient
        /// </summary>
        /// <param name="nom">nom de l'ingrédient à créer</param>
        public Ingredient(string nom)
        {
            mNom = nom;
        }

        /// <summary>
        /// Redéfinition de la méthode ToString()
        /// </summary>
        /// <returns>Le nom suivi d'un retour à la ligne</returns>
        public override string ToString()
        {
            return string.Format("{0}\n", Nom);
        }
    }
}
