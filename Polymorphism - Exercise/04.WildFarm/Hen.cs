using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        public override string MakeSound()
        {
            return "Cluck";
        }
        public override void Eat(int foodEaten)
        {
            Weight = Weight + foodEaten* 0.35;
            this.FoodEaten = this.FoodEaten + foodEaten;
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
