using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
   public abstract class BaseHero : IBaseHero
    {
        
        public string Name { get; protected set; }

        public int Power { get; protected set; }

        public abstract string CastAbility();
        
    }
}
