using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Boisson
    {
        private List<Ingredient> listIng = new List<Ingredient>();
        public Type Type{ get; private set; }
        public string Nom { get; private set; }
        public float Prix { get; private set; }
        public string Marque { get; private set; }
        public int DegreAlcool { get; private set; }

        public Boisson(string nom, float prix, string marque, int degreA, Type type)
        {
            Nom = nom;
            Prix = prix;
            Marque = marque;
            DegreAlcool = degreA;
            Type = type;
        }
    }
}