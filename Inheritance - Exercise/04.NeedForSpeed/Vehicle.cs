using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_VEHICLE_FUEL_CONSUMPTION = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }
        public virtual double FuelConsumption { get { return DEFAULT_VEHICLE_FUEL_CONSUMPTION; }  }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }
        public  void Drive(double kilometers)
        {
            if (Fuel - (kilometers * FuelConsumption) >= 0)
            {
                Fuel = Fuel - (kilometers * FuelConsumption);
            }
        }
    }
}
