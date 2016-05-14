﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    public interface IDataManager
    {
        HashSet<User> loadUsers();
        List<Ville> loadVilles();
    }
}
