using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Façade immuable de Ville
    /// </summary>
    public interface IVille
    {
        /// <summary>
        /// Nom de la ville : uniquement récupérable
        /// </summary>
        string Nom { get;}

        /// <summary>
        /// Localisation de la ville sous forme de coordonnées GPS : uniquement récupérable
        /// </summary>
        CoordonneesGPS GPSVille { get;}

        /// <summary>
        /// La liste des bars présents dans la ville : uniquement récupérable
        /// </summary>
        IEnumerable<IBar> ListBar { get; }
    }
}
