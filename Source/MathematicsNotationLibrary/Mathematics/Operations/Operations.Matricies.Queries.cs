// <copyright file="Operations.Matricies.Queries.cs" company="Shkyrockett" >
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
    #region Is Scaler
    /// <summary>
    /// Determines whether the specified matrix is scaler.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>
    ///   <see langword="true" /> if the specified matrix is scaler; otherwise, <see langword="false" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsScaler<T>(Span2D<T> matrix) => matrix.Height == 1 && matrix.Width == 1;
    #endregion

    #region Is Vector
    /// <summary>
    /// Determines whether the specified matrix is vector.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>
    ///   <see langword="true" /> if the specified matrix is vector; otherwise, <see langword="false" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsVector<T>(Span2D<T> matrix) => matrix.Height == 1 || matrix.Width == 1;

    /// <summary>
    /// Determines whether [is vertical vector] [the specified matrix].
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>
    ///   <see langword="true" /> if [is vertical vector] [the specified matrix]; otherwise, <see langword="false" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsVerticalVector<T>(Span2D<T> matrix) => (matrix.Height == 1 || matrix.Width == 1) && matrix.Width == 1;

    /// <summary>
    /// Determines whether [is horizontal vector] [the specified matrix].
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>
    ///   <see langword="true" /> if [is horizontal vector] [the specified matrix]; otherwise, <see langword="false" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsHorizontalVector<T>(Span2D<T> matrix) => (matrix.Height == 1 || matrix.Width == 1) && matrix.Height == 1;
    #endregion

    #region Is Square Matrix
    /// <summary>
    /// Check if a matrix is has the same number of rows as columns.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>
    ///   <see langword="true" /> if [is square matrix] [the specified matrix]; otherwise, <see langword="false" />.
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L173
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsSquareMatrix<T>(Span2D<T> matrix) => matrix.Height == matrix.Width;
    #endregion

    #region Equality
    /// <summary>
    /// Equals the matrices.
    /// </summary>
    /// <param name="matrix1">The matrix1.</param>
    /// <param name="matrix2">The matrix2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool MatricesEquality<T>(Span2D<T> matrix1, Span2D<T> matrix2)
        where T : INumber<T>
    {
        var rows = matrix1.Height;
        var columns = matrix1.Width;

        if (rows != matrix2.Height || columns != matrix1.Width)
        {
            return false;
        }

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                if (matrix1[i, j] != matrix2[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// Equals the matrices.
    /// </summary>
    /// <param name="matrix1">The matrix1.</param>
    /// <param name="matrix2">The matrix2.</param>
    /// <param name="accuracy"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool MatricesEquality<T>(Span2D<T> matrix1, Span2D<T> matrix2, int accuracy = 15, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
    {
        var rows = matrix1.Height;
        var columns = matrix1.Width;

        if (rows != matrix2.Height || columns != matrix1.Width)
        {
            return false;
        }

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                var v1_rounded = T.Round(matrix1[i, j], accuracy, mode);
                var v2_rounded = T.Round(matrix2[i, j], accuracy, mode);
                if (v1_rounded != v2_rounded)
                {
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// Equals the matrices.
    /// </summary>
    /// <param name="matrix1">The matrix1.</param>
    /// <param name="matrix2">The matrix2.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool MatricesEquality<T>(Span2D<T> matrix1, Span2D<T> matrix2, int rows, int columns)
        where T : INumber<T>
    {
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                if (matrix1[i, j] != matrix2[i, j])
                {
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// Equals the matrices.
    /// </summary>
    /// <param name="matrix1">The matrix1.</param>
    /// <param name="matrix2">The matrix2.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="accuracy"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool MatricesEquality<T>(Span2D<T> matrix1, Span2D<T> matrix2, int rows, int columns, int accuracy = 15, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
    {
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                var v1_rounded = T.Round(matrix1[i, j], accuracy, mode);
                var v2_rounded = T.Round(matrix2[i, j], accuracy, mode);
                if (v1_rounded != v2_rounded)
                {
                    return false;
                }
            }
        }

        return true;
    }
    #endregion

    #region Is Additive Identity All Zeros
    /// <summary>
    /// Determines whether the specified matrix components are all equal to zero.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>
    ///   <see langword="true" /> if [is matrix zero] [the specified matrix]; otherwise, <see langword="false" />.
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsAdditiveIdentity<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var rows = matrix.Height;
        var columns = matrix.Width;
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                var temp_round = matrix[i, j];
                if (temp_round != T.Zero)
                {
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether the specified matrix components are all equal to zero.
    /// </summary>
    /// <param name="the_matrix">The matrix.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns>
    ///   <see langword="true" /> if [is matrix zero] [the specified rows]; otherwise, <see langword="false" />.
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsAdditiveIdentity<T>(Span2D<T> the_matrix, int rows, int columns)
        where T : INumber<T>
    {
        var zero_matrix = true;
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                var temp_round = the_matrix[i, j];
                if (temp_round != T.Zero)
                {
                    zero_matrix = false;
                }
            }
        }

        return zero_matrix;
    }
    #endregion

    #region Is Zero Rounded
    /// <summary>
    /// Determines whether the specified matrix components are all equal to zero.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns>
    ///   <see langword="true" /> if [is matrix zero] [the specified matrix]; otherwise, <see langword="false" />.
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsZeroRounded<T>(Span2D<T> matrix, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
    {
        var rows = matrix.Height;
        var columns = matrix.Width;
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                var temp_round = T.Round(matrix[i, j], accuracy, mode);
                if (temp_round != T.Zero)
                {
                    return false;
                }
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether the specified matrix components are all equal to zero.
    /// </summary>
    /// <param name="the_matrix">The matrix.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns>
    ///   <see langword="true" /> if [is matrix zero] [the specified rows]; otherwise, <see langword="false" />.
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsZeroRounded<T>(Span2D<T> the_matrix, int rows, int columns, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
    {
        var zero_matrix = true;
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                var temp_round = T.Round(the_matrix[i, j], accuracy, mode);
                if (temp_round != T.Zero)
                {
                    zero_matrix = false;
                }
            }
        }

        return zero_matrix;
    }
    #endregion

    #region Is Multiplicative Identity All Zeros Except For Diagonal Ones
    /// <summary>
    /// Determines whether the specified matrix is identity.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>
    ///   <see langword="true"/> if the specified matrix is identity; otherwise, <see langword="false"/>.
    /// </returns>
    /// <acknowledgment>
    /// https://www.tutorialgateway.org/c-program-to-check-matrix-is-an-identity-matrix/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsMultiplicativeIdentity<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var rows = matrix.Height;
        var cols = matrix.Width;

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (matrix[i, j] != T.One && matrix[j, i] != T.Zero)
                {
                    return false;
                }
            }
        }

        return true;
    }
    #endregion Is Identity

    #region Is Zero Column
    /// <summary>
    /// Zero column.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="columnIndex">Index of the column.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsZeroColumn<T>(Span2D<T> matrix, int columnIndex)
        where T : INumber<T>
    {
        var N = matrix.Height;
        for (var i = 0; i < N; i++)
        {
            if (matrix[i, columnIndex] != T.Zero)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Zero column.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="N">The n.</param>
    /// <param name="columnIndex">Index of the column.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsZeroColumn<T>(Span2D<T> matrix, int N, int columnIndex)
        where T : INumber<T>
    {
        for (var i = 0; i < N; i++)
        {
            if (matrix[i, columnIndex] != T.Zero)
            {
                return false;
            }
        }

        return true;
    }
    #endregion

    #region Matrix Is Non-Singular
    /// <summary>
    /// Is the matrix nonsingular?
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>
    ///   <see langword="true" /> if [is non singular] [the specified matrix]; otherwise, <see langword="false" />.
    /// </returns>
    /// <acknowledgment>
    /// https://www.codeproject.com/articles/5835/dotnetmatrix-simple-matrix-library-for-net
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsNonSingular<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var n = matrix.Width;
        for (var j = 0; j < n; j++)
        {
            if (matrix[j, j] == T.Zero)
            {
                return false;
            }
        }

        return true;
    }
    #endregion

    #region Matrix Is Full-Rank
    /// <summary>
    /// Is the matrix diagonal full rank?
    /// </summary>
    /// <acknowledgment>
    /// https://www.codeproject.com/articles/5835/dotnetmatrix-simple-matrix-library-for-net
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsFullRank<T>(Span<T> RDiagnal)
        where T : INumber<T>
    {
        var n = RDiagnal.Length;
        for (var j = 0; j < n; j++)
        {
            if (RDiagnal[j] == T.Zero)
            {
                return false;
            }
        }

        return true;
    }
    #endregion

    #region Is Lower Matrix
    /// <summary>
    /// Check whether a matrix is a lower matrix.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>
    ///   <see langword="true" /> if [is lower matrix] [the specified matrix]; otherwise, <see langword="false" />.
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L181
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsLowerMatrix<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var rows = matrix.Height;
        var cols = matrix.Width;

        for (var i = 0; i < rows; i++)
        {
            for (var j = i + 1; j < cols; j++)
            {
                if (matrix[i, j] != T.Zero)
                {
                    return false;
                }
            }
        }

        return true;
    }
    #endregion

    #region Is Upper Matrix
    /// <summary>
    /// Check whether a matrix is an upper matrix.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns>
    ///   <see langword="true" /> if [is upper matrix] [the specified matrix]; otherwise, <see langword="false" />.
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L199
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsUpperMatrix<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var rows = matrix.Height;
        //var cols = matrix.Width;

        for (var i = 1; i < rows; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (matrix[i, j] != T.Zero)
                {
                    return false;
                }
            }
        }

        return true;
    }
    #endregion
}
