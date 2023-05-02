using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Vehicles
{
    public class Bus : IVehicle
    {
        private AirConditioner airConditioner;
        private double fuelConsumption;
        private double fuelQuantity;
        public Bus(double fuelQuantity, double fuelConsumption,double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
            this.FuelQuantity = fuelQuantity;
        }
        public double TankCapacity { get; private set; }
        
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
            private set { fuelConsumption = value; }
        }

        public void Drive(double distance)
        {
            if (airConditioner == AirConditioner.Default)
            {
                FuelConsumption = FuelConsumption + 1.4;
            }
           else if (airConditioner == AirConditioner.Off)
            {
                FuelConsumption = FuelConsumption + 1.4;
            }
            airConditioner = AirConditioner.On;

            if ((FuelConsumption * distance) > FuelQuantity)
            {
                Console.WriteLine($"Bus needs refueling");
            }
            else
            {
                FuelQuantity = FuelQuantity - (FuelConsumption * distance);
                Console.WriteLine($"Bus travelled { distance} km");
            }
        }

        public void DriveEmpty(double distance)
        {
            if (airConditioner == AirConditioner.Default)
            {
                
            }
            else if (airConditioner == AirConditioner.On)
            {
                FuelConsumption = FuelConsumption - 1.4;
            }
            airConditioner = AirConditioner.Off;
            

            if ((FuelConsumption * distance) > FuelQuantity)
            {
                Console.WriteLine($"Bus needs refueling");
            }
            else
            {
                FuelQuantity = FuelQuantity - (FuelConsumption * distance);
                Console.WriteLine($"Bus travelled { distance} km");
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
