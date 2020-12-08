// <copyright file="MixedRational.cs" company="Shkyrockett" >
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
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public struct MixedRational
        : IEquatable<MixedRational>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRational"/> struct.
        /// </summary>
        /// <param name="whole">The whole.</param>
        public MixedRational(int whole)
            : this(0, whole, 1)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRational"/> struct.
        /// </summary>
        /// <param name="b">The b.</param>
        public MixedRational(double value)
            : this(0, (int)(value / Operations.GCD(value, 1d)), 1)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRational"/> struct.
        /// </summary>
        /// <param name="whole">The whole.</param>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        public MixedRational((int whole, int numerator, int denominator) tuple)
            : this(tuple.whole, tuple.numerator, tuple.denominator)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MixedRational"/> struct.
        /// </summary>
        /// <param name="whole">The whole.</param>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        public MixedRational(int whole, int numerator, int denominator)
        {
            (Whole, Numerator, Denominator) = Operations.Simplify(whole, numerator, denominator == 0 ? 1 : denominator);
        }
        #endregion

        #region Deconstructors
        /// <summary>
        /// Deconstructs the specified whole.
        /// </summary>
        /// <param name="whole">The whole.</param>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        public void Deconstruct(out int numerator, out int denominator) => (_, numerator, denominator) = Operations.ProperToImproperFraction(Whole, Numerator, Denominator);

        /// <summary>
        /// Deconstructs the specified whole.
        /// </summary>
        /// <param name="whole">The whole.</param>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        public void Deconstruct(out int whole, out int numerator, out int denominator) => (whole, numerator, denominator) = (Whole, Numerator, Denominator);
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the whole portion of the rational number.
        /// </summary>
        /// <value>
        /// The whole portion of the number.
        /// </value>
        public int Whole { get; set; }

        /// <summary>
        /// Gets or sets the numerator of the fraction part of the number.
        /// </summary>
        /// <value>
        /// The numerator portion of the fraction.
        /// </value>
        public int Numerator { get; set; }

        /// <summary>
        /// Gets or sets the denominator of the fraction part of the number.
        /// </summary>
        /// <value>
        /// The denominator portion of the fraction.
        /// </value>
        public int Denominator { get; set; }
        #endregion

        #region Operators
        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MixedRational operator +(MixedRational a, MixedRational b) => Plus(a, b);

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MixedRational operator +(MixedRational a, double b) => a + new MixedRational(b);

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MixedRational operator +(double a, MixedRational b) => new MixedRational(a) + b;

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MixedRational operator -(MixedRational a, MixedRational b) => Minus(a, b);

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MixedRational operator -(MixedRational a, double b) => a - new MixedRational(b);

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MixedRational operator -(double a, MixedRational b) => new MixedRational(a) - b;

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MixedRational operator *(MixedRational a, MixedRational b) => Multiply(a, b);

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MixedRational operator *(MixedRational a, double b) => a * new MixedRational(b);

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MixedRational operator *(double a, MixedRational b) => new MixedRational(a) * b;

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MixedRational operator /(MixedRational a, MixedRational b) => Divide(a, b);

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MixedRational operator /(MixedRational a, double b) => a / new MixedRational(b);

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static MixedRational operator /(double a, MixedRational b) => new MixedRational(a) / b;

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(MixedRational left, MixedRational right) => left.Equals(right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(MixedRational left, MixedRational right) => !(left == right);

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator >(MixedRational a, MixedRational b) => a.GreaterThan(b);

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator >=(MixedRational a, MixedRational b) => !(a < b);

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator <(MixedRational a, MixedRational b) => a.LessThan(b);

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator <=(MixedRational a, MixedRational b) => !(a > b);

        /// <summary>
        /// Performs an implicit conversion from <see cref="MixedRational"/> to <see cref="System.Double"/>.
        /// </summary>
        /// <param name="rational">The rational.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator double(MixedRational rational)
        {
            (_, int num, int den) = Operations.ProperToImproperFraction(rational.Whole, rational.Numerator, rational.Denominator);
            return (double)num / den;
        }
        #endregion

        #region Operator backing methods
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <see langword="true" /> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj) => obj is MixedRational rational && Equals(rational);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(MixedRational other)
        {
            (var thisNumerator, var thisDenominator) = this;
            (var otherNumerator, var otherDenominator) = other;
            return thisNumerator == otherNumerator && thisDenominator == otherDenominator;
        }

        /// <summary>
        /// Greaters the than.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool GreaterThan(MixedRational b)
        {
            (var aNumerator, var aDenominator) = this;
            (var bNumerator, var bDenominator) = b;
            return (double)aNumerator * bNumerator > (double)bDenominator * aDenominator;
        }

        /// <summary>
        /// Lesses the than.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool LessThan(MixedRational b)
        {
            (var aNumerator, var aDenominator) = this;
            (var bNumerator, var bDenominator) = b;
            return (decimal)aNumerator * bDenominator < (decimal)bNumerator * aDenominator;
        }

        /// <summary>
        /// Adds the specified mixed rational fractions together.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MixedRational Plus(MixedRational n, MixedRational m)
        {
            (var nNumerator, var nDenominator) = n;
            (var mNumerator, var mDenominator) = m;
            return new(Operations.Simplify(0, nNumerator * mDenominator + mNumerator * nDenominator, nDenominator * mDenominator));
        }

        /// <summary>
        /// Subtracts the specified mixed rational fraction from the other.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MixedRational Minus(MixedRational n, MixedRational m)
        {
            (var nNumerator, var nDenominator) = n;
            (var mNumerator, var mDenominator) = m;
            return new(Operations.Simplify(0, n.Numerator - m.Numerator, n.Denominator));
        }

        /// <summary>
        /// Multiplies the specified mixed rational fractions together.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MixedRational Multiply(MixedRational n, MixedRational m)
        {
            (var nNumerator, var nDenominator) = n;
            (var mNumerator, var mDenominator) = m;
            return new MixedRational(Operations.Simplify(0, nNumerator * mNumerator, nDenominator * mDenominator));
        }

        /// <summary>
        /// Divides the specified mixed rational fraction by the other.
        /// </summary>
        /// <param name="n">The n.</param>
        /// <param name="m">The m.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MixedRational Divide(MixedRational n, MixedRational m)
        {
            (var nNumerator, var nDenominator) = n;
            (var mNumerator, var mDenominator) = m;
            var ndeno = n.Denominator;
            var mdeno = m.Denominator;
            (nNumerator, _) = Operations.MultiplyByDenominator(nNumerator, nDenominator, mdeno);
            (mNumerator, _) = Operations.MultiplyByDenominator(mNumerator, mDenominator, ndeno);
            return new MixedRational(Operations.Simplify(0, nNumerator, mNumerator));
        }
        #endregion

        /// <summary>
        /// Inverses this Fraction.
        /// </summary>
        /// <returns></returns>
        public MixedRational Inverse()
        {
            (var numerator, var denominator) = this;
            return new MixedRational(Operations.Simplify(0, denominator, numerator));
        }

        /// <summary>
        /// Checks the denominator zero.
        /// </summary>
        /// <param name="den">The den.</param>
        /// <exception cref="ArithmeticException">The denominator of any fraction cannot have the value zero</exception>
        private void ValidateDenominatorNotZero()
        {
            if (Denominator == 0) throw new ArithmeticException("The denominator of any fraction cannot have the value zero");
        }

        #region Standard Methods
        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode()
        {
            (var numerator, var denominator) = this;
            return HashCode.Combine(Whole, numerator, denominator);
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (this == null) return nameof(MixedRational);
            return $"{(Whole == 0 ? string.Empty : $"{Whole} ")}{Numerator}/{Denominator}";
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(IFormatProvider formatProvider) => ToString("R" /* format string */, formatProvider);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Gets the debugger display.
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string GetDebuggerDisplay() => ToString();
        #endregion
    }
}
