// <copyright file="Operations.Fractions.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
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

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
public static partial class Operations
{
    #region Proper to Improper Fractions
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
    #endregion

    #region Improper to Proper Fractions
    /// <summary>
    /// Converts an improper rational fraction to a proper mixed fraction.
    /// </summary>
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
    #endregion

    #region Simplify Fraction
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
    #endregion

    #region Multiply Fraction by Denominator
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
    #endregion

    #region Rounding
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
        if (fraction == 0)
        {
            return (whole, numerator, denominator);
        }

        var precision = 1f / accuracy;
        var n = Enumerable.Range(0, accuracy + 1).SkipWhile(e => (e * precision) < fraction).First();
        var hi = n * precision;
        var lo = (n - 1) * precision;
        if ((fraction - lo) < (hi - fraction))
        {
            n--;
        }

        if (n == accuracy)
        {
            return (++whole, numerator, denominator);
        }

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
        if (fraction == 0)
        {
            return (whole, numerator, denominator);
        }

        var precision = 1d / accuracy;
        var n = Enumerable.Range(0, accuracy + 1).SkipWhile(e => (e * precision) < fraction).First();
        var hi = n * precision;
        var lo = (n - 1) * precision;
        if ((fraction - lo) < (hi - fraction))
        {
            n--;
        }

        if (n == accuracy)
        {
            return (++whole, numerator, denominator);
        }

        var gcd = GCD(n, accuracy);
        numerator = n / gcd;
        denominator = accuracy / gcd;
        return (whole, numerator, denominator);
    }
    #endregion
}
