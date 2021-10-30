// <copyright file="GeneralMatrix.cs" company="Shkyrockett" >
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using static MathematicsNotationLibrary.Operations;

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class Matrix<T>
    : IEquatable<Matrix<T>>, IMatrix<T>
    where T : INumber<T>
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="Matrix{T}" /> struct.
    /// </summary>
    /// <param name="values">The values.</param>
    public Matrix(T[,] values)
    {
        Items = values;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Matrix{T}" /> struct.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    public Matrix(int rows, int columns)
    {
        Items = new T[rows, columns];
    }
    #endregion

    #region Indexers
    /// <summary>
    /// Gets or sets the value with the specified index1.
    /// </summary>
    /// <value>
    /// The value.
    /// </value>
    /// <param name="index1">The index1.</param>
    /// <param name="index2">The index2.</param>
    /// <returns></returns>
    public T this[int index1, int index2]
    {
        get => Items[index1, index2];
        set => Items[index1, index2] = value;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the values.
    /// </summary>
    /// <value>
    /// The values.
    /// </value>
    public T[,] Items { get; set; }

    /// <summary>
    /// Gets the rows.
    /// </summary>
    /// <value>
    /// The rows.
    /// </value>
    public int Rows => Items.GetLength(0);

    /// <summary>
    /// Gets the columns.
    /// </summary>
    /// <value>
    /// The columns.
    /// </value>
    public int Columns => Items.GetLength(1);

    /// <summary>
    /// Gets a value indicating whether this instance is square.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if this instance is square; otherwise, <see langword="false" />.
    /// </value>
    public bool IsSquare => IsSquareMatrix<T>(Items);

    /// <summary>
    /// Gets a value indicating whether this instance is identity.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if this instance is identity; otherwise, <see langword="false" />.
    /// </value>
    public bool IsMultiplicativeIdentity => IsMultiplicativeIdentity<T>(Items);

    /// <summary>
    /// Gets a value indicating whether this instance is a lower matrix.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if this instance is lower; otherwise, <see langword="false" />.
    /// </value>
    public bool IsLower => IsLowerMatrix<T>(Items);

    /// <summary>
    /// Gets a value indicating whether this instance is an upper matrix.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if this instance is upper; otherwise, <see langword="false" />.
    /// </value>
    public bool IsUpper => IsUpperMatrix<T>(Items);

    /// <summary>
    /// The determinant
    /// </summary>
    public T Determinant => Determinant<T>(Items);

    /// <summary>
    /// Gets the inverse determinant.
    /// </summary>
    /// <value>
    /// The inverse determinant.
    /// </value>
    public T InverseDeterminant => Determinant<T>(Inverse2<T>(Items));

    /// <summary>
    /// Gets the transpose.
    /// </summary>
    /// <value>
    /// The transpose.
    /// </value>
    public Matrix<T> Transpose => Transpose<T>(Items);

    /// <summary>
    /// Gets the inverse.
    /// </summary>
    /// <value>
    /// The inverse.
    /// </value>
    public Matrix<T> Inverse => Inverse2<T>(Items);

    /// <summary>
    /// Gets the adjoint.
    /// </summary>
    /// <value>
    /// The adjoint.
    /// </value>
    public Matrix<T> Adjoint => Adjoint<T>(Items);

    /// <summary>
    /// Gets the cofactor.
    /// </summary>
    /// <value>
    /// The cofactor.
    /// </value>
    public Matrix<T> Cofactor => Cofactor<T>(Items);

    /// <summary>
    /// Gets the decompose.
    /// </summary>
    /// <value>
    /// The decompose.
    /// </value>
    public (Matrix<T> Lower, Matrix<T> Upper) Decompose => DecomposeToLowerUpper<T>(Items);
    #endregion

    #region Operators
    /// <summary>
    /// Implements the operator +.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static Matrix<T> operator +(Matrix<T> value) => Plus(value);

    /// <summary>
    /// Implements the operator +.
    /// </summary>
    /// <param name="augend">The augend.</param>
    /// <param name="addend">The addend.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static Matrix<T> operator +(Matrix<T> augend, Matrix<T> addend) => Add(augend, addend);

    /// <summary>
    /// Implements the operator -.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static Matrix<T> operator -(Matrix<T> value) => Negate(value);

    /// <summary>
    /// Implements the operator -.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subend">The subend.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static Matrix<T> operator -(Matrix<T> minuend, Matrix<T> subend) => Subtract(minuend, subend);

    /// <summary>
    /// Implements the operator *.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static Matrix<T> operator *(Matrix<T> multiplicand, T multiplier) => Scale(multiplicand, multiplier);

    /// <summary>
    /// Implements the operator *.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static Matrix<T> operator *(T multiplicand, Matrix<T> multiplier) => Scale(multiplicand, multiplier);

    /// <summary>
    /// Implements the operator *.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static Vector<T> operator *(Matrix<T> multiplicand, Vector<T> multiplier) => Multiply(multiplicand, multiplier);

    /// <summary>
    /// Implements the operator *.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static Vector<T> operator *(Vector<T> multiplicand, Matrix<T> multiplier) => Multiply(multiplier, multiplicand);

    /// <summary>
    /// Implements the operator *.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static Matrix<T> operator *(Matrix<T> multiplicand, Matrix<T> multiplier) => Multiply(multiplicand, multiplier);

    /// <summary>
    /// Implements the operator ==.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator ==(Matrix<T> left, Matrix<T> right) => left.Equals(right);

    /// <summary>
    /// Implements the operator !=.
    /// </summary>
    /// <param name="left">The left.</param>
    /// <param name="right">The right.</param>
    /// <returns>
    /// The result of the operator.
    /// </returns>
    public static bool operator !=(Matrix<T> left, Matrix<T> right) => !(left == right);

    /// <summary>
    /// Performs an implicit conversion from <see cref="Array" /> to <see cref="Matrix{T}" />.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Matrix<T>(T[,] array) => ToMatrix(array);
    #endregion

    #region Operator Backing Methods
    /// <summary>
    /// Pluses the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Matrix<T> Plus(Matrix<T> value) => Plus<T>(value.Items);

    /// <summary>
    /// Adds the specified augend.
    /// </summary>
    /// <param name="augend">The augend.</param>
    /// <param name="addend">The addend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Matrix<T> Add(Matrix<T> augend, Matrix<T> addend) => Add<T, T>(augend.Items, addend.Items);

    /// <summary>
    /// Negates the specified value.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Matrix<T> Negate(Matrix<T> value) => Negate<T>(value.Items);

    /// <summary>
    /// Subtracts the specified minuend.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subend">The subend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Matrix<T> Subtract(Matrix<T> minuend, Matrix<T> subend) => Subtract<T, T>(minuend.Items, subend.Items);

    /// <summary>
    /// Multiplies the specified multiplicand.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Matrix<T> Scale(Matrix<T> multiplicand, T multiplier) => Scale<T>(multiplicand.Items, multiplier);

    /// <summary>
    /// Scales the specified multiplicand.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Matrix<T> Scale(T multiplicand, Matrix<T> multiplier) => Scale<T>(multiplicand, multiplier.Items);

    /// <summary>
    /// Multiplies the specified multiplicand.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector<T> Multiply(Matrix<T> multiplicand, Vector<T> multiplier) => Multiply<T>(multiplicand.Items, multiplier.Items);

    /// <summary>
    /// Multiplies the specified multiplicand.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Vector<T> Multiply(Vector<T> multiplicand, Matrix<T> multiplier) => Multiply<T>(multiplicand.Items, multiplier.Items);

    /// <summary>
    /// Multiplies the specified multiplicand.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Matrix<T> Multiply(Matrix<T> multiplicand, Matrix<T> multiplier) => Multiply<T>(multiplicand.Items, multiplier.Items);

    /// <summary>
    /// Determines whether the specified <see cref="object" />, is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
    /// <returns>
    ///   <see langword="true" /> if the specified <see cref="object" /> is equal to this instance; otherwise, <see langword="false" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public override bool Equals(object? obj) => obj is Matrix<T> matrix && Equals(matrix);

    /// <summary>
    /// Indicates whether the current object is equal to another object of the same type.
    /// </summary>
    /// <param name="other">An object to compare with this object.</param>
    /// <returns>
    ///   <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public bool Equals(Matrix<T>? other) => other is Matrix<T> matrix && EqualityComparer<T[,]>.Default.Equals(Items, matrix.Items);

    /// <summary>
    /// Converts to matrix.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Matrix<T> ToMatrix(T[,] array) => new(array);
    #endregion

    /// <summary>
    /// Dots the product.
    /// </summary>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    public T DotProduct(Matrix<T> b) => DotProduct<T>(Items, b.Items);

    /// <summary>
    /// Lerps the specified b.
    /// </summary>
    /// <param name="b">The b.</param>
    /// <param name="t">The t.</param>
    /// <returns></returns>
    public Matrix<T> Lerp(Matrix<T> b, T t) => Operations.Lerp(Items, b.Items, t);

    #region Standard Methods
    /// <summary>
    /// Returns a hash code for this instance.
    /// </summary>
    /// <returns>
    /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
    /// </returns>
    public override int GetHashCode() => HashCode.Combine(Items);

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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public string ToString(string format, IFormatProvider formatProvider)
    {
        var sb = new StringBuilder();
        sb.Append('{');
        for (var i = 0; i < Rows; i++)
        {
            sb.Append('{');
            for (var j = 0; j < Columns; j++)
            {
                sb.Append($"{Items[i, j].ToString(format, formatProvider)},\t");
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
