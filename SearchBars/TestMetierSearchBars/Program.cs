using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetierSearchBars;

namespace TestMetierSearchBars
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager mgr = new Manager();

            //test connexion avec User inexistant
            if (mgr.seConnecter("toto", "123456"))
                Console.WriteLine(mgr.CurrentUser.Nom + " connecté");
            else
                Console.WriteLine("Connexion échoué");

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

            //test connexion avec User existant et mauvant mdp
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
        }
    }
}
