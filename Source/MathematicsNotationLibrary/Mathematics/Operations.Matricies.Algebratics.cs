// <copyright file="Operations.Matricies.Algebratics.Array.cs" company="Shkyrockett" >
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
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// The Operations class.
    /// </summary>
    public static partial class Operations
    {
        #region Adjoint
        /// <summary>
        /// Function to get adjoint of the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Adjoint(Span2D<float> matrix)
        {
            var rows = matrix.Height;
            var cols = matrix.Width;

            if (rows == 1)
            {
                return new float[1, 1] { { 1f } };
            }

            var adj = new float[rows, cols];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    // Get cofactor of A[i,j] 
                    var temp = Cofactor(matrix, i, j);

                    // Sign of adj[j,i] positive if sum of row and column indexes is even. 
                    var sign = ((i + j) % 2f == 0f) ? 1f : -1f;

                    // Interchanging rows and columns to get the  transpose of the cofactor matrix 
                    adj[j, i] = sign * Determinant(temp);
                }
            }

            return adj;
        }

        /// <summary>
        /// Function to get adjoint of the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Adjoint(Span2D<double> matrix)
        {
            var rows = matrix.Height;
            var cols = matrix.Width;

            if (rows == 1)
            {
                return new double[1, 1] { { 1d } };
            }

            var adj = new double[rows, cols];

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    // Get cofactor of A[i,j] 
                    var temp = Cofactor(matrix, i, j);

                    // Sign of adj[j,i] positive if sum of row and column indexes is even. 
                    var sign = ((i + j) % 2d == 0d) ? 1d : -1d;

                    // Interchanging rows and columns to get the  transpose of the cofactor matrix 
                    adj[j, i] = sign * Determinant(temp);
                }
            }

            return adj;
        }
        #endregion Adjoint

        #region Cofactor
        /// <summary>
        /// Cofactors the specified a.
        /// </summary>
        /// <param name="matrix">a.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Cofactor(Span2D<float> matrix)
        {
            var i = 0;
            var j = 0;
            var rows = matrix.Height;
            var cols = matrix.Width;
            var temp = new float[rows, cols];

            // Looping for each element of the matrix 
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    temp[i, j++] = matrix[row, col];

                    // Row is filled, so increase row index and 
                    // reset col index 
                    if (j == cols - 1)
                    {
                        j = 0;
                        i++;
                    }
                }
            }

            return temp;
        }

        /// <summary>
        /// Cofactors the specified a.
        /// </summary>
        /// <param name="matrix">a.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Cofactor(Span2D<double> matrix)
        {
            var i = 0;
            var j = 0;
            var rows = matrix.Height;
            var cols = matrix.Width;
            var temp = new double[rows, cols];

            // Looping for each element of the matrix 
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    temp[i, j++] = matrix[row, col];

                    // Row is filled, so increase row index and 
                    // reset col index 
                    if (j == cols - 1)
                    {
                        j = 0;
                        i++;
                    }
                }
            }

            return temp;
        }

        /// <summary>
        /// Cofactors the specified a.
        /// </summary>
        /// <param name="matrix">a.</param>
        /// <param name="p">The p.</param>
        /// <param name="q">The q.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Cofactor(Span2D<float> matrix, int p, int q)
        {
            var i = 0;
            var j = 0;
            var rows = matrix.Height;
            var cols = matrix.Width;
            var temp = new float[rows, cols];

            // Looping for each element of the matrix 
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    // Copying into temporary matrix only those element 
                    // which are not in given row and column 
                    if (row != p && col != q)
                    {
                        temp[i, j++] = matrix[row, col];

                        // Row is filled, so increase row index and 
                        // reset col index 
                        if (j == cols - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }

            return temp;
        }

        /// <summary>
        /// Cofactors the specified a.
        /// </summary>
        /// <param name="matrix">a.</param>
        /// <param name="p">The p.</param>
        /// <param name="q">The q.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Cofactor(Span2D<double> matrix, int p, int q)
        {
            var i = 0;
            var j = 0;
            var rows = matrix.Height;
            var cols = matrix.Width;
            var temp = new double[rows, cols];

            // Looping for each element of the matrix 
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    // Copying into temporary matrix only those element 
                    // which are not in given row and column 
                    if (row != p && col != q)
                    {
                        temp[i, j++] = matrix[row, col];

                        // Row is filled, so increase row index and 
                        // reset col index 
                        if (j == cols - 1)
                        {
                            j = 0;
                            i++;
                        }
                    }
                }
            }

            return temp;
        }
        #endregion Cofactor

        #region Inverse
        /// <summary>
        /// Trick: compute the inverse of a squared matrix using LU decomposition
        /// (LU)^-1 = U^-1 * L^-1
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Inverse(Span2D<float> matrix)
        {
            if (!IsSquareMatrix(matrix))
            {
                return new float[1, 1];
            }

            (var L, var U) = DecomposeToLowerUpper(matrix);

            var L_inv = InverseLowerMatrix(L);
            var U_inv = InverseUpperMatrix(U);

            return Multiply(U_inv, L_inv);
        }

        /// <summary>
        /// Trick: compute the inverse of a squared matrix using LU decomposition
        /// (LU)^-1 = U^-1 * L^-1
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Inverse(Span2D<double> matrix)
        {
            if (!IsSquareMatrix(matrix))
            {
                return new double[1, 1];
            }

            (var L, var U) = DecomposeToLowerUpper(matrix);

            var L_inv = InverseLowerMatrix(L);
            var U_inv = InverseUpperMatrix(U);

            return Multiply(U_inv, L_inv);
        }

        /// <summary>
        /// Function to calculate the inverse of the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Singular matrix, can't find its inverse</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] Inverse_Broken(Span2D<float> matrix)
        {
            // Find determinant of [,]A 
            var det = Determinant(matrix);
            if (det == 0)
                throw new Exception("Singular matrix, can't find its inverse");

            // Find adjoint 
            var adj = Adjoint(matrix);

            var rows = matrix.Height;
            var cols = matrix.Width;
            var inverse = new float[rows, cols];

            // Find Inverse using formula "inverse(A) = adj(A)/det(A)" 
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    inverse[i, j] = adj[i, j] / det;
                }
            }

            return inverse;
        }

        /// <summary>
        /// Function to calculate the inverse of the specified matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <exception cref="Exception">Singular matrix, can't find its inverse</exception>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Inverse_Broken(Span2D<double> matrix)
        {
            // Find determinant of [,]A 
            var det = Determinant(matrix);
            if (det == 0)
                throw new Exception("Singular matrix, can't find its inverse");

            // Find adjoint 
            var adj = Adjoint(matrix);

            var rows = matrix.Height;
            var cols = matrix.Width;
            var inverse = new double[rows, cols];

            // Find Inverse using formula "inverse(A) = adj(A)/det(A)" 
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    inverse[i, j] = adj[i, j] / det;
                }
            }

            return inverse;
        }
        #endregion Invert

        #region Inverse Lower Matrix
        /// <summary>
        /// compute and returns the inverse of a lower matrix
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] InverseLowerMatrix(Span2D<float> matrix)
        {
            if (!IsLowerMatrix(matrix))
            {
                return new float[1, 1];
            }

            var row = matrix.Height;
            var col = matrix.Width;
            var inv = new float[row, 1];

            for (var i = 0; i < row; i++)
            {
                var id = new float[row, 1];
                id[i, 0] = 1f;

                var vect = ResolveLinearEquationLowerTriangularMatrix(matrix, id);
                inv = ConcatenationColumns(inv, vect);
            }

            return Truncate(inv, 1, row, 2, col + 1);
        }

        /// <summary>
        /// compute and returns the inverse of a lower matrix
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] InverseLowerMatrix(Span2D<double> matrix)
        {
            if (!IsLowerMatrix(matrix))
            {
                return new double[1, 1];
            }

            var row = matrix.Height;
            var col = matrix.Width;
            var inv = new double[row, 1];

            for (var i = 0; i < row; i++)
            {
                var id = new double[row, 1];
                id[i, 0] = 1d;

                var vect = ResolveLinearEquationLowerTriangularMatrix(matrix, id);
                inv = ConcatenationColumns(inv, vect);
            }

            return Truncate(inv, 1, row, 2, col + 1);
        }
        #endregion

        #region Inverse Upper Matrix
        /// <summary>
        /// compute and returns the inverse of an upper matrix
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] InverseUpperMatrix(Span2D<float> matrix)
        {
            if (!IsUpperMatrix(matrix))
            {
                return new float[1, 1];
            }

            var row = matrix.Height;
            var col = matrix.Width;
            var inv = new float[row, 1];

            for (var i = 0; i < row; i++)
            {
                var id = new float[row, 1];
                id[i, 0] = 1f;

                var vect = ResolveLinearEquation_UpperTriangularMatrix(matrix, id);
                inv = ConcatenationColumns(inv, vect);
            }

            return Truncate(inv, 1, row, 2, col + 1);
        }

        /// <summary>
        /// compute and returns the inverse of an upper matrix
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] InverseUpperMatrix(Span2D<double> matrix)
        {
            if (!IsUpperMatrix(matrix))
            {
                return new double[1, 1];
            }

            var row = matrix.Height;
            var col = matrix.Width;
            var inv = new double[row, 1];

            for (var i = 0; i < row; i++)
            {
                var id = new double[row, 1];
                id[i, 0] = 1d;

                var vect = ResolveLinearEquation_UpperTriangularMatrix(matrix, id);
                inv = ConcatenationColumns(inv, vect);
            }

            return Truncate(inv, 1, row, 2, col + 1);
        }
        #endregion

        #region Determinant
        /// <summary>
        /// Recursive function for finding determinant of matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Determinant(Span2D<float> matrix)
        {
            var rows = matrix.Height;
            //var cols = matrix.GetLength(1);

            var result = 0f; // Initialize result 

            // Base case : if matrix contains single element 
            if (rows == 1)
                return matrix[0, 0];

            var sign = 1f; // To store sign multiplier 

            // Iterate for each element of first row 
            for (var f = 0; f < rows; f++)
            {
                // Getting Cofactor of A[0,f] 
                var temp = Cofactor(matrix, 0, f);
                result += sign * matrix[0, f] * Determinant(temp);

                // terms are to be added with alternate sign 
                sign = -sign;
            }

            return result;
        }

        /// <summary>
        /// Recursive function for finding determinant of matrix.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
        /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Determinant(Span2D<double> matrix)
        {
            var rows = matrix.Height;
            //var cols = matrix.GetLength(1);

            var result = 0d; // Initialize result 

            // Base case : if matrix contains single element 
            if (rows == 1)
                return matrix[0, 0];

            var sign = 1d; // To store sign multiplier 

            // Iterate for each element of first row 
            for (var f = 0; f < rows; f++)
            {
                // Getting Cofactor of A[0,f] 
                var temp = Cofactor(matrix, 0, f);
                result += sign * matrix[0, f] * Determinant(temp);

                // terms are to be added with alternate sign 
                sign = -sign;
            }

            return result;
        }
        #endregion Determinant

        #region Lerp
        /// <summary>
        /// Lerps the specified a.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Lerp(Span2D<double> a, Span2D<double> b, double amount)
        {
            var aRows = a.Height;
            var bRows = b.Height;
            var aCols = a.Width;
            var bCols = b.Width;
            if (aRows != bRows || aCols != bCols) throw new Exception();

            var results = new double[aRows, bRows];
            for (var i = 0; i < aRows; i++)
            {
                for (var j = 0; j < aCols; j++)
                {
                    results[i, j] = a[i, j] + ((b[i, j] - a[i, j]) * amount);
                }
            }

            return results;
        }
        #endregion

        #region Dot Product
        /// <summary>
        /// Dots the product.
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double DotProduct(Span2D<double> a, Span2D<double> b)
        {
            var rowsA = a.Height;
            var colsA = a.Width;
            var rowsB = b.Height;
            var colsB = b.Width;

            if (rowsA != rowsB || colsA != colsB) throw new Exception();

            double result = 0;
            for (var i = 0; i < rowsA; i++)
            {
                for (var j = 0; j < colsA; j++)
                {
                    result += a[i, j] * b[i, j];
                }
            }

            return result;
        }
        #endregion

        #region Decompose to Lower and Upper Matrices
        /// <summary>
        /// Compute LU decomposition on a squared matrix
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (float[,] Lower, float[,] Upper) DecomposeToLowerUpper(Span2D<float> matrix)
        {
            var rows = matrix.Height;
            var cols = matrix.Width;

            if (!IsSquareMatrix(matrix))
            {
                return (new float[1, 1], new float[1, 1]);
            }
            else
            {
                var lower = new float[rows, cols];
                var upper = new float[rows, cols];

                for (var i = 0; i < rows; i++)
                {
                    lower[i, i] = 1;
                }

                for (var i = 0; i < rows; i++)
                {
                    for (var j = i; j < rows; j++)
                    {
                        var sumU = 0f;
                        for (var k = 0; k < i; k++)
                        {
                            sumU += lower[i, k] * upper[k, j];
                        }

                        upper[i, j] = matrix[i, j] - sumU;
                    }

                    for (var j = i; j < rows; j++)
                    {
                        var sumL = 0f;
                        for (var k = 0; k < i; k++)
                        {
                            sumL += lower[j, k] * upper[k, i];
                        }

                        lower[j, i] = (matrix[j, i] - sumL) / upper[i, i];
                    }
                }

                return (lower, upper);
            }
        }

        /// <summary>
        /// Compute LU decomposition on a squared matrix
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double[,] Lower, double[,] Upper) DecomposeToLowerUpper(Span2D<double> matrix)
        {
            var rows = matrix.Height;
            var cols = matrix.Width;

            if (!IsSquareMatrix(matrix))
            {
                return (new double[1, 1], new double[1, 1]);
            }
            else
            {
                var lower = new double[rows, cols];
                var upper = new double[rows, cols];

                for (var i = 0; i < rows; i++)
                {
                    lower[i, i] = 1;
                }

                for (var i = 0; i < rows; i++)
                {
                    for (var j = i; j < rows; j++)
                    {
                        var sumU = 0d;
                        for (var k = 0; k < i; k++)
                        {
                            sumU += lower[i, k] * upper[k, j];
                        }

                        upper[i, j] = matrix[i, j] - sumU;
                    }

                    for (var j = i; j < rows; j++)
                    {
                        var sumL = 0d;
                        for (var k = 0; k < i; k++)
                        {
                            sumL += lower[j, k] * upper[k, i];
                        }

                        lower[j, i] = (matrix[j, i] - sumL) / upper[i, i];
                    }
                }

                return (lower, upper);
            }
        }
        #endregion

        #region Resolve Linear Equation Lower Triangular Matrix
        /// <summary>
        /// Resolve the following linear equation LY = f
        /// where L is a lower triangular matrix
        /// </summary>
        /// <param name="matrix">The data.</param>
        /// <param name="fMatrix">vector of shape (d,1)</param>
        /// <returns>
        /// Y vector y of shape (d,1)
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] ResolveLinearEquationLowerTriangularMatrix(Span2D<float> matrix, Span2D<float> fMatrix)
        {
            var row = matrix.Height;
            var col = matrix.Width;
            var rowf = fMatrix.Height;
            var colf = fMatrix.Width;
            var violations = !IsLowerMatrix(matrix) || row != rowf || colf > 1 || row < 2;
            if (violations)
            {
                return new float[1, 1];
            }

            var yMatrix = new float[row, 1];

            yMatrix[0, 0] = fMatrix[0, 0] / matrix[0, 0];

            for (var m = 1; m < row; m++)
            {
                float sum = 0;
                for (var i = 0; i < m; i++)
                {
                    sum += matrix[m, i] * yMatrix[i, 0];
                }

                yMatrix[m, 0] = (fMatrix[m, 0] - sum) / matrix[m, m];
            }

            return yMatrix;
        }

        /// <summary>
        /// Resolve the following linear equation LY = f
        /// where L is a lower triangular matrix
        /// </summary>
        /// <param name="matrix">The data.</param>
        /// <param name="fMatrix">vector of shape (d,1)</param>
        /// <returns>
        /// Y vector y of shape (d,1)
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] ResolveLinearEquationLowerTriangularMatrix(Span2D<double> matrix, Span2D<double> fMatrix)
        {
            var row = matrix.Height;
            var col = matrix.Width;
            var rowf = fMatrix.Height;
            var colf = fMatrix.Width;
            var violations = !IsLowerMatrix(matrix) || row != rowf || colf > 1 || row < 2;
            if (violations)
            {
                return new double[1, 1];
            }

            var yMatrix = new double[row, 1];

            yMatrix[0, 0] = fMatrix[0, 0] / matrix[0, 0];

            for (var m = 1; m < row; m++)
            {
                double sum = 0;
                for (var i = 0; i < m; i++)
                {
                    sum += matrix[m, i] * yMatrix[i, 0];
                }

                yMatrix[m, 0] = (fMatrix[m, 0] - sum) / matrix[m, m];
            }

            return yMatrix;
        }
        #endregion

        #region Resolve Linear Equation Upper Triangular Matrix
        /// <summary>
        /// Resolve the following linear equation UX = y
        /// where U is a upper triangular matrix
        /// </summary>
        /// <param name="matrix">The data.</param>
        /// <param name="yMatrix">vector of shape (d,1)</param>
        /// <returns>
        /// X vector y of shape (d,1)
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] ResolveLinearEquation_UpperTriangularMatrix(Span2D<float> matrix, Span2D<float> yMatrix)
        {
            var row = matrix.Height;
            var col = matrix.Width;
            var rowy = yMatrix.Height;
            var coly = yMatrix.Width;
            var violations = !IsUpperMatrix(matrix) || row != rowy || coly > 1;
            if (violations)
            {
                return new float[1, 1];
            }

            var xMatrix = new float[row, 1];

            for (var i = row - 1; i >= 0; i--)
            {
                float sum = 0;
                for (var k = i + 1; k < row; k++)
                {
                    sum += matrix[i, k] * xMatrix[k, 0];
                }

                xMatrix[i, 0] = (yMatrix[i, 0] - sum) / matrix[i, i];
            }

            return xMatrix;
        }

        /// <summary>
        /// Resolve the following linear equation UX = y
        /// where U is a upper triangular matrix
        /// </summary>
        /// <param name="matrix">The data.</param>
        /// <param name="yMatrix">vector of shape (d,1)</param>
        /// <returns>
        /// X vector y of shape (d,1)
        /// </returns>
        /// <acknowledgment>
        /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] ResolveLinearEquation_UpperTriangularMatrix(Span2D<double> matrix, Span2D<double> yMatrix)
        {
            var row = matrix.Height;
            var col = matrix.Width;
            var rowy = yMatrix.Height;
            var coly = yMatrix.Width;
            var violations = !IsUpperMatrix(matrix) || row != rowy || coly > 1;
            if (violations)
            {
                return new double[1, 1];
            }

            var xMatrix = new double[row, 1];

            for (var i = row - 1; i >= 0; i--)
            {
                double sum = 0;
                for (var k = i + 1; k < row; k++)
                {
                    sum += matrix[i, k] * xMatrix[k, 0];
                }

                xMatrix[i, 0] = (yMatrix[i, 0] - sum) / matrix[i, i];
            }

            return xMatrix;
        }
        #endregion

        #region 1: Least Squares Method Prepare Matrix
        /// <summary>
        /// LSM, step 1: Prepare the matrix.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="numberOfSamples">The number of samples.</param>
        /// <param name="columnsAccordingToMode">The columns according to mode.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (float[,], float[,]) LeastSquaresMethodPrepareMatrix(Span2D<float> data, int numberOfSamples, int columnsAccordingToMode)
        {
            var cube = false;
            if (columnsAccordingToMode == 4)
            {
                cube = true;
            }
            else if (columnsAccordingToMode != 3)
            {
                throw new Exception("LSM error");
            }

            var vector_columns = 1;
            var the_result_matrix = new float[numberOfSamples, columnsAccordingToMode];
            var the_result_vector = new float[numberOfSamples, vector_columns];
            for (var i = 0; i < numberOfSamples; i++)
            {
                for (var j = 0; j < columnsAccordingToMode; j++)
                {
                    the_result_matrix[i, j] = j switch
                    {
                        0 => the_result_matrix[i, j] = cube ? data[i, 0] * data[i, 0] * data[i, 0] : data[i, 0] * data[i, 0],
                        1 => the_result_matrix[i, j] = cube ? data[i, 0] * data[i, 0] : data[i, 0],
                        2 => the_result_matrix[i, j] = cube ? data[i, 0] : 1,
                        3 => the_result_matrix[i, j] = 1,
                        _ => throw new NotImplementedException(),
                    };
                }

                the_result_vector[i, 0] = data[i, 1];
            }

            return (the_result_matrix, the_result_vector);
        }

        /// <summary>
        /// LSM, step 1: Prepare the matrix.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="numberOfSamples">The number of samples.</param>
        /// <param name="columnsAccordingToMode">The columns according to mode.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (double[,], double[,]) LeastSquaresMethodPrepareMatrix(Span2D<double> data, int numberOfSamples, int columnsAccordingToMode)
        {
            var cube = false;
            if (columnsAccordingToMode == 4)
            {
                cube = true;
            }
            else if (columnsAccordingToMode != 3)
            {
                throw new Exception("LSM error");
            }

            var vector_columns = 1;
            var the_result_matrix = new double[numberOfSamples, columnsAccordingToMode];
            var the_result_vector = new double[numberOfSamples, vector_columns];
            for (var i = 0; i < numberOfSamples; i++)
            {
                for (var j = 0; j < columnsAccordingToMode; j++)
                {
                    the_result_matrix[i, j] = j switch
                    {
                        0 => the_result_matrix[i, j] = cube ? data[i, 0] * data[i, 0] * data[i, 0] : data[i, 0] * data[i, 0],
                        1 => the_result_matrix[i, j] = cube ? data[i, 0] * data[i, 0] : data[i, 0],
                        2 => the_result_matrix[i, j] = cube ? data[i, 0] : 1,
                        3 => the_result_matrix[i, j] = 1,
                        _ => throw new NotImplementedException(),
                    };
                }

                the_result_vector[i, 0] = data[i, 1];
            }

            return (the_result_matrix, the_result_vector);
        }
        #endregion

        // ToDo: Port the rest of the LSM.
        #region 3: Least Squares Method Solution
        /// <summary>
        /// LSM, step 3: The solution extraction.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] LeastSquaresMethodSolution(Span2D<float> matrix)
        {
            var rows = matrix.Height;
            var columns = matrix.Width;
            var result = new float[rows];
            var column_index = columns - 1;
            for (var i = 0; i < rows; i++)
            {
                result[i] = matrix[i, column_index];
            }

            return result;
        }

        /// <summary>
        /// LSM, step 3: The solution extraction.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] LeastSquaresMethodSolution(Span2D<double> matrix)
        {
            var rows = matrix.Height;
            var columns = matrix.Width;
            var result = new double[rows];
            var column_index = columns - 1;
            for (var i = 0; i < rows; i++)
            {
                result[i] = matrix[i, column_index];
            }

            return result;
        }

        /// <summary>
        /// LSM, step 3: The solution extraction.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[] LeastSquaresMethodSolution(Span2D<float> matrix, int rows, int columns)
        {
            var result = new float[rows];
            var column_index = columns - 1;
            for (var i = 0; i < rows; i++)
            {
                result[i] = matrix[i, column_index];
            }

            return result;
        }

        /// <summary>
        /// LSM, step 3: The solution extraction.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] LeastSquaresMethodSolution(Span2D<double> matrix, int rows, int columns)
        {
            var result = new double[rows];
            var column_index = columns - 1;
            for (var i = 0; i < rows; i++)
            {
                result[i] = matrix[i, column_index];
            }

            return result;
        }
        #endregion

        #region Least Squares Method Sort
        /// <summary>
        /// LSM, sort.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="numberOfSamples">The number of samples.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float[,] LeastSquaresMethodSort(Span2D<float> data, int numberOfSamples)
        {
            var swapped = true;
            var temp = CopyMatrix(data, numberOfSamples, 2);
            while (swapped)
            {
                swapped = false;
                for (var i = 0; i < numberOfSamples - 1; i++)
                {
                    if (temp[i, 0] > temp[i + 1, 0] || temp[i, 0] == temp[i + 1, 0] && temp[i, 1] > temp[i + 1, 1])
                    {
                        SwapRows(temp, numberOfSamples, 2, i, i + 1);
                        swapped = true;
                    }
                }
            }

            return temp;
        }

        /// <summary>
        /// LSM, sort.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="numberOfSamples">The number of samples.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] LeastSquaresMethodSort(Span2D<double> data, int numberOfSamples)
        {
            var swapped = true;
            var temp = CopyMatrix(data, numberOfSamples, 2);
            while (swapped)
            {
                swapped = false;
                for (var i = 0; i < numberOfSamples - 1; i++)
                {
                    if (temp[i, 0] > temp[i + 1, 0] || temp[i, 0] == temp[i + 1, 0] && temp[i, 1] > temp[i + 1, 1])
                    {
                        SwapRows(temp, numberOfSamples, 2, i, i + 1);
                        swapped = true;
                    }
                }
            }

            return temp;
        }
        #endregion

        // ToDo: Figure out what this is.
        #region Extract A2
        /// <summary>
        /// Extract A2.
        /// </summary>
        /// <param name="theBigOne">The big one.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] ExtractA2(Span2D<double> theBigOne)
        {
            var rows = theBigOne.Height;
            var columns = theBigOne.Width;
            var A2_rows = rows - 1;
            var A2_columns = columns - 1;
            var A2_matrix = new double[A2_rows, A2_columns];
            if (A2_rows != 0 && A2_columns != 0)
            {
                for (var i = 1; i < rows; i++)
                {
                    for (var j = 1; j < columns; j++)
                    {
                        A2_matrix[i - 1, j - 1] = theBigOne[i, j];
                    }
                }
            }
            else
            {
                A2_matrix = null;
            }

            return A2_matrix;
        }

        /// <summary>
        /// Extract A2.
        /// </summary>
        /// <param name="theBigOne">The big one.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] ExtractA2(Span2D<double> theBigOne, int rows, int columns)
        {
            var A2_rows = rows - 1;
            var A2_columns = columns - 1;
            var A2_matrix = new double[A2_rows, A2_columns];
            if (A2_rows != 0 && A2_columns != 0)
            {
                for (var i = 1; i < rows; i++)
                {
                    for (var j = 1; j < columns; j++)
                    {
                        A2_matrix[i - 1, j - 1] = theBigOne[i, j];
                    }
                }
            }
            else
            {
                A2_matrix = null;
            }

            return A2_matrix;
        }
        #endregion

        // ToDo: Figure out what is supposed to use this.
        #region Power Iteration Row Swap
        /// <summary>
        /// Tricky row swap to make Power Iteration faster.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] SwappingSomeRows(Span2D<double> matrix)
        {
            var bingo = false;
            var rows = matrix.Height;
            var columns = matrix.Width;
            var result = new double[rows, columns];
            if (rows == columns && columns == 2)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (matrix[0, j] == 0)
                    {
                        bingo = true;
                    }
                }
                if (bingo)
                {
                    result = CopyMatrix(matrix);
                    SwapRows(result, rows, columns, 0, 1);
                }
            }
            if (!bingo)
            {
                result = matrix.ToArray();
            }

            return result;
        }

        /// <summary>
        /// Tricky row swap to make Power Iteration faster.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="matrix">The matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] SwappingSomeRows(int rows, int columns, Span2D<double> matrix)
        {
            var bingo = false;
            var result = new double[rows, columns];
            if (rows == columns && columns == 2)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (matrix[0, j] == 0)
                    {
                        bingo = true;
                    }
                }
                if (bingo)
                {
                    result = CopyMatrix(matrix);
                    SwapRows(result, rows, columns, 0, 1);
                }
            }
            if (!bingo)
            {
                result = matrix.ToArray();
            }

            return result;
        }
        #endregion

        // ToDo: Figure out how to port everything else.
        #region Eigenvalue Multiplicity
        /// <summary>
        /// Find the Eigenvalue the multiplicity.
        /// </summary>
        /// <param name="eigenvalues">The eigenvalues.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<double, int> EigenvalueMultiplicity(Span<double> eigenvalues)
        {
            var Eigenvalues_and_Multiplicity = new Dictionary<double, int>();
            for (var i = 0; i < eigenvalues.Length; i++)
            {
                if (!Eigenvalues_and_Multiplicity.ContainsKey(eigenvalues[i]))
                {
                    Eigenvalues_and_Multiplicity.Add(eigenvalues[i], 1);
                }
                else
                {
                    Eigenvalues_and_Multiplicity[eigenvalues[i]]++;
                }
            }

            return Eigenvalues_and_Multiplicity;
        }

        /// <summary>
        /// Find the Eigenvalue the multiplicity.
        /// </summary>
        /// <param name="eigenvalues">The eigenvalues.</param>
        /// <param name="N">The n.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Dictionary<double, int> EigenvalueMultiplicity(Span<double> eigenvalues, int N)
        {
            var Eigenvalues_and_Multiplicity = new Dictionary<double, int>();
            for (var i = 0; i < N; i++)
            {
                if (!Eigenvalues_and_Multiplicity.ContainsKey(eigenvalues[i]))
                {
                    Eigenvalues_and_Multiplicity.Add(eigenvalues[i], 1);
                }
                else
                {
                    Eigenvalues_and_Multiplicity[eigenvalues[i]]++;
                }
            }

            return Eigenvalues_and_Multiplicity;
        }
        #endregion

        // ToDo: Work out what this is supposed to do.
        #region Solution Finder
        /// <summary>
        /// Solution finder.
        /// </summary>
        /// <param name="tempMatrix">The temporary matrix.</param>
        /// <param name="rank">The rank.</param>
        /// <param name="row">The row.</param>
        /// <param name="freePositionsInTheRow">The free positions in the row.</param>
        /// <param name="tempValue">The temporary value.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double[,] SolutionFinder(Span2D<double> tempMatrix, int rank, int row, List<int> freePositionsInTheRow, double tempValue, int index)
        {
            var N = tempMatrix.Height;
            var Kernel_dimension = N - rank;
            var Temp_countings = new double[Kernel_dimension, N + 1];
            //var free_positions_count = free_positions_in_the_row.Count;
            var i = 0; // row index

            while (i < Kernel_dimension) // tonight i have to check this out
            {
                double temp_value_copy = 0;
                var random_vectors = Factories.Vectors_1_0(Kernel_dimension, freePositionsInTheRow.Count, index);
                //MessageBox.Show(Convert_MX_VR_to_string(Kernel_dimension, free_positions_in_the_row.Count - 1, random_vectors) + "Rnd");
                for (var free = 0; free < freePositionsInTheRow.Count - 1; free++)
                {
                    Temp_countings[i, freePositionsInTheRow[free]] = random_vectors[i, free];
                    temp_value_copy += Temp_countings[i, freePositionsInTheRow[free]] * tempMatrix[row, freePositionsInTheRow[free]];
                }
                //MessageBox.Show(Convert.ToString(temp_value_copy));
                var the_last_free_second_index = freePositionsInTheRow[^1];
                Temp_countings[i, the_last_free_second_index] = (-1) * temp_value_copy / tempMatrix[row, the_last_free_second_index];
                //MessageBox.Show(Convert_MX_VR_to_string(Kernel_dimension, N + 1, Temp_countings) + "Temp countings");
                i++;
            }

            return Temp_countings;
        }

        /// <summary>
        /// Solution finder.
        /// </summary>
        /// <param name="tempMatrix">The temporary matrix.</param>
        /// <param name="N">The n.</param>
        /// <param name="rank">The rank.</param>
        /// <param name="row">The row.</param>
        /// <param name="freePositionsInTheRow">The free positions in the row.</param>
        /// <param name="tempValue">The temporary value.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double[,] SolutionFinder(Span2D<double> tempMatrix, int N, int rank, int row, List<int> freePositionsInTheRow, double tempValue, int index)
        {
            var Kernel_dimension = N - rank;
            var Temp_countings = new double[Kernel_dimension, N + 1];
            //var free_positions_count = free_positions_in_the_row.Count;
            var i = 0; // row index

            while (i < Kernel_dimension) // tonight i have to check this out
            {
                double temp_value_copy = 0;
                var random_vectors = Factories.Vectors_1_0(Kernel_dimension, freePositionsInTheRow.Count, index);
                //MessageBox.Show(Convert_MX_VR_to_string(Kernel_dimension, free_positions_in_the_row.Count - 1, random_vectors) + "Rnd");
                for (var free = 0; free < freePositionsInTheRow.Count - 1; free++)
                {
                    Temp_countings[i, freePositionsInTheRow[free]] = random_vectors[i, free];
                    temp_value_copy += Temp_countings[i, freePositionsInTheRow[free]] * tempMatrix[row, freePositionsInTheRow[free]];
                }
                //MessageBox.Show(Convert.ToString(temp_value_copy));
                var the_last_free_second_index = freePositionsInTheRow[^1];
                Temp_countings[i, the_last_free_second_index] = (-1) * temp_value_copy / tempMatrix[row, the_last_free_second_index];
                //MessageBox.Show(Convert_MX_VR_to_string(Kernel_dimension, N + 1, Temp_countings) + "Temp countings");
                i++;
            }

            return Temp_countings;
        }
        #endregion

        #region Validate Spectral Decomposition
        /// <summary>
        /// Spectral decomposition check.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="matrix1">The matrix 1.</param>
        /// <param name="matrix2">The matrix 2.</param>
        /// <param name="matrix3">The matrix 3.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateSpectralDecomposition(Span2D<double> original, Span2D<double> matrix1, Span2D<double> matrix2, Span2D<double> matrix3)
        {
            var N = original.Height;
            var temp_matrix = MatrixMatrixScalarMultiplication(matrix1, N, N, matrix2, N, N, 15);
            var result_matrix = MatrixMatrixScalarMultiplication(temp_matrix, N, N, matrix3, N, N, 5);
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, result_matrix));
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_original));
            return MatricesEquality(original, result_matrix, N, N);
        }

        /// <summary>
        /// Spectral decomposition check.
        /// </summary>
        /// <param name="original">The original.</param>
        /// <param name="N">The n.</param>
        /// <param name="matrix1">The matrix 1.</param>
        /// <param name="matrix2">The matrix 2.</param>
        /// <param name="matrix3">The matrix 3.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ValidateSpectralDecomposition(Span2D<double> original, int N, Span2D<double> matrix1, Span2D<double> matrix2, Span2D<double> matrix3)
        {
            var temp_matrix = MatrixMatrixScalarMultiplication(matrix1, N, N, matrix2, N, N, 15);
            var result_matrix = MatrixMatrixScalarMultiplication(temp_matrix, N, N, matrix3, N, N, 5);
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, result_matrix));
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_original));
            return MatricesEquality(original, result_matrix, N, N);
        }
        #endregion

        // ToDo: Figure out what this is supposed to do.
        #region Create Orthogonal Spectral Decomposition
        /// <summary>
        /// Creates the orthogonal spectral decomposition.
        /// Coefficient and Inverse checker
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="inversedMatrix">The inversed matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] CreateOrthogonalSpectralDecomposition(Span2D<double> matrix, Span2D<double> inversedMatrix)
        {
            var N = matrix.Height;
            var the_result = new double[N, N];
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_matrix) + " : the original");
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_inversed_matrix) + " : the inversed");
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, Matrix_Multiplication(N, N, the_matrix, N, N, the_inversed_matrix, 15)) + " : Mult");
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    try
                    {
                        the_result[i, j] = Math.Sqrt(matrix[i, j] * inversedMatrix[j, i]);
                    }
                    catch (Exception The_Exception)
                    {
                        the_result[i, j] = 0;
                        throw new Exception(The_Exception.Message);
                    }

                    if (matrix[i, j] < 0)
                    {
                        the_result[i, j] = (-1) * the_result[i, j];
                    }
                }
            }

            //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_result) + " : the result");
            var the_result_tr = Transpose(the_result, N, N, 15);
            var checker = MatrixMatrixScalarMultiplication(the_result, N, N, the_result_tr, N, N, 4);
            var identity_matrix = Factories.IdentityMatrix(N, N);
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, checker) + " : checker");
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, identity_matrix) + " : IDE");
            //double coefficient = the_matrix[0, 0] / the_inveresed_matrix[0, 0];
            return MatricesEquality(checker, identity_matrix) ? the_result : null;
        }

        /// <summary>
        /// Creates the orthogonal spectral decomposition.
        /// Coefficient and Inverse checker
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="N">The n.</param>
        /// <param name="inversedMatrix">The inversed matrix.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static double[,] CreateOrthogonalSpectralDecomposition(Span2D<double> matrix, int N, Span2D<double> inversedMatrix)
        {
            var the_result = new double[N, N];
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_matrix) + " : the original");
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_inversed_matrix) + " : the inversed");
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, Matrix_Multiplication(N, N, the_matrix, N, N, the_inversed_matrix, 15)) + " : Mult");
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    try
                    {
                        the_result[i, j] = Math.Sqrt(matrix[i, j] * inversedMatrix[j, i]);
                    }
                    catch (Exception The_Exception)
                    {
                        the_result[i, j] = 0;
                        throw new Exception(The_Exception.Message);
                    }

                    if (matrix[i, j] < 0)
                    {
                        the_result[i, j] = (-1) * the_result[i, j];
                    }
                }
            }

            //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_result) + " : the result");
            var the_result_tr = Transpose(the_result, N, N, 15);
            var checker = MatrixMatrixScalarMultiplication(the_result, N, N, the_result_tr, N, N, 4);
            var identity_matrix = Factories.IdentityMatrix(N, N);
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, checker) + " : checker");
            //MessageBox.Show(Convert_MX_VR_to_string(N, N, identity_matrix) + " : IDE");
            //double coefficient = the_matrix[0, 0] / the_inveresed_matrix[0, 0];
            return MatricesEquality(checker, identity_matrix) ? the_result : null;
        }
        #endregion

        // ToDo: Figure out what this is supposed to do.
        #region Singular Decomposition Sigma Matrix
        /// <summary>
        /// SVDs the create sigma matrix.
        /// The Xi matrix
        /// </summary>
        /// <param name="sMatrix">The s matrix.</param>
        /// <param name="rank">The rank.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] SingularValueDecompositionCreateSigmaMatrix(Span2D<double> sMatrix, int rank)
        {
            var rows = sMatrix.Height;
            var columns = sMatrix.Width;
            var the_Xi_matrix = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    the_Xi_matrix[i, j] = i < rank && j < rank ? sMatrix[i, j] : 0;
                }
            }

            return the_Xi_matrix;
        }

        /// <summary>
        /// SVDs the create sigma matrix.
        /// The Xi matrix
        /// </summary>
        /// <param name="sMatrix">The s matrix.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="rank">The rank.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] SingularValueDecompositionCreateSigmaMatrix(Span2D<double> sMatrix, int rows, int columns, int rank)
        {
            var the_Xi_matrix = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    the_Xi_matrix[i, j] = i < rank && j < rank ? sMatrix[i, j] : 0;
                }
            }

            return the_Xi_matrix;
        }
        #endregion

        // ToDo: Work out what this is supposed to do.
        #region Singular Value Decomposition V1 Matrix
        /// <summary>
        /// SVDs the create v1 matrix.
        /// The V1 matrix
        /// </summary>
        /// <param name="vMatrix">The v matrix.</param>
        /// <param name="rank">The rank.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] SingularValueDecompositionCreateV1Matrix(Span2D<double> vMatrix, int rank)
        {
            var N = vMatrix.Height;
            var the_V1_matrix = new double[N, rank];
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < rank; j++)
                {
                    the_V1_matrix[i, j] = vMatrix[i, j];
                }
            }

            return the_V1_matrix;
        }

        /// <summary>
        /// SVDs the create v1 matrix.
        /// The V1 matrix
        /// </summary>
        /// <param name="vMatrix">The v matrix.</param>
        /// <param name="N">The n.</param>
        /// <param name="rank">The rank.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] SingularValueDecompositionCreateV1Matrix(Span2D<double> vMatrix, int N, int rank)
        {
            var the_V1_matrix = new double[N, rank];
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < rank; j++)
                {
                    the_V1_matrix[i, j] = vMatrix[i, j];
                }
            }

            return the_V1_matrix;
        }
        #endregion

        #region Cholesky Decomposition
        /// <summary>
        /// Calculates the Cholesky decomposition.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool positiveDefiniteness, bool, double[,] lowerMatrix, double[,] upperMatrix) CholeskyDecomposition(Span2D<double> matrix, int accuracy)
        {
            var n = matrix.Height;
            var positiveDefiniteness = true;
            var lowerMatrix = new double[n, n];
            for (var k = 0; k < n && positiveDefiniteness; k++)
            {
                var temporarySum = 0d;
                for (var j = 0; j <= k - 1; j++)
                {
                    temporarySum += Math.Pow(lowerMatrix[k, j], 2);
                }

                var definitenessCheck = matrix[k, k] - temporarySum;

                if (definitenessCheck <= 0)
                {
                    positiveDefiniteness = false;
                }
                else
                {
                    lowerMatrix[k, k] = Math.Sqrt(definitenessCheck);

                    for (var i = k + 1; i < n; i++)
                    {
                        temporarySum = 0;
                        for (var j = 0; j <= k - 1; j++)
                        {
                            temporarySum += lowerMatrix[i, j] * lowerMatrix[k, j];
                        }

                        lowerMatrix[i, k] = 1d / lowerMatrix[k, k] * (matrix[i, k] - temporarySum);
                    }
                }
            }

            var upperMatrix = Transpose(lowerMatrix, n, n, 15);
            var resultCheckerMatrix = MatrixMatrixScalarMultiplication(lowerMatrix, n, n, upperMatrix, n, n, accuracy);

            var result_check = false;
            if (MatricesEquality(matrix, resultCheckerMatrix, n, n))
            {
                result_check = true;
            }

            return (positiveDefiniteness, result_check, Round(lowerMatrix, n, n, accuracy), Round(upperMatrix, n, n, accuracy));
        }

        /// <summary>
        /// Calculates the Cholesky decomposition.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        /// <param name="n">The n.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (bool positiveDefiniteness, bool, double[,] lowerMatrix, double[,] upperMatrix) CholeskyDecomposition(Span2D<double> matrix, int n, int accuracy)
        {
            var positiveDefiniteness = true;
            var lowerMatrix = new double[n, n];
            for (var k = 0; k < n && positiveDefiniteness; k++)
            {
                var temporarySum = 0d;
                for (var j = 0; j <= k - 1; j++)
                {
                    temporarySum += Math.Pow(lowerMatrix[k, j], 2);
                }

                var definitenessCheck = matrix[k, k] - temporarySum;

                if (definitenessCheck <= 0)
                {
                    positiveDefiniteness = false;
                }
                else
                {
                    lowerMatrix[k, k] = Math.Sqrt(definitenessCheck);

                    for (var i = k + 1; i < n; i++)
                    {
                        temporarySum = 0;
                        for (var j = 0; j <= k - 1; j++)
                        {
                            temporarySum += lowerMatrix[i, j] * lowerMatrix[k, j];
                        }

                        lowerMatrix[i, k] = 1d / lowerMatrix[k, k] * (matrix[i, k] - temporarySum);
                    }
                }
            }

            var upperMatrix = Transpose(lowerMatrix, n, n, 15);
            var resultCheckerMatrix = MatrixMatrixScalarMultiplication(lowerMatrix, n, n, upperMatrix, n, n, accuracy);

            var result_check = false;
            if (MatricesEquality(matrix, resultCheckerMatrix, n, n))
            {
                result_check = true;
            }

            return (positiveDefiniteness, result_check, Round(lowerMatrix, n, n, accuracy), Round(upperMatrix, n, n, accuracy));
        }
        #endregion
    }
}
