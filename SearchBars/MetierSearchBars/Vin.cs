using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class Vin : BoissonSimple
    {
        public int Millesime { get; set; }
        public string Robe { get; set; }

        public Vin(string nom, double prix, string marque, int degreA, TypeBoisson type, int millesime, string robe) : base(nom, prix, marque, degreA, type)
        {
            Millesime = millesime;
            Robe = robe;
        }
    }
}
