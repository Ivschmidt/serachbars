using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Bar
    {
        private Dictionary<User, Avis> commentaires = new Dictionary<User, Avis>();
        private List<Boisson> listBoissons = new List<Boisson>();
        public string Ville { get; private set; }
        public float NoteMoyenne { get; private set; }
        public CoordonneesGPS GPS{ get; private set; }
        public bool Restauration { get; private set; }

        public Bar(CoordonneesGPS gps, bool restauration = false, float note = -1, string ville="") 
        {
            GPS = gps;
            Restauration = restauration;
            NoteMoyenne = note;
            Ville = ville;
        } 
    }
}
