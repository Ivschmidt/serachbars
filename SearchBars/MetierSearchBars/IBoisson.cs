using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Façade immuable d'une Boisson
    /// </summary>
    public interface IBoisson
    {
        /// <summary>
        /// Type de la boisson : uniquement récupérable
        /// </summary>
        TypeBoisson Type { get; }

        /// <summary>
        /// Nom de la boisson : uniquement récupérable
        /// </summary>
        string Nom { get; }

        /// <summary>
        /// Prix de la boisson : uniquement récupérable
        /// </summary>
        double Prix { get; }

        /// <summary>
        /// Degré d'alcool de la boisson : uniquement récupérable
        /// </summary>
        double DegreAlcool { get; }
    }
}
