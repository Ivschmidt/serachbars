using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    [DataContract]
    class BoissonSimple : Boisson
    { 
        [DataMember]
        public string Marque { get; set; }

        public BoissonSimple(string nom, double prix, string marque, double degreA, TypeBoisson type) : base(nom, prix, degreA, type)
        {
            Marque = marque;
        }

        public override string ToString()
        {
            return base.ToString() + "marque : " + Marque + "\n";
        }
    }
}
