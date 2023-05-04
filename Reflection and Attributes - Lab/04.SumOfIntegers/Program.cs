using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SumOfIntegers
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                
                try
                {
                    int number = int.Parse(input[i]);
                    stack.Push(number);

                }
                catch (OverflowException)
                {
                    Console.WriteLine($"The element '{input[i]}' is out of range!");
                }
                catch(FormatException)
                {
                    Console.WriteLine($"The element '{input[i]}' is in wrong format!");
                }
                finally
                {
                    Console.WriteLine($"Element '{input[i]}' processed - current sum: {stack.Sum()}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {stack.Sum()}");
        }
    }
}
