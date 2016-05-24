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

            //test connexion avec User inexistant
            if (mgr.seConnecter("toto", "123456"))
                Console.WriteLine(mgr.CurrentUser.Nom + " connecté");
            else
                Console.WriteLine("Connexion échoué");

            //test inscription avec numTel éronné (10 chiffres)
            try
            {
                mgr.sInscrire("toto", "1234", "michel", "jean", Sexe.Femme, new DateTime(1986, 9, 20), "06589636565");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //test inscription avec numTel éronné (lettres)
            try
            {
                mgr.sInscrire("toto", "1234", "michel", "jean", Sexe.Femme, new DateTime(1986, 9, 20), "065896c365");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            //test inscription
            try
            {
                mgr.sInscrire("tutu", "123", "delabierre", "Yvan", Sexe.Homme, new DateTime(1980, 1, 9), ville: "St Julien De Copel");
                Console.WriteLine("Inscription réussie");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //test connexion suite à l'inscription : avec User existant et bon mdp
            if (mgr.seConnecter("tutu", "123"))
                Console.WriteLine(mgr.CurrentUser.Nom + " connecté");
            else
                Console.WriteLine("Connexion échoué");

            //test connexion avec User existant et mauvais mdp
            if (mgr.seConnecter("tutu", "1234"))
                Console.WriteLine(mgr.CurrentUser.Nom + " connecté");
            else
                Console.WriteLine("Connexion échoué");

            //tentative d'inscription d'un User déja existant
            try
            {
                mgr.sInscrire("tutu", "123", "delabierre", "yvan", Sexe.Homme, new DateTime(1980, 1, 9), ville: "st julien de copel");
                Console.WriteLine("inscription réussie");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //test modification avec User existant et connecté (+Mot de passe correct)
            try
            {
                mgr.modifierUser("123", nprenom: "Denis", nnom: "Brognard");
                Console.WriteLine("Mot de passe correct");
                Console.WriteLine("Nouveau nom : " + mgr.CurrentUser.Nom);
                Console.WriteLine("Nouveau prénom : " + mgr.CurrentUser.Prenom);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //test modification avec User existant et connecté (+Mot de passe incorrect)
            try
            {
                mgr.modifierUser("560", nprenom: "Denis", nnom: "Brognard");
                Console.WriteLine("Nouveau nom : " + mgr.CurrentUser.Nom);
                Console.WriteLine("Nouveau prénom : " + mgr.CurrentUser.Prenom);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //afficher les villes
            foreach (IVille ville in mgr.ListVilles)
            {
                Console.WriteLine(ville);
            }

            //test déconnexion 
            mgr.seDeconnecter();
            Console.WriteLine("Déconnexion");
        }
    }
}
