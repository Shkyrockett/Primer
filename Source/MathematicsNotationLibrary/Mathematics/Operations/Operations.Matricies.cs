// <copyright file="Operations.Matricies.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using Microsoft.Toolkit.HighPerformance;
using System;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary;

/// <summary>
/// The Operations class.
/// </summary>
public static partial class Operations
{
    #region Matrix Rounding
    /// <summary>
    /// Rounds the specified matrix.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] Round<T, TResult>(this Span2D<T> matrix, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult>
    {
        var rows = matrix.Height;
        var columns = matrix.Width;

        var result = new TResult[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                result[i, j] = TResult.Create(T.Round(matrix[i, j], accuracy, mode));
            }
        }

        return result;
    }

    /// <summary>
    /// Rounds the specified matrix.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] Round<T, TResult>(this Span2D<T> matrix, int rows, int columns, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult>
    {
        if (rows > matrix.Height || columns > matrix.Width)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(matrix)}");
        }

        var result = new TResult[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                result[i, j] = TResult.Create(T.Round(matrix[i, j], accuracy, mode));
            }
        }

        return result;
    }
    #endregion

    #region Matrix Type Conversion
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] Cast<T, TResult>(this Span2D<T> value)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = new TResult[value.Width, value.Height];

        for (int i = 0; i < value.Width; i++)
        {
            for (int j = 0; j < value.Height; j++)
            {
                result[i, j] = TResult.Create(value[i, j]);
            }
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <param name="rows"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] Cast<T, TResult>(this Span2D<T> value, int rows, int columns)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        if (rows > value.Height || columns > value.Width)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(value)}");
        }

        var result = new TResult[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = TResult.Create(value[i, j]);
            }
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] CastSaturating<T, TResult>(this Span2D<T> value)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = new TResult[value.Width, value.Height];

        for (int i = 0; i < value.Width; i++)
        {
            for (int j = 0; j < value.Height; j++)
            {
                result[i, j] = TResult.CreateSaturating(value[i, j]);
            }
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <param name="rows"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] CastSaturating<T, TResult>(this Span2D<T> value, int rows, int columns)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        if (rows > value.Height || columns > value.Width)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(value)}");
        }

        var result = new TResult[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = TResult.CreateSaturating(value[i, j]);
            }
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] CastTruncating<T, TResult>(this Span2D<T> value)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = new TResult[value.Width, value.Height];

        for (int i = 0; i < value.Width; i++)
        {
            for (int j = 0; j < value.Height; j++)
            {
                result[i, j] = TResult.CreateTruncating(value[i, j]);
            }
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <param name="rows"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] CastTruncating<T, TResult>(this Span2D<T> value, int rows, int columns)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        if (rows > value.Height || columns > value.Width)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(value)}");
        }

        var result = new TResult[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = TResult.CreateTruncating(value[i, j]);
            }
        }

        return result;
    }
    #endregion

    #region Matrix Copy
    /// <summary>
    /// Copies the matrix.
    /// </summary>
    /// <param name="matrix">The original matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] CopyMatrix<T>(Span2D<T> matrix)
    {
        var rows = matrix.Height;
        var columns = matrix.Width;
        var result = new T[rows, columns];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                result[i, j] = matrix[i, j];
            }
        }

        return result;
    }

    /// <summary>
    /// Copies the matrix.
    /// </summary>
    /// <param name="matrix">The original matrix.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] CopyMatrix<T>(Span2D<T> matrix, int rows, int columns)
    {
        var result = new T[rows, columns];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                result[i, j] = matrix[i, j];
            }
        }

        return result;
    }
    #endregion

    #region Matrix Vector Conversion
    /// <summary>
    /// Vectors to 1 row matrix.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] VectorToSingleRowMatrix<T>(Span<T> vector)
    {
        var Result = new T[1, vector.Length];
        for (var j = 0; j < vector.Length; j++)
        {
            Result[0, j] = vector[j];
        }

        return Result;
    }

    /// <summary>
    /// Vectors to 1 row matrix.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] VectorToSingleRowMatrix<T>(Span<T> vector, int length)
    {
        var Result = new T[1, length];
        for (var j = 0; j < length; j++)
        {
            Result[0, j] = vector[j];
        }

        return Result;
    }

    /// <summary>
    /// Vectors to 1 column matrix.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] VectorToSingleColumnMatrix<T>(Span<T> vector)
    {
        var Result = new T[vector.Length, 1];
        for (var i = 0; i < vector.Length; i++)
        {
            Result[i, 0] = vector[i];
        }

        return Result;
    }

    /// <summary>
    /// Vectors to 1 column matrix.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] VectorToSingleColumnMatrix<T>(Span<T> vector, int length)
    {
        var Result = new T[length, 1];
        for (var i = 0; i < length; i++)
        {
            Result[i, 0] = vector[i];
        }

        return Result;
    }

    /// <summary>
    /// Converts a single row matrix to a vector.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] SingleRowMatrixToVector<T>(Span2D<T> matrix, int columns)
    {
        var Result = new T[columns];
        for (var i = 0; i < columns; i++)
        {
            Result[i] = matrix[0, i];
        }

        return Result;
    }

    /// <summary>
    /// Converts a single column matrix to a vector.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="rows">The rows.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] SingleColumnMatrixToVector<T>(Span2D<T> matrix, int rows)
    {
        var Result = new T[rows];
        for (var i = 0; i < rows; i++)
        {
            Result[i] = matrix[i, 0];
        }

        return Result;
    }
    #endregion

    #region Matrix Diagonal from Vector
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] DiagnalFromVector<T>(Span<T> vector)
        where T : INumber<T>
    {
        var length = vector.Length;

        var result = new T[length, length];

        for (var i = 0; i < length; i++)
        {
            for (var j = 0; j < length; j++)
            {
                result[i, j] = i == j ? vector[i] : T.Zero;
            }
        }

        return result;
    }
    #endregion

    #region Matrix Truncate
    /// <summary>
    /// Truncate a matrix
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="rowStart">The row start.</param>
    /// <param name="rowEnd">The row end.</param>
    /// <param name="columnStart">The column start.</param>
    /// <param name="columnEnd">The column end.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L100
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Truncate<T>(Span2D<T> matrix, int rowStart, int rowEnd, int columnStart, int columnEnd)
    {
        var rows = matrix.Height;
        var cols = matrix.Width;

        var minimumIndex = rowStart == 0 || rowEnd == 0 || columnStart == 0 || columnEnd == 0;
        var coherenceIndex = rowEnd < rowStart || columnEnd < columnStart;
        var boundIndex = rowEnd > rows || columnEnd > cols;

        if (minimumIndex || coherenceIndex || boundIndex)
        {
            return new T[1, 1];
        }

        var result = new T[rowEnd - rowStart + 1, columnEnd - columnStart + 1];

        for (var i = rowStart - 1; i < rowEnd; i++)
        {
            for (var j = columnStart - 1; j < columnEnd; j++)
            {
                result[i - rowStart + 1, j - columnStart + 1] = matrix[i, j];
            }
        }

        return result;
    }

    /// <summary>
    /// Get a sub-matrix.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="i0">Initial row index</param>
    /// <param name="i1">Final row index</param>
    /// <param name="j0">Initial column index</param>
    /// <param name="j1">Final column index</param>
    /// <returns>
    /// A(i0:i1,j0:j1)
    /// </returns>
    /// <exception cref="IndexOutOfRangeException">Sub-matrix indices</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] GetMatrix<T>(Span2D<T> matrix, int i0, int i1, int j0, int j1)
    {
        var tMatrix = new T[i1 - i0 + 1, j1 - j0 + 1];
        try
        {
            for (var i = i0; i <= i1; i++)
            {
                for (var j = j0; j <= j1; j++)
                {
                    tMatrix[i - i0, j - j0] = matrix[i, j];
                }
            }
        }
        catch (IndexOutOfRangeException e)
        {
            throw new IndexOutOfRangeException("Sub-matrix indices", e);
        }

        return tMatrix;
    }

    /// <summary>
    /// Get a sub-matrix.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="r">Array of row indices.</param>
    /// <param name="c">Array of column indices.</param>
    /// <returns>
    /// A(r(:),c(:))
    /// </returns>
    /// <exception cref="IndexOutOfRangeException">Sub-matrix indices</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] GetMatrix<T>(Span2D<T> matrix, Span<int> r, Span<int> c)
    {
        var tMatrix = new T[r.Length, c.Length];
        try
        {
            for (var i = 0; i < r.Length; i++)
            {
                for (var j = 0; j < c.Length; j++)
                {
                    tMatrix[i, j] = matrix[r[i], c[j]];
                }
            }
        }
        catch (IndexOutOfRangeException e)
        {
            throw new IndexOutOfRangeException("Sub-matrix indices", e);
        }
        return tMatrix;
    }

    /// <summary>
    /// Get a sub-matrix.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="i0">Initial row index</param>
    /// <param name="i1">Final row index</param>
    /// <param name="c">Array of column indices.</param>
    /// <returns>
    /// A(i0:i1,c(:))
    /// </returns>
    /// <exception cref="IndexOutOfRangeException">Sub-matrix indices</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] GetMatrix<T>(Span2D<T> matrix, int i0, int i1, Span<int> c)
    {
        var tMatrix = new T[i1 - i0 + 1, c.Length];
        try
        {
            for (var i = i0; i <= i1; i++)
            {
                for (var j = 0; j < c.Length; j++)
                {
                    tMatrix[i - i0, j] = matrix[i, c[j]];
                }
            }
        }
        catch (IndexOutOfRangeException e)
        {
            throw new IndexOutOfRangeException("Sub-matrix indices", e);
        }
        return tMatrix;
    }

    /// <summary>
    /// Get a sub-matrix.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="r">Array of row indices.</param>
    /// <param name="j0">Initial column index</param>
    /// <param name="j1">Final column index</param>
    /// <returns>
    /// A(r(:),j0:j1)
    /// </returns>
    /// <exception cref="IndexOutOfRangeException">Sub-matrix indices</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] GetMatrix<T>(Span2D<T> matrix, Span<int> r, int j0, int j1)
    {
        var tMatrix = new T[r.Length, j1 - j0 + 1];
        try
        {
            for (var i = 0; i < r.Length; i++)
            {
                for (var j = j0; j <= j1; j++)
                {
                    tMatrix[i, j - j0] = matrix[r[i], j];
                }
            }
        }
        catch (IndexOutOfRangeException e)
        {
            throw new IndexOutOfRangeException("Sub-matrix indices", e);
        }
        return tMatrix;
    }
    #endregion

    #region Transpose Matrix
    /// <summary>
    /// Returns the transpose of a matrix
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Transpose<T>(Span2D<T> matrix)
    {
        var rows = matrix.Height;
        var cols = matrix.Width;
        var result = new T[cols, rows];
        for (var i = 0; i < cols; i++)
        {
            for (var j = 0; j < rows; j++)
            {
                result[i, j] = matrix[j, i];
                //result[j, i] = matrix[i, j];
            }
        }

        return result;
    }

    /// <summary>
    /// Transposes the specified rows.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Transpose<T>(Span2D<T> matrix, int accuracy)
        where T : IFloatingPoint<T>
    {
        var rows = matrix.Height;
        var columns = matrix.Width;
        var result = new T[columns, rows];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                result[i, j] = matrix[j, i];
                //result[j, i] = matrix[i, j];
            }
        }

        return Round<T, T>(result, accuracy);
    }

    /// <summary>
    /// Transposes the specified rows.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Transpose<T>(Span2D<T> matrix, int rows, int columns, int accuracy)
        where T : IFloatingPoint<T>
    {
        var result = new T[columns, rows];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                result[i, j] = matrix[j, i];
                //result[j, i] = matrix[i, j];
            }
        }

        return Round<T, T>(result, columns, rows, accuracy);
    }
    #endregion Transpose

    #region Matrix Row Swap
    /// <summary>
    /// Swaps the rows.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="row1">The row1.</param>
    /// <param name="row2">The row2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void SwapRows<T>(Span2D<T> matrix, int row1, int row2)
    {
        var columns = matrix.Width;
        var temp_row = new T[columns];
        for (var j = 0; j < columns; j++)
        {
            temp_row[j] = matrix[row1, j];
            matrix[row1, j] = matrix[row2, j];
            matrix[row2, j] = temp_row[j];
        }
    }

    /// <summary>
    /// Swaps the rows.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="rows">The number of rows.</param>
    /// <param name="columns">The number of columns.</param>
    /// <param name="row1">The row1.</param>
    /// <param name="row2">The row2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void SwapRows<T>(Span2D<T> matrix, int rows, int columns, int row1, int row2)
    {
        _ = rows;
        var temp_row = new T[columns];
        for (var j = 0; j < columns; j++)
        {
            temp_row[j] = matrix[row1, j];
            matrix[row1, j] = matrix[row2, j];
            matrix[row2, j] = temp_row[j];
        }
    }
    #endregion

    #region Matrix Column Swap
    /// <summary>
    /// Swaps the columns.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="column1">The column1.</param>
    /// <param name="column2">The column2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void SwapColumns<T>(Span2D<T> matrix, int column1, int column2)
    {
        var rows = matrix.Height;
        var temp_column = new T[rows];
        for (var i = 0; i < rows; i++)
        {
            temp_column[i] = matrix[i, column1];
            matrix[i, column1] = matrix[i, column2];
            matrix[i, column2] = temp_column[i];
        }
    }

    /// <summary>
    /// Swaps the columns.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="rows">The number of rows.</param>
    /// <param name="columns">The number of columns.</param>
    /// <param name="column1">The column1.</param>
    /// <param name="column2">The column2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void SwapColumns<T>(Span2D<T> matrix, int rows, int columns, int column1, int column2)
    {
        _ = columns;
        var temp_column = new T[rows];
        for (var i = 0; i < rows; i++)
        {
            temp_column[i] = matrix[i, column1];
            matrix[i, column1] = matrix[i, column2];
            matrix[i, column2] = temp_column[i];
        }
    }
    #endregion

    #region Column Concatenation
    /// <summary>
    /// Concatenation of matrices by columns
    /// </summary>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L100
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] ConcatenationColumns<T>(Span2D<T> matrix1, Span2D<T> matrix2)
    {
        var rows1 = matrix1.Height;
        var cols1 = matrix1.Width;
        var rows2 = matrix2.Height;
        var cols2 = matrix2.Width;
        if (rows1 != rows2)
        {
            return new T[1, 1];
        }

        var results = new T[rows1, cols1 + cols2];
        for (var k = 0; k < cols1; k++)
        {
            for (var i = 0; i < rows1; i++)
            {
                results[i, k] = matrix1[i, k];
            }
        }

        for (var k = cols1; k < cols1 + cols2; k++)
        {
            for (var i = 0; i < rows1; i++)
            {
                results[i, k] = matrix2[i, k - cols1];
            }
        }

        return results;
    }
    #endregion

    #region Merge Matrices Horizontally
    /// <summary>
    /// Merge two matrices (or vectors) - LSM.
    /// </summary>
    /// <param name="matrix1">The matrix1.</param>
    /// <param name="matrix2">The matrix2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] MergeMatricesHorizontally<T>(Span2D<T> matrix1, Span2D<T> matrix2)
    {
        var rows1 = matrix1.Height;
        var columns1 = matrix1.Width;
        var columns2 = matrix2.Width;
        var matrix2_columns = 0;
        var result = new T[rows1, columns1 + columns2];
        for (var i = 0; i < rows1; i++)
        {
            for (var j = 0; j < columns1 + columns2; j++)
            {
                if (j < columns1)
                {
                    result[i, j] = matrix1[i, j];
                }
                else
                {
                    result[i, j] = matrix2[i, matrix2_columns];
                    if (matrix2_columns < columns2)
                    {
                        matrix2_columns++;
                    }
                    else
                    {
                        throw new Exception("Error in merging matrices, columns don't match.");
                    }
                }
            }

            matrix2_columns = 0;
        }

        return result;
    }

    /// <summary>
    /// Merge two matrices (or vectors) - LSM.
    /// </summary>
    /// <param name="matrix1">The matrix1.</param>
    /// <param name="rows1">The rows1.</param>
    /// <param name="columns1">The columns1.</param>
    /// <param name="matrix2">The matrix2.</param>
    /// <param name="columns2">The columns2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] MergeMatricesHorizontally<T>(Span2D<T> matrix1, int rows1, int columns1, Span2D<T> matrix2, int columns2)
    {
        var matrix2_columns = 0;
        var result = new T[rows1, columns1 + columns2];
        for (var i = 0; i < rows1; i++)
        {
            for (var j = 0; j < columns1 + columns2; j++)
            {
                if (j < columns1)
                {
                    result[i, j] = matrix1[i, j];
                }
                else
                {
                    result[i, j] = matrix2[i, matrix2_columns];
                    if (matrix2_columns < columns2)
                    {
                        matrix2_columns++;
                    }
                    else
                    {
                        throw new Exception("Error in merging matrices, columns don't match.");
                    }
                }
            }

            matrix2_columns = 0;
        }

        return result;
    }
    #endregion

    #region Merge Matrices Vertically
    /// <summary>
    /// Merge two matrices vertically, I have changed access area here to make it shorter.
    /// </summary>
    /// <param name="matrix1">The matrix1.</param>
    /// <param name="matrix2">The matrix2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (int rows, int columns, T[,] matrix) MergeMatricesVertically<T>(Span2D<T> matrix1, Span2D<T> matrix2)
    {
        var rows1 = matrix1.Height;
        var columns1 = matrix1.Width;
        var rows2 = matrix2.Height;
        var result_rows = rows1 + rows2;
        var result = new T[rows1 + rows2, columns1];
        for (var i = 0; i < result_rows; i++)
        {
            for (var j = 0; j < columns1; j++)
            {
                result[i, j] = i < rows1 ? matrix1[i, j] : matrix2[i - rows1, j];
            }
        }

        return (result_rows, columns1, result);
    }

    /// <summary>
    /// Merge two matrices vertically, I have changed access area here to make it shorter.
    /// </summary>
    /// <param name="matrix1">The matrix1.</param>
    /// <param name="rows1">The rows1.</param>
    /// <param name="columns1">The columns1.</param>
    /// <param name="matrix2">The matrix2.</param>
    /// <param name="rows2">The rows2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (int rows, int columns, T[,] matrix) MergeMatricesVertically<T>(Span2D<T> matrix1, int rows1, int columns1, Span2D<T> matrix2, int rows2)
    {
        var result_rows = rows1 + rows2;
        var result = new T[rows1 + rows2, columns1];
        for (var i = 0; i < result_rows; i++)
        {
            for (var j = 0; j < columns1; j++)
            {
                result[i, j] = i < rows1 ? matrix1[i, j] : matrix2[i - rows1, j];
            }
        }

        return (result_rows, columns1, result);
    }
    #endregion

    #region Extract Part Of Matrix
    /// <summary>
    /// Extracts the bottom right part of the matrix.
    /// </summary>
    /// <param name="matrix">The whole matrix.</param>
    /// <param name="beginning_row">The beginning row.</param>
    /// <param name="ending_row">The ending row.</param>
    /// <param name="beginning_column">The beginning column.</param>
    /// <param name="ending_column">The ending column.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] ExtractPartOfMatrix<T>(Span2D<T> matrix, int beginning_row, int ending_row, int beginning_column, int ending_column)
    {
        //var rows_total = matrix.Height;
        //var columns_total = matrix.Width;
        int temp;
        if (beginning_row > ending_row)
        {
            temp = beginning_row;
            beginning_row = ending_row;
            ending_row = temp;
        }

        if (beginning_column > ending_column)
        {
            temp = beginning_column;
            beginning_column = ending_column;
            ending_column = temp;
        }

        var the_result = new T[ending_row - beginning_row + 1, ending_column - beginning_column + 1];
        try
        {
            for (var i = beginning_row; i <= ending_row; i++)
            {
                for (var j = beginning_column; j <= ending_column; j++)
                {
                    the_result[i - beginning_row, j - beginning_column] = matrix[i, j];
                }
            }
        }
        catch (Exception The_Exception)
        {
            throw new Exception($"Couldn't cut the wanted piece from the matrix. Error: {The_Exception.Message}");
        }

        return the_result;
    }

    /// <summary>
    /// Extracts the bottom right part of the matrix.
    /// </summary>
    /// <param name="whole_matrix">The whole matrix.</param>
    /// <param name="rows_total">The rows total.</param>
    /// <param name="columns_total">The columns total.</param>
    /// <param name="beginning_row">The beginning row.</param>
    /// <param name="ending_row">The ending row.</param>
    /// <param name="beginning_column">The beginning column.</param>
    /// <param name="ending_column">The ending column.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] ExtractPartOfMatrix<T>(Span2D<T> whole_matrix, int rows_total, int columns_total, int beginning_row, int ending_row, int beginning_column, int ending_column)
    {
        _ = rows_total;
        _ = columns_total;

        int temp;
        if (beginning_row > ending_row)
        {
            temp = beginning_row;
            beginning_row = ending_row;
            ending_row = temp;
        }

        if (beginning_column > ending_column)
        {
            temp = beginning_column;
            beginning_column = ending_column;
            ending_column = temp;
        }

        var the_result = new T[ending_row - beginning_row + 1, ending_column - beginning_column + 1];
        try
        {
            for (var i = beginning_row; i <= ending_row; i++)
            {
                for (var j = beginning_column; j <= ending_column; j++)
                {
                    the_result[i - beginning_row, j - beginning_column] = whole_matrix[i, j];
                }
            }
        }
        catch (Exception The_Exception)
        {
            throw new Exception($"Couldn't cut the wanted piece from the matrix. Error: {The_Exception.Message}");
        }

        return the_result;
    }
    #endregion

    #region Rotate Matrix Clockwise
    /// <summary>
    /// Rotates the matrix clockwise.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://stackoverflow.com/a/18035050
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] RotateMatrixClockwise<T>(Span2D<T> matrix)
    {
        var m = matrix.Height;
        var n = matrix.Width;
        var result = new T[n, m];
        for (var i = 0; i < n; ++i)
        {
            for (var j = 0; j < n; ++j)
            {
                result[i, j] = matrix[n - j - 1, i];
            }
        }

        return result;
    }
    #endregion

    #region Rotate Matrix Counter Clockwise
    /// <summary>
    /// Rotates the matrix counter clockwise.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://stackoverflow.com/a/18035050
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] RotateMatrixCounterClockwise<T>(Span2D<T> matrix)
    {
        var m = matrix.Height;
        var n = matrix.Width;
        var result = new T[n, m];
        for (var i = 0; i < n; ++i)
        {
            for (var j = 0; j < n; ++j)
            {
                result[i, j] = matrix[j, n - i - 1];
            }
        }

        return result;
    }
    #endregion
}
