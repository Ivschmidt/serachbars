using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VuesSearchBars
{
    public class ModificationEventArgs : System.EventArgs
    {
        public string Password
        {
            get;
            private set;
        }

        public ModificationEventArgs(String password)
        {
            Password = password;
        }
    }
}
