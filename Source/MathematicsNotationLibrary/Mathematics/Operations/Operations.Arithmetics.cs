// <copyright file="Operations.Arithmetics.cs" company="Shkyrockett" >
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
/// Arithmetic Operations class.
/// </summary>
public static partial class Operations
{
    #region Scaler Equality
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TLeft"></typeparam>
    /// <typeparam name="TRight"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool Equals<TLeft, TRight>(TLeft left, TRight right) where TLeft : INumber<TLeft> where TRight : INumber<TRight> => left == TLeft.Create(right);
    #endregion

    #region Scaler Inequality
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TLeft"></typeparam>
    /// <typeparam name="TRight"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool NotEquals<TLeft, TRight>(TLeft left, TRight right) where TLeft : INumber<TLeft> where TRight : INumber<TRight> => !Equals(left, right);
    #endregion

    #region Scaler Plus
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Plus<T, TResult>(T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.Create(+value);
    #endregion

    #region Scaler Addition
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TLeft"></typeparam>
    /// <typeparam name="TRight"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/#trying-out-the-features
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Add<TLeft, TRight, TResult>(TLeft left, TRight right) where TLeft : INumber<TLeft> where TRight : INumber<TRight> where TResult : INumber<TResult> => TResult.Create(left) + TResult.Create(right);
    #endregion

    #region Scaler Incrementation
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Increment<T, TResult>(T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.Create(value) + TResult.One;
    #endregion

    #region Scaler Negation
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Negate<T, TResult>(T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.Create(-value);
    #endregion

    #region Scaler Subtraction
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TLeft"></typeparam>
    /// <typeparam name="TRight"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Subtract<TLeft, TRight, TResult>(TLeft left, TLeft right) where TLeft : INumber<TLeft> where TRight : INumber<TRight> where TResult : INumber<TResult> => TResult.Create(left) - TResult.Create(right);
    #endregion

    #region Scaler decrementation
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Decrement<T, TResult>(T value) where T : INumber<T> where TResult : INumber<TResult> => TResult.Create(value) - TResult.One;
    #endregion

    #region Scaler Multiplication
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TLeft"></typeparam>
    /// <typeparam name="TRight"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Multiply<TLeft, TRight, TResult>(TLeft left, TLeft right) where TLeft : INumber<TLeft> where TRight : INumber<TRight> where TResult : INumber<TResult> => TResult.Create(left) * TResult.Create(right);
    #endregion

    #region Scaler Division
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TLeft"></typeparam>
    /// <typeparam name="TRight"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Divide<TLeft, TRight, TResult>(TLeft left, TLeft right) where TLeft : INumber<TLeft> where TRight : INumber<TRight> where TResult : INumber<TResult> => TResult.Create(left) / TResult.Create(right);
    #endregion

    #region Scaler Modulus
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TLeft"></typeparam>
    /// <typeparam name="TRight"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Modulus<TLeft, TRight, TResult>(TLeft left, TLeft right) where TLeft : INumber<TLeft> where TRight : INumber<TRight> where TResult : INumber<TResult> => TResult.Create(left) % TResult.Create(right);
    #endregion

    #region Modulo
    /// <summary>
    /// Imitation of Excel's Mod Operator
    /// </summary>
    /// <param name="left">Source parameter</param>
    /// <param name="right">Destination parameter</param>
    /// <returns>
    /// Returns the same Modulus Result that Excel returns.
    /// </returns>
    /// <remarks>
    /// <para>Created after finding out Excel returns a different value for the Mod Operator than .Net</para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Modulo<TLeft, TRight, TResult>(this TLeft left, TRight right) where TLeft : INumber<TLeft> where TRight : INumber<TRight> where TResult : INumber<TResult>
    {
        var l = TResult.Create(left);
        var r = TResult.Create(right);
        return ((l %= r) < TResult.Zero) ? l + r : l;
    }
    #endregion

    #region Greatest Common Divisor
    /// <summary>
    /// Return the greatest common divisor (GCD) of a and b.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="b">The b.</param>
    /// <returns>The <see cref="long"/>.</returns>
    /// <acknowledgment>
    /// http://csharphelper.com/blog/2014/08/calculate-the-greatest-common-divisor-gcd-and-least-common-multiple-lcm-of-two-integers-in-c/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T GCD<T>(T a, T b)
        where T : INumber<T>
    {
        T remainder;

        // Pull out remainders.
        for (; ; )
        {
            remainder = a % b;
            if (remainder == T.Zero)
            {
                break;
            }

            a = b;
            b = remainder;
        }

        return b;
    }
    #endregion
}
