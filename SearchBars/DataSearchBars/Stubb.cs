using MetierSearchBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSearchBars
{
    public class Stubb : IDataManager
    {
        public List<User> loadUsers()
        {
            List<User> list = new List<User>();
            list.Add(new User("trololo", "123456", "Delabierre", "Yvan", Sexe.Homme, new DateTime(1980, 1, 9), "0654856952", "St Julien De Copel"));
            list.Add(new User("picoiffard", "090297", "Coiffard", "Pierre", Sexe.Homme, new DateTime(1997, 2, 9), "0659712062", "Bois de boulogne"));
            list.Add(new User("ivschmidt", "290497", "Schmidt", "Ivan", Sexe.Homme, new DateTime(1997, 4, 29),ville : "cantal perdu"));
            list.Add(new User("olmartin2", "131096", "Martin", "Olivier", Sexe.Homme, new DateTime(1996, 10, 13), "0626731060", "coin riche"));
            return list;
        }

        public List<Bar> loadBar()
        {
            List<Bar> list = new List<Bar>();
            list.Add(new Bar("Le Starter",new CoordonneesGPS(45.782036,3.081432),false,"Clermont-Ferrand",5);
            list.Add(new Bar("Délirium",new CoordonneesGPS(45.776289,3.083339),true,"Clermont-Ferrand");
            list.Add(new Bar("The Still Irish Bar",new CoordonneesGPS(45.773706,3.086125),false,"Clermont-Ferrand");
            return list;
        }
    }
}
