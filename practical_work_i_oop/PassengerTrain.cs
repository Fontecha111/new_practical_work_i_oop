using System;
using System.Runtime.InteropServices;

namespace practicalwork
{
    public class PassengerTrain : Train
    {
        private int numberOfCarriages;
        private int capacity;


        public PassengerTrain(int numberOfCarriages, int capacity, string ID, int arrivalTime, string type) : base(ID, arrivalTime, type)
        {
            this.numberOfCarriages = numberOfCarriages;
            this.capacity = capacity;
        }

        public int getNumberOfCarriages()
        {
            return this.numberOfCarriages;
        }

        public int getCapacity()
        {
            return this.capacity;
        }
    }
}