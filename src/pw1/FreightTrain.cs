using System;

namespace practicalwork
{
    public class FreightTrain : Train
    {
        private int maxWeight;
        private string freightType;

        public FreightTrain(string ID, int arrivalTime, int maxWeight, string freightType) : base(ID, arrivalTime, "freight")
        {
            this.maxWeight = maxWeight;
            this.freightType = freightType;
        }

        public int GetMaxWeight()
        {
            return this.maxWeight;
        }

        public string GetFreightType()
        {
            return this.freightType;
        }

        public override string ShowInfo()
        {
            return $"Freight Train ID: {ID}, Status: {status}, Arrival Time: {arrivalTime}, Max Weight: {maxWeight}, Freight Type: {freightType}";
        }
    }

}