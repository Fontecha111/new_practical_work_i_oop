using System;

namespace practicalwork
{
    public class PassengerTrain : Train
    {
        private int numberOfCarriages;
        private int capacity;

        public PassengerTrain(string ID, int arrivalTime, int numberOfCarriages, int capacity) : base(ID, arrivalTime, "passenger")
        {
            this.numberOfCarriages = numberOfCarriages;
            this.capacity = capacity;
        }

        public int GetNumberOfCarriages()
        {
            return this.numberOfCarriages;
        }

        public int GetCapacity()
        {
            return this.capacity;
        }

        public override string ShowInfo()
        {
            return $"Passenger Train ID: {ID}, Status: {status}, Arrival Time: {arrivalTime}, Carriages: {numberOfCarriages}, Capacity: {capacity}";
        }
    }
}