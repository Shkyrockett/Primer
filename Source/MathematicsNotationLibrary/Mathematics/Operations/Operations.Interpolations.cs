// <copyright file="Operations.Interpolations.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using Microsoft.Toolkit.HighPerformance;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
public static partial class Operations
{
    #region Linear Interpolate
    /// <summary>
    /// The linear interpolation method.
    /// </summary>
    /// <param name="u0">The u0.</param>
    /// <param name="u1">The u1.</param>
    /// <param name="t">The t.</param>
    /// <returns>
    /// The linear interpolation method.
    /// </returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Lerp<T>(T u0, T u1, T t) where T : INumber<T> => u0 + ((u1 - u0) * t);
    #endregion

    #region Vector Linear Interpolate
    /// <summary>
    /// Linear Interpolates the specified a.
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <param name="amount">The amount.</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Lerp<T>(Span<T> a, Span<T> b, T amount)
        where T : INumber<T>
    {
        var leftLength = a.Length;
        var rightLength = b.Length;

        if (leftLength != rightLength)
        {
            throw new Exception();
        }

        var results = new T[leftLength];
        for (var i = 0; i < leftLength; i++)
        {
            results[i] = a[i] + ((b[i] - a[i]) * amount);
        }

        return results;
    }

    /// <summary>
    /// The linear interpolation method.
    /// </summary>
    /// <param name="x0">The x0.</param>
    /// <param name="y0">The y0.</param>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="t">The t.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2}"/>.</returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) Lerp<T>(T x0, T y0, T x1, T y1, T t) where T : INumber<T> => (x0 + ((x1 - x0) * t), y0 + ((y1 - y0) * t));

    /// <summary>
    /// The linear interpolation method.
    /// </summary>
    /// <param name="x0">The x0.</param>
    /// <param name="y0">The y0.</param>
    /// <param name="z0">The z0.</param>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="t">The t.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2, T3}"/>.</returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) Lerp<T>(T x0, T y0, T z0, T x1, T y1, T z1, T t) where T : INumber<T> => (x0 + ((x1 - x0) * t), y0 + ((y1 - y0) * t), z0 + ((z1 - z0) * t));

    /// <summary>
    /// The linear interpolation method.
    /// </summary>
    /// <param name="x0">The x0.</param>
    /// <param name="y0">The y0.</param>
    /// <param name="z0">The z0.</param>
    /// <param name="w0">The w0.</param>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="w1">The w1.</param>
    /// <param name="t">The t.</param>
    /// <returns>The <see cref="ValueTuple{T1, T2, T3, T4}"/>.</returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) Lerp<T>(T x0, T y0, T z0, T w0, T x1, T y1, T z1, T w1, T t) where T : INumber<T> => (x0 + ((x1 - x0) * t), y0 + ((y1 - y0) * t), z0 + ((z1 - z0) * t), w0 + ((w1 - w0) * t));

    /// <summary>
    /// The linear interpolation method.
    /// </summary>
    /// <param name="x0">The x0.</param>
    /// <param name="y0">The y0.</param>
    /// <param name="z0">The z0.</param>
    /// <param name="w0">The w0.</param>
    /// <param name="v0">The v0.</param>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="w1">The w1.</param>
    /// <param name="v1">The v1.</param>
    /// <param name="t">The t.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3, T4, T5}" />.
    /// </returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) Lerp<T>(T x0, T y0, T z0, T w0, T v0, T x1, T y1, T z1, T w1, T v1, T t) where T : INumber<T> => (x0 + ((x1 - x0) * t), y0 + ((y1 - y0) * t), z0 + ((z1 - z0) * t), w0 + ((w1 - w0) * t), v0 + ((v1 - v0) * t));

    /// <summary>
    /// The linear interpolation method.
    /// </summary>
    /// <param name="x0">The x0.</param>
    /// <param name="y0">The y0.</param>
    /// <param name="z0">The z0.</param>
    /// <param name="w0">The w0.</param>
    /// <param name="v0">The v0.</param>
    /// <param name="u0">The u0.</param>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="w1">The w1.</param>
    /// <param name="v1">The v1.</param>
    /// <param name="u1">The u1.</param>
    /// <param name="t">The t.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3, T4, T5, T6}" />.
    /// </returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V, T U) Lerp<T>(T x0, T y0, T z0, T w0, T v0, T u0, T x1, T y1, T z1, T w1, T v1, T u1, T t) where T : INumber<T> => (x0 + ((x1 - x0) * t), y0 + ((y1 - y0) * t), z0 + ((z1 - z0) * t), w0 + ((w1 - w0) * t), v0 + ((v1 - v0) * t), u0 + ((u1 - u0) * t));
    #endregion

    #region Matrix Linear Interpolate
    /// <summary>
    /// Linear Interpolates the specified a.
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <param name="amount">The amount.</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Lerp<T>(Span2D<T> a, Span2D<T> b, T amount)
        where T : INumber<T>
    {
        var aRows = a.Height;
        var bRows = b.Height;
        var aCols = a.Width;
        var bCols = b.Width;

        if (aRows != bRows || aCols != bCols)
        {
            throw new Exception();
        }

        var results = new T[aRows, bRows];
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
}
