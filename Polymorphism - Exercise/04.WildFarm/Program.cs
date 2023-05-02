using System;
using System.Collections.Generic;

namespace _04.WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> list = new List<Animal>();
            string input = Console.ReadLine();
            Animal animal = null;

            while (input != "End")
            {
                string[] animalInfo = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string[] foodInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string animalType = animalInfo[0];

                if (animalType == "Owl")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    double wingSize = double.Parse(animalInfo[3]);
                    if (foodInfo[0] == "Meat")
                    {
                        animal = new Owl(name, weight, wingSize);
                        animal.Eat(int.Parse(foodInfo[1]));
                        list.Add(animal);
                        Console.WriteLine(animal.MakeSound());
                    }
                    else
                    {
                        animal = new Owl(name, weight, wingSize);
                        list.Add(animal);
                        Console.WriteLine(animal.MakeSound());
                        Console.WriteLine($"{animal.GetType().Name} does not eat {foodInfo[0]}!");
                    }
                }
                else if (animalType == "Hen")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    double wingSize = double.Parse(animalInfo[3]);
                    if (foodInfo[0] == "Meat" || foodInfo[0] == "Vegetable" || foodInfo[0] == "Fruit" || foodInfo[0] == "Seeds")
                    {
                        animal = new Hen(name, weight, wingSize);
                        animal.Eat(int.Parse(foodInfo[1]));
                        list.Add(animal);
                        Console.WriteLine(animal.MakeSound());
                    }
                    else
                    {
                        animal = new Hen(name, weight, wingSize);
                        list.Add(animal);
                        Console.WriteLine(animal.MakeSound());
                        Console.WriteLine($"{animal.GetType().Name} does not eat {foodInfo[0]}!");
                    }
                }
                else if (animalType == "Mouse")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];
                    if (foodInfo[0] == "Vegetable" || foodInfo[0] == "Fruit")
                    {
                        animal = new Mouse(name, weight, livingRegion);
                        animal.Eat(int.Parse(foodInfo[1]));
                        list.Add(animal);
                        Console.WriteLine(animal.MakeSound());
                    }
                    else
                    {
                        animal = new Mouse(name, weight, livingRegion);
                        list.Add(animal);
                        Console.WriteLine(animal.MakeSound());
                        Console.WriteLine($"{animal.GetType().Name} does not eat {foodInfo[0]}!");
                    }
                }
                else if (animalType == "Dog")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];
                    if (foodInfo[0] == "Meat")
                    {
                        animal = new Dog(name, weight, livingRegion);
                        animal.Eat(int.Parse(foodInfo[1]));
                        list.Add(animal);
                        Console.WriteLine(animal.MakeSound());
                    }
                    else
                    {
                        animal = new Dog(name, weight, livingRegion);
                        list.Add(animal);
                        Console.WriteLine(animal.MakeSound());
                        Console.WriteLine($"{animal.GetType().Name} does not eat {foodInfo[0]}!");
                    }
                }
                else if (animalType == "Cat")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    if (foodInfo[0] == "Meat" || foodInfo[0] == "Vegetable")
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                        animal.Eat(int.Parse(foodInfo[1]));
                        list.Add(animal);
                        Console.WriteLine(animal.MakeSound());
                    }
                    else
                    {
                        animal = new Cat(name, weight, livingRegion, breed);
                        list.Add(animal);
                        Console.WriteLine(animal.MakeSound());
                        Console.WriteLine($"{animal.GetType().Name} does not eat {foodInfo[0]}!");
                    }
                }
                else if (animalType == "Tiger")
                {
                    string name = animalInfo[1];
                    double weight = double.Parse(animalInfo[2]);
                    string livingRegion = animalInfo[3];
                    string breed = animalInfo[4];
                    if (foodInfo[0] == "Meat" )
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                        animal.Eat(int.Parse(foodInfo[1]));
                        list.Add(animal);
                        Console.WriteLine(animal.MakeSound());
                    }
                    else
                    {
                        animal = new Tiger(name, weight, livingRegion, breed);
                        list.Add(animal);
                        Console.WriteLine(animal.MakeSound());
                        Console.WriteLine($"{animal.GetType().Name} does not eat {foodInfo[0]}!");
                    }
                }
                input = Console.ReadLine();
            }
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
