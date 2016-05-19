using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class BoissonComposee : Boisson
    {
        private List<Boisson> listBoissons = new List<Boisson>();
        private List<Ingredient> listIng = new List<Ingredient>();

        public BoissonComposee(string nom, float prix, string marque, int degreA, TypeBoisson type)
            : base(nom, prix, marque, degreA, type)
        {
        }
    }
}
