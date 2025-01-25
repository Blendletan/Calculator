﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
namespace CalculatorEngine
{
    public class Calculator
    {
        public static BigInteger? Calculate(string input)
        {
            List<Token>? tokens = Tokenizer.Tokenize(input);
            if (tokens == null)
            {
                return null;
            }
            List<Token>? reversePolishTokens = Parser.Parse(tokens);
            if (reversePolishTokens == null)
            {
                return null;
            }
            BigInteger? output = Processor.Evaluate(reversePolishTokens);
            return output;
        }
    }
}
