// <copyright file="Operations.Vectors.Arithmatics.Array.cs" company="Shkyrockett" >
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
        #region Vector Rounding
        /// <summary>
        /// Rounds the specified vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static float[] Round(Span<float> vector, int accuracy)
        {
            var Result = new float[vector.Length];
            if (accuracy < 15)
            {
                for (var i = 0; i < vector.Length; i++)
                {
                    Result[i] = MathF.Round(vector[i], accuracy);
                }
            }
            else
            {
                Result = CopyVector(vector);
            }

            return Result;
        }

        /// <summary>
        /// Rounds the specified vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[] Round(Span<double> vector, int accuracy)
        {
            var Result = new double[vector.Length];
            if (accuracy < 15)
            {
                for (var i = 0; i < vector.Length; i++)
                {
                    Result[i] = Math.Round(vector[i], accuracy);
                }
            }
            else
            {
                Result = CopyVector(vector);
            }

            return Result;
        }

        /// <summary>
        /// Rounds the specified vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="length">The length.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static float[] Round(Span<float> vector, int length, int accuracy)
        {
            var Result = new float[length];
            if (accuracy < 15)
            {
                for (var i = 0; i < length; i++)
                {
                    Result[i] = MathF.Round(vector[i], accuracy);
                }
            }
            else
            {
                Result = CopyVector(vector, length);
            }

            return Result;
        }

        /// <summary>
        /// Rounds the specified vector.
        /// </summary>
        /// <param name="vector">The vector.</param>
        /// <param name="length">The length.</param>
        /// <param name="accuracy">The accuracy.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[] Round(Span<double> vector, int length, int accuracy)
        {
            var Result = new double[length];
            if (accuracy < 15)
            {
                for (var i = 0; i < length; i++)
                {
                    Result[i] = Math.Round(vector[i], accuracy);
                }
            }
            else
            {
                Result = CopyVector(vector, length);
            }

            return Result;
        }
        #endregion

        #region Vector Scaling
        /// <summary>
        /// Vector multiplications by scalar.
        /// </summary>
        /// <param name="multiplicand">The scalar.</param>
        /// <param name="multiplier">The vector.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static float[] Scale(float multiplicand, Span<float> multiplier)
        {
            var result = new float[multiplier.Length];
            for (var i = 0; i < multiplier.Length; i++)
            {
                result[i] = multiplicand * multiplier[i];
            }

            return result;
        }

        /// <summary>
        /// Vector multiplications by scalar.
        /// </summary>
        /// <param name="multiplicand">The scalar.</param>
        /// <param name="multiplier">The vector.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[] Scale(double multiplicand, Span<double> multiplier)
        {
            var result = new double[multiplier.Length];
            for (var i = 0; i < multiplier.Length; i++)
            {
                result[i] = multiplicand * multiplier[i];
            }

            return result;
        }

        /// <summary>
        /// Vector multiplications by scalar.
        /// </summary>
        /// <param name="multiplicand">The scalar.</param>
        /// <param name="multiplier">The vector.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static float[] Scale(float multiplicand, Span<float> multiplier, int length)
        {
            var result = new float[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = multiplicand * multiplier[i];
            }

            return result;
        }

        /// <summary>
        /// Vector multiplications by scalar.
        /// </summary>
        /// <param name="multiplicand">The scalar.</param>
        /// <param name="multiplier">The vector.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[] Scale(double multiplicand, Span<double> multiplier, int length)
        {
            var result = new double[length];
            for (var i = 0; i < length; i++)
            {
                result[i] = multiplicand * multiplier[i];
            }

            return result;
        }
        #endregion

        #region Vector Multiplication
        /// <summary>
        /// Vector vs Vector Multiplication 1, internal usage
        /// </summary>
        /// <param name="rowVector">The row vector.</param>
        /// <param name="columnVector">The column vector.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double RowVectorColumnVectorMatrixMultiplication(Span<double> rowVector, Span<double> columnVector)
        {
            double result = 0;
            for (var i = 0; i < rowVector.Length; i++)
            {
                result += rowVector[i] * columnVector[i];
            }

            return result;
        }

        /// <summary>
        /// Vector vs Vector Multiplication 1, internal usage
        /// </summary>
        /// <param name="rowVector">The row vector.</param>
        /// <param name="columnVector">The column vector.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double RowVectorColumnVectorMatrixMultiplication(Span<double> rowVector, Span<double> columnVector, int length)
        {
            double result = 0;
            for (var i = 0; i < length; i++)
            {
                result += rowVector[i] * columnVector[i];
            }

            return result;
        }

        /// <summary>
        /// Vector vs Vector Multiplication 2, internal usage.
        /// </summary>
        /// <param name="colummnVector">The column vector.</param>
        /// <param name="rowVector">The row vector.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[,] ColumnVectorRowVectorMatrixMultiplication(Span<double> colummnVector, Span<double> rowVector)
        {
            var result = new double[colummnVector.Length, rowVector.Length];
            for (var i = 0; i < colummnVector.Length; i++)
            {
                for (var j = 0; j < rowVector.Length; j++)
                {
                    result[i, j] = colummnVector[i] * rowVector[j];
                }
            }

            return result;
        }

        /// <summary>
        /// Vector vs Vector Multiplication 2, internal usage.
        /// </summary>
        /// <param name="colummnVector">The column vector.</param>
        /// <param name="colummnLength">Length of the col.</param>
        /// <param name="rowVector">The row vector.</param>
        /// <param name="rowLength">Length of the row.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
        /// </acknowledgment>
        public static double[,] ColumnVectorRowVectorMatrixMultiplication(Span<double> colummnVector, int colummnLength, Span<double> rowVector, int rowLength)
        {
            var result = new double[colummnLength, rowLength];
            for (var i = 0; i < colummnLength; i++)
            {
                for (var j = 0; j < rowLength; j++)
                {
                    result[i, j] = colummnVector[i] * rowVector[j];
                }
            }

            return result;
        }
        #endregion
    }
}
