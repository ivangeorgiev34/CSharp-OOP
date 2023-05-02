using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
   public interface ICar
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }
        public void Drive(double distance);
        public void Refuel(double fuel);

    }
}
