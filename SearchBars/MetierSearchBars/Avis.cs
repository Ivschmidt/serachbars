    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{   
    public struct Avis : IEquatable<Avis>
    {
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

        public Avis(int note)
        {
            mNote = note;
            mDescription = "";
        }

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

        public static bool operator ==(Avis avis1, Avis avis2)
        {
            return avis1.Equals(avis2);
        }

        public static bool operator !=(Avis avis1, Avis avis2)
        {
            return !avis1.Equals(avis2);
        }
    }
}
