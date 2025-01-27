using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace CalculatorEngine
{
    internal class Processor
    {
        private static BigRational Factorial(BigRational input)
        {
            if (input.denominator == 1)
            {
                return new BigRational(Factorial(input.numerator),1);
            }
            throw new Exception($"Error: Cannot take factorial of the fraction {input.numerator} / {input.denominator}");
        }
        private static BigInteger Factorial(BigInteger input)
        {
            if (input < 0)
            {
                throw new Exception($"Cannot take the factorial of negative number {input}");
            }
            BigInteger output = 1;
            for (BigInteger i = 1; i <= input; i++)
            {
                output *= i;
            }
            return output;
        }
        public static BigRational? Evaluate(List<Token> input)
        {
            Stack<BigRational> numberStack = new Stack<BigRational>();
            foreach (var nextToken in input)
            {
                if (nextToken.IsOperator == false)
                {
                    if (nextToken.IntegerValue == null)
                    {
                        throw new Exception("Invalid token: declared as integer but has no integer value");
                    }
                    numberStack.Push(nextToken.IntegerValue);
                    continue;
                }
                if (nextToken.OperatorValue == null)
                {
                    throw new Exception("Invalid token: declarted as operator but has no operator type");
                }
                var nextOperator = nextToken.OperatorValue;
                if (nextOperator == OperatorType.Factorial)
                {
                    if (numberStack.Count < 1)
                    {
                        return null;
                    }
                    var inputNumber = numberStack.Pop();
                    var outputNumber = Factorial(inputNumber);
                    numberStack.Push(outputNumber);
                    continue;
                }
                if (numberStack.Count < 2)
                {
                    return null;
                }
                var y = numberStack.Pop();
                var x = numberStack.Pop();
                if (nextOperator == OperatorType.Add)
                {
                    numberStack.Push(BigRational.Add(x,y));
                }
                else if (nextOperator == OperatorType.Subtract)
                {
                    numberStack.Push(BigRational.Subtract(x,y));
                }
                else if (nextOperator == OperatorType.Multiply)
                {
                    numberStack.Push(BigRational.Multiply(x,y));
                }
                else if (nextOperator == OperatorType.Divide)
                {
                    numberStack.Push(BigRational.Divide(x,y));
                }
                else
                {
                    throw new Exception($"Invalid operator type {nextOperator.ToString}");
                }
            }
            if (numberStack.Count != 1)
            {
                return null;
            }
            return numberStack.Pop();
        }
    }
}
