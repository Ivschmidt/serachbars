using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Boisson
    {
        public TypeBoisson Type{ get; private set; }
        public string Nom { get; private set; }
        public double Prix { get; private set; }
        public string Marque { get; private set; }
        public int DegreAlcool { get; private set; }

        public Boisson(string nom, double prix, string marque, int degreA, TypeBoisson type)
        {
            Nom = nom;
            Prix = prix;
            Marque = marque;
            DegreAlcool = degreA;
            Type = type;
        }
    }
}