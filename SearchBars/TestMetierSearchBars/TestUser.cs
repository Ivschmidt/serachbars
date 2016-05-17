using System;
using MetierSearchBars;

namespace TestMetierSearchBars
{
    class TestUser
    {
        static void Main(string[] args)
        {
            User u1 = new User("u1", "mdp1", "jacky", "michel", Sexe.Homme, new DateTime(1962, 05, 28), "0659712062", boissonPref: TypeBoisson.Soda);
            Console.WriteLine("ville du user" + u1.NumTel);
        }
    }
}
