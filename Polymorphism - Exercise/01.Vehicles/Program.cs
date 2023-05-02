using System;

namespace _01.Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (commands[1] == "Car")
                {
                    if (commands[0] == "Drive")
                    {
                        car.Drive(double.Parse(commands[2]));
                    }
                    else if (commands[0] == "Refuel")
                    {
                        car.Refuel(double.Parse(commands[2]));
                    }
                    
                }
                else if(commands[1] == "Truck")
                {
                    if (commands[0] == "Drive")
                    {
                        truck.Drive(double.Parse(commands[2]));
                    }
                    else if (commands[0] == "Refuel")
                    {
                        truck.Refuel(double.Parse(commands[2]));
                    }
                }
            }
            Console.WriteLine($"Car: { car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: { truck.FuelQuantity:f2}");
        }
    }
}
