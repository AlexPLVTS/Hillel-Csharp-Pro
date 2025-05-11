using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace HW_1._1
{
    public static class AdvancedCalculator
    {
        public static double Power(double baseValue, double exponent)
        {
            double result = Math.Pow(baseValue, exponent);
            if (double.IsInfinity(result))
            {
                throw new InvalidOperationException("Result is too large to handle.");
            }
            return result;
        }
        public static double NRoot(double baseNum, double rootNum) => Math.Pow(baseNum, 1.0 / rootNum);
        public static double Logarithm(double num) => Math.Log(num);

        public static BigInteger Factorial(int number)
        {
            if (number < 0)
                throw new ArgumentException("Factorial cannot be defined for negative numbers.");

            BigInteger result = BigInteger.One;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
        public static int DateDifference(DateTime date1, DateTime date2)
        {
            return Math.Abs((date1 - date2).Days);
        }
    }
}
