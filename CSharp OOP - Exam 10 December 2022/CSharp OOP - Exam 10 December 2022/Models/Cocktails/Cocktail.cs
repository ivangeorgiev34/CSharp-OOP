using ChristmasPastryShop.Models.Cocktails.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        public Cocktail(string cocktailName, string size, double price)
        {
            this.Name= cocktailName;
            this.Size= size;
            this.Price= price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                name = value;
            }
        }

        public string Size
        {
            get { return size; }
            private set { size = value; }
        }

        public double Price
        {
            get { return price; }
            private set 
            {
                //check for possible errors here
                if (this.Size == "Large")
                {
                    value = value;
                }
                else if (this.Size == "Middle")
                {
                    double result = value / 3;
                    value = value - result;
                }
                else if (this.Size == "Small")
                {
                    value = value / 3;
                }
                price = value; 
            }
        }
        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
        }
    }
}
