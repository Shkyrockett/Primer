// <copyright file="Operations.cs" company="Shkyrockett" >
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
public static partial class Operations
{
    #region Random
    /// <summary>
    /// Initialize random number generator with seed based on time.
    /// </summary>
    [ThreadStatic]
    public static readonly Random RandomNumberGenerator = new((int)DateTime.Now.Ticks & 0x0000FFFF);

    /// <summary>
    /// The random.
    /// </summary>
    /// <param name="lower">The Lower.</param>
    /// <param name="upper">The Upper.</param>
    /// <returns>The random number.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Random<T>(this T lower, T upper) where T : INumber<T> => (T.Create(RandomNumberGenerator.Next()) * (upper - lower + T.One)) + lower;
    #endregion

    #region Rounding
    /// <summary>
    /// Rounds the specified number.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Round<T, TResult>(T number, int accuracy) where T : IFloatingPoint<T> where TResult : INumber<TResult> => (accuracy < 15) ? TResult.Create(T.Round(number, accuracy)) : TResult.Create(number);
    #endregion

    #region Clamp
    /// <summary>
    /// Keep the value between the maximum and minimum.
    /// </summary>
    /// <param name="value">The value to clamp.</param>
    /// <param name="min">The lower limit the value should be above.</param>
    /// <param name="max">The upper limit the value should be under.</param>
    /// <returns>A value clamped between the maximum and minimum values.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Clamp<T>(this T value, T min, T max) where T : INumber<T> => value > max ? max : value < min ? min : value;
    #endregion

    #region Wrapping
    /// <summary>
    /// The wrap.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="min">The min.</param>
    /// <param name="max">The max.</param>
    /// <returns>The <see cref="double"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Wrap<T>(this T value, T min, T max) where T : INumber<T> => (value < min) ? max - ((min - value) % (max - min)) : min + ((value - min) % (max - min));
    #endregion Wrapping

    #region Type Conversions
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool TryCast<T, TResult>(this T value, out TResult result) where T : INumber<T> where TResult : INumber<TResult> => TResult.TryCreate(value, out result);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult? TryCastOrDefault<T, TResult>(this T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.TryCreate(value, out TResult? result) ? result : default;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult? Cast<T, TResult>(this T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.Create(value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult? CastSaturating<T, TResult>(this T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.CreateSaturating(value);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult? CastTruncating<T, TResult>(this T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.CreateTruncating(value);
    #endregion
}
