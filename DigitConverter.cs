using System;
using System.Collections.Generic;

namespace KataRomanNumerals
{
    public static class DigitConverter
    {
        private static readonly char[][] R =
        {
            new char[]{ 'I', 'V', 'X' },
            new char[]{ 'X', 'L', 'C' },
            new char[]{ 'C', 'D', 'M' },
            new char[]{ 'M', 'v', 'x' },
            new char[]{ 'x', 'l', 'c' },
            new char[]{ 'c', 'd' ,'m' }
        };

        /// <summary>Gets the respective Roman representation of a Digit in relation to its Row</summary>
        /// <param name="digit">Single Digit to be converted</param>
        /// <param name="pos">Location of the digit in the number</param>
        /// <returns>Roman representation of the digit</returns>
        public static string DigitToNumeral(int digit, int pos)
        {
            if (pos > R.Length) 
                throw new ArgumentException("Row too big");

            string output = string.Empty;
            if (digit == 9) return $"{R[pos][0]}{R[pos][2]}";
            if (digit == 4) return $"{R[pos][0]}{R[pos][1]}";
            if (digit >= 5)
            {
                output += R[pos][1];
                digit -= 5;
            }
            while (digit != 0)
            {
                output += R[pos][0];
                digit--;
            }
            return output;
        }

        /// <summary>Gets the Numeric value of a roman Numeral</summary>
        /// <param name="letter">A single roman Numeral</param>
        public static int NumeralToDigit(char letter)
        {
            int t = 0;
            for (int i = 0; i < R.Length; i++)
            {
                int p = Array.IndexOf(R[i], letter);
                switch (p)
                {
                    case 0: t = 1; break;
                    case 1: t = 5; break;
                    case 2: t = 10; break;
                }
                if (i > 0) t *= (int)Math.Pow(10, i);

                if (t != 0) return t;
            }

            throw new ArgumentException($"Letter \"{letter}\" not recognized");
        }

        /// <summary>Splits a decimal Number into its single digits</summary>
        /// <returns>int[] with all the digits</returns>
        public static int[] SplitDigits(int number)
        {
            List<int> output = new List<int>();
            int remainer = number;
            do
            {
                output.Add(remainer % 10);
                remainer /= 10;
            }
            while (remainer != 0);
            return output.ToArray();
        }

    }
}
