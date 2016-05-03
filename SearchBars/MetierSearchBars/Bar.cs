using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Bar
    {
        private Dictionary<User, Avis> commentaires;
        private List<Boisson> listBoissons;
        public string Ville { get; set; }
        public int NoteMoyenne { get; set; }
        public CoordonneesGPS GPS{ get; set; }
        public bool Restauration { get; set; }

        public Bar(CoordonneesGPS gps, bool restauration = false, int note = -1, string ville="") {
            GPS = gps;
            Restauration = restauration;
            NoteMoyenne = note;
            Ville = ville;
            commentaires = new Dictionary<User, Avis>();
            listBoissons = new List<Boisson>();
        } 
    }
}
