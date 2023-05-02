using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight , string livingRegion) : base(name, weight, livingRegion)
        {
        }
        public override string MakeSound()
        {
            return  "Woof!";
        }
        public override void Eat(int foodEaten)
        {
            Weight = Weight + foodEaten * 0.40;
            this.FoodEaten = this.FoodEaten + foodEaten;
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
