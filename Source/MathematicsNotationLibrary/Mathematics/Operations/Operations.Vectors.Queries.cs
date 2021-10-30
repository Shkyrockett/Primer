// <copyright file="Operations.Vectors.Queries.cs" company="Shkyrockett" >
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
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
public static partial class Operations
{
    #region Is Scaler
    /// <summary>
    /// Determines whether the specified vector is a scaler.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <returns>
    ///   <see langword="true" /> if the specified vector is scaler; otherwise, <see langword="false" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsScaler<T>(Span<T> vector) => vector.Length == 1;
    #endregion

    #region Vector Equality
    /// <summary>
    /// Equals the vectors.
    /// </summary>
    /// <param name="vector1">The vector1.</param>
    /// <param name="vector2">The vector2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool VectorsEquality<T>(Span<T> vector1, Span<T> vector2)
        where T : INumber<T>
    {
        if (vector1.Length != vector2.Length)
        {
            return false;
        }

        for (var i = 0; i < vector1.Length; i++)
        {
            if (vector1[i] != vector2[i])
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Equals the vectors.
    /// </summary>
    /// <param name="vector1">The vector1.</param>
    /// <param name="vector2">The vector2.</param>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool VectorsEquality<T>(Span<T> vector1, Span<T> vector2, int length)
        where T : INumber<T>
    {
        for (var i = 0; i < length; i++)
        {
            if (vector1[i] != vector2[i])
            {
                return false;
            }
        }

        return true;
    }
    #endregion

    #region Vector Equality Rounded
    /// <summary>
    /// Equals the vectors.
    /// </summary>
    /// <param name="vector1">The vector1.</param>
    /// <param name="vector2">The vector2.</param>
    /// <param name="accuracy"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool VectorsEqualityRounded<T>(Span<T> vector1, Span<T> vector2, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
    {
        if (vector1.Length != vector2.Length)
        {
            return false;
        }

        for (var i = 0; i < vector1.Length; i++)
        {
            var v1_rounded = T.Round(vector1[i], accuracy, mode);
            var v2_rounded = T.Round(vector2[i], accuracy, mode);
            if (v1_rounded != v2_rounded)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Equals the vectors.
    /// </summary>
    /// <param name="vector1">The vector1.</param>
    /// <param name="vector2">The vector2.</param>
    /// <param name="length">The length.</param>
    /// <param name="accuracy"></param>
    /// <param name="mode"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool VectorsEqualityRounded<T>(Span<T> vector1, Span<T> vector2, int length, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
    {
        var Equal = true;
        for (var i = 0; i < length; i++)
        {
            var v1_rounded = T.Round(vector1[i], accuracy, mode);
            var v2_rounded = T.Round(vector2[i], accuracy, mode);
            if (v1_rounded != v2_rounded)
            {
                Equal = false;
                break;
            }
        }
        return Equal;
    }
    #endregion

    #region Is Additive Identity
    /// <summary>
    /// Determines whether the specified vector components are all equal to zero.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <returns>
    ///   <see langword="true"/> if the vector is only zeros, otherwise <see langword="false"/>.
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsAdditiveIdentity<T>(Span<T> vector)
        where T : INumber<T>
    {
        for (var i = 0; i < vector.Length; i++)
        {
            if (vector[i] != T.Zero)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether the specified vector components are all equal to zero.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="length">The length.</param>
    /// <returns>
    ///   <see langword="true"/> if the vector is only zeros, otherwise <see langword="false"/>.
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsAdditiveIdentity<T>(Span<T> vector, int length)
        where T : INumber<T>
    {
        for (var i = 0; i < length; i++)
        {
            if (vector[i] != T.Zero)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether the vector is an empty additive identity vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <returns>
    ///   <see langword="true"/> if the vector is only zeros, otherwise <see langword="false"/>.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsAdditiveIdentity<T>(T i, T j) where T : IFloatingPoint<T> => T.Abs(i) < T.Epsilon && T.Abs(j) < T.Epsilon;

    /// <summary>
    /// Determines whether the vector is an empty additive identity vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="k">The k.</param>
    /// <returns>
    ///   <see langword="true"/> if the vector is only zeros, otherwise <see langword="false"/>.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsAdditiveIdentity<T>(T i, T j, T k) where T : IFloatingPoint<T> => T.Abs(i) < T.Epsilon && T.Abs(j) < T.Epsilon && T.Abs(k) < T.Epsilon;

    /// <summary>
    /// Determines whether the vector is an empty additive identity vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="k">The k.</param>
    /// <param name="l">The l.</param>
    /// <returns>
    ///   <see langword="true"/> if the vector is only zeros, otherwise <see langword="false"/>.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsAdditiveIdentity<T>(T i, T j, T k, T l) where T : IFloatingPoint<T> => T.Abs(i) < T.Epsilon && T.Abs(j) < T.Epsilon && T.Abs(k) < T.Epsilon && T.Abs(l) < T.Epsilon;

    /// <summary>
    /// Determines whether the vector is an empty additive identity vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="k">The k.</param>
    /// <param name="l">The l.</param>
    /// <param name="m">The m.</param>
    /// <returns>
    ///   <see langword="true"/> if the vector is only zeros, otherwise <see langword="false"/>.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsAdditiveIdentity<T>(T i, T j, T k, T l, T m) where T : IFloatingPoint<T> => T.Abs(i) < T.Epsilon && T.Abs(j) < T.Epsilon && T.Abs(k) < T.Epsilon && T.Abs(l) < T.Epsilon && T.Abs(m) < T.Epsilon;

    /// <summary>
    /// Determines whether the vector is an empty additive identity vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="k">The k.</param>
    /// <param name="l">The l.</param>
    /// <param name="m">The m.</param>
    /// <param name="n">The n.</param>
    /// <returns>
    ///   <see langword="true"/> if the vector is only zeros, otherwise <see langword="false"/>.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsAdditiveIdentity<T>(T i, T j, T k, T l, T m, T n) where T : IFloatingPoint<T> => T.Abs(i) < T.Epsilon && T.Abs(j) < T.Epsilon && T.Abs(k) < T.Epsilon && T.Abs(l) < T.Epsilon && T.Abs(m) < T.Epsilon && T.Abs(n) < T.Epsilon;
    #endregion

    #region Vector Is Zero Rounded
    /// <summary>
    /// Determines whether the specified vector components are all equal to zero.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns>
    ///   <see langword="true" /> if the specified vector is zero; otherwise, <see langword="false" />.
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsZeroRounded<T>(Span<T> vector, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
    {
        for (var i = 0; i < vector.Length; i++)
        {
            if (T.Round(vector[i], accuracy, mode) != T.Zero)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether the specified vector components are all equal to zero.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="length">The length.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns>
    ///   <see langword="true" /> if [is vector zero] [the specified vector]; otherwise, <see langword="false" />.
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsZeroRounded<T>(Span<T> vector, int length, int accuracy, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
    {
        for (var i = 0; i < length; i++)
        {
            if (T.Round(vector[i], accuracy, mode) != T.Zero)
            {
                return false;
            }
        }

        return true;
    }
    #endregion

    #region Is Multiplicative Identity
    /// <summary>
    /// Determines whether the specified vector components are all equal to one.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <returns>
    ///   <see langword="true" /> if the specified vector is one; otherwise, <see langword="false" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsMultiplicativeIdentity<T>(Span<T> vector)
        where T : INumber<T>
    {
        for (var i = 0; i < vector.Length; i++)
        {
            if (vector[i] != T.One)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Determines whether the specified vector components are all equal to one.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="length">The length.</param>
    /// <returns>
    ///   <see langword="true" /> if the specified vector is one; otherwise, <see langword="false" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsMultiplicativeIdentity<T>(Span<T> vector, int length)
        where T : INumber<T>
    {
        for (var i = 0; i < length; i++)
        {
            if (vector[i] != T.One)
            {
                return false;
            }
        }

        return true;
    }
    #endregion

    #region Is Unit Vector
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="vector"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsUnitVector<T>(Span<T> vector) where T : IFloatingPoint<T> => T.Abs(Magnitude<T, T>(vector) - T.One) < T.Epsilon;

    /// <summary>
    /// The is unit vector.
    /// </summary>
    /// <param name="i">The i1.</param>
    /// <param name="j">The j1.</param>
    /// <returns>
    /// The <see cref="bool" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsUnitVector<T>(T i, T j) where T : IFloatingPoint<T> => T.Abs(Magnitude<T, T>(i, j) - T.One) < T.Epsilon;

    /// <summary>
    /// The is unit vector.
    /// </summary>
    /// <param name="i">The i1.</param>
    /// <param name="j">The j1.</param>
    /// <param name="k">The k1.</param>
    /// <returns>
    /// The <see cref="bool" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsUnitVector<T>(T i, T j, T k) where T : IFloatingPoint<T> => T.Abs(Magnitude<T, T>(i, j, k) - T.One) < T.Epsilon;

    /// <summary>
    /// The is unit vector.
    /// </summary>
    /// <param name="i">The i1.</param>
    /// <param name="j">The j1.</param>
    /// <param name="k">The k1.</param>
    /// <param name="l">The l.</param>
    /// <returns>
    /// The <see cref="bool" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsUnitVector<T>(T i, T j, T k, T l) where T : IFloatingPoint<T> => T.Abs(Magnitude<T, T>(i, j, k, l) - T.One) < T.Epsilon;

    /// <summary>
    /// The is unit vector.
    /// </summary>
    /// <param name="i">The i1.</param>
    /// <param name="j">The j1.</param>
    /// <param name="k">The k1.</param>
    /// <param name="l">The l.</param>
    /// <param name="m">The m.</param>
    /// <returns>
    /// The <see cref="bool" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsUnitVector<T>(T i, T j, T k, T l, T m) where T : IFloatingPoint<T> => T.Abs(Magnitude<T, T>(i, j, k, l, m) - T.One) < T.Epsilon;

    /// <summary>
    /// The is unit vector.
    /// </summary>
    /// <param name="i">The i1.</param>
    /// <param name="j">The j1.</param>
    /// <param name="k">The k1.</param>
    /// <param name="l">The l.</param>
    /// <param name="m">The m.</param>
    /// <param name="n">The n.</param>
    /// <returns>
    /// The <see cref="bool" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool IsUnitVector<T>(T i, T j, T k, T l, T m, T n) where T : IFloatingPoint<T> => T.Abs(Magnitude<T, T>(i, j, k, l, m, n) - T.One) < T.Epsilon;
    #endregion
}
