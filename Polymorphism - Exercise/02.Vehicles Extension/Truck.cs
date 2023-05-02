using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Vehicles
{
  public  class Truck : IVehicle
    {

        private double fuelConsumption;
        private double fuelQuantity;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuantity;
            
        }

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            private set { fuelConsumption = value + 1.6; }
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

        public double TankCapacity { get; private set; }

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
            FuelQuantity = FuelQuantity + (fuel * 0.95);
        }
    }
}
