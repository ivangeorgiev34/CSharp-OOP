using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models
{
    public class ProfessionalRacer : Racer,IRacer
    {
        private const int PROFESSIONAL_RACER_DRIVING_EXPERIENCE = 30;
        private const string PROFESSIONAL_RACER_RACING_BEHAVIOR ="strict";
        public ProfessionalRacer(string username, ICar car) : base(username, PROFESSIONAL_RACER_RACING_BEHAVIOR, PROFESSIONAL_RACER_DRIVING_EXPERIENCE, car)
        {
        }
        public override void Race()
        {
            this.Race();
            this.DrivingExperience += 10;
        }
    }
}
