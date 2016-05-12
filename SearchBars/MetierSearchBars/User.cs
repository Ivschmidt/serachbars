using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class User
    {
        public string Pseudo { get; private set; }
        public string Mdp { get; private set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public Sexe Sexe { get; private set; }
        public DateTime DdN { get; private set; }
        public string NumTel { get; private set; }
        public string Ville { get; private set; }
        public Boisson BoissonPref { get; private set; }

        public User(string pseudo, string mdp, string nom, string prenom, Sexe sexe, DateTime ddN, string numTel = "", string ville = "", Boisson boissonPref = null)
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

        /// <summary>
        /// returns a hash code in order to use this class in hash table
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Pseudo.GetHashCode();
        }

        /// <summary>
        /// checks if the "right" object is equal to this User or not
        /// </summary>
        /// <param name="right">the other object to be compared with this User</param>
        /// <returns>true if equals, false if not</returns>
        public override bool Equals(object right)
        {
            //check null
            if (object.ReferenceEquals(, null))
            {
                return false;
            }

            if (object.ReferenceEquals(this, right))
            {
                return true;
            }

            if (this.GetType() != right.GetType())
            {
                return false;
            }

            return this.Equals(right as User);
        }

        /// <summary>
        /// checks if this User is equal to the other User
        /// </summary>
        /// <param name="other">the other User to be compared with</param>
        /// <returns>true if equals</returns>
        public bool Equals(User other)
        {
            return (this.Pseudo.Equals(other.Pseudo));
        }
    }
}
