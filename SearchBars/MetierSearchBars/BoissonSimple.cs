using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class BoissonSimple : Boisson
    { 
        public string Marque { get; set; }

        public BoissonSimple(string nom, double prix, string marque, int degreA, TypeBoisson type) : base(nom, prix, degreA, type)
        {
            Marque = marque;
        }
    }
}
