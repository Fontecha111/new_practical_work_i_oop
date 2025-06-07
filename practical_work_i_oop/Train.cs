using System;

public enum Status
{
    EnRoute,
    Waiting,
    Docking,
    Dicked
}
namespace practicalwork
{
    public class Train
    {
        protected string ID;
        protected enum Status;
        protected int arrivalTime;
        protected string type;

        public Train(string ID, int arrivalTime, string type)
        {
            this.ID = ID;
            this.arrivalTime = arrivalTime;
            this.type = type;
        }


        public string getID()
        {
            return this.ID;
        }

        public int getArrivalTime()
        {
            return this.arrivalTime;
        }

        public string getType()
        {
            return this.type;
        }
    }

    
}