using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Cat : Feline
    {
        public Cat(string name, double weight , string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }
        public override string MakeSound()
        {
            return "Meow";
        }
        public override void Eat(int foodEaten)
        {
            Weight = Weight  + foodEaten* 0.30;
            this.FoodEaten = this.FoodEaten + foodEaten;
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
