using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : ITruck
    {
        
        private double fuelConsumption;

        public Truck(double fuelQuantity, double fuelConsumption)
        {
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuantity;
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
           private set { fuelConsumption = value + 1.6; }
        }

        public double FuelQuantity { get; private set; }

        public void Drive(double distance)
        {
            if ((FuelConsumption * distance) > FuelQuantity)
            {
                Console.WriteLine($"Truck needs refueling");
            }
            else
            {
                FuelQuantity = FuelQuantity - (FuelConsumption * distance);
                Console.WriteLine($"Truck travelled { distance} km");
            }

        }

        public void Refuel(double fuel)
        {
            FuelQuantity = FuelQuantity + (fuel * 0.95);
        }
    }
}
