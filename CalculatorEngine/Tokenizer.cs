using System.Text;
namespace CalculatorEngine
{
    internal class Tokenizer
    {
        public static List<Token>? Tokenize(string input)
        {
            List<Token> output = new List<Token>();
            StringBuilder nextTokenString = new StringBuilder();
            int length = input.Length;
            for (int i = 0; i < length; i++)
            {
                char currentChar = input[i];
                if (char.IsWhiteSpace(currentChar))
                {
                    continue;
                }
                else if (char.IsDigit(currentChar))
                {
                    nextTokenString.Append(currentChar);
                }
                else if (IsOperator(currentChar))
                {
                    if (nextTokenString.Length != 0)
                    {
                        var previousToken = new Token(nextTokenString.ToString());
                        output.Add(previousToken);
                        nextTokenString.Clear();
                    }
                    var nextToken = new Token(currentChar.ToString());
                    output.Add(nextToken);
                }
            }
            if (nextTokenString.Length != 0)
            {
                var nextToken = new Token(nextTokenString.ToString());
                output.Add(nextToken);
            }
            return output;
        }
        private static bool IsOperator(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '*' || c == '!' || c == '(' || c == ')')
            {
                return true;
            }
            return false;
        }
    }
}
