using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PlayCatch
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int exceptionsCount = 0;

            while (exceptionsCount < 3)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (command[0] == "Replace")
                    {
                        int index = int.Parse(command[1]);
                        int element = int.Parse(command[2]);
                        input[index] = element;
                    }
                    else if (command[0] == "Print")
                    {
                        int startIndex = int.Parse(command[1]);
                        int endIndex = int.Parse(command[2]);
                        List<int> list = new List<int>();
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            list.Add(input[i]);
                        }
                        Console.WriteLine(string.Join(", ",list));
                    }
                    else if (command[0] == "Show")
                    {
                        int index = int.Parse(command[1]);
                        Console.WriteLine(input[index]);
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The index does not exist!");
                    exceptionsCount++;
                }
                catch(FormatException)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    exceptionsCount++;
                }
            }
            Console.WriteLine(string.Join(", ",input));
        }
    }
}
