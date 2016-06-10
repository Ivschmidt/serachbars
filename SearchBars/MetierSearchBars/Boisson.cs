using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    [DataContract]
    abstract class Boisson : IBoisson
    {
        [DataMember]
        public TypeBoisson Type{ get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public double Prix { get; set; }
        [DataMember]
        public double DegreAlcool { get; set; }

        public Boisson(string nom, double prix, double degreA, TypeBoisson type)
        {
            Nom = nom;
            Prix = prix;
            DegreAlcool = degreA;
            Type = type;
        }

        public override string ToString()
        {
            return Type + " : " + Nom + "(" + DegreAlcool + "°) : " + Prix + " euros\n";
        }
    }
}