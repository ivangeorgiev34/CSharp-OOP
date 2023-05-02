using System;

namespace _02.Vehicles
{
  public class StratUp
{
    static void Main(string[] args)
    {
        string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        string[] busInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
        Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
        Bus bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
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
            else if (commands[1] == "Truck")
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
            else if (commands[1] == "Bus")
            {
                if (commands[0] == "Drive")
                {
                    bus.Drive(double.Parse(commands[2]));
                }
                else if (commands[0] == "DriveEmpty")
                {
                    bus.DriveEmpty(double.Parse(commands[2]));
                }
                else if (commands[0] == "Refuel")
                {
                    bus.Refuel(double.Parse(commands[2]));
                }
            }
        }
        Console.WriteLine($"Car: { car.FuelQuantity:f2}");
        Console.WriteLine($"Truck: { truck.FuelQuantity:f2}");
        Console.WriteLine($"Bus: { bus.FuelQuantity:f2}");
    }
}

}
