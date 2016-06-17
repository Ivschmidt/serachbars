using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Structure permettant de rassembler une longitude et une latitude sous forme de Coordonnées GPS utilisables pour situer un lieu
    /// </summary>
    [DataContract]
    public struct CoordonneesGPS : IEquatable<CoordonneesGPS>
    {
        /// <summary>
        /// La longitude de ce lieu
        /// </summary>
        public double Longitude
        {
            get
            {
                return mLongitude;
            }
        }
        [DataMember (Name = "Longitude")]
        private double mLongitude;

        /// <summary>
        /// La latitude de ce lieu
        /// </summary>
        public double Latitude
        {
            get
            {
                return mLatitude;
            }
        }
        [DataMember (Name = "Latitude")]
        private double mLatitude;

        /// <summary>
        /// Constructeur d'une coordonnées GPS
        /// </summary>
        /// <param name="latitude">La latitude de le coordonnée à créer</param>
        /// <param name="longitude">La longitude la coordonnée à créer</param>
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

        /// <summary>
        /// redéfinition de la méthode ==
        /// </summary>
        /// <param name="gps1">First CoordonneesGPS to be compared with the second CoordonneesGPS</param>
        /// <param name="gps2">CoordonneesGPS Avis to be compared with the first CoordonneesGPS</param>
        /// <returns>true if equals</returns>
        public static bool operator ==(CoordonneesGPS gps1, CoordonneesGPS gps2)
        {
            return gps1.Equals(gps2);
        }

        /// <summary>
        /// redéfinition de la méthode !=
        /// </summary>
        /// <param name="gps1">First CoordonneesGPS to be compared with the second CoordonneesGPS</param>
        /// <param name="gps2">CoordonneesGPS Avis to be compared with the first CoordonneesGPS</param>
        /// <returns>true if non-equals</returns>
        public static bool operator !=(CoordonneesGPS gps1, CoordonneesGPS gps2)
        {
            return !gps1.Equals(gps2);
        }

    }
}
