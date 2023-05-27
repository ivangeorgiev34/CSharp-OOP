using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models
{
    public class StreetRacer : Racer , IRacer
    {
        private const int STREET_RACER_DRIVING_EXPERIENCE = 10;
        private const string STREET_RACER_RACING_BEHAVIOR = "aggressive";
        public StreetRacer(string username, ICar car) : base(username, STREET_RACER_RACING_BEHAVIOR, STREET_RACER_DRIVING_EXPERIENCE, car)
        {
        }
        public override void Race()
        {
            this.Race();
            this.DrivingExperience += 5;
        }
    }
}
