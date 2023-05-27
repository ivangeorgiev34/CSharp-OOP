using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class SleepyBunny : Bunny
    {
        private const int SLEEPY_BUNNY_ENERGY = 50;
        public SleepyBunny(string name ) : base(name, SLEEPY_BUNNY_ENERGY)
        {
        }

        public override void Work()
        {
            //check for logic errors here
            this.Energy -= 15;
        }
    }
}
