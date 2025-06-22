using System;

namespace practicalwork
{
    //Enum for the different Platform status
    public enum PlatformStatus
    {
        Free,
        Occupied
    }

    public class Platform
    {
        private string ID;
        private PlatformStatus status;
        private Train currentTrain;
        private int dockingTime;

        public Platform(string ID)
        {
            this.ID = ID;
            this.status = PlatformStatus.Free;
            this.currentTrain = null;
            this.dockingTime = 0;
        }

        public string GetID()
        {
            return this.ID;
        }

        public PlatformStatus GetStatus()
        {
            return this.status;
        }

        public Train GetCurrentTrain()
        {
            return this.currentTrain;
        }

        public int GetDockingTime()
        {
            return this.dockingTime;
        }

        public void AssignTrain(Train train)
        {
            this.currentTrain = train; //It assigns the train 
            this.status = PlatformStatus.Occupied; //Changes the status of the platform to occupied 
            this.dockingTime = 2;
            train.SetStatus(Status.Docking); 
        }

        public void AdvanceTick()
        {
            //If the platform is occupied and there is still docking time
            if (status == PlatformStatus.Occupied && dockingTime > 0)
            {
                dockingTime--;
                if (dockingTime == 0)
                {
                    currentTrain.SetStatus(Status.Docked); //Changes the train status to Docked
                }
            }
        }

        public void FreePlatform()
        {
            //If the train is already docked and there is no docking time left
            if (dockingTime == 0 && currentTrain != null && currentTrain.GetStatus() == Status.Docked)
            {
                currentTrain = null; //It frees the platform
                status = PlatformStatus.Free; //Changes the status of the platform to Free
            }
        }

        public string ShowInfo()
        {
            //It shows the platform status when it is free or when it is occupied 
            if (status == PlatformStatus.Free)
            {
                return $"Platform {ID}: Free";
            }
            else
            {
                return $"Platform {ID}: Occupied by the Train {currentTrain.GetID()} with status: {currentTrain.GetStatus()} - Remaining Ticks: {dockingTime}";
            }
        }
        
    }
}