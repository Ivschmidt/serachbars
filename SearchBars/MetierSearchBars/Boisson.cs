using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    abstract class Boisson : IBoisson
    {
        public TypeBoisson Type{ get; set; }
        public string Nom { get; set; }
        public double Prix { get; set; }
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