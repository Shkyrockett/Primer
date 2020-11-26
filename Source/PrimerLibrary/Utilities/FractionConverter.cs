using System;

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
            var value = pvalue;

            if (!skipRounding)
                value = DecimalRound(pvalue, decimalPlaces);

            if (value == Math.Round(value, 0)) // Whole number check.
                return (1, 1);

            // Get the whole value of the fraction
            var mWhole = MathF.Truncate(value);

            // Get the fractional value.
            var mFraction = value - mWhole;

            // Initialize a numerator and denominator.
            var mNumerator = 0u;
            var mDenomenator = 1u;

            // Ensure that there is actual a fraction.
            if (mFraction > 0f)
            {
                // Convert the value to a string so that you can count the number of decimal places there are.
                var strFraction = mFraction.ToString().Remove(0, 2);

                // Store the number of decimal places.
                var intFractLength = (uint)strFraction.Length;

                // Set the numerator to have the proper amount of zeros.
                mNumerator = (uint)Math.Pow(10, intFractLength);

                // Parse the fraction value to an integer that equals [fraction value] * 10^[number of decimal places].
                _ = uint.TryParse(strFraction, out mDenomenator);

                // Get the greatest common divisor for both numbers.
                var gcd = GreatestCommonDivisor(mDenomenator, mNumerator);

                // Divide the numerator and the denominator by the greatest common divisor/
                mNumerator /= gcd;
                mDenomenator /= gcd;
            }

            return ((int)mNumerator, (int)mDenomenator);
        }

        /// <summary>
        /// Greatest the common divisor.
        /// </summary>
        /// <param name="valA">The value a.</param>
        /// <param name="valB">The value b.</param>
        /// <returns></returns>
        private static uint GreatestCommonDivisor(uint valA, uint valB)
        {
            if (valA == 0 && valB == 0)
            {
                // Return 0 if both values are 0 (no GSD).
                return 0;
            }
            else if (valA == 0 && valB != 0)
            {
                // Return value b if only a == 0.
                return valB;
            }
            else if (valA != 0 && valB == 0)
            {
                // Return value a if only b == 0.
                return valA;
            }
            else
            {
                // Actually find the GSD.
                var first = valA;
                var second = valB;

                while (first != second)
                {
                    if (first > second)
                    {
                        first -= second;
                    }
                    else
                    {
                        second -= first;
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
            var (_, denomenator) = ConvertToFraction(places, true);
            var d = MathF.Round(val * denomenator);
            return d / denomenator;
        }
    }
}
