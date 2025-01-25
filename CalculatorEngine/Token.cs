using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace CalculatorEngine
{
    internal class Token
    {
        public readonly bool IsOperator;
        public readonly BigInteger? IntegerValue;
        public readonly OperatorType? OperatorValue;
        public Token(string s)
        {
            IsOperator = false;
            BigInteger value;
            if (BigInteger.TryParse(s, out value))
            {
                IntegerValue = value;
                OperatorValue = null;
            }
            else
            {
                IsOperator = true;
                OperatorValue = GetOperator(s);
                IntegerValue = null;
            }
        }
        private static OperatorType GetOperator(string s)
        {
            switch (s)
            {
                case "+":
                    return OperatorType.Add;
                case "-":
                    return OperatorType.Subtract;
                case "*":
                    return OperatorType.Multiply;
                case "%":
                    return OperatorType.Divide;
                case "/":
                    return OperatorType.Divide;
                case "(":
                    return OperatorType.OpenBracket;
                case ")":
                    return OperatorType.CloseBracket;
                case "!":
                    return OperatorType.Factorial;
                default:
                    throw new Exception($"Unrecognized operator type {s}");
            };
        }
    }
    internal enum OperatorType
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        Factorial,
        OpenBracket,
        CloseBracket
    }
}
