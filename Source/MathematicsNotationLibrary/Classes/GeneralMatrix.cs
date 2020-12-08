// <copyright file="GeneralMatrix.cs" company="Shkyrockett" >
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using static MathematicsNotationLibrary.Operations;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class GeneralMatrix
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralMatrix" /> struct.
        /// </summary>
        /// <param name="values">The values.</param>
        public GeneralMatrix(double[,] values)
        {
            Values = values;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralMatrix" /> struct.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        public GeneralMatrix(int rows, int columns)
        {
            Values = new double[rows, columns];
        }
        #endregion

        #region Indexers
        /// <summary>
        /// Gets or sets the <see cref="double"/> with the specified index1.
        /// </summary>
        /// <value>
        /// The <see cref="double"/>.
        /// </value>
        /// <param name="index1">The index1.</param>
        /// <param name="index2">The index2.</param>
        /// <returns></returns>
        public double this[int index1, int index2]
        {
            get => Values[index1, index2];
            set => Values[index1, index2] = value;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        public double[,] Values { get; set; }

        /// <summary>
        /// Gets the rows.
        /// </summary>
        /// <value>
        /// The rows.
        /// </value>
        public int Rows => Values.GetLength(0);

        /// <summary>
        /// Gets the columns.
        /// </summary>
        /// <value>
        /// The columns.
        /// </value>
        public int Columns => Values.GetLength(1);

        /// <summary>
        /// Gets a value indicating whether this instance is square.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is square; otherwise, <see langword="false" />.
        /// </value>
        public bool IsSquare => IsSquareMatrix(Values);

        /// <summary>
        /// Gets a value indicating whether this instance is identity.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is identity; otherwise, <see langword="false" />.
        /// </value>
        public bool IsIdentity => IsIdentity(Values);

        /// <summary>
        /// Gets a value indicating whether this instance is a lower matrix.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is lower; otherwise, <see langword="false" />.
        /// </value>
        public bool IsLower => IsLowerMatrix(Values);

        /// <summary>
        /// Gets a value indicating whether this instance is an upper matrix.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is upper; otherwise, <see langword="false" />.
        /// </value>
        public bool IsUpper => IsUpperMatrix(Values);

        /// <summary>
        /// The determinant
        /// </summary>
        public double Determinant => Operations.Determinant(Values);

        /// <summary>
        /// Gets the inverse determinant.
        /// </summary>
        /// <value>
        /// The inverse determinant.
        /// </value>
        public double InverseDeterminant => Operations.Determinant(Inverse_Broken(Values));

        /// <summary>
        /// Gets the transpose.
        /// </summary>
        /// <value>
        /// The transpose.
        /// </value>
        public GeneralMatrix Transpose => Operations.Transpose(Values);

        /// <summary>
        /// Gets the inverse.
        /// </summary>
        /// <value>
        /// The inverse.
        /// </value>
        public GeneralMatrix Inverse => Inverse_Broken(Values);

        /// <summary>
        /// Gets the adjoint.
        /// </summary>
        /// <value>
        /// The adjoint.
        /// </value>
        public GeneralMatrix Adjoint => Operations.Adjoint(Values);

        /// <summary>
        /// Gets the cofactor.
        /// </summary>
        /// <value>
        /// The cofactor.
        /// </value>
        public GeneralMatrix Cofactor => Operations.Cofactor(Values);

        /// <summary>
        /// Gets the decompose.
        /// </summary>
        /// <value>
        /// The decompose.
        /// </value>
        public (GeneralMatrix Lower, GeneralMatrix Upper) Decompose => DecomposeToLowerUpper(Values);
        #endregion

        #region Operators
        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static GeneralMatrix operator +(GeneralMatrix value) => Plus(value);

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <param name="addend">The addend.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static GeneralMatrix operator +(GeneralMatrix augend, GeneralMatrix addend) => Add(augend, addend);

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static GeneralMatrix operator -(GeneralMatrix value) => Negate(value);

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="minuend">The minuend.</param>
        /// <param name="subend">The subend.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static GeneralMatrix operator -(GeneralMatrix minuend, GeneralMatrix subend) => Subtract(minuend, subend);

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static GeneralMatrix operator *(GeneralMatrix multiplicand, double multiplier) => Scale(multiplicand, multiplier);

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static GeneralMatrix operator *(double multiplicand, GeneralMatrix multiplier) => Scale(multiplicand, multiplier);

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static GeneralVector operator *(GeneralMatrix multiplicand, GeneralVector multiplier) => Multiply(multiplicand, multiplier);

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static GeneralVector operator *(GeneralVector multiplicand, GeneralMatrix multiplier) => Multiply(multiplier, multiplicand);

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static GeneralMatrix operator *(GeneralMatrix multiplicand, GeneralMatrix multiplier) => Multiply(multiplicand, multiplier);

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(GeneralMatrix left, GeneralMatrix right) => left.Equals(right);

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(GeneralMatrix left, GeneralMatrix right) => !(left == right);

        /// <summary>
        /// Performs an implicit conversion from <see cref="Array" /> to <see cref="GeneralMatrix" />.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator GeneralMatrix(double[,] array) => ToMatrix(array);
        #endregion

        #region Operator Backing Methods
        /// <summary>
        /// Pluses the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GeneralMatrix Plus(GeneralMatrix value) => Operations.Plus(value.Values);

        /// <summary>
        /// Adds the specified augend.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <param name="addend">The addend.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GeneralMatrix Add(GeneralMatrix augend, GeneralMatrix addend) => Operations.Add(augend.Values, addend.Values);

        /// <summary>
        /// Negates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GeneralMatrix Negate(GeneralMatrix value) => Operations.Negate(value.Values);

        /// <summary>
        /// Subtracts the specified minuend.
        /// </summary>
        /// <param name="minuend">The minuend.</param>
        /// <param name="subend">The subend.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GeneralMatrix Subtract(GeneralMatrix minuend, GeneralMatrix subend) => Operations.Subtract(minuend.Values, subend.Values);

        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GeneralMatrix Scale(GeneralMatrix multiplicand, double multiplier) => Operations.Scale(multiplicand.Values, multiplier);

        /// <summary>
        /// Scales the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GeneralMatrix Scale(double multiplicand, GeneralMatrix multiplier) => Operations.Scale(multiplicand, multiplier.Values);

        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GeneralVector Multiply(GeneralMatrix multiplicand, GeneralVector multiplier) => Operations.Multiply(multiplicand.Values, multiplier.Values);

        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GeneralVector Multiply(GeneralVector multiplicand, GeneralMatrix multiplier) => Operations.Multiply(multiplicand.Values, multiplier.Values);

        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GeneralMatrix Multiply(GeneralMatrix multiplicand, GeneralMatrix multiplier) => Operations.Multiply(multiplicand.Values, multiplier.Values);

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <see langword="true" /> if the specified <see cref="object" /> is equal to this instance; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object? obj) => obj is GeneralMatrix matrix && Equals(matrix);

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(GeneralMatrix other) => other is GeneralMatrix matrix && EqualityComparer<double[,]>.Default.Equals(Values, matrix.Values);

        /// <summary>
        /// Converts to matrix.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static GeneralMatrix ToMatrix(double[,] array) => new(array);
        #endregion

        /// <summary>
        /// Dots the product.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        public double DotProduct(GeneralMatrix b) => Operations.DotProduct(Values, b.Values);

        /// <summary>
        /// Lerps the specified b.
        /// </summary>
        /// <param name="b">The b.</param>
        /// <param name="t">The t.</param>
        /// <returns></returns>
        public GeneralMatrix Lerp(GeneralMatrix b, double t) => Operations.Lerp(Values, b.Values, t);

        #region Standard Methods
        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => HashCode.Combine(Values);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => ToString("R" /* format string */, CultureInfo.InvariantCulture /* format provider */);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public string ToString(IFormatProvider formatProvider) => ToString("R" /* format string */, formatProvider);

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var sb = new StringBuilder();
            sb.Append('{');
            for (var i = 0; i < Rows; i++)
            {
                sb.Append('{');
                for (var j = 0; j < Columns; j++)
                {
                    sb.Append($"{Values[i, j].ToString(format, formatProvider)},\t");
                }

                sb.Append("},");
            }

            sb.Append('}');

            return sb.ToString();
        }

        /// <summary>
        /// Gets the debugger display.
        /// </summary>
        /// <returns></returns>
        private string GetDebuggerDisplay() => ToString();
        #endregion
    }
}
