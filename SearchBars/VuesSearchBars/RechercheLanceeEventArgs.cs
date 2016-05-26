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

        public float NoteMin
        {
            get;
            private set;
        }

        public List<TypeBoisson> BoissonsPref
        {
            get;
            private set;
        }

        public RechercheLanceeEventArgs(IVille ville, bool restauration, float noteMin, List<TypeBoisson> listBoissons)
        {
            Ville = ville;
            Restauration = restauration;
            NoteMin = noteMin;
            BoissonsPref = listBoissons;
        }
    }
}