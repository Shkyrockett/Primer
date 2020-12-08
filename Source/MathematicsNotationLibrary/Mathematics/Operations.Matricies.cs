// <copyright file="Operations.Matricies.Arrangements.Array.cs" company="Shkyrockett" >
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
        #region Matrix Copy
        /// <summary>
        /// Copies the matrix.
        /// </summary>
        /// <param name="originalMatrix">The original matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static float[,] CopyMatrix(Span2D<float> originalMatrix)
        {
            var rows = originalMatrix.Height;
            var columns = originalMatrix.Width;
            var result = new float[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = originalMatrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Copies the matrix.
        /// </summary>
        /// <param name="originalMatrix">The original matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[,] CopyMatrix(Span2D<double> originalMatrix)
        {
            var rows = originalMatrix.Height;
            var columns = originalMatrix.Width;
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = originalMatrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Copies the matrix.
        /// </summary>
        /// <param name="original_matrix">The original matrix.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static float[,] CopyMatrix(Span2D<float> original_matrix, int rows, int columns)
        {
            var result = new float[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = original_matrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Copies the matrix.
        /// </summary>
        /// <param name="original_matrix">The original matrix.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[,] CopyMatrix(Span2D<double> original_matrix, int rows, int columns)
        {
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = original_matrix[i, j];
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
        public static double[,] VectorToSingleRowMatrix(Span<double> vector)
        {
            var Result = new double[1, vector.Length];
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
        public static double[,] VectorToSingleRowMatrix(Span<double> vector, int length)
        {
            var Result = new double[1, length];
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
        public static double[,] VectorToSingleColumnMatrix(Span<double> vector)
        {
            var Result = new double[vector.Length, 1];
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
        public static double[,] VectorToSingleColumnMatrix(Span<double> vector, int length)
        {
            var Result = new double[length, 1];
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
        public static double[] SingleRowMatrixToVector(Span2D<double> matrix, int columns)
        {
            var Result = new double[columns];
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
        public static double[] SingleColumnMatrixToVector(Span2D<double> matrix, int rows)
        {
            var Result = new double[rows];
            for (var i = 0; i < rows; i++)
            {
                Result[i] = matrix[i, 0];
            }

            return Result;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Truncate(Span2D<float> matrix, int rowStart, int rowEnd, int columnStart, int columnEnd)
        {
            var rows = matrix.Height;
            var cols = matrix.Width;

            var minimumIndex = rowStart == 0 || rowEnd == 0 || columnStart == 0 || columnEnd == 0;
            var coherenceIndex = rowEnd < rowStart || columnEnd < columnStart;
            var boundIndex = rowEnd > rows || columnEnd > cols;

            if (minimumIndex || coherenceIndex || boundIndex)
            {
                return new float[1, 1];
            }

            var result = new float[rowEnd - rowStart + 1, columnEnd - columnStart + 1];

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Truncate(Span2D<double> matrix, int rowStart, int rowEnd, int columnStart, int columnEnd)
        {
            var rows = matrix.Height;
            var cols = matrix.Width;

            var minimumIndex = rowStart == 0 || rowEnd == 0 || columnStart == 0 || columnEnd == 0;
            var coherenceIndex = rowEnd < rowStart || columnEnd < columnStart;
            var boundIndex = rowEnd > rows || columnEnd > cols;

            if (minimumIndex || coherenceIndex || boundIndex)
            {
                return new double[1, 1];
            }

            var result = new double[rowEnd - rowStart + 1, columnEnd - columnStart + 1];

            for (var i = rowStart - 1; i < rowEnd; i++)
            {
                for (var j = columnStart - 1; j < columnEnd; j++)
                {
                    result[i - rowStart + 1, j - columnStart + 1] = matrix[i, j];
                }
            }

            return result;
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Transpose(Span2D<double> matrix)
        {
            var rows = matrix.Height;
            var cols = matrix.Width;
            var result = new double[cols, rows];
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
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Transpose(Span2D<double> matrix, int accuracy)
        {
            var rows = matrix.Height;
            var columns = matrix.Width;
            var result = new double[columns, rows];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = matrix[j, i];
                    //result[j, i] = matrix[i, j];
                }
            }

            return Round(result, accuracy);
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
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Transpose(Span2D<double> matrix, int rows, int columns, int accuracy)
        {
            var result = new double[columns, rows];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = matrix[j, i];
                    //result[j, i] = matrix[i, j];
                }
            }

            return Round(result, columns, rows, accuracy);
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SwapRows(Span2D<float> matrix, int row1, int row2)
        {
            var columns = matrix.Width;
            var temp_row = new float[columns];
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
        /// <param name="row1">The row1.</param>
        /// <param name="row2">The row2.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static void SwapRows(Span2D<double> matrix, int row1, int row2)
        {
            var columns = matrix.Width;
            var temp_row = new double[columns];
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
        public static void SwapRows(Span2D<float> matrix, int rows, int columns, int row1, int row2)
        {
            var temp_row = new float[columns];
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
        public static void SwapRows(Span2D<double> matrix, int rows, int columns, int row1, int row2)
        {
            var temp_row = new double[columns];
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
        public static void SwapColumns(Span2D<float> matrix, int column1, int column2)
        {
            var rows = matrix.Height;
            var temp_column = new float[rows];
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
        /// <param name="column1">The column1.</param>
        /// <param name="column2">The column2.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static void SwapColumns(Span2D<double> matrix, int column1, int column2)
        {
            var rows = matrix.Height;
            var temp_column = new double[rows];
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
        public static void SwapColumns(Span2D<float> matrix, int rows, int columns, int column1, int column2)
        {
            var temp_column = new float[rows];
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
        public static void SwapColumns(Span2D<double> matrix, int rows, int columns, int column1, int column2)
        {
            var temp_column = new double[rows];
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
        public static float[,] ConcatenationColumns(Span2D<float> matrix1, Span2D<float> matrix2)
        {
            var rows1 = matrix1.Height;
            var cols1 = matrix1.Width;
            var rows2 = matrix2.Height;
            var cols2 = matrix2.Width;
            if (rows1 != rows2) return new float[1, 1];

            var results = new float[rows1, cols1 + cols2];
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

        /// <summary>
        /// Concatenation of matrices by columns
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L100
        /// </acknowledgment>
        public static double[,] ConcatenationColumns(Span2D<double> matrix1, Span2D<double> matrix2)
        {
            var rows1 = matrix1.Height;
            var cols1 = matrix1.Width;
            var rows2 = matrix2.Height;
            var cols2 = matrix2.Width;
            if (rows1 != rows2) return new double[1, 1];

            var results = new double[rows1, cols1 + cols2];
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
        public static double[,] MergeMatricesHorizontally(Span2D<double> matrix1, Span2D<double> matrix2)
        {
            var rows1 = matrix1.Height;
            var columns1 = matrix1.Width;
            var rows2 = matrix2.Height;
            var columns2 = matrix2.Width;
            var matrix2_columns = 0;
            var result = new double[rows1, columns1 + columns2];
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
        public static double[,] MergeMatricesHorizontally(Span2D<double> matrix1, int rows1, int columns1, Span2D<double> matrix2, int columns2)
        {
            var matrix2_columns = 0;
            var result = new double[rows1, columns1 + columns2];
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
        public static (int rows, int columns, double[,] matrix) MergeMatricesVertically(Span2D<double> matrix1, Span2D<double> matrix2)
        {
            var rows1 = matrix1.Height;
            var columns1 = matrix1.Width;
            var rows2 = matrix2.Height;
            var columns2 = matrix2.Width;
            var result_rows = rows1 + rows2;
            var result = new double[rows1 + rows2, columns1];
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
        public static (int rows, int columns, double[,] matrix) MergeMatricesVertically(Span2D<double> matrix1, int rows1, int columns1, Span2D<double> matrix2, int rows2)
        {
            var result_rows = rows1 + rows2;
            var result = new double[rows1 + rows2, columns1];
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
        public static double[,] ExtractPartOfMatrix(Span2D<double> matrix, int beginning_row, int ending_row, int beginning_column, int ending_column)
        {
            var rows_total = matrix.Height;
            var columns_total = matrix.Width;
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

            var the_result = new double[ending_row - beginning_row + 1, ending_column - beginning_column + 1];
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
        public static double[,] ExtractPartOfMatrix(Span2D<double> whole_matrix, int rows_total, int columns_total, int beginning_row, int ending_row, int beginning_column, int ending_column)
        {
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

            var the_result = new double[ending_row - beginning_row + 1, ending_column - beginning_column + 1];
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

        #region Diagonalize Matrix
        /// <summary>
        /// Diagonalizes the matrix.
        /// Atr. * A
        /// </summary>
        /// <param name="originalMatrix">The original matrix.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[,] DiagonalizeMatrix(Span2D<double> originalMatrix, int accuracy) => MatrixMatrixScalarMultiplication(Transpose(originalMatrix, accuracy), originalMatrix, accuracy);

        /// <summary>
        /// Diagonalizes the matrix.
        /// Atr. * A
        /// </summary>
        /// <param name="originalMatrix">The original matrix.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[,] DiagonalizeMatrix(Span2D<double> originalMatrix, int rows, int columns, int accuracy) => MatrixMatrixScalarMultiplication(Transpose(originalMatrix, rows, columns, accuracy), columns, rows, originalMatrix, rows, columns, accuracy);
        #endregion

        /// <summary>
        /// Rotates the matrix clockwise.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/18035050
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] RotateMatrixClockwise(Span2D<double> matrix)
        {
            var m = matrix.Height;
            var n = matrix.Width;
            var result = new double[n, m];
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    result[i, j] = matrix[n - j - 1, i];
                }
            }

            return result;
        }

        /// <summary>
        /// Rotates the matrix counter clockwise.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://stackoverflow.com/a/18035050
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] RotateMatrixCounterClockwise(Span2D<double> matrix)
        {
            var m = matrix.Height;
            var n = matrix.Width;
            var result = new double[n, m];
            for (var i = 0; i < n; ++i)
            {
                for (var j = 0; j < n; ++j)
                {
                    result[i, j] = matrix[j, n - i - 1];
                }
            }

            return result;
        }
    }
}
