using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    [DataContract]
    public struct CoordonneesGPS : IEquatable<CoordonneesGPS>
    {
        public double Longitude
        {
            get
            {
                return mLongitude;
            }
        }
        [DataMember (Name = "Longitude")]
        private double mLongitude;

        public double Latitude
        {
            get
            {
                return mLatitude;
            }
        }
        [DataMember (Name = "Latitude")]
        private double mLatitude;

        public CoordonneesGPS(double latitude, double longitude)
        {
            mLatitude = latitude;
            mLongitude = longitude;

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

            if (!(right is CoordonneesGPS))
            {
                return false;
            }
            return Equals((CoordonneesGPS)right);
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

        public static bool operator ==(CoordonneesGPS gps1, CoordonneesGPS gps2)
        {
            return gps1.Equals(gps2);
        }

        public static bool operator !=(CoordonneesGPS gps1, CoordonneesGPS gps2)
        {
            return !gps1.Equals(gps2);
        }

    }
}
