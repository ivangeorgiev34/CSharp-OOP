using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {

        private string name;
        private int money;
        private List<Product> bagOfProducts;
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }
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
        public int Money
        {
            get { return money; }
            private set 
            {
                if (value < 0)
                {
                    throw new Exception("Money cannot be negative");
                }
                money = value; 
            }
        }
        public List<Product> BagOfProducts
        {
            get { return bagOfProducts; }
            private set { bagOfProducts = value; }
        }
        public void PersonBoughtAProduct(Person person, int cost)
        {
            person.Money = person.Money - cost;
        }

    }
}
