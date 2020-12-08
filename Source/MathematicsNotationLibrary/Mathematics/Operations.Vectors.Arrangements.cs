// <copyright file="Operations.Vectors.Arrangements.Array.cs" company="Shkyrockett" >
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
using System.Collections.Generic;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Operations
    {
        #region Copy Vector
        /// <summary>
        /// Copies the vector.
        /// </summary>
        /// <param name="originalVector">The original vector.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static float[] CopyVector(Span<float> originalVector)
        {
            if (originalVector == null)
            {
                return null;
            }

            var result = new float[originalVector.Length];
            originalVector.CopyTo(result);

            return result;
        }

        /// <summary>
        /// Copies the vector.
        /// </summary>
        /// <param name="originalVector">The original vector.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[] CopyVector(Span<double> originalVector)
        {
            if (originalVector == null)
            {
                return null;
            }

            var result = new double[originalVector.Length];
            originalVector.CopyTo(result);

            return result;
        }

        /// <summary>
        /// Copies the vector.
        /// </summary>
        /// <param name="originalVector">The original vector.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static float[] CopyVector(Span<float> originalVector, int length)
        {
            if (originalVector == null)
            {
                return null;
            }

            var result = new float[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = originalVector[i];
            }

            return result;
        }

        /// <summary>
        /// Copies the vector.
        /// </summary>
        /// <param name="originalVector">The original vector.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[] CopyVector(Span<double> originalVector, int length)
        {
            if (originalVector == null)
            {
                return null;
            }

            var result = new double[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = originalVector[i];
            }

            return result;
        }
        #endregion

        #region Dictionary to Vector
        /// <summary>
        /// Converts the dictionary to two vectors.
        /// </summary>
        /// <param name="EigenvaluesAndMultiplicity">The eigenvalues and multiplicity.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static (int, double[], int[]) DictionaryToVector(Dictionary<double, int> EigenvaluesAndMultiplicity)
        {
            var Eigenvalues = new double[EigenvaluesAndMultiplicity.Count];
            EigenvaluesAndMultiplicity.Keys.CopyTo(Eigenvalues, 0);
            var Multiplicity = new int[EigenvaluesAndMultiplicity.Count];
            EigenvaluesAndMultiplicity.Values.CopyTo(Multiplicity, 0);
            return (EigenvaluesAndMultiplicity.Count, Eigenvalues, Multiplicity);
        }
        #endregion
    }
}
