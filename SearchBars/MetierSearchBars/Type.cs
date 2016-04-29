using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Type
    {
        public string Nom { get; set; }
        public string Libelle { get; set; }

        public Type(string nom, string libelle)
        {
            Nom = nom;
            Libelle = libelle;
        }
    }
}
