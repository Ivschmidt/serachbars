using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class Boisson : IBoisson
    {
        public TypeBoisson Type{ get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
        public string Marque { get; set; }
        public int DegreAlcool { get; set; }

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