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
        public readonly BigRational? IntegerValue;
        public readonly OperatorType? OperatorValue;
        public Token(string s)
        {
            IsOperator = true;
            IntegerValue = null;
            OperatorValue = GetOperator(s);
            if (OperatorValue == null)
            {
                IsOperator = false;
                IntegerValue = new BigRational(s);
            }
        }
        private static OperatorType? GetOperator(string s)
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
                    return null;
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
