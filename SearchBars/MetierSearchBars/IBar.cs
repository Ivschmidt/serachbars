using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public interface IBar
    {
        string Nom { get; }
        float? NoteMoyenne { get; }
        CoordonneesGPS GPS { get; }
        bool Restauration { get; }
        IEnumerable<IBoisson> ListBoisson { get; }
        System.Collections.ObjectModel.ReadOnlyCollection<string> CheminPhotoROC { get; }
    }
}
