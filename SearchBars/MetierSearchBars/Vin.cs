using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    [DataContract]
    class Vin : BoissonSimple
    {
        [DataMember (Order = 0)]
        public int Millesime { get; set; }
        [DataMember (Order = 1)]
        public string Robe { get; set; }

        public Vin(string nom, double prix, string marque, double degreA, TypeBoisson type, int millesime, string robe) : base(nom, prix, marque, degreA, type)
        {
            Millesime = millesime;
            Robe = robe;
        }

        public override string ToString()
        {
            return base.ToString() + "millésime : " + Millesime + "\nrobe : " + Robe + "\n";
        }
    }
}
