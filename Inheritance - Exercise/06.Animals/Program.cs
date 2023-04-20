using System;
using System.Collections.Generic;

namespace Animals
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            
            List<Animal> list = new List<Animal>();
            string input = Console.ReadLine();
            while (input!="Beast!")
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string gender = string.Empty;
                //if (tokens.Length > 2)
                //{
                //    gender = tokens[2];
                //}
                switch (input)
                {
                    //case "Animal":
                    //    Animal animal = new Animal(tokens[0], int.Parse(tokens[1]),gender);
                    //    list.Add(animal);
                    //    break;
                    case "Dog":
                        Dog dog = new Dog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        list.Add(dog);
                        break;
                    case "Frog":
                        Frog frog = new Frog(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        list.Add(frog);
                        break;
                    case "Cat":
                        Cat cat = new Cat(tokens[0], int.Parse(tokens[1]), tokens[2]);
                        list.Add(cat);
                        break;
                    case "Tomcat":
                        Tomcat tomcat = new Tomcat(tokens[0], int.Parse(tokens[1]));
                        list.Add(tomcat);
                        break;
                    case "Kitten":
                        Kitten kitten = new Kitten(tokens[0], int.Parse(tokens[1]));
                        list.Add(kitten);
                        break;
                    default:
                        throw new ArgumentException("Invalid input!");
                        
                }
                input = Console.ReadLine();
            }
            foreach (var item in list)
            {
                //string type = item.GetType().ToString();
                //type = type.Remove(0, 7);
                //Console.WriteLine($"{type}");
                //Console.WriteLine($"{item.Name} {item.Age} {item.Gender}");
                //item.ProduceSound();
                Console.WriteLine(item.ProduceSound());
            }
        }
    }
}
