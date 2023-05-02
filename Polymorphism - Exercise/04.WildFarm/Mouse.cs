using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }
        public override string MakeSound()
        {
            return "Squeak";
        }
        public override void Eat(int foodEaten)
        {
            Weight = Weight + foodEaten * 0.10;
            this.FoodEaten = this.FoodEaten + foodEaten;
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
