// <copyright file="Factories.Matricies.Array.cs" company="Shkyrockett" >
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
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Factories
    {
        /// <summary>
        /// The random generator
        /// </summary>
        private static readonly Random rnd_generator = new();

        /// <summary>
        /// Creates the identity matrix.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] IdentityMatrix(int rows, int columns)
        {
            var result = new double[rows, columns];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    result[i, j] = i == j ? 1 : 0;
                }
            }

            return result;
        }

        /// <summary>
        /// Random matrix generator.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] RandomNonZeroMatrix(int rows, int columns)
        {
            var non_zero = false;
            var Result = new double[rows, columns];
            while (!non_zero)
            {
                for (var i = 0; i < rows; i++)
                {
                    non_zero = false;
                    for (var j = 0; j < columns; j++)
                    {
                        Result[i, j] = rnd_generator.Next(0, 999);
                        Result[i, j] = Result[i, j] / 1000; // random number from the interval [0.0.999)
                        if (Result[i, j] != 0)
                        {
                            non_zero = true;
                        }
                    }
                }
            }

            return Result;
        }

        /// <summary>
        /// Generates the 1 0 vectors.
        /// </summary>
        /// <param name="kernel_dim">The kernel dim.</param>
        /// <param name="length">The length.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] Vectors_1_0(int kernel_dim, int length, int index)
        {
            var The_Result = new double[kernel_dim, length - 1];
            for (var i = 0; i < kernel_dim; i++)
            {
                //int Matrix_Rank = 0;
                var the_zero_position = i - 1;
                for (var j = 0; j < length - 1; j++)
                {
                    The_Result[i, j] = i >= length && index == 0 || j == the_zero_position ? 0 : j == 0 ? -1 : 1;
                }
            }

            //Matrix_Rank = Matrix_Rank_Finder(kernel_dim, length - 1, The_Result, 7);
            //MessageBox.Show(Convert.ToString(Random_Matrix_Rank) + " :Rank");
            return The_Result;
        }

        #region Create Lambda Matrix
        /// <summary>
        /// Spectral decomposition. Creates the lambda matrix.
        /// </summary>
        /// <param name="eigenvalues">The eigenvalues.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] CreateLambdaMatrix(Span<double> eigenvalues)
        {
            var numberOfEigenvalues = eigenvalues.Length;
            var bigLambda = new double[numberOfEigenvalues, numberOfEigenvalues];
            for (var i = 0; i < numberOfEigenvalues; i++)
            {
                bigLambda[i, i] = eigenvalues[i];
            }

            return bigLambda;
        }

        /// <summary>
        /// Spectral decomposition. Creates the lambda matrix.
        /// </summary>
        /// <param name="eigenvalues">The eigenvalues.</param>
        /// <param name="numberOfEigenvalues">The number of eigenvalues.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] CreateLambdaMatrix(Span<double> eigenvalues, int numberOfEigenvalues)
        {
            var bigLambda = new double[numberOfEigenvalues, numberOfEigenvalues];
            for (var i = 0; i < numberOfEigenvalues; i++)
            {
                bigLambda[i, i] = eigenvalues[i];
            }
            return bigLambda;
        }

        /// <summary>
        /// Lambda Matrix Final Function.
        /// </summary>
        /// <param name="Eigenvalues">The eigenvalues.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] LambdaAllTogether((int, double[], int[]) Eigenvalues)
        {
            var total_number_of_eigenvalues = 0;
            for (var i = 0; i < Eigenvalues.Item1; i++)
            {
                total_number_of_eigenvalues += Eigenvalues.Item3[i];
            }

            var The_Eigenvalues_Vector = new double[total_number_of_eigenvalues];
            var k = 0;
            for (var j = 0; j < Eigenvalues.Item1; j++)
            {
                double single_eigenvalue = Eigenvalues.Item3[j];
                while (single_eigenvalue > 0)
                {
                    single_eigenvalue--;
                    The_Eigenvalues_Vector[k] = Eigenvalues.Item2[j];
                    if (k < total_number_of_eigenvalues)
                    {
                        k++;
                    }
                    else
                    {
                        throw new Exception("Lambda Error");
                    }
                }
            }

            var Big_Lambda = CreateLambdaMatrix(The_Eigenvalues_Vector, total_number_of_eigenvalues);
            return Big_Lambda;
        }
        #endregion

        #region Change the Eigenvalues order
        /// <summary>
        /// Changes the values order.
        /// </summary>
        /// <param name="Eigenvalues">The eigenvalues.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int, double[], int[]) ChangeTheValuesOrder((int, double[], int[]) Eigenvalues)
        {
            var Eigenvalues_copy = (Eigenvalues.Item1, Eigenvalues.Item2, Eigenvalues.Item3);
            var changed = true;
            while (changed)
            {
                changed = false;
                for (var i = 0; i < Eigenvalues_copy.Item1 - 1; i++)
                {
                    if (Eigenvalues_copy.Item2[i] < Eigenvalues_copy.Item2[i + 1])
                    {
                        changed = true;
                        //var temp = Eigenvalues_copy.Item2[i];
                        Eigenvalues_copy.Item2[i] = Eigenvalues_copy.Item2[i + 1];
                        Eigenvalues_copy.Item2[i + 1] = Eigenvalues_copy.Item2[i];
                        //var temp1 = Eigenvalues_copy.Item3[i];
                        Eigenvalues_copy.Item3[i] = Eigenvalues_copy.Item3[i + 1];
                        Eigenvalues_copy.Item3[i + 1] = Eigenvalues_copy.Item3[i];
                    }
                }
            }

            return (Eigenvalues_copy.Item1, Eigenvalues_copy.Item2, Eigenvalues_copy.Item3);
        }
        #endregion

        #region Singular Value Decomposition Matrix
        /// <summary>
        /// SVDs the singular matrix.
        /// S matrix, Sqrt. Eigenvalues
        /// </summary>
        /// <param name="singularValues">The singular values.</param>
        /// <param name="Rank">The rank.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[,] SingularValueDecompositionSingularMatrix(Span<double> singularValues, int Rank)
        {
            var the_result = new double[Rank, Rank];
            for (var i = 0; i < Rank; i++)
            {
                for (var j = 0; j < Rank; j++)
                {
                    the_result[i, j] = i == j ? singularValues[i] : 0;
                }
            }

            return the_result;
        }
        #endregion
    }
}
