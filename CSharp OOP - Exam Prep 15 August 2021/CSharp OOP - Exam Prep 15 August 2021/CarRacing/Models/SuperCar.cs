using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models
{
    public class SuperCar : Car , ICar
    {
        private const double SUPER_CAR_AVAILABLE_FUEL = 80;
        private const double SUPER_CAR_FUEL_CONSUMPTION_PER_RACE = 10;
        public SuperCar(string make, string model, string VIN, int horsePower  ) : base(make, model, VIN, horsePower, SUPER_CAR_AVAILABLE_FUEL, SUPER_CAR_FUEL_CONSUMPTION_PER_RACE)
        {
        }
        
    }
}
