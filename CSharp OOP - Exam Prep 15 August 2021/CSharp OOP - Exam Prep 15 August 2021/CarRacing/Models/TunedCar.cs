using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models
{
    public class TunedCar : Car,ICar
    {
        private const double TUNED_CAR_AVAILABLE_FUEL = 65;
        private const double TUNED_CAR_FUEL_CONSUMPTION_PER_RACE = 7.5;
        public TunedCar(string make, string model, string VIN, int horsePower) : base(make, model, VIN, horsePower, TUNED_CAR_AVAILABLE_FUEL, TUNED_CAR_FUEL_CONSUMPTION_PER_RACE)
        {
        }

        public override void Drive()
        {
            base.Drive();
            this.HorsePower = (int)Math.Round(this.HorsePower - (this.HorsePower * 0.03));
        }
    }
    
}
