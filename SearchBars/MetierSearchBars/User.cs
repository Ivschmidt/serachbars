using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class User
    {
        public string Pseudo { get; set; }
        public string Mdp { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Sexe Sexe { get; set; }
        public DateTime DdN { get; set; }
        public string NumTel { get; set; }
        public string Ville { get; set; }
        public string BoissonPref { get; set; }

        public User(string pseudo, string mdp, string nom, string prenom, Sexe sexe, DateTime ddN, string numTel = "", string ville = "", string boissonPref = "")
        {
            Pseudo = pseudo;
            Mdp = mdp;
            Nom = nom;
            Prenom = prenom;
            Sexe = sexe;
            DdN = ddN;
            NumTel = numTel;
            Ville = ville;
            BoissonPref = boissonPref;
        }
    }
}
