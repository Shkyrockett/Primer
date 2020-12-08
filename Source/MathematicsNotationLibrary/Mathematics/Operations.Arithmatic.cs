// <copyright file="Operations.Arithmatics.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Operations
    {
        #region Random
        /// <summary>
        /// Initialize random number generator with seed based on time.
        /// </summary>
        [ThreadStatic]
        public static readonly Random RandomNumberGenerator = new((int)DateTime.Now.Ticks & 0x0000FFFF);

        /// <summary>
        /// The random.
        /// </summary>
        /// <param name="Lower">The Lower.</param>
        /// <param name="Upper">The Upper.</param>
        /// <returns>The <see cref="double"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Random(this double Lower, double Upper) => (RandomNumberGenerator.Next() * (Upper - Lower + 1)) + Lower;
        #endregion Random

        /// <summary>
        /// Rounds the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        public static double Round(double number, int accuracy) => accuracy < 15 ? Math.Round(number, accuracy) : number;

        /// <summary>
        /// Rounds to mixed fraction.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/52912881
        /// </acknowledgment>
        public static (int whole, int numerator, int denominator) RoundToMixedFraction(float input, int accuracy)
        {
            var whole = (int)Math.Truncate(input);
            var numerator = 0;
            var denominator = 1;
            var fraction = Math.Abs(input - whole);
            if (fraction == 0) return (whole, numerator, denominator);
            var precision = 1f / accuracy;
            var n = Enumerable.Range(0, accuracy + 1).SkipWhile(e => (e * precision) < fraction).First();
            var hi = n * precision;
            var lo = (n - 1) * precision;
            if ((fraction - lo) < (hi - fraction)) n--;
            if (n == accuracy) return (++whole, numerator, denominator);
            var gcd = GCD(n, accuracy);
            numerator = n / gcd;
            denominator = accuracy / gcd;
            return (whole, numerator, denominator);
        }

        /// <summary>
        /// Rounds to mixed fraction.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/52912881
        /// </acknowledgment>
        public static (int whole, int numerator, int denominator) RoundToMixedFraction(double input, int accuracy)
        {
            var whole = (int)Math.Truncate(input);
            var numerator = 0;
            var denominator = 1;
            var fraction = Math.Abs(input - whole);
            if (fraction == 0) return (whole, numerator, denominator);
            var precision = 1d / accuracy;
            var n = Enumerable.Range(0, accuracy + 1).SkipWhile(e => (e * precision) < fraction).First();
            var hi = n * precision;
            var lo = (n - 1) * precision;
            if ((fraction - lo) < (hi - fraction)) n--;
            if (n == accuracy) return (++whole, numerator, denominator);
            var gcd = GCD(n, accuracy);
            numerator = n / gcd;
            denominator = accuracy / gcd;
            return (whole, numerator, denominator);
        }

        /// <summary>
        /// Propers to improper fraction.
        /// </summary>
        /// <param name="tuple">The tuple.</param>
        /// <returns></returns>
        public static (int whole, int numerator, int denominator) ProperToImproperFraction((int whole, int numerator, int denominator) tuple) => ProperToImproperFraction(tuple.whole, tuple.numerator, tuple.denominator);

        /// <summary>
        /// Converts a mixed rational fraction to an improper fraction.
        /// </summary>
        /// <param name="whole">The whole portion.</param>
        /// <param name="numerator">The numerator portion.</param>
        /// <param name="denominator">The denominator portion.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/NaviteKepler11/MixedNumberCalculator
        /// </acknowledgment>
        public static (int whole, int numerator, int denominator) ProperToImproperFraction(int whole, int numerator, int denominator) => (0, numerator + (whole * denominator), denominator);

        /// <summary>
        /// Converts an improper rational fraction to a proper mixed fraction.
        /// </summary>
        /// <param name="whole">The whole portion.</param>
        /// <param name="numerator">The numerator portion.</param>
        /// <param name="denominator">The denominator portion.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/NaviteKepler11/MixedNumberCalculator
        /// </acknowledgment>
        public static (int whole, int numerator, int denominator) ImproperToProperFraction(int numerator, int denominator)
        {
            var w = (int)((double)numerator / denominator);
            return (w, numerator - (w * denominator), denominator);
        }

        /// <summary>
        /// Simplifies the specified mixed rational fraction.
        /// </summary>
        /// <param name="whole">The whole portion.</param>
        /// <param name="numerator">The numerator portion.</param>
        /// <param name="denominator">The denominator portion.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/NaviteKepler11/MixedNumberCalculator
        /// </acknowledgment>
        public static (int whole, int numerator, int denominator) Simplify(int whole, int numerator, int denominator)
        {
            (_, var num, var den) = ProperToImproperFraction(whole, numerator, denominator);
            var gcd = GCD(num, den);
            num /= gcd;
            den /= gcd;
            var w = (int)((double)num / den);
            num %= num;
            den = (num == 0) ? 1 : den;
            return (w, num, den);
        }

        /// <summary>
        /// Return the greatest common divisor (GCD) of a and b.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="long"/>.</returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/08/calculate-the-greatest-common-divisor-gcd-and-least-common-multiple-lcm-of-two-integers-in-c/
        /// </acknowledgment>
        public static int GCD(int a, int b)
        {
            int remainder;

            // Pull out remainders.
            for (; ; )
            {
                remainder = a % b;
                if (remainder == 0)
                {
                    break;
                }

                a = b;
                b = remainder;
            }

            return b;
        }

        /// <summary>
        /// Return the greatest common divisor (GCD) of a and b.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="long"/>.</returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/08/calculate-the-greatest-common-divisor-gcd-and-least-common-multiple-lcm-of-two-integers-in-c/
        /// </acknowledgment>
        public static float GCD(float a, float b)
        {
            float remainder;

            // Pull out remainders.
            for (; ; )
            {
                remainder = a % b;
                if (remainder == 0)
                {
                    break;
                }

                a = b;
                b = remainder;
            }

            return b;
        }

        /// <summary>
        /// Return the greatest common divisor (GCD) of a and b.
        /// </summary>
        /// <param name="a">The a.</param>
        /// <param name="b">The b.</param>
        /// <returns>The <see cref="long"/>.</returns>
        /// <acknowledgment>
        /// http://csharphelper.com/blog/2014/08/calculate-the-greatest-common-divisor-gcd-and-least-common-multiple-lcm-of-two-integers-in-c/
        /// </acknowledgment>
        public static double GCD(double a, double b)
        {
            double remainder;

            // Pull out remainders.
            for (; ; )
            {
                remainder = a % b;
                if (remainder == 0)
                {
                    break;
                }

                a = b;
                b = remainder;
            }

            return b;
        }

        /// <summary>
        /// Multiplies the specified numerator and denominator by a denominator divisor.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/NaviteKepler11/MixedNumberCalculator
        /// </acknowledgment>
        public static (int numerator, int denominator) MultiplyByDenominator(int numerator, int denominator, int divisor)
        {
            denominator *= divisor;
            numerator *= divisor;
            return (numerator, denominator);
        }
    }
}
