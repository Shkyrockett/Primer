// <copyright file="Factories.Vectors.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
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

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
public static partial class Factories
{
    #region Vector Multiplicative Identity
    /// <summary>
    /// Creates the multiplicative identity vector.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] MultiplicativeIdentity<T>(int length)
        where T : INumber<T>
    {
        var identity = new T[length];

        for (var i = 0; i < length; i++)
        {
            identity[i] = T.One;
        }

        return identity;
    }
    #endregion

    #region Vector Additive Identity
    /// <summary>
    /// Creates the additive identity matrix.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] AdditiveIdentity<T>(int length)
        where T : INumber<T>
    {
        var identity = new T[length];

        for (var i = 0; i < length; i++)
        {
            identity[i] = T.Zero;
        }

        return identity;
    }
    #endregion

    #region Vector Randomization
    /// <summary>
    /// Random vector generator.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] RandomNonZeroVector<T>(int length) where T : INumber<T> => RandomNonZeroVector(length, T.Zero, T.One / T.Create(1000));

    /// <summary>
    /// Random vector generator.
    /// </summary>
    /// <param name="length">The length.</param>
    /// <param name="lower"></param>
    /// <param name="upper"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] RandomNonZeroVector<T>(int length, T lower, T upper)
        where T : INumber<T>
    {
        var nonZero = false;

        var vector = new T[length];

        while (!nonZero)
        {
            for (var i = 0; i < length; i++)
            {
                vector[i] = Operations.Random(lower, upper);

                if (vector[i] != T.Zero)
                {
                    nonZero = true;
                }
            }
        }

        return vector;
    }
    #endregion

    #region Singular Value Decomposition Vectors
    /// <summary>
    /// SVD - eigenvalues change
    /// </summary>
    /// <param name="sortedEigenvalues">The sorted eigenvalues.</param>
    /// <param name="matrixARank">The matrix a rank.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] SingularValueDecompositionSingularValues<T, TResult>((int, T[], T[]) sortedEigenvalues, int matrixARank)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        var Eigenvalues_copy = (sortedEigenvalues.Item1, sortedEigenvalues.Item2, sortedEigenvalues.Item3);
        var the_result_singular_values = new TResult[matrixARank];

        var j = 0;
        var multiplicity = Eigenvalues_copy.Item3[j];
        for (var i = 0; i < matrixARank; i++)
        {
            the_result_singular_values[i] = TResult.Sqrt(TResult.Create(Eigenvalues_copy.Item2[j]));
            multiplicity--;
            if (multiplicity == T.Zero && j < sortedEigenvalues.Item1 - 1)
            {
                j++;
                multiplicity = Eigenvalues_copy.Item3[j];
            }
        }

        return the_result_singular_values;
    }
    #endregion
}
