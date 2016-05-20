using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class BoissonComposee : Boisson
    {
        private List<Boisson> listBoissons;
        private List<Ingredient> listIng;

        public BoissonComposee(string nom, double prix, int degreA, TypeBoisson type, List<Boisson> boissonList, List<Ingredient> ingrList)
            : base(nom, prix, degreA, type)
        {
            listBoissons = boissonList;
            listIng = ingrList;
        }
    }
}
