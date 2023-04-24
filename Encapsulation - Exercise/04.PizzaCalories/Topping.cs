using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private string type;
        private double grams;
        private double caloriesPerGram;
        public Topping(string type,double grams)
        {
            Type = type;
            Grams = grams;
        }
        public double CaloriesPerGram
        {
            get { return caloriesPerGram; }
            private set
            {
                caloriesPerGram = value;
            }
        }

        public string Type
        {
            get { return type; }
            private set
            {
                if (value.ToLower() == "meat")
                {
                    CaloriesPerGram = 1.2;
                }
                else if (value.ToLower() == "veggies")
                {
                    CaloriesPerGram = 0.8;
                }
                else if (value.ToLower() == "cheese")
                {
                    CaloriesPerGram = 1.1;
                }
                else if (value.ToLower() == "sauce")
                {
                    CaloriesPerGram = 0.9;
                }
                else
                {
                    throw new Exception($"Cannot place {value} on top of your pizza.");
                }
                type = value;
            }
        }
        public double Grams
        {
            get { return grams; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new Exception($"{Type} weight should be in the range [1..50].");
                }
                grams = value;
            }
        }
        public double CalculateCalories()
        {
            return 2 * Grams * CaloriesPerGram;
        }
    }
}
