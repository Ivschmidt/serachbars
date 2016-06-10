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
        //pour utiliser trololo pour laisser un avis
        private User trololo = new User("trololo", "123456", "Delabierre", "Yvan", Sexe.Homme, new DateTime(1980, 1, 9), "0654856952", "St Julien De Copel",TypeBoisson.Biere, photo: "Images/ImagesProfils/trololo.jpg");
        private User enzo = new User("enzoDu93", "147", "Devie", "Enzo", Sexe.Homme, new DateTime(1997, 4, 1), boissonPref: TypeBoisson.AlcoolFort);

        public IEnumerable<IUser> loadUsers()
        {
            List<IUser> list = new List<IUser>();

            list.Add(trololo);
            list.Add(enzo);
            list.Add(new User("picoiffard", "090297", "Coiffard", "Pierre", Sexe.Homme, new DateTime(1997, 2, 9), "0659712062", "Bois de boulogne"));
            list.Add(new User("ivschmidt", "290497", "Schmidt", "Ivan", Sexe.Homme, new DateTime(1997, 4, 29), ville: "cantal perdu", photo: "Images/ImagesProfils/IvanSchmidt.jpg"));
            list.Add(new User("olmartin2", "131096", "Martin", "Olivier", Sexe.Homme, new DateTime(1996, 10, 13), "0626731060", "coin riche"));
            list.Add(new User("a", "a", "TestNom", "TestPrenom", Sexe.Homme, new DateTime(1995, 10, 13)));
            return list;
        }

        public IEnumerable<IVille> loadVilles()
        {
            List<IVille> list = new List<IVille>();

            Ville clermont = new Ville("Clermont-ferrand", new CoordonneesGPS(45.7833, 3.0833));

            Bar starter = new Bar("Le Starter", new CoordonneesGPS(45.782036, 3.081432), "06 98 72 04 74", "17 Rue Sainte-Claire");
            starter.ajouterBoisson(new BoissonSimple("Ruby", 3.5, "Leffe", 4, TypeBoisson.Biere));
            starter.ajouterBoisson(new BoissonSimple("Jus de banane", 2, "Pago", 0, TypeBoisson.Jus));
            starter.ajouterBoisson(new BoissonSimple("Vodka", 5, "Eristoff", 37, TypeBoisson.AlcoolFort));
            starter.ajouterBoisson(new BoissonSimple("Coca Cherry", 1.5, "Coca Cola", 0, TypeBoisson.Soda));
            starter.laisserAvis(new Avis(1, "j'ai failli mourir"), trololo);
            starter.laisserAvis(new Avis(4, "Wesh ma gueule ça pete sa mère c'est trop bien !"), enzo);
            clermont.ajouterBar(starter);

            Bar delirium = new Bar("Délirium", new CoordonneesGPS(45.776289, 3.083339), "09 54 66 54 47", "20 rue de la Tour d'Auvergne", true);
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

            Bar stillIrishBar = new Bar("The Still Irish Bar", new CoordonneesGPS(45.773706, 3.086125), "04 73 93 13 45", "7 Boulevard Léon Malfreyt");


            clermont.ajouterBar(stillIrishBar);
            list.Add(clermont);


            Ville nice = new Ville("Nice", new CoordonneesGPS(43.7, 7.25));
            Bar jam = new Bar("Le Jam", new CoordonneesGPS(43.696485, 7.264722), "04 82 53 29 29", "10 Rue du Commandant Raffali");
            nice.ajouterBar(jam);

            Bar akathor = new Bar("Akathor", new CoordonneesGPS(43.695566, 7.274040), "04 93 62 49 90", "32 Rue Cours Saleya", true);
            nice.ajouterBar(akathor);
            
            list.Add(nice);
           
            return list;
        }

        public void saveUsers(List<IUser> userList)
        {
            //ne fait rien
        }

        public void saveVille(List<IVille> villeList )
        {
            //ne fait rien 
        }
    }
}
