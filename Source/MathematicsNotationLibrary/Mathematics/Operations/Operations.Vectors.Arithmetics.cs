// <copyright file="Operations.Vectors.Arithmetics.cs" company="Shkyrockett" >
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
    #region Min Point
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="augend"></param>
    /// <param name="addend"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] MinPoint<T>(Span<T> augend, Span<T> addend)
        where T : INumber<T>
    {
        var length = augend.Length;
        var sum = new T[length];

        for (int i = 0; i < length; i++)
        {
            sum[i] = T.Min(augend[i], addend[i]);
        }

        return sum;
    }

    /// <summary>
    /// The min point.
    /// </summary>
    /// <param name="point1X">The point1X.</param>
    /// <param name="point1Y">The point1Y.</param>
    /// <param name="point2X">The point2X.</param>
    /// <param name="point2Y">The point2Y.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.kevlindev.com/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) MinPoint<T>(T point1X, T point1Y, T point2X, T point2Y) where T : INumber<T> => (T.Min(point1X, point2X), T.Min(point1Y, point2Y));
    #endregion Min Point

    #region Max Point
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="augend"></param>
    /// <param name="addend"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] MaxPoint<T>(Span<T> augend, Span<T> addend)
        where T : INumber<T>
    {
        var length = augend.Length;
        var sum = new T[length];

        for (int i = 0; i < length; i++)
        {
            sum[i] = T.Max(augend[i], addend[i]);
        }

        return sum;
    }

    /// <summary>
    /// The max point.
    /// </summary>
    /// <param name="point1X">The point1X.</param>
    /// <param name="point1Y">The point1Y.</param>
    /// <param name="point2X">The point2X.</param>
    /// <param name="point2Y">The point2Y.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.kevlindev.com/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) MaxPoint<T>(T point1X, T point1Y, T point2X, T point2Y) where T : INumber<T> => (T.Max(point1X, point2X), T.Max(point1Y, point2Y));
    #endregion Max Point

    #region Unary Plus
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Plus<T>(Span<T> value)
        where T : INumber<T>
    {
        var length = value.Length;
        var sum = new T[length];

        for (int i = 0; i < length; i++)
        {
            sum[i] = +value[i];
        }

        return sum;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The addend a.</param>
    /// <param name="Y">The addend b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) PlusVectors<T>(T X, T Y) where T : INumber<T> => (+X, +Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The addend a.</param>
    /// <param name="Y">The addend b.</param>
    /// <param name="Z">The addend c.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) PlusVectors<T>(T X, T Y, T Z) where T : INumber<T> => (+X, +Y, +Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The addend a.</param>
    /// <param name="Y">The addend b.</param>
    /// <param name="Z">The addend c.</param>
    /// <param name="W">The addend d.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) PlusVectors<T>(T X, T Y, T Z, T W) where T : INumber<T> => (+X, +Y, +Z, +W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The addend a.</param>
    /// <param name="Y">The addend b.</param>
    /// <param name="Z">The addend c.</param>
    /// <param name="W">The addend d.</param>
    /// <param name="V">The addend e.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) PlusVectors<T>(T X, T Y, T Z, T W, T V) where T : INumber<T> => (+X, +Y, +Z, +W, +V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The addend a.</param>
    /// <param name="Y">The addend b.</param>
    /// <param name="Z">The addend c.</param>
    /// <param name="W">The addend d.</param>
    /// <param name="V">The addend e.</param>
    /// <param name="U">The addend f.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V, T U) PlusVectors<T>(T X, T Y, T Z, T W, T V, T U) where T : INumber<T> => (+X, +Y, +Z, +W, +V, +U);
    #endregion

    #region Increment
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Increment<T>(Span<T> value)
        where T : INumber<T>
    {
        var length = value.Length;
        var sum = new T[length];

        for (int i = 0; i < length; i++)
        {
            sum[i] = ++value[i];
        }

        return sum;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The addend a.</param>
    /// <param name="Y">The addend b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) IncrementVector<T>(T X, T Y) where T : INumber<T> => (++X, ++Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The addend a.</param>
    /// <param name="Y">The addend b.</param>
    /// <param name="Z">The addend c.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) IncrementVector<T>(T X, T Y, T Z) where T : INumber<T> => (++X, ++Y, ++Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The addend a.</param>
    /// <param name="Y">The addend b.</param>
    /// <param name="Z">The addend c.</param>
    /// <param name="W">The addend d.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) IncrementVector<T>(T X, T Y, T Z, T W) where T : INumber<T> => (++X, ++Y, ++Z, ++W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The addend a.</param>
    /// <param name="Y">The addend b.</param>
    /// <param name="Z">The addend c.</param>
    /// <param name="W">The addend d.</param>
    /// <param name="V">The addend e.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) IncrementVector<T>(T X, T Y, T Z, T W, T V) where T : INumber<T> => (++X, ++Y, ++Z, ++W, ++V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The addend a.</param>
    /// <param name="Y">The addend b.</param>
    /// <param name="Z">The addend c.</param>
    /// <param name="W">The addend d.</param>
    /// <param name="V">The addend e.</param>
    /// <param name="U">The addend f.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V, T U) IncrementVector<T>(T X, T Y, T Z, T W, T V, T U) where T : INumber<T> => (++X, ++Y, ++Z, ++W, ++V, ++U);
    #endregion

    #region Add Value To Vector
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="augend"></param>
    /// <param name="addend"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Add<T>(Span<T> augend, T addend)
        where T : INumber<T>
    {
        var length = augend.Length;
        var sum = new T[length];

        for (int i = 0; i < length; i++)
        {
            sum[i] = augend[i] + addend;
        }

        return sum;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="augend"></param>
    /// <param name="addend"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Add<T>(T augend, Span<T> addend)
        where T : INumber<T>
    {
        var length = addend.Length;
        var sum = new T[length];

        for (int i = 0; i < length; i++)
        {
            sum[i] = augend + addend[i];
        }

        return sum;
    }

    /// <summary>
    /// Adds the vector uniformly.
    /// </summary>
    /// <param name="augendA">The augend a.</param>
    /// <param name="augendB">The augend b.</param>
    /// <param name="addend">The addend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) AddVectorUniform<T>(T augendA, T augendB, T addend) where T : INumber<T> => (augendA + addend, augendB + addend);

    /// <summary>
    /// Adds the vector uniformly.
    /// </summary>
    /// <param name="augendA">The augend a.</param>
    /// <param name="augendB">The augend b.</param>
    /// <param name="augendC">The augend c.</param>
    /// <param name="addend">The addend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) AddVectorUniform<T>(T augendA, T augendB, T augendC, T addend) where T : INumber<T> => (augendA + addend, augendB + addend, augendC + addend);

    /// <summary>
    /// Adds the vector uniformly.
    /// </summary>
    /// <param name="augendA">The augend a.</param>
    /// <param name="augendB">The augend b.</param>
    /// <param name="augendC">The augend c.</param>
    /// <param name="augendD">The augend d.</param>
    /// <param name="addend">The addend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) AddVectorUniform<T>(T augendA, T augendB, T augendC, T augendD, T addend) where T : INumber<T> => (augendA + addend, augendB + addend, augendC + addend, augendD + addend);

    /// <summary>
    /// Adds the vector uniformly.
    /// </summary>
    /// <param name="augendA">The augend a.</param>
    /// <param name="augendB">The augend b.</param>
    /// <param name="augendC">The augend c.</param>
    /// <param name="augendD">The augend d.</param>
    /// <param name="augendE">The augend e.</param>
    /// <param name="addend">The addend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) AddVectorUniform<T>(T augendA, T augendB, T augendC, T augendD, T augendE, T addend) where T : INumber<T> => (augendA + addend, augendB + addend, augendC + addend, augendD + addend, augendE + addend);

    /// <summary>
    /// Adds the vector uniformly.
    /// </summary>
    /// <param name="augendA">The augend a.</param>
    /// <param name="augendB">The augend b.</param>
    /// <param name="augendC">The augend c.</param>
    /// <param name="augendD">The augend d.</param>
    /// <param name="augendE">The augend e.</param>
    /// <param name="augendF">The augend f.</param>
    /// <param name="addend">The addend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V, T U) AddVectorUniform<T>(T augendA, T augendB, T augendC, T augendD, T augendE, T augendF, T addend) where T : INumber<T> => (augendA + addend, augendB + addend, augendC + addend, augendD + addend, augendE + addend, augendF + addend);
    #endregion Add Value To Vector

    #region Add Two Vectors
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="augend"></param>
    /// <param name="addend"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Add<T>(Span<T> augend, Span<T> addend)
        where T : INumber<T>
    {
        var length = augend.Length;
        var sum = new T[length];

        for (int i = 0; i < length; i++)
        {
            sum[i] = augend[i] + addend[i];
        }

        return sum;
    }

    /// <summary>
    /// Adds the vectors.
    /// </summary>
    /// <param name="augendA">The augend a.</param>
    /// <param name="augendB">The augend b.</param>
    /// <param name="addendA">The addend a.</param>
    /// <param name="addendB">The addend b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B) AddVectors<T>(T augendA, T augendB, T addendA, T addendB) where T : INumber<T> => (augendA + addendA, augendB + addendB);

    /// <summary>
    /// Adds the vectors.
    /// </summary>
    /// <param name="augendA">The augend a.</param>
    /// <param name="augendB">The augend b.</param>
    /// <param name="augendC">The augend c.</param>
    /// <param name="addendA">The addend a.</param>
    /// <param name="addendB">The addend b.</param>
    /// <param name="addendC">The addend c.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C) AddVectors<T>(T augendA, T augendB, T augendC, T addendA, T addendB, T addendC) where T : INumber<T> => (augendA + addendA, augendB + addendB, augendC + addendC);

    /// <summary>
    /// Adds the vectors.
    /// </summary>
    /// <param name="augendA">The augend a.</param>
    /// <param name="augendB">The augend b.</param>
    /// <param name="augendC">The augend c.</param>
    /// <param name="augendD">The augend d.</param>
    /// <param name="addendA">The addend a.</param>
    /// <param name="addendB">The addend b.</param>
    /// <param name="addendC">The addend c.</param>
    /// <param name="addendD">The addend d.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D) AddVectors<T>(T augendA, T augendB, T augendC, T augendD, T addendA, T addendB, T addendC, T addendD) where T : INumber<T> => (augendA + addendA, augendB + addendB, augendC + addendC, augendD + addendD);

    /// <summary>
    /// Adds the vectors.
    /// </summary>
    /// <param name="augendA">The augend a.</param>
    /// <param name="augendB">The augend b.</param>
    /// <param name="augendC">The augend c.</param>
    /// <param name="augendD">The augend d.</param>
    /// <param name="augendE">The augend e.</param>
    /// <param name="addendA">The addend a.</param>
    /// <param name="addendB">The addend b.</param>
    /// <param name="addendC">The addend c.</param>
    /// <param name="addendD">The addend d.</param>
    /// <param name="addendE">The addend e.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E) AddVectors<T>(T augendA, T augendB, T augendC, T augendD, T augendE, T addendA, T addendB, T addendC, T addendD, T addendE) where T : INumber<T> => (augendA + addendA, augendB + addendB, augendC + addendC, augendD + addendD, augendE + addendE);

    /// <summary>
    /// Adds the vectors.
    /// </summary>
    /// <param name="augendA">The augend a.</param>
    /// <param name="augendB">The augend b.</param>
    /// <param name="augendC">The augend c.</param>
    /// <param name="augendD">The augend d.</param>
    /// <param name="augendE">The augend e.</param>
    /// <param name="augendF">The augend f.</param>
    /// <param name="addendA">The addend a.</param>
    /// <param name="addendB">The addend b.</param>
    /// <param name="addendC">The addend c.</param>
    /// <param name="addendD">The addend d.</param>
    /// <param name="addendE">The addend e.</param>
    /// <param name="addendF">The addend f.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E, T F) AddVectors<T>(T augendA, T augendB, T augendC, T augendD, T augendE, T augendF, T addendA, T addendB, T addendC, T addendD, T addendE, T addendF) where T : INumber<T> => (augendA + addendA, augendB + addendB, augendC + addendC, augendD + addendD, augendE + addendE, augendF + addendF);
    #endregion Add Two Vectors

    #region Negation
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Negate<T>(Span<T> value)
        where T : INumber<T>
    {
        var length = value.Length;

        var difference = new T[length];

        for (int i = 0; i < length; i++)
        {
            difference[i] = -value[i];
        }

        return difference;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) NegateVector<T>(T X, T Y) where T : INumber<T> => (-X, -Y);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) NegateVector<T>(T X, T Y, T Z) where T : INumber<T> => (-X, -Y, -Z);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    /// <param name="W"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) NegateVector<T>(T X, T Y, T Z, T W) where T : INumber<T> => (-X, -Y, -Z, -W);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    /// <param name="W"></param>
    /// <param name="V"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) NegateVector<T>(T X, T Y, T Z, T W, T V) where T : INumber<T> => (-X, -Y, -Z, -W, -V);

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <param name="Z"></param>
    /// <param name="W"></param>
    /// <param name="V"></param>
    /// <param name="U"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V, T U) NegateVector<T>(T X, T Y, T Z, T W, T V, T U) where T : INumber<T> => (-X, -Y, -Z, -W, -V, -U);
    #endregion

    #region Decrement
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Decrement<T>(Span<T> value)
        where T : INumber<T>
    {
        var length = value.Length;

        var difference = new T[length];

        for (int i = 0; i < length; i++)
        {
            difference[i] = --value[i];
        }

        return difference;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The subend a.</param>
    /// <param name="Y">The subend b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) DecrementVector<T>(T X, T Y) where T : INumber<T> => (--X, --Y);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The subend a.</param>
    /// <param name="Y">The subend b.</param>
    /// <param name="Z">The subend c.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) DecrementVector<T>(T X, T Y, T Z) where T : INumber<T> => (--X, --Y, --Z);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The subend a.</param>
    /// <param name="Y">The subend b.</param>
    /// <param name="Z">The subend c.</param>
    /// <param name="W">The subend d.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) DecrementVector<T>(T X, T Y, T Z, T W) where T : INumber<T> => (--X, --Y, --Z, --W);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The subend a.</param>
    /// <param name="Y">The subend b.</param>
    /// <param name="Z">The subend c.</param>
    /// <param name="W">The subend d.</param>
    /// <param name="V">The subend e.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) DecrementVector<T>(T X, T Y, T Z, T W, T V) where T : INumber<T> => (--X, --Y, --Z, --W, --V);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="X">The subend a.</param>
    /// <param name="Y">The subend b.</param>
    /// <param name="Z">The subend c.</param>
    /// <param name="W">The subend d.</param>
    /// <param name="V">The subend e.</param>
    /// <param name="U">The subend f.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V, T U) DecrementVector<T>(T X, T Y, T Z, T W, T V, T U) where T : INumber<T> => (--X, --Y, --Z, --W, --V, --U);
    #endregion

    #region Subtract Value From Vector
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="minuend"></param>
    /// <param name="subend"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Subtract<T>(Span<T> minuend, T subend)
        where T : INumber<T>
    {
        var length = minuend.Length;
        var difference = new T[length];

        for (int i = 0; i < length; i++)
        {
            difference[i] = minuend[i] - subend;
        }

        return difference;
    }

    /// <summary>
    /// Subtracts the vector uniformly.
    /// </summary>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="subend">The subend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B) SubtractVectorUniform<T>(T minuendA, T minuendB, T subend) where T : INumber<T> => (minuendA - subend, minuendB - subend);

    /// <summary>
    /// Subtracts the vector uniformly.
    /// </summary>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="minuendC">The minuend c.</param>
    /// <param name="subend">The subend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C) SubtractVectorUniform<T>(T minuendA, T minuendB, T minuendC, T subend) where T : INumber<T> => (minuendA - subend, minuendB - subend, minuendC - subend);

    /// <summary>
    /// Subtracts the vector uniformly.
    /// </summary>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="minuendC">The minuend c.</param>
    /// <param name="minuendD">The minuend d.</param>
    /// <param name="subend">The subend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D) SubtractVectorUniform<T>(T minuendA, T minuendB, T minuendC, T minuendD, T subend) where T : INumber<T> => (minuendA - subend, minuendB - subend, minuendC - subend, minuendD - subend);

    /// <summary>
    /// Subtracts the vector uniformly.
    /// </summary>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="minuendC">The minuend c.</param>
    /// <param name="minuendD">The minuend d.</param>
    /// <param name="minuendE">The minuend e.</param>
    /// <param name="subend">The subend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E) SubtractVectorUniform<T>(T minuendA, T minuendB, T minuendC, T minuendD, T minuendE, T subend) where T : INumber<T> => (minuendA - subend, minuendB - subend, minuendC - subend, minuendD - subend, minuendE - subend);

    /// <summary>
    /// Subtracts the vector uniformly.
    /// </summary>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="minuendC">The minuend c.</param>
    /// <param name="minuendD">The minuend d.</param>
    /// <param name="minuendE">The minuend e.</param>
    /// <param name="minuendF">The minuend f.</param>
    /// <param name="subend">The subend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E, T F) SubtractVectorUniform<T>(T minuendA, T minuendB, T minuendC, T minuendD, T minuendE, T minuendF, T subend) where T : INumber<T> => (minuendA - subend, minuendB - subend, minuendC - subend, minuendD - subend, minuendE - subend, minuendF - subend);
    #endregion Subtract Value From Vector

    #region Subtract Vector From Value
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="minuend"></param>
    /// <param name="subend"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Subtract<T>(T minuend, Span<T> subend)
        where T : INumber<T>
    {
        var length = subend.Length;
        var difference = new T[length];

        for (int i = 0; i < length; i++)
        {
            difference[i] = minuend - subend[i];
        }

        return difference;
    }

    /// <summary>
    /// Subtracts from minuend2 d.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B) SubtractFromMinuend<T>(T minuend, T subendA, T subendB) where T : INumber<T> => (minuend - subendA, minuend - subendB);

    /// <summary>
    /// Subtracts from minuend3 d.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="subendC">The subend c.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C) SubtractFromMinuend<T>(T minuend, T subendA, T subendB, T subendC) where T : INumber<T> => (minuend - subendA, minuend - subendB, minuend - subendC);

    /// <summary>
    /// Subtracts from minuend4 d.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="subendC">The subend c.</param>
    /// <param name="subendD">The subend d.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D) SubtractFromMinuend<T>(T minuend, T subendA, T subendB, T subendC, T subendD) where T : INumber<T> => (minuend - subendA, minuend - subendB, minuend - subendC, minuend - subendD);

    /// <summary>
    /// Subtracts from minuend5 d.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="subendC">The subend c.</param>
    /// <param name="subendD">The subend d.</param>
    /// <param name="subendE">The subend e.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E) SubtractFromMinuend<T>(T minuend, T subendA, T subendB, T subendC, T subendD, T subendE) where T : INumber<T> => (minuend - subendA, minuend - subendB, minuend - subendC, minuend - subendD, minuend - subendE);

    /// <summary>
    /// Subtracts from minuend6 d.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="subendC">The subend c.</param>
    /// <param name="subendD">The subend d.</param>
    /// <param name="subendE">The subend e.</param>
    /// <param name="subendF">The subend f.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E, T F) SubtractFromMinuend<T>(T minuend, T subendA, T subendB, T subendC, T subendD, T subendE, T subendF) where T : INumber<T> => (minuend - subendA, minuend - subendB, minuend - subendC, minuend - subendD, minuend - subendE, minuend - subendF);
    #endregion Subtract Vector From Value

    #region Subtract Two Vectors
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="minuend"></param>
    /// <param name="subend"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Subtract<T>(Span<T> minuend, Span<T> subend)
        where T : INumber<T>
    {
        var length = minuend.Length;
        var difference = new T[length];

        for (int i = 0; i < length; i++)
        {
            difference[i] = minuend[i] - subend[i];
        }

        return difference;
    }

    /// <summary>
    /// Subtracts the vector.
    /// </summary>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B) SubtractVector<T>(T minuendA, T minuendB, T subendA, T subendB) where T : INumber<T> => (minuendA - subendA, minuendB - subendB);

    /// <summary>
    /// Subtracts the vector.
    /// </summary>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="minuendC">The minuend c.</param>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="subendC">The subend c.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C) SubtractVector<T>(T minuendA, T minuendB, T minuendC, T subendA, T subendB, T subendC) where T : INumber<T> => (minuendA - subendA, minuendB - subendB, minuendC - subendC);

    /// <summary>
    /// Subtracts the vector.
    /// </summary>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="minuendC">The minuend c.</param>
    /// <param name="minuendD">The minuend d.</param>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="subendC">The subend c.</param>
    /// <param name="subendD">The subend d.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D) SubtractVector<T>(T minuendA, T minuendB, T minuendC, T minuendD, T subendA, T subendB, T subendC, T subendD) where T : INumber<T> => (minuendA - subendA, minuendB - subendB, minuendC - subendC, minuendD - subendD);

    /// <summary>
    /// Subtracts the vector.
    /// </summary>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="minuendC">The minuend c.</param>
    /// <param name="minuendD">The minuend d.</param>
    /// <param name="minuendE">The minuend e.</param>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="subendC">The subend c.</param>
    /// <param name="subendD">The subend d.</param>
    /// <param name="subendE">The subend e.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E) SubtractVector<T>(T minuendA, T minuendB, T minuendC, T minuendD, T minuendE, T subendA, T subendB, T subendC, T subendD, T subendE) where T : INumber<T> => (minuendA - subendA, minuendB - subendB, minuendC - subendC, minuendD - subendD, minuendE - subendE);

    /// <summary>
    /// Subtracts the vector.
    /// </summary>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="minuendC">The minuend c.</param>
    /// <param name="minuendD">The minuend d.</param>
    /// <param name="minuendE">The minuend e.</param>
    /// <param name="minuendF">The minuend f.</param>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="subendC">The subend c.</param>
    /// <param name="subendD">The subend d.</param>
    /// <param name="subendE">The subend e.</param>
    /// <param name="subendF">The subend f.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E, T F) SubtractVector<T>(T minuendA, T minuendB, T minuendC, T minuendD, T minuendE, T minuendF, T subendA, T subendB, T subendC, T subendD, T subendE, T subendF) where T : INumber<T> => (minuendA - subendA, minuendB - subendB, minuendC - subendC, minuendD - subendD, minuendE - subendE, minuendF - subendF);
    #endregion Subtract Two Vectors

    #region Difference Between Two Vectors
    /// <summary>
    /// Finds the Delta of two 2D Vectors.
    /// </summary>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <returns>
    /// Returns the Difference Between PointA and PointB
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B) DeltaVector<T>(T subendA, T subendB, T minuendA, T minuendB) where T : INumber<T> => SubtractVector(minuendA, minuendB, subendA, subendB);

    /// <summary>
    /// Finds the Delta of two 3D Vectors.
    /// </summary>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="subendC">The subend c.</param>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="minuendC">The minuend c.</param>
    /// <returns>
    /// Returns the Difference Between PointA and PointB
    /// </returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C) DeltaVector<T>(T subendA, T subendB, T subendC, T minuendA, T minuendB, T minuendC) where T : INumber<T> => SubtractVector(minuendA, minuendB, minuendC, subendA, subendB, subendC);

    /// <summary>
    /// Finds the Delta of two 4D Vectors.
    /// </summary>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="subendC">The subend c.</param>
    /// <param name="subendD">The subend d.</param>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="minuendC">The minuend c.</param>
    /// <param name="minuendD">The minuend d.</param>
    /// <returns>
    /// Returns the Difference Between PointA and PointB
    /// </returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D) DeltaVector<T>(T subendA, T subendB, T subendC, T subendD, T minuendA, T minuendB, T minuendC, T minuendD) where T : INumber<T> => SubtractVector(minuendA, minuendB, minuendC, minuendD, subendA, subendB, subendC, subendD);

    /// <summary>
    /// Finds the Delta of two 5D Vectors.
    /// </summary>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="subendC">The subend c.</param>
    /// <param name="subendD">The subend d.</param>
    /// <param name="subendE">The subend e.</param>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="minuendC">The minuend c.</param>
    /// <param name="minuendD">The minuend d.</param>
    /// <param name="minuendE">The minuend e.</param>
    /// <returns>
    /// Returns the Difference Between PointA and PointB
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E) DeltaVector<T>(T subendA, T subendB, T subendC, T subendD, T subendE, T minuendA, T minuendB, T minuendC, T minuendD, T minuendE) where T : INumber<T> => SubtractVector(minuendA, minuendB, minuendC, minuendD, minuendE, subendA, subendB, subendC, subendD, subendE);

    /// <summary>
    /// Finds the Delta of two 6D Vectors.
    /// </summary>
    /// <param name="subendA">The subend a.</param>
    /// <param name="subendB">The subend b.</param>
    /// <param name="subendC">The subend c.</param>
    /// <param name="subendD">The subend d.</param>
    /// <param name="subendE">The subend e.</param>
    /// <param name="subendF">The subend f.</param>
    /// <param name="minuendA">The minuend a.</param>
    /// <param name="minuendB">The minuend b.</param>
    /// <param name="minuendC">The minuend c.</param>
    /// <param name="minuendD">The minuend d.</param>
    /// <param name="minuendE">The minuend e.</param>
    /// <param name="minuendF">The minuend f.</param>
    /// <returns>
    /// Returns the Difference Between PointA and PointB
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E, T F) DeltaVector<T>(T subendA, T subendB, T subendC, T subendD, T subendE, T subendF, T minuendA, T minuendB, T minuendC, T minuendD, T minuendE, T minuendF) where T : INumber<T> => SubtractVector(minuendA, minuendB, minuendC, minuendD, minuendE, minuendF, subendA, subendB, subendC, subendD, subendE, subendF);
    #endregion Difference Between Two Vectors

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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Scale<T>(T multiplicand, Span<T> multiplier)
        where T : INumber<T>
    {
        var result = new T[multiplier.Length];
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Scale<T>(T multiplicand, Span<T> multiplier, int length)
        where T : INumber<T>
    {
        var result = new T[length];
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
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Scale<T>(Span<T> multiplicand, T multiplier)
        where T : INumber<T>
    {
        var result = new T[multiplicand.Length];
        for (var i = 0; i < multiplicand.Length; i++)
        {
            result[i] = multiplicand[i] * multiplier;
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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Scale<T>(Span<T> multiplicand, T multiplier, int length)
        where T : INumber<T>
    {
        var result = new T[length];
        for (var i = 0; i < length; i++)
        {
            result[i] = multiplicand[i] * multiplier;
        }

        return result;
    }

    /// <summary>
    /// Scales the vector.
    /// </summary>
    /// <param name="multiplicandA">The multiplicand a.</param>
    /// <param name="multiplicandB">The multiplicand b.</param>
    /// <param name="scalar">The scalar.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B) ScaleVector<T>(T multiplicandA, T multiplicandB, T scalar) where T : INumber<T> => (multiplicandA * scalar, multiplicandB * scalar);

    /// <summary>
    /// Scales the vector.
    /// </summary>
    /// <param name="multiplicandA">The multiplicand a.</param>
    /// <param name="multiplicandB">The multiplicand b.</param>
    /// <param name="multiplicandC">The multiplicand c.</param>
    /// <param name="scalar">The scalar.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C) ScaleVector<T>(T multiplicandA, T multiplicandB, T multiplicandC, T scalar) where T : INumber<T> => (multiplicandA * scalar, multiplicandB * scalar, multiplicandC * scalar);

    /// <summary>
    /// Scales the vector.
    /// </summary>
    /// <param name="multiplicandA">The multiplicand a.</param>
    /// <param name="multiplicandB">The multiplicand b.</param>
    /// <param name="multiplicandC">The multiplicand c.</param>
    /// <param name="multiplicandD">The multiplicand d.</param>
    /// <param name="scalar">The scalar.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D) ScaleVector<T>(T multiplicandA, T multiplicandB, T multiplicandC, T multiplicandD, T scalar) where T : INumber<T> => (multiplicandA * scalar, multiplicandB * scalar, multiplicandC * scalar, multiplicandD * scalar);

    /// <summary>
    /// Scales the vector.
    /// </summary>
    /// <param name="multiplicandA">The multiplicand a.</param>
    /// <param name="multiplicandB">The multiplicand b.</param>
    /// <param name="multiplicandC">The multiplicand c.</param>
    /// <param name="multiplicandD">The multiplicand d.</param>
    /// <param name="multiplicandE">The multiplicand e.</param>
    /// <param name="scalar">The scalar.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E) ScaleVector<T>(T multiplicandA, T multiplicandB, T multiplicandC, T multiplicandD, T multiplicandE, T scalar) where T : INumber<T> => (multiplicandA * scalar, multiplicandB * scalar, multiplicandC * scalar, multiplicandD * scalar, multiplicandE * scalar);

    /// <summary>
    /// Scales the vector.
    /// </summary>
    /// <param name="multiplicandA">The multiplicand a.</param>
    /// <param name="multiplicandB">The multiplicand b.</param>
    /// <param name="multiplicandC">The multiplicand c.</param>
    /// <param name="multiplicandD">The multiplicand d.</param>
    /// <param name="multiplicandE">The multiplicand e.</param>
    /// <param name="multiplicandF">The multiplicand f.</param>
    /// <param name="scalar">The scalar.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E, T F) ScaleVector<T>(T multiplicandA, T multiplicandB, T multiplicandC, T multiplicandD, T multiplicandE, T multiplicandF, T scalar) where T : INumber<T> => (multiplicandA * scalar, multiplicandB * scalar, multiplicandC * scalar, multiplicandD * scalar, multiplicandE * scalar, multiplicandF * scalar);
    #endregion Multiply A Vector by a Value

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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T RowVectorColumnVectorMatrixMultiplication<T>(Span<T> rowVector, Span<T> columnVector)
        where T : INumber<T>
    {
        T result = T.Zero;

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
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T RowVectorColumnVectorMatrixMultiplication<T>(Span<T> rowVector, Span<T> columnVector, int length)
        where T : INumber<T>
    {
        T result = T.Zero;
        for (var i = 0; i < length; i++)
        {
            result += rowVector[i] * columnVector[i];
        }

        return result;
    }
    #endregion

    #region Multiply Each Vector Component By The One in Another Vector
    /// <summary>
    /// Vector multiplications by parametric scalar.
    /// </summary>
    /// <param name="multiplicand">The scalar.</param>
    /// <param name="multiplier">The vector.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] ScaleParametric<T>(Span<T> multiplicand, Span<T> multiplier)
        where T : INumber<T>
    {
        int length = multiplicand.Length;

        var product = new T[length];

        for (var i = 0; i < length; i++)
        {
            product[i] = multiplicand[i] * multiplier[i];
        }

        return product;
    }

    /// <summary>
    /// Scales the vector parametrically.
    /// </summary>
    /// <param name="multiplicandA">The multiplicand a.</param>
    /// <param name="multiplicandB">The multiplicand b.</param>
    /// <param name="multiplierA">The multiplier a.</param>
    /// <param name="multiplierB">The multiplier b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B) ScaleVectorParametric<T>(T multiplicandA, T multiplicandB, T multiplierA, T multiplierB) where T : INumber<T> => (multiplicandA * multiplierA, multiplicandB * multiplierB);

    /// <summary>
    /// Scales the vector parametrically.
    /// </summary>
    /// <param name="multiplicandA">The multiplicand a.</param>
    /// <param name="multiplicandB">The multiplicand b.</param>
    /// <param name="multiplicandC">The multiplicand c.</param>
    /// <param name="multiplierA">The multiplier a.</param>
    /// <param name="multiplierB">The multiplier b.</param>
    /// <param name="multiplierC">The multiplier c.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C) ScaleVectorParametric<T>(T multiplicandA, T multiplicandB, T multiplicandC, T multiplierA, T multiplierB, T multiplierC) where T : INumber<T> => (multiplicandA * multiplierA, multiplicandB * multiplierB, multiplicandC * multiplierC);

    /// <summary>
    /// Scales the vector parametrically.
    /// </summary>
    /// <param name="multiplicandA">The multiplicand a.</param>
    /// <param name="multiplicandB">The multiplicand b.</param>
    /// <param name="multiplicandC">The multiplicand c.</param>
    /// <param name="multiplicandD">The multiplicand d.</param>
    /// <param name="multiplierA">The multiplier a.</param>
    /// <param name="multiplierB">The multiplier b.</param>
    /// <param name="multiplierC">The multiplier c.</param>
    /// <param name="multiplierD">The multiplier d.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D) ScaleVectorParametric<T>(T multiplicandA, T multiplicandB, T multiplicandC, T multiplicandD, T multiplierA, T multiplierB, T multiplierC, T multiplierD) where T : INumber<T> => (multiplicandA * multiplierA, multiplicandB * multiplierB, multiplicandC * multiplierC, multiplicandD * multiplierD);

    /// <summary>
    /// Scales the vector parametrically.
    /// </summary>
    /// <param name="multiplicandA">The multiplicand a.</param>
    /// <param name="multiplicandB">The multiplicand b.</param>
    /// <param name="multiplicandC">The multiplicand c.</param>
    /// <param name="multiplicandD">The multiplicand d.</param>
    /// <param name="multiplicandE">The multiplicand e.</param>
    /// <param name="multiplierA">The multiplier a.</param>
    /// <param name="multiplierB">The multiplier b.</param>
    /// <param name="multiplierC">The multiplier c.</param>
    /// <param name="multiplierD">The multiplier d.</param>
    /// <param name="multiplierE">The multiplier e.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E) ScaleVectorParametric<T>(T multiplicandA, T multiplicandB, T multiplicandC, T multiplicandD, T multiplicandE, T multiplierA, T multiplierB, T multiplierC, T multiplierD, T multiplierE) where T : INumber<T> => (multiplicandA * multiplierA, multiplicandB * multiplierB, multiplicandC * multiplierC, multiplicandD * multiplierD, multiplicandE * multiplierE);

    /// <summary>
    /// Scales the vector parametrically.
    /// </summary>
    /// <param name="multiplicandA">The multiplicand a.</param>
    /// <param name="multiplicandB">The multiplicand b.</param>
    /// <param name="multiplicandC">The multiplicand c.</param>
    /// <param name="multiplicandD">The multiplicand d.</param>
    /// <param name="multiplicandE">The multiplicand e.</param>
    /// <param name="multiplicandF">The multiplicand f.</param>
    /// <param name="multiplierA">The multiplier a.</param>
    /// <param name="multiplierB">The multiplier b.</param>
    /// <param name="multiplierC">The multiplier c.</param>
    /// <param name="multiplierD">The multiplier d.</param>
    /// <param name="multiplierE">The multiplier e.</param>
    /// <param name="multiplierF">The multiplier f.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E, T F) ScaleVectorParametric<T>(T multiplicandA, T multiplicandB, T multiplicandC, T multiplicandD, T multiplicandE, T multiplicandF, T multiplierA, T multiplierB, T multiplierC, T multiplierD, T multiplierE, T multiplierF) where T : INumber<T> => (multiplicandA * multiplierA, multiplicandB * multiplierB, multiplicandC * multiplierC, multiplicandD * multiplierD, multiplicandE * multiplierE, multiplicandF * multiplierF);
    #endregion Multiply Each Vector Component By The One in Another Vector

    #region Divide Vector By Value
    /// <summary>
    /// Vector division by parametric scalar.
    /// </summary>
    /// <param name="multiplicand">The scalar.</param>
    /// <param name="multiplier">The vector.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] InverseScaleParametric<T>(Span<T> multiplicand, T multiplier)
        where T : INumber<T>
    {
        int length = multiplicand.Length;

        var product = new T[length];

        for (var i = 0; i < length; i++)
        {
            product[i] = multiplicand[i] / multiplier;
        }

        return product;
    }

    /// <summary>
    /// Divides the vector uniform.
    /// </summary>
    /// <param name="divisorA">The divisor a.</param>
    /// <param name="divisorB">The divisor b.</param>
    /// <param name="dividend">The dividend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B) DivideVectorUniform<T>(T divisorA, T divisorB, T dividend) where T : INumber<T> => (divisorA / dividend, divisorB / dividend);

    /// <summary>
    /// Divides the vector uniform.
    /// </summary>
    /// <param name="divisorA">The divisor a.</param>
    /// <param name="divisorB">The divisor b.</param>
    /// <param name="divisorC">The divisor c.</param>
    /// <param name="dividend">The dividend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C) DivideVectorUniform<T>(T divisorA, T divisorB, T divisorC, T dividend) where T : INumber<T> => (divisorA / dividend, divisorB / dividend, divisorC / dividend);

    /// <summary>
    /// Divides the vector uniform.
    /// </summary>
    /// <param name="divisorA">The divisor a.</param>
    /// <param name="divisorB">The divisor b.</param>
    /// <param name="divisorC">The divisor c.</param>
    /// <param name="divisorD">The divisor d.</param>
    /// <param name="dividend">The dividend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D) DivideVectorUniform<T>(T divisorA, T divisorB, T divisorC, T divisorD, T dividend) where T : INumber<T> => (divisorA / dividend, divisorB / dividend, divisorC / dividend, divisorD / dividend);

    /// <summary>
    /// Divides the vector uniform.
    /// </summary>
    /// <param name="divisorA">The divisor a.</param>
    /// <param name="divisorB">The divisor b.</param>
    /// <param name="divisorC">The divisor c.</param>
    /// <param name="divisorD">The divisor d.</param>
    /// <param name="divisorE">The divisor e.</param>
    /// <param name="dividend">The dividend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E) DivideVectorUniform<T>(T divisorA, T divisorB, T divisorC, T divisorD, T divisorE, T dividend) where T : INumber<T> => (divisorA / dividend, divisorB / dividend, divisorC / dividend, divisorD / dividend, divisorE / dividend);

    /// <summary>
    /// Divides the vector uniform.
    /// </summary>
    /// <param name="divisorA">The divisor a.</param>
    /// <param name="divisorB">The divisor b.</param>
    /// <param name="divisorC">The divisor c.</param>
    /// <param name="divisorD">The divisor d.</param>
    /// <param name="divisorE">The divisor e.</param>
    /// <param name="divisorF">The divisor f.</param>
    /// <param name="dividend">The dividend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E, T F) DivideVectorUniform<T>(T divisorA, T divisorB, T divisorC, T divisorD, T divisorE, T divisorF, T dividend) where T : INumber<T> => (divisorA / dividend, divisorB / dividend, divisorC / dividend, divisorD / dividend, divisorE / dividend, divisorF / dividend);
    #endregion Divide Vector By Value

    #region Divide Value into Vector Components
    /// <summary>
    /// Vector division by parametric scalar.
    /// </summary>
    /// <param name="multiplicand">The scalar.</param>
    /// <param name="multiplier">The vector.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] InverseScaleParametric<T>(T multiplicand, Span<T> multiplier)
        where T : INumber<T>
    {
        int length = multiplier.Length;

        var product = new T[length];

        for (var i = 0; i < length; i++)
        {
            product[i] = multiplicand / multiplier[i];
        }

        return product;
    }

    /// <summary>
    /// Divides the by vector uniformly.
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <param name="dividendA">The dividend a.</param>
    /// <param name="dividendB">The dividend b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B) DivideByVectorUniform<T>(T divisor, T dividendA, T dividendB) where T : INumber<T> => (divisor / dividendA, divisor / dividendB);

    /// <summary>
    /// Divides the by vector uniformly.
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <param name="dividendA">The dividend a.</param>
    /// <param name="dividendB">The dividend b.</param>
    /// <param name="dividendC">The dividend c.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C) DivideByVectorUniform<T>(T divisor, T dividendA, T dividendB, T dividendC) where T : INumber<T> => (divisor / dividendA, divisor / dividendB, divisor / dividendC);

    /// <summary>
    /// Divides the by vector uniformly.
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <param name="dividendA">The dividend a.</param>
    /// <param name="dividendB">The dividend b.</param>
    /// <param name="dividendC">The dividend c.</param>
    /// <param name="dividendD">The dividend d.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D) DivideByVectorUniform<T>(T divisor, T dividendA, T dividendB, T dividendC, T dividendD) where T : INumber<T> => (divisor / dividendA, divisor / dividendB, divisor / dividendC, divisor / dividendD);

    /// <summary>
    /// Divides the by vector uniformly.
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <param name="dividendA">The dividend a.</param>
    /// <param name="dividendB">The dividend b.</param>
    /// <param name="dividendC">The dividend c.</param>
    /// <param name="dividendD">The dividend d.</param>
    /// <param name="dividendE">The dividend e.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E) DivideByVectorUniform<T>(T divisor, T dividendA, T dividendB, T dividendC, T dividendD, T dividendE) where T : INumber<T> => (divisor / dividendA, divisor / dividendB, divisor / dividendC, divisor / dividendD, divisor / dividendE);

    /// <summary>
    /// Divides the by vector uniformly.
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <param name="dividendA">The dividend a.</param>
    /// <param name="dividendB">The dividend b.</param>
    /// <param name="dividendC">The dividend c.</param>
    /// <param name="dividendD">The dividend d.</param>
    /// <param name="dividendE">The dividend e.</param>
    /// <param name="dividendF">The dividend f.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E, T F) DivideByVectorUniform<T>(T divisor, T dividendA, T dividendB, T dividendC, T dividendD, T dividendE, T dividendF) where T : INumber<T> => (divisor / dividendA, divisor / dividendB, divisor / dividendC, divisor / dividendD, divisor / dividendE, divisor / dividendF);
    #endregion Divide Value into Vector Components

    #region Divide Each Of The Components Of A Vector By The Same Components Of Another Vector
    /// <summary>
    /// Vector division by parametric scalar.
    /// </summary>
    /// <param name="multiplicand">The scalar.</param>
    /// <param name="multiplier">The vector.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] InverseScaleParametric<T>(Span<T> multiplicand, Span<T> multiplier)
        where T : INumber<T>
    {
        int length = multiplicand.Length;

        var product = new T[length];

        for (var i = 0; i < length; i++)
        {
            product[i] = multiplicand[i] / multiplier[i];
        }

        return product;
    }

    /// <summary>
    /// Divides the vector parametrically.
    /// </summary>
    /// <param name="divisorA">The divisor a.</param>
    /// <param name="divisorB">The divisor b.</param>
    /// <param name="dividendA">The dividend a.</param>
    /// <param name="dividendB">The dividend b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B) DivideVectorParametric<T>(T divisorA, T divisorB, T dividendA, T dividendB) where T : INumber<T> => (divisorA / dividendA, divisorB / dividendB);

    /// <summary>
    /// Divides the vector parametrically.
    /// </summary>
    /// <param name="divisorA">The divisor a.</param>
    /// <param name="divisorB">The divisor b.</param>
    /// <param name="divisorC">The divisor c.</param>
    /// <param name="dividendA">The dividend a.</param>
    /// <param name="dividendB">The dividend b.</param>
    /// <param name="dividendC">The dividend c.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C) DivideVectorParametric<T>(T divisorA, T divisorB, T divisorC, T dividendA, T dividendB, T dividendC) where T : INumber<T> => (divisorA / dividendA, divisorB / dividendB, divisorC / dividendC);

    /// <summary>
    /// Divides the vector parametrically.
    /// </summary>
    /// <param name="divisorA">The divisor a.</param>
    /// <param name="divisorB">The divisor b.</param>
    /// <param name="divisorC">The divisor c.</param>
    /// <param name="divisorD">The divisor d.</param>
    /// <param name="dividendA">The dividend a.</param>
    /// <param name="dividendB">The dividend b.</param>
    /// <param name="dividendC">The dividend c.</param>
    /// <param name="dividendD">The dividend d.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D) DivideVectorParametric<T>(T divisorA, T divisorB, T divisorC, T divisorD, T dividendA, T dividendB, T dividendC, T dividendD) where T : INumber<T> => (divisorA / dividendA, divisorB / dividendB, divisorC / dividendC, divisorD / dividendD);

    /// <summary>
    /// Divides the vector parametrically.
    /// </summary>
    /// <param name="divisorA">The divisor a.</param>
    /// <param name="divisorB">The divisor b.</param>
    /// <param name="divisorC">The divisor c.</param>
    /// <param name="divisorD">The divisor d.</param>
    /// <param name="divisorE">The divisor e.</param>
    /// <param name="dividendA">The dividend a.</param>
    /// <param name="dividendB">The dividend b.</param>
    /// <param name="dividendC">The dividend c.</param>
    /// <param name="dividendD">The dividend d.</param>
    /// <param name="dividendE">The dividend e.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E) DivideVectorParametric<T>(T divisorA, T divisorB, T divisorC, T divisorD, T divisorE, T dividendA, T dividendB, T dividendC, T dividendD, T dividendE) where T : INumber<T> => (divisorA / dividendA, divisorB / dividendB, divisorC / dividendC, divisorD / dividendD, divisorE / dividendE);

    /// <summary>
    /// Divides the vector parametrically.
    /// </summary>
    /// <param name="divisorA">The divisor a.</param>
    /// <param name="divisorB">The divisor b.</param>
    /// <param name="divisorC">The divisor c.</param>
    /// <param name="divisorD">The divisor d.</param>
    /// <param name="divisorE">The divisor e.</param>
    /// <param name="divisorF">The divisor f.</param>
    /// <param name="dividendA">The dividend a.</param>
    /// <param name="dividendB">The dividend b.</param>
    /// <param name="dividendC">The dividend c.</param>
    /// <param name="dividendD">The dividend d.</param>
    /// <param name="dividendE">The dividend e.</param>
    /// <param name="dividendF">The dividend f.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T A, T B, T C, T D, T E, T F) DivideVectorParametric<T>(T divisorA, T divisorB, T divisorC, T divisorD, T divisorE, T divisorF, T dividendA, T dividendB, T dividendC, T dividendD, T dividendE, T dividendF) where T : INumber<T> => (divisorA / dividendA, divisorB / dividendB, divisorC / dividendC, divisorD / dividendD, divisorE / dividendE, divisorF / dividendF);
    #endregion Divide Each Of The Components Of A Vector By The Same Components Of Another Vector

    #region Mod Vector By Value
    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisor"></param>
    /// <param name="dividend"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] ModulusParametric<T>(Span<T> divisor, T dividend)
        where T : INumber<T>
    {
        int length = divisor.Length;

        var product = new T[length];

        for (var i = 0; i < length; i++)
        {
            product[i] = divisor[i] % dividend;
        }

        return product;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisorX">The divisor a.</param>
    /// <param name="divisorY">The divisor b.</param>
    /// <param name="dividend">The dividend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) ModulusVectorRight<T>(T divisorX, T divisorY, T dividend) where T : INumber<T> => (divisorX % dividend, divisorY % dividend);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisorX">The divisor a.</param>
    /// <param name="divisorY">The divisor b.</param>
    /// <param name="divisorZ">The divisor c.</param>
    /// <param name="dividend">The dividend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) ModulusVectorRight<T>(T divisorX, T divisorY, T divisorZ, T dividend) where T : INumber<T> => (divisorX % dividend, divisorY % dividend, divisorZ % dividend);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisorX">The divisor a.</param>
    /// <param name="divisorY">The divisor b.</param>
    /// <param name="divisorZ">The divisor c.</param>
    /// <param name="divisorW">The divisor d.</param>
    /// <param name="dividend">The dividend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) ModulusVectorRight<T>(T divisorX, T divisorY, T divisorZ, T divisorW, T dividend) where T : INumber<T> => (divisorX % dividend, divisorY % dividend, divisorZ % dividend, divisorW % dividend);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisorX">The divisor a.</param>
    /// <param name="divisorY">The divisor b.</param>
    /// <param name="divisorZ">The divisor c.</param>
    /// <param name="divisorW">The divisor d.</param>
    /// <param name="divisorV">The divisor e.</param>
    /// <param name="dividend">The dividend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) ModulusVectorRight<T>(T divisorX, T divisorY, T divisorZ, T divisorW, T divisorV, T dividend) where T : INumber<T> => (divisorX % dividend, divisorY % dividend, divisorZ % dividend, divisorW % dividend, divisorV % dividend);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisorX">The divisor a.</param>
    /// <param name="divisorY">The divisor b.</param>
    /// <param name="divisorZ">The divisor c.</param>
    /// <param name="divisorW">The divisor d.</param>
    /// <param name="divisorV">The divisor e.</param>
    /// <param name="divisorU">The divisor f.</param>
    /// <param name="dividend">The dividend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V, T U) ModulusVectorRight<T>(T divisorX, T divisorY, T divisorZ, T divisorW, T divisorV, T divisorU, T dividend) where T : INumber<T> => (divisorX % dividend, divisorY % dividend, divisorZ % dividend, divisorW % dividend, divisorV % dividend, divisorU % dividend);
    #endregion Divide Vector By Value

    #region Mod Value into Vector Components
    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiplicand">The scalar.</param>
    /// <param name="multiplier">The vector.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] ModulusParametric<T>(T multiplicand, Span<T> multiplier)
        where T : INumber<T>
    {
        int length = multiplier.Length;

        var product = new T[length];

        for (var i = 0; i < length; i++)
        {
            product[i] = multiplicand % multiplier[i];
        }

        return product;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <param name="dividendX">The dividend a.</param>
    /// <param name="dividendY">The dividend b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) ModulusVectorLeft<T>(T divisor, T dividendX, T dividendY) where T : INumber<T> => (divisor % dividendX, divisor % dividendY);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <param name="dividendX">The dividend a.</param>
    /// <param name="dividendY">The dividend b.</param>
    /// <param name="dividendZ">The dividend c.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) ModulusVectorLeft<T>(T divisor, T dividendX, T dividendY, T dividendZ) where T : INumber<T> => (divisor % dividendX, divisor % dividendY, divisor % dividendZ);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <param name="dividendX">The dividend a.</param>
    /// <param name="dividendY">The dividend b.</param>
    /// <param name="dividendZ">The dividend c.</param>
    /// <param name="dividendW">The dividend d.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) ModulusVectorLeft<T>(T divisor, T dividendX, T dividendY, T dividendZ, T dividendW) where T : INumber<T> => (divisor % dividendX, divisor % dividendY, divisor % dividendZ, divisor % dividendW);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <param name="dividendX">The dividend a.</param>
    /// <param name="dividendY">The dividend b.</param>
    /// <param name="dividendZ">The dividend c.</param>
    /// <param name="dividendW">The dividend d.</param>
    /// <param name="dividendV">The dividend e.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) ModulusVectorLeft<T>(T divisor, T dividendX, T dividendY, T dividendZ, T dividendW, T dividendV) where T : INumber<T> => (divisor % dividendX, divisor % dividendY, divisor % dividendZ, divisor % dividendW, divisor % dividendV);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisor">The divisor.</param>
    /// <param name="dividendX">The dividend a.</param>
    /// <param name="dividendY">The dividend b.</param>
    /// <param name="dividendZ">The dividend c.</param>
    /// <param name="dividendW">The dividend d.</param>
    /// <param name="dividendV">The dividend e.</param>
    /// <param name="dividendU">The dividend f.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V, T U) ModulusVectorLeft<T>(T divisor, T dividendX, T dividendY, T dividendZ, T dividendW, T dividendV, T dividendU) where T : INumber<T> => (divisor % dividendX, divisor % dividendY, divisor % dividendZ, divisor % dividendW, divisor % dividendV, divisor % dividendU);
    #endregion Divide Value into Vector Components

    #region Mod Each Of The Components Of A Vector By The Same Components Of Another Vector
    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisor">The scalar.</param>
    /// <param name="dividend">The vector.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] ModulusParametric<T>(Span<T> divisor, Span<T> dividend)
        where T : INumber<T>
    {
        int length = divisor.Length;

        var product = new T[length];

        for (var i = 0; i < length; i++)
        {
            product[i] = divisor[i] % dividend[i];
        }

        return product;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisorX">The divisor a.</param>
    /// <param name="divisorY">The divisor b.</param>
    /// <param name="dividendX">The dividend a.</param>
    /// <param name="dividendY">The dividend b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) ModulusVectorParametric<T>(T divisorX, T divisorY, T dividendX, T dividendY) where T : INumber<T> => (divisorX / dividendX, divisorY / dividendY);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisorX">The divisor a.</param>
    /// <param name="divisorY">The divisor b.</param>
    /// <param name="divisorZ">The divisor c.</param>
    /// <param name="dividendX">The dividend a.</param>
    /// <param name="dividendY">The dividend b.</param>
    /// <param name="dividendZ">The dividend c.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) ModulusVectorParametric<T>(T divisorX, T divisorY, T divisorZ, T dividendX, T dividendY, T dividendZ) where T : INumber<T> => (divisorX / dividendX, divisorY / dividendY, divisorZ / dividendZ);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisorX">The divisor a.</param>
    /// <param name="divisorY">The divisor b.</param>
    /// <param name="divisorZ">The divisor c.</param>
    /// <param name="divisorW">The divisor d.</param>
    /// <param name="dividendX">The dividend a.</param>
    /// <param name="dividendY">The dividend b.</param>
    /// <param name="dividendZ">The dividend c.</param>
    /// <param name="dividendW">The dividend d.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) ModulusVectorParametric<T>(T divisorX, T divisorY, T divisorZ, T divisorW, T dividendX, T dividendY, T dividendZ, T dividendW) where T : INumber<T> => (divisorX / dividendX, divisorY / dividendY, divisorZ / dividendZ, divisorW / dividendW);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisorX">The divisor a.</param>
    /// <param name="divisorY">The divisor b.</param>
    /// <param name="divisorZ">The divisor c.</param>
    /// <param name="divisorW">The divisor d.</param>
    /// <param name="divisorV">The divisor e.</param>
    /// <param name="dividendX">The dividend a.</param>
    /// <param name="dividendY">The dividend b.</param>
    /// <param name="dividendZ">The dividend c.</param>
    /// <param name="dividendW">The dividend d.</param>
    /// <param name="dividendV">The dividend e.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) ModulusVectorParametric<T>(T divisorX, T divisorY, T divisorZ, T divisorW, T divisorV, T dividendX, T dividendY, T dividendZ, T dividendW, T dividendV) where T : INumber<T> => (divisorX / dividendX, divisorY / dividendY, divisorZ / dividendZ, divisorW / dividendW, divisorV / dividendV);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="divisorX">The divisor a.</param>
    /// <param name="divisorY">The divisor b.</param>
    /// <param name="divisorZ">The divisor c.</param>
    /// <param name="divisorW">The divisor d.</param>
    /// <param name="divisorV">The divisor e.</param>
    /// <param name="divisorU">The divisor f.</param>
    /// <param name="dividendX">The dividend a.</param>
    /// <param name="dividendY">The dividend b.</param>
    /// <param name="dividendZ">The dividend c.</param>
    /// <param name="dividendW">The dividend d.</param>
    /// <param name="dividendV">The dividend e.</param>
    /// <param name="dividendU">The dividend f.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V, T U) ModulusVectorParametric<T>(T divisorX, T divisorY, T divisorZ, T divisorW, T divisorV, T divisorU, T dividendX, T dividendY, T dividendZ, T dividendW, T dividendV, T dividendU) where T : INumber<T> => (divisorX / dividendX, divisorY / dividendY, divisorZ / dividendZ, divisorW / dividendW, divisorV / dividendV, divisorU / dividendU);
    #endregion Divide Each Of The Components Of A Vector By The Same Components Of Another Vector
}
