using System;

namespace practicalwork
{
    public class Program
    {
        public static void Main()
        {
            Station station = new Station(6);
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("----- UFV Train Station -----");
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Load trains from an existing file");
                Console.WriteLine("2. Start simulation");
                Console.WriteLine("3. Exit");

                string input = Console.ReadLine();

                
            }
        }
    }
}