using System;

namespace practicalwork
{
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
            this.currentTrain = train;
            this.status = PlatformStatus.Occupied;
            this.dockingTime = 2;
            train.SetStatus(Status.Docking);
        }

        public void AdvanceTick()
        {
            if (status == PlatformStatus.Occupied && dockingTime > 0)
            {
                dockingTime--;
                if (dockingTime == 0)
                {
                    currentTrain.SetStatus(Status.Docked);
                }
            }
        }

        public void FreePlatform()
        {
            if (dockingTime == 0 && currentTrain != null && currentTrain.GetStatus() == Status.Docked)
            {
                currentTrain = null;
                status = PlatformStatus.Free;
            }
        }

        public string ShowInfo()
        {
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