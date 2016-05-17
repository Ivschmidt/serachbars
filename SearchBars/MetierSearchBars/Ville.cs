using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class Ville : IVille
    {
        public string Nom { get; private set; }
        public CoordonneesGPS GPS { get; private set; }

        private List<Bar> listBar = new List<Bar>();
        public IEnumerable<IBar> ListBar
        {
            get
            {
                return listBar;
            }
        }

        public Ville(string nom, CoordonneesGPS gps)
        {
            Nom = nom;
            GPS = gps;
        }

        public void ajouterBar(Bar bar)
        {
            listBar.Add(bar);
        }


    }
}
