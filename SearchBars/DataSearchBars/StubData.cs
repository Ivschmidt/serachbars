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
        private User trololo = new User("trololo", "123456", "Delabierre", "Yvan", Sexe.Homme, new DateTime(1980, 1, 9), "0654856952", "St Julien De Copel", TypeBoisson.Biere, photo: "Images/ImagesProfils/trololo.jpg");
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
            //Boissons
            //bières :
            Boisson leffeRubis = new BoissonSimple("Ruby", 3.5, "Leffe", 4, TypeBoisson.Biere);
            Boisson leffeAmbre = new BoissonSimple("Ambré", 3.5, "Leffe", 4, TypeBoisson.Biere);
            Boisson leffe = new BoissonSimple("Blonde", 2.5, "Leffe", 4, TypeBoisson.Biere);
            Boisson kMangue = new BoissonSimple("K Mangue", 3.2, "Kronenbourg", 4.5, TypeBoisson.Biere);
            Boisson kronenbourg = new BoissonSimple("Blonde", 3.2, "Kronenbourg", 2.5, TypeBoisson.Biere);
            Boisson heineken = new BoissonSimple("Blonde", 3.2, "Heineken", 2.5, TypeBoisson.Biere);
            Boisson peroni = new BoissonSimple("Blonde", 3.5, "Peroni", 4.7, TypeBoisson.Biere);

            //alcools forts :
            Boisson vodkaPoliakov = new BoissonSimple("Vodka", 5, "Poliakov", 41, TypeBoisson.AlcoolFort);
            Boisson vodkaEristof = new BoissonSimple("Vodka", 5, "Eristoff", 37, TypeBoisson.AlcoolFort);
            Boisson tequila = new BoissonSimple("Tequila", 4, "Gordon", 25, TypeBoisson.AlcoolFort);
            Boisson rhumOldNick = new BoissonSimple("Rhum", 4, "OldNick", 40, TypeBoisson.AlcoolFort);
            Boisson rhumDiplomatico = new BoissonSimple("Rhum", 4, "Diplomatico ", 40, TypeBoisson.AlcoolFort);
            Boisson whiskyJackDaniel = new BoissonSimple("Whisky", 6, "Jack's Daniel", 45, TypeBoisson.AlcoolFort);
            Boisson whiskyWilliamPeel = new BoissonSimple("Whisky", 4, "William Peel", 40, TypeBoisson.AlcoolFort);
            Boisson schnapsPeche = new BoissonSimple("Schnaps Pêche", 4, "Berentzen", 42, TypeBoisson.AlcoolFort);
            Boisson jeagermeister = new BoissonSimple("Jeagermeister", 4, "Jeagermeister", 35, TypeBoisson.AlcoolFort);

            //soda :
            Boisson cocaColaCherry = new BoissonSimple("Coca Cherry", 2.5, "Coca Cola", 0, TypeBoisson.Soda);
            Boisson cocaCola = new BoissonSimple("Coca cola", 1.5, "Coca Cola", 0, TypeBoisson.Soda);
            Boisson redBull = new BoissonSimple("RedBull Energy Drink", 2.8, "Redbull", 0, TypeBoisson.Soda);
            Boisson oasisTropical = new BoissonSimple("Oasis Tropical", 1.5, "Oasis", 0, TypeBoisson.Soda);
            Boisson oasisOrange = new BoissonSimple("Oasis Orange", 1.5, "Oasis", 0, TypeBoisson.Soda);
            Boisson sevenUp = new BoissonSimple("7Up", 1.5, "SevenUp", 0, TypeBoisson.Soda);
            Boisson orangina = new BoissonSimple("Orangina", 1.5, "Orangina", 0, TypeBoisson.Soda);

            //jus + sirops :
            Boisson siropGrenadine = new BoissonSimple("Sirop de grenadine", 3, "Teisseire", 0, TypeBoisson.Sirop);
            Boisson siropPeche = new BoissonSimple("Sirop de peche", 3, "Teisseire", 0, TypeBoisson.Sirop);
            Boisson jusOrange = new BoissonSimple("Jus d'orange", 2, "Pago", 0, TypeBoisson.Jus);
            Boisson jusDeBanane = new BoissonSimple("Jus de banane", 2, "Pago", 0, TypeBoisson.Jus);
            Boisson jusCanneberge = new BoissonSimple("Jus de Canneberge", 2, "Pago", 3, TypeBoisson.Jus);

            //vins :
            Boisson chateaubriant = new Vin("Chateaubriant", 15, "Duras", 12, TypeBoisson.Vin, 2009, "rouge");
            Boisson coteDeBeaune = new Vin("Côte de Beaune", 16, "Bourgogne", 12, TypeBoisson.Vin, 2007, "rouge");

            //coktails :
            Boisson mojito = new BoissonComposee("Mojito", 6.5, 18, TypeBoisson.Cocktail, new List<Boisson> { rhumOldNick }, new List<Ingredient> { new Ingredient("citron vert"), new Ingredient("feuilles de menthe fraiches") });
            Boisson tequilaSunrise = new BoissonComposee("Tequila Sunrise", 8.5, 16, TypeBoisson.Cocktail, new List<Boisson> { tequila, siropGrenadine, jusOrange }, new List<Ingredient>());
            Boisson sexeOnTheBeach = new BoissonComposee("Sex On the Beach", 8, 25, TypeBoisson.Cocktail, new List<Boisson> { vodkaPoliakov, schnapsPeche, jusOrange, jusCanneberge }, new List<Ingredient>());
            Boisson crashNaya = new BoissonComposee("Shooter Crash Naya", 1, 40, TypeBoisson.AlcoolFort, new List<Boisson> { vodkaEristof }, new List<Ingredient> { new Ingredient("sel"), new Ingredient("Tabasco") });
            Boisson pechePiment = new BoissonComposee("Shooter Pêche Piment", 1, 40, TypeBoisson.AlcoolFort, new List<Boisson> { vodkaEristof, siropPeche }, new List<Ingredient> { new Ingredient("piments") });
            Boisson jeagerBombe = new BoissonComposee("Jeager Bombe", 4.5, 35, TypeBoisson.AlcoolFort, new List<Boisson> { jeagermeister, redBull }, new List<Ingredient>());
            Boisson vodkaOrange = new BoissonComposee("Vodka orange", 3, 40, TypeBoisson.AlcoolFort, new List<Boisson> { vodkaEristof, jusOrange }, new List<Ingredient>());

            //Villes + Bars
            List<IVille> list = new List<IVille>();

            Ville clermont = new Ville("Clermont-ferrand", new CoordonneesGPS(45.7833, 3.0833));

            Bar starter = new Bar("Le Starter", new CoordonneesGPS(45.782036, 3.081432), "06 98 72 04 74", "17 Rue Sainte-Claire", photo: "Images/ImagesBars/starter.jpg");
            starter.ajouterBoisson(heineken);
            starter.ajouterBoisson(kronenbourg);
            starter.ajouterBoisson(jeagerBombe);
            starter.ajouterBoisson(jeagermeister);
            starter.ajouterBoisson(crashNaya);
            starter.ajouterBoisson(pechePiment);
            starter.ajouterBoisson(cocaCola);
            starter.ajouterBoisson(oasisOrange);
            starter.ajouterBoisson(sevenUp);
            starter.ajouterBoisson(orangina);
            starter.ajouterBoisson(jusDeBanane);
            starter.ajouterBoisson(redBull);
            starter.laisserAvis(new Avis(4, "Wesh c'est trop bien ce bar !"), enzo);
            starter.laisserAvis(new Avis(5, "19h Ce bar est d'une pureté qui n'a pas d'égal !"), trololo);

            Bar delirium = new Bar("Le Délirium", new CoordonneesGPS(45.776289, 3.083339), "09 54 66 54 47", "20 rue de la Tour d'Auvergne", true, "Images/ImagesBars/delirium.jpg");
            delirium.ajouterBoisson(chateaubriant);
            delirium.ajouterBoisson(rhumOldNick);
            delirium.ajouterBoisson(leffe);
            delirium.ajouterBoisson(leffeAmbre);
            delirium.ajouterBoisson(leffeRubis);
            delirium.ajouterBoisson(kMangue);
            delirium.ajouterBoisson(peroni);
            delirium.ajouterBoisson(kronenbourg);
            delirium.ajouterBoisson(heineken);
            delirium.laisserAvis(new Avis(4, "20h Des excelentes bières, le choix y est riche."), trololo);

            Bar stillIrishBar = new Bar("The Still Irish Bar", new CoordonneesGPS(45.773706, 3.086125), "04 73 93 13 45", "7 Boulevard Léon Malfreyt", photo: "Images/ImagesBars/lestill.jpg");
            stillIrishBar.ajouterBoisson(kMangue);
            stillIrishBar.ajouterBoisson(tequilaSunrise);
            stillIrishBar.ajouterBoisson(tequila);
            stillIrishBar.ajouterBoisson(siropGrenadine);
            stillIrishBar.ajouterBoisson(jusOrange);
            stillIrishBar.ajouterBoisson(oasisTropical);
            stillIrishBar.laisserAvis(new Avis(3, "21h Ouais c'est pas mal on y est bien."), trololo);

            Bar lesBerthom = new Bar("Les Berthom", new CoordonneesGPS(45.779581, 3.080976), "04 73 31 01 65", "6 Place Etoile", true, "Images/ImagesBars/barthom.jpg");
            lesBerthom.ajouterBoisson(coteDeBeaune);
            lesBerthom.ajouterBoisson(redBull);
            lesBerthom.ajouterBoisson(vodkaEristof);
            lesBerthom.laisserAvis(new Avis(4, "22h beaucoup de bière, les toilettes sont sympa #tropDeBiere"), trololo);

            Bar leMarais = new Bar("Le Marais", new CoordonneesGPS(45.780716, 3.078746), "06 60 23 75 87", "49 Rue Fontgieve", photo: "Images/ImagesBars/marais.jpg");
            leMarais.ajouterBoisson(whiskyJackDaniel);
            leMarais.ajouterBoisson(vodkaPoliakov);
            leMarais.ajouterBoisson(schnapsPeche);
            leMarais.ajouterBoisson(jusOrange);
            leMarais.ajouterBoisson(jusCanneberge);
            leMarais.ajouterBoisson(sexeOnTheBeach);
            leMarais.laisserAvis(new Avis(1, "23h WTF ce nom ouech ? #OnVautMieuxQueCa"), trololo);

            Bar captainCabin = new Bar("Captain's Cabin", new CoordonneesGPS(45.779379, 3.081777), "04 73 36 33 32", "20 Avenue des États Unis", photo: "Images/ImagesBars/captain.jpg");
            captainCabin.ajouterBoisson(whiskyWilliamPeel);
            captainCabin.ajouterBoisson(vodkaEristof);
            captainCabin.ajouterBoisson(cocaCola);
            captainCabin.ajouterBoisson(oasisOrange);
            captainCabin.ajouterBoisson(schnapsPeche);
            captainCabin.ajouterBoisson(tequila);
            captainCabin.laisserAvis(new Avis(5, "23h30 DU RHUM DES FEMMES ET D'LA BIERE NON DE DIEU !"), trololo);

            Bar monkeysPub = new Bar("3 Monkeys Pub", new CoordonneesGPS(45.774317, 3.094291), "04 73 90 32 46", "25 Avenue des Paulines", true, "Images/ImagesBars/monkey.jpg");
            monkeysPub.ajouterBoisson(chateaubriant);
            monkeysPub.ajouterBoisson(rhumOldNick);
            monkeysPub.ajouterBoisson(leffe);
            monkeysPub.ajouterBoisson(leffeAmbre);
            monkeysPub.ajouterBoisson(leffeRubis);
            monkeysPub.ajouterBoisson(kMangue);
            monkeysPub.ajouterBoisson(peroni);
            monkeysPub.ajouterBoisson(kronenbourg);
            monkeysPub.ajouterBoisson(heineken);
            monkeysPub.laisserAvis(new Avis(4, "1h TROLOLO LEVE TON VERRE ! ET SURTOUUUT NE LE RENVERSE PAS ! CA RISQUE PAS !"), trololo);

            Bar HaciendaCafe = new Bar("Hacienda Cafe", new CoordonneesGPS(45.780042, 3.083441), "04 73 16 86 41", "5 Place Gilbert Gaillard", true, "Images/ImagesBars/hacienda.jpg");
            HaciendaCafe.ajouterBoisson(whiskyJackDaniel);
            HaciendaCafe.ajouterBoisson(vodkaPoliakov);
            HaciendaCafe.ajouterBoisson(schnapsPeche);
            HaciendaCafe.ajouterBoisson(jusOrange);
            HaciendaCafe.ajouterBoisson(jusCanneberge);
            HaciendaCafe.ajouterBoisson(sexeOnTheBeach);
            HaciendaCafe.laisserAvis(new Avis(2, "2h oklm snapchat : trololo63"), trololo);

            Bar leVerlaine = new Bar("Le Verlaine", new CoordonneesGPS(45.775282, 3.084487), "04 73 34 17 55", "5 Mail d'Allagnat", photo: "Images/ImagesBars/verlaine.jpg");
            leVerlaine.ajouterBoisson(heineken);
            leVerlaine.ajouterBoisson(kronenbourg);
            leVerlaine.ajouterBoisson(jeagerBombe);
            leVerlaine.ajouterBoisson(jeagermeister);
            leVerlaine.ajouterBoisson(crashNaya);
            leVerlaine.ajouterBoisson(pechePiment);
            leVerlaine.ajouterBoisson(cocaCola);
            leVerlaine.ajouterBoisson(oasisOrange);
            leVerlaine.ajouterBoisson(sevenUp);
            leVerlaine.ajouterBoisson(orangina);
            leVerlaine.ajouterBoisson(jusDeBanane);
            leVerlaine.ajouterBoisson(redBull);
            leVerlaine.laisserAvis(new Avis(5, "2h30 SUPER BONNE ! La vodka aussi !"), trololo);

            Bar leRimbaud = new Bar("Le Rimbaud", new CoordonneesGPS(45.774817, 3.084195), "04 73 34 21 39", "Place Louis Aragon", photo: "Images/ImagesBars/rimbaud.jpg");
            leRimbaud.ajouterBoisson(heineken);
            leRimbaud.ajouterBoisson(kronenbourg);
            leRimbaud.ajouterBoisson(jeagerBombe);
            leRimbaud.ajouterBoisson(jeagermeister);
            leRimbaud.ajouterBoisson(crashNaya);
            leRimbaud.ajouterBoisson(pechePiment);
            leRimbaud.ajouterBoisson(cocaCola);
            leRimbaud.ajouterBoisson(oasisOrange);
            leRimbaud.ajouterBoisson(sevenUp);
            leRimbaud.ajouterBoisson(orangina);
            leRimbaud.ajouterBoisson(jusDeBanane);
            leRimbaud.ajouterBoisson(redBull);
            leRimbaud.laisserAvis(new Avis(0, "4h g pa pu rentrer c pa normal RT si t triste"), trololo);

            Bar lAppart = new Bar("L'Appart", new CoordonneesGPS(45.777610, 3.084859), "04 73 91 19 00", "6 Place Sugny", true, "Images/ImagesBars/appart.jpg");
            lAppart.ajouterBoisson(heineken);
            lAppart.ajouterBoisson(kronenbourg);
            lAppart.ajouterBoisson(jeagerBombe);
            lAppart.ajouterBoisson(jeagermeister);
            lAppart.ajouterBoisson(whiskyJackDaniel);
            lAppart.ajouterBoisson(whiskyWilliamPeel);
            lAppart.ajouterBoisson(cocaCola);
            lAppart.ajouterBoisson(oasisOrange);
            lAppart.ajouterBoisson(sevenUp);
            lAppart.ajouterBoisson(orangina);
            lAppart.ajouterBoisson(jusDeBanane);
            lAppart.ajouterBoisson(redBull);
            lAppart.laisserAvis(new Avis(5, "4h30 bleuaaah yeee ouee zt ro keol"), trololo);

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

            Bar jam = new Bar("Le Jam", new CoordonneesGPS(43.696485, 7.264722), "04 82 53 29 29", "10 Rue du Commandant Raffali", false, "Images/ImagesBars/jam.jpg");
            jam.ajouterBoisson(heineken);
            jam.ajouterBoisson(kronenbourg);
            jam.ajouterBoisson(jeagerBombe);
            jam.ajouterBoisson(jeagermeister);
            jam.ajouterBoisson(whiskyJackDaniel);
            jam.ajouterBoisson(whiskyWilliamPeel);
            jam.ajouterBoisson(cocaCola);
            jam.ajouterBoisson(oasisOrange);
            jam.ajouterBoisson(sevenUp);
            jam.ajouterBoisson(orangina);
            jam.ajouterBoisson(jusDeBanane);
            jam.ajouterBoisson(redBull);

            Bar akathor = new Bar("Akathor", new CoordonneesGPS(43.695566, 7.274040), "04 93 62 49 90", "32 Rue Cours Saleya", true, "Images/ImagesBars/aka.jpg");
            akathor.ajouterBoisson(whiskyJackDaniel);
            akathor.ajouterBoisson(vodkaPoliakov);
            akathor.ajouterBoisson(schnapsPeche);
            akathor.ajouterBoisson(jusOrange);
            akathor.ajouterBoisson(jusCanneberge);
            akathor.ajouterBoisson(sexeOnTheBeach);

            Bar Nomad = new Bar("Le Nomad", new CoordonneesGPS(43.698997, 7.277781), " 04 97 08 34 86", "3, Place Saint-François", true, "Images/ImagesBars/Nomad.jpg");
            Nomad.ajouterBoisson(kMangue);
            Nomad.ajouterBoisson(tequilaSunrise);
            Nomad.ajouterBoisson(tequila);
            Nomad.ajouterBoisson(siropGrenadine);
            Nomad.ajouterBoisson(jusOrange);
            Nomad.ajouterBoisson(oasisTropical);

            Bar ghostpub = new Bar("Le Ghost Pub", new CoordonneesGPS(43.695728, 7.276580), "04 93 92 93 37", "3, Rue Barillerie", true, "Images/ImagesBars/Ghost Pub.jpg");
            ghostpub.ajouterBoisson(chateaubriant);
            ghostpub.ajouterBoisson(rhumOldNick);
            ghostpub.ajouterBoisson(leffe);
            ghostpub.ajouterBoisson(leffeAmbre);
            ghostpub.ajouterBoisson(leffeRubis);
            ghostpub.ajouterBoisson(kMangue);
            ghostpub.ajouterBoisson(peroni);
            ghostpub.ajouterBoisson(kronenbourg);
            ghostpub.ajouterBoisson(heineken);

            Bar loop = new Bar("Loop'S Bar", new CoordonneesGPS(43.702583, 7.280003), "04 92 04 53 35", "52, Boulevard Risso", false, "Images/ImagesBars/loopsbar.jpg");
            loop.ajouterBoisson(kMangue);
            loop.ajouterBoisson(tequilaSunrise);
            loop.ajouterBoisson(tequila);
            loop.ajouterBoisson(siropGrenadine);
            loop.ajouterBoisson(jusOrange);
            loop.ajouterBoisson(oasisTropical);

            Bar baroc = new Bar("Le Bar'Oc", new CoordonneesGPS(43.699535, 7.285229), "06 43 64 68 05", "10, Rue Bavastro", true, "Images/ImagesBars/Bar'OC.jpg");
            baroc.ajouterBoisson(coteDeBeaune);
            baroc.ajouterBoisson(redBull);
            baroc.ajouterBoisson(vodkaEristof);

            Bar masterhome = new Bar("Master Home", new CoordonneesGPS(43.696781, 7.274456), "04 93 80 33 82", "11, Rue de la Préfecture", true, "Images/ImagesBars/masterhome.jpg");
            masterhome.ajouterBoisson(chateaubriant);
            masterhome.ajouterBoisson(rhumOldNick);
            masterhome.ajouterBoisson(leffe);
            masterhome.ajouterBoisson(leffeAmbre);
            masterhome.ajouterBoisson(leffeRubis);
            masterhome.ajouterBoisson(kMangue);
            masterhome.ajouterBoisson(peroni);
            masterhome.ajouterBoisson(kronenbourg);
            masterhome.ajouterBoisson(heineken);

            nice.ajouterBar(jam);
            nice.ajouterBar(akathor);
            nice.ajouterBar(Nomad);
            nice.ajouterBar(ghostpub);
            nice.ajouterBar(loop);
            nice.ajouterBar(masterhome);
            nice.ajouterBar(baroc);

            list.Add(nice);


            Ville saintEtienne = new Ville("Saint Etienne", new CoordonneesGPS(45.441, 4.39));

            Bar theSmokingDog = new Bar("The Smoking Dog", new CoordonneesGPS(45.436414, 4.390269), "04 77 47 23 57", "5 Rue Georges Dupré", false, "Images/ImagesBars/theSmokingDog.jpg");
            theSmokingDog.ajouterBoisson(heineken);
            theSmokingDog.ajouterBoisson(kronenbourg);
            theSmokingDog.ajouterBoisson(jeagerBombe);
            theSmokingDog.ajouterBoisson(jeagermeister);
            theSmokingDog.ajouterBoisson(whiskyJackDaniel);
            theSmokingDog.ajouterBoisson(whiskyWilliamPeel);
            theSmokingDog.ajouterBoisson(cocaCola);
            theSmokingDog.ajouterBoisson(oasisOrange);
            theSmokingDog.ajouterBoisson(sevenUp);
            theSmokingDog.ajouterBoisson(orangina);
            theSmokingDog.ajouterBoisson(jusDeBanane);
            theSmokingDog.ajouterBoisson(redBull);

            Bar leSaintPatrick = new Bar("Le Saint Patrick", new CoordonneesGPS(45.435488, 4.390237), "04 77 25 11 52", "44 Rue des Martyrs de Vingré", false, "Images/ImagesBars/leSaintPatrick.jpg");
            leSaintPatrick.ajouterBoisson(chateaubriant);
            leSaintPatrick.ajouterBoisson(rhumOldNick);
            leSaintPatrick.ajouterBoisson(leffe);
            leSaintPatrick.ajouterBoisson(leffeAmbre);
            leSaintPatrick.ajouterBoisson(leffeRubis);
            leSaintPatrick.ajouterBoisson(kMangue);
            leSaintPatrick.ajouterBoisson(peroni);
            leSaintPatrick.ajouterBoisson(kronenbourg);
            leSaintPatrick.ajouterBoisson(heineken);

            Bar soggyBottom = new Bar("Soggy Bottom", new CoordonneesGPS(45.439672, 4.385902), "04 77 32 95 98", "9 Rue de la Résistance", false, "Images/ImagesBars/soggyBottom.jpg");
            soggyBottom.ajouterBoisson(heineken);
            soggyBottom.ajouterBoisson(kronenbourg);
            soggyBottom.ajouterBoisson(jeagerBombe);
            soggyBottom.ajouterBoisson(jeagermeister);
            soggyBottom.ajouterBoisson(whiskyJackDaniel);
            soggyBottom.ajouterBoisson(whiskyWilliamPeel);
            soggyBottom.ajouterBoisson(cocaCola);
            soggyBottom.ajouterBoisson(oasisOrange);
            soggyBottom.ajouterBoisson(sevenUp);
            soggyBottom.ajouterBoisson(orangina);
            soggyBottom.ajouterBoisson(jusDeBanane);
            soggyBottom.ajouterBoisson(redBull);

            Bar lipopetteBar = new Bar("Lipopette Bar", new CoordonneesGPS(45.435617, 4.388625), "04 77 32 64 08", "5 Rue Saint-François", false, "Images/ImagesBars/lipopetteBar.jpg");
            lipopetteBar.ajouterBoisson(kMangue);
            lipopetteBar.ajouterBoisson(tequilaSunrise);
            lipopetteBar.ajouterBoisson(tequila);
            lipopetteBar.ajouterBoisson(siropGrenadine);
            lipopetteBar.ajouterBoisson(jusOrange);
            lipopetteBar.ajouterBoisson(oasisTropical);

            Bar leBarberousse = new Bar("Le Barberousse", new CoordonneesGPS(45.435023, 4.391136), "04 77 95 14 79", "27 Rue Léon Nautin", false, "Images/ImagesBars/leBarberousse.jpg");
            leBarberousse.ajouterBoisson(heineken);
            leBarberousse.ajouterBoisson(kronenbourg);
            leBarberousse.ajouterBoisson(jeagerBombe);
            leBarberousse.ajouterBoisson(jeagermeister);
            leBarberousse.ajouterBoisson(whiskyJackDaniel);
            leBarberousse.ajouterBoisson(whiskyWilliamPeel);
            leBarberousse.ajouterBoisson(cocaCola);
            leBarberousse.ajouterBoisson(oasisOrange);
            leBarberousse.ajouterBoisson(sevenUp);
            leBarberousse.ajouterBoisson(orangina);
            leBarberousse.ajouterBoisson(jusDeBanane);
            leBarberousse.ajouterBoisson(redBull);

            Bar zoobar = new Bar("Zoobar", new CoordonneesGPS(45.437129, 4.392145), "04 77 80 85 84", "27 Rue Léon Nautin", true, "Images/ImagesBars/zoobar.jpg");
            zoobar.ajouterBoisson(kMangue);
            zoobar.ajouterBoisson(tequilaSunrise);
            zoobar.ajouterBoisson(tequila);
            zoobar.ajouterBoisson(siropGrenadine);
            zoobar.ajouterBoisson(jusOrange);
            zoobar.ajouterBoisson(oasisTropical);

            Bar volDeNuit = new Bar("Vol de Nuit", new CoordonneesGPS(45.438293, 4.392548), "04 77 33 48 02", "12 Rue Elise Gervais", false, "Images/ImagesBars/volDeNuit.jpg");
            volDeNuit.ajouterBoisson(coteDeBeaune);
            volDeNuit.ajouterBoisson(redBull);
            volDeNuit.ajouterBoisson(vodkaEristof);

            Bar leChantier = new Bar("LE CHANTIER", new CoordonneesGPS(45.427643, 4.390312), "04 77 41 75 13", "32 Rue du Onze Novembre", false, "Images/ImagesBars/leChantier.jpg");
            leChantier.ajouterBoisson(chateaubriant);
            leChantier.ajouterBoisson(rhumOldNick);
            leChantier.ajouterBoisson(leffe);
            leChantier.ajouterBoisson(leffeAmbre);
            leChantier.ajouterBoisson(leffeRubis);
            leChantier.ajouterBoisson(kMangue);
            leChantier.ajouterBoisson(peroni);
            leChantier.ajouterBoisson(kronenbourg);
            leChantier.ajouterBoisson(heineken);

            Bar leCafeStJacques = new Bar("Le Café St Jacques", new CoordonneesGPS(45.436357, 4.390070), "04 77 32 00 79", "13 Rue des Martyrs de Vingré", false, "Images/ImagesBars/leCafeStJacques.jpg");
            leCafeStJacques.ajouterBoisson(kMangue);
            leCafeStJacques.ajouterBoisson(tequilaSunrise);
            leCafeStJacques.ajouterBoisson(tequila);
            leCafeStJacques.ajouterBoisson(siropGrenadine);
            leCafeStJacques.ajouterBoisson(jusOrange);
            leCafeStJacques.ajouterBoisson(oasisTropical);

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
            meltdown.ajouterBoisson(heineken);
            meltdown.ajouterBoisson(kronenbourg);
            meltdown.ajouterBoisson(jeagerBombe);
            meltdown.ajouterBoisson(jeagermeister);
            meltdown.ajouterBoisson(whiskyJackDaniel);
            meltdown.ajouterBoisson(whiskyWilliamPeel);
            meltdown.ajouterBoisson(cocaCola);
            meltdown.ajouterBoisson(oasisOrange);
            meltdown.ajouterBoisson(sevenUp);
            meltdown.ajouterBoisson(orangina);
            meltdown.ajouterBoisson(jusDeBanane);
            meltdown.ajouterBoisson(redBull);

            Bar candelaria = new Bar("Candelaria", new CoordonneesGPS(48.862938, 2.364019), "pas de numero", "52 Rue de Saintonge", true, "Images/ImagesBars/candelaria.jpg");
            candelaria.ajouterBoisson(kMangue);
            candelaria.ajouterBoisson(tequilaSunrise);
            candelaria.ajouterBoisson(tequila);
            candelaria.ajouterBoisson(siropGrenadine);
            candelaria.ajouterBoisson(jusOrange);
            candelaria.ajouterBoisson(oasisTropical);

            Bar laPerlaBar = new Bar("La Perla Bar", new CoordonneesGPS(48.855739, 2.356165), "01 42 77 59 40", "26 Rue François Miron", true, "Images/ImagesBars/laPerlaBar.jpg");
            laPerlaBar.ajouterBoisson(coteDeBeaune);
            laPerlaBar.ajouterBoisson(redBull);
            laPerlaBar.ajouterBoisson(vodkaEristof);

            Bar barDemoryParis = new Bar("Bar Demory Paris", new CoordonneesGPS(48.855739, 2.356165), "09 81 12 53 06", "62 Rue Quincampoix", false, "Images/ImagesBars/barDemoryParis.jpg");
            barDemoryParis.ajouterBoisson(heineken);
            barDemoryParis.ajouterBoisson(kronenbourg);
            barDemoryParis.ajouterBoisson(jeagerBombe);
            barDemoryParis.ajouterBoisson(jeagermeister);
            barDemoryParis.ajouterBoisson(whiskyJackDaniel);
            barDemoryParis.ajouterBoisson(whiskyWilliamPeel);
            barDemoryParis.ajouterBoisson(cocaCola);
            barDemoryParis.ajouterBoisson(oasisOrange);
            barDemoryParis.ajouterBoisson(sevenUp);
            barDemoryParis.ajouterBoisson(orangina);
            barDemoryParis.ajouterBoisson(jusDeBanane);
            barDemoryParis.ajouterBoisson(redBull);

            Bar panicRoom = new Bar("Panic Room", new CoordonneesGPS(48.861313, 2.367645), "01 58 30 93 43", "101 Rue Amelot", false, "Images/ImagesBars/panicRoom.jpg");
            panicRoom.ajouterBoisson(chateaubriant);
            panicRoom.ajouterBoisson(rhumOldNick);
            panicRoom.ajouterBoisson(leffe);
            panicRoom.ajouterBoisson(leffeAmbre);
            panicRoom.ajouterBoisson(leffeRubis);
            panicRoom.ajouterBoisson(kMangue);
            panicRoom.ajouterBoisson(peroni);
            panicRoom.ajouterBoisson(kronenbourg);
            panicRoom.ajouterBoisson(heineken);

            Bar lesCaractèresBarParis = new Bar("Les Caractères Bar Paris", new CoordonneesGPS(48.853746, 2.340308), "07 61 74 47 89", "25 Rue des Grands Augustins", false, "Images/ImagesBars/lesCaractèresBarParis.jpg");
            lesCaractèresBarParis.ajouterBoisson(kMangue);
            lesCaractèresBarParis.ajouterBoisson(tequilaSunrise);
            lesCaractèresBarParis.ajouterBoisson(tequila);
            lesCaractèresBarParis.ajouterBoisson(siropGrenadine);
            lesCaractèresBarParis.ajouterBoisson(jusOrange);
            lesCaractèresBarParis.ajouterBoisson(oasisTropical);

            Bar moonshiner = new Bar("Moonshiner", new CoordonneesGPS(48.855638, 2.371293), "09 50 73 12 99", "5 Rue Sedaine", true, "Images/ImagesBars/moonshiner.jpg");
            moonshiner.ajouterBoisson(heineken);
            moonshiner.ajouterBoisson(kronenbourg);
            moonshiner.ajouterBoisson(jeagerBombe);
            moonshiner.ajouterBoisson(jeagermeister);
            moonshiner.ajouterBoisson(whiskyJackDaniel);
            moonshiner.ajouterBoisson(whiskyWilliamPeel);
            moonshiner.ajouterBoisson(cocaCola);
            moonshiner.ajouterBoisson(oasisOrange);
            moonshiner.ajouterBoisson(sevenUp);
            moonshiner.ajouterBoisson(orangina);
            moonshiner.ajouterBoisson(jusDeBanane);
            moonshiner.ajouterBoisson(redBull);

            Bar harrysNewYorkBar = new Bar("Harry's New York Bar", new CoordonneesGPS(48.853746, 2.340308), "01 42 61 71 14", "5 Rue Daunou", false, "Images/ImagesBars/harrysNewYorkBar.jpg");
            harrysNewYorkBar.ajouterBoisson(coteDeBeaune);
            harrysNewYorkBar.ajouterBoisson(redBull);
            harrysNewYorkBar.ajouterBoisson(vodkaEristof);

            Bar downtownCafe = new Bar("Downtown Cafe", new CoordonneesGPS(48.866367, 2.372194), "01 43 14 29 66", "46 Rue Jean-Pierre Timbaud", false, "Images/ImagesBars/downtownCafe.jpg");
            downtownCafe.ajouterBoisson(chateaubriant);
            downtownCafe.ajouterBoisson(rhumOldNick);
            downtownCafe.ajouterBoisson(leffe);
            downtownCafe.ajouterBoisson(leffeAmbre);
            downtownCafe.ajouterBoisson(leffeRubis);
            downtownCafe.ajouterBoisson(kMangue);
            downtownCafe.ajouterBoisson(peroni);
            downtownCafe.ajouterBoisson(kronenbourg);
            downtownCafe.ajouterBoisson(heineken);

            Bar iceKubeBar = new Bar("Ice Kube Bar", new CoordonneesGPS(48.886584, 2.358854), "01 42 05 20 00", "5 Passage Ruelle", false, "Images/ImagesBars/iceKubeBar.jpg");
            iceKubeBar.ajouterBoisson(coteDeBeaune);
            iceKubeBar.ajouterBoisson(redBull);
            iceKubeBar.ajouterBoisson(vodkaEristof);

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

        public void saveVille(List<IVille> villeList)
        {
            //ne fait rien 
        }
    }
}
