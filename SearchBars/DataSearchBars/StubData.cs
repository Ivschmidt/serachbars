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

            Bar starter = new Bar("Le Starter", new CoordonneesGPS(45.782036, 3.081432), "06 98 72 04 74", "17 Rue Sainte-Claire", photo: "Images/ImagesBars/starter.jpg");
            starter.ajouterBoisson(new BoissonSimple("Ruby", 3.5, "Leffe", 4, TypeBoisson.Biere));
            starter.ajouterBoisson(new BoissonSimple("Jus de banane", 2, "Pago", 0, TypeBoisson.Jus));
            starter.ajouterBoisson(new BoissonSimple("Vodka", 5, "Eristoff", 37, TypeBoisson.AlcoolFort));
            starter.ajouterBoisson(new BoissonSimple("Coca Cherry", 1.5, "Coca Cola", 0, TypeBoisson.Soda));
            starter.laisserAvis(new Avis(1, "j'ai failli mourir"), trololo);
            starter.laisserAvis(new Avis(4, "Wesh c'est trop bien ce bar !"), enzo);
            //starter.ajouterPhoto("Images/ImagesBars/starter.jpg");
            //starter.ajouterPhoto("Images/ImagesBars/starter2.jpg");
            //starter.ajouterPhoto("Images/ImagesBars/starter3.jpg");


            Bar delirium = new Bar("Le Délirium", new CoordonneesGPS(45.776289, 3.083339), "09 54 66 54 47", "20 rue de la Tour d'Auvergne", true, "Images/ImagesBars/delirium.jpg");
            delirium.ajouterBoisson(new Vin("Chateaubriant", 15, "Duras", 12, TypeBoisson.Vin, 2009, "rouge"));

            Boisson rhum = new BoissonSimple("Rhum", 4, "OldNick", 40, TypeBoisson.AlcoolFort);
            delirium.ajouterBoisson(rhum);
            delirium.ajouterBoisson(new BoissonComposee("Mojito", 6.5, 18, TypeBoisson.Cocktail, new List<Boisson> { rhum }, new List<Ingredient> { new Ingredient("citron vert"), new Ingredient("feuilles de menthe fraiches") }));
            delirium.ajouterBoisson(new BoissonSimple("7Up", 1.5, "SevenUp", 0, TypeBoisson.Soda));
            //delirium.ajouterPhoto("Images/ImagesBars/delirium.jpg");

            Bar stillIrishBar = new Bar("The Still Irish Bar", new CoordonneesGPS(45.773706, 3.086125), "04 73 93 13 45", "7 Boulevard Léon Malfreyt", photo: "Images/ImagesBars/lestill.jpg");
            stillIrishBar.ajouterBoisson(new BoissonSimple("K Mangue", 3.2, "Kronenbourg", 4.5, TypeBoisson.Biere));
            List<Boisson> boissonTequilaSunrise = new List<Boisson>();
            Boisson tequila = new BoissonSimple("Tequila", 4, "Gordon", 25, TypeBoisson.AlcoolFort);
            Boisson siropGrenadine = new BoissonSimple("Sirop de grenadine", 3, "Teisseire", 0, TypeBoisson.Sirop);
            Boisson jusOrange = new BoissonSimple("Jus d'orange", 2, "Pago", 0, TypeBoisson.Jus);
            stillIrishBar.ajouterBoisson(new BoissonComposee("Tequila Sunrise", 8.5, 16, TypeBoisson.Cocktail, new List<Boisson>{ tequila, siropGrenadine, jusOrange}, new List<Ingredient>()));
            stillIrishBar.ajouterBoisson(tequila);
            stillIrishBar.ajouterBoisson(siropGrenadine);
            stillIrishBar.ajouterBoisson(jusOrange);
            stillIrishBar.ajouterBoisson(new BoissonSimple("Oasis Tropical", 1.5, "Oasis", 0, TypeBoisson.Soda));
            //stillIrishBar.ajouterPhoto("Images/ImagesBars/lestill.jpg");

            Boisson vodka = new BoissonSimple("Vodka", 5, "Poliakov", 41, TypeBoisson.AlcoolFort);
            Bar lesBerthom = new Bar("Les Berthom", new CoordonneesGPS(45.779581, 3.080976), "04 73 31 01 65", "6 Place Etoile", true, "Images/ImagesBars/barthom.jpg");
            lesBerthom.ajouterBoisson(new Vin("Côte de Beaune", 16, "Bourgogne", 12, TypeBoisson.Vin, 2007, "rouge"));
            lesBerthom.ajouterBoisson(new BoissonSimple("RedBull Energy Drink", 2.8, "Redbull", 0, TypeBoisson.Soda));
            lesBerthom.ajouterBoisson(vodka);
            Bar leMarais = new Bar("Le Marais", new CoordonneesGPS(45.780716, 3.078746), "06 60 23 75 87", "49 Rue Fontgieve", photo: "Images/ImagesBars/marais.jpg");
            leMarais.ajouterBoisson(new BoissonSimple("Whisky", 6, "Jack's Daniel", 38, TypeBoisson.AlcoolFort));
            Boisson schnapsPeche = new BoissonSimple("Schnaps Pêche", 4, "Berentzen", 42, TypeBoisson.AlcoolFort);
            Boisson jusCanneberge = new BoissonSimple("Jus de Canneberge", 2, "Pago", 3, TypeBoisson.Jus);
            leMarais.ajouterBoisson(vodka);
            leMarais.ajouterBoisson(schnapsPeche);
            leMarais.ajouterBoisson(jusOrange);
            leMarais.ajouterBoisson(jusCanneberge);
            leMarais.ajouterBoisson(new BoissonComposee("Sex On the Beach", 8, 25, TypeBoisson.Cocktail, new List<Boisson> { vodka, schnapsPeche, jusOrange, jusCanneberge }, new List<Ingredient>()));
            Bar captainCabin = new Bar("Captain's Cabin", new CoordonneesGPS(45.779379, 3.081777), "04 73 36 33 32", "20 Avenue des États Unis", photo: "Images/ImagesBars/captain.jpg");
            
            Bar monkeysPub = new Bar("3 Monkeys Pub", new CoordonneesGPS(45.774317, 3.094291), "04 73 90 32 46", "25 Avenue des Paulines", true, "Images/ImagesBars/monkey.jpg");
            Bar HaciendaCafe = new Bar("Hacienda Cafe", new CoordonneesGPS(45.780042, 3.083441), "04 73 16 86 41", "5 Place Gilbert Gaillard", true, "Images/ImagesBars/hacienda.jpg");
            Bar leVerlaine = new Bar("Le Verlaine", new CoordonneesGPS(45.775282, 3.084487), "04 73 34 17 55", "5 Mail d'Allagnat", photo: "Images/ImagesBars/verlaine.jpg");
            Bar leRimbaud = new Bar("Le Rimbaud", new CoordonneesGPS(45.774817, 3.084195), "04 73 34 21 39", "Place Louis Aragon", photo: "Images/ImagesBars/rimbaud.jpg");
            Bar lAppart = new Bar("L'Appart", new CoordonneesGPS(45.777610, 3.084859), "04 73 91 19 00", "6 Place Sugny", true, "Images/ImagesBars/appart.jpg");

            clermont.ajouterBar(starter);
            clermont.ajouterBar(delirium);
            clermont.ajouterBar(stillIrishBar);
            clermont.ajouterBar(lesBerthom);
            clermont.ajouterBar(captainCabin);
            clermont.ajouterBar(monkeysPub);
            clermont.ajouterBar(HaciendaCafe);
            clermont.ajouterBar(leVerlaine);
            clermont.ajouterBar(leRimbaud);
            clermont.ajouterBar(lAppart);

            list.Add(clermont);


            Ville nice = new Ville("Nice", new CoordonneesGPS(43.7, 7.25));
            Bar jam = new Bar("Le Jam", new CoordonneesGPS(43.696485, 7.264722), "04 82 53 29 29", "10 Rue du Commandant Raffali");
            nice.ajouterBar(jam);

            Bar akathor = new Bar("Akathor", new CoordonneesGPS(43.695566, 7.274040), "04 93 62 49 90", "32 Rue Cours Saleya", true);
            nice.ajouterBar(akathor);

            //pour ajouter nouveaux bars
            //Bar leSpring = new Bar("Le Spring", new CoordonneesGPS(45.773706, 3.086125), "", "");
            //Bar leSpring = new Bar("Le Spring", new CoordonneesGPS(45.773706, 3.086125), "", "");
            //Bar leSpring = new Bar("Le Spring", new CoordonneesGPS(45.773706, 3.086125), "", "");
            //Bar leSpring = new Bar("Le Spring", new CoordonneesGPS(45.773706, 3.086125), "", "");
            //Bar leSpring = new Bar("Le Spring", new CoordonneesGPS(45.773706, 3.086125), "", "");
            //Bar leSpring = new Bar("Le Spring", new CoordonneesGPS(45.773706, 3.086125), "", "");

            list.Add(nice);

            Ville saintEtienne = new Ville("Saint Etienne", new CoordonneesGPS(45.441, 4.39));

            Bar theSmokingDog = new Bar("The Smoking Dog", new CoordonneesGPS(45.436414, 4.390269), "04 77 47 23 57", "5 Rue Georges Dupré", false, "Images/ImagesBars/theSmokingDog.jpg");
            Bar leSaintPatrick = new Bar("Le Saint Patrick", new CoordonneesGPS(45.435488, 4.390237), "04 77 25 11 52", "44 Rue des Martyrs de Vingré", false, "Images/ImagesBars/leSaintPatrick.jpg");
            Bar soggyBottom = new Bar("Soggy Bottom", new CoordonneesGPS(45.439672, 4.385902), "04 77 32 95 98", "9 Rue de la Résistance", false, "Images/ImagesBars/soggyBottom.jpg");
            Bar lipopetteBar = new Bar("Lipopette Bar", new CoordonneesGPS(45.435617, 4.388625), "04 77 32 64 08", "5 Rue Saint-François", false, "Images/ImagesBars/lipopetteBar.jpg");
            Bar leBarberousse = new Bar("Le Barberousse", new CoordonneesGPS(45.435023, 4.391136), "04 77 95 14 79", "27 Rue Léon Nautin", false, "Images/ImagesBars/leBarberousse.jpg");
            Bar zoobar = new Bar("Zoobar", new CoordonneesGPS(45.437129, 4.392145), "04 77 80 85 84", "27 Rue Léon Nautin", true, "Images/ImagesBars/zoobar.jpg");
            Bar volDeNuit = new Bar("Vol de Nuit", new CoordonneesGPS(45.438293, 4.392548), "04 77 33 48 02", "12 Rue Elise Gervais", false, "Images/ImagesBars/volDeNuit.jpg");
            Bar leChantier = new Bar("LE CHANTIER", new CoordonneesGPS(45.427643, 4.390312), "04 77 41 75 13", "32 Rue du Onze Novembre", false, "Images/ImagesBars/leChantier.jpg");
            Bar leCafeStJacques = new Bar("Le Café St Jacques", new CoordonneesGPS(45.436357, 4.390070), "04 77 32 00 79", "13 Rue des Martyrs de Vingré", false, "Images/ImagesBars/leCafeStJacques.jpg");

            saintEtienne.ajouterBar(theSmokingDog);
            saintEtienne.ajouterBar(leSaintPatrick);
            saintEtienne.ajouterBar(soggyBottom);
            saintEtienne.ajouterBar(lipopetteBar);
            saintEtienne.ajouterBar(leBarberousse);
            saintEtienne.ajouterBar(zoobar);
            saintEtienne.ajouterBar(volDeNuit);
            saintEtienne.ajouterBar(leChantier);
            saintEtienne.ajouterBar(leCafeStJacques);

            list.Add(saintEtienne);

            Ville paris = new Ville("Paris", new CoordonneesGPS(48.856579, 2.345495));

            Bar meltdown = new Bar("Meltdown", new CoordonneesGPS(48.853555, 2.374861), "01 77 11 81 78", "6 Passage Thiéré", true, "Images/ImagesBars/meltdown.jpg");
            Bar candelaria = new Bar("Candelaria", new CoordonneesGPS(48.862938, 2.364019), "pas de numero", "52 Rue de Saintonge", true, "Images/ImagesBars/candelaria.jpg");
            Bar laPerlaBar = new Bar("La Perla Bar", new CoordonneesGPS(48.855739, 2.356165), "01 42 77 59 40", "26 Rue François Miron", true, "Images/ImagesBars/laPerlaBar.jpg");
            Bar barDemoryParis = new Bar("Bar Demory Paris", new CoordonneesGPS(48.855739, 2.356165), "09 81 12 53 06", "62 Rue Quincampoix", false, "Images/ImagesBars/barDemoryParis.jpg");
            Bar panicRoom = new Bar("Panic Room", new CoordonneesGPS(48.861313, 2.367645), "01 58 30 93 43", "101 Rue Amelot", false, "Images/ImagesBars/panicRoom.jpg");
            Bar lesCaractèresBarParis = new Bar("Les Caractères Bar Paris", new CoordonneesGPS(48.853746, 2.340308), "07 61 74 47 89", "25 Rue des Grands Augustins", false, "Images/ImagesBars/lesCaractèresBarParis.jpg");
            Bar moonshiner = new Bar("Moonshiner", new CoordonneesGPS(48.855638, 2.371293), "09 50 73 12 99", "5 Rue Sedaine", true, "Images/ImagesBars/moonshiner.jpg");
            Bar harrysNewYorkBar = new Bar("Harry's New York Bar", new CoordonneesGPS(48.853746, 2.340308), "01 42 61 71 14", "5 Rue Daunou", false, "Images/ImagesBars/harrysNewYorkBar.jpg");
            Bar downtownCafe = new Bar("Downtown Cafe", new CoordonneesGPS(48.866367, 2.372194), "01 43 14 29 66", "46 Rue Jean-Pierre Timbaud", false, "Images/ImagesBars/downtownCafe.jpg");
            Bar iceKubeBar = new Bar("Ice Kube Bar", new CoordonneesGPS(48.886584, 2.358854), "01 42 05 20 00", "5 Passage Ruelle", false, "Images/ImagesBars/iceKubeBar.jpg");

            paris.ajouterBar(meltdown);
            paris.ajouterBar(candelaria);
            paris.ajouterBar(laPerlaBar);
            paris.ajouterBar(barDemoryParis);
            paris.ajouterBar(panicRoom);
            paris.ajouterBar(lesCaractèresBarParis);
            paris.ajouterBar(moonshiner);
            paris.ajouterBar(harrysNewYorkBar);
            paris.ajouterBar(downtownCafe);
            paris.ajouterBar(iceKubeBar);

            list.Add(paris);
           
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
