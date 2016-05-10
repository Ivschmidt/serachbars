using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class User
    {
        public string Pseudo { get; private set; }
        public string Mdp { get; private set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public Sexe Sexe { get; set; }
        public DateTime DdN { get; private set; }
        public string NumTel { get; private set; }
        public string Ville { get; private set; }
        public string BoissonPref { get; private set; }

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
