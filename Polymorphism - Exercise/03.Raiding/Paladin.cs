﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
   public class Paladin: BaseHero
    {
        public Paladin(string name)
        {
            this.Name = name;
            this.Power = 100;
        }

        

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
