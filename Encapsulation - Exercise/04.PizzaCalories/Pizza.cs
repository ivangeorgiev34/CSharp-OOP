using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        public Pizza(string name)
        {
            Name = name;
            
        }
        private string name;
        //private Dough dough;
        //private Topping topping;
        private double totalCalories;
        private int toppingsCount;

        public int ToppingsCount
        {
            get { return toppingsCount; }
            private set
            {
                if (value >= 10)
                {
                    throw new Exception("Number of toppings should be in range [0..10].");
                }
                toppingsCount = value;
            }
        }

        public double TotalCalories
        {
            get { return totalCalories; }
            private set
            {
                totalCalories = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value) || value.Length > 15 || value.Length < 1)
                {
                    throw new Exception("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        //public Dough Dough
        //{
        //    get { return dough; }
        //     set { dough = value; }
        //}
        //public Topping Topping
        //{
        //    get { return topping; }
        //    private set
        //    {
                
        //        topping = value;
        //    }
        //}
        public void AddToppingCalories(double caloriesToAdd)
        {
            TotalCalories = TotalCalories + caloriesToAdd;
            ToppingsCount++;
        }
        public void AddDoughCalories(double caloriesToAdd)
        {
            TotalCalories = TotalCalories + caloriesToAdd;
            
        }

    }
}
