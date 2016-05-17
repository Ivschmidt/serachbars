﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public interface IVille
    {
        string Nom { get;}
        CoordonneesGPS GPS { get;}
        public IEnumerable<IBar> ListBar { get; }
    }
}
