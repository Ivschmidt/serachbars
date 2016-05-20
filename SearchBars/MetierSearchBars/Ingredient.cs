using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class Ingredient
    {
        public string Nom { get; private set; }
        public string Description { get; private set; }

        public Ingredient(string nom, string description)
        {
            Nom = nom;
            Description = description;  
        }
    }
}
