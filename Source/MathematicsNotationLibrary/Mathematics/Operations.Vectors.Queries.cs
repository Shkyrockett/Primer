// <copyright file="Operations.Vectors.Queries.Array.cs" company="Shkyrockett" >
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
        #region Equality
        /// <summary>
        /// Equals the vectors.
        /// </summary>
        /// <param name="vector1">The vector1.</param>
        /// <param name="vector2">The vector2.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static bool VectorsEquality(Span<double> vector1, Span<double> vector2)
        {
            if (vector1.Length != vector2.Length) return false;
            var Equal = true;
            for (var i = 0; i < vector1.Length; i++)
            {
                var v1_rounded = Round(vector1[i], 0);
                var v2_rounded = Round(vector2[i], 0);
                if (v1_rounded != v2_rounded)
                {
                    Equal = false;
                    break;
                }
            }
            return Equal;
        }

        /// <summary>
        /// Equals the vectors.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <param name="vector1">The vector1.</param>
        /// <param name="vector2">The vector2.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static bool VectorsEquality(int length, Span<double> vector1, Span<double> vector2)
        {
            var Equal = true;
            for (var i = 0; i < length; i++)
            {
                var v1_rounded = Round(vector1[i], 0);
                var v2_rounded = Round(vector2[i], 0);
                if (v1_rounded != v2_rounded)
                {
                    Equal = false;
                    break;
                }
            }
            return Equal;
        }
        #endregion
    }
}
