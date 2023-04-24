using System;

namespace _04.PizzaCalories
{
   public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] inputPizza = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Pizza pizza = new Pizza(inputPizza[1]);
                string command = Console.ReadLine();
                while (command!="END")
                {
                    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (tokens[0] == "Dough")
                    {
                        Dough dough = new Dough(tokens[1], tokens[2], double.Parse(tokens[3]));
                        double calories = dough.CalculateCalories();
                        pizza.AddDoughCalories(calories);
                    }
                    else if (tokens[0] == "Topping")
                    {
                        Topping topping = new Topping(tokens[1], double.Parse(tokens[2]));
                        double calories = topping.CalculateCalories();
                        pizza.AddToppingCalories(calories);
                    }    
                    command = Console.ReadLine();
                }
                 
                Console.WriteLine($"{pizza.Name} - {String.Format("{0:0.00}", pizza.TotalCalories)} Calories.");
            }
            catch (Exception ee)
            {

                Console.WriteLine(ee.Message);
            }
           
        }
    }
}
