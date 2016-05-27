﻿using System;
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
        float? NoteMoyenne { get; }
        CoordonneesGPS GPS { get; }
        bool Restauration { get; }
        IEnumerable<IBoisson> ListBoisson { get; }
        ReadOnlyCollection<string> CheminPhotoROC { get; }
        ReadOnlyDictionary<IUser, Avis> Commentaires { get; }
    }
}
