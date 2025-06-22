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

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Enter the file name: ");
                        string fileName = Console.ReadLine();
                        station.LoadTrainsFromFile(fileName);
                        break;


                    case "2":
                        Console.WriteLine("Starting simulation...");
                        while (!station.AllTrainsDocked()) 
                        {
                            station.AdvanceTick();
                            station.DisplayStatus();
                            Thread.Sleep(2500);
                        }
                        Console.WriteLine("All the trains are docked. Simulation is finished");
                        break;

                    case "3":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("That is not a valid option to choose. Try again.");
                        break;
                }
            }
        }
    }
}