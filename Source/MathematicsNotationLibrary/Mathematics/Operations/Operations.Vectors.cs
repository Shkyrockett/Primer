// <copyright file="Operations.Vectors.cs" company="Shkyrockett" >
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
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary;

/// <summary>
/// Some standard shared operations to perform on Points, Vectors, and Sizes.
/// </summary>
public static partial class Operations
{
    #region Vector Type Conversions
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] Cast<T, TResult>(this Span<T> value)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = new TResult[value.Length];

        for (int i = 0; i < value.Length; i++)
        {
            result[i] = TResult.Create(value[i]);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] Cast<T, TResult>(this Span<T> value, int length)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = new TResult[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = TResult.Create(value[i]);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] CastSaturating<T, TResult>(this Span<T> value)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = new TResult[value.Length];

        for (int i = 0; i < value.Length; i++)
        {
            result[i] = TResult.CreateSaturating(value[i]);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] CastSaturating<T, TResult>(this Span<T> value, int length)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = new TResult[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = TResult.CreateSaturating(value[i]);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] CastTruncating<T, TResult>(this Span<T> value)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = new TResult[value.Length];

        for (int i = 0; i < value.Length; i++)
        {
            result[i] = TResult.CreateTruncating(value[i]);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <param name="length"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] CastTruncating<T, TResult>(this Span<T> value, int length)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = new TResult[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = TResult.CreateTruncating(value[i]);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y)? Cast<T, TResult>(this (T X, T Y) value) where T : INumber<T> where TResult : INumber<TResult> => (TResult.Create(value.X), TResult.Create(value.Y));

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y)? CastSaturating<T, TResult>(this (T X, T Y) value) where T : INumber<T> where TResult : INumber<TResult> => (TResult.CreateSaturating(value.X), TResult.CreateSaturating(value.Y));

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y)? CastTruncating<T, TResult>(this (T X, T Y) value) where T : INumber<T> where TResult : INumber<TResult> => (TResult.CreateTruncating(value.X), TResult.CreateTruncating(value.Y));

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z)? Cast<T, TResult>(this (T X, T Y, T Z) value) where T : INumber<T> where TResult : INumber<TResult> => (TResult.Create(value.X), TResult.Create(value.Y), TResult.Create(value.Z));

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z)? CastSaturating<T, TResult>(this (T X, T Y, T Z) value) where T : INumber<T> where TResult : INumber<TResult> => (TResult.CreateSaturating(value.X), TResult.CreateSaturating(value.Y), TResult.CreateSaturating(value.Z));

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z)? CastTruncating<T, TResult>(this (T X, T Y, T Z) value) where T : INumber<T> where TResult : INumber<TResult> => (TResult.CreateTruncating(value.X), TResult.CreateTruncating(value.Y), TResult.CreateTruncating(value.Z));

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W)? Cast<T, TResult>(this (T X, T Y, T Z, T W) value) where T : INumber<T> where TResult : INumber<TResult> => (TResult.Create(value.X), TResult.Create(value.Y), TResult.Create(value.Z), TResult.Create(value.W));

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W)? CastSaturating<T, TResult>(this (T X, T Y, T Z, T W) value) where T : INumber<T> where TResult : INumber<TResult> => (TResult.CreateSaturating(value.X), TResult.CreateSaturating(value.Y), TResult.CreateSaturating(value.Z), TResult.Create(value.W));

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W)? CastTruncating<T, TResult>(this (T X, T Y, T Z, T W) value) where T : INumber<T> where TResult : INumber<TResult> => (TResult.CreateTruncating(value.X), TResult.CreateTruncating(value.Y), TResult.CreateTruncating(value.Z), TResult.Create(value.W));

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W, TResult V)? Cast<T, TResult>(this (T X, T Y, T Z, T W, T V) value) where T : INumber<T> where TResult : INumber<TResult> => (TResult.Create(value.X), TResult.Create(value.Y), TResult.Create(value.Z), TResult.Create(value.W), TResult.Create(value.V));

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W, TResult V)? CastSaturating<T, TResult>(this (T X, T Y, T Z, T W, T V) value) where T : INumber<T> where TResult : INumber<TResult> => (TResult.CreateSaturating(value.X), TResult.CreateSaturating(value.Y), TResult.CreateSaturating(value.Z), TResult.Create(value.W), TResult.Create(value.V));

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W, TResult V)? CastTruncating<T, TResult>(this (T X, T Y, T Z, T W, T V) value) where T : INumber<T> where TResult : INumber<TResult> => (TResult.CreateTruncating(value.X), TResult.CreateTruncating(value.Y), TResult.CreateTruncating(value.Z), TResult.Create(value.W), TResult.Create(value.V));
    #endregion

    #region Vector Rounding
    /// <summary>
    /// Rounds the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="digits">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] Round<T, TResult>(Span<T> vector, int digits, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult>
    {
        var result = new TResult[vector.Length];
        for (var i = 0; i < vector.Length; i++)
        {
            result[i] = TResult.Create(T.Round(vector[i], digits, mode));
        }

        return result;
    }

    /// <summary>
    /// Rounds the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="length">The length.</param>
    /// <param name="digits">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] Round<T, TResult>(Span<T> vector, int length, int digits, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult>
    {
        var result = new TResult[length];
        for (var i = 0; i < length; i++)
        {
            result[i] = TResult.Create(T.Round(vector[i], digits, mode));
        }

        return result;
    }

    /// <summary>
    /// Rounds the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="digits">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y) Round<T, TResult>((T X, T Y) vector, int digits, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult> => (
            TResult.Create(T.Round(vector.X, digits, mode)),
            TResult.Create(T.Round(vector.Y, digits, mode))
        );

    /// <summary>
    /// Rounds the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="digits">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) Round<T, TResult>((T X, T Y, T Z) vector, int digits, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult> => (
            TResult.Create(T.Round(vector.X, digits, mode)),
            TResult.Create(T.Round(vector.Y, digits, mode)),
            TResult.Create(T.Round(vector.Z, digits, mode))
        );

    /// <summary>
    /// Rounds the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="digits">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W) Round<T, TResult>((T X, T Y, T Z, T W) vector, int digits, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult> => (
            TResult.Create(T.Round(vector.X, digits, mode)),
            TResult.Create(T.Round(vector.Y, digits, mode)),
            TResult.Create(T.Round(vector.Z, digits, mode)),
            TResult.Create(T.Round(vector.W, digits, mode))
        );

    /// <summary>
    /// Rounds the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="digits">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W, TResult V) Round<T, TResult>((T X, T Y, T Z, T W, T V) vector, int digits, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult> => (
            TResult.Create(T.Round(vector.X, digits, mode)),
            TResult.Create(T.Round(vector.Y, digits, mode)),
            TResult.Create(T.Round(vector.Z, digits, mode)),
            TResult.Create(T.Round(vector.W, digits, mode)),
            TResult.Create(T.Round(vector.V, digits, mode))
        );

    /// <summary>
    /// Rounds the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="digits">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W, TResult V, TResult U) Round<T, TResult>((T X, T Y, T Z, T W, T V, T U) vector, int digits, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult> => (
            TResult.Create(T.Round(vector.X, digits, mode)),
            TResult.Create(T.Round(vector.Y, digits, mode)),
            TResult.Create(T.Round(vector.Z, digits, mode)),
            TResult.Create(T.Round(vector.W, digits, mode)),
            TResult.Create(T.Round(vector.V, digits, mode)),
            TResult.Create(T.Round(vector.U, digits, mode))
        );

    /// <summary>
    /// Rounds the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="digits">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W, TResult V, TResult U, TResult T, TResult S) Round<T, TResult>((T X, T Y, T Z, T W, T V, T U, T T, T S) vector, int digits, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult> => (
            TResult.Create(T.Round(vector.X, digits, mode)),
            TResult.Create(T.Round(vector.Y, digits, mode)),
            TResult.Create(T.Round(vector.Z, digits, mode)),
            TResult.Create(T.Round(vector.W, digits, mode)),
            TResult.Create(T.Round(vector.V, digits, mode)),
            TResult.Create(T.Round(vector.U, digits, mode)),
            TResult.Create(T.Round(vector.T, digits, mode)),
            TResult.Create(T.Round(vector.S, digits, mode))
        );

    /// <summary>
    /// Rounds the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="digits">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        TResult X, TResult Y, TResult Z,
        TResult W, TResult V, TResult U,
        TResult T, TResult S, TResult R)
        Round<T, TResult>(
        (
        T X, T Y, T Z,
        T W, T V, T U,
        T T, T S, T R) vector, int digits, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult> => (
            TResult.Create(T.Round(vector.X, digits, mode)),
            TResult.Create(T.Round(vector.Y, digits, mode)),
            TResult.Create(T.Round(vector.Z, digits, mode)),
            TResult.Create(T.Round(vector.W, digits, mode)),
            TResult.Create(T.Round(vector.V, digits, mode)),
            TResult.Create(T.Round(vector.U, digits, mode)),
            TResult.Create(T.Round(vector.T, digits, mode)),
            TResult.Create(T.Round(vector.S, digits, mode)),
            TResult.Create(T.Round(vector.R, digits, mode))
        );

    /// <summary>
    /// Rounds the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="digits">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        TResult X, TResult Y, TResult Z, TResult W,
        TResult V, TResult U, TResult T, TResult S,
        TResult R, TResult Q, TResult P, TResult O,
        TResult N, TResult M, TResult L, TResult K)
        Round<T, TResult>(
        (T X, T Y, T Z, T W,
        T V, T U, T T, T S,
        T R, T Q, T P, T O,
        T N, T M, T L, T K) vector, int digits, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult> => (
            TResult.Create(T.Round(vector.X, digits, mode)),
            TResult.Create(T.Round(vector.Y, digits, mode)),
            TResult.Create(T.Round(vector.Z, digits, mode)),
            TResult.Create(T.Round(vector.W, digits, mode)),
            TResult.Create(T.Round(vector.V, digits, mode)),
            TResult.Create(T.Round(vector.U, digits, mode)),
            TResult.Create(T.Round(vector.T, digits, mode)),
            TResult.Create(T.Round(vector.S, digits, mode)),
            TResult.Create(T.Round(vector.R, digits, mode)),
            TResult.Create(T.Round(vector.Q, digits, mode)),
            TResult.Create(T.Round(vector.P, digits, mode)),
            TResult.Create(T.Round(vector.O, digits, mode)),
            TResult.Create(T.Round(vector.N, digits, mode)),
            TResult.Create(T.Round(vector.M, digits, mode)),
            TResult.Create(T.Round(vector.L, digits, mode)),
            TResult.Create(T.Round(vector.K, digits, mode))
        );

    /// <summary>
    /// Rounds the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="digits">The accuracy.</param>
    /// <param name="mode"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        TResult X, TResult Y, TResult Z, TResult W, TResult V,
        TResult U, TResult T, TResult S, TResult R, TResult Q,
        TResult P, TResult O, TResult N, TResult M, TResult L,
        TResult K, TResult J, TResult I, TResult H, TResult G,
        TResult F, TResult E, TResult D, TResult C, TResult B)
        Round<T, TResult>(
        (T X, T Y, T Z, T W, T V,
        T U, T T, T S, T R, T Q,
        T P, T O, T N, T M, T L,
        T K, T J, T I, T H, T G,
        T F, T E, T D, T C, T B) vector, int digits, MidpointRounding mode = MidpointRounding.ToEven)
        where T : IFloatingPoint<T>
        where TResult : INumber<TResult> => (
            TResult.Create(T.Round(vector.X, digits, mode)),
            TResult.Create(T.Round(vector.Y, digits, mode)),
            TResult.Create(T.Round(vector.Z, digits, mode)),
            TResult.Create(T.Round(vector.W, digits, mode)),
            TResult.Create(T.Round(vector.V, digits, mode)),
            TResult.Create(T.Round(vector.U, digits, mode)),
            TResult.Create(T.Round(vector.T, digits, mode)),
            TResult.Create(T.Round(vector.S, digits, mode)),
            TResult.Create(T.Round(vector.R, digits, mode)),
            TResult.Create(T.Round(vector.Q, digits, mode)),
            TResult.Create(T.Round(vector.P, digits, mode)),
            TResult.Create(T.Round(vector.O, digits, mode)),
            TResult.Create(T.Round(vector.N, digits, mode)),
            TResult.Create(T.Round(vector.M, digits, mode)),
            TResult.Create(T.Round(vector.L, digits, mode)),
            TResult.Create(T.Round(vector.K, digits, mode)),
            TResult.Create(T.Round(vector.J, digits, mode)),
            TResult.Create(T.Round(vector.I, digits, mode)),
            TResult.Create(T.Round(vector.H, digits, mode)),
            TResult.Create(T.Round(vector.G, digits, mode)),
            TResult.Create(T.Round(vector.F, digits, mode)),
            TResult.Create(T.Round(vector.E, digits, mode)),
            TResult.Create(T.Round(vector.D, digits, mode)),
            TResult.Create(T.Round(vector.C, digits, mode)),
            TResult.Create(T.Round(vector.B, digits, mode))
        );
    #endregion

    #region Copy Vector
    /// <summary>
    /// Copies the vector.
    /// </summary>
    /// <param name="originalVector">The original vector.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[]? CopyVector<T>(Span<T> originalVector)
    {
        if (originalVector == null)
        {
            return Array.Empty<T>();
        }

        var result = new T[originalVector.Length];
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[]? CopyVector<T>(Span<T> originalVector, int length)
    {
        if (originalVector == null)
        {
            return Array.Empty<T>();
        }

        var result = new T[length];
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
    public static (int, T[], int[]) DictionaryToVector<T>(Dictionary<T, int> EigenvaluesAndMultiplicity)
        where T : INumber<T>
    {
        var Eigenvalues = new T[EigenvaluesAndMultiplicity.Count];
        EigenvaluesAndMultiplicity.Keys.CopyTo(Eigenvalues, 0);
        var Multiplicity = new int[EigenvaluesAndMultiplicity.Count];
        EigenvaluesAndMultiplicity.Values.CopyTo(Multiplicity, 0);
        return (EigenvaluesAndMultiplicity.Count, Eigenvalues, Multiplicity);
    }
    #endregion
}
