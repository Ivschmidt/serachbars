using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    /// <summary>
    /// Facade immuable d'un Bar
    /// </summary>
    public interface IBar
    {
        /// <summary>
        /// Nom du bar : uniquement récupérable
        /// </summary>
        string Nom { get; }

        /// <summary>
        /// Note moyenne sur le bar : uniquement récupérable
        /// null si aucune note moyenne
        /// </summary>
        double? NoteMoyenne { get; }

        /// <summary>
        /// Coordonnées GPS du bar : uniquement récupérable
        /// </summary>
        CoordonneesGPS GPSBar { get; }

        /// <summary>
        /// Booléen qui indique si le bar sert à manger ou non : uniquement récupérable
        /// </summary>
        bool Restauration { get; }

        /// <summary>
        /// Numéro de téléphone du bar : uniquement récupérable
        /// </summary>
        string Numero { get; }

        /// <summary>
        /// Adresse du bar : uniquement récupérable
        /// </summary>
        string Adresse { get; }

        /// <summary>
        /// Encapsulation de la liste de boissons du bar : uniquement récupérable
        /// </summary>
        IEnumerable<IBoisson> ListBoisson { get; }

        //ReadOnlyCollection<string> CheminPhotoROC { get; }

        /// <summary>
        /// Photo représentant le bar : uniquement récupérable
        /// </summary>
        string Photo { get; }

        /// <summary>
        /// Encapsulation du dictionnaire d'Avis du bar : uniquement récupérable
        /// </summary>
        ReadOnlyDictionary<IUser, Avis> Commentaires { get; }
    }
}
