﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
   public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight,string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get;protected set; }
    }
}
