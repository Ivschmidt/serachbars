    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public class Avis
    {
        public int Note { get; set; }
        public string Description { get; set; }

        public Avis(int note, string desc)
        {
            Note = note;
            Description = desc;
        }
    }
}
