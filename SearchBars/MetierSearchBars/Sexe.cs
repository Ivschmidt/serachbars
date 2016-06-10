using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Enumération portant sur le sexe d'une personne
    /// </summary>
    [DataContract]
    public enum Sexe
    {
        /// <summary>
        /// Sexe masculin
        /// </summary>
        [EnumMember]
        Homme,
        /// <summary>
        /// Sexe féminin
        /// </summary>
        [EnumMember]
        Femme,
    }
}
