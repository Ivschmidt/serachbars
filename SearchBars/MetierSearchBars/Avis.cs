    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{   
    public struct Avis : IEquatable<Avis>
    {
        /// <summary>
        /// Propriété Note composée d'un getter public et d'un setter privé
        /// Utilisée pour que le CurentUser note un Bar
        /// </summary>
        public int Note
        {
            get
            {
                return mNote;
            }
            private set
            {
                if(value > 5 || value < 0)
                {
                    throw new Exception("La note doit être comprise entre 0 et 5 inclus");
                }
                mNote = value;
            }
        }
        private int mNote;

        /// <summary>
        /// Propriété Description composée d'un getter public et d'un setter privé
        /// Utilisé par le CurrentUser pour donner une descirption d'un Bar
        /// </summary>
        public string Description
        {
            get
            {
                return mDescription;
            }
            private set
            {
                mDescription = value;
            }
        }
        private string mDescription;

        /// <summary>
        /// Constructeur de la classe Avis avec juste une note et pas de description
        /// </summary>
        /// <param name="note">note attribuée par le CurrentUser</param>
        public Avis(int note)
        {
            mNote = note;
            mDescription = "";
        }

        /// <summary>
        /// Constructeur de la classe Avis avec une note et une description
        /// </summary>
        /// <param name="note">note attribuée par le CurrentUser</param>
        /// <param name="desc">description attribuée par le CurrentUser</param>
        public Avis(int note, string desc) : this(note)
        {
            mDescription = desc;
        }

        /// <summary>
        /// returns a hash code in order to use this class in hash table
        /// </summary>
        /// <returns>hash code</returns>
        public override int GetHashCode()
        {
            return Description.GetHashCode() + Note % 31;
        }

        /// <summary>
        /// checks if the "right" object is equal to this Avis or not
        /// </summary>
        /// <param name="right">the other object to be compared with this Avis</param>
        /// <returns>true if equals, false if not</returns>
        public override bool Equals(object right)
        {

            if (!(right is Avis))
            {
                return false;
            }
            return Equals((Avis)right);
        }

        /// <summary>
        /// checks if this Avis is equal to the other Avis
        /// </summary>
        /// <param name="other">the other Avis to be compared with</param>
        /// <returns>true if equals</returns>
        public bool Equals(Avis other)
        {
            return (this.Description.Equals(other.Description) && this.Note == other.Note);
        }

        /// <summary>
        /// redéfinition de la méthode ==
        /// </summary>
        /// <param name="avis1">1 er avis</param>
        /// <param name="avis2">2 eme avis</param>
        /// <returns></returns>
        public static bool operator ==(Avis avis1, Avis avis2)
        {
            return avis1.Equals(avis2);
        }

        /// <summary>
        /// redéfinition de la méthode !=
        /// </summary>
        /// <param name="avis1">1 er avis</param>
        /// <param name="avis2">2 eme avis</param>
        /// <returns></returns>
        public static bool operator !=(Avis avis1, Avis avis2)
        {
            return !avis1.Equals(avis2);
        }
    }
}
