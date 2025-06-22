using System;

namespace practicalwork
{
    public class Station
    {
        private List<Train> trains;
        private List<Platform> platforms;

        public Station(int numberOfPlatforms)
        {
            trains = new List<Train>();
            platforms = new List<Platform>();

            for (int i = 1; i <= numberOfPlatforms; i++)
            {
                platforms.Add(new Platform("P" + i));
            }
        }

        public void AdvanceTick()
        {
            foreach (var train in trains)
            {
                if (train.GetStatus() == Status.EnRoute)
                {
                    train.DecreaseArrivalTime(15);

                    if (train.GetArrivalTime() == 0)
                    {
                        Platform freePlatform = platforms.FirstOrDefault(p => p.GetStatus() == PlatformStatus.Free);

                        if (freePlatform != null)
                        {
                            freePlatform.AssignTrain(train);
                        }
                        else
                        {
                            train.SetStatus(Status.Waiting);
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
                Console.WriteLine(train.ShowInfo());
            }

            Console.WriteLine("----Platform Status----");
            foreach (var platform in platforms)
            {
                Console.WriteLine(platform.ShowInfo());
            }
        }

        public bool AllTrainsDocked()
        {
            return trains.All(t => t.GetStatus() == Status.Docked);
        }   

        public void LoadTrainsFromFile(string filePath)
        {
            
        }
    }
}