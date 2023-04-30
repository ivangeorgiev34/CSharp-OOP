using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        protected string name;
        protected string favouriteFood;
        public virtual string ExplainSelf()
        {
            return $"I am {name} and my favourite food is {favouriteFood}";
        }
    }
}
