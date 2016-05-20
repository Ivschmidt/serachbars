    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{   
    public struct Avis
    {
        public int Note
        {
            get
            {
                return mNote;
            }
            private set
            {
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
    }
}
