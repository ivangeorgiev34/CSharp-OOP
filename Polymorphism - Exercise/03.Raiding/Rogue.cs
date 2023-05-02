using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
   public class Rogue : BaseHero
    {
        public Rogue(string name)
        {
            this.Name = name;
            this.Power = 80;
        }

        

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
