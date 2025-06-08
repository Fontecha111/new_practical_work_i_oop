using System;

namespace practicalwork
{
    public class FreightTrain : Train
    {
        private int maxWeight;
        private string freightType;

        public FreightTrain(int maxWeight, string freightType, string ID, int arrivalTime, string type) : base(ID, arrivalTime, type)
        {
            this.maxWeight = maxWeight;
            this.freightType = freightType;
        }

        public int getMaxWeight()
        {
            return this.maxWeight;
        }

        public string getFreighType()
        {
            return this.freightType;
        }
    }
}