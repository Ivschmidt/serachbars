using MetierSearchBars;
using System.Collections.Generic;

namespace VuesSearchBars
{
    public class RechercheLanceeEventArgs : System.EventArgs
    {
        public IVille Ville
        {
            get;
            private set;
        }

        public bool Restauration
        {
            get;
            private set;
        }

        public double NoteMin
        {
            get;
            private set;
        }

        public List<TypeBoisson> BoissonsPref
        {
            get;
            private set;
        }

        public RechercheLanceeEventArgs(IVille ville, bool restauration, double noteMin, List<TypeBoisson> listBoissons)
        {
            Ville = ville;
            Restauration = restauration;
            NoteMin = noteMin;
            BoissonsPref = listBoissons;
        }
    }
}