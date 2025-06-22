using System;
using System.Runtime.CompilerServices;

namespace practicalwork
{
    public class Station
    {
        private List<Train> trains; 
        private List<Platform> platforms;

        public Station(int numberOfPlatforms)
        {
            //It initializes the lists
            trains = new List<Train>();
            platforms = new List<Platform>();

            for (int i = 1; i <= numberOfPlatforms; i++)
            {
                platforms.Add(new Platform("P" + i)); //It creates the different platforms (P1, P2...)
            }
        }

        public void AdvanceTick()
        {
            foreach (var train in trains)
            {
                
                if (train.GetStatus() == Status.EnRoute)
                {
                    train.DecreaseArrivalTime(15); //If the train is in route it decreases the arrival time 

                    if (train.GetArrivalTime() == 0)
                    {
                        //When the arrival time is 0, it looks for a Free Platform
                        Platform freePlatform = platforms.FirstOrDefault(p => p.GetStatus() == PlatformStatus.Free);

                        if (freePlatform != null)
                        {
                            freePlatform.AssignTrain(train); //When there is a platform, it assings that train to the platform
                        }
                        else
                        {
                            train.SetStatus(Status.Waiting); //If there is not a free platform it waits
                        }
                    }
                }
                else if (train.GetStatus() == Status.Waiting)
                {
                    Platform freePlatform = platforms.FirstOrDefault(p => p.GetStatus() == PlatformStatus.Free);

                    if (freePlatform != null)
                    {
                        freePlatform.AssignTrain(train);
                    }
                }
            }
            
            foreach (var platform in platforms)
            {
                platform.AdvanceTick();
                platform.FreePlatform();
            }
        }

        public void DisplayStatus()
        {
            Console.WriteLine("----Train Status----");
            foreach (var train in trains)
            {
                Console.WriteLine(train.ShowInfo()); //Shows the info from every train
            }

            Console.WriteLine("----Platform Status----");
            foreach (var platform in platforms)
            {
                Console.WriteLine(platform.ShowInfo()); //Shows the info from every platform
            }
        }

        public bool AllTrainsDocked()
        {
            return trains.All(t => t.GetStatus() == Status.Docked); //It returns true if all the trains are docked
        }   

        public void LoadTrainsFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("The file was not found.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath); 

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    string ID = parts[0]; //This is the ID from the train
                    string type = parts[1].ToLower(); //This is the type of the train (Passenger or Freight)
                    int arrivalTime = int.Parse(parts[2]); //This is de arrival time 

                    if (type == "passenger")
                    {
                        int numberOfCarriages = int.Parse(parts[3]);
                        int capacity = int.Parse(parts[4]);
                        trains.Add(new PassengerTrain(ID, arrivalTime, numberOfCarriages, capacity));
                    }
                    else if (type == "freight")
                    {
                        int maxWeight = int.Parse(parts[3]);
                        string freightType = parts[4];
                        trains.Add(new FreightTrain(ID, arrivalTime, maxWeight, freightType));
                    }
                }

                Console.WriteLine("Trains are loaded succesfully"); 
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error with the file: {ex.Message}");
            }
        }
    }
}