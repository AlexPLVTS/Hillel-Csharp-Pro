using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_2._3
{
    public struct NumericSystems
    {
        private const int Binary = 2;
        private const int Octal = 8;
        private const int Hex = 16;
        private const string hexDigits = "0123456789ABCDEF";
        private int number;
        public int Number
        {
            get => number;
            set => number = value;
        }
        public string ToBinarySystem(int number)
        {
            if (number == 0) return "0";

            bool isNegative = number < 0;
            number = Math.Abs(number);

            string s = "";
            while (number > 0)
            {
                s += (number % Binary).ToString();
                number /= Binary;
            }

            string result = new string(s.Reverse().ToArray());
            return isNegative ? "-" + result : result;
        }
        public string ToOctalSystem(int number)
        {
            if (number == 0) return "0";

            bool isNegative = number < 0;
            number = Math.Abs(number);

            string s = "";
            while (number > 0)
            {
                s += number % Octal;
                number /= Octal;
            }
            string result = new string(s.Reverse().ToArray());
            return isNegative ? "-" + result : result;
        }
        public string ToHexSystem(int number)
        {
            if (number == 0) return "0";

            bool isNegative = number < 0;
            number = Math.Abs(number);

            string s = "";
            while (number > 0)
            {
                int r = number % Hex;
                s += hexDigits[r];
                number /= Hex;
            }
            string result = new string(s.Reverse().ToArray());
            return isNegative ? "-" + result : result;
        }
    }
}
