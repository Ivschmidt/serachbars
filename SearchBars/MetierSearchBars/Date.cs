using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class Date
    {
        public int Jour { get; set; }
        public int Mois { get; set; }
        public int Annee { get; set; }

        public Date(int jour,int mois, int annee){
            Jour = jour;
            Mois = mois;
            Annee = annee;
        }
    }


}
