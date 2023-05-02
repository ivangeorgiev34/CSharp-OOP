using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car : ICar
    {
        private double fuelConsumption;

        public Car(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; private set; }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            private set { fuelConsumption = value + 0.9; }
        }


        public void Drive(double distance)
        {
            if ((FuelConsumption * distance) > FuelQuantity)
            {
                Console.WriteLine($"Car needs refueling");
            }
            else
            {
                FuelQuantity = FuelQuantity - (FuelConsumption * distance);
                Console.WriteLine($"Car travelled { distance} km");
            }
            
        }

        public void Refuel(double fuel)
        {
            FuelQuantity = FuelQuantity + fuel;
        }
    }
}
