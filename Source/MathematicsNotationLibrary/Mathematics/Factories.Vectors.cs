// <copyright file="Factories.Vectors.Array.cs" company="Shkyrockett" >
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
        /// Random vector generator.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] RandomNonZeroVector(int length)
        {
            var non_zero = false;
            var Result = new double[length];
            while (!non_zero)
            {
                for (var i = 0; i < length; i++)
                {
                    Result[i] = rnd_generator.Next(0, 999);
                    Result[i] = Result[i] / 1000; // random number from the interval [0.0.999)
                    if (Result[i] != 0)
                    {
                        non_zero = true;
                    }
                }
            }

            return Result;
        }

        #region Singular Value Decomposition Vectors
        /// <summary>
        /// SVD - eigenvalues change
        /// </summary>
        /// <param name="sortedEigenvalues">The sorted eigenvalues.</param>
        /// <param name="matrixARank">The matrix a rank.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double[] SingularValueDecompositionSingularValues((int, double[], int[]) sortedEigenvalues, int matrixARank)
        {
            var Eigenvalues_copy = (sortedEigenvalues.Item1, sortedEigenvalues.Item2, sortedEigenvalues.Item3);
            var the_result_singular_values = new double[matrixARank];

            var j = 0;
            var multiplicity = Eigenvalues_copy.Item3[j];
            for (var i = 0; i < matrixARank; i++)
            {
                the_result_singular_values[i] = Math.Sqrt(Eigenvalues_copy.Item2[j]);
                multiplicity--;
                if (multiplicity == 0 && j < sortedEigenvalues.Item1 - 1)
                {
                    j++;
                    multiplicity = Eigenvalues_copy.Item3[j];
                }
            }

            return the_result_singular_values;
        }
        #endregion
    }
}
