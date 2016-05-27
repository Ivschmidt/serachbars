using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public interface IBoisson
    {
        TypeBoisson Type { get; }
        string Nom { get; }
        double Prix { get; }
        double DegreAlcool { get; }
    }
}
