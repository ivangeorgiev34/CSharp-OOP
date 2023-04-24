using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty");
                }
                name = value;
            }
        }
        private int cost;

        public int Cost
        {
            get { return cost; }
            private set 
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }   
                cost = value; 
            }
        }


    }
}
