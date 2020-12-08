// <copyright file="Operations.Matricies.Arithmatics.Array.cs" company="Shkyrockett" >
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
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// The Operations class.
    /// </summary>
    public static partial class Operations
    {
        #region Rounding
        /// <summary>
        /// Rounds the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Round(Span2D<float> matrix, int accuracy)
        {
            var rows = matrix.Height;
            var columns = matrix.Width;

            var Result = new float[rows, columns];
            if (accuracy < 15)
            {
                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < columns; j++)
                    {
                        Result[i, j] = MathF.Round(matrix[i, j], accuracy);
                    }
                }
            }
            else
            {
                Result = CopyMatrix(matrix);
            }

            return Result;
        }

        /// <summary>
        /// Rounds the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Round(Span2D<double> matrix, int accuracy)
        {
            var rows = matrix.Height;
            var columns = matrix.Width;

            var Result = new double[rows, columns];
            if (accuracy < 15)
            {
                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < columns; j++)
                    {
                        Result[i, j] = Math.Round(matrix[i, j], accuracy);
                    }
                }
            }
            else
            {
                Result = CopyMatrix(matrix);
            }

            return Result;
        }

        /// <summary>
        /// Rounds the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Round(Span2D<float> matrix, int rows, int columns, int accuracy)
        {
            var Result = new float[rows, columns];
            if (accuracy < 15)
            {
                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < columns; j++)
                    {
                        Result[i, j] = MathF.Round(matrix[i, j], accuracy);
                    }
                }
            }
            else
            {
                Result = CopyMatrix(matrix, rows, columns);
            }

            return Result;
        }

        /// <summary>
        /// Rounds the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Round(Span2D<double> matrix, int rows, int columns, int accuracy)
        {
            var Result = new double[rows, columns];
            if (accuracy < 15)
            {
                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < columns; j++)
                    {
                        Result[i, j] = Math.Round(matrix[i, j], accuracy);
                    }
                }
            }
            else
            {
                Result = CopyMatrix(matrix, rows, columns);
            }

            return Result;
        }
        #endregion

        #region Positive
        /// <summary>
        /// Applies the plus operator to the specified augend.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Plus(Span2D<float> augend)
        {
            if (augend == null) return null;
            var p = augend.Height;
            var q = augend.Width;
            var result = new float[p, q];
            for (var i = 0; i < p; i++)
            {
                for (var j = 0; j < q; j++)
                {
                    result[i, j] = +augend[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Applies the plus operator to the specified augend.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Plus(Span2D<double> augend)
        {
            if (augend == null) return null;
            var rows = augend.Height;
            var cols = augend.Width;
            var result = new double[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    result[i, j] = +augend[i, j];
                }
            }

            return result;
        }
        #endregion

        #region Addition
        /// <summary>
        /// Adds the specified augend.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <param name="addend">The addend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Add(Span2D<float> augend, Span2D<float> addend)
        {
            if (augend == null) return addend.ToArray();
            if (addend == null) return augend.ToArray();
            var m = augend.Height;
            var n = augend.Width;
            var result = new float[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    result[i, j] = augend[i, j] + addend[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Adds the specified augend.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <param name="addend">The addend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Add(Span2D<double> augend, Span2D<double> addend)
        {
            if (augend == null) return addend.ToArray();
            if (addend == null) return augend.ToArray();
            var m = augend.Height;
            var n = augend.Width;
            var result = new double[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    result[i, j] = augend[i, j] + addend[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Adds the two matrices.
        /// </summary>
        /// <param name="augend">The matrix1.</param>
        /// <param name="addend">The matrix2.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Add(Span2D<float> augend, Span2D<float> addend, int accuracy)
        {
            if (augend == null) return addend.ToArray();
            if (addend == null) return augend.ToArray();
            var m = augend.Height;
            var n = augend.Width;
            var result = new float[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    result[i, j] = augend[i, j] + addend[i, j];
                }
            }

            return Round(result, m, n, accuracy);
        }

        /// <summary>
        /// Adds the two matrices.
        /// </summary>
        /// <param name="augend">The matrix1.</param>
        /// <param name="addend">The matrix2.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Add(Span2D<double> augend, Span2D<double> addend, int accuracy)
        {
            if (augend == null) return addend.ToArray();
            if (addend == null) return augend.ToArray();
            var m = augend.Height;
            var n = augend.Width;
            var result = new double[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    result[i, j] = augend[i, j] + addend[i, j];
                }
            }

            return Round(result, m, n, accuracy);
        }

        /// <summary>
        /// Adds the two matrices.
        /// </summary>
        /// <param name="augend">The matrix1.</param>
        /// <param name="addend">The matrix2.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Add(Span2D<float> augend, Span2D<float> addend, int rows, int columns)
        {
            if (augend == null) return addend.ToArray();
            if (addend == null) return augend.ToArray();
            var result = new float[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = augend[i, j] + addend[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Adds the two matrices.
        /// </summary>
        /// <param name="augend">The matrix1.</param>
        /// <param name="addend">The matrix2.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Add(Span2D<double> augend, Span2D<double> addend, int rows, int columns)
        {
            if (augend == null) return addend.ToArray();
            if (addend == null) return augend.ToArray();
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = augend[i, j] + addend[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Adds the two matrices.
        /// </summary>
        /// <param name="augend">The matrix1.</param>
        /// <param name="addend">The matrix2.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Add(Span2D<float> augend, Span2D<float> addend, int rows, int columns, int accuracy)
        {
            if (augend == null) return addend.ToArray();
            if (addend == null) return augend.ToArray();
            var result = new float[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = augend[i, j] + addend[i, j];
                }
            }

            return Round(result, rows, columns, accuracy);
        }

        /// <summary>
        /// Adds the two matrices.
        /// </summary>
        /// <param name="augend">The matrix1.</param>
        /// <param name="addend">The matrix2.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Add(Span2D<double> augend, Span2D<double> addend, int rows, int columns, int accuracy)
        {
            if (augend == null) return addend.ToArray();
            if (addend == null) return augend.ToArray();
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = augend[i, j] + addend[i, j];
                }
            }

            return Round(result, rows, columns, accuracy);
        }

        /// <summary>
        /// Sums the two matrices eigen vectors edition.
        /// </summary>
        /// <param name="augend">The matrix1.</param>
        /// <param name="addend">The matrix2.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] AddEigenVectorMatrices(Span2D<float> augend, Span2D<float> addend, int rows, int columns)
        {
            if (augend == null) return addend.ToArray();
            if (addend == null) return augend.ToArray();
            var result = new float[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns - 1; j++)
                {
                    result[i, j] = augend[i, j] + addend[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Sums the two matrices eigen vectors edition.
        /// </summary>
        /// <param name="augend">The matrix1.</param>
        /// <param name="addend">The matrix2.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] AddEigenVectorMatrices(Span2D<double> augend, Span2D<double> addend, int rows, int columns)
        {
            if (augend == null) return addend.ToArray();
            if (addend == null) return augend.ToArray();
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns - 1; j++)
                {
                    result[i, j] = augend[i, j] + addend[i, j];
                }
            }

            return result;
        }
        #endregion

        #region Negation
        /// <summary>
        /// Applies the plus operator to the specified augend.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Negate(Span2D<float> augend)
        {
            var p = augend.Height;
            var q = augend.Width;
            var result = new float[p, q];
            for (var i = 0; i < p; i++)
            {
                for (var j = 0; j < q; j++)
                {
                    result[i, j] = -augend[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Applies the plus operator to the specified augend.
        /// </summary>
        /// <param name="augend">The augend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Negate(Span2D<double> augend)
        {
            var rows = augend.Height;
            var cols = augend.Width;
            var result = new double[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    result[i, j] = -augend[i, j];
                }
            }

            return result;
        }
        #endregion

        #region Subtraction
        /// <summary>
        /// Subtracts the specified minuend.
        /// </summary>
        /// <param name="minuend">The minuend.</param>
        /// <param name="subtrahend">The subtrahend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Subtract(Span2D<float> minuend, Span2D<float> subtrahend)
        {
            if (minuend == null) return subtrahend.ToArray();
            if (subtrahend == null) return minuend.ToArray();
            var m = minuend.Height;
            var n = minuend.Width;
            var result = new float[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    result[i, j] = minuend[i, j] - subtrahend[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Subtracts the specified minuend.
        /// </summary>
        /// <param name="minuend">The minuend.</param>
        /// <param name="subtrahend">The subtrahend.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Subtract(Span2D<double> minuend, Span2D<double> subtrahend)
        {
            if (minuend == null) return subtrahend.ToArray();
            if (subtrahend == null) return minuend.ToArray();
            var m = minuend.Height;
            var n = minuend.Width;
            var result = new double[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    result[i, j] = minuend[i, j] - subtrahend[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Subtracts the matrix.
        /// </summary>
        /// <param name="minuend">The matrix1.</param>
        /// <param name="subtrahend">The matrix2.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] SubtractMatrix(Span2D<double> minuend, Span2D<double> subtrahend)
        {
            var m = minuend.Height;
            var n = minuend.Width;
            var p = subtrahend.Height;
            var q = subtrahend.Width;
            if (m != p || n != q) return new double[1, 1];
            var l = Math.Min(m, p);
            var c = Math.Min(n, q);
            var result = new double[l, c];
            for (var i = 0; i < l; i++)
            {
                for (var j = 0; j < c; j++)
                {
                    result[i, j] = minuend[i, j] - subtrahend[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="minuend">The matrix1.</param>
        /// <param name="subtrahend">The matrix2.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Subtract(Span2D<float> minuend, Span2D<float> subtrahend, int accuracy)
        {
            if (minuend == null) return subtrahend.ToArray();
            if (subtrahend == null) return minuend.ToArray();

            var m = minuend.Height;
            var n = minuend.Width;
            var result = new float[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    result[i, j] = minuend[i, j] - subtrahend[i, j];
                }
            }

            return Round(result, m, n, accuracy);
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="minuend">The matrix1.</param>
        /// <param name="subtrahend">The matrix2.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Subtract(Span2D<double> minuend, Span2D<double> subtrahend, int accuracy)
        {
            if (minuend == null) return subtrahend.ToArray();
            if (subtrahend == null) return minuend.ToArray();
            var rows = minuend.Height;
            var columns = minuend.Width;
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = minuend[i, j] - subtrahend[i, j];
                }
            }

            return Round(result, rows, columns, accuracy);
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="minuend">The matrix1.</param>
        /// <param name="subtrahend">The matrix2.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Subtract(Span2D<float> minuend, Span2D<float> subtrahend, int rows, int columns)
        {
            if (minuend == null) return subtrahend.ToArray();
            if (subtrahend == null) return minuend.ToArray();
            var result = new float[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = minuend[i, j] - subtrahend[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="minuend">The matrix1.</param>
        /// <param name="subtrahend">The matrix2.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Subtract(Span2D<double> minuend, Span2D<double> subtrahend, int rows, int columns)
        {
            if (minuend == null) return subtrahend.ToArray();
            if (subtrahend == null) return minuend.ToArray();
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = minuend[i, j] - subtrahend[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="minuend">The matrix1.</param>
        /// <param name="subtrahend">The matrix2.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Subtract(Span2D<float> minuend, Span2D<float> subtrahend, int rows, int columns, int accuracy)
        {
            if (minuend == null) return subtrahend.ToArray();
            if (subtrahend == null) return minuend.ToArray();
            var result = new float[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = minuend[i, j] - subtrahend[i, j];
                }
            }

            return Round(result, rows, columns, accuracy);
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="minuend">The matrix1.</param>
        /// <param name="subtrahend">The matrix2.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Subtract(Span2D<double> minuend, Span2D<double> subtrahend, int rows, int columns, int accuracy)
        {
            if (minuend == null) return subtrahend.ToArray();
            if (subtrahend == null) return minuend.ToArray();
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = minuend[i, j] - subtrahend[i, j];
                }
            }

            return Round(result, rows, columns, accuracy);
        }
        #endregion

        #region Scale
        /// <summary>
        /// Multiplies the specified multiplicand by a scalar.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Scale(float multiplicand, Span2D<float> multiplier)
        {
            var p = multiplier.Height;
            var q = multiplier.Width;
            var result = new float[p, q];
            for (var i = 0; i < p; i++)
            {
                for (var j = 0; j < q; j++)
                {
                    result[i, j] = multiplicand * multiplier[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies the specified multiplier by a scalar.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Scale(double multiplicand, Span2D<double> multiplier)
        {
            var m = multiplier.Height;
            var n = multiplier.Width;
            var result = new double[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    result[i, j] = multiplicand * multiplier[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Matrix multiplications by scalar.
        /// </summary>
        /// <param name="multiplicand">The scalar.</param>
        /// <param name="multiplier">The matrix.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Scale(double multiplicand, Span2D<double> multiplier, int accuracy)
        {
            var rows = multiplier.Height;
            var columns = multiplier.Width;
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = multiplicand * multiplier[i, j];
                }
            }

            return Round(result, rows, columns, accuracy);
        }

        /// <summary>
        /// Matrix multiplications by scalar.
        /// </summary>
        /// <param name="multiplicand">The scalar.</param>
        /// <param name="multiplier">The matrix.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Scale(double multiplicand, Span2D<double> multiplier, int rows, int columns)
        {
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = multiplicand * multiplier[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Matrix multiplications by scalar.
        /// </summary>
        /// <param name="scalar">The scalar.</param>
        /// <param name="multiplier">The matrix.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Scale(double scalar, Span2D<double> multiplier, int rows, int columns, int accuracy)
        {
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = scalar * multiplier[i, j];
                }
            }

            return Round(result, rows, columns, accuracy);
        }

        /// <summary>
        /// Multiplies the specified multiplicand by a scalar.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Scale(Span2D<float> multiplicand, float multiplier)
        {
            var m = multiplicand.Height;
            var n = multiplicand.Width;

            var result = new float[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    result[i, j] = multiplicand[i, j] * multiplier;
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies the specified multiplicand by a scalar.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Scale(Span2D<double> multiplicand, double multiplier)
        {
            var m = multiplicand.Height;
            var n = multiplicand.Width;
            var result = new double[m, n];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    result[i, j] = multiplicand[i, j] * multiplier;
                }
            }

            return result;
        }
        #endregion Scale

        #region Multiply
        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] Multiply(Span<float> multiplicand, Span2D<float> multiplier)
        {
            var n = multiplicand.Length;
            var p = multiplier.Height;
            var q = multiplier.Width;
            if (n != p) throw new Exception("Columns of multiplicand must be the same length as the rows of multiplier.");
            var result = new float[n];
            for (var j = 0; j < q; j++)
            {
                result[j] = 0;
                for (var k = 0; k < n; k++)
                {
                    result[j] += multiplicand[j] * multiplier[k, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] Multiply(Span<double> multiplicand, Span2D<double> multiplier)
        {
            var n = multiplicand.Length;
            var p = multiplier.Height;
            var q = multiplier.Width;
            if (n != p) throw new Exception("Columns of multiplicand must be the same length as the rows of multiplier.");
            var result = new double[n];
            for (var j = 0; j < q; j++)
            {
                result[j] = 0;
                for (var k = 0; k < n; k++)
                {
                    result[j] += multiplicand[j] * multiplier[k, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies the specified multiplicand.
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] Multiply(Span2D<double> multiplicand, Span<double> multiplier)
        {
            var m = multiplicand.Height;
            var n = multiplicand.Width;
            var p = multiplier.Length;
            if (n != p) throw new Exception("Columns of multiplicand must be the same length as the rows of multiplier.");
            var result = new double[m];
            for (var i = 0; i < m; i++)
            {
                result[i] = 0;
                for (var k = 0; k < n; k++)
                {
                    result[i] += multiplicand[i, k] * multiplier[k];
                }
            }

            return result;
        }

        /// <summary>
        /// Matrix vs Vector Multiplication, internal usage.
        /// </summary>
        /// <param name="multiplicand">The matrix.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="multiplier">The vector.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[] Multiply(Span2D<double> multiplicand, int rows, int columns, double[] multiplier, int length)
        {
            var result = new double[rows];
            for (var i = 0; i < rows; i++)
            {
                result[i] = 0;
                for (var k = 0; k < columns; k++)
                {
                    result[i] = result[i] + multiplicand[i, k] * multiplier[k];
                }
            }

            return result;
        }

        /// <summary>
        /// Linear algebraic matrix multiplication, A * B
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.codeproject.com/Articles/5835/DotNetMatrix-Simple-Matrix-Library-for-NET
        /// https://www.tutorialspoint.com/chash-program-to-multiply-two-matrices
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Multiply(Span2D<float> multiplicand, Span2D<float> multiplier)
        {
            var m = multiplicand.Height;
            var n = multiplicand.Width;
            var p = multiplier.Height;
            var q = multiplier.Width;
            if (n != p) throw new Exception("Columns of multiplicand must be the same length as the rows of multiplier.");
            var result = new float[m, q];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < q; j++)
                {
                    var s = 0f;
                    for (var k = 0; k < n; k++)
                    {
                        s += multiplicand[i, k] * multiplier[k, j];
                    }

                    result[i, j] = s;
                }
            }

            return result;
        }

        /// <summary>
        /// Linear algebraic matrix multiplication, A * B
        /// </summary>
        /// <param name="multiplicand">The multiplicand.</param>
        /// <param name="multiplier">The multiplier.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
        /// <acknowledgment>
        /// https://www.codeproject.com/Articles/5835/DotNetMatrix-Simple-Matrix-Library-for-NET
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs
        /// https://www.tutorialspoint.com/chash-program-to-multiply-two-matrices
        /// https://www.geeksforgeeks.org/different-operation-matrices/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Multiply(Span2D<double> multiplicand, Span2D<double> multiplier)
        {
            var m = multiplicand.Height;
            var n = multiplicand.Width;
            var p = multiplier.Height;
            var q = multiplier.Width;
            if (n != p) throw new Exception("Columns of multiplicand must be the same length as the rows of multiplier.");
            var result = new double[m, q];
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < q; j++)
                {
                    var s = 0d;
                    for (var k = 0; k < n; k++)
                    {
                        s += multiplicand[i, k] * multiplier[k, j];
                    }

                    result[i, j] = s;
                }
            }

            return result;
        }

        /// <summary>
        /// Multiply + Multiplication by scalar, accuracy needed.
        /// </summary>
        /// <param name="multiplicand">The matrix1.</param>
        /// <param name="multiplier">The matrix2.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] MatrixMatrixScalarMultiplication(Span2D<double> multiplicand, Span2D<double> multiplier)
        {
            var rows1 = multiplicand.Height;
            var columns1 = multiplicand.Width;
            var rows2 = multiplier.Height;
            var columns2 = multiplier.Width;
            var scalar_multiplication = false;
            if (rows1 == 1 && columns1 == 1 || rows2 == 1 && columns2 == 1)
            {
                scalar_multiplication = true;
            }

            int res_rows;
            int res_columns;
            double[,] result;
            if (scalar_multiplication)
            {
                double scalar;
                if (rows1 == 1 && columns1 == 1)
                {
                    scalar = multiplicand[0, 0];
                    res_rows = rows2;
                    res_columns = columns2;
                    result = CopyMatrix(multiplier, res_rows, res_columns);
                }
                else
                {
                    scalar = multiplier[0, 0];
                    res_rows = rows1;
                    res_columns = columns1;
                    result = CopyMatrix(multiplicand, res_rows, res_columns);
                }

                for (var i = 0; i < res_rows; i++)
                {
                    for (var j = 0; j < res_columns; j++)
                    {
                        result[i, j] = scalar * result[i, j];
                    }
                }
            }
            else // normal 2 matrix multiplication 
            {
                res_rows = rows1;
                res_columns = columns2;
                result = new double[res_rows, res_columns];
                for (var i = 0; i < rows1; i++)
                {
                    for (var j = 0; j < columns2; j++)
                    {
                        result[i, j] = 0;
                        for (var k = 0; k < columns1; k++)
                        {
                            result[i, j] += multiplicand[i, k] * multiplier[k, j];
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Multiply + Multiplication by scalar, accuracy needed.
        /// </summary>
        /// <param name="multiplicand">The matrix1.</param>
        /// <param name="multiplier">The matrix2.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] MatrixMatrixScalarMultiplication(Span2D<double> multiplicand, Span2D<double> multiplier, int accuracy)
        {
            var rows1 = multiplicand.Height;
            var columns1 = multiplicand.Width;
            var rows2 = multiplier.Height;
            var columns2 = multiplier.Width;
            var scalar_multiplication = false;
            if (rows1 == 1 && columns1 == 1 || rows2 == 1 && columns2 == 1)
            {
                scalar_multiplication = true;
            }

            int res_rows;
            int res_columns;
            double[,] result;
            if (scalar_multiplication)
            {
                double scalar;
                if (rows1 == 1 && columns1 == 1)
                {
                    scalar = multiplicand[0, 0];
                    res_rows = rows2;
                    res_columns = columns2;
                    result = CopyMatrix(multiplier, res_rows, res_columns);
                }
                else
                {
                    scalar = multiplier[0, 0];
                    res_rows = rows1;
                    res_columns = columns1;
                    result = CopyMatrix(multiplicand, res_rows, res_columns);
                }

                for (var i = 0; i < res_rows; i++)
                {
                    for (var j = 0; j < res_columns; j++)
                    {
                        result[i, j] = scalar * result[i, j];
                    }
                }
            }
            else // normal 2 matrix multiplication 
            {
                res_rows = rows1;
                res_columns = columns2;
                result = new double[res_rows, res_columns];
                for (var i = 0; i < rows1; i++)
                {
                    for (var j = 0; j < columns2; j++)
                    {
                        result[i, j] = 0;
                        for (var k = 0; k < columns1; k++)
                        {
                            result[i, j] += multiplicand[i, k] * multiplier[k, j];
                        }
                    }
                }
            }

            return Round(result, accuracy);
        }

        /// <summary>
        /// Multiply + Multiplication by scalar, accuracy needed.
        /// </summary>
        /// <param name="multiplicand">The matrix1.</param>
        /// <param name="rows1">The rows1.</param>
        /// <param name="columns1">The columns1.</param>
        /// <param name="multiplier">The matrix2.</param>
        /// <param name="rows2">The rows2.</param>
        /// <param name="columns2">The columns2.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] MatrixMatrixScalarMultiplication(Span2D<double> multiplicand, int rows1, int columns1, Span2D<double> multiplier, int rows2, int columns2)
        {
            var scalar_multiplication = false;
            if (rows1 == 1 && columns1 == 1 || rows2 == 1 && columns2 == 1)
            {
                scalar_multiplication = true;
            }

            int res_rows;
            int res_columns;
            double[,] result;
            if (scalar_multiplication)
            {
                double scalar;
                if (rows1 == 1 && columns1 == 1)
                {
                    scalar = multiplicand[0, 0];
                    res_rows = rows2;
                    res_columns = columns2;
                    result = CopyMatrix(multiplier, res_rows, res_columns);
                }
                else
                {
                    scalar = multiplier[0, 0];
                    res_rows = rows1;
                    res_columns = columns1;
                    result = CopyMatrix(multiplicand, res_rows, res_columns);
                }

                for (var i = 0; i < res_rows; i++)
                {
                    for (var j = 0; j < res_columns; j++)
                    {
                        result[i, j] = scalar * result[i, j];
                    }
                }
            }
            else // normal 2 matrix multiplication 
            {
                res_rows = rows1;
                res_columns = columns2;
                result = new double[res_rows, res_columns];
                for (var i = 0; i < rows1; i++)
                {
                    for (var j = 0; j < columns2; j++)
                    {
                        result[i, j] = 0;
                        for (var k = 0; k < columns1; k++)
                        {
                            result[i, j] += multiplicand[i, k] * multiplier[k, j];
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Multiply + Multiplication by scalar, accuracy needed.
        /// </summary>
        /// <param name="multiplicand">The matrix1.</param>
        /// <param name="rows1">The rows1.</param>
        /// <param name="columns1">The columns1.</param>
        /// <param name="multiplier">The matrix2.</param>
        /// <param name="rows2">The rows2.</param>
        /// <param name="columns2">The columns2.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] MatrixMatrixScalarMultiplication(Span2D<double> multiplicand, int rows1, int columns1, Span2D<double> multiplier, int rows2, int columns2, int accuracy)
        {
            var scalar_multiplication = false;
            if (rows1 == 1 && columns1 == 1 || rows2 == 1 && columns2 == 1)
            {
                scalar_multiplication = true;
            }

            int res_rows;
            int res_columns;
            double[,] result;
            if (scalar_multiplication)
            {
                double scalar;
                if (rows1 == 1 && columns1 == 1)
                {
                    scalar = multiplicand[0, 0];
                    res_rows = rows2;
                    res_columns = columns2;
                    result = CopyMatrix(multiplier, res_rows, res_columns);
                }
                else
                {
                    scalar = multiplier[0, 0];
                    res_rows = rows1;
                    res_columns = columns1;
                    result = CopyMatrix(multiplicand, res_rows, res_columns);
                }

                for (var i = 0; i < res_rows; i++)
                {
                    for (var j = 0; j < res_columns; j++)
                    {
                        result[i, j] = scalar * result[i, j];
                    }
                }
            }
            else // normal 2 matrix multiplication 
            {
                res_rows = rows1;
                res_columns = columns2;
                result = new double[res_rows, res_columns];
                for (var i = 0; i < rows1; i++)
                {
                    for (var j = 0; j < columns2; j++)
                    {
                        result[i, j] = 0;
                        for (var k = 0; k < columns1; k++)
                        {
                            result[i, j] += multiplicand[i, k] * multiplier[k, j];
                        }
                    }
                }
            }

            return Round(result, res_rows, res_columns, accuracy);
        }
        #endregion Multiply
    }
}
