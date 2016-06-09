using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    [DataContract]
    public enum TypeBoisson
    {
        [EnumMember]
        Biere,
        [EnumMember]
        Vin,
        [EnumMember]
        AlcoolFort,
        [EnumMember]
        Cocktail,
        [EnumMember]
        Sirop,
        [EnumMember]
        Jus,
        [EnumMember]
        Soda,
    }
}
