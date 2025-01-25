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
        public static BigInteger Factorial(BigInteger input)
        {
            BigInteger output = 1;
            for (BigInteger i = 1; i <= input; i++)
            {
                output *= i;
            }
            return output;
        }
        public static BigInteger? Evaluate(List<Token> input)
        {
            Stack<BigInteger> numberStack = new Stack<BigInteger>();
            foreach (var nextToken in input)
            {
                if (nextToken.IsOperator == false)
                {
                    if (nextToken.IntegerValue == null)
                    {
                        throw new Exception("Invalid token: declared as integer but has no integer value");
                    }
                    numberStack.Push(nextToken.IntegerValue.Value);
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
                    numberStack.Push(x + y);
                }
                else if (nextOperator == OperatorType.Subtract)
                {
                    numberStack.Push(x - y);
                }
                else if (nextOperator == OperatorType.Multiply)
                {
                    numberStack.Push(x * y);
                }
                else if (nextOperator == OperatorType.Divide)
                {
                    numberStack.Push(x / y);
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
