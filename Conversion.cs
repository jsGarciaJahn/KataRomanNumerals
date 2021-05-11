using System;

namespace KataRomanNumerals
{
    public static class Conversion
    {
        /// <summary>Converts a Decimal Number to a Roman Numeral</summary>
        /// <exception cref="ArgumentException">Thrown when a Number is greater than 99999</exception>
        public static string ToRoman(int number)
        {
            if (number > 999999) throw new ArgumentException($"Number {number} is too big");
            string output = string.Empty;
            int[] digits = DigitConverter.SplitDigits(number);

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int digit = digits[i];
                output += DigitConverter.DigitToNumeral(digit, i);
            }

            return output;
        }

        /// <summary>Converts a Roman Numeral to its decimal representation</summary>
        /// <exception cref="ArgumentException">Thrown when an illegal number is detected</exception>
        public static int ToDecimal(string numeral)
        {
            int output = 0;
            for (int i = 0; i < numeral.Length; i++)
            {
                int tmp = DigitConverter.NumeralToDigit(numeral[i]);
                if (i < numeral.Length - 1)
                {
                    int next = DigitConverter.NumeralToDigit(numeral[i + 1]);
                    if (next > tmp)
                    {
                        if (!(tmp == next / 5 || tmp == next / 10))
                            throw new ArgumentException($"Number {numeral} is illegal!");

                        output += next - tmp;
                        i++;
                        continue;
                    }
                }
                output += tmp;
            }

            return output;
        }


    }
}
