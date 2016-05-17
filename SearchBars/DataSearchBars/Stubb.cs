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
        public IEnumerable<IUser> loadUsers()
        {
            HashSet<IUser> list = new HashSet<IUser>();
            list.Add(new User("trololo", "123456", "Delabierre", "Yvan", Sexe.Homme, new DateTime(1980, 1, 9), "0654856952", "St Julien De Copel"));
            list.Add(new User("picoiffard", "090297", "Coiffard", "Pierre", Sexe.Homme, new DateTime(1997, 2, 9), "0659712062", "Bois de boulogne"));
            list.Add(new User("ivschmidt", "290497", "Schmidt", "Ivan", Sexe.Homme, new DateTime(1997, 4, 29),ville : "cantal perdu"));
            list.Add(new User("olmartin2", "131096", "Martin", "Olivier", Sexe.Homme, new DateTime(1996, 10, 13), "0626731060", "coin riche"));
            return list;
        }

        public IEnumerable<IVille> loadVilles()
        {
            List<IVille> list = new List<IVille>();

            Ville clermont = new Ville("Clermont-ferrand", new CoordonneesGPS(45.7833, 3.0833));
            clermont.ajouterBar(new Bar("Le Starter", new CoordonneesGPS(45.782036, 3.081432), false));
            clermont.ajouterBar(new Bar("Délirium", new CoordonneesGPS(45.776289, 3.083339), true));
            clermont.ajouterBar(new Bar("The Still Irish Bar", new CoordonneesGPS(45.773706, 3.086125), false));
            list.Add(clermont);

            Ville nice = new Ville("Nice", new CoordonneesGPS(43.7, 7.25));
            nice.ajouterBar(new Bar("Le Jam", new CoordonneesGPS(43.696485, 7.264722), false));
            nice.ajouterBar(new Bar("Akathor", new CoordonneesGPS(43.695566, 7.274040), true));
            list.Add(nice);
           
            return list;
        }
    }
}
