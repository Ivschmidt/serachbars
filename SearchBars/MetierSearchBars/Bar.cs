using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Bar
    {
        Dictionary<User, Avis> commentaire = new Dictionary<User, Avis>();
        List<Boisson> coktail = new List<Boisson>();
        public string Ville { get; set; }
        public int Note { get; set; }
        public CoordonneesGPS GPS{ get; set; }
        public bool Restauration { get; set; }

        public Bar(CoordonneesGPS gps) { 
        
        } 
    }
}
