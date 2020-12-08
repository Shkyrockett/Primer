// <copyright file="Operations.Vectors.Algebratics.Array.cs" company="Shkyrockett" >
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

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Operations
    {
        #region Vector Euclidean Norm
        /// <summary>
        /// Euclidean norm.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double EuclideanNorm(Span<double> vector)
        {
            var result = 0d;
            for (var i = 0; i < vector.Length; i++)
            {
                result += vector[i] * vector[i];
            }

            return Math.Sqrt(result);
        }

        /// <summary>
        /// Euclidean norm.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double EuclideanNorm(Span<double> vector, int length)
        {
            var result = 0d;
            for (var i = 0; i < length; i++)
            {
                result += vector[i] * vector[i];
            }

            return Math.Sqrt(result);
        }
        #endregion
    }
}
