using System;
using System.Collections.Generic;
using System.Text;

namespace _02.Vehicles
{
    public  abstract class Vehicle : IVehicle
    {
        public double TankCapacity { get; private set; }

        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public abstract void Drive(double distance);


        public abstract void Refuel(double fuel);
        
    }
}
