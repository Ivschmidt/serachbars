using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class BoissonComposee : Boisson
    {
        private List<Boisson> listBoissons;

        public BoissonComposee(string nom, float prix, string marque, int degreA, Type type)
            : base(nom, prix, marque, degreA, type)
        {
            listBoissons = new List<Boisson>();
        }
    }
}
