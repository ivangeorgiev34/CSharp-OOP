using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override string MakeSound()
        {
            return "Hoot Hoot";
        }
        public override void Eat(int foodEaten)
        {
            Weight = Weight + (foodEaten * 0.25);
            this.FoodEaten = this.FoodEaten + foodEaten;
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
