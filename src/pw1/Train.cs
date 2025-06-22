using System;


namespace practicalwork
{
    public enum Status
    {
        EnRoute,
        Waiting,
        Docking,
        Docked
    }
    public class Train
    {
        protected string ID;
        protected Status status;
        protected int arrivalTime;
        protected string type;

        public Train(string ID, int arrivalTime, string type)
        {
            this.ID = ID;
            this.arrivalTime = arrivalTime;
            this.type = type;
            this.status = Status.EnRoute;
        }


        public string GetID()
        {
            return this.ID;
        }

        public int GetArrivalTime()
        {
            return this.arrivalTime;
        }

        public string GetType()
        {
            return this.type;
        }

        public Status GetStatus()
        {
            return this.status;
        }

        public void SetStatus(Status newStatus)
        {
            status = newStatus;
        }

        public virtual string ShowInfo()
        {
            return $"Train ID: {ID}, Type: {type}, Status: {status}, Arrival Time: {arrivalTime}";
        }

        public void DecreaseArrivalTime(int minutes)
        {
            arrivalTime = Math.Max(0, arrivalTime - minutes);
        }
    }

    
}