using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public interface IUser
    {
        string Pseudo { get;}
        string Mdp { get;}
        string Nom { get;}
        string Prenom { get;}
        Sexe Sexe { get; }
        DateTime DdN { get; }
        string NumTel { get; }
        string Ville { get;  }
        TypeBoisson BoissonPref { get;  }
    }
}
