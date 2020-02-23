using System;

namespace Poker
{
    class Program
    {
        static Random random = new Random();
        static NetworkManager nm = new NetworkManager();
        static GameControll gc = new GameControll(random);

        static void Main()
        {
            string title = "Poker Game";
            Console.Title = title + ": Setup";

            nm.Setup();
        }

        public static void MainHost()
        {

        }

        public static void MainConnect()
        {

        }

        public static void MainOffline()
        {
            
        }
    }
}
