﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    class BoissonComposee : Boisson
    {
        private List<Boisson> listBoissons;
        private List<Ingredient> listIng;

        public BoissonComposee(string nom, double prix, double degreA, TypeBoisson type, List<Boisson> boissonList, List<Ingredient> ingrList)
            : base(nom, prix, degreA, type)
        {
            listBoissons = boissonList;
            listIng = ingrList;
        }

        public override string ToString()
        {
            string temp =  base.ToString() + "Liste des boissons incluses dans cette boisson :\n";
            foreach(Boisson boissComp in listBoissons)
            {
                temp += "\t" + boissComp.ToString();
            }

            temp += "Liste des ingrédients inclus dans cette boisson :\n";
            foreach (Ingredient ingred in listIng)
            {
                temp += "\t" + ingred.ToString();
            }

            return temp;
        }
    }
}
