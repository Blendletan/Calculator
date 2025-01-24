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
            string[] tokens = PadInput(input).Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            string[] reversePolishTokens = ShuntingYard(tokens);
            int x = EvaluateReversePolish(reversePolishTokens);
            Console.WriteLine(x);
            Console.WriteLine("Hello, World!");
        }
        static int EvaluateReversePolish(string[] tokens)
        {
            var myStack = new Stack<int>();
            foreach (var nextToken in tokens)
            {
                if (nextToken == "+" || nextToken == "-" || nextToken == "*" || nextToken == "/")
                {
                    int y = myStack.Pop();
                    int x = myStack.Pop();
                    int z;
                    if (nextToken == "+")
                    {
                        z = x + y;
                    }
                    else if (nextToken == "-")
                    {
                        z = x - y;
                    }
                    else if (nextToken == "*")
                    {
                        z = x * y;
                    }
                    else if (nextToken == "/")
                    {
                        z = x / y;
                    }
                    else
                    {
                        throw new Exception("invalid operand");
                    }
                    myStack.Push(z);
                }
                else if (nextToken == "!")
                {
                    int x = myStack.Pop();
                    int z = Factorial(x);
                    myStack.Push(z);
                }
                else
                {
                    int nextInt = int.Parse(nextToken);
                    myStack.Push(nextInt);
                }
            }
            return myStack.Pop();
        }
        static string[] ShuntingYard(string[] inputs)
        {
            var output = new List<string>();
            var operatorStack = new Stack<string>();
            foreach (string nextToken in inputs)
            {
                if (nextToken == "+" || nextToken == "-")
                {
                    while (operatorStack.Count != 0)
                    {
                        string topOfStack = operatorStack.Peek();
                        if (topOfStack == "(")
                        {
                            break;
                        }
                        output.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(nextToken);
                }
                else if (nextToken == "*" || nextToken == "/")
                {
                    while (operatorStack.Count != 0)
                    {
                        string topOfStack = operatorStack.Peek();
                        if (topOfStack == "(" || topOfStack == "+" || topOfStack == "-")
                        {
                            break;
                        }
                        output.Add(operatorStack.Pop());
                    }
                    operatorStack.Push(nextToken);
                }
                else if (nextToken == "(")
                {
                    operatorStack.Push(nextToken);
                }
                else if (nextToken == ")")
                {
                    while (operatorStack.Count != 0)
                    {
                        string topOfStack = operatorStack.Pop();
                        if (topOfStack == "(")
                        {
                            break;
                        }
                        output.Add(topOfStack);
                    }
                }
                else if (nextToken == "!")
                {
                    output.Add(nextToken);
                }
                else
                {
                    int nextInt = int.Parse(nextToken);
                    output.Add(nextInt.ToString());
                }
            }
            foreach (var v in operatorStack)
            {
                output.Add(v);
            }
            return output.ToArray();
        }
        static int Factorial(int x)
        {
            int output = 1;
            for (int i = 1; i <= x; i++)
            {
                output *= i;
            }
            return output;
        }
        static string PadInput(string input)
        {
            StringBuilder output = new StringBuilder();
            int length = input.Length;
            for (int i = 0; i < length - 1; i++)
            {
                char currentChar = input[i];
                output.Append(currentChar);
                if (Char.IsDigit(currentChar))
                {
                    char nextChar = input[i + 1];
                    if (Char.IsDigit(nextChar))
                    {
                        continue;
                    }
                }
                output.Append(" ");
            }
            output.Append(input[length - 1]);
            return output.ToString();
        }
    }
}
