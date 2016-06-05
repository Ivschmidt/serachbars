using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetierSearchBars;
using DataSearchBars;

namespace TestMetierSearchBars
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager mgr = new Manager(new StubData());

            Console.WriteLine("Test connexion avec User inexistant");
            if (mgr.seConnecter("toto", "123456"))
                Console.WriteLine(mgr.CurrentUser.Nom + " connecté");
            else
                Console.WriteLine("Connexion échoué");

            Console.WriteLine();
            Console.WriteLine("Test inscription avec numTel éronné (10 chiffres)");
            try
            {
                mgr.sInscrire("toto", "1234", "michel", "jean", Sexe.Femme, new DateTime(1986, 9, 20), "06589636565");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Test inscription avec numTel éronné (lettres)");
            try
            {
                mgr.sInscrire("toto", "1234", "michel", "jean", Sexe.Femme, new DateTime(1986, 9, 20), "065896c365");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine();
            Console.WriteLine("Test inscription");
            try
            {
                mgr.sInscrire("tutu", "123", "delabierre", "Yvan", Sexe.Homme, new DateTime(1980, 1, 9), ville: "St Julien De Copel");
                Console.WriteLine("Inscription réussie");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Test connexion suite à l'inscription : avec User existant et bon mdp");
            if (mgr.seConnecter("tutu", "123"))
                Console.WriteLine(mgr.CurrentUser.Nom + " connecté");
            else
                Console.WriteLine("Connexion échoué");

            Console.WriteLine();
            Console.WriteLine("Test connexion avec User existant et mauvais mdp");
            if (mgr.seConnecter("tutu", "1234"))
                Console.WriteLine(mgr.CurrentUser.Nom + " connecté");
            else
                Console.WriteLine("Connexion échoué");

            Console.WriteLine();
            Console.WriteLine("Tentative d'inscription d'un User déja existant");
            try
            {
                mgr.sInscrire("tutu", "123", "delabierre", "yvan", Sexe.Homme, new DateTime(1980, 1, 9), ville: "st julien de copel");
                Console.WriteLine("inscription réussie");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Test modification d'un User (avec User existant et connecté avec Mot de passe correct)");
            if(mgr.verifierMotDePasse("123"))
            {
                mgr.modifierUser(nprenom: "Denis", nnom: "Brognard");
                Console.WriteLine("Mot de passe correct");
            }
            else
            {
                Console.WriteLine("Mot de passe incorrect");
            }
            Console.WriteLine("Nouveau nom : " + mgr.CurrentUser.Nom);
            Console.WriteLine("Nouveau prénom : " + mgr.CurrentUser.Prenom);

            Console.WriteLine();
            Console.WriteLine("Test modification d'un User (avec User existant et connecté mais Mot de passe incorrect)");
            if (mgr.verifierMotDePasse("456"))
            {
                mgr.modifierUser(nprenom: "Jacques", nnom: "Line");
                Console.WriteLine("Mot de passe correct");
            }
            else
            {
                Console.WriteLine("Mot de passe incorrect");
            }
            Console.WriteLine("Nouveau nom : " + mgr.CurrentUser.Nom);
            Console.WriteLine("Nouveau prénom : " + mgr.CurrentUser.Prenom);

            Console.WriteLine();
            Console.WriteLine("Test modification d'un User (avec User existant et connecté, Mot de passe correct mais envoi du meme nom)");
            if (mgr.verifierMotDePasse("123"))
            {
                mgr.modifierUser(nprenom: "coco", nnom: "Brognard");
                Console.WriteLine("Mot de passe correct");
            }
            else
            {
                Console.WriteLine("Mot de passe incorrect");
            }
            Console.WriteLine("Nouveau nom : " + mgr.CurrentUser.Nom);
            Console.WriteLine("Nouveau prénom : " + mgr.CurrentUser.Prenom);

            Console.WriteLine();
            Console.WriteLine("Test affichage des villes avec leur bars et eux-mêmes leurs boissons :");
            foreach (IVille ville in mgr.ListVilles)
            {
                Console.WriteLine(ville);
            }

            Console.WriteLine("Test recherche de bars avec restauration dans ville 2 (nice)");
            mgr.rechercherBars(mgr.ListVilles.ElementAt(1), true);
            foreach(IBar bar in mgr.BarRecherches)
            {
                Console.Write(bar);
            }

            Console.WriteLine("Test recherche de bars avec comme boisson coktails dans ville 1 (clermont)");
            mgr.rechercherBars(mgr.ListVilles.ElementAt(0), listTypeBoissonPref : new List<TypeBoisson> { TypeBoisson.Soda});
            foreach (IBar bar in mgr.BarRecherches)
            {
                Console.Write(bar);
            }

            Console.WriteLine();
            Console.WriteLine("Test laisser un avis");
            try
            {
                mgr.laisserUnAvis(mgr.BarRecherches.ElementAt(0), 4, "super bar, bonne ambiance");
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            mgr.seDeconnecter();

            mgr.seConnecter("ivschmidt", "290497");
            try
            {
                mgr.laisserUnAvis(mgr.BarRecherches.ElementAt(0), 2, "je ne vais pas y retourner j'ai mal à la langue !");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            foreach (IBar bar in mgr.BarRecherches)
            {
                Console.Write(bar + "\n");
            }

            Console.WriteLine("Test de déconnexion :");
            mgr.seDeconnecter();
            Console.WriteLine("Déconnexion");
            Console.WriteLine();
        }
    }
}
