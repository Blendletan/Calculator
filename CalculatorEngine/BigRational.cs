using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorEngine
{
    public class BigRational
    {
        public readonly BigInteger numerator;
        public readonly BigInteger denominator;
        public BigRational(BigInteger a, BigInteger b)
        {
            if (b == 0)
            {
                throw new Exception("Error: Fraction cannot have zero as a denominator");
            }
            var gcd = BigInteger.GreatestCommonDivisor(a, b);
            numerator = a / gcd;
            denominator = b / gcd;
        }
        public BigRational(string input)
        {
            int numberOfDecimals = CountChar(input, '.');
            if (numberOfDecimals == 0)
            {
                numerator = BigInteger.Parse(input);
                denominator = 1;
                return;
            }
            if (numberOfDecimals ==1)
            {
                string[] numeratorHalves = input.Split('.');
                BigInteger firstHalf = BigInteger.Parse(numeratorHalves[0]);
                BigInteger secondHalf = BigInteger.Parse(numeratorHalves[1]);
                denominator = BigInteger.Pow(10, Length(secondHalf));
                numerator = firstHalf * denominator + secondHalf;
                return;
            }
            throw new Exception($"Cannot parse integer \" {input} \" ");
        }
        private static int Length(BigInteger input)
        {
            return (int)BigInteger.Log10(input)+1;
        }
        private static int CountChar(string input, char c)
        {
            int output = 0;
            foreach (var v in input)
            {
                if (v == c)
                {
                    output++;
                }
            }
            return output;
        }

        public static BigRational Add(BigRational a, BigRational b)
        {
            BigInteger newNumerator = a.numerator * b.denominator + b.numerator * a.denominator;
            BigInteger newDenominator = a.denominator * b.denominator;
            return new BigRational(newNumerator, newDenominator);
        }
        public static BigRational Subtract(BigRational a, BigRational b)
        {
            BigInteger newNumerator = a.numerator * b.denominator - b.numerator * a.denominator;
            BigInteger newDenominator = a.denominator * b.denominator;
            return new BigRational(newNumerator, newDenominator);
        }
        public static BigRational Multiply(BigRational a, BigRational b)
        {
            BigInteger newNumerator = a.numerator * b.numerator;
            BigInteger newDenominator = a.denominator * b.denominator;
            return new BigRational(newNumerator, newDenominator);
        }
        public static BigRational Divide(BigRational a, BigRational b)
        {
            if (b.numerator == 0)
            {
                throw new Exception("Error: Attempted division by zero");
            }
            BigInteger newNumerator = a.numerator * b.denominator;
            BigInteger newDenominator = a.denominator * b.numerator;
            return new BigRational(newNumerator, newDenominator);
        }
    }
}
