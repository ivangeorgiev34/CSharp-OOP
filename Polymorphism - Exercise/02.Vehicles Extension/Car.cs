using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Vehicles
{
    public class Car : IVehicle
    {
        private double fuelConsumption;
        private double fuelQuantity;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;

        }

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            private set
            {
                if (value > TankCapacity)
                {
                    value = 0;
                    fuelQuantity = value;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption
        {
            get { return fuelConsumption; }
            private set { fuelConsumption = value + 0.9; }
        }

        public double TankCapacity { get; private set; }

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
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            if (fuel + FuelQuantity > TankCapacity)
            {
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
                return;
            }
            FuelQuantity = FuelQuantity + fuel;
        }
    }
}
