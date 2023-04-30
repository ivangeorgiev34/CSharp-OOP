using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }
        public override string ExplainSelf()
        {
            return base.ExplainSelf() + Environment.NewLine + $"MEEOW";
        }
    }
}
