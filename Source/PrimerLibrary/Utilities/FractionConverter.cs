using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerLibrary
{
    /// <summary>
    /// https://www.codeproject.com/Tips/623477/Convert-Decimal-to-Fraction-and-Vice-Versa-in-Csha
    /// </summary>
    public static class FractionConverter
    {
        /// <summary>
        /// Converts to fraction.
        /// </summary>
        /// <param name="pvalue">The pvalue.</param>
        /// <param name="skipRounding">if set to <see langword="true" /> [skip rounding].</param>
        /// <param name="decimalPlaces">The decimal places.</param>
        /// <returns></returns>
        public static (int numerator, int denomenator) ConvertToFraction(float pvalue, bool skipRounding = false, float decimalPlaces = 0.0625f)
        {
            float value = pvalue;

            if (!skipRounding)
                value = DecimalRound(pvalue, decimalPlaces);

            if (value == Math.Round(value, 0)) // whole number check
                return (1, 1);

            // get the whole value of the fraction
            float mWhole = MathF.Truncate(value);

            // get the fractional value
            float mFraction = value - mWhole;

            // initialize a numerator and denomintar
            uint mNumerator = 0;
            uint mDenomenator = 1;

            // ensure that there is actual a fraction
            if (mFraction > 0f)
            {
                // convert the value to a string so that
                // you can count the number of decimal places there are
                string strFraction = mFraction.ToString().Remove(0, 2);

                // store the number of decimal places
                uint intFractLength = (uint)strFraction.Length;

                // set the numerator to have the proper amount of zeros
                mNumerator = (uint)Math.Pow(10, intFractLength);

                // parse the fraction value to an integer that equals
                // [fraction value] * 10^[number of decimal places]
                uint.TryParse(strFraction, out mDenomenator);

                // get the greatest common divisor for both numbers
                uint gcd = GreatestCommonDivisor(mDenomenator, mNumerator);

                // divide the numerator and the denominator by the greatest common divisor
                mNumerator = mNumerator / gcd;
                mDenomenator = mDenomenator / gcd;
            }

            return ((int)mNumerator, (int)mDenomenator);
        }

        /// <summary>
        /// Greatests the common divisor.
        /// </summary>
        /// <param name="valA">The value a.</param>
        /// <param name="valB">The value b.</param>
        /// <returns></returns>
        private static uint GreatestCommonDivisor(uint valA, uint valB)
        {
            // return 0 if both values are 0 (no GSD)
            if (valA == 0 &&
              valB == 0)
            {
                return 0;
            }
            // return value b if only a == 0
            else if (valA == 0 &&
                  valB != 0)
            {
                return valB;
            }
            // return value a if only b == 0
            else if (valA != 0 && valB == 0)
            {
                return valA;
            }
            // actually find the GSD
            else
            {
                uint first = valA;
                uint second = valB;

                while (first != second)
                {
                    if (first > second)
                    {
                        first = first - second;
                    }
                    else
                    {
                        second = second - first;
                    }
                }

                return first;
            }

        }

        /// <summary>
        /// Rounds a number to the nearest decimal.
        /// For instance, carpenters do not want to see a number like 4/5.
        /// That means nothing to them
        /// and you'll have an angry carpenter on your hands
        /// if you ask them cut a 2x4 to 36 and 4/5 inches.
        /// So, we would want to convert to the nearest 1/16 of an inch.
        /// Example: DecimalRound(0.8, 0.0625) Rounds 4/5 to 13/16 or 0.8125.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="places">The places.</param>
        /// <returns></returns>
        private static float DecimalRound(float val, float places)
        {
            var sPlaces = ConvertToFraction(places, true);
            var d = MathF.Round(val * sPlaces.denomenator);
            return d / sPlaces.denomenator;
        }
    }
}
