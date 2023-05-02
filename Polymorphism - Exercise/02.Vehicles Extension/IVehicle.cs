using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Vehicles
{
  public  interface IVehicle
    {
        public double TankCapacity { get; }
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
        public void Drive(double distance);
        public void Refuel(double fuel);
    }
}
