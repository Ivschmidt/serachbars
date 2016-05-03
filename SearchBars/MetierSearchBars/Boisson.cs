using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Boisson
    {
        private List<Ingredient> listIng;
        public Type Type{ get; set; }
        public string Nom { get; set; }
        public float Prix { get; set; }
        public string Marque { get; set; }
        public int DegreAlcool { get; set; }

        public Boisson(string nom, float prix, string marque, int degreA, Type type)
        {
            composition = new List<Ingredient>();
            Nom = nom;
            Prix = prix;
            Marque = marque;
            DegreAlcool = degreA;
            Type = type;
        }
    }
}