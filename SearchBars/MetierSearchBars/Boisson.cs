﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MetierSearchBars
{
    [DataContract]
    abstract class Boisson : IBoisson
    {
        [DataMember (Order = 0, Name = "typeDeLaBoisson")]
        public TypeBoisson Type{ get; set; }
        [DataMember (Order = 1)]
        public string Nom { get; set; }
        [DataMember (Order = 2)]
        public double Prix { get; set; }
        [DataMember (Order = 3)]
        public double DegreAlcool { get; set; }

        public Boisson(string nom, double prix, double degreA, TypeBoisson type)
        {
            Nom = nom;
            Prix = prix;
            DegreAlcool = degreA;
            Type = type;
        }

        public override string ToString()
        {
            return Type + " : " + Nom + "(" + DegreAlcool + "°) : " + Prix + " euros\n";
        }
    }
}