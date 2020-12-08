// <copyright file="Operations.Queries.Arrangements.Array.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using Microsoft.Toolkit.HighPerformance.Memory;
using System;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary
{
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsScaler(Span2D<float> matrix) => matrix.Height == 1 && matrix.Width == 1;

        /// <summary>
        /// Determines whether the specified matrix is scaler.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if the specified matrix is scaler; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsScaler(Span2D<double> matrix) => matrix.Height == 1 && matrix.Width == 1;
        #endregion

        #region Is Vector
        /// <summary>
        /// Determines whether the specified matrix is vector.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if the specified matrix is vector; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsVector(Span2D<float> matrix) => matrix.Height == 1 || matrix.Width == 1;

        /// <summary>
        /// Determines whether the specified matrix is vector.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if the specified matrix is vector; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsVector(Span2D<double> matrix) => matrix.Height == 1 || matrix.Width == 1;

        /// <summary>
        /// Determines whether [is vertical vector] [the specified matrix].
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if [is vertical vector] [the specified matrix]; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsVerticalVector(Span2D<float> matrix) => (matrix.Height == 1 || matrix.Width == 1) && matrix.Width == 1;

        /// <summary>
        /// Determines whether [is vertical vector] [the specified matrix].
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if [is vertical vector] [the specified matrix]; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsVerticalVector(Span2D<double> matrix) => (matrix.Height == 1 || matrix.Width == 1) && matrix.Width == 1;

        /// <summary>
        /// Determines whether [is horizontal vector] [the specified matrix].
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if [is horizontal vector] [the specified matrix]; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsHorizontalVector(Span2D<float> matrix) => (matrix.Height == 1 || matrix.Width == 1) && matrix.Height == 1;

        /// <summary>
        /// Determines whether [is horizontal vector] [the specified matrix].
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns>
        ///   <see langword="true" /> if [is horizontal vector] [the specified matrix]; otherwise, <see langword="false" />.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsHorizontalVector(Span2D<double> matrix) => (matrix.Height == 1 || matrix.Width == 1) && matrix.Height == 1;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSquareMatrix(Span2D<float> matrix) => matrix.Height == matrix.Width;

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSquareMatrix(Span2D<double> matrix) => matrix.Height == matrix.Width;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool MatricesEquality(Span2D<double> matrix1, Span2D<double> matrix2)
        {
            var rows = matrix1.Height;
            var columns = matrix1.Width;

            if (rows != matrix2.Height || columns != matrix1.Width) return false;

            var Equal = true;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    var v1_rounded = Round(matrix1[i, j], 15);
                    var v2_rounded = Round(matrix2[i, j], 15);
                    if (v1_rounded == v2_rounded)
                    {
                        Equal = false;
                        break;
                    }
                }
            }

            return Equal;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool MatricesEquality(Span2D<double> matrix1, Span2D<double> matrix2, int rows, int columns)
        {
            var Equal = true;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    var v1_rounded = Round(matrix1[i, j], 15);
                    var v2_rounded = Round(matrix2[i, j], 15);
                    if (v1_rounded == v2_rounded)
                    {
                        Equal = false;
                        break;
                    }
                }
            }

            return Equal;
        }
        #endregion

        #region Is Zero
        /// <summary>
        /// Determines whether the specified vector components are all equal to zero.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns>
        ///   <see langword="true" /> if the specified vector is zero; otherwise, <see langword="false" />.
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero(Span<double> vector, int accuracy)
        {
            for (var i = 0; i < vector.Length; i++)
            {
                if (Round(vector[i], accuracy) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the specified vector components are all equal to zero.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="length">The length.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns>
        ///   <see langword="true" /> if [is vector zero] [the specified vector]; otherwise, <see langword="false" />.
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero(Span<double> vector, int length, int accuracy)
        {
            for (var i = 0; i < length; i++)
            {
                if (Round(vector[i], accuracy) != 0d)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether the specified matrix components are all equal to zero.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns>
        ///   <see langword="true" /> if [is matrix zero] [the specified matrix]; otherwise, <see langword="false" />.
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero(Span2D<double> matrix, int accuracy)
        {
            var rows = matrix.Height;
            var columns = matrix.Width;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    var temp_round = Round(matrix[i, j], accuracy);
                    if (temp_round != 0d)
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
        /// <returns>
        ///   <see langword="true" /> if [is matrix zero] [the specified rows]; otherwise, <see langword="false" />.
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero(Span2D<double> the_matrix, int rows, int columns, int accuracy)
        {
            var zero_matrix = true;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    var temp_round = Round(the_matrix[i, j], accuracy);
                    if (temp_round != 0)
                    {
                        zero_matrix = false;
                    }
                }
            }

            return zero_matrix;
        }
        #endregion

        #region Is Zero Column
        /// <summary>
        /// Zero column.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="columnIndex">Index of the column.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZeroColumn(Span2D<float> matrix, int columnIndex)
        {
            var zero_column = true;
            var N = matrix.Height;
            for (var i = 0; i < N; i++)
            {
                if (matrix[i, columnIndex] != 0)
                {
                    zero_column = false;
                }
            }

            return zero_column;
        }

        /// <summary>
        /// Zero column.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="columnIndex">Index of the column.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZeroColumn(Span2D<double> matrix, int columnIndex)
        {
            var zero_column = true;
            var N = matrix.Height;
            for (var i = 0; i < N; i++)
            {
                if (matrix[i, columnIndex] != 0)
                {
                    zero_column = false;
                }
            }

            return zero_column;
        }

        /// <summary>
        /// Zero column.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="N">The n.</param>
        /// <param name="columnIndex">Index of the column.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZeroColumn(Span2D<float> matrix, int N, int columnIndex)
        {
            var zero_column = true;
            for (var i = 0; i < N; i++)
            {
                if (matrix[i, columnIndex] != 0)
                {
                    zero_column = false;
                }
            }

            return zero_column;
        }

        /// <summary>
        /// Zero column.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="N">The n.</param>
        /// <param name="columnIndex">Index of the column.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZeroColumn(Span2D<double> matrix, int N, int columnIndex)
        {
            var zero_column = true;
            for (var i = 0; i < N; i++)
            {
                if (matrix[i, columnIndex] != 0)
                {
                    zero_column = false;
                }
            }

            return zero_column;
        }
        #endregion

        #region Is Identity
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIdentity(Span2D<float> matrix)
        {
            var rows = matrix.Height;
            var cols = matrix.Width;

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (matrix[i, j] != 1 && matrix[j, i] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsIdentity(Span2D<double> matrix)
        {
            var rows = matrix.Height;
            var cols = matrix.Width;

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (matrix[i, j] != 1 && matrix[j, i] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion Is Identity

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLowerMatrix(Span2D<float> matrix)
        {
            var rows = matrix.Height;
            var cols = matrix.Width;

            for (var i = 0; i < rows; i++)
            {
                for (var j = i + 1; j < cols; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsLowerMatrix(Span2D<double> matrix)
        {
            var rows = matrix.Height;
            var cols = matrix.Width;

            for (var i = 0; i < rows; i++)
            {
                for (var j = i + 1; j < cols; j++)
                {
                    if (matrix[i, j] != 0)
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsUpperMatrix(Span2D<float> matrix)
        {
            var rows = matrix.Height;
            //var cols = matrix.Width;

            for (var i = 1; i < rows; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsUpperMatrix(Span2D<double> matrix)
        {
            var rows = matrix.Height;
            //var cols = matrix.Width;

            for (var i = 1; i < rows; i++)
            {
                for (var j = 0; j < i; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion
    }
}
