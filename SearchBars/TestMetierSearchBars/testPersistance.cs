﻿using DataSearchBars;
using MetierSearchBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMetierSearchBars
{
    class testPersistance
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager(new SerializedData());

            manager.copierDonner(new StubData());

            manager.ChargerDonnees();

        }
    }
}
