using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public abstract class Animal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
           
        }
        public string Name { get;protected set; }
        public double Weight { get;protected set; }
        public int FoodEaten { get;protected set; }
        public virtual string MakeSound()
        {
            return string.Empty;
        }
        public virtual void Eat(int foodEaten)
        {
            
        }
        public override string ToString()
        {
            return "";
        }

    }
}
