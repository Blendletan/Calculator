using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CalculatorEngine
{
    internal class Parser
    {
        public static List<Token>? Parse(List<Token> inputTokens)
        {
            var output = new List<Token>();
            var operatorStack = new Stack<Token>();
            foreach (var nextToken in inputTokens)
            {
                if (nextToken.IsOperator == false)
                {
                    output.Add(nextToken);
                    continue;
                }
                if (nextToken.OperatorValue == null)
                {
                    throw new Exception("Invalid token: declarted as operator but has no operator type");
                }
                OperatorType nextOperator = nextToken.OperatorValue.Value;
                if (nextOperator == OperatorType.Factorial)
                {
                    output.Add(nextToken);
                    continue;
                }
                if (nextOperator == OperatorType.Add || nextOperator == OperatorType.Subtract)
                {
                    while (operatorStack.Count != 0)
                    {
                        Token topOfStack = operatorStack.Peek();
                        if (topOfStack.OperatorValue == null)
                        {
                            throw new Exception("Invalid token: declarted as operator but has no operator type");
                        }
                        if (topOfStack.OperatorValue.Value == OperatorType.OpenBracket)
                        {
                            break;
                        }
                        output.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(nextToken);
                }
                if (nextOperator == OperatorType.Multiply || nextOperator == OperatorType.Divide)
                {
                    while (operatorStack.Count != 0)
                    {
                        Token topOfStack = operatorStack.Peek();
                        if (topOfStack.OperatorValue == null)
                        {
                            throw new Exception("Invalid token: declarted as operator but has no operator type");
                        }
                        if (topOfStack.OperatorValue.Value == OperatorType.OpenBracket)
                        {
                            break;
                        }
                        if (topOfStack.OperatorValue.Value == OperatorType.Add)
                        {
                            break;
                        }
                        if (topOfStack.OperatorValue.Value == OperatorType.Subtract)
                        {
                            break;
                        }
                        output.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(nextToken);
                }
                if (nextOperator == OperatorType.OpenBracket)
                {
                    operatorStack.Push(nextToken);
                }
                if (nextOperator == OperatorType.CloseBracket)
                {
                    while (true)
                    {
                        if (operatorStack.Count == 0)
                        {
                            return null;
                        }
                        var topOfStack = operatorStack.Pop();
                        if (topOfStack.OperatorValue == OperatorType.OpenBracket)
                        {
                            break;
                        }
                        output.Add(topOfStack);
                    }
                }
            }
            while (operatorStack.Count != 0)
            {
                output.Add(operatorStack.Pop());
            }
            return output;
        }
    }
}
