using System;
using System.Collections.Generic;

namespace _02.EnterNumbers
{

    public class Program
    {

        public static void Main()
        {
            List<int> list = new List<int>();
            int start = 1;
            int end = 100;
            while (list.Count < 10)
            {
                try
                {
                    start = ReadNumber(start, end);
                    list.Add(start);
                }
                catch (ArgumentException exc)
                {
                    Console.WriteLine(exc.Message);
                }
                catch (FormatException exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            Console.WriteLine(string.Join(", ",list));
        }
        public static int ReadNumber(int start, int end)
        {
            string number = Console.ReadLine();
            if (!int.TryParse(number, out int result))
            {
                throw new FormatException("Invalid Number!");
            }
            if (int.Parse(number) <= start || int.Parse(number) >= end)
            {
                throw new ArgumentException($"Your number is not in range { start } - 100!");
            }
            return int.Parse(number);
        }
    }
}
