using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Enumération comportant les principaux types de boisson
    /// </summary>
    [DataContract]
    public enum TypeBoisson
    {
        /// <summary>
        /// Regroupe tout les types de bières
        /// </summary>
        [EnumMember]
        Biere,
        /// <summary>
        /// Regroupe tout les types de vins
        /// </summary>
        [EnumMember]
        Vin,
        /// <summary>
        /// Regroupe tout les alcools forts(+20°)
        /// </summary>
        [EnumMember]
        AlcoolFort,
        /// <summary>
        /// Regroupe toutes les boissons composées à base d'autres boissons et/ou d'ingrédients
        /// </summary>
        [EnumMember]
        Cocktail,
        /// <summary>
        /// Regroupe tout les types de sirops
        /// </summary>
        [EnumMember]
        Sirop,
        /// <summary>
        /// Regroupe tout les types de jus 
        /// </summary>
        [EnumMember]
        Jus,
        /// <summary>
        /// Regroupe tout les sodas
        /// </summary>
        [EnumMember]
        Soda,
    }
}
