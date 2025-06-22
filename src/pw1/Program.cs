using System;

namespace practicalwork
{
    public class Program
    {
        public static void Main()
        {
            Station station = new Station(6); //New station with 6 different platforms
            bool exit = false;

            while (!exit) //Loop that executes until the user wants to exit
            {
                //Different menu options
                Console.WriteLine("----- UFV Train Station -----");
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Load trains from an existing file");
                Console.WriteLine("2. Start simulation");
                Console.WriteLine("3. Exit");

                string input = Console.ReadLine();

                //Switch for the different cases depending on the input from the user
                switch (input)
                {
                    case "1": //Case 1 to charge trains from a file
                        Console.WriteLine("Enter the file name: ");
                        string fileName = Console.ReadLine();
                        station.LoadTrainsFromFile(fileName);
                        break;


                    case "2":
                        Console.WriteLine("Starting simulation...");
                        while (!station.AllTrainsDocked()) //It executes this loop when there are no trains docked
                        {
                            station.AdvanceTick();
                            station.DisplayStatus();
                            Thread.Sleep(2500); //Updates the status every 2.5 seconds
                        }
                        Console.WriteLine("All the trains are docked. Simulation is finished");
                        break;

                    case "3": //Option to exit the program
                        exit = true;
                        break;

                    default: //Default case if the user enters an invalid input in the menu
                        Console.WriteLine("That is not a valid option to choose. Try again.");
                        break;
                }
            }
        }
    }
}