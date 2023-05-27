using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int HAPPY_BUNNY_ENERGY = 100;
        public HappyBunny(string name ) : base(name, HAPPY_BUNNY_ENERGY)
        {
        }

        public override void Work()
        { 
            this.Energy -= 10;
        }
    }
}
