using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    struct Ingredient
    {
        public string Nom
        {
            get
            {
                return mNom;
            }
        }
        private string mNom;

        public Ingredient(string nom)
        {
            mNom = nom;
        }

        public override string ToString()
        {
            return Nom + "\n";
        }
    }
}
