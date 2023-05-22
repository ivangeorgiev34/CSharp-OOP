using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models
{
    public class Boxer : Athlete
    {
        private const int BOXER_STAMINA = 60;
        public Boxer(string fullName, string motivation, int numberOfMedals ) : base(fullName, motivation, numberOfMedals, BOXER_STAMINA)
        {
        }
        public override void Exercise()
        {
            this.Stamina += 15;
            if (this.Stamina > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException("Stamina cannot exceed 100 points.");
            }
        }
    }
}
