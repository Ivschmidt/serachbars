using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Ingredient
    {
        public string Nom { get; set; }
        public string Description { get; set; }

        public Ingredient(string nom, string description)
        {
            Nom = nom;
            Description = description;  
        }
    }
}
