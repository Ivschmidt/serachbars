using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public interface IBar
    {
        string Nom { get; }
        double? NoteMoyenne { get; }
        CoordonneesGPS GPSBar { get; }
        bool Restauration { get; }
        string Numero { get; }
        string Adresse { get; }
        IEnumerable<IBoisson> ListBoisson { get; }
        //ReadOnlyCollection<string> CheminPhotoROC { get; }
        string Photo { get; }
        ReadOnlyDictionary<IUser, Avis> Commentaires { get; }
    }
}
