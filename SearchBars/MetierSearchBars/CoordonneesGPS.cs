using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class CoordonneesGPS
    {
        public double Longitude { get; private set; }
        public double Latitude { get; private set; }

        public CoordonneesGPS(double latitude, double longitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        /// <summary>
        /// returns a hash code in order to use this class in hash table
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return (int) (Longitude % 31 + Latitude % 31);
        }

        /// <summary>
        /// checks if the "right" object is equal to this CoordonneesGPS or not
        /// </summary>
        /// <param name="right">the other object to be compared with this CoordonneesGPS</param>
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

            return this.Equals(right as CoordonneesGPS);
        }

        /// <summary>
        /// checks if this CoordonneesGPS is equal to the other CoordonneesGPS
        /// </summary>
        /// <param name="other">the other CoordonneesGPS to be compared with</param>
        /// <returns>true if equals</returns>
        public bool Equals(CoordonneesGPS other)
        {
            return (this.Latitude == other.Latitude && this.Longitude == other.Longitude);
        }
    }
}
