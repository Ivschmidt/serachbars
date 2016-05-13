﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public interface IDataManager
    {
        public List<User> loadUsers();
        public List<Bar> loadBar();
    }
}
