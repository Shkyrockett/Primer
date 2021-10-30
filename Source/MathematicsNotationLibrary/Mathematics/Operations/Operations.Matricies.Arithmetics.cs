// <copyright file="Operations.Matricies.Arithmetics.cs" company="Shkyrockett" >
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
/// The Operations class.
/// </summary>
public static partial class Operations
{
    #region Matrix Positive
    /// <summary>
    /// Applies the plus operator to the specified augend.
    /// </summary>
    /// <param name="augend">The augend.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Plus<T>(Span2D<T> augend)
        where T : INumber<T>
    {
        if (augend == null)
        {
            return new T[0, 0];
        }

        var rows = augend.Height;
        var cols = augend.Width;

        var sum = new T[rows, cols];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                sum[i, j] = +augend[i, j];
            }
        }

        return sum;
    }

    /// <summary>
    /// Used to add two matrices together.
    /// </summary>
    /// <param name="addendM1x1">The addend M1X1.</param>
    /// <param name="addendM1x2">The addend M1X2.</param>
    /// <param name="addendM2x1">The addend M2X1.</param>
    /// <param name="addendM2x2">The addend M2X2.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2
        ) PlusMatrix<T>(
        T addendM1x1, T addendM1x2,
        T addendM2x1, T addendM2x2)
        where T : INumber<T>
        => (+addendM1x1, +addendM1x2,
            +addendM2x1, +addendM2x2);

    /// <summary>
    /// Used to add two matrices together.
    /// </summary>
    /// <param name="addendM1x1">The addend M1X1.</param>
    /// <param name="addendM1x2">The addend M1X2.</param>
    /// <param name="addendM1x3"></param>
    /// <param name="addendM2x1">The addend M2X1.</param>
    /// <param name="addendM2x2">The addend M2X2.</param>
    /// <param name="addendM2x3"></param>
    /// <param name="addendM3x1"></param>
    /// <param name="addendM3x2"></param>
    /// <param name="addendM3x3"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3
        ) PlusMatrix<T>(
        T addendM1x1, T addendM1x2, T addendM1x3,
        T addendM2x1, T addendM2x2, T addendM2x3,
        T addendM3x1, T addendM3x2, T addendM3x3)
        where T : INumber<T>
        => (
        +addendM1x1, +addendM1x2, +addendM1x3,
        +addendM2x1, +addendM2x2, +addendM2x3,
        +addendM3x1, +addendM3x2, +addendM3x3
        );

    /// <summary>
    /// Used to add two matrices together.
    /// </summary>
    /// <param name="addendM1x1">The addend M1X1.</param>
    /// <param name="addendM1x2">The addend M1X2.</param>
    /// <param name="addendM1x3"></param>
    /// <param name="addendM1x4"></param>
    /// <param name="addendM2x1">The addend M2X1.</param>
    /// <param name="addendM2x2">The addend M2X2.</param>
    /// <param name="addendM2x3"></param>
    /// <param name="addendM2x4"></param>
    /// <param name="addendM3x1"></param>
    /// <param name="addendM3x2"></param>
    /// <param name="addendM3x3"></param>
    /// <param name="addendM3x4"></param>
    /// <param name="addendM4x1"></param>
    /// <param name="addendM4x2"></param>
    /// <param name="addendM4x3"></param>
    /// <param name="addendM4x4"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4
        ) PlusMatrix<T>(
        T addendM1x1, T addendM1x2, T addendM1x3, T addendM1x4,
        T addendM2x1, T addendM2x2, T addendM2x3, T addendM2x4,
        T addendM3x1, T addendM3x2, T addendM3x3, T addendM3x4,
        T addendM4x1, T addendM4x2, T addendM4x3, T addendM4x4)
        where T : INumber<T>
        => (
        +addendM1x1, +addendM1x2, +addendM1x3, +addendM1x4,
        +addendM2x1, +addendM2x2, +addendM2x3, +addendM2x4,
        +addendM3x1, +addendM3x2, +addendM3x3, +addendM3x4,
        +addendM4x1, +addendM4x2, +addendM4x3, +addendM4x4
        );

    /// <summary>
    /// Used to add two matrices together.
    /// </summary>
    /// <param name="addendM1x1">The addend M1X1.</param>
    /// <param name="addendM1x2">The addend M1X2.</param>
    /// <param name="addendM1x3"></param>
    /// <param name="addendM1x4"></param>
    /// <param name="addendM1x5"></param>
    /// <param name="addendM2x1">The addend M2X1.</param>
    /// <param name="addendM2x2">The addend M2X2.</param>
    /// <param name="addendM2x3"></param>
    /// <param name="addendM2x4"></param>
    /// <param name="addendM2x5"></param>
    /// <param name="addendM3x1"></param>
    /// <param name="addendM3x2"></param>
    /// <param name="addendM3x3"></param>
    /// <param name="addendM3x4"></param>
    /// <param name="addendM3x5"></param>
    /// <param name="addendM4x1"></param>
    /// <param name="addendM4x2"></param>
    /// <param name="addendM4x3"></param>
    /// <param name="addendM4x4"></param>
    /// <param name="addendM4x5"></param>
    /// <param name="addendM5x1"></param>
    /// <param name="addendM5x2"></param>
    /// <param name="addendM5x3"></param>
    /// <param name="addendM5x4"></param>
    /// <param name="addendM5x5"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5
        ) PlusMatrix<T>(
        T addendM1x1, T addendM1x2, T addendM1x3, T addendM1x4, T addendM1x5,
        T addendM2x1, T addendM2x2, T addendM2x3, T addendM2x4, T addendM2x5,
        T addendM3x1, T addendM3x2, T addendM3x3, T addendM3x4, T addendM3x5,
        T addendM4x1, T addendM4x2, T addendM4x3, T addendM4x4, T addendM4x5,
        T addendM5x1, T addendM5x2, T addendM5x3, T addendM5x4, T addendM5x5)
        where T : INumber<T>
        => (
        +addendM1x1, +addendM1x2, +addendM1x3, +addendM1x4, +addendM1x5,
        +addendM2x1, +addendM2x2, +addendM2x3, +addendM2x4, +addendM2x5,
        +addendM3x1, +addendM3x2, +addendM3x3, +addendM3x4, +addendM3x5,
        +addendM4x1, +addendM4x2, +addendM4x3, +addendM4x4, +addendM4x5,
        +addendM5x1, +addendM5x2, +addendM5x3, +addendM5x4, +addendM5x5
        );
    #endregion

    #region Matrix Addition
    /// <summary>
    /// Adds the specified augend.
    /// </summary>
    /// <param name="augend">The augend.</param>
    /// <param name="addend">The addend.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Add<T>(Span2D<T> augend, Span2D<T> addend)
        where T : INumber<T>
    {
        if (augend == null)
        {
            return addend.ToArray();
        }

        if (addend == null)
        {
            return augend.ToArray();
        }

        var rowsAugend = augend.Height;
        var columnsAugend = augend.Width;
        var rowsAddend = addend.Height;
        var columnsAddend = addend.Width;

        if (rowsAugend != rowsAddend || columnsAugend != columnsAddend)
        {
            throw new ArgumentException($"The {nameof(augend)} Matrix must be the same size as the {nameof(addend)} Matrix.");
        }

        var sum = new T[rowsAugend, columnsAugend];

        for (var i = 0; i < rowsAugend; i++)
        {
            for (var j = 0; j < columnsAugend; j++)
            {
                sum[i, j] = augend[i, j] + addend[i, j];
            }
        }

        return sum;
    }

    /// <summary>
    /// Adds the specified augend.
    /// </summary>
    /// <param name="augend">The augend.</param>
    /// <param name="addend">The addend.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] Add<T, TResult>(Span2D<T> augend, Span2D<T> addend)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        if (augend == null)
        {
            return addend.Cast<T, TResult>();
        }

        if (addend == null)
        {
            return augend.Cast<T, TResult>();
        }

        var rowsAugend = augend.Height;
        var columnsAugend = augend.Width;
        var rowsAddend = addend.Height;
        var columnsAddend = addend.Width;

        if (rowsAugend != rowsAddend || columnsAugend != columnsAddend)
        {
            throw new ArgumentException($"The {nameof(augend)} Matrix must be the same size as the {nameof(addend)} Matrix.");
        }

        var sum = new TResult[rowsAugend, columnsAugend];

        for (var i = 0; i < rowsAugend; i++)
        {
            for (var j = 0; j < columnsAugend; j++)
            {
                sum[i, j] = TResult.Create(augend[i, j] + addend[i, j]);
            }
        }

        return sum;
    }

    /// <summary>
    /// Adds the two matrices.
    /// </summary>
    /// <param name="augend">The matrix1.</param>
    /// <param name="addend">The matrix2.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] Add<T, TResult>(Span2D<T> augend, Span2D<T> addend, int accuracy)
        where T : INumber<T>
        where TResult : struct, IFloatingPoint<TResult>
    {
        if (augend == null)
        {
            return addend.Cast<T, TResult>();
        }

        if (addend == null)
        {
            return augend.Cast<T, TResult>();
        }

        var rowsAugend = augend.Height;
        var columnsAugend = augend.Width;
        var rowsAddend = addend.Height;
        var columnsAddend = addend.Width;

        if (rowsAugend != rowsAddend || columnsAugend != columnsAddend)
        {
            throw new ArgumentException($"The {nameof(augend)} Matrix must be the same size as the {nameof(addend)} Matrix.");
        }

        var sum = new TResult[rowsAugend, columnsAugend];

        for (var i = 0; i < rowsAugend; i++)
        {
            for (var j = 0; j < columnsAugend; j++)
            {
                sum[i, j] = TResult.Create(augend[i, j] + addend[i, j]);
            }
        }

        return Round<TResult, TResult>(sum, rowsAugend, columnsAugend, accuracy);
    }

    /// <summary>
    /// Adds the two matrices.
    /// </summary>
    /// <param name="augend">The matrix1.</param>
    /// <param name="addend">The matrix2.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Add<T>(Span2D<T> augend, Span2D<T> addend, int rows, int columns)
        where T : INumber<T>
    {
        if (augend == null)
        {
            return addend.ToArray();
        }

        if (addend == null)
        {
            return augend.ToArray();
        }

        var rowsAugend = augend.Height;
        var columnsAugend = augend.Width;
        var rowsAddend = addend.Height;
        var columnsAddend = addend.Width;

        if (rows > rowsAugend || columns > columnsAugend || rows > rowsAddend || columns > columnsAddend)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(augend)} and {nameof(addend)}");
        }

        var sum = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                sum[i, j] = augend[i, j] + addend[i, j];
            }
        }

        return sum;
    }

    /// <summary>
    /// Adds the two matrices.
    /// </summary>
    /// <param name="augend">The matrix1.</param>
    /// <param name="addend">The matrix2.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Add<T>(Span2D<T> augend, Span2D<T> addend, int rows, int columns, int accuracy)
        where T : IFloatingPoint<T>
    {
        if (augend == null)
        {
            return addend.ToArray();
        }

        if (addend == null)
        {
            return augend.ToArray();
        }

        var rowsAugend = augend.Height;
        var columnsAugend = augend.Width;
        var rowsAddend = addend.Height;
        var columnsAddend = addend.Width;

        if (rows > rowsAugend || columns > columnsAugend || rows > rowsAddend || columns > columnsAddend)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(augend)} and {nameof(addend)}");
        }

        var sum = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                sum[i, j] = augend[i, j] + addend[i, j];
            }
        }

        return Round<T, T>(sum, rows, columns, accuracy);
    }

    /// <summary>
    /// Sums the two matrices eigen vectors edition.
    /// </summary>
    /// <param name="augend">The matrix1.</param>
    /// <param name="addend">The matrix2.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] AddEigenVectorMatrices<T>(Span2D<T> augend, Span2D<T> addend, int rows, int columns)
        where T : INumber<T>
    {
        if (augend == null)
        {
            return addend.ToArray();
        }

        if (addend == null)
        {
            return augend.ToArray();
        }

        var rowsAugend = augend.Height;
        var columnsAugend = augend.Width;
        var rowsAddend = addend.Height;
        var columnsAddend = addend.Width;

        if (rows > rowsAugend || columns > columnsAugend || rows > rowsAddend || columns > columnsAddend)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(augend)} and {nameof(addend)}");
        }

        var sum = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns - 1; j++) // The only difference is this does not touch the last column.
            {
                sum[i, j] = augend[i, j] + addend[i, j];
            }
        }

        return sum;
    }

    /// <summary>
    /// Used to add two matrices together.
    /// </summary>
    /// <param name="augendM1x1">The augend M1X1.</param>
    /// <param name="augendM1x2">The augend M1X2.</param>
    /// <param name="augendM2x1">The augend M2X1.</param>
    /// <param name="augendM2x2">The augend M2X2.</param>
    /// <param name="addendM1x1">The addend M1X1.</param>
    /// <param name="addendM1x2">The addend M1X2.</param>
    /// <param name="addendM2x1">The addend M2X1.</param>
    /// <param name="addendM2x2">The addend M2X2.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2
        ) AddMatrix<T>(
        T augendM1x1, T augendM1x2,
        T augendM2x1, T augendM2x2,
        T addendM1x1, T addendM1x2,
        T addendM2x1, T addendM2x2)
        where T : INumber<T>
        => (augendM1x1 + addendM1x1, augendM1x2 + addendM1x2,
            augendM2x1 + addendM2x1, augendM2x2 + addendM2x2);

    /// <summary>
    /// Used to add two matrices together.
    /// </summary>
    /// <param name="augendM1x1">The augend M1X1.</param>
    /// <param name="augendM1x2">The augend M1X2.</param>
    /// <param name="augendM2x1">The augend M2X1.</param>
    /// <param name="augendM2x2">The augend M2X2.</param>
    /// <param name="augendM3x1"></param>
    /// <param name="augendM3x2"></param>
    /// <param name="addendM1x1">The addend M1X1.</param>
    /// <param name="addendM1x2">The addend M1X2.</param>
    /// <param name="addendM2x1">The addend M2X1.</param>
    /// <param name="addendM2x2">The addend M2X2.</param>
    /// <param name="addendM3x1"></param>
    /// <param name="addendM3x2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2,
        T m3x1, T m3x2
        ) AddMatrix<T>(
        T augendM1x1, T augendM1x2,
        T augendM2x1, T augendM2x2,
        T augendM3x1, T augendM3x2,
        T addendM1x1, T addendM1x2,
        T addendM2x1, T addendM2x2,
        T addendM3x1, T addendM3x2)
        where T : INumber<T>
        => (
        augendM1x1 + addendM1x1, augendM1x2 + addendM1x2,
        augendM2x1 + addendM2x1, augendM2x2 + addendM2x2,
        augendM3x1 + addendM3x1, augendM3x2 + addendM3x2
        );

    /// <summary>
    /// Used to add two matrices together.
    /// </summary>
    /// <param name="augendM1x1">The augend M1X1.</param>
    /// <param name="augendM1x2">The augend M1X2.</param>
    /// <param name="augendM1x3"></param>
    /// <param name="augendM2x1">The augend M2X1.</param>
    /// <param name="augendM2x2">The augend M2X2.</param>
    /// <param name="augendM2x3"></param>
    /// <param name="augendM3x1"></param>
    /// <param name="augendM3x2"></param>
    /// <param name="augendM3x3"></param>
    /// <param name="addendM1x1">The addend M1X1.</param>
    /// <param name="addendM1x2">The addend M1X2.</param>
    /// <param name="addendM1x3"></param>
    /// <param name="addendM2x1">The addend M2X1.</param>
    /// <param name="addendM2x2">The addend M2X2.</param>
    /// <param name="addendM2x3"></param>
    /// <param name="addendM3x1"></param>
    /// <param name="addendM3x2"></param>
    /// <param name="addendM3x3"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3
        ) AddMatrix<T>(
        T augendM1x1, T augendM1x2, T augendM1x3,
        T augendM2x1, T augendM2x2, T augendM2x3,
        T augendM3x1, T augendM3x2, T augendM3x3,
        T addendM1x1, T addendM1x2, T addendM1x3,
        T addendM2x1, T addendM2x2, T addendM2x3,
        T addendM3x1, T addendM3x2, T addendM3x3)
        where T : INumber<T>
        => (
        augendM1x1 + addendM1x1, augendM1x2 + addendM1x2, augendM1x3 + addendM1x3,
        augendM2x1 + addendM2x1, augendM2x2 + addendM2x2, augendM2x3 + addendM2x3,
        augendM3x1 + addendM3x1, augendM3x2 + addendM3x2, augendM3x3 + addendM3x3
        );

    /// <summary>
    /// Used to add two matrices together.
    /// </summary>
    /// <param name="augendM1x1">The augend M1X1.</param>
    /// <param name="augendM1x2">The augend M1X2.</param>
    /// <param name="augendM1x3"></param>
    /// <param name="augendM1x4"></param>
    /// <param name="augendM2x1">The augend M2X1.</param>
    /// <param name="augendM2x2">The augend M2X2.</param>
    /// <param name="augendM2x3"></param>
    /// <param name="augendM2x4"></param>
    /// <param name="augendM3x1"></param>
    /// <param name="augendM3x2"></param>
    /// <param name="augendM3x3"></param>
    /// <param name="augendM3x4"></param>
    /// <param name="augendM4x1"></param>
    /// <param name="augendM4x2"></param>
    /// <param name="augendM4x3"></param>
    /// <param name="augendM4x4"></param>
    /// <param name="addendM1x1">The addend M1X1.</param>
    /// <param name="addendM1x2">The addend M1X2.</param>
    /// <param name="addendM1x3"></param>
    /// <param name="addendM1x4"></param>
    /// <param name="addendM2x1">The addend M2X1.</param>
    /// <param name="addendM2x2">The addend M2X2.</param>
    /// <param name="addendM2x3"></param>
    /// <param name="addendM2x4"></param>
    /// <param name="addendM3x1"></param>
    /// <param name="addendM3x2"></param>
    /// <param name="addendM3x3"></param>
    /// <param name="addendM3x4"></param>
    /// <param name="addendM4x1"></param>
    /// <param name="addendM4x2"></param>
    /// <param name="addendM4x3"></param>
    /// <param name="addendM4x4"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4
        ) AddMatrix<T>(
        T augendM1x1, T augendM1x2, T augendM1x3, T augendM1x4,
        T augendM2x1, T augendM2x2, T augendM2x3, T augendM2x4,
        T augendM3x1, T augendM3x2, T augendM3x3, T augendM3x4,
        T augendM4x1, T augendM4x2, T augendM4x3, T augendM4x4,
        T addendM1x1, T addendM1x2, T addendM1x3, T addendM1x4,
        T addendM2x1, T addendM2x2, T addendM2x3, T addendM2x4,
        T addendM3x1, T addendM3x2, T addendM3x3, T addendM3x4,
        T addendM4x1, T addendM4x2, T addendM4x3, T addendM4x4)
        where T : INumber<T>
        => (
        augendM1x1 + addendM1x1, augendM1x2 + addendM1x2, augendM1x3 + addendM1x3, augendM1x4 + addendM1x4,
        augendM2x1 + addendM2x1, augendM2x2 + addendM2x2, augendM2x3 + addendM2x3, augendM2x4 + addendM2x4,
        augendM3x1 + addendM3x1, augendM3x2 + addendM3x2, augendM3x3 + addendM3x3, augendM3x4 + addendM3x4,
        augendM4x1 + addendM4x1, augendM4x2 + addendM4x2, augendM4x3 + addendM4x3, augendM4x4 + addendM4x4
        );

    /// <summary>
    /// Used to add two matrices together.
    /// </summary>
    /// <param name="augendM1x1">The augend M1X1.</param>
    /// <param name="augendM1x2">The augend M1X2.</param>
    /// <param name="augendM1x3"></param>
    /// <param name="augendM1x4"></param>
    /// <param name="augendM1x5"></param>
    /// <param name="augendM2x1">The augend M2X1.</param>
    /// <param name="augendM2x2">The augend M2X2.</param>
    /// <param name="augendM2x3"></param>
    /// <param name="augendM2x4"></param>
    /// <param name="augendM2x5"></param>
    /// <param name="augendM3x1"></param>
    /// <param name="augendM3x2"></param>
    /// <param name="augendM3x3"></param>
    /// <param name="augendM3x4"></param>
    /// <param name="augendM3x5"></param>
    /// <param name="augendM4x1"></param>
    /// <param name="augendM4x2"></param>
    /// <param name="augendM4x3"></param>
    /// <param name="augendM4x4"></param>
    /// <param name="augendM4x5"></param>
    /// <param name="augendM5x1"></param>
    /// <param name="augendM5x2"></param>
    /// <param name="augendM5x3"></param>
    /// <param name="augendM5x4"></param>
    /// <param name="augendM5x5"></param>
    /// <param name="addendM1x1">The addend M1X1.</param>
    /// <param name="addendM1x2">The addend M1X2.</param>
    /// <param name="addendM1x3"></param>
    /// <param name="addendM1x4"></param>
    /// <param name="addendM1x5"></param>
    /// <param name="addendM2x1">The addend M2X1.</param>
    /// <param name="addendM2x2">The addend M2X2.</param>
    /// <param name="addendM2x3"></param>
    /// <param name="addendM2x4"></param>
    /// <param name="addendM2x5"></param>
    /// <param name="addendM3x1"></param>
    /// <param name="addendM3x2"></param>
    /// <param name="addendM3x3"></param>
    /// <param name="addendM3x4"></param>
    /// <param name="addendM3x5"></param>
    /// <param name="addendM4x1"></param>
    /// <param name="addendM4x2"></param>
    /// <param name="addendM4x3"></param>
    /// <param name="addendM4x4"></param>
    /// <param name="addendM4x5"></param>
    /// <param name="addendM5x1"></param>
    /// <param name="addendM5x2"></param>
    /// <param name="addendM5x3"></param>
    /// <param name="addendM5x4"></param>
    /// <param name="addendM5x5"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5
        ) AddMatrix<T>(
        T augendM1x1, T augendM1x2, T augendM1x3, T augendM1x4, T augendM1x5,
        T augendM2x1, T augendM2x2, T augendM2x3, T augendM2x4, T augendM2x5,
        T augendM3x1, T augendM3x2, T augendM3x3, T augendM3x4, T augendM3x5,
        T augendM4x1, T augendM4x2, T augendM4x3, T augendM4x4, T augendM4x5,
        T augendM5x1, T augendM5x2, T augendM5x3, T augendM5x4, T augendM5x5,
        T addendM1x1, T addendM1x2, T addendM1x3, T addendM1x4, T addendM1x5,
        T addendM2x1, T addendM2x2, T addendM2x3, T addendM2x4, T addendM2x5,
        T addendM3x1, T addendM3x2, T addendM3x3, T addendM3x4, T addendM3x5,
        T addendM4x1, T addendM4x2, T addendM4x3, T addendM4x4, T addendM4x5,
        T addendM5x1, T addendM5x2, T addendM5x3, T addendM5x4, T addendM5x5)
        where T : INumber<T>
        => (
        augendM1x1 + addendM1x1, augendM1x2 + addendM1x2, augendM1x3 + addendM1x3, augendM1x4 + addendM1x4, augendM1x5 + addendM1x5,
        augendM2x1 + addendM2x1, augendM2x2 + addendM2x2, augendM2x3 + addendM2x3, augendM2x4 + addendM2x4, augendM2x5 + addendM2x5,
        augendM3x1 + addendM3x1, augendM3x2 + addendM3x2, augendM3x3 + addendM3x3, augendM3x4 + addendM3x4, augendM3x5 + addendM3x5,
        augendM4x1 + addendM4x1, augendM4x2 + addendM4x2, augendM4x3 + addendM4x3, augendM4x4 + addendM4x4, augendM4x5 + addendM4x5,
        augendM5x1 + addendM5x1, augendM5x2 + addendM5x2, augendM5x3 + addendM5x3, augendM5x4 + addendM5x4, augendM5x5 + addendM5x5
        );
    #endregion

    #region Matrix Negation
    /// <summary>
    /// Applies the plus operator to the specified augend.
    /// </summary>
    /// <param name="augend">The augend.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Negate<T>(Span2D<T> augend)
        where T : INumber<T>
    {
        var rows = augend.Height;
        var cols = augend.Width;

        var difference = new T[rows, cols];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                difference[i, j] = -augend[i, j];
            }
        }

        return difference;
    }

    /// <summary>
    /// Used to negate a matrix.
    /// </summary>
    /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
    /// <param name="subtrahendM1x2">The subtrahend M1X2.</param>
    /// <param name="subtrahendM2x1">The subtrahend M2X1.</param>
    /// <param name="subtrahendM2x2">The subtrahend M2X2.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2
        )
        NegateMatrix<T>(
        T subtrahendM1x1, T subtrahendM1x2,
        T subtrahendM2x1, T subtrahendM2x2)
        where T : INumber<T>
        => (-subtrahendM1x1, -subtrahendM1x2,
            -subtrahendM2x1, -subtrahendM2x2);

    /// <summary>
    /// Used to negate a matrix.
    /// </summary>
    /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
    /// <param name="subtrahendM1x2">The subtrahend M1X2.</param>
    /// <param name="subtrahendM2x1">The subtrahend M2X1.</param>
    /// <param name="subtrahendM2x2">The subtrahend M2X2.</param>
    /// <param name="subtrahendM3x1"></param>
    /// <param name="subtrahendM3x2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2,
        T m3x1, T m3x2
        )
        NegateMatrix<T>(
        T subtrahendM1x1, T subtrahendM1x2,
        T subtrahendM2x1, T subtrahendM2x2,
        T subtrahendM3x1, T subtrahendM3x2)
        where T : INumber<T>
        => (-subtrahendM1x1, -subtrahendM1x2,
            -subtrahendM2x1, -subtrahendM2x2,
            -subtrahendM3x1, -subtrahendM3x2);

    /// <summary>
    /// Used to negate a matrix.
    /// </summary>
    /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
    /// <param name="subtrahendM1x2">The subtrahend M1X2.</param>
    /// <param name="subtrahendM1x3"></param>
    /// <param name="subtrahendM2x1">The subtrahend M2X1.</param>
    /// <param name="subtrahendM2x2">The subtrahend M2X2.</param>
    /// <param name="subtrahendM2x3"></param>
    /// <param name="subtrahendM3x1"></param>
    /// <param name="subtrahendM3x2"></param>
    /// <param name="subtrahendM3x3"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3
        )
        NegateMatrix<T>(
        T subtrahendM1x1, T subtrahendM1x2, T subtrahendM1x3,
        T subtrahendM2x1, T subtrahendM2x2, T subtrahendM2x3,
        T subtrahendM3x1, T subtrahendM3x2, T subtrahendM3x3)
        where T : INumber<T>
        => (-subtrahendM1x1, -subtrahendM1x2, -subtrahendM1x3,
            -subtrahendM2x1, -subtrahendM2x2, -subtrahendM2x3,
            -subtrahendM3x1, -subtrahendM3x2, -subtrahendM3x3);

    /// <summary>
    /// Used to negate a matrix.
    /// </summary>
    /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
    /// <param name="subtrahendM1x2">The subtrahend M1X2.</param>
    /// <param name="subtrahendM1x3"></param>
    /// <param name="subtrahendM1x4"></param>
    /// <param name="subtrahendM2x1">The subtrahend M2X1.</param>
    /// <param name="subtrahendM2x2">The subtrahend M2X2.</param>
    /// <param name="subtrahendM2x3"></param>
    /// <param name="subtrahendM2x4"></param>
    /// <param name="subtrahendM3x1"></param>
    /// <param name="subtrahendM3x2"></param>
    /// <param name="subtrahendM3x3"></param>
    /// <param name="subtrahendM3x4"></param>
    /// <param name="subtrahendM4x1"></param>
    /// <param name="subtrahendM4x2"></param>
    /// <param name="subtrahendM4x3"></param>
    /// <param name="subtrahendM4x4"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4
        )
        NegateMatrix<T>(
        T subtrahendM1x1, T subtrahendM1x2, T subtrahendM1x3, T subtrahendM1x4,
        T subtrahendM2x1, T subtrahendM2x2, T subtrahendM2x3, T subtrahendM2x4,
        T subtrahendM3x1, T subtrahendM3x2, T subtrahendM3x3, T subtrahendM3x4,
        T subtrahendM4x1, T subtrahendM4x2, T subtrahendM4x3, T subtrahendM4x4)
        where T : INumber<T>
        => (-subtrahendM1x1, -subtrahendM1x2, -subtrahendM1x3, -subtrahendM1x4,
            -subtrahendM2x1, -subtrahendM2x2, -subtrahendM2x3, -subtrahendM2x4,
            -subtrahendM3x1, -subtrahendM3x2, -subtrahendM3x3, -subtrahendM3x4,
            -subtrahendM4x1, -subtrahendM4x2, -subtrahendM4x3, -subtrahendM4x4);

    /// <summary>
    /// Used to negate a matrix.
    /// </summary>
    /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
    /// <param name="subtrahendM1x2">The subtrahend M1X2.</param>
    /// <param name="subtrahendM1x3"></param>
    /// <param name="subtrahendM1x4"></param>
    /// <param name="subtrahendM1x5"></param>
    /// <param name="subtrahendM2x1">The subtrahend M2X1.</param>
    /// <param name="subtrahendM2x2">The subtrahend M2X2.</param>
    /// <param name="subtrahendM2x3"></param>
    /// <param name="subtrahendM2x4"></param>
    /// <param name="subtrahendM2x5"></param>
    /// <param name="subtrahendM3x1"></param>
    /// <param name="subtrahendM3x2"></param>
    /// <param name="subtrahendM3x3"></param>
    /// <param name="subtrahendM3x4"></param>
    /// <param name="subtrahendM3x5"></param>
    /// <param name="subtrahendM4x1"></param>
    /// <param name="subtrahendM4x2"></param>
    /// <param name="subtrahendM4x3"></param>
    /// <param name="subtrahendM4x4"></param>
    /// <param name="subtrahendM4x5"></param>
    /// <param name="subtrahendM5x1"></param>
    /// <param name="subtrahendM5x2"></param>
    /// <param name="subtrahendM5x3"></param>
    /// <param name="subtrahendM5x4"></param>
    /// <param name="subtrahendM5x5"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5
        )
        NegateMatrix<T>(
        T subtrahendM1x1, T subtrahendM1x2, T subtrahendM1x3, T subtrahendM1x4, T subtrahendM1x5,
        T subtrahendM2x1, T subtrahendM2x2, T subtrahendM2x3, T subtrahendM2x4, T subtrahendM2x5,
        T subtrahendM3x1, T subtrahendM3x2, T subtrahendM3x3, T subtrahendM3x4, T subtrahendM3x5,
        T subtrahendM4x1, T subtrahendM4x2, T subtrahendM4x3, T subtrahendM4x4, T subtrahendM4x5,
        T subtrahendM5x1, T subtrahendM5x2, T subtrahendM5x3, T subtrahendM5x4, T subtrahendM5x5)
        where T : INumber<T>
        => (-subtrahendM1x1, -subtrahendM1x2, -subtrahendM1x3, -subtrahendM1x4, -subtrahendM1x5,
            -subtrahendM2x1, -subtrahendM2x2, -subtrahendM2x3, -subtrahendM2x4, -subtrahendM2x5,
            -subtrahendM3x1, -subtrahendM3x2, -subtrahendM3x3, -subtrahendM3x4, -subtrahendM3x5,
            -subtrahendM4x1, -subtrahendM4x2, -subtrahendM4x3, -subtrahendM4x4, -subtrahendM4x5,
            -subtrahendM5x1, -subtrahendM5x2, -subtrahendM5x3, -subtrahendM5x4, -subtrahendM5x5);
    #endregion

    #region Matrix Subtraction
    /// <summary>
    /// Subtracts the specified minuend.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subtrahend">The subtrahend.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Subtract<T>(Span2D<T> minuend, Span2D<T> subtrahend)
        where T : INumber<T>
    {
        if (minuend == null)
        {
            return subtrahend.ToArray();
        }

        if (subtrahend == null)
        {
            return minuend.ToArray();
        }

        var rowsMinuend = minuend.Height;
        var columnsMinuend = minuend.Width;
        var rowsSubtrahend = subtrahend.Height;
        var columnsSubtrahend = subtrahend.Width;

        if (rowsMinuend != rowsSubtrahend || columnsMinuend != columnsSubtrahend)
        {
            throw new ArgumentException($"The {nameof(minuend)} Matrix must be the same size as the {nameof(subtrahend)} Matrix.");
        }

        var difference = new T[rowsMinuend, columnsMinuend];

        for (var i = 0; i < rowsMinuend; i++)
        {
            for (var j = 0; j < columnsMinuend; j++)
            {
                difference[i, j] = minuend[i, j] - subtrahend[i, j];
            }
        }

        return difference;
    }

    /// <summary>
    /// Subtracts the specified minuend.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subtrahend">The subtrahend.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] Subtract<T, TResult>(Span2D<T> minuend, Span2D<T> subtrahend)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        if (minuend == null)
        {
            return Cast<T, TResult>(subtrahend);
        }

        if (subtrahend == null)
        {
            return Cast<T, TResult>(minuend);
        }

        var rowsMinuend = minuend.Height;
        var columnsMinuend = minuend.Width;
        var rowsSubtrahend = subtrahend.Height;
        var columnsSubtrahend = subtrahend.Width;

        if (rowsMinuend != rowsSubtrahend || columnsMinuend != columnsSubtrahend)
        {
            throw new ArgumentException($"The {nameof(minuend)} Matrix must be the same size as the {nameof(subtrahend)} Matrix.");
        }

        var difference = new TResult[rowsMinuend, columnsMinuend];

        for (var i = 0; i < rowsMinuend; i++)
        {
            for (var j = 0; j < columnsMinuend; j++)
            {
                difference[i, j] = TResult.Create(minuend[i, j] - subtrahend[i, j]);
            }
        }

        return difference;
    }

    /// <summary>
    /// Subtracts the matrix.
    /// </summary>
    /// <param name="minuend">The matrix1.</param>
    /// <param name="subtrahend">The matrix2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L75
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] SubtractMatrix<T>(Span2D<T> minuend, Span2D<T> subtrahend)
        where T : INumber<T>
    {
        if (minuend == null)
        {
            return subtrahend.ToArray();
        }

        if (subtrahend == null)
        {
            return minuend.ToArray();
        }

        var rowsMinuend = minuend.Height;
        var columnsMinuend = minuend.Width;
        var rowsSubtrahend = subtrahend.Height;
        var columnsSubtrahend = subtrahend.Width;

        // returning an empty matrix instead of throwing. Must be to prevent crashing?
        if (rowsMinuend != rowsSubtrahend || columnsMinuend != columnsSubtrahend)
        {
            return new T[1, 1];
        }

        var rows = Math.Min(rowsMinuend, rowsSubtrahend); // These should always be the same because of the above return.
        var columns = Math.Min(columnsMinuend, columnsSubtrahend); // These should always be the same because of the above return.
        var difference = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                difference[i, j] = minuend[i, j] - subtrahend[i, j];
            }
        }

        return difference;
    }

    /// <summary>
    /// Subtracts two matrices.
    /// </summary>
    /// <param name="minuend">The matrix1.</param>
    /// <param name="subtrahend">The matrix2.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Subtract<T>(Span2D<T> minuend, Span2D<T> subtrahend, int accuracy)
        where T : IFloatingPoint<T>
    {
        if (minuend == null)
        {
            return subtrahend.ToArray();
        }

        if (subtrahend == null)
        {
            return minuend.ToArray();
        }

        var rowsMinuend = minuend.Height;
        var columnsMinuend = minuend.Width;
        var rowsSubtrahend = subtrahend.Height;
        var columnsSubtrahend = subtrahend.Width;

        if (rowsMinuend != rowsSubtrahend || columnsMinuend != columnsSubtrahend)
        {
            throw new ArgumentException($"The {nameof(minuend)} Matrix must be the same size as the {nameof(subtrahend)} Matrix.");
        }

        var difference = new T[rowsMinuend, columnsMinuend];

        for (var i = 0; i < rowsMinuend; i++)
        {
            for (var j = 0; j < columnsMinuend; j++)
            {
                difference[i, j] = minuend[i, j] - subtrahend[i, j];
            }
        }

        return Round<T, T>(difference, rowsMinuend, columnsMinuend, accuracy);
    }

    /// <summary>
    /// Subtracts two matrices.
    /// </summary>
    /// <param name="minuend">The matrix1.</param>
    /// <param name="subtrahend">The matrix2.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Subtract<T>(Span2D<T> minuend, Span2D<T> subtrahend, int rows, int columns)
        where T : INumber<T>
    {
        if (minuend == null)
        {
            return subtrahend.ToArray();
        }

        if (subtrahend == null)
        {
            return minuend.ToArray();
        }

        var rowsMinuend = minuend.Height;
        var columnsMinuend = minuend.Width;
        var rowsSubtrahend = subtrahend.Height;
        var columnsSubtrahend = subtrahend.Width;

        if (rows > rowsMinuend || columns > columnsMinuend || rows > rowsSubtrahend || columns > columnsSubtrahend)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(minuend)} and {nameof(subtrahend)}");
        }

        var difference = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                difference[i, j] = minuend[i, j] - subtrahend[i, j];
            }
        }

        return difference;
    }

    /// <summary>
    /// Subtracts two matrices.
    /// </summary>
    /// <param name="minuend">The matrix1.</param>
    /// <param name="subtrahend">The matrix2.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Subtract<T>(Span2D<T> minuend, Span2D<T> subtrahend, int rows, int columns, int accuracy)
        where T : IFloatingPoint<T>
    {
        if (minuend == null)
        {
            return subtrahend.ToArray();
        }

        if (subtrahend == null)
        {
            return minuend.ToArray();
        }

        var rowsMinuend = minuend.Height;
        var columnsMinuend = minuend.Width;
        var rowsSubtrahend = subtrahend.Height;
        var columnsSubtrahend = subtrahend.Width;

        if (rows > rowsMinuend || columns > columnsMinuend || rows > rowsSubtrahend || columns > columnsSubtrahend)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(minuend)} and {nameof(subtrahend)}");
        }

        var difference = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                difference[i, j] = minuend[i, j] - subtrahend[i, j];
            }
        }

        return Round<T, T>(difference, rows, columns, accuracy);
    }

    /// <summary>
    /// Used to subtract two matrices.
    /// </summary>
    /// <param name="minuendM1x1">The minuend M1X1.</param>
    /// <param name="minuendM1x2">The minuend M1X2.</param>
    /// <param name="minuendM2x1">The minuend M2X1.</param>
    /// <param name="minuendM2x2">The minuend M2X2.</param>
    /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
    /// <param name="subtrahendM1x2">The subtrahend M1X2.</param>
    /// <param name="subtrahendM2x1">The subtrahend M2X1.</param>
    /// <param name="subtrahendM2x2">The subtrahend M2X2.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2)
        SubtractMatrix<T>(
        T minuendM1x1, T minuendM1x2,
        T minuendM2x1, T minuendM2x2,
        T subtrahendM1x1, T subtrahendM1x2,
        T subtrahendM2x1, T subtrahendM2x2)
        where T : INumber<T>
        => (minuendM1x1 - subtrahendM1x1, minuendM1x2 - subtrahendM1x2,
            minuendM2x1 - subtrahendM2x1, minuendM2x2 - subtrahendM2x2);

    /// <summary>
    /// Used to subtract two matrices.
    /// </summary>
    /// <param name="minuendM1x1">The minuend M1X1.</param>
    /// <param name="minuendM1x2">The minuend M1X2.</param>
    /// <param name="minuendM2x1">The minuend M2X1.</param>
    /// <param name="minuendM2x2">The minuend M2X2.</param>
    /// <param name="minuendM3x1"></param>
    /// <param name="minuendM3x2"></param>
    /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
    /// <param name="subtrahendM1x2">The subtrahend M1X2.</param>
    /// <param name="subtrahendM2x1">The subtrahend M2X1.</param>
    /// <param name="subtrahendM2x2">The subtrahend M2X2.</param>
    /// <param name="subtrahendM3x1"></param>
    /// <param name="subtrahendM3x2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2,
        T m3x1, T m3x2
        )
        SubtractMatrix<T>(
        T minuendM1x1, T minuendM1x2,
        T minuendM2x1, T minuendM2x2,
        T minuendM3x1, T minuendM3x2,
        T subtrahendM1x1, T subtrahendM1x2,
        T subtrahendM2x1, T subtrahendM2x2,
        T subtrahendM3x1, T subtrahendM3x2)
        where T : INumber<T>
        => (minuendM1x1 - subtrahendM1x1, minuendM1x2 - subtrahendM1x2,
            minuendM2x1 - subtrahendM2x1, minuendM2x2 - subtrahendM2x2,
            minuendM3x1 - subtrahendM3x1, minuendM3x2 - subtrahendM3x2);

    /// <summary>
    /// Used to subtract two matrices.
    /// </summary>
    /// <param name="minuendM1x1">The minuend M1X1.</param>
    /// <param name="minuendM1x2">The minuend M1X2.</param>
    /// <param name="minuendM1x3"></param>
    /// <param name="minuendM2x1">The minuend M2X1.</param>
    /// <param name="minuendM2x2">The minuend M2X2.</param>
    /// <param name="minuendM2x3"></param>
    /// <param name="minuendM3x1"></param>
    /// <param name="minuendM3x2"></param>
    /// <param name="minuendM3x3"></param>
    /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
    /// <param name="subtrahendM1x2">The subtrahend M1X2.</param>
    /// <param name="subtrahendM1x3"></param>
    /// <param name="subtrahendM2x1">The subtrahend M2X1.</param>
    /// <param name="subtrahendM2x2">The subtrahend M2X2.</param>
    /// <param name="subtrahendM2x3"></param>
    /// <param name="subtrahendM3x1"></param>
    /// <param name="subtrahendM3x2"></param>
    /// <param name="subtrahendM3x3"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3
        )
        SubtractMatrix<T>(
        T minuendM1x1, T minuendM1x2, T minuendM1x3,
        T minuendM2x1, T minuendM2x2, T minuendM2x3,
        T minuendM3x1, T minuendM3x2, T minuendM3x3,
        T subtrahendM1x1, T subtrahendM1x2, T subtrahendM1x3,
        T subtrahendM2x1, T subtrahendM2x2, T subtrahendM2x3,
        T subtrahendM3x1, T subtrahendM3x2, T subtrahendM3x3)
        where T : INumber<T>
        => (minuendM1x1 - subtrahendM1x1, minuendM1x2 - subtrahendM1x2, minuendM1x3 - subtrahendM1x3,
            minuendM2x1 - subtrahendM2x1, minuendM2x2 - subtrahendM2x2, minuendM2x3 - subtrahendM2x3,
            minuendM3x1 - subtrahendM3x1, minuendM3x2 - subtrahendM3x2, minuendM3x3 - subtrahendM3x3);

    /// <summary>
    /// Used to subtract two matrices.
    /// </summary>
    /// <param name="minuendM1x1">The minuend M1X1.</param>
    /// <param name="minuendM1x2">The minuend M1X2.</param>
    /// <param name="minuendM1x3"></param>
    /// <param name="minuendM1x4"></param>
    /// <param name="minuendM2x1">The minuend M2X1.</param>
    /// <param name="minuendM2x2">The minuend M2X2.</param>
    /// <param name="minuendM2x3"></param>
    /// <param name="minuendM2x4"></param>
    /// <param name="minuendM3x1"></param>
    /// <param name="minuendM3x2"></param>
    /// <param name="minuendM3x3"></param>
    /// <param name="minuendM3x4"></param>
    /// <param name="minuendM4x1"></param>
    /// <param name="minuendM4x2"></param>
    /// <param name="minuendM4x3"></param>
    /// <param name="minuendM4x4"></param>
    /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
    /// <param name="subtrahendM1x2">The subtrahend M1X2.</param>
    /// <param name="subtrahendM1x3"></param>
    /// <param name="subtrahendM1x4"></param>
    /// <param name="subtrahendM2x1">The subtrahend M2X1.</param>
    /// <param name="subtrahendM2x2">The subtrahend M2X2.</param>
    /// <param name="subtrahendM2x3"></param>
    /// <param name="subtrahendM2x4"></param>
    /// <param name="subtrahendM3x1"></param>
    /// <param name="subtrahendM3x2"></param>
    /// <param name="subtrahendM3x3"></param>
    /// <param name="subtrahendM3x4"></param>
    /// <param name="subtrahendM4x1"></param>
    /// <param name="subtrahendM4x2"></param>
    /// <param name="subtrahendM4x3"></param>
    /// <param name="subtrahendM4x4"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4
        )
        SubtractMatrix<T>(
        T minuendM1x1, T minuendM1x2, T minuendM1x3, T minuendM1x4,
        T minuendM2x1, T minuendM2x2, T minuendM2x3, T minuendM2x4,
        T minuendM3x1, T minuendM3x2, T minuendM3x3, T minuendM3x4,
        T minuendM4x1, T minuendM4x2, T minuendM4x3, T minuendM4x4,
        T subtrahendM1x1, T subtrahendM1x2, T subtrahendM1x3, T subtrahendM1x4,
        T subtrahendM2x1, T subtrahendM2x2, T subtrahendM2x3, T subtrahendM2x4,
        T subtrahendM3x1, T subtrahendM3x2, T subtrahendM3x3, T subtrahendM3x4,
        T subtrahendM4x1, T subtrahendM4x2, T subtrahendM4x3, T subtrahendM4x4)
        where T : INumber<T>
        => (minuendM1x1 - subtrahendM1x1, minuendM1x2 - subtrahendM1x2, minuendM1x3 - subtrahendM1x3, minuendM1x4 - subtrahendM1x4,
            minuendM2x1 - subtrahendM2x1, minuendM2x2 - subtrahendM2x2, minuendM2x3 - subtrahendM2x3, minuendM2x4 - subtrahendM2x4,
            minuendM3x1 - subtrahendM3x1, minuendM3x2 - subtrahendM3x2, minuendM3x3 - subtrahendM3x3, minuendM3x4 - subtrahendM3x4,
            minuendM4x1 - subtrahendM4x1, minuendM4x2 - subtrahendM4x2, minuendM4x3 - subtrahendM4x3, minuendM4x4 - subtrahendM4x4);

    /// <summary>
    /// Used to subtract two matrices.
    /// </summary>
    /// <param name="minuendM1x1">The minuend M1X1.</param>
    /// <param name="minuendM1x2">The minuend M1X2.</param>
    /// <param name="minuendM1x3"></param>
    /// <param name="minuendM1x4"></param>
    /// <param name="minuendM1x5"></param>
    /// <param name="minuendM2x1">The minuend M2X1.</param>
    /// <param name="minuendM2x2">The minuend M2X2.</param>
    /// <param name="minuendM2x3"></param>
    /// <param name="minuendM2x4"></param>
    /// <param name="minuendM2x5"></param>
    /// <param name="minuendM3x1"></param>
    /// <param name="minuendM3x2"></param>
    /// <param name="minuendM3x3"></param>
    /// <param name="minuendM3x4"></param>
    /// <param name="minuendM3x5"></param>
    /// <param name="minuendM4x1"></param>
    /// <param name="minuendM4x2"></param>
    /// <param name="minuendM4x3"></param>
    /// <param name="minuendM4x4"></param>
    /// <param name="minuendM4x5"></param>
    /// <param name="minuendM5x1"></param>
    /// <param name="minuendM5x2"></param>
    /// <param name="minuendM5x3"></param>
    /// <param name="minuendM5x4"></param>
    /// <param name="minuendM5x5"></param>
    /// <param name="subtrahendM1x1">The subtrahend M1X1.</param>
    /// <param name="subtrahendM1x2">The subtrahend M1X2.</param>
    /// <param name="subtrahendM1x3"></param>
    /// <param name="subtrahendM1x4"></param>
    /// <param name="subtrahendM1x5"></param>
    /// <param name="subtrahendM2x1">The subtrahend M2X1.</param>
    /// <param name="subtrahendM2x2">The subtrahend M2X2.</param>
    /// <param name="subtrahendM2x3"></param>
    /// <param name="subtrahendM2x4"></param>
    /// <param name="subtrahendM2x5"></param>
    /// <param name="subtrahendM3x1"></param>
    /// <param name="subtrahendM3x2"></param>
    /// <param name="subtrahendM3x3"></param>
    /// <param name="subtrahendM3x4"></param>
    /// <param name="subtrahendM3x5"></param>
    /// <param name="subtrahendM4x1"></param>
    /// <param name="subtrahendM4x2"></param>
    /// <param name="subtrahendM4x3"></param>
    /// <param name="subtrahendM4x4"></param>
    /// <param name="subtrahendM4x5"></param>
    /// <param name="subtrahendM5x1"></param>
    /// <param name="subtrahendM5x2"></param>
    /// <param name="subtrahendM5x3"></param>
    /// <param name="subtrahendM5x4"></param>
    /// <param name="subtrahendM5x5"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5
        )
        SubtractMatrix<T>(
        T minuendM1x1, T minuendM1x2, T minuendM1x3, T minuendM1x4, T minuendM1x5,
        T minuendM2x1, T minuendM2x2, T minuendM2x3, T minuendM2x4, T minuendM2x5,
        T minuendM3x1, T minuendM3x2, T minuendM3x3, T minuendM3x4, T minuendM3x5,
        T minuendM4x1, T minuendM4x2, T minuendM4x3, T minuendM4x4, T minuendM4x5,
        T minuendM5x1, T minuendM5x2, T minuendM5x3, T minuendM5x4, T minuendM5x5,
        T subtrahendM1x1, T subtrahendM1x2, T subtrahendM1x3, T subtrahendM1x4, T subtrahendM1x5,
        T subtrahendM2x1, T subtrahendM2x2, T subtrahendM2x3, T subtrahendM2x4, T subtrahendM2x5,
        T subtrahendM3x1, T subtrahendM3x2, T subtrahendM3x3, T subtrahendM3x4, T subtrahendM3x5,
        T subtrahendM4x1, T subtrahendM4x2, T subtrahendM4x3, T subtrahendM4x4, T subtrahendM4x5,
        T subtrahendM5x1, T subtrahendM5x2, T subtrahendM5x3, T subtrahendM5x4, T subtrahendM5x5)
        where T : INumber<T>
        => (minuendM1x1 - subtrahendM1x1, minuendM1x2 - subtrahendM1x2, minuendM1x3 - subtrahendM1x3, minuendM1x4 - subtrahendM1x4, minuendM1x5 - subtrahendM1x5,
            minuendM2x1 - subtrahendM2x1, minuendM2x2 - subtrahendM2x2, minuendM2x3 - subtrahendM2x3, minuendM2x4 - subtrahendM2x4, minuendM2x5 - subtrahendM2x5,
            minuendM3x1 - subtrahendM3x1, minuendM3x2 - subtrahendM3x2, minuendM3x3 - subtrahendM3x3, minuendM3x4 - subtrahendM3x4, minuendM3x5 - subtrahendM3x5,
            minuendM4x1 - subtrahendM4x1, minuendM4x2 - subtrahendM4x2, minuendM4x3 - subtrahendM4x3, minuendM4x4 - subtrahendM4x4, minuendM4x5 - subtrahendM4x5,
            minuendM5x1 - subtrahendM5x1, minuendM5x2 - subtrahendM5x2, minuendM5x3 - subtrahendM5x3, minuendM5x4 - subtrahendM5x4, minuendM5x5 - subtrahendM5x5);
    #endregion

    #region Matrix Scaling
    /// <summary>
    /// Multiplies the specified multiplier by a scalar.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns></returns>
    /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Scale<T>(T multiplicand, Span2D<T> multiplier)
        where T : INumber<T>
    {
        if (multiplicand == null)
        {
            return multiplier.ToArray();
        }

        if (multiplier == null)
        {
            return new T[,] { { multiplicand } };
        }

        var multiplierRows = multiplier.Height;
        var multiplierColumns = multiplier.Width;

        var product = new T[multiplierRows, multiplierColumns];

        for (var i = 0; i < multiplierRows; i++)
        {
            for (var j = 0; j < multiplierColumns; j++)
            {
                product[i, j] = multiplicand * multiplier[i, j];
            }
        }

        return product;
    }

    /// <summary>
    /// Matrix multiplications by scalar.
    /// </summary>
    /// <param name="multiplicand">The scalar.</param>
    /// <param name="multiplier">The matrix.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Scale<T>(T multiplicand, Span2D<T> multiplier, int accuracy)
        where T : IFloatingPoint<T>
    {
        if (multiplicand == null)
        {
            return multiplier.ToArray();
        }

        if (multiplier == null)
        {
            return new T[,] { { multiplicand } };
        }

        var multiplierRows = multiplier.Height;
        var multiplierColumns = multiplier.Width;

        var product = new T[multiplierRows, multiplierColumns];

        for (var i = 0; i < multiplierRows; i++)
        {
            for (var j = 0; j < multiplierColumns; j++)
            {
                product[i, j] = multiplicand * multiplier[i, j];
            }
        }

        return Round<T, T>(product, accuracy);
    }

    /// <summary>
    /// Matrix multiplications by scalar.
    /// </summary>
    /// <param name="multiplicand">The scalar.</param>
    /// <param name="multiplier">The matrix.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Scale<T>(T multiplicand, Span2D<T> multiplier, int rows, int columns)
        where T : INumber<T>
    {
        if (multiplicand == null)
        {
            return multiplier.ToArray();
        }

        if (multiplier == null)
        {
            return new T[,] { { multiplicand } };
        }

        var rowsMultiplier = multiplier.Height;
        var columnsMultiplier = multiplier.Width;

        if (rows > rowsMultiplier || columns > columnsMultiplier)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(multiplier)}");
        }

        var product = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                product[i, j] = multiplicand * multiplier[i, j];
            }
        }

        return product;
    }

    /// <summary>
    /// Matrix multiplications by scalar.
    /// </summary>
    /// <param name="multiplicand">The scalar.</param>
    /// <param name="multiplier">The matrix.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Scale<T>(T multiplicand, Span2D<T> multiplier, int rows, int columns, int accuracy)
        where T : IFloatingPoint<T>
    {
        if (multiplicand == null)
        {
            return multiplier.ToArray();
        }

        if (multiplier == null)
        {
            return new T[,] { { multiplicand } };
        }

        var rowsMultiplier = multiplier.Height;
        var columnsMultiplier = multiplier.Width;

        if (rows > rowsMultiplier || columns > columnsMultiplier)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(multiplier)}");
        }

        var product = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                product[i, j] = multiplicand * multiplier[i, j];
            }
        }

        return Round<T, T>(product, rows, columns, accuracy);
    }

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicand"></param>
    /// <param name="multiplierM1x1"></param>
    /// <param name="multiplierM1x2"></param>
    /// <param name="multiplierM2x1"></param>
    /// <param name="multiplierM2x2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2
        )
        ScaleMatrixLeft<T>(
        T multiplicand,
        T multiplierM1x1, T multiplierM1x2,
        T multiplierM2x1, T multiplierM2x2)
        where T : INumber<T>
        => (multiplicand * multiplierM1x1, multiplicand * multiplierM1x2,
            multiplicand * multiplierM2x1, multiplicand * multiplierM2x2);

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicand"></param>
    /// <param name="multiplierM1x1"></param>
    /// <param name="multiplierM1x2"></param>
    /// <param name="multiplierM2x1"></param>
    /// <param name="multiplierM2x2"></param>
    /// <param name="multiplierM3x1"></param>
    /// <param name="multiplierM3x2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2,
        T m3x1, T m3x2
        )
        ScaleMatrixLeft<T>(
        T multiplicand,
        T multiplierM1x1, T multiplierM1x2,
        T multiplierM2x1, T multiplierM2x2,
        T multiplierM3x1, T multiplierM3x2)
        where T : INumber<T>
        => (multiplicand * multiplierM1x1, multiplicand * multiplierM1x2,
            multiplicand * multiplierM2x1, multiplicand * multiplierM2x2,
            multiplicand * multiplierM3x1, multiplicand * multiplierM3x2);

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicand"></param>
    /// <param name="multiplierM1x1"></param>
    /// <param name="multiplierM1x2"></param>
    /// <param name="multiplierM1x3"></param>
    /// <param name="multiplierM2x1"></param>
    /// <param name="multiplierM2x2"></param>
    /// <param name="multiplierM2x3"></param>
    /// <param name="multiplierM3x1"></param>
    /// <param name="multiplierM3x2"></param>
    /// <param name="multiplierM3x3"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3
        )
        ScaleMatrixLeft<T>(
        T multiplicand,
        T multiplierM1x1, T multiplierM1x2, T multiplierM1x3,
        T multiplierM2x1, T multiplierM2x2, T multiplierM2x3,
        T multiplierM3x1, T multiplierM3x2, T multiplierM3x3)
        where T : INumber<T>
        => (multiplicand * multiplierM1x1, multiplicand * multiplierM1x2, multiplicand * multiplierM1x3,
            multiplicand * multiplierM2x1, multiplicand * multiplierM2x2, multiplicand * multiplierM2x3,
            multiplicand * multiplierM3x1, multiplicand * multiplierM3x2, multiplicand * multiplierM3x3);

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicand"></param>
    /// <param name="multiplierM1x1"></param>
    /// <param name="multiplierM1x2"></param>
    /// <param name="multiplierM1x3"></param>
    /// <param name="multiplierM1x4"></param>
    /// <param name="multiplierM2x1"></param>
    /// <param name="multiplierM2x2"></param>
    /// <param name="multiplierM2x3"></param>
    /// <param name="multiplierM2x4"></param>
    /// <param name="multiplierM3x1"></param>
    /// <param name="multiplierM3x2"></param>
    /// <param name="multiplierM3x3"></param>
    /// <param name="multiplierM3x4"></param>
    /// <param name="multiplierM4x1"></param>
    /// <param name="multiplierM4x2"></param>
    /// <param name="multiplierM4x3"></param>
    /// <param name="multiplierM4x4"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4
        )
        ScaleMatrixLeft<T>(
        T multiplicand,
        T multiplierM1x1, T multiplierM1x2, T multiplierM1x3, T multiplierM1x4,
        T multiplierM2x1, T multiplierM2x2, T multiplierM2x3, T multiplierM2x4,
        T multiplierM3x1, T multiplierM3x2, T multiplierM3x3, T multiplierM3x4,
        T multiplierM4x1, T multiplierM4x2, T multiplierM4x3, T multiplierM4x4)
        where T : INumber<T>
        => (multiplicand * multiplierM1x1, multiplicand * multiplierM1x2, multiplicand * multiplierM1x3, multiplicand * multiplierM1x4,
            multiplicand * multiplierM2x1, multiplicand * multiplierM2x2, multiplicand * multiplierM2x3, multiplicand * multiplierM2x4,
            multiplicand * multiplierM3x1, multiplicand * multiplierM3x2, multiplicand * multiplierM3x3, multiplicand * multiplierM3x4,
            multiplicand * multiplierM4x1, multiplicand * multiplierM4x2, multiplicand * multiplierM4x3, multiplicand * multiplierM4x4);

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicand"></param>
    /// <param name="multiplierM1x1"></param>
    /// <param name="multiplierM1x2"></param>
    /// <param name="multiplierM1x3"></param>
    /// <param name="multiplierM1x4"></param>
    /// <param name="multiplierM1x5"></param>
    /// <param name="multiplierM2x1"></param>
    /// <param name="multiplierM2x2"></param>
    /// <param name="multiplierM2x3"></param>
    /// <param name="multiplierM2x4"></param>
    /// <param name="multiplierM2x5"></param>
    /// <param name="multiplierM3x1"></param>
    /// <param name="multiplierM3x2"></param>
    /// <param name="multiplierM3x3"></param>
    /// <param name="multiplierM3x4"></param>
    /// <param name="multiplierM3x5"></param>
    /// <param name="multiplierM4x1"></param>
    /// <param name="multiplierM4x2"></param>
    /// <param name="multiplierM4x3"></param>
    /// <param name="multiplierM4x4"></param>
    /// <param name="multiplierM4x5"></param>
    /// <param name="multiplierM5x1"></param>
    /// <param name="multiplierM5x2"></param>
    /// <param name="multiplierM5x3"></param>
    /// <param name="multiplierM5x4"></param>
    /// <param name="multiplierM5x5"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5
        )
        ScaleMatrixLeft<T>(
        T multiplicand,
        T multiplierM1x1, T multiplierM1x2, T multiplierM1x3, T multiplierM1x4, T multiplierM1x5,
        T multiplierM2x1, T multiplierM2x2, T multiplierM2x3, T multiplierM2x4, T multiplierM2x5,
        T multiplierM3x1, T multiplierM3x2, T multiplierM3x3, T multiplierM3x4, T multiplierM3x5,
        T multiplierM4x1, T multiplierM4x2, T multiplierM4x3, T multiplierM4x4, T multiplierM4x5,
        T multiplierM5x1, T multiplierM5x2, T multiplierM5x3, T multiplierM5x4, T multiplierM5x5)
        where T : INumber<T>
        => (multiplicand * multiplierM1x1, multiplicand * multiplierM1x2, multiplicand * multiplierM1x3, multiplicand * multiplierM1x4, multiplicand * multiplierM1x5,
            multiplicand * multiplierM2x1, multiplicand * multiplierM2x2, multiplicand * multiplierM2x3, multiplicand * multiplierM2x4, multiplicand * multiplierM2x5,
            multiplicand * multiplierM3x1, multiplicand * multiplierM3x2, multiplicand * multiplierM3x3, multiplicand * multiplierM3x4, multiplicand * multiplierM3x5,
            multiplicand * multiplierM4x1, multiplicand * multiplierM4x2, multiplicand * multiplierM4x3, multiplicand * multiplierM4x4, multiplicand * multiplierM4x5,
            multiplicand * multiplierM5x1, multiplicand * multiplierM5x2, multiplicand * multiplierM5x3, multiplicand * multiplierM5x4, multiplicand * multiplierM5x5);

    /// <summary>
    /// Multiplies the specified multiplicand by a scalar.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns></returns>
    /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Scale<T>(Span2D<T> multiplicand, T multiplier)
        where T : INumber<T>
    {
        if (multiplicand == null)
        {
            return new T[,] { { multiplier } };
        }

        if (multiplier == null)
        {
            return multiplicand.ToArray();
        }

        var rowsMultiplicand = multiplicand.Height;
        var columnsMultiplicand = multiplicand.Width;

        var product = new T[rowsMultiplicand, columnsMultiplicand];

        for (var i = 0; i < rowsMultiplicand; i++)
        {
            for (var j = 0; j < columnsMultiplicand; j++)
            {
                product[i, j] = multiplicand[i, j] * multiplier;
            }
        }

        return product;
    }

    /// <summary>
    /// Multiplies the specified multiplicand by a scalar.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <param name="rows"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Scale<T>(Span2D<T> multiplicand, T multiplier, int rows, int columns)
        where T : INumber<T>
    {
        if (multiplicand == null)
        {
            return new T[,] { { multiplier } };
        }

        if (multiplier == null)
        {
            return multiplicand.ToArray();
        }

        var rowsMultiplicand = multiplicand.Height;
        var columnsMultiplicand = multiplicand.Width;

        if (rows > rowsMultiplicand || columns > columnsMultiplicand)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(multiplier)}");
        }

        var product = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                product[i, j] = multiplicand[i, j] * multiplier;
            }
        }

        return product;
    }

    /// <summary>
    /// Multiplies the specified multiplicand by a scalar.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <param name="accuracy"></param>
    /// <returns></returns>
    /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Scale<T>(Span2D<T> multiplicand, T multiplier, int accuracy)
        where T : IFloatingPoint<T>
    {
        if (multiplicand == null)
        {
            return new T[,] { { multiplier } };
        }

        if (multiplier == null)
        {
            return multiplicand.ToArray();
        }

        var rowsMultiplicand = multiplicand.Height;
        var columnsMultiplicand = multiplicand.Width;

        var product = new T[rowsMultiplicand, columnsMultiplicand];

        for (var i = 0; i < rowsMultiplicand; i++)
        {
            for (var j = 0; j < columnsMultiplicand; j++)
            {
                product[i, j] = multiplicand[i, j] * multiplier;
            }
        }

        return Round<T, T>(product, accuracy);
    }

    /// <summary>
    /// Multiplies the specified multiplicand by a scalar.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <param name="rows"></param>
    /// <param name="columns"></param>
    /// <param name="accuracy"></param>
    /// <returns></returns>
    /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Scale<T>(Span2D<T> multiplicand, T multiplier, int rows, int columns, int accuracy)
        where T : IFloatingPoint<T>
    {
        if (multiplicand == null)
        {
            return new T[,] { { multiplier } };
        }

        if (multiplier == null)
        {
            return multiplicand.ToArray();
        }

        var rowsMultiplicand = multiplicand.Height;
        var columnsMultiplicand = multiplicand.Width;

        if (rows > rowsMultiplicand || columns > columnsMultiplicand)
        {
            throw new ArgumentException($"{nameof(rows)} and {nameof(columns)} must not be larger than the size of {nameof(multiplier)}");
        }

        var product = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                product[i, j] = multiplicand[i, j] * multiplier;
            }
        }

        return Round<T, T>(product, rows, columns, accuracy);
    }

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicandM1x1"></param>
    /// <param name="multiplicandM1x2"></param>
    /// <param name="multiplicandM2x1"></param>
    /// <param name="multiplicandM2x2"></param>
    /// <param name="multiplier"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2
        )
        ScaleMatrixRight<T>(
        T multiplicandM1x1, T multiplicandM1x2,
        T multiplicandM2x1, T multiplicandM2x2,
        T multiplier)
        where T : INumber<T>
        => (multiplicandM1x1 * multiplier, multiplicandM1x2 * multiplier,
            multiplicandM2x1 * multiplier, multiplicandM2x2 * multiplier);

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicandM1x1"></param>
    /// <param name="multiplicandM1x2"></param>
    /// <param name="multiplicandM2x1"></param>
    /// <param name="multiplicandM2x2"></param>
    /// <param name="multiplicandM3x1"></param>
    /// <param name="multiplicandM3x2"></param>
    /// <param name="multiplier"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2,
        T m3x1, T m3x2
        )
        ScaleMatrixRight<T>(
        T multiplicandM1x1, T multiplicandM1x2,
        T multiplicandM2x1, T multiplicandM2x2,
        T multiplicandM3x1, T multiplicandM3x2,
        T multiplier)
        where T : INumber<T>
        => (multiplicandM1x1 * multiplier, multiplicandM1x2 * multiplier,
            multiplicandM2x1 * multiplier, multiplicandM2x2 * multiplier,
            multiplicandM3x1 * multiplier, multiplicandM3x2 * multiplier);

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicandM1x1"></param>
    /// <param name="multiplicandM1x2"></param>
    /// <param name="multiplicandM1x3"></param>
    /// <param name="multiplicandM2x1"></param>
    /// <param name="multiplicandM2x2"></param>
    /// <param name="multiplicandM2x3"></param>
    /// <param name="multiplicandM3x1"></param>
    /// <param name="multiplicandM3x2"></param>
    /// <param name="multiplicandM3x3"></param>
    /// <param name="multiplier"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3
        )
        ScaleMatrixRight<T>(
        T multiplicandM1x1, T multiplicandM1x2, T multiplicandM1x3,
        T multiplicandM2x1, T multiplicandM2x2, T multiplicandM2x3,
        T multiplicandM3x1, T multiplicandM3x2, T multiplicandM3x3,
        T multiplier)
        where T : INumber<T>
        => (multiplicandM1x1 * multiplier, multiplicandM1x2 * multiplier, multiplicandM1x3 * multiplier,
            multiplicandM2x1 * multiplier, multiplicandM2x2 * multiplier, multiplicandM2x3 * multiplier,
            multiplicandM3x1 * multiplier, multiplicandM3x2 * multiplier, multiplicandM3x3 * multiplier);

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicandM1x1"></param>
    /// <param name="multiplicandM1x2"></param>
    /// <param name="multiplicandM1x3"></param>
    /// <param name="multiplicandM1x4"></param>
    /// <param name="multiplicandM2x1"></param>
    /// <param name="multiplicandM2x2"></param>
    /// <param name="multiplicandM2x3"></param>
    /// <param name="multiplicandM2x4"></param>
    /// <param name="multiplicandM3x1"></param>
    /// <param name="multiplicandM3x2"></param>
    /// <param name="multiplicandM3x3"></param>
    /// <param name="multiplicandM3x4"></param>
    /// <param name="multiplicandM4x1"></param>
    /// <param name="multiplicandM4x2"></param>
    /// <param name="multiplicandM4x3"></param>
    /// <param name="multiplicandM4x4"></param>
    /// <param name="multiplier"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4
        )
        ScaleMatrixRight<T>(
        T multiplicandM1x1, T multiplicandM1x2, T multiplicandM1x3, T multiplicandM1x4,
        T multiplicandM2x1, T multiplicandM2x2, T multiplicandM2x3, T multiplicandM2x4,
        T multiplicandM3x1, T multiplicandM3x2, T multiplicandM3x3, T multiplicandM3x4,
        T multiplicandM4x1, T multiplicandM4x2, T multiplicandM4x3, T multiplicandM4x4,
        T multiplier)
        where T : INumber<T>
        => (multiplicandM1x1 * multiplier, multiplicandM1x2 * multiplier, multiplicandM1x3 * multiplier, multiplicandM1x4 * multiplier,
            multiplicandM2x1 * multiplier, multiplicandM2x2 * multiplier, multiplicandM2x3 * multiplier, multiplicandM2x4 * multiplier,
            multiplicandM3x1 * multiplier, multiplicandM3x2 * multiplier, multiplicandM3x3 * multiplier, multiplicandM3x4 * multiplier,
            multiplicandM4x1 * multiplier, multiplicandM4x2 * multiplier, multiplicandM4x3 * multiplier, multiplicandM4x4 * multiplier);

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicandM1x1"></param>
    /// <param name="multiplicandM1x2"></param>
    /// <param name="multiplicandM1x3"></param>
    /// <param name="multiplicandM1x4"></param>
    /// <param name="multiplicandM1x5"></param>
    /// <param name="multiplicandM2x1"></param>
    /// <param name="multiplicandM2x2"></param>
    /// <param name="multiplicandM2x3"></param>
    /// <param name="multiplicandM2x4"></param>
    /// <param name="multiplicandM2x5"></param>
    /// <param name="multiplicandM3x1"></param>
    /// <param name="multiplicandM3x2"></param>
    /// <param name="multiplicandM3x3"></param>
    /// <param name="multiplicandM3x4"></param>
    /// <param name="multiplicandM3x5"></param>
    /// <param name="multiplicandM4x1"></param>
    /// <param name="multiplicandM4x2"></param>
    /// <param name="multiplicandM4x3"></param>
    /// <param name="multiplicandM4x4"></param>
    /// <param name="multiplicandM4x5"></param>
    /// <param name="multiplicandM5x1"></param>
    /// <param name="multiplicandM5x2"></param>
    /// <param name="multiplicandM5x3"></param>
    /// <param name="multiplicandM5x4"></param>
    /// <param name="multiplicandM5x5"></param>
    /// <param name="multiplier"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5
        )
        ScaleMatrixRight<T>(
        T multiplicandM1x1, T multiplicandM1x2, T multiplicandM1x3, T multiplicandM1x4, T multiplicandM1x5,
        T multiplicandM2x1, T multiplicandM2x2, T multiplicandM2x3, T multiplicandM2x4, T multiplicandM2x5,
        T multiplicandM3x1, T multiplicandM3x2, T multiplicandM3x3, T multiplicandM3x4, T multiplicandM3x5,
        T multiplicandM4x1, T multiplicandM4x2, T multiplicandM4x3, T multiplicandM4x4, T multiplicandM4x5,
        T multiplicandM5x1, T multiplicandM5x2, T multiplicandM5x3, T multiplicandM5x4, T multiplicandM5x5,
        T multiplier)
        where T : INumber<T>
        => (multiplicandM1x1 * multiplier, multiplicandM1x2 * multiplier, multiplicandM1x3 * multiplier, multiplicandM1x4 * multiplier, multiplicandM1x5 * multiplier,
            multiplicandM2x1 * multiplier, multiplicandM2x2 * multiplier, multiplicandM2x3 * multiplier, multiplicandM2x4 * multiplier, multiplicandM2x5 * multiplier,
            multiplicandM3x1 * multiplier, multiplicandM3x2 * multiplier, multiplicandM3x3 * multiplier, multiplicandM3x4 * multiplier, multiplicandM3x5 * multiplier,
            multiplicandM4x1 * multiplier, multiplicandM4x2 * multiplier, multiplicandM4x3 * multiplier, multiplicandM4x4 * multiplier, multiplicandM4x5 * multiplier,
            multiplicandM5x1 * multiplier, multiplicandM5x2 * multiplier, multiplicandM5x3 * multiplier, multiplicandM5x4 * multiplier, multiplicandM5x5 * multiplier);

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicandM1x1"></param>
    /// <param name="multiplicandM1x2"></param>
    /// <param name="multiplicandM2x1"></param>
    /// <param name="multiplicandM2x2"></param>
    /// <param name="multiplierM1x1"></param>
    /// <param name="multiplierM1x2"></param>
    /// <param name="multiplierM2x1"></param>
    /// <param name="multiplierM2x2"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2
        )
        ScaleMatrix<T>(
        T multiplicandM1x1, T multiplicandM1x2,
        T multiplicandM2x1, T multiplicandM2x2,
        T multiplierM1x1, T multiplierM1x2,
        T multiplierM2x1, T multiplierM2x2)
        where T : INumber<T>
        => (multiplicandM1x1 * multiplierM1x1, multiplicandM1x2 * multiplierM1x2,
            multiplicandM2x1 * multiplierM2x1, multiplicandM2x2 * multiplierM2x2);

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicandM1x1"></param>
    /// <param name="multiplicandM1x2"></param>
    /// <param name="multiplicandM1x3"></param>
    /// <param name="multiplicandM2x1"></param>
    /// <param name="multiplicandM2x2"></param>
    /// <param name="multiplicandM2x3"></param>
    /// <param name="multiplicandM3x1"></param>
    /// <param name="multiplicandM3x2"></param>
    /// <param name="multiplicandM3x3"></param>
    /// <param name="multiplierM1x1"></param>
    /// <param name="multiplierM1x2"></param>
    /// <param name="multiplierM1x3"></param>
    /// <param name="multiplierM2x1"></param>
    /// <param name="multiplierM2x2"></param>
    /// <param name="multiplierM2x3"></param>
    /// <param name="multiplierM3x1"></param>
    /// <param name="multiplierM3x2"></param>
    /// <param name="multiplierM3x3"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3
        )
        ScaleMatrix<T>(
        T multiplicandM1x1, T multiplicandM1x2, T multiplicandM1x3,
        T multiplicandM2x1, T multiplicandM2x2, T multiplicandM2x3,
        T multiplicandM3x1, T multiplicandM3x2, T multiplicandM3x3,
        T multiplierM1x1, T multiplierM1x2, T multiplierM1x3,
        T multiplierM2x1, T multiplierM2x2, T multiplierM2x3,
        T multiplierM3x1, T multiplierM3x2, T multiplierM3x3)
        where T : INumber<T>
        => (multiplicandM1x1 * multiplierM1x1, multiplicandM1x2 * multiplierM1x2, multiplicandM1x3 * multiplierM1x3,
            multiplicandM2x1 * multiplierM2x1, multiplicandM2x2 * multiplierM2x2, multiplicandM2x3 * multiplierM2x3,
            multiplicandM3x1 * multiplierM3x1, multiplicandM3x2 * multiplierM3x2, multiplicandM3x3 * multiplierM3x3);

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicandM1x1"></param>
    /// <param name="multiplicandM1x2"></param>
    /// <param name="multiplicandM1x3"></param>
    /// <param name="multiplicandM1x4"></param>
    /// <param name="multiplicandM2x1"></param>
    /// <param name="multiplicandM2x2"></param>
    /// <param name="multiplicandM2x3"></param>
    /// <param name="multiplicandM2x4"></param>
    /// <param name="multiplicandM3x1"></param>
    /// <param name="multiplicandM3x2"></param>
    /// <param name="multiplicandM3x3"></param>
    /// <param name="multiplicandM3x4"></param>
    /// <param name="multiplicandM4x1"></param>
    /// <param name="multiplicandM4x2"></param>
    /// <param name="multiplicandM4x3"></param>
    /// <param name="multiplicandM4x4"></param>
    /// <param name="multiplierM1x1"></param>
    /// <param name="multiplierM1x2"></param>
    /// <param name="multiplierM1x3"></param>
    /// <param name="multiplierM1x4"></param>
    /// <param name="multiplierM2x1"></param>
    /// <param name="multiplierM2x2"></param>
    /// <param name="multiplierM2x3"></param>
    /// <param name="multiplierM2x4"></param>
    /// <param name="multiplierM3x1"></param>
    /// <param name="multiplierM3x2"></param>
    /// <param name="multiplierM3x3"></param>
    /// <param name="multiplierM3x4"></param>
    /// <param name="multiplierM4x1"></param>
    /// <param name="multiplierM4x2"></param>
    /// <param name="multiplierM4x3"></param>
    /// <param name="multiplierM4x4"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4
        )
        ScaleMatrix<T>(
        T multiplicandM1x1, T multiplicandM1x2, T multiplicandM1x3, T multiplicandM1x4,
        T multiplicandM2x1, T multiplicandM2x2, T multiplicandM2x3, T multiplicandM2x4,
        T multiplicandM3x1, T multiplicandM3x2, T multiplicandM3x3, T multiplicandM3x4,
        T multiplicandM4x1, T multiplicandM4x2, T multiplicandM4x3, T multiplicandM4x4,
        T multiplierM1x1, T multiplierM1x2, T multiplierM1x3, T multiplierM1x4,
        T multiplierM2x1, T multiplierM2x2, T multiplierM2x3, T multiplierM2x4,
        T multiplierM3x1, T multiplierM3x2, T multiplierM3x3, T multiplierM3x4,
        T multiplierM4x1, T multiplierM4x2, T multiplierM4x3, T multiplierM4x4)
        where T : INumber<T>
        => (multiplicandM1x1 * multiplierM1x1, multiplicandM1x2 * multiplierM1x2, multiplicandM1x3 * multiplierM1x3, multiplicandM1x4 * multiplierM1x4,
            multiplicandM2x1 * multiplierM2x1, multiplicandM2x2 * multiplierM2x2, multiplicandM2x3 * multiplierM2x3, multiplicandM2x4 * multiplierM2x4,
            multiplicandM3x1 * multiplierM3x1, multiplicandM3x2 * multiplierM3x2, multiplicandM3x3 * multiplierM3x3, multiplicandM3x4 * multiplierM3x4,
            multiplicandM4x1 * multiplierM4x1, multiplicandM4x2 * multiplierM4x2, multiplicandM4x3 * multiplierM4x3, multiplicandM4x4 * multiplierM4x4);

    /// <summary>
    /// Used to scale two matrices.
    /// </summary>
    /// <param name="multiplicandM1x1"></param>
    /// <param name="multiplicandM1x2"></param>
    /// <param name="multiplicandM1x3"></param>
    /// <param name="multiplicandM1x4"></param>
    /// <param name="multiplicandM1x5"></param>
    /// <param name="multiplicandM2x1"></param>
    /// <param name="multiplicandM2x2"></param>
    /// <param name="multiplicandM2x3"></param>
    /// <param name="multiplicandM2x4"></param>
    /// <param name="multiplicandM2x5"></param>
    /// <param name="multiplicandM3x1"></param>
    /// <param name="multiplicandM3x2"></param>
    /// <param name="multiplicandM3x3"></param>
    /// <param name="multiplicandM3x4"></param>
    /// <param name="multiplicandM3x5"></param>
    /// <param name="multiplicandM4x1"></param>
    /// <param name="multiplicandM4x2"></param>
    /// <param name="multiplicandM4x3"></param>
    /// <param name="multiplicandM4x4"></param>
    /// <param name="multiplicandM4x5"></param>
    /// <param name="multiplicandM5x1"></param>
    /// <param name="multiplicandM5x2"></param>
    /// <param name="multiplicandM5x3"></param>
    /// <param name="multiplicandM5x4"></param>
    /// <param name="multiplicandM5x5"></param>
    /// <param name="multiplierM1x1"></param>
    /// <param name="multiplierM1x2"></param>
    /// <param name="multiplierM1x3"></param>
    /// <param name="multiplierM1x4"></param>
    /// <param name="multiplierM1x5"></param>
    /// <param name="multiplierM2x1"></param>
    /// <param name="multiplierM2x2"></param>
    /// <param name="multiplierM2x3"></param>
    /// <param name="multiplierM2x4"></param>
    /// <param name="multiplierM2x5"></param>
    /// <param name="multiplierM3x1"></param>
    /// <param name="multiplierM3x2"></param>
    /// <param name="multiplierM3x3"></param>
    /// <param name="multiplierM3x4"></param>
    /// <param name="multiplierM3x5"></param>
    /// <param name="multiplierM4x1"></param>
    /// <param name="multiplierM4x2"></param>
    /// <param name="multiplierM4x3"></param>
    /// <param name="multiplierM4x4"></param>
    /// <param name="multiplierM4x5"></param>
    /// <param name="multiplierM5x1"></param>
    /// <param name="multiplierM5x2"></param>
    /// <param name="multiplierM5x3"></param>
    /// <param name="multiplierM5x4"></param>
    /// <param name="multiplierM5x5"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5
        )
        ScaleMatrix<T>(
        T multiplicandM1x1, T multiplicandM1x2, T multiplicandM1x3, T multiplicandM1x4, T multiplicandM1x5,
        T multiplicandM2x1, T multiplicandM2x2, T multiplicandM2x3, T multiplicandM2x4, T multiplicandM2x5,
        T multiplicandM3x1, T multiplicandM3x2, T multiplicandM3x3, T multiplicandM3x4, T multiplicandM3x5,
        T multiplicandM4x1, T multiplicandM4x2, T multiplicandM4x3, T multiplicandM4x4, T multiplicandM4x5,
        T multiplicandM5x1, T multiplicandM5x2, T multiplicandM5x3, T multiplicandM5x4, T multiplicandM5x5,
        T multiplierM1x1, T multiplierM1x2, T multiplierM1x3, T multiplierM1x4, T multiplierM1x5,
        T multiplierM2x1, T multiplierM2x2, T multiplierM2x3, T multiplierM2x4, T multiplierM2x5,
        T multiplierM3x1, T multiplierM3x2, T multiplierM3x3, T multiplierM3x4, T multiplierM3x5,
        T multiplierM4x1, T multiplierM4x2, T multiplierM4x3, T multiplierM4x4, T multiplierM4x5,
        T multiplierM5x1, T multiplierM5x2, T multiplierM5x3, T multiplierM5x4, T multiplierM5x5)
        where T : INumber<T>
        => (multiplicandM1x1 * multiplierM1x1, multiplicandM1x2 * multiplierM1x2, multiplicandM1x3 * multiplierM1x3, multiplicandM1x4 * multiplierM1x4, multiplicandM1x5 * multiplierM1x5,
            multiplicandM2x1 * multiplierM2x1, multiplicandM2x2 * multiplierM2x2, multiplicandM2x3 * multiplierM2x3, multiplicandM2x4 * multiplierM2x4, multiplicandM2x5 * multiplierM2x5,
            multiplicandM3x1 * multiplierM3x1, multiplicandM3x2 * multiplierM3x2, multiplicandM3x3 * multiplierM3x3, multiplicandM3x4 * multiplierM3x4, multiplicandM3x5 * multiplierM3x5,
            multiplicandM4x1 * multiplierM4x1, multiplicandM4x2 * multiplierM4x2, multiplicandM4x3 * multiplierM4x3, multiplicandM4x4 * multiplierM4x4, multiplicandM4x5 * multiplierM4x5,
            multiplicandM5x1 * multiplierM5x1, multiplicandM5x2 * multiplierM5x2, multiplicandM5x3 * multiplierM5x3, multiplicandM5x4 * multiplierM5x4, multiplicandM5x5 * multiplierM5x5);
    #endregion Scale

    #region Matrix Vector Multiplication
    /// <summary>
    /// Multiplies the specified multiplicand.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="columnMultiplier">The multiplier.</param>
    /// <returns></returns>
    /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Multiply<T>(Span2D<T> multiplicand, Span<T> columnMultiplier)
        where T : INumber<T>
    {
        if (multiplicand == null)
        {
            throw new ArgumentNullException(nameof(multiplicand));
        }

        if (columnMultiplier == null)
        {
            throw new ArgumentNullException(nameof(columnMultiplier));
        }

        var rowsMultiplicand = multiplicand.Height;
        var columnsMultiplicand = multiplicand.Width;
        var lengthMultiplier = columnMultiplier.Length;

        if (columnsMultiplicand != lengthMultiplier)
        {
            throw new ArgumentException($"Columns of {nameof(multiplicand)} must be the same length as the rows of {nameof(columnMultiplier)}.");
        }

        var product = new T[rowsMultiplicand];

        for (var i = 0; i < rowsMultiplicand; i++)
        {
            var dotProduct = T.Zero;

            for (var k = 0; k < columnsMultiplicand; k++)
            {
                dotProduct += multiplicand[i, k] * columnMultiplier[k];
            }

            product[i] = dotProduct;
        }

        return product;
    }

    /// <summary>
    /// Matrix vs Vector Multiplication, internal usage.
    /// </summary>
    /// <param name="multiplicand">The matrix.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="columnMultiplier">The vector.</param>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Multiply<T>(Span2D<T> multiplicand, int rows, int columns, Span<T> columnMultiplier, int length)
        where T : INumber<T>
    {
        if (multiplicand == null)
        {
            return columnMultiplier.ToArray();
        }

        if (columnMultiplier == null)
        {
            throw new ArgumentNullException(nameof(columnMultiplier));
        }

        var rowsMultiplicand = multiplicand.Height;
        var columnsMultiplicand = multiplicand.Width;
        var lengthMultiplier = multiplicand.Width;

        if (rows > rowsMultiplicand || columns > columnsMultiplicand || length > lengthMultiplier)
        {
            throw new ArgumentException($"{nameof(rows)}, {nameof(columns)} and {nameof(length)} must not be larger than the size of {nameof(multiplicand)} and {nameof(columnMultiplier)}.");
        }

        var product = new T[rows];

        for (var i = 0; i < rows; i++)
        {
            var dotProduct = T.Zero;

            for (var k = 0; k < columns; k++)
            {
                dotProduct += multiplicand[i, k] * columnMultiplier[k];
            }

            product[i] = dotProduct;
        }

        return product;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiplicand1x1">The multiplicand M1X1.</param>
    /// <param name="multiplicand1x2">The multiplicand M1X2.</param>
    /// <param name="multiplicand2x1">The multiplicand M2X1.</param>
    /// <param name="multiplicand2x2">The multiplicand M2X2.</param>
    /// <param name="multiplierX">The multiplier M1X1.</param>
    /// <param name="multiplierY">The multiplier M1X2.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) MultiplyMatrixVector<T>(
        T multiplicand1x1, T multiplicand1x2,
        T multiplicand2x1, T multiplicand2x2,
        T multiplierX, T multiplierY)
        where T : INumber<T>
    {
        return (
            (multiplicand1x1 * multiplierX) + (multiplicand1x2 * multiplierY),
            (multiplicand2x1 * multiplierX) + (multiplicand2x2 * multiplierY)
               );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiplicand1x1">The multiplicand M1X1.</param>
    /// <param name="multiplicand1x2">The multiplicand M1X2.</param>
    /// <param name="multiplicand2x1">The multiplicand M2X1.</param>
    /// <param name="multiplicand2x2">The multiplicand M2X2.</param>
    /// <param name="multiplicand3x1">The multiplicand M3X1.</param>
    /// <param name="multiplicand3x2">The multiplicand M3X2.</param>
    /// <param name="multiplierX">The multiplier M1X1.</param>
    /// <param name="multiplierY">The multiplier M1X2.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) MultiplyMatrixVector<T>(
        T multiplicand1x1, T multiplicand1x2,
        T multiplicand2x1, T multiplicand2x2,
        T multiplicand3x1, T multiplicand3x2,
        T multiplierX, T multiplierY)
        where T : INumber<T>
    {
        return (
            (multiplicand1x1 * multiplierX) + (multiplicand1x2 * multiplierY),
            (multiplicand2x1 * multiplierX) + (multiplicand2x2 * multiplierY),
            (multiplicand3x1 * multiplierX) + (multiplicand3x2 * multiplierY)
               );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiplicand1x1">The multiplicand M1X1.</param>
    /// <param name="multiplicand1x2">The multiplicand M1X2.</param>
    /// <param name="multiplicand1x3">The multiplicand M1X3.</param>
    /// <param name="multiplicand2x1">The multiplicand M2X1.</param>
    /// <param name="multiplicand2x2">The multiplicand M2X2.</param>
    /// <param name="multiplicand2x3">The multiplicand M2X3.</param>
    /// <param name="multiplicand3x1">The multiplicand M3X1.</param>
    /// <param name="multiplicand3x2">The multiplicand M3X2.</param>
    /// <param name="multiplicand3x3">The multiplicand M3X3.</param>
    /// <param name="multiplierX">The multiplier M1X1.</param>
    /// <param name="multiplierY">The multiplier M1X2.</param>
    /// <param name="multiplierZ">The multiplier M1X3.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) MultiplyMatrixVector<T>(
        T multiplicand1x1, T multiplicand1x2, T multiplicand1x3,
        T multiplicand2x1, T multiplicand2x2, T multiplicand2x3,
        T multiplicand3x1, T multiplicand3x2, T multiplicand3x3,
        T multiplierX, T multiplierY, T multiplierZ)
        where T : INumber<T>
    {
        return (
            (multiplicand1x1 * multiplierX) + (multiplicand1x2 * multiplierY) + (multiplicand1x3 * multiplierZ),
            (multiplicand2x1 * multiplierX) + (multiplicand2x2 * multiplierY) + (multiplicand2x3 * multiplierZ),
            (multiplicand3x1 * multiplierX) + (multiplicand3x2 * multiplierY) + (multiplicand3x3 * multiplierZ)
               );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiplicand1x1">The multiplicand M1X1.</param>
    /// <param name="multiplicand1x2">The multiplicand M1X2.</param>
    /// <param name="multiplicand1x3">The multiplicand M1X3.</param>
    /// <param name="multiplicand1x4">The multiplicand M1X4.</param>
    /// <param name="multiplicand2x1">The multiplicand M2X1.</param>
    /// <param name="multiplicand2x2">The multiplicand M2X2.</param>
    /// <param name="multiplicand2x3">The multiplicand M2X3.</param>
    /// <param name="multiplicand2x4">The multiplicand M2X4.</param>
    /// <param name="multiplicand3x1">The multiplicand M3X1.</param>
    /// <param name="multiplicand3x2">The multiplicand M3X2.</param>
    /// <param name="multiplicand3x3">The multiplicand M3X3.</param>
    /// <param name="multiplicand3x4">The multiplicand M3X4.</param>
    /// <param name="multiplicand4x1">The multiplicand M4X1.</param>
    /// <param name="multiplicand4x2">The multiplicand M4X2.</param>
    /// <param name="multiplicand4x3">The multiplicand M4X3.</param>
    /// <param name="multiplicand4x4">The multiplicand M4X4.</param>
    /// <param name="multiplierX">The multiplier M1X1.</param>
    /// <param name="multiplierY">The multiplier M1X2.</param>
    /// <param name="multiplierZ">The multiplier M1X3.</param>
    /// <param name="multiplierW">The multiplier M1X4.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) MultiplyMatrixVector<T>(
        T multiplicand1x1, T multiplicand1x2, T multiplicand1x3, T multiplicand1x4,
        T multiplicand2x1, T multiplicand2x2, T multiplicand2x3, T multiplicand2x4,
        T multiplicand3x1, T multiplicand3x2, T multiplicand3x3, T multiplicand3x4,
        T multiplicand4x1, T multiplicand4x2, T multiplicand4x3, T multiplicand4x4,
        T multiplierX, T multiplierY, T multiplierZ, T multiplierW)
        where T : INumber<T>
    {
        return (
            (multiplicand1x1 * multiplierX) + (multiplicand1x2 * multiplierY) + (multiplicand1x3 * multiplierZ) + (multiplicand1x4 * multiplierW),
            (multiplicand2x1 * multiplierX) + (multiplicand2x2 * multiplierY) + (multiplicand2x3 * multiplierZ) + (multiplicand2x4 * multiplierW),
            (multiplicand3x1 * multiplierX) + (multiplicand3x2 * multiplierY) + (multiplicand3x3 * multiplierZ) + (multiplicand3x4 * multiplierW),
            (multiplicand4x1 * multiplierX) + (multiplicand4x2 * multiplierY) + (multiplicand4x3 * multiplierZ) + (multiplicand4x4 * multiplierW)
               );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiplicand1x1">The multiplicand M1X1.</param>
    /// <param name="multiplicand1x2">The multiplicand M1X2.</param>
    /// <param name="multiplicand1x3">The multiplicand M1X3.</param>
    /// <param name="multiplicand1x4">The multiplicand M1X4.</param>
    /// <param name="multiplicand1x5">The multiplicand M1X5.</param>
    /// <param name="multiplicand2x1">The multiplicand M2X1.</param>
    /// <param name="multiplicand2x2">The multiplicand M2X2.</param>
    /// <param name="multiplicand2x3">The multiplicand M2X3.</param>
    /// <param name="multiplicand2x4">The multiplicand M2X4.</param>
    /// <param name="multiplicand2x5">The multiplicand M2X5.</param>
    /// <param name="multiplicand3x1">The multiplicand M3X1.</param>
    /// <param name="multiplicand3x2">The multiplicand M3X2.</param>
    /// <param name="multiplicand3x3">The multiplicand M3X3.</param>
    /// <param name="multiplicand3x4">The multiplicand M3X4.</param>
    /// <param name="multiplicand3x5">The multiplicand M3X5.</param>
    /// <param name="multiplicand4x1">The multiplicand M4X1.</param>
    /// <param name="multiplicand4x2">The multiplicand M4X2.</param>
    /// <param name="multiplicand4x3">The multiplicand M4X3.</param>
    /// <param name="multiplicand4x4">The multiplicand M4X4.</param>
    /// <param name="multiplicand4x5">The multiplicand M4X5.</param>
    /// <param name="multiplicand5x1">The multiplicand M5X1.</param>
    /// <param name="multiplicand5x2">The multiplicand M5X2.</param>
    /// <param name="multiplicand5x3">The multiplicand M5X3.</param>
    /// <param name="multiplicand5x4">The multiplicand M5X4.</param>
    /// <param name="multiplicand5x5">The multiplicand M5X5.</param>
    /// <param name="multiplierX">The multiplier M1X1.</param>
    /// <param name="multiplierY">The multiplier M2X1.</param>
    /// <param name="multiplierZ">The multiplier M3X1.</param>
    /// <param name="multiplierW">The multiplier M4X1.</param>
    /// <param name="multiplierV">The multiplier M5X1.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) MultiplyMatrixVector<T>(
        T multiplicand1x1, T multiplicand1x2, T multiplicand1x3, T multiplicand1x4, T multiplicand1x5,
        T multiplicand2x1, T multiplicand2x2, T multiplicand2x3, T multiplicand2x4, T multiplicand2x5,
        T multiplicand3x1, T multiplicand3x2, T multiplicand3x3, T multiplicand3x4, T multiplicand3x5,
        T multiplicand4x1, T multiplicand4x2, T multiplicand4x3, T multiplicand4x4, T multiplicand4x5,
        T multiplicand5x1, T multiplicand5x2, T multiplicand5x3, T multiplicand5x4, T multiplicand5x5,
        T multiplierX, T multiplierY, T multiplierZ, T multiplierW, T multiplierV)
        where T : INumber<T>
    {
        return (
            (multiplicand1x1 * multiplierX) + (multiplicand1x2 * multiplierY) + (multiplicand1x3 * multiplierZ) + (multiplicand1x4 * multiplierW) + (multiplicand1x5 * multiplierV),
            (multiplicand2x1 * multiplierX) + (multiplicand2x2 * multiplierY) + (multiplicand2x3 * multiplierZ) + (multiplicand2x4 * multiplierW) + (multiplicand2x5 * multiplierV),
            (multiplicand3x1 * multiplierX) + (multiplicand3x2 * multiplierY) + (multiplicand3x3 * multiplierZ) + (multiplicand3x4 * multiplierW) + (multiplicand3x5 * multiplierV),
            (multiplicand4x1 * multiplierX) + (multiplicand4x2 * multiplierY) + (multiplicand4x3 * multiplierZ) + (multiplicand4x4 * multiplierW) + (multiplicand4x5 * multiplierV),
            (multiplicand5x1 * multiplierX) + (multiplicand5x2 * multiplierY) + (multiplicand5x3 * multiplierZ) + (multiplicand5x4 * multiplierW) + (multiplicand5x5 * multiplierV)
               );
    }

    /// <summary>
    /// Multiplies the specified multiplicand.
    /// </summary>
    /// <param name="columnMultiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns></returns>
    /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] Multiply<T>(Span<T> columnMultiplicand, Span2D<T> multiplier)
        where T : INumber<T>
    {
        if (columnMultiplicand == null)
        {
            throw new ArgumentNullException(nameof(columnMultiplicand));
        }

        if (multiplier == null)
        {
            return columnMultiplicand.ToArray();
        }

        var lengthMultiplicand = columnMultiplicand.Length;
        var rowsMultiplier = multiplier.Height;
        var ColumnsMultiplier = multiplier.Width;

        if (lengthMultiplicand != rowsMultiplier)
        {
            throw new ArgumentException("Columns of multiplicand must be the same length as the rows of multiplier.");
        }

        var product = new T[lengthMultiplicand];

        for (var j = 0; j < ColumnsMultiplier; j++)
        {
            var dotProduct = T.Zero;

            for (var k = 0; k < lengthMultiplicand; k++)
            {
                dotProduct += columnMultiplicand[j] * multiplier[k, j];
            }

            product[j] = dotProduct;
        }

        return product;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiplicandX">The multiplicand M1X1.</param>
    /// <param name="multiplicandY">The multiplicand M1X2.</param>
    /// <param name="multiplier1x1">The multiplier M1X1.</param>
    /// <param name="multiplier1x2">The multiplier M1X2.</param>
    /// <param name="multiplier2x1">The multiplier M2X1.</param>
    /// <param name="multiplier2x2">The multiplier M2X2.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) MultiplyVectorMatrix<T>(
        T multiplicandX, T multiplicandY,
        T multiplier1x1, T multiplier1x2,
        T multiplier2x1, T multiplier2x2)
        where T : INumber<T>
    {
        return (
            (multiplicandX * multiplier1x1) + (multiplicandY * multiplier2x1),
            (multiplicandX * multiplier1x2) + (multiplicandY * multiplier2x2)
               );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiplicandX">The multiplicand M1X1.</param>
    /// <param name="multiplicandY">The multiplicand M1X2.</param>
    /// <param name="multiplicandZ">The multiplicand M1X3.</param>
    /// <param name="multiplier1x1">The multiplier M1X1.</param>
    /// <param name="multiplier1x2">The multiplier M1X2.</param>
    /// <param name="multiplier2x1">The multiplier M2X1.</param>
    /// <param name="multiplier2x2">The multiplier M2X2.</param>
    /// <param name="multiplier3x1">The multiplier M3X1.</param>
    /// <param name="multiplier3x2">The multiplier M3X2.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) MultiplyVectorMatrix<T>(
        T multiplicandX, T multiplicandY, T multiplicandZ,
        T multiplier1x1, T multiplier1x2,
        T multiplier2x1, T multiplier2x2,
        T multiplier3x1, T multiplier3x2)
        where T : INumber<T>
    {
        return (
            (multiplicandX * multiplier1x1) + (multiplicandY * multiplier2x1) + (multiplicandZ * multiplier3x1),
            (multiplicandX * multiplier1x2) + (multiplicandY * multiplier2x2) + (multiplicandZ * multiplier3x2)
               );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiplicandX">The multiplicand M1X1.</param>
    /// <param name="multiplicandY">The multiplicand M1X2.</param>
    /// <param name="multiplicandZ">The multiplicand M1X3.</param>
    /// <param name="multiplier1x1">The multiplier M1X1.</param>
    /// <param name="multiplier1x2">The multiplier M1X2.</param>
    /// <param name="multiplier1x3">The multiplier M1X3.</param>
    /// <param name="multiplier2x1">The multiplier M2X1.</param>
    /// <param name="multiplier2x2">The multiplier M2X2.</param>
    /// <param name="multiplier2x3">The multiplier M2X3.</param>
    /// <param name="multiplier3x1">The multiplier M3X1.</param>
    /// <param name="multiplier3x2">The multiplier M3X2.</param>
    /// <param name="multiplier3x3">The multiplier M3X3.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) MultiplyVectorMatrix<T>(
        T multiplicandX, T multiplicandY, T multiplicandZ,
        T multiplier1x1, T multiplier1x2, T multiplier1x3,
        T multiplier2x1, T multiplier2x2, T multiplier2x3,
        T multiplier3x1, T multiplier3x2, T multiplier3x3)
        where T : INumber<T>
    {
        return (
            (multiplicandX * multiplier1x1) + (multiplicandY * multiplier2x1) + (multiplicandZ * multiplier3x1),
            (multiplicandX * multiplier1x2) + (multiplicandY * multiplier2x2) + (multiplicandZ * multiplier3x2),
            (multiplicandX * multiplier1x3) + (multiplicandY * multiplier2x3) + (multiplicandZ * multiplier3x3)
               );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiplicandX">The multiplicand M1X1.</param>
    /// <param name="multiplicandY">The multiplicand M1X2.</param>
    /// <param name="multiplicandZ">The multiplicand M1X3.</param>
    /// <param name="multiplicandW">The multiplicand M1X4.</param>
    /// <param name="multiplier1x1">The multiplier M1X1.</param>
    /// <param name="multiplier1x2">The multiplier M1X2.</param>
    /// <param name="multiplier1x3">The multiplier M1X3.</param>
    /// <param name="multiplier1x4">The multiplier M1X4.</param>
    /// <param name="multiplier2x1">The multiplier M2X1.</param>
    /// <param name="multiplier2x2">The multiplier M2X2.</param>
    /// <param name="multiplier2x3">The multiplier M2X3.</param>
    /// <param name="multiplier2x4">The multiplier M2X4.</param>
    /// <param name="multiplier3x1">The multiplier M3X1.</param>
    /// <param name="multiplier3x2">The multiplier M3X2.</param>
    /// <param name="multiplier3x3">The multiplier M3X3.</param>
    /// <param name="multiplier3x4">The multiplier M3X4.</param>
    /// <param name="multiplier4x1">The multiplier M4X1.</param>
    /// <param name="multiplier4x2">The multiplier M4X2.</param>
    /// <param name="multiplier4x3">The multiplier M4X3.</param>
    /// <param name="multiplier4x4">The multiplier M4X4.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) MultiplyVectorMatrix<T>(
        T multiplicandX, T multiplicandY, T multiplicandZ, T multiplicandW,
        T multiplier1x1, T multiplier1x2, T multiplier1x3, T multiplier1x4,
        T multiplier2x1, T multiplier2x2, T multiplier2x3, T multiplier2x4,
        T multiplier3x1, T multiplier3x2, T multiplier3x3, T multiplier3x4,
        T multiplier4x1, T multiplier4x2, T multiplier4x3, T multiplier4x4)
        where T : INumber<T>
    {
        return (
            (multiplicandX * multiplier1x1) + (multiplicandY * multiplier2x1) + (multiplicandZ * multiplier3x1) + (multiplicandW * multiplier4x1),
            (multiplicandX * multiplier1x2) + (multiplicandY * multiplier2x2) + (multiplicandZ * multiplier3x2) + (multiplicandW * multiplier4x2),
            (multiplicandX * multiplier1x3) + (multiplicandY * multiplier2x3) + (multiplicandZ * multiplier3x3) + (multiplicandW * multiplier4x3),
            (multiplicandX * multiplier1x4) + (multiplicandY * multiplier2x4) + (multiplicandZ * multiplier3x4) + (multiplicandW * multiplier4x4)
               );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="multiplicandX">The multiplicand M1X1.</param>
    /// <param name="multiplicandY">The multiplicand M1X2.</param>
    /// <param name="multiplicandZ">The multiplicand M1X3.</param>
    /// <param name="multiplicandW">The multiplicand M1X4.</param>
    /// <param name="multiplicandV">The multiplicand M1X5.</param>
    /// <param name="multiplier1x1">The multiplier M1X1.</param>
    /// <param name="multiplier1x2">The multiplier M1X2.</param>
    /// <param name="multiplier1x3">The multiplier M1X3.</param>
    /// <param name="multiplier1x4">The multiplier M1X4.</param>
    /// <param name="multiplier1x5">The multiplier M1X5.</param>
    /// <param name="multiplier2x1">The multiplier M2X1.</param>
    /// <param name="multiplier2x2">The multiplier M2X2.</param>
    /// <param name="multiplier2x3">The multiplier M2X3.</param>
    /// <param name="multiplier2x4">The multiplier M2X4.</param>
    /// <param name="multiplier2x5">The multiplier M2X5.</param>
    /// <param name="multiplier3x1">The multiplier M3X1.</param>
    /// <param name="multiplier3x2">The multiplier M3X2.</param>
    /// <param name="multiplier3x3">The multiplier M3X3.</param>
    /// <param name="multiplier3x4">The multiplier M3X4.</param>
    /// <param name="multiplier3x5">The multiplier M3X5.</param>
    /// <param name="multiplier4x1">The multiplier M4X1.</param>
    /// <param name="multiplier4x2">The multiplier M4X2.</param>
    /// <param name="multiplier4x3">The multiplier M4X3.</param>
    /// <param name="multiplier4x4">The multiplier M4X4.</param>
    /// <param name="multiplier4x5">The multiplier M4X5.</param>
    /// <param name="multiplier5x1">The multiplier M5X1.</param>
    /// <param name="multiplier5x2">The multiplier M5X2.</param>
    /// <param name="multiplier5x3">The multiplier M5X3.</param>
    /// <param name="multiplier5x4">The multiplier M5X4.</param>
    /// <param name="multiplier5x5">The multiplier M5X5.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) MultiplyVectorMatrix<T>(
        T multiplicandX, T multiplicandY, T multiplicandZ, T multiplicandW, T multiplicandV,
        T multiplier1x1, T multiplier1x2, T multiplier1x3, T multiplier1x4, T multiplier1x5,
        T multiplier2x1, T multiplier2x2, T multiplier2x3, T multiplier2x4, T multiplier2x5,
        T multiplier3x1, T multiplier3x2, T multiplier3x3, T multiplier3x4, T multiplier3x5,
        T multiplier4x1, T multiplier4x2, T multiplier4x3, T multiplier4x4, T multiplier4x5,
        T multiplier5x1, T multiplier5x2, T multiplier5x3, T multiplier5x4, T multiplier5x5)
        where T : INumber<T>
    {
        return (
            (multiplicandX * multiplier1x1) + (multiplicandY * multiplier2x1) + (multiplicandZ * multiplier3x1) + (multiplicandW * multiplier4x1) + (multiplicandV * multiplier5x1),
            (multiplicandX * multiplier1x2) + (multiplicandY * multiplier2x2) + (multiplicandZ * multiplier3x2) + (multiplicandW * multiplier4x2) + (multiplicandV * multiplier5x2),
            (multiplicandX * multiplier1x3) + (multiplicandY * multiplier2x3) + (multiplicandZ * multiplier3x3) + (multiplicandW * multiplier4x3) + (multiplicandV * multiplier5x3),
            (multiplicandX * multiplier1x4) + (multiplicandY * multiplier2x4) + (multiplicandZ * multiplier3x4) + (multiplicandW * multiplier4x4) + (multiplicandV * multiplier5x4),
            (multiplicandX * multiplier1x5) + (multiplicandY * multiplier2x5) + (multiplicandZ * multiplier3x5) + (multiplicandW * multiplier4x5) + (multiplicandV * multiplier5x5)
               );
    }
    #endregion

    #region Matrix Multiplication
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="multiplicand"></param>
    /// <param name="multiplier"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] Multiply<T, TResult>(Span2D<T> multiplicand, Span2D<T> multiplier)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        if (multiplicand == null)
        {
            return multiplier.Cast<T, TResult>();
        }

        if (multiplier == null)
        {
            return multiplicand.Cast<T, TResult>();
        }

        var rowsMultiplicand = multiplicand.Height;
        var columnsMultiplicand = multiplicand.Width;
        var rowsMultiplier = multiplier.Height;
        var ColumnsMultiplier = multiplier.Width;

        if (columnsMultiplicand != rowsMultiplier)
        {
            throw new ArgumentException($"The {nameof(multiplicand)} Matrix must have the same number of rows as the {nameof(multiplier)} Matrix has columns.");
        }

        var product = new TResult[rowsMultiplicand, ColumnsMultiplier];

        for (int i = 0; i < rowsMultiplicand; i++)
        {
            for (int j = 0; j < ColumnsMultiplier; j++)
            {
                // Find the dot product of the multiplicand row and the multiplier column.
                var dotProduct = TResult.Zero;

                for (int k = 0; k < columnsMultiplicand; k++)
                {
                    dotProduct += TResult.Create(multiplicand[i, k] * multiplier[k, j]);
                }

                product[i, j] = dotProduct;
            }
        }

        return product;
    }

    /// <summary>
    /// Linear algebraic matrix multiplication, A * B
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="multiplier">The multiplier.</param>
    /// <returns></returns>
    /// <exception cref="Exception">Columns of multiplicand must be the same length as the rows of multiplier.</exception>
    /// <acknowledgment>
    /// https://www.codeproject.com/Articles/5835/DotNetMatrix-Simple-Matrix-Library-for-NET
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs
    /// https://www.tutorialspoint.com/chash-program-to-multiply-two-matrices
    /// https://www.geeksforgeeks.org/different-operation-matrices/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Multiply<T>(Span2D<T> multiplicand, Span2D<T> multiplier)
        where T : INumber<T>
    {
        if (multiplicand == null)
        {
            return multiplier.ToArray();
        }

        if (multiplier == null)
        {
            return multiplicand.ToArray();
        }

        var rowsMultiplicand = multiplicand.Height;
        var columnsMultiplicand = multiplicand.Width;
        var rowsMultiplier = multiplier.Height;
        var ColumnsMultiplier = multiplier.Width;

        if (columnsMultiplicand != rowsMultiplier)
        {
            throw new ArgumentException($"The {nameof(multiplicand)} Matrix must have the same number of rows as the {nameof(multiplier)} Matrix has columns.");
        }

        var product = new T[rowsMultiplicand, ColumnsMultiplier];

        for (var i = 0; i < rowsMultiplicand; i++)
        {
            for (var j = 0; j < ColumnsMultiplier; j++)
            {
                var dotProduct = T.Zero;

                for (var k = 0; k < columnsMultiplicand; k++)
                {
                    dotProduct += multiplicand[i, k] * multiplier[k, j];
                }

                product[i, j] = dotProduct;
            }
        }

        return product;
    }

    /// <summary>
    /// Multiply + Multiplication by scalar, accuracy needed.
    /// </summary>
    /// <param name="multiplicand">The matrix1.</param>
    /// <param name="multiplier">The matrix2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] MatrixMatrixScalarMultiplication<T>(Span2D<T> multiplicand, Span2D<T> multiplier)
        where T : INumber<T>
    {
        if (multiplicand == null)
        {
            return multiplier.ToArray();
        }

        if (multiplier == null)
        {
            return multiplicand.ToArray();
        }

        var rowsMultiplicand = multiplicand.Height;
        var columnsMultiplicand = multiplicand.Width;
        var rowsMultiplier = multiplier.Height;
        var columnsMultiplier = multiplier.Width;

        int rowsProduct;
        int columnsProduct;

        T[,] product;

        if (rowsMultiplicand == 1 && columnsMultiplicand == 1 || rowsMultiplier == 1 && columnsMultiplier == 1)
        {
            T scalar;
            Span2D<T> matrix;

            if (rowsMultiplicand == 1 && columnsMultiplicand == 1)
            {
                matrix = multiplier;
                scalar = multiplicand[0, 0];

                rowsProduct = rowsMultiplier;
                columnsProduct = columnsMultiplier;
            }
            else
            {
                matrix = multiplicand;
                scalar = multiplier[0, 0];

                rowsProduct = rowsMultiplicand;
                columnsProduct = columnsMultiplicand;
            }

            product = new T[rowsProduct, columnsProduct];

            for (var i = 0; i < rowsProduct; i++)
            {
                for (var j = 0; j < columnsProduct; j++)
                {
                    product[i, j] = scalar * matrix[i, j];
                }
            }
        }
        else // normal 2 matrix multiplication 
        {
            if (columnsMultiplicand != rowsMultiplier)
            {
                throw new ArgumentException($"The {nameof(multiplicand)} Matrix must have the same number of rows as the {nameof(multiplier)} Matrix has columns.");
            }

            product = new T[rowsMultiplicand, columnsMultiplier];

            for (var i = 0; i < rowsMultiplicand; i++)
            {
                for (var j = 0; j < columnsMultiplier; j++)
                {
                    var dotProduct = T.Zero;

                    for (var k = 0; k < columnsMultiplicand; k++)
                    {
                        dotProduct += multiplicand[i, k] * multiplier[k, j];
                    }

                    product[i, j] = dotProduct;
                }
            }
        }

        return product;
    }

    /// <summary>
    /// Multiply + Multiplication by scalar, accuracy needed.
    /// </summary>
    /// <param name="multiplicand">The matrix1.</param>
    /// <param name="multiplier">The matrix2.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] MatrixMatrixScalarMultiplication<T>(Span2D<T> multiplicand, Span2D<T> multiplier, int accuracy)
        where T : IFloatingPoint<T>
    {
        if (multiplicand == null)
        {
            return multiplier.ToArray();
        }

        if (multiplier == null)
        {
            return multiplicand.ToArray();
        }

        var rowsMultiplicand = multiplicand.Height;
        var columnsMultiplicand = multiplicand.Width;
        var rowsMultiplier = multiplier.Height;
        var columnsMultiplier = multiplier.Width;

        T[,] product;

        if (rowsMultiplicand == 1 && columnsMultiplicand == 1 || rowsMultiplier == 1 && columnsMultiplier == 1)
        {
            T scalar;
            Span2D<T> matrix;

            int rowsProduct;
            int columnsProduct;

            if (rowsMultiplicand == 1 && columnsMultiplicand == 1)
            {
                matrix = multiplier;
                scalar = multiplicand[0, 0];

                rowsProduct = rowsMultiplier;
                columnsProduct = columnsMultiplier;
            }
            else
            {
                matrix = multiplicand;
                scalar = multiplier[0, 0];

                rowsProduct = rowsMultiplicand;
                columnsProduct = columnsMultiplicand;
            }

            product = new T[rowsProduct, columnsProduct];

            for (var i = 0; i < rowsProduct; i++)
            {
                for (var j = 0; j < columnsProduct; j++)
                {
                    product[i, j] = scalar * matrix[i, j];
                }
            }
        }
        else // normal 2 matrix multiplication 
        {
            if (columnsMultiplicand != rowsMultiplier)
            {
                throw new ArgumentException($"The {nameof(multiplicand)} Matrix must have the same number of rows as the {nameof(multiplier)} Matrix has columns.");
            }

            product = new T[rowsMultiplicand, columnsMultiplier];

            for (var i = 0; i < rowsMultiplicand; i++)
            {
                for (var j = 0; j < columnsMultiplier; j++)
                {
                    var dotProduct = T.Zero;

                    for (var k = 0; k < columnsMultiplicand; k++)
                    {
                        dotProduct += multiplicand[i, k] * multiplier[k, j];
                    }

                    product[i, j] = dotProduct;
                }
            }
        }

        return Round<T, T>(product, accuracy);
    }

    /// <summary>
    /// Multiply + Multiplication by scalar, accuracy needed.
    /// </summary>
    /// <param name="multiplicand">The matrix1.</param>
    /// <param name="multiplicandRows">The rows1.</param>
    /// <param name="multiplicandColumns">The columns1.</param>
    /// <param name="multiplier">The matrix2.</param>
    /// <param name="multiplierRows">The rows2.</param>
    /// <param name="multiplierColumns">The columns2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] MatrixMatrixScalarMultiplication<T>(Span2D<T> multiplicand, int multiplicandRows, int multiplicandColumns, Span2D<T> multiplier, int multiplierRows, int multiplierColumns)
        where T : INumber<T>
    {
        if (multiplicand == null)
        {
            return multiplier.ToArray();
        }

        if (multiplier == null)
        {
            return multiplicand.ToArray();
        }

        var rowsMultiplicand = multiplicand.Height;
        var columnsMultiplicand = multiplicand.Width;
        var rowsMultiplier = multiplier.Height;
        var columnsMultiplier = multiplier.Width;

        if (multiplicandRows > rowsMultiplicand || multiplicandColumns > columnsMultiplicand || multiplicandRows > rowsMultiplier || multiplicandColumns > columnsMultiplier ||
            multiplierRows > rowsMultiplicand || multiplierColumns > columnsMultiplicand || multiplierRows > rowsMultiplier || multiplierColumns > columnsMultiplier)
        {
            throw new ArgumentException($"{nameof(multiplicandRows)}, {nameof(multiplicandColumns)}, {nameof(multiplierRows)} and {nameof(multiplierColumns)} must not be larger than the size of {nameof(multiplicand)} and {nameof(multiplier)}");
        }

        T[,] product;

        if (multiplicandRows == 1 && multiplicandColumns == 1 || multiplierRows == 1 && multiplierColumns == 1)
        {
            T scalar;
            Span2D<T> matrix;

            int rowsProduct;
            int columnsProduct;

            if (multiplicandRows == 1 && multiplicandColumns == 1)
            {
                scalar = multiplicand[0, 0];
                matrix = multiplier;

                rowsProduct = multiplierRows;
                columnsProduct = multiplierColumns;
            }
            else
            {
                scalar = multiplier[0, 0];
                matrix = multiplicand;

                rowsProduct = multiplicandRows;
                columnsProduct = multiplicandColumns;
            }

            product = new T[rowsProduct, columnsProduct];

            for (var i = 0; i < rowsProduct; i++)
            {
                for (var j = 0; j < columnsProduct; j++)
                {
                    product[i, j] = scalar * matrix[i, j];
                }
            }
        }
        else // normal 2 matrix multiplication 
        {
            if (columnsMultiplicand != rowsMultiplier)
            {
                throw new ArgumentException($"The {nameof(multiplicand)} Matrix must have the same number of rows as the {nameof(multiplier)} Matrix has columns.");
            }

            product = new T[multiplicandRows, multiplierColumns];

            for (var i = 0; i < multiplicandRows; i++)
            {
                for (var j = 0; j < multiplierColumns; j++)
                {
                    product[i, j] = T.Zero;
                    for (var k = 0; k < multiplicandColumns; k++)
                    {
                        product[i, j] += multiplicand[i, k] * multiplier[k, j];
                    }
                }
            }
        }

        return product;
    }

    /// <summary>
    /// Multiply + Multiplication by scalar, accuracy needed.
    /// </summary>
    /// <param name="multiplicand">The matrix1.</param>
    /// <param name="multiplicandRows">The rows1.</param>
    /// <param name="multiplicandColumns">The columns1.</param>
    /// <param name="multiplier">The matrix2.</param>
    /// <param name="multiplierRows">The rows2.</param>
    /// <param name="multiplierColumns">The columns2.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] MatrixMatrixScalarMultiplication<T>(Span2D<T> multiplicand, int multiplicandRows, int multiplicandColumns, Span2D<T> multiplier, int multiplierRows, int multiplierColumns, int accuracy)
        where T : IFloatingPoint<T>
    {
        if (multiplicand == null)
        {
            return multiplier.ToArray();
        }

        if (multiplier == null)
        {
            return multiplicand.ToArray();
        }

        var rowsMultiplicand = multiplicand.Height;
        var columnsMultiplicand = multiplicand.Width;
        var rowsMultiplier = multiplier.Height;
        var columnsMultiplier = multiplier.Width;

        if (multiplicandRows > rowsMultiplicand || multiplicandColumns > columnsMultiplicand || multiplicandRows > rowsMultiplier || multiplicandColumns > columnsMultiplier ||
            multiplierRows > rowsMultiplicand || multiplierColumns > columnsMultiplicand || multiplierRows > rowsMultiplier || multiplierColumns > columnsMultiplier)
        {
            throw new ArgumentException($"{nameof(multiplicandRows)}, {nameof(multiplicandColumns)}, {nameof(multiplierRows)} and {nameof(multiplierColumns)} must not be larger than the size of {nameof(multiplicand)} and {nameof(multiplier)}");
        }

        T[,] product;

        if (multiplicandRows == 1 && multiplicandColumns == 1 || multiplierRows == 1 && multiplierColumns == 1)
        {
            T scalar;
            Span2D<T> matrix;

            int rowsProduct;
            int columnsProduct;

            if (multiplicandRows == 1 && multiplicandColumns == 1)
            {
                scalar = multiplicand[0, 0];
                matrix = multiplier;

                rowsProduct = multiplierRows;
                columnsProduct = multiplierColumns;
            }
            else
            {
                scalar = multiplier[0, 0];
                matrix = multiplicand;

                rowsProduct = multiplicandRows;
                columnsProduct = multiplicandColumns;
            }

            product = new T[rowsProduct, columnsProduct];

            for (var i = 0; i < rowsProduct; i++)
            {
                for (var j = 0; j < columnsProduct; j++)
                {
                    product[i, j] = scalar * matrix[i, j];
                }
            }
        }
        else // normal 2 matrix multiplication 
        {
            if (columnsMultiplicand != rowsMultiplier)
            {
                throw new ArgumentException($"The {nameof(multiplicand)} Matrix must have the same number of rows as the {nameof(multiplier)} Matrix has columns.");
            }

            product = new T[multiplicandRows, multiplierColumns];

            for (var i = 0; i < multiplicandRows; i++)
            {
                for (var j = 0; j < multiplierColumns; j++)
                {
                    product[i, j] = T.Zero;
                    for (var k = 0; k < multiplicandColumns; k++)
                    {
                        product[i, j] += multiplicand[i, k] * multiplier[k, j];
                    }
                }
            }
        }

        return Round<T, T>(product, accuracy);
    }

    /// <summary>
    /// Multiply2x2x2x2s the specified multiplicand1x1.
    /// </summary>
    /// <param name="multiplicand1x1">The multiplicand M1X1.</param>
    /// <param name="multiplicand1x2">The multiplicand M1X2.</param>
    /// <param name="multiplicand2x1">The multiplicand M2X1.</param>
    /// <param name="multiplicand2x2">The multiplicand M2X2.</param>
    /// <param name="multiplier1x1">The multiplier M1X1.</param>
    /// <param name="multiplier1x2">The multiplier M1X2.</param>
    /// <param name="multiplier2x1">The multiplier M2X1.</param>
    /// <param name="multiplier2x2">The multiplier M2X2.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2
        ) MultiplyMatrix<T>(
        T multiplicand1x1, T multiplicand1x2,
        T multiplicand2x1, T multiplicand2x2,
        T multiplier1x1, T multiplier1x2,
        T multiplier2x1, T multiplier2x2)
        where T : INumber<T>
    {
        return (
                   (multiplicand1x1 * multiplier1x1) + (multiplicand1x2 * multiplier2x1), (multiplicand1x1 * multiplier1x2) + (multiplicand1x2 * multiplier2x2),
                   (multiplicand2x1 * multiplier1x1) + (multiplicand2x2 * multiplier2x1), (multiplicand2x1 * multiplier1x2) + (multiplicand2x2 * multiplier2x2)
               );
    }

    /// <summary>
    /// Multiply3x3x3x3s the specified multiplicand1x1.
    /// </summary>
    /// <param name="multiplicand1x1">The multiplicand M1X1.</param>
    /// <param name="multiplicand1x2">The multiplicand M1X2.</param>
    /// <param name="multiplicand1x3">The multiplicand M1X3.</param>
    /// <param name="multiplicand2x1">The multiplicand M2X1.</param>
    /// <param name="multiplicand2x2">The multiplicand M2X2.</param>
    /// <param name="multiplicand2x3">The multiplicand M2X3.</param>
    /// <param name="multiplicand3x1">The multiplicand M3X1.</param>
    /// <param name="multiplicand3x2">The multiplicand M3X2.</param>
    /// <param name="multiplicand3x3">The multiplicand M3X3.</param>
    /// <param name="multiplier1x1">The multiplier M1X1.</param>
    /// <param name="multiplier1x2">The multiplier M1X2.</param>
    /// <param name="multiplier1x3">The multiplier M1X3.</param>
    /// <param name="multiplier2x1">The multiplier M2X1.</param>
    /// <param name="multiplier2x2">The multiplier M2X2.</param>
    /// <param name="multiplier2x3">The multiplier M2X3.</param>
    /// <param name="multiplier3x1">The multiplier M3X1.</param>
    /// <param name="multiplier3x2">The multiplier M3X2.</param>
    /// <param name="multiplier3x3">The multiplier M3X3.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3)
        MultiplyMatrix<T>(
        T multiplicand1x1, T multiplicand1x2, T multiplicand1x3,
        T multiplicand2x1, T multiplicand2x2, T multiplicand2x3,
        T multiplicand3x1, T multiplicand3x2, T multiplicand3x3,
        T multiplier1x1, T multiplier1x2, T multiplier1x3,
        T multiplier2x1, T multiplier2x2, T multiplier2x3,
        T multiplier3x1, T multiplier3x2, T multiplier3x3)
        where T : INumber<T>
    {
        return (
                   (multiplicand1x1 * multiplier1x1) + (multiplicand1x2 * multiplier2x1) + (multiplicand1x3 * multiplier3x1), (multiplicand1x1 * multiplier1x2) + (multiplicand1x2 * multiplier2x2) + (multiplicand1x3 * multiplier3x2), (multiplicand1x1 * multiplier1x3) + (multiplicand1x2 * multiplier2x3) + (multiplicand1x3 * multiplier3x3),
                   (multiplicand2x1 * multiplier1x1) + (multiplicand2x2 * multiplier2x1) + (multiplicand2x3 * multiplier3x1), (multiplicand2x1 * multiplier1x2) + (multiplicand2x2 * multiplier2x2) + (multiplicand2x3 * multiplier3x2), (multiplicand2x1 * multiplier1x3) + (multiplicand2x2 * multiplier2x3) + (multiplicand2x3 * multiplier3x3),
                   (multiplicand3x1 * multiplier1x1) + (multiplicand3x2 * multiplier2x1) + (multiplicand3x3 * multiplier3x1), (multiplicand3x1 * multiplier1x2) + (multiplicand3x2 * multiplier2x2) + (multiplicand3x3 * multiplier3x2), (multiplicand3x1 * multiplier1x3) + (multiplicand3x2 * multiplier2x3) + (multiplicand3x3 * multiplier3x3)
               );
    }

    /// <summary>
    /// Used to multiply two Matrices.
    /// </summary>
    /// <param name="multiplicand1x1">The multiplicand M1X1.</param>
    /// <param name="multiplicand1x2">The multiplicand M1X2.</param>
    /// <param name="multiplicand1x3">The multiplicand M1X3.</param>
    /// <param name="multiplicand1x4">The multiplicand M1X4.</param>
    /// <param name="multiplicand2x1">The multiplicand M2X1.</param>
    /// <param name="multiplicand2x2">The multiplicand M2X2.</param>
    /// <param name="multiplicand2x3">The multiplicand M2X3.</param>
    /// <param name="multiplicand2x4">The multiplicand M2X4.</param>
    /// <param name="multiplicand3x1">The multiplicand M3X1.</param>
    /// <param name="multiplicand3x2">The multiplicand M3X2.</param>
    /// <param name="multiplicand3x3">The multiplicand M3X3.</param>
    /// <param name="multiplicand3x4">The multiplicand M3X4.</param>
    /// <param name="multiplicand4x1">The multiplicand M4X1.</param>
    /// <param name="multiplicand4x2">The multiplicand M4X2.</param>
    /// <param name="multiplicand4x3">The multiplicand M4X3.</param>
    /// <param name="multiplicand4x4">The multiplicand M4X4.</param>
    /// <param name="multiplier1x1">The multiplier M1X1.</param>
    /// <param name="multiplier1x2">The multiplier M1X2.</param>
    /// <param name="multiplier1x3">The multiplier M1X3.</param>
    /// <param name="multiplier1x4">The multiplier M1X4.</param>
    /// <param name="multiplier2x1">The multiplier M2X1.</param>
    /// <param name="multiplier2x2">The multiplier M2X2.</param>
    /// <param name="multiplier2x3">The multiplier M2X3.</param>
    /// <param name="multiplier2x4">The multiplier M2X4.</param>
    /// <param name="multiplier3x1">The multiplier M3X1.</param>
    /// <param name="multiplier3x2">The multiplier M3X2.</param>
    /// <param name="multiplier3x3">The multiplier M3X3.</param>
    /// <param name="multiplier3x4">The multiplier M3X4.</param>
    /// <param name="multiplier4x1">The multiplier M4X1.</param>
    /// <param name="multiplier4x2">The multiplier M4X2.</param>
    /// <param name="multiplier4x3">The multiplier M4X3.</param>
    /// <param name="multiplier4x4">The multiplier M4X4.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4)
        MultiplyMatrix<T>(
        T multiplicand1x1, T multiplicand1x2, T multiplicand1x3, T multiplicand1x4,
        T multiplicand2x1, T multiplicand2x2, T multiplicand2x3, T multiplicand2x4,
        T multiplicand3x1, T multiplicand3x2, T multiplicand3x3, T multiplicand3x4,
        T multiplicand4x1, T multiplicand4x2, T multiplicand4x3, T multiplicand4x4,
        T multiplier1x1, T multiplier1x2, T multiplier1x3, T multiplier1x4,
        T multiplier2x1, T multiplier2x2, T multiplier2x3, T multiplier2x4,
        T multiplier3x1, T multiplier3x2, T multiplier3x3, T multiplier3x4,
        T multiplier4x1, T multiplier4x2, T multiplier4x3, T multiplier4x4)
        where T : INumber<T>
    {
        return (
                   (multiplicand1x1 * multiplier1x1) + (multiplicand1x2 * multiplier2x1) + (multiplicand1x3 * multiplier3x1) + (multiplicand1x4 * multiplier4x1), (multiplicand1x1 * multiplier1x2) + (multiplicand1x2 * multiplier2x2) + (multiplicand1x3 * multiplier3x2) + (multiplicand1x4 * multiplier4x2), (multiplicand1x1 * multiplier1x3) + (multiplicand1x2 * multiplier2x3) + (multiplicand1x3 * multiplier3x3) + (multiplicand1x4 * multiplier4x3), (multiplicand1x1 * multiplier1x4) + (multiplicand1x2 * multiplier2x4) + (multiplicand1x3 * multiplier3x4) + (multiplicand1x4 * multiplier4x4),
                   (multiplicand2x1 * multiplier1x1) + (multiplicand2x2 * multiplier2x1) + (multiplicand2x3 * multiplier3x1) + (multiplicand2x4 * multiplier4x1), (multiplicand2x1 * multiplier1x2) + (multiplicand2x2 * multiplier2x2) + (multiplicand2x3 * multiplier3x2) + (multiplicand2x4 * multiplier4x2), (multiplicand2x1 * multiplier1x3) + (multiplicand2x2 * multiplier2x3) + (multiplicand2x3 * multiplier3x3) + (multiplicand2x4 * multiplier4x3), (multiplicand2x1 * multiplier1x4) + (multiplicand2x2 * multiplier2x4) + (multiplicand2x3 * multiplier3x4) + (multiplicand2x4 * multiplier4x4),
                   (multiplicand3x1 * multiplier1x1) + (multiplicand3x2 * multiplier2x1) + (multiplicand3x3 * multiplier3x1) + (multiplicand3x4 * multiplier4x1), (multiplicand3x1 * multiplier1x2) + (multiplicand3x2 * multiplier2x2) + (multiplicand3x3 * multiplier3x2) + (multiplicand3x4 * multiplier4x2), (multiplicand3x1 * multiplier1x3) + (multiplicand3x2 * multiplier2x3) + (multiplicand3x3 * multiplier3x3) + (multiplicand3x4 * multiplier4x3), (multiplicand3x1 * multiplier1x4) + (multiplicand3x2 * multiplier2x4) + (multiplicand3x3 * multiplier3x4) + (multiplicand3x4 * multiplier4x4),
                   (multiplicand4x1 * multiplier1x1) + (multiplicand4x2 * multiplier2x1) + (multiplicand4x3 * multiplier3x1) + (multiplicand4x4 * multiplier4x1), (multiplicand4x1 * multiplier1x2) + (multiplicand4x2 * multiplier2x2) + (multiplicand4x3 * multiplier3x2) + (multiplicand4x4 * multiplier4x2), (multiplicand4x1 * multiplier1x3) + (multiplicand4x2 * multiplier2x3) + (multiplicand4x3 * multiplier3x3) + (multiplicand4x4 * multiplier4x3), (multiplicand4x1 * multiplier1x4) + (multiplicand4x2 * multiplier2x4) + (multiplicand4x3 * multiplier3x4) + (multiplicand4x4 * multiplier4x4)
               );
    }

    /// <summary>
    /// Multiply5x5x5x5s the specified multiplicand M1X1.
    /// </summary>
    /// <param name="multiplicand1x1">The multiplicand M1X1.</param>
    /// <param name="multiplicand1x2">The multiplicand M1X2.</param>
    /// <param name="multiplicand1x3">The multiplicand M1X3.</param>
    /// <param name="multiplicand1x4">The multiplicand M1X4.</param>
    /// <param name="multiplicand1x5">The multiplicand M1X5.</param>
    /// <param name="multiplicand2x1">The multiplicand M2X1.</param>
    /// <param name="multiplicand2x2">The multiplicand M2X2.</param>
    /// <param name="multiplicand2x3">The multiplicand M2X3.</param>
    /// <param name="multiplicand2x4">The multiplicand M2X4.</param>
    /// <param name="multiplicand2x5">The multiplicand M2X5.</param>
    /// <param name="multiplicand3x1">The multiplicand M3X1.</param>
    /// <param name="multiplicand3x2">The multiplicand M3X2.</param>
    /// <param name="multiplicand3x3">The multiplicand M3X3.</param>
    /// <param name="multiplicand3x4">The multiplicand M3X4.</param>
    /// <param name="multiplicand3x5">The multiplicand M3X5.</param>
    /// <param name="multiplicand4x1">The multiplicand M4X1.</param>
    /// <param name="multiplicand4x2">The multiplicand M4X2.</param>
    /// <param name="multiplicand4x3">The multiplicand M4X3.</param>
    /// <param name="multiplicand4x4">The multiplicand M4X4.</param>
    /// <param name="multiplicand4x5">The multiplicand M4X5.</param>
    /// <param name="multiplicand5x1">The multiplicand M5X1.</param>
    /// <param name="multiplicand5x2">The multiplicand M5X2.</param>
    /// <param name="multiplicand5x3">The multiplicand M5X3.</param>
    /// <param name="multiplicand5x4">The multiplicand M5X4.</param>
    /// <param name="multiplicand5x5">The multiplicand M5X5.</param>
    /// <param name="multiplier1x1">The multiplier M1X1.</param>
    /// <param name="multiplier1x2">The multiplier M1X2.</param>
    /// <param name="multiplier1x3">The multiplier M1X3.</param>
    /// <param name="multiplier1x4">The multiplier M1X4.</param>
    /// <param name="multiplier1x5">The multiplier M1X5.</param>
    /// <param name="multiplier2x1">The multiplier M2X1.</param>
    /// <param name="multiplier2x2">The multiplier M2X2.</param>
    /// <param name="multiplier2x3">The multiplier M2X3.</param>
    /// <param name="multiplier2x4">The multiplier M2X4.</param>
    /// <param name="multiplier2x5">The multiplier M2X5.</param>
    /// <param name="multiplier3x1">The multiplier M3X1.</param>
    /// <param name="multiplier3x2">The multiplier M3X2.</param>
    /// <param name="multiplier3x3">The multiplier M3X3.</param>
    /// <param name="multiplier3x4">The multiplier M3X4.</param>
    /// <param name="multiplier3x5">The multiplier M3X5.</param>
    /// <param name="multiplier4x1">The multiplier M4X1.</param>
    /// <param name="multiplier4x2">The multiplier M4X2.</param>
    /// <param name="multiplier4x3">The multiplier M4X3.</param>
    /// <param name="multiplier4x4">The multiplier M4X4.</param>
    /// <param name="multiplier4x5">The multiplier M4X5.</param>
    /// <param name="multiplier5x1">The multiplier M5X1.</param>
    /// <param name="multiplier5x2">The multiplier M5X2.</param>
    /// <param name="multiplier5x3">The multiplier M5X3.</param>
    /// <param name="multiplier5x4">The multiplier M5X4.</param>
    /// <param name="multiplier5x5">The multiplier M5X5.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T M1x1, T M1x2, T M1x3, T M1x4, T M1x5,
        T M2x1, T M2x2, T M2x3, T M2x4, T M2x5,
        T M3x1, T M3x2, T M3x3, T M3x4, T M3x5,
        T M4x1, T M4x2, T M4x3, T M4x4, T M4x5,
        T M5x1, T M5x2, T M5x3, T M5x4, T M5x5)
        MultiplyMatrix<T>(
        T multiplicand1x1, T multiplicand1x2, T multiplicand1x3, T multiplicand1x4, T multiplicand1x5,
        T multiplicand2x1, T multiplicand2x2, T multiplicand2x3, T multiplicand2x4, T multiplicand2x5,
        T multiplicand3x1, T multiplicand3x2, T multiplicand3x3, T multiplicand3x4, T multiplicand3x5,
        T multiplicand4x1, T multiplicand4x2, T multiplicand4x3, T multiplicand4x4, T multiplicand4x5,
        T multiplicand5x1, T multiplicand5x2, T multiplicand5x3, T multiplicand5x4, T multiplicand5x5,
        T multiplier1x1, T multiplier1x2, T multiplier1x3, T multiplier1x4, T multiplier1x5,
        T multiplier2x1, T multiplier2x2, T multiplier2x3, T multiplier2x4, T multiplier2x5,
        T multiplier3x1, T multiplier3x2, T multiplier3x3, T multiplier3x4, T multiplier3x5,
        T multiplier4x1, T multiplier4x2, T multiplier4x3, T multiplier4x4, T multiplier4x5,
        T multiplier5x1, T multiplier5x2, T multiplier5x3, T multiplier5x4, T multiplier5x5)
        where T : INumber<T>
    {
        return (
            (multiplicand1x1 * multiplier1x1) + (multiplicand1x2 * multiplier2x1) + (multiplicand1x3 * multiplier3x1) + (multiplicand1x4 * multiplier4x1) + (multiplicand1x5 * multiplier5x1),
            (multiplicand1x1 * multiplier1x2) + (multiplicand1x2 * multiplier2x2) + (multiplicand1x3 * multiplier3x2) + (multiplicand1x4 * multiplier4x2) + (multiplicand1x5 * multiplier5x2),
            (multiplicand1x1 * multiplier1x3) + (multiplicand1x2 * multiplier2x3) + (multiplicand1x3 * multiplier3x3) + (multiplicand1x4 * multiplier4x3) + (multiplicand1x5 * multiplier5x3),
            (multiplicand1x1 * multiplier1x4) + (multiplicand1x2 * multiplier2x4) + (multiplicand1x3 * multiplier3x4) + (multiplicand1x4 * multiplier4x4) + (multiplicand1x5 * multiplier5x4),
            (multiplicand1x1 * multiplier1x5) + (multiplicand1x2 * multiplier2x5) + (multiplicand1x3 * multiplier3x5) + (multiplicand1x4 * multiplier4x5) + (multiplicand1x5 * multiplier5x5),
            (multiplicand2x1 * multiplier1x1) + (multiplicand2x2 * multiplier2x1) + (multiplicand2x3 * multiplier3x1) + (multiplicand2x4 * multiplier4x1) + (multiplicand2x5 * multiplier5x1),
            (multiplicand2x1 * multiplier1x2) + (multiplicand2x2 * multiplier2x2) + (multiplicand2x3 * multiplier3x2) + (multiplicand2x4 * multiplier4x2) + (multiplicand2x5 * multiplier5x2),
            (multiplicand2x1 * multiplier1x3) + (multiplicand2x2 * multiplier2x3) + (multiplicand2x3 * multiplier3x3) + (multiplicand2x4 * multiplier4x3) + (multiplicand2x5 * multiplier5x3),
            (multiplicand2x1 * multiplier1x4) + (multiplicand2x2 * multiplier2x4) + (multiplicand2x3 * multiplier3x4) + (multiplicand2x4 * multiplier4x4) + (multiplicand2x5 * multiplier5x4),
            (multiplicand2x1 * multiplier1x5) + (multiplicand2x2 * multiplier2x5) + (multiplicand2x3 * multiplier3x5) + (multiplicand2x4 * multiplier4x5) + (multiplicand2x5 * multiplier5x5),
            (multiplicand3x1 * multiplier1x1) + (multiplicand3x2 * multiplier2x1) + (multiplicand3x3 * multiplier3x1) + (multiplicand3x4 * multiplier4x1) + (multiplicand3x5 * multiplier5x1),
            (multiplicand3x1 * multiplier1x2) + (multiplicand3x2 * multiplier2x2) + (multiplicand3x3 * multiplier3x2) + (multiplicand3x4 * multiplier4x2) + (multiplicand3x5 * multiplier5x2),
            (multiplicand3x1 * multiplier1x3) + (multiplicand3x2 * multiplier2x3) + (multiplicand3x3 * multiplier3x3) + (multiplicand3x4 * multiplier4x3) + (multiplicand3x5 * multiplier5x3),
            (multiplicand3x1 * multiplier1x4) + (multiplicand3x2 * multiplier2x4) + (multiplicand3x3 * multiplier3x4) + (multiplicand3x4 * multiplier4x4) + (multiplicand3x5 * multiplier5x4),
            (multiplicand3x1 * multiplier1x5) + (multiplicand3x2 * multiplier2x5) + (multiplicand3x3 * multiplier3x5) + (multiplicand3x4 * multiplier4x5) + (multiplicand3x5 * multiplier5x5),
            (multiplicand4x1 * multiplier1x1) + (multiplicand4x2 * multiplier2x1) + (multiplicand4x3 * multiplier3x1) + (multiplicand4x4 * multiplier4x1) + (multiplicand4x5 * multiplier5x1),
            (multiplicand4x1 * multiplier1x2) + (multiplicand4x2 * multiplier2x2) + (multiplicand4x3 * multiplier3x2) + (multiplicand4x4 * multiplier4x2) + (multiplicand4x5 * multiplier5x2),
            (multiplicand4x1 * multiplier1x3) + (multiplicand4x2 * multiplier2x3) + (multiplicand4x3 * multiplier3x3) + (multiplicand4x4 * multiplier4x3) + (multiplicand4x5 * multiplier5x3),
            (multiplicand4x1 * multiplier1x4) + (multiplicand4x2 * multiplier2x4) + (multiplicand4x3 * multiplier3x4) + (multiplicand4x4 * multiplier4x4) + (multiplicand4x5 * multiplier5x4),
            (multiplicand4x1 * multiplier1x5) + (multiplicand4x2 * multiplier2x5) + (multiplicand4x3 * multiplier3x5) + (multiplicand4x4 * multiplier4x5) + (multiplicand4x5 * multiplier5x5),
            (multiplicand5x1 * multiplier1x1) + (multiplicand5x2 * multiplier2x1) + (multiplicand5x3 * multiplier3x1) + (multiplicand5x4 * multiplier4x1) + (multiplicand5x5 * multiplier5x1),
            (multiplicand5x1 * multiplier1x2) + (multiplicand5x2 * multiplier2x2) + (multiplicand5x3 * multiplier3x2) + (multiplicand5x4 * multiplier4x2) + (multiplicand5x5 * multiplier5x2),
            (multiplicand5x1 * multiplier1x3) + (multiplicand5x2 * multiplier2x3) + (multiplicand5x3 * multiplier3x3) + (multiplicand5x4 * multiplier4x3) + (multiplicand5x5 * multiplier5x3),
            (multiplicand5x1 * multiplier1x4) + (multiplicand5x2 * multiplier2x4) + (multiplicand5x3 * multiplier3x4) + (multiplicand5x4 * multiplier4x4) + (multiplicand5x5 * multiplier5x4),
            (multiplicand5x1 * multiplier1x5) + (multiplicand5x2 * multiplier2x5) + (multiplicand5x3 * multiplier3x5) + (multiplicand5x4 * multiplier4x5) + (multiplicand5x5 * multiplier5x5)
               );
    }
    #endregion

    #region Multiply Vectors with the right vector a transposed matrix
    /// <summary>
    /// Vector vs Vector Multiplication 2, internal usage.
    /// </summary>
    /// <param name="colummnVectorMultiplicand">The column vector.</param>
    /// <param name="rowVectorMultiplier">The row vector.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,] ColumnVectorRowVectorMatrixMultiplication<T, TResult>(Span<T> colummnVectorMultiplicand, Span<T> rowVectorMultiplier)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        if (colummnVectorMultiplicand == null)
        {
            throw new ArgumentNullException(nameof(colummnVectorMultiplicand));
        }

        if (rowVectorMultiplier == null)
        {
            throw new ArgumentNullException(nameof(rowVectorMultiplier));
        }

        var rowsMultiplicand = colummnVectorMultiplicand.Length;
        var ColumnsMultiplier = rowVectorMultiplier.Length;

        if (rowsMultiplicand != ColumnsMultiplier)
        {
            throw new ArgumentException($"The {nameof(colummnVectorMultiplicand)} Matrix must have the same number of rows as the {nameof(rowVectorMultiplier)} Matrix has columns.");
        }

        var product = new TResult[rowsMultiplicand, ColumnsMultiplier];

        for (var i = 0; i < rowsMultiplicand; i++)
        {
            for (var j = 0; j < ColumnsMultiplier; j++)
            {
                product[i, j] = TResult.Create(colummnVectorMultiplicand[i] * rowVectorMultiplier[j]);
            }
        }

        return product;
    }

    /// <summary>
    /// Vector vs Vector Multiplication 2, internal usage.
    /// </summary>
    /// <param name="colummnVectorMultiplicand">The column vector.</param>
    /// <param name="colummnLength">Length of the col.</param>
    /// <param name="rowVectorMultiplier">The row vector.</param>
    /// <param name="rowLength">Length of the row.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] ColumnVectorRowVectorMatrixMultiplication<T>(Span<T> colummnVectorMultiplicand, int colummnLength, Span<T> rowVectorMultiplier, int rowLength)
        where T : INumber<T>
    {
        if (colummnVectorMultiplicand == null)
        {
            throw new ArgumentNullException(nameof(colummnVectorMultiplicand));
        }

        if (rowVectorMultiplier == null)
        {
            throw new ArgumentNullException(nameof(rowVectorMultiplier));
        }

        var rowsMultiplicand = colummnVectorMultiplicand.Length;
        var ColumnsMultiplier = rowVectorMultiplier.Length;

        if (colummnLength > rowsMultiplicand || rowLength > ColumnsMultiplier)
        {
            throw new ArgumentException($"{nameof(colummnVectorMultiplicand)} and {nameof(ColumnsMultiplier)} must not be larger than the size of {nameof(colummnVectorMultiplicand)} and {nameof(rowVectorMultiplier)}");
        }

        var product = new T[colummnLength, rowLength];

        for (var i = 0; i < colummnLength; i++)
        {
            for (var j = 0; j < rowLength; j++)
            {
                product[i, j] = colummnVectorMultiplicand[i] * rowVectorMultiplier[j];
            }
        }

        return product;
    }

    /// <summary>
    /// Multiplies the vectors right transposed.
    /// </summary>
    /// <param name="ai">The ai.</param>
    /// <param name="aj">The aj.</param>
    /// <param name="bi">The bi.</param>
    /// <param name="bj">The bj.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T M0x0, T M0x1,
        T M1x0, T M1x1
        ) MultiplyVectorsRightTransposed<T>(
        T ai, T aj,
        T bi, T bj
        )
        where T : INumber<T> => (
            ai * bi, aj * bi,
            ai * bj, aj * bj
            );

    /// <summary>
    /// Multiplies the vectors right transposed.
    /// </summary>
    /// <param name="ai">The ai.</param>
    /// <param name="aj">The aj.</param>
    /// <param name="ak">The ak.</param>
    /// <param name="bi">The bi.</param>
    /// <param name="bj">The bj.</param>
    /// <param name="bk">The bk.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T M0x0, T M0x1, T M0x2,
        T M1x0, T M1x1, T M1x2,
        T M2x0, T M2x1, T M2x2
        ) MultiplyVectorsRightTransposed<T>(
        T ai, T aj, T ak,
        T bi, T bj, T bk
        )
        where T : INumber<T> => (
            ai * bi, aj * bi, ak * bi,
            ai * bj, aj * bj, ak * bj,
            ai * bk, aj * bk, ak * bk
            );

    /// <summary>
    /// Multiplies the vectors right transposed.
    /// </summary>
    /// <param name="ai">The ai.</param>
    /// <param name="aj">The aj.</param>
    /// <param name="ak">The ak.</param>
    /// <param name="al">The al.</param>
    /// <param name="bi">The bi.</param>
    /// <param name="bj">The bj.</param>
    /// <param name="bk">The bk.</param>
    /// <param name="bl">The bl.</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T M0x0, T M0x1, T M0x2, T M0x3,
        T M1x0, T M1x1, T M1x2, T M1x3,
        T M2x0, T M2x1, T M2x2, T M2x3,
        T M3x0, T M3x1, T M3x2, T M3x3
        ) MultiplyVectorsRightTransposed<T>(
        T ai, T aj, T ak, T al,
        T bi, T bj, T bk, T bl
        )
        where T : INumber<T> => (
            ai * bi, aj * bi, ak * bi, al * bi,
            ai * bj, aj * bj, ak * bj, al * bj,
            ai * bk, aj * bk, ak * bk, al * bk,
            ai * bl, aj * bl, ak * bl, al * bl
            );

    /// <summary>
    /// Multiplies the vectors right transposed.
    /// </summary>
    /// <param name="ai">The ai.</param>
    /// <param name="aj">The aj.</param>
    /// <param name="ak">The ak.</param>
    /// <param name="al">The al.</param>
    /// <param name="am">The am.</param>
    /// <param name="bi">The bi.</param>
    /// <param name="bj">The bj.</param>
    /// <param name="bk">The bk.</param>
    /// <param name="bl">The bl.</param>
    /// <param name="bm">The bm.</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T M0x0, T M0x1, T M0x2, T M0x3, T M0x4,
        T M1x0, T M1x1, T M1x2, T M1x3, T M1x4,
        T M2x0, T M2x1, T M2x2, T M2x3, T M2x4,
        T M3x0, T M3x1, T M3x2, T M3x3, T M3x4,
        T M4x0, T M4x1, T M4x2, T M4x3, T M4x4
        ) MultiplyVectorsRightTransposed<T>(
        T ai, T aj, T ak, T al, T am,
        T bi, T bj, T bk, T bl, T bm
        )
        where T : INumber<T> => (
            ai * bi, aj * bi, ak * bi, al * bi, am * bi,
            ai * bj, aj * bj, ak * bj, al * bj, am * bj,
            ai * bk, aj * bk, ak * bk, al * bk, am * bk,
            ai * bl, aj * bl, ak * bl, al * bl, am * bl,
            ai * bm, aj * bm, ak * bm, al * bm, am * bm
            );

    /// <summary>
    /// Multiplies the vectors right transposed.
    /// </summary>
    /// <param name="ai">The ai.</param>
    /// <param name="aj">The aj.</param>
    /// <param name="ak">The ak.</param>
    /// <param name="al">The al.</param>
    /// <param name="am">The am.</param>
    /// <param name="an">An.</param>
    /// <param name="bi">The bi.</param>
    /// <param name="bj">The bj.</param>
    /// <param name="bk">The bk.</param>
    /// <param name="bl">The bl.</param>
    /// <param name="bm">The bm.</param>
    /// <param name="bn">The bn.</param>
    /// <returns></returns>
    [DebuggerStepThrough]
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T M0x0, T M0x1, T M0x2, T M0x3, T M0x4, T M0x5,
        T M1x0, T M1x1, T M1x2, T M1x3, T M1x4, T M1x5,
        T M2x0, T M2x1, T M2x2, T M2x3, T M2x4, T M2x5,
        T M3x0, T M3x1, T M3x2, T M3x3, T M3x4, T M3x5,
        T M4x0, T M4x1, T M4x2, T M4x3, T M4x4, T M4x5,
        T M5x0, T M5x1, T M5x2, T M5x3, T M5x4, T M5x5
        ) MultiplyVectorsRightTransposed<T>(
        T ai, T aj, T ak, T al, T am, T an,
        T bi, T bj, T bk, T bl, T bm, T bn
        )
        where T : INumber<T> => (
            ai * bi, aj * bi, ak * bi, al * bi, am * bi, an * bi,
            ai * bj, aj * bj, ak * bj, al * bj, am * bj, an * bj,
            ai * bk, aj * bk, ak * bk, al * bk, am * bk, an * bk,
            ai * bl, aj * bl, ak * bl, al * bl, am * bl, an * bl,
            ai * bm, aj * bm, ak * bm, al * bm, am * bm, an * bm,
            ai * bn, aj * bn, ak * bn, al * bn, am * bn, an * bn
            );
    #endregion
}
