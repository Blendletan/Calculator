using CalculatorEngine;
using System.Numerics;
using System.Text;
namespace CalculatorConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Calculate();
            }
        }
        static string GetInput()
        {
            string? output = Console.ReadLine();
            while (output == null)
            {
                output = Console.ReadLine();
            }
            return output;
        }
        static void PrintOutput(BigRational output)
        {
            if (output.denominator == 1)
            {
                Console.WriteLine(output.numerator);
            }
            else
            {
                Console.WriteLine($"{output.numerator} / {output.denominator}");
            }
        }
        static void Calculate()
        {
            string input = GetInput();
            try
            {
                BigRational? output = Calculator.Calculate(input);
                if (output == null)
                {
                    Console.WriteLine("Error: invalid format");
                }
                else
                {
                    PrintOutput(output);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
