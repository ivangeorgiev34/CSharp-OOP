using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Peter=11;George=4
            //Bread=10;Milk=2;
            //Peter Bread
            //George Milk
            //George Milk
            //Peter Milk
            //END
            try
            {
                List<Product> products = new List<Product>();
                List<Person> persons = new List<Person>();
                string[] firstLine = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
                string[] secondLine = Console.ReadLine().Split(';',StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < firstLine.Length; i++)
                {
                    string[] tokens = firstLine[i].Split('=',StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[0];
                    int money = int.Parse(tokens[1]);
                    persons.Add(new Person(name, money));
                }
                for (int i = 0; i < secondLine.Length; i++)
                {
                    string[] tokens = secondLine[i].Split('=',StringSplitOptions.RemoveEmptyEntries);
                    string name = tokens[0];
                    int cost = int.Parse(tokens[1]);
                    products.Add(new Product(name, cost));
                }
                string command = Console.ReadLine();
                while (command != "END")
                {
                    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string personName = tokens[0];
                    string productName = tokens[1];

                    Person person = persons.FirstOrDefault(x => x.Name == personName);
                    Product product = products.FirstOrDefault(x => x.Name == productName);
                    if (person.Money >= product.Cost)
                    {
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                        person.BagOfProducts.Add(product);
                        person.PersonBoughtAProduct(person, product.Cost);
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");

                    }
                    command = Console.ReadLine();
                }
                foreach (Person person in persons)
                {
                    if (person.BagOfProducts.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");
                        continue;
                    }
                    List<string> list = new List<string>();
                    for (int i = 0; i < person.BagOfProducts.Count; i++)
                    {
                        list.Add(person.BagOfProducts[i].Name);
                    }
                    Console.WriteLine($"{person.Name} - {string.Join(", ", list)}");

                }
            }
            catch (Exception error)
            {

                Console.WriteLine(error.Message);
            }


        }
    }
}

