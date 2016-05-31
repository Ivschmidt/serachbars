using MetierSearchBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSearchBars
{
    public class StubData : IDataManager
    {
        public IEnumerable<IUser> loadUsers()
        {
            List<IUser> list = new List<IUser>();
            list.Add(new User("trololo", "123456", "Delabierre", "Yvan", Sexe.Homme, new DateTime(1980, 1, 9), "0654856952", "St Julien De Copel",TypeBoisson.Biere));
            list.Add(new User("picoiffard", "090297", "Coiffard", "Pierre", Sexe.Homme, new DateTime(1997, 2, 9), "0659712062", "Bois de boulogne"));
            list.Add(new User("ivschmidt", "290497", "Schmidt", "Ivan", Sexe.Homme, new DateTime(1997, 4, 29),ville : "cantal perdu"));
            list.Add(new User("olmartin2", "131096", "Martin", "Olivier", Sexe.Homme, new DateTime(1996, 10, 13), "0626731060", "coin riche"));
            list.Add(new User("a", "a", "TestNom", "TestPrenom", Sexe.Homme, new DateTime(1995, 10, 13)));
            return list;
        }

        public IEnumerable<IVille> loadVilles()
        {
            List<IVille> list = new List<IVille>();

            Ville clermont = new Ville("Clermont-ferrand", new CoordonneesGPS(45.7833, 3.0833));

            Bar starter = new Bar("Le Starter", new CoordonneesGPS(45.782036, 3.081432));
            starter.ajouterBoisson(new BoissonSimple("Ruby", 3.5, "Leffe", 4, TypeBoisson.Biere));
            starter.ajouterBoisson(new BoissonSimple("Jus de banane", 2, "Pago", 0, TypeBoisson.Jus));
            starter.ajouterBoisson(new BoissonSimple("Vodka", 5, "Eristoff", 37, TypeBoisson.AlcoolFort));
            starter.ajouterBoisson(new BoissonSimple("Coca Cherry", 1.5, "Coca Cola", 0, TypeBoisson.Soda));
            clermont.ajouterBar(starter);

            Bar delirium = new Bar("Délirium", new CoordonneesGPS(45.776289, 3.083339), true);
            delirium.ajouterBoisson(new Vin("Chateaubriant", 15, "Duras", 12, TypeBoisson.Vin, 2009, "rouge"));

            List<Boisson> boissonMojitoList = new List<Boisson>();
            Boisson rhum = new BoissonSimple("Rhum", 4, "OldNick", 40, TypeBoisson.AlcoolFort);
            delirium.ajouterBoisson(rhum);
            boissonMojitoList.Add(rhum);
            List<Ingredient> ingrMojitoList = new List<Ingredient>();
            ingrMojitoList.Add(new Ingredient("citron vert"));
            ingrMojitoList.Add(new Ingredient("feuilles de menthe fraiches"));
            delirium.ajouterBoisson(new BoissonComposee("Mojito", 6.5, 18, TypeBoisson.Cocktail, boissonMojitoList, ingrMojitoList));
            delirium.ajouterBoisson(new BoissonSimple("7Up", 1.5, "SevenUp", 0, TypeBoisson.Soda));

            clermont.ajouterBar(delirium);

            Bar stillIrishBar = new Bar("The Still Irish Bar", new CoordonneesGPS(45.773706, 3.086125));
            
            clermont.ajouterBar(stillIrishBar);
            list.Add(clermont);


            Ville nice = new Ville("Nice", new CoordonneesGPS(43.7, 7.25));
            Bar jam = new Bar("Le Jam", new CoordonneesGPS(43.696485, 7.264722));
            nice.ajouterBar(jam);

            Bar akathor = new Bar("Akathor", new CoordonneesGPS(43.695566, 7.274040), true);
            nice.ajouterBar(akathor);
            
            list.Add(nice);
           
            return list;
        }

        public void saveUsers(List<IUser> userList)
        {
            throw new NotImplementedException();
        }

        public void saveVille(List<IVille> villeList )
        {
            throw new NotImplementedException();
        }
    }
}
