using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class CoordonneesGPS
    {
        public int Longitude { get; private set; }
        public int Latitude { get; private set; }

        public CoordonneesGPS(int longitude, int latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
