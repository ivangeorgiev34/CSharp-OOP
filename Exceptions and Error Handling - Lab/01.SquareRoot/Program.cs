using System;

namespace _01.SquareRoot
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double number = double.Parse(Console.ReadLine());
                double result = Math.Sqrt(number);
                if (double.IsNaN(result))
                {
                    throw new ArithmeticException("Invalid number.");
                }
                Console.WriteLine(result);
            }
            catch (ArithmeticException exc)
            {
                Console.WriteLine(exc.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
