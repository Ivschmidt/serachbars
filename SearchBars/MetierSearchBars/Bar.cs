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
        public string Nom { get; private set; }
        public float NoteMoyenne { get; private set; }
        public CoordonneesGPS GPS{ get; private set; }
        public bool Restauration { get; private set; }

        public Bar(string nom, CoordonneesGPS gps, bool restauration = false, float note = -1) 
        {
            Nom = nom;
            GPS = gps;
            Restauration = restauration;
            NoteMoyenne = note;
        }

        /// <summary>
        /// returns a hash code in order to use this class in hash table
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return GPS.GetHashCode();
        }

        /// <summary>
        /// checks if the "right" object is equal to this Bar or not
        /// </summary>
        /// <param name="right">the other object to be compared with this Bar</param>
        /// <returns>true if equals, false if not</returns>
        public override bool Equals(object right)
        {
            //check null
            if (object.ReferenceEquals(right, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, right))
            {
                return true;
            }

            if (this.GetType() != right.GetType())
            {
                return false;
            }

            return this.Equals(right as Bar);
        }

        /// <summary>
        /// checks if this Bar is equal to the other Bar
        /// </summary>
        /// <param name="other">the other Bar to be compared with</param>
        /// <returns>true if equals</returns>
        public bool Equals(Bar other)
        {
            return (this.GPS.Equals(other.GPS));
        }
    }
}
