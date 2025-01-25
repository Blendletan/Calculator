using System.Numerics;
using System.Text;
namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? input = Console.ReadLine();
            while (input == null)
            {
                input = Console.ReadLine();
            }
            BigInteger? output = CalculatorEngine.Calculator.Calculate(input);
            if (output == null)
            {
                Console.WriteLine("Error, invalid format");
            }
            else
            {
                Console.WriteLine(output);
            }
        }
    }
}
