﻿// <copyright file="Operations.Matricies.Algebratics.cs" company="Shkyrockett" >
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
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary;

/// <summary>
/// The Operations class.
/// </summary>
public static partial class Operations
{
    #region Adjoint
    /// <summary>
    /// Function to get adjoint of the specified matrix.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Adjoint<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var rows = matrix.Height;
        var cols = matrix.Width;

        if (rows == 1)
        {
            return new T[1, 1] { { T.One } };
        }

        var adj = new T[rows, cols];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                // Get cofactor of A[i,j] 
                var temp = Cofactor(matrix, i, j);

                // Sign of adj[j,i] positive if sum of row and column indexes is even. 
                var sign = ((i + j) % 2 == 0) ? T.One : -T.One;

                // Interchanging rows and columns to get the  transpose of the cofactor matrix 
                adj[j, i] = sign * Determinant<T>(temp);
            }
        }

        return adj;
    }

    /// <summary>
    /// The adjoint.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <returns>
    /// The Matrix.
    /// </returns>
    /// <acknowledgment>
    /// https://sites.google.com/site/physics2d/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2)
        AdjointMatrix<T>(
        T m1x1, T m1x2,
        T m2x1, T m2x2)
        where T : INumber<T>
        => (
            m2x2, -m1x2,
            -m2x1, m1x1);

    /// <summary>
    /// The adjoint.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m1x3">The M1X3.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <param name="m2x3">The M2X3.</param>
    /// <param name="m3x1">The M3X1.</param>
    /// <param name="m3x2">The M3X2.</param>
    /// <param name="m3x3">The M3X3.</param>
    /// <returns>
    /// The Matrix.
    /// </returns>
    /// <acknowledgment>
    /// https://sites.google.com/site/physics2d/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3)
        AdjointMatrix<T>(
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3)
        where T : INumber<T>
        => (
            (m2x2 * m3x3) - (m2x3 * m3x2), -((m1x2 * m3x3) - (m1x3 * m3x2)), (m1x2 * m2x3) - (m1x3 * m2x2),
            -((m2x1 * m3x3) - (m2x3 * m3x1)), (m1x1 * m3x3) - (m1x3 * m3x1), -((m1x1 * m2x3) - (m1x3 * m2x1)),
            (m2x1 * m3x2) - (m2x2 * m3x1), -((m1x1 * m3x2) - (m1x2 * m3x1)), (m1x1 * m2x2) - (m1x2 * m2x1));

    /// <summary>
    /// Used to generate the adjoint of this matrix.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m1x3">The M1X3.</param>
    /// <param name="m1x4">The M1X4.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <param name="m2x3">The M2X3.</param>
    /// <param name="m2x4">The M2X4.</param>
    /// <param name="m3x1">The M3X1.</param>
    /// <param name="m3x2">The M3X2.</param>
    /// <param name="m3x3">The M3X3.</param>
    /// <param name="m3x4">The M3X4.</param>
    /// <param name="m4x1">The M4X1.</param>
    /// <param name="m4x2">The M4X2.</param>
    /// <param name="m4x3">The M4X3.</param>
    /// <param name="m4x4">The M4X4.</param>
    /// <returns>
    /// The adjoint matrix of the current instance.
    /// </returns>
    /// <acknowledgment>
    /// https://sites.google.com/site/physics2d/
    /// This is an expanded version of the Ogre adjoint() method.
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4)
        AdjointMatrix<T>(
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4)
        where T : INumber<T>
    {
        var m33m44m43m34 = (m3x3 * m4x4) - (m4x3 * m3x4);
        var m32m44m42m34 = (m3x2 * m4x4) - (m4x2 * m3x4);
        var m32m43m42m33 = (m3x2 * m4x3) - (m4x2 * m3x3);

        var m23m44m43m24 = (m2x3 * m4x4) - (m4x3 * m2x4);
        var m22m44m42m24 = (m2x2 * m4x4) - (m4x2 * m2x4);
        var m22m43m42m23 = (m2x2 * m4x3) - (m4x2 * m2x3);

        var m23m34m33m24 = (m2x3 * m3x4) - (m3x3 * m2x4);
        var m22m34m32m24 = (m2x2 * m3x4) - (m3x2 * m2x4);
        var m22m33m32m23 = (m2x2 * m3x3) - (m3x2 * m2x3);

        var m31m44m41m34 = (m3x1 * m4x4) - (m4x1 * m3x4);
        var m31m43m41m33 = (m3x1 * m4x3) - (m4x1 * m3x3);
        var m21m44m41m24 = (m2x1 * m4x4) - (m4x1 * m2x4);

        var m21m43m41m23 = (m2x1 * m4x3) - (m4x1 * m2x3);
        var m21m34m31m24 = (m2x1 * m3x4) - (m3x1 * m2x4);
        var m21m33m31m23 = (m2x1 * m3x3) - (m3x1 * m2x3);

        var m31m42m41m32 = (m3x1 * m4x2) - (m4x1 * m3x2);
        var m21m42m41m22 = (m2x1 * m4x2) - (m4x1 * m2x2);
        var m21m32m31m22 = (m2x1 * m3x2) - (m3x1 * m2x2);

        return (
              (m2x2 * m33m44m43m34) - (m2x3 * m32m44m42m34) + (m2x4 * m32m43m42m33), -((m1x2 * m33m44m43m34) - (m1x3 * m32m44m42m34) + (m1x4 * m32m43m42m33)), (m1x2 * m23m44m43m24) - (m1x3 * m22m44m42m24) + (m1x4 * m22m43m42m23), -((m1x2 * m23m34m33m24) - (m1x3 * m22m34m32m24) + (m1x4 * m22m33m32m23)),
            -((m2x1 * m33m44m43m34) - (m2x3 * m31m44m41m34) + (m2x4 * m31m43m41m33)), (m1x1 * m33m44m43m34) - (m1x3 * m31m44m41m34) + (m1x4 * m31m43m41m33), -((m1x1 * m23m44m43m24) - (m1x3 * m21m44m41m24) + (m1x4 * m21m43m41m23)), (m1x1 * m23m34m33m24) - (m1x3 * m21m34m31m24) + (m1x4 * m21m33m31m23),
              (m2x1 * m32m44m42m34) - (m2x2 * m31m44m41m34) + (m2x4 * m31m42m41m32), -((m1x1 * m32m44m42m34) - (m1x2 * m31m44m41m34) + (m1x4 * m31m42m41m32)), (m1x1 * m22m44m42m24) - (m1x2 * m21m44m41m24) + (m1x4 * m21m42m41m22), -((m1x1 * m22m34m32m24) - (m1x2 * m21m34m31m24) + (m1x4 * m21m32m31m22)),
            -((m2x1 * m32m43m42m33) - (m2x2 * m31m43m41m33) + (m2x3 * m31m42m41m32)), (m1x1 * m32m43m42m33) - (m1x2 * m31m43m41m33) + (m1x3 * m31m42m41m32), -((m1x1 * m22m43m42m23) - (m1x2 * m21m43m41m23) + (m1x3 * m21m42m41m22)), (m1x1 * m22m33m32m23) - (m1x2 * m21m33m31m23) + (m1x3 * m21m32m31m22)
            );
    }

    /// <summary>
    /// Adjoints the specified matrix.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m1x3">The M1X3.</param>
    /// <param name="m1x4">The M1X4.</param>
    /// <param name="m1x5">The M1X5.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <param name="m2x3">The M2X3.</param>
    /// <param name="m2x4">The M2X4.</param>
    /// <param name="m2x5">The M2X5.</param>
    /// <param name="m3x1">The M3X1.</param>
    /// <param name="m3x2">The M3X2.</param>
    /// <param name="m3x3">The M3X3.</param>
    /// <param name="m3x4">The M3X4.</param>
    /// <param name="m3x5">The M3X5.</param>
    /// <param name="m4x1">The M4X1.</param>
    /// <param name="m4x2">The M4X2.</param>
    /// <param name="m4x3">The M4X3.</param>
    /// <param name="m4x4">The M4X4.</param>
    /// <param name="m4x5">The M4X5.</param>
    /// <param name="m5x1">The M5X1.</param>
    /// <param name="m5x2">The M5X2.</param>
    /// <param name="m5x3">The M5X3.</param>
    /// <param name="m5x4">The M5X4.</param>
    /// <param name="m5x5">The M5X5.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5)
        AdjointMatrix<T>(
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5)
        where T : INumber<T>
    {
        var m = Adjoint<T>(new T[,]
            {
                    {m1x1, m1x2, m1x3, m1x4, m1x5},
                    {m2x1, m2x2, m2x3, m2x4, m2x5},
                    {m3x1, m3x2, m3x3, m3x4, m3x5},
                    {m4x1, m4x2, m4x3, m4x4, m4x5},
                    {m5x1, m5x2, m5x3, m5x4, m5x5}
            });
        return (m[0, 0], m[0, 1], m[0, 2], m[0, 3], m[0, 4],
                m[1, 0], m[1, 1], m[1, 2], m[1, 3], m[1, 4],
                m[2, 0], m[2, 1], m[2, 2], m[2, 3], m[2, 4],
                m[3, 0], m[3, 1], m[3, 2], m[3, 3], m[3, 4],
                m[4, 0], m[4, 1], m[4, 2], m[4, 3], m[4, 4]);
    }

    /// <summary>
    /// Adjoints the specified M0X0.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m1x3">The M1X3.</param>
    /// <param name="m1x4">The M1X4.</param>
    /// <param name="m1x5">The M1X5.</param>
    /// <param name="m1x6">The M1X6.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <param name="m2x3">The M2X3.</param>
    /// <param name="m2x4">The M2X4.</param>
    /// <param name="m2x5">The M2X5.</param>
    /// <param name="m2x6">The M2X6.</param>
    /// <param name="m3x1">The M3X1.</param>
    /// <param name="m3x2">The M3X2.</param>
    /// <param name="m3x3">The M3X3.</param>
    /// <param name="m3x4">The M3X4.</param>
    /// <param name="m3x5">The M3X5.</param>
    /// <param name="m3x6">The M3X6.</param>
    /// <param name="m4x1">The M4X1.</param>
    /// <param name="m4x2">The M4X2.</param>
    /// <param name="m4x3">The M4X3.</param>
    /// <param name="m4x4">The M4X4.</param>
    /// <param name="m4x5">The M4X5.</param>
    /// <param name="m4x6">The M4X6.</param>
    /// <param name="m5x1">The M5X1.</param>
    /// <param name="m5x2">The M5X2.</param>
    /// <param name="m5x3">The M5X3.</param>
    /// <param name="m5x4">The M5X4.</param>
    /// <param name="m5x5">The M5X5.</param>
    /// <param name="m5x6">The M5X6.</param>
    /// <param name="m6x1">The M6X1.</param>
    /// <param name="m6x2">The M6X2.</param>
    /// <param name="m6x3">The M6X3.</param>
    /// <param name="m6x4">The M6X4.</param>
    /// <param name="m6x5">The M6X5.</param>
    /// <param name="m6x6">The M6X6.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5, T m1x6,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5, T m2x6,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5, T m3x6,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5, T m4x6,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5, T m5x6,
        T m6x1, T m6x2, T m6x3, T m6x4, T m6x5, T m6x6)
        AdjointMatrix<T>(
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5, T m1x6,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5, T m2x6,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5, T m3x6,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5, T m4x6,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5, T m5x6,
        T m6x1, T m6x2, T m6x3, T m6x4, T m6x5, T m6x6)
        where T : INumber<T>
    {
        var m = Adjoint<T>(new T[,]
            {
                    {m1x1, m1x2, m1x3, m1x4, m1x5, m1x6},
                    {m2x1, m2x2, m2x3, m2x4, m2x5, m2x6},
                    {m3x1, m3x2, m3x3, m3x4, m3x5, m3x6},
                    {m4x1, m4x2, m4x3, m4x4, m4x5, m4x6},
                    {m5x1, m5x2, m5x3, m5x4, m5x5, m5x6},
                    {m6x1, m6x2, m6x3, m6x4, m6x5, m6x6}
            });
        return (m[0, 0], m[0, 1], m[0, 2], m[0, 3], m[0, 4], m[0, 5],
                m[1, 0], m[1, 1], m[1, 2], m[1, 3], m[1, 4], m[1, 5],
                m[2, 0], m[2, 1], m[2, 2], m[2, 3], m[2, 4], m[2, 5],
                m[3, 0], m[3, 1], m[3, 2], m[3, 3], m[3, 4], m[3, 5],
                m[4, 0], m[4, 1], m[4, 2], m[4, 3], m[4, 4], m[4, 5],
                m[5, 0], m[5, 1], m[5, 2], m[5, 3], m[5, 4], m[5, 5]);
    }
    #endregion Adjoint

    #region Cofactor
    /// <summary>
    /// Cofactors the specified a.
    /// </summary>
    /// <param name="matrix">a.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
    /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Cofactor<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var i = 0;
        var j = 0;
        var rows = matrix.Height;
        var cols = matrix.Width;
        var temp = new T[rows, cols];

        // Looping for each element of the matrix 
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                temp[i, j++] = matrix[row, col];

                // Row is filled, so increase row index and 
                // reset col index 
                if (j == cols - 1)
                {
                    j = 0;
                    i++;
                }
            }
        }

        return temp;
    }

    /// <summary>
    /// Cofactors the specified a.
    /// </summary>
    /// <param name="matrix">a.</param>
    /// <param name="p">The p.</param>
    /// <param name="q">The q.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
    /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Cofactor<T>(Span2D<T> matrix, int p, int q)
        where T : INumber<T>
    {
        var i = 0;
        var j = 0;
        var rows = matrix.Height;
        var cols = matrix.Width;
        var temp = new T[rows, cols];

        // Looping for each element of the matrix 
        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                // Copying into temporary matrix only those element 
                // which are not in given row and column 
                if (row != p && col != q)
                {
                    temp[i, j++] = matrix[row, col];

                    // Row is filled, so increase row index and 
                    // reset col index 
                    if (j == cols - 1)
                    {
                        j = 0;
                        i++;
                    }
                }
            }
        }

        return temp;
    }

    /// <summary>
    /// The cofactor.
    /// </summary>
    /// <param name="m1x1">The M0X0.</param>
    /// <param name="m1x2">The M0X1.</param>
    /// <param name="m2x1">The M1X0.</param>
    /// <param name="m2x2">The M1X1.</param>
    /// <returns>
    /// The Matrix.
    /// </returns>
    /// <acknowledgment>
    /// https://sites.google.com/site/physics2d/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2)
        CofactorMatrix<T>(
        T m1x1, T m1x2,
        T m2x1, T m2x2)
        where T : INumber<T>
        => (-m2x2, m1x2,
            m2x1, -m1x1);

    /// <summary>
    /// The cofactor.
    /// </summary>
    /// <param name="m1x1">The M0X0.</param>
    /// <param name="m1x2">The M0X1.</param>
    /// <param name="m1x3">The M0X2.</param>
    /// <param name="m2x1">The M1X0.</param>
    /// <param name="m2x2">The M1X1.</param>
    /// <param name="m2x3">The M1X2.</param>
    /// <param name="m3x1">The M2X0.</param>
    /// <param name="m3x2">The M2X1.</param>
    /// <param name="m3x3">The M2X2.</param>
    /// <returns>
    /// The Matrix.
    /// </returns>
    /// <acknowledgment>
    /// https://sites.google.com/site/physics2d/
    /// This is an expanded version of the Ogre determinant() method, to give better performance in C#. Generated using a script.
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3)
        CofactorMatrix<T>(
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3)
        where T : INumber<T>
        => (-((m2x2 * m3x3) - (m2x3 * m3x2)), (m1x2 * m3x3) - (m1x3 * m3x2), -((m1x2 * m2x3) - (m1x3 * m2x2)),
              (m2x1 * m3x3) - (m2x3 * m3x1), -((m1x1 * m3x3) - (m1x3 * m3x1)), (m1x1 * m2x3) - (m1x3 * m2x1),
            -((m2x1 * m3x2) - (m2x2 * m3x1)), (m1x1 * m3x2) - (m1x2 * m3x1), -((m1x1 * m2x2) - (m1x2 * m2x1)));

    /// <summary>
    /// The cofactor.
    /// </summary>
    /// <param name="m1x1">The M0X0.</param>
    /// <param name="m1x2">The M0X1.</param>
    /// <param name="m1x3">The M0X2.</param>
    /// <param name="m1x4">The M0X3.</param>
    /// <param name="m2x1">The M1X0.</param>
    /// <param name="m2x2">The M1X1.</param>
    /// <param name="m2x3">The M1X2.</param>
    /// <param name="m2x4">The M1X3.</param>
    /// <param name="m3x1">The M2X0.</param>
    /// <param name="m3x2">The M2X1.</param>
    /// <param name="m3x3">The M2X2.</param>
    /// <param name="m3x4">The M2X3.</param>
    /// <param name="m4x1">The M3X0.</param>
    /// <param name="m4x2">The M3X1.</param>
    /// <param name="m4x3">The M3X2.</param>
    /// <param name="m4x4">The M3X3.</param>
    /// <returns>
    /// The Matrix.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4)
        CofactorMatrix<T>(
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4)
        where T : INumber<T>
    {
        var m33m44m43m34 = (m3x3 * m4x4) - (m4x3 * m3x4);
        var m32m44m42m34 = (m3x2 * m4x4) - (m4x2 * m3x4);
        var m32m43m42m33 = (m3x2 * m4x3) - (m4x2 * m3x3);
        var m23m44m43m24 = (m2x3 * m4x4) - (m4x3 * m2x4);

        var m22m44m42m24 = (m2x2 * m4x4) - (m4x2 * m2x4);
        var m22m43m42m23 = (m2x2 * m4x3) - (m4x2 * m2x3);
        var m23m34m33m24 = (m2x3 * m3x4) - (m3x3 * m2x4);
        var m22m34m32m24 = (m2x2 * m3x4) - (m3x2 * m2x4);

        var m22m33m32m23 = (m2x2 * m3x3) - (m3x2 * m2x3);
        var m31m44m41m34 = (m3x1 * m4x4) - (m4x1 * m3x4);
        var m31m43m41m33 = (m3x1 * m4x3) - (m4x1 * m3x3);
        var m21m44m41m24 = (m2x1 * m4x4) - (m4x1 * m2x4);

        var m21m43m41m23 = (m2x1 * m4x3) - (m4x1 * m2x3);
        var m21m34m31m24 = (m2x1 * m3x4) - (m3x1 * m2x4);
        var m21m33m31m23 = (m2x1 * m3x3) - (m3x1 * m2x3);
        var m31m42m41m32 = (m3x1 * m4x2) - (m4x1 * m3x2);

        var m21m42m41m22 = (m2x1 * m4x2) - (m4x1 * m2x2);
        var m21m32m31m22 = (m2x1 * m3x2) - (m3x1 * m2x2);

        return (
            -((m2x2 * m33m44m43m34) - (m2x3 * m32m44m42m34) + (m2x4 * m32m43m42m33)), (m1x2 * m33m44m43m34) - (m1x3 * m32m44m42m34) + (m1x4 * m32m43m42m33), -((m1x2 * m23m44m43m24) - (m1x3 * m22m44m42m24) + (m1x4 * m22m43m42m23)), (m1x2 * m23m34m33m24) - (m1x3 * m22m34m32m24) + (m1x4 * m22m33m32m23),
            (m2x1 * m33m44m43m34) - (m2x3 * m31m44m41m34) + (m2x4 * m31m43m41m33), -((m1x1 * m33m44m43m34) - (m1x3 * m31m44m41m34) + (m1x4 * m31m43m41m33)), (m1x1 * m23m44m43m24) - (m1x3 * m21m44m41m24) + (m1x4 * m21m43m41m23), -((m1x1 * m23m34m33m24) - (m1x3 * m21m34m31m24) + (m1x4 * m21m33m31m23)),
            -((m2x1 * m32m44m42m34) - (m2x2 * m31m44m41m34) + (m2x4 * m31m42m41m32)), (m1x1 * m32m44m42m34) - (m1x2 * m31m44m41m34) + (m1x4 * m31m42m41m32), -((m1x1 * m22m44m42m24) - (m1x2 * m21m44m41m24) + (m1x4 * m21m42m41m22)), (m1x1 * m22m34m32m24) - (m1x2 * m21m34m31m24) + (m1x4 * m21m32m31m22),
            (m2x1 * m32m43m42m33) - (m2x2 * m31m43m41m33) + (m2x3 * m31m42m41m32), -((m1x1 * m32m43m42m33) - (m1x2 * m31m43m41m33) + (m1x3 * m31m42m41m32)), (m1x1 * m22m43m42m23) - (m1x2 * m21m43m41m23) + (m1x3 * m21m42m41m22), -((m1x1 * m22m33m32m23) - (m1x2 * m21m33m31m23) + (m1x3 * m21m32m31m22)));
    }

    /// <summary>
    /// Cofactors the specified M0X0.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m1x3">The M1X3.</param>
    /// <param name="m1x4">The M1X4.</param>
    /// <param name="m1x5">The M1X5.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <param name="m2x3">The M2X3.</param>
    /// <param name="m2x4">The M2X4.</param>
    /// <param name="m2x5">The M2X5.</param>
    /// <param name="m3x1">The M3X1.</param>
    /// <param name="m3x2">The M3X2.</param>
    /// <param name="m3x3">The M3X3.</param>
    /// <param name="m3x4">The M3X4.</param>
    /// <param name="m3x5">The M3X5.</param>
    /// <param name="m4x1">The M4X1.</param>
    /// <param name="m4x2">The M4X2.</param>
    /// <param name="m4x3">The M4X3.</param>
    /// <param name="m4x4">The M4X4.</param>
    /// <param name="m4x5">The M4X5.</param>
    /// <param name="m5x1">The M5X1.</param>
    /// <param name="m5x2">The M5X2.</param>
    /// <param name="m5x3">The M5X3.</param>
    /// <param name="m5x4">The M5X4.</param>
    /// <param name="m5x5">The M5X5.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5)
        CofactorMatrix<T>(
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5)
        where T : INumber<T>
    {
        var m = Cofactor<T>(new T[,]
            {
                    {m1x1, m1x2, m1x3, m1x4, m1x5},
                    {m2x1, m2x2, m2x3, m2x4, m2x5},
                    {m3x1, m3x2, m3x3, m3x4, m3x5},
                    {m4x1, m4x2, m4x3, m4x4, m4x5},
                    {m5x1, m5x2, m5x3, m5x4, m5x5}
            });
        return (m[0, 0], m[0, 1], m[0, 2], m[0, 3], m[0, 4],
                m[1, 0], m[1, 1], m[1, 2], m[1, 3], m[1, 4],
                m[2, 0], m[2, 1], m[2, 2], m[2, 3], m[2, 4],
                m[3, 0], m[3, 1], m[3, 2], m[3, 3], m[3, 4],
                m[4, 0], m[4, 1], m[4, 2], m[4, 3], m[4, 4]);
    }

    /// <summary>
    /// Cofactors the matrix.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m1x3">The M1X3.</param>
    /// <param name="m1x4">The M1X4.</param>
    /// <param name="m1x5">The M1X5.</param>
    /// <param name="m1x6">The M1X6.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <param name="m2x3">The M2X3.</param>
    /// <param name="m2x4">The M2X4.</param>
    /// <param name="m2x5">The M2X5.</param>
    /// <param name="m2x6">The M2X6.</param>
    /// <param name="m3x1">The M3X1.</param>
    /// <param name="m3x2">The M3X2.</param>
    /// <param name="m3x3">The M3X3.</param>
    /// <param name="m3x4">The M3X4.</param>
    /// <param name="m3x5">The M3X5.</param>
    /// <param name="m3x6">The M3X6.</param>
    /// <param name="m4x1">The M4X1.</param>
    /// <param name="m4x2">The M4X2.</param>
    /// <param name="m4x3">The M4X3.</param>
    /// <param name="m4x4">The M4X4.</param>
    /// <param name="m4x5">The M4X5.</param>
    /// <param name="m4x6">The M4X6.</param>
    /// <param name="m5x1">The M5X1.</param>
    /// <param name="m5x2">The M5X2.</param>
    /// <param name="m5x3">The M5X3.</param>
    /// <param name="m5x4">The M5X4.</param>
    /// <param name="m5x5">The M5X5.</param>
    /// <param name="m5x6">The M5X6.</param>
    /// <param name="m6x1">The M6X1.</param>
    /// <param name="m6x2">The M6X2.</param>
    /// <param name="m6x3">The M6X3.</param>
    /// <param name="m6x4">The M6X4.</param>
    /// <param name="m6x5">The M6X5.</param>
    /// <param name="m6x6">The M6X6.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5, T m1x6,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5, T m2x6,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5, T m3x6,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5, T m4x6,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5, T m5x6,
        T m6x1, T m6x2, T m6x3, T m6x4, T m6x5, T m6x6)
        CofactorMatrix<T>(
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5, T m1x6,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5, T m2x6,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5, T m3x6,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5, T m4x6,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5, T m5x6,
        T m6x1, T m6x2, T m6x3, T m6x4, T m6x5, T m6x6)
        where T : INumber<T>
    {
        var m = Cofactor<T>(new T[,]
            {
                    {m1x1, m1x2, m1x3, m1x4, m1x5, m1x6},
                    {m2x1, m2x2, m2x3, m2x4, m2x5, m2x6},
                    {m3x1, m3x2, m3x3, m3x4, m3x5, m3x6},
                    {m4x1, m4x2, m4x3, m4x4, m4x5, m4x6},
                    {m5x1, m5x2, m5x3, m5x4, m5x5, m5x6},
                    {m6x1, m6x2, m6x3, m6x4, m6x5, m6x6}
            });
        return (m[0, 0], m[0, 1], m[0, 2], m[0, 3], m[0, 4], m[0, 5],
                m[1, 0], m[1, 1], m[1, 2], m[1, 3], m[1, 4], m[1, 5],
                m[2, 0], m[2, 1], m[2, 2], m[2, 3], m[2, 4], m[2, 5],
                m[3, 0], m[3, 1], m[3, 2], m[3, 3], m[3, 4], m[3, 5],
                m[4, 0], m[4, 1], m[4, 2], m[4, 3], m[4, 4], m[4, 5],
                m[5, 0], m[5, 1], m[5, 2], m[5, 3], m[5, 4], m[5, 5]);
    }
    #endregion Cofactor

    #region Inverse
    /// <summary>
    /// Trick: compute the inverse of a squared matrix using LU decomposition
    /// (LU)^-1 = U^-1 * L^-1
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Inverse<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        if (!IsSquareMatrix(matrix))
        {
            return new T[1, 1];
        }

        (var L, var U) = DecomposeToLowerUpper(matrix);

        var L_inv = InverseLowerMatrix<T>(L);
        var U_inv = InverseUpperMatrix<T>(U);

        return Multiply<T>(U_inv, L_inv);
    }

    /// <summary>
    /// Function to calculate the inverse of the specified matrix.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <exception cref="Exception">Singular matrix, can't find its inverse</exception>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Inverse2<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        // Find determinant of [,]A 
        var det = Determinant(matrix);
        if (det == T.Zero)
        {
            throw new Exception("Singular matrix, can't find its inverse");
        }

        // Find adjoint 
        var adj = Adjoint(matrix);

        var rows = matrix.Height;
        var cols = matrix.Width;
        var inverse = new T[rows, cols];

        // Find Inverse using formula "inverse(A) = adj(A)/det(A)" 
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                inverse[i, j] = adj[i, j] / det;
            }
        }

        return inverse;
    }

    /// <summary>
    /// The invert.
    /// </summary>
    /// <param name="m1x1">The M0X0.</param>
    /// <param name="m1x2">The M0X1.</param>
    /// <param name="m2x1">The M1X0.</param>
    /// <param name="m2x2">The M1X1.</param>
    /// <returns>
    /// The Matrix.
    /// </returns>
    /// <acknowledgment>
    /// https://sites.google.com/site/physics2d/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2,
        T m2x1, T m2x2)
        InverseMatrix<T>(
        T m1x1, T m1x2,
        T m2x1, T m2x2)
        where T : INumber<T>
    {
        var detInv = T.One / ((m1x1 * m2x2) - (m1x2 * m2x1));
        return (
            detInv * m2x2, detInv * -m1x2,
            detInv * -m2x1, detInv * m1x1);
    }

    /// <summary>
    /// The invert.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m1x3">The M1X3.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <param name="m2x3">The M2X3.</param>
    /// <param name="m3x1">The M3X1.</param>
    /// <param name="m3x2">The M3X2.</param>
    /// <param name="m3x3">The M3X3.</param>
    /// <returns>
    /// The Matrix.
    /// </returns>
    /// <acknowledgment>
    /// https://sites.google.com/site/physics2d/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3)
        InverseMatrixr<T>(
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3)
        where T : INumber<T>
    {
        var m11m22m12m21 = (m2x2 * m3x3) - (m2x3 * m3x2);
        var m10m22m12m20 = (m2x1 * m3x3) - (m2x3 * m3x1);
        var m10m21m11m20 = (m2x1 * m3x2) - (m2x2 * m3x1);

        var detInv = T.One / ((m1x1 * m11m22m12m21) - (m1x2 * m10m22m12m20) + (m1x3 * m10m21m11m20));

        return (
            detInv * m11m22m12m21, detInv * (-((m1x2 * m3x3) - (m1x3 * m3x2))), detInv * ((m1x2 * m2x3) - (m1x3 * m2x2)),
            detInv * (-m10m22m12m20), detInv * ((m1x1 * m3x3) - (m1x3 * m3x1)), detInv * (-((m1x1 * m2x3) - (m1x3 * m2x1))),
            detInv * m10m21m11m20, detInv * (-((m1x1 * m3x2) - (m1x2 * m3x1))), detInv * ((m1x1 * m2x2) - (m1x2 * m2x1)));
    }

    /// <summary>
    /// The invert.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m1x3">The M1X3.</param>
    /// <param name="m1x4">The M1X4.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <param name="m2x3">The M2X3.</param>
    /// <param name="m2x4">The M2X4.</param>
    /// <param name="m3x1">The M3X1.</param>
    /// <param name="m3x2">The M3X2.</param>
    /// <param name="m3x3">The M3X3.</param>
    /// <param name="m3x4">The M3X4.</param>
    /// <param name="m4x1">The M4X1.</param>
    /// <param name="m4x2">The M4X2.</param>
    /// <param name="m4x3">The M4X3.</param>
    /// <param name="m4x4">The M4X4.</param>
    /// <returns>
    /// The Matrix.
    /// </returns>
    /// <acknowledgment>
    /// https://sites.google.com/site/physics2d/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4)
        InverseMatrix<T>(
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4)
        where T : INumber<T>
    {
        var m22m33m32m23 = (m3x3 * m4x4) - (m4x3 * m3x4);
        var m21m33m31m23 = (m3x2 * m4x4) - (m4x2 * m3x4);
        var m21m32m31m22 = (m3x2 * m4x3) - (m4x2 * m3x3);

        var m12m33m32m13 = (m2x3 * m4x4) - (m4x3 * m2x4);
        var m11m33m31m13 = (m2x2 * m4x4) - (m4x2 * m2x4);
        var m11m32m31m12 = (m2x2 * m4x3) - (m4x2 * m2x3);

        var m12m23m22m13 = (m2x3 * m3x4) - (m3x3 * m2x4);
        var m11m23m21m13 = (m2x2 * m3x4) - (m3x2 * m2x4);
        var m11m22m21m12 = (m2x2 * m3x3) - (m3x2 * m2x3);

        var m20m33m30m23 = (m3x1 * m4x4) - (m4x1 * m3x4);
        var m20m32m30m22 = (m3x1 * m4x3) - (m4x1 * m3x3);
        var m10m33m30m13 = (m2x1 * m4x4) - (m4x1 * m2x4);

        var m10m32m30m12 = (m2x1 * m4x3) - (m4x1 * m2x3);
        var m10m23m20m13 = (m2x1 * m3x4) - (m3x1 * m2x4);
        var m10m22m20m12 = (m2x1 * m3x3) - (m3x1 * m2x3);

        var m20m31m30m21 = (m3x1 * m4x2) - (m4x1 * m3x2);
        var m10m31m30m11 = (m2x1 * m4x2) - (m4x1 * m2x2);
        var m10m21m20m11 = (m2x1 * m3x2) - (m3x1 * m2x2);

        var detInv = T.One /
        ((m1x1 * ((m2x2 * m22m33m32m23) - (m2x3 * m21m33m31m23) + (m2x4 * m21m32m31m22))) -
        (m1x2 * ((m2x1 * m22m33m32m23) - (m2x3 * m20m33m30m23) + (m2x4 * m20m32m30m22))) +
        (m1x3 * ((m2x1 * m21m33m31m23) - (m2x2 * m20m33m30m23) + (m2x4 * m20m31m30m21))) -
        (m1x4 * ((m2x1 * m21m32m31m22) - (m2x2 * m20m32m30m22) + (m2x3 * m20m31m30m21))));

        return (
            detInv * ((m2x2 * m22m33m32m23) - (m2x3 * m21m33m31m23) + (m2x4 * m21m32m31m22)), detInv * (-((m1x2 * m22m33m32m23) - (m1x3 * m21m33m31m23) + (m1x4 * m21m32m31m22))), detInv * ((m1x2 * m12m33m32m13) - (m1x3 * m11m33m31m13) + (m1x4 * m11m32m31m12)), detInv * (-((m1x2 * m12m23m22m13) - (m1x3 * m11m23m21m13) + (m1x4 * m11m22m21m12))),
            detInv * (-((m2x1 * m22m33m32m23) - (m2x3 * m20m33m30m23) + (m2x4 * m20m32m30m22))), detInv * ((m1x1 * m22m33m32m23) - (m1x3 * m20m33m30m23) + (m1x4 * m20m32m30m22)), detInv * (-((m1x1 * m12m33m32m13) - (m1x3 * m10m33m30m13) + (m1x4 * m10m32m30m12))), detInv * ((m1x1 * m12m23m22m13) - (m1x3 * m10m23m20m13) + (m1x4 * m10m22m20m12)),
            detInv * ((m2x1 * m21m33m31m23) - (m2x2 * m20m33m30m23) + (m2x4 * m20m31m30m21)), detInv * (-((m1x1 * m21m33m31m23) - (m1x2 * m20m33m30m23) + (m1x4 * m20m31m30m21))), detInv * ((m1x1 * m11m33m31m13) - (m1x2 * m10m33m30m13) + (m1x4 * m10m31m30m11)), detInv * (-((m1x1 * m11m23m21m13) - (m1x2 * m10m23m20m13) + (m1x4 * m10m21m20m11))),
            detInv * (-((m2x1 * m21m32m31m22) - (m2x2 * m20m32m30m22) + (m2x3 * m20m31m30m21))), detInv * ((m1x1 * m21m32m31m22) - (m1x2 * m20m32m30m22) + (m1x3 * m20m31m30m21)), detInv * (-((m1x1 * m11m32m31m12) - (m1x2 * m10m32m30m12) + (m1x3 * m10m31m30m11))), detInv * ((m1x1 * m11m22m21m12) - (m1x2 * m10m22m20m12) + (m1x3 * m10m21m20m11)));
    }

    /// <summary>
    /// Inverts the specified M0X0.
    /// </summary>
    /// <param name="m1x1">The M0X0.</param>
    /// <param name="m1x2">The M0X1.</param>
    /// <param name="m1x3">The M0X2.</param>
    /// <param name="m1x4">The M0X3.</param>
    /// <param name="m1x5">The M0X4.</param>
    /// <param name="m2x1">The M1X0.</param>
    /// <param name="m2x2">The M1X1.</param>
    /// <param name="m2x3">The M1X2.</param>
    /// <param name="m2x4">The M1X3.</param>
    /// <param name="m2x5">The M1X4.</param>
    /// <param name="m3x1">The M2X0.</param>
    /// <param name="m3x2">The M2X1.</param>
    /// <param name="m3x3">The M2X2.</param>
    /// <param name="m3x4">The M2X3.</param>
    /// <param name="m3x5">The M2X4.</param>
    /// <param name="m4x1">The M3X0.</param>
    /// <param name="m4x2">The M3X1.</param>
    /// <param name="m4x3">The M3X2.</param>
    /// <param name="m4x4">The M3X3.</param>
    /// <param name="m4x5">The M3X4.</param>
    /// <param name="m5x1">The M4X0.</param>
    /// <param name="m5x2">The M4X1.</param>
    /// <param name="m5x3">The M4X2.</param>
    /// <param name="m5x4">The M4X3.</param>
    /// <param name="m5x5">The M4X4.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5)
        InverseMatrix<T>(
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5)
        where T : INumber<T>
    {
        var m = Inverse<T>(new T[,]
            {
                    {m1x1, m1x2, m1x3, m1x4, m1x5},
                    {m2x1, m2x2, m2x3, m2x4, m2x5},
                    {m3x1, m3x2, m3x3, m3x4, m3x5},
                    {m4x1, m4x2, m4x3, m4x4, m4x5},
                    {m5x1, m5x2, m5x3, m5x4, m5x5}
            });
        return (m[0, 0], m[0, 1], m[0, 2], m[0, 3], m[0, 4],
                m[1, 0], m[1, 1], m[1, 2], m[1, 3], m[1, 4],
                m[2, 0], m[2, 1], m[2, 2], m[2, 3], m[2, 4],
                m[3, 0], m[3, 1], m[3, 2], m[3, 3], m[3, 4],
                m[4, 0], m[4, 1], m[4, 2], m[4, 3], m[4, 4]);
    }

    /// <summary>
    /// Inverts the matrix.
    /// </summary>
    /// <param name="m1x1">The M0X0.</param>
    /// <param name="m1x2">The M0X1.</param>
    /// <param name="m1x3">The M0X2.</param>
    /// <param name="m1x4">The M0X3.</param>
    /// <param name="m1x5">The M0X4.</param>
    /// <param name="m1x6">The M0X5.</param>
    /// <param name="m2x1">The M1X0.</param>
    /// <param name="m2x2">The M1X1.</param>
    /// <param name="m2x3">The M1X2.</param>
    /// <param name="m2x4">The M1X3.</param>
    /// <param name="m2x5">The M1X4.</param>
    /// <param name="m2x6">The M1X5.</param>
    /// <param name="m3x1">The M2X0.</param>
    /// <param name="m3x2">The M2X1.</param>
    /// <param name="m3x3">The M2X2.</param>
    /// <param name="m3x4">The M2X3.</param>
    /// <param name="m3x5">The M2X4.</param>
    /// <param name="m3x6">The M2X5.</param>
    /// <param name="m4x1">The M3X0.</param>
    /// <param name="m4x2">The M3X1.</param>
    /// <param name="m4x3">The M3X2.</param>
    /// <param name="m4x4">The M3X3.</param>
    /// <param name="m4x5">The M3X4.</param>
    /// <param name="m4x6">The M3X5.</param>
    /// <param name="m5x1">The M4X0.</param>
    /// <param name="m5x2">The M4X1.</param>
    /// <param name="m5x3">The M4X2.</param>
    /// <param name="m5x4">The M4X3.</param>
    /// <param name="m5x5">The M4X4.</param>
    /// <param name="m5x6">The M4X5.</param>
    /// <param name="m6x1">The M5X0.</param>
    /// <param name="m6x2">The M5X1.</param>
    /// <param name="m6x3">The M5X2.</param>
    /// <param name="m6x4">The M5X3.</param>
    /// <param name="m6x5">The M5X4.</param>
    /// <param name="m6x6">The M5X5.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5, T m1x6,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5, T m2x6,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5, T m3x6,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5, T m4x6,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5, T m5x6,
        T m6x1, T m6x2, T m6x3, T m6x4, T m6x5, T m6x6)
        InverseMatrix<T>(
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5, T m1x6,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5, T m2x6,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5, T m3x6,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5, T m4x6,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5, T m5x6,
        T m6x1, T m6x2, T m6x3, T m6x4, T m6x5, T m6x6)
        where T : INumber<T>
    {
        var m = Inverse<T>(new T[,]
            {
                    {m1x1, m1x2, m1x3, m1x4, m1x5, m1x6},
                    {m2x1, m2x2, m2x3, m2x4, m2x5, m2x6},
                    {m3x1, m3x2, m3x3, m3x4, m3x5, m3x6},
                    {m4x1, m4x2, m4x3, m4x4, m4x5, m4x6},
                    {m5x1, m5x2, m5x3, m5x4, m5x5, m5x6},
                    {m6x1, m6x2, m6x3, m6x4, m6x5, m6x6}
            });
        return (m[0, 0], m[0, 1], m[0, 2], m[0, 3], m[0, 4], m[0, 5],
                m[1, 0], m[1, 1], m[1, 2], m[1, 3], m[1, 4], m[1, 5],
                m[2, 0], m[2, 1], m[2, 2], m[2, 3], m[2, 4], m[2, 5],
                m[3, 0], m[3, 1], m[3, 2], m[3, 3], m[3, 4], m[3, 5],
                m[4, 0], m[4, 1], m[4, 2], m[4, 3], m[4, 4], m[4, 5],
                m[5, 0], m[5, 1], m[5, 2], m[5, 3], m[5, 4], m[5, 5]);
    }
    #endregion Invert

    #region Inverse Lower Matrix
    /// <summary>
    /// compute and returns the inverse of a lower matrix
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] InverseLowerMatrix<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        if (!IsLowerMatrix(matrix))
        {
            return new T[1, 1];
        }

        var row = matrix.Height;
        var col = matrix.Width;
        var inv = new T[row, 1];

        for (var i = 0; i < row; i++)
        {
            var id = new T[row, 1];
            id[i, 0] = T.One;

            var vect = ResolveLinearEquationLowerTriangularMatrix(matrix, id);
            inv = ConcatenationColumns<T>(inv, vect);
        }

        return Truncate<T>(inv, 1, row, 2, col + 1);
    }
    #endregion

    #region Inverse Upper Matrix
    /// <summary>
    /// compute and returns the inverse of an upper matrix
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] InverseUpperMatrix<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        if (!IsUpperMatrix(matrix))
        {
            return new T[1, 1];
        }

        var row = matrix.Height;
        var col = matrix.Width;
        var inv = new T[row, 1];

        for (var i = 0; i < row; i++)
        {
            var id = new T[row, 1];
            id[i, 0] = T.One;

            var vect = ResolveLinearEquation_UpperTriangularMatrix(matrix, id);
            inv = ConcatenationColumns<T>(inv, vect);
        }

        return Truncate<T>(inv, 1, row, 2, col + 1);
    }
    #endregion

    #region Determinant
    /// <summary>
    /// Recursive function for finding determinant of matrix.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.geeksforgeeks.org/determinant-of-a-matrix/
    /// https://www.geeksforgeeks.org/adjoint-inverse-matrix/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Determinant<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var rows = matrix.Height;
        //var cols = matrix.GetLength(1);

        var result = T.Zero; // Initialize result 

        // Base case : if matrix contains single element 
        if (rows == 1)
        {
            return matrix[0, 0];
        }

        var sign = T.One; // To store sign multiplier 

        // Iterate for each element of first row 
        for (var f = 0; f < rows; f++)
        {
            // Getting Cofactor of A[0,f] 
            var temp = Cofactor(matrix, 0, f);
            result += sign * matrix[0, f] * Determinant<T>(temp);

            // terms are to be added with alternate sign 
            sign = -sign;
        }

        return result;
    }

    /// <summary>
    /// Find the determinant of a 2 by 2 matrix.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MatrixDeterminant<T>(
        T m1x1, T m1x2,
        T m2x1, T m2x2)
        where T : INumber<T>
        => (m1x1 * m2x2)
          - (m1x2 * m2x1);

    /// <summary>
    /// Find the determinant of a 3 by 3 matrix.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m1x3">The M1X3.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <param name="m2x3">The M2X3.</param>
    /// <param name="m3x1">The M3X1.</param>
    /// <param name="m3x2">The M3X2.</param>
    /// <param name="m3x3">The M3X3.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://sites.google.com/site/physics2d/
    /// This is an expanded version of the Ogre determinant() method, to give better performance in C#. Generated using a script.
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MatrixDeterminant<T>(
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3)
        where T : INumber<T>
        => (m1x1 * ((m2x2 * m3x3) - (m2x3 * m3x2)))
         - (m1x2 * ((m2x1 * m3x3) - (m2x3 * m3x1)))
         + (m1x3 * ((m2x1 * m3x2) - (m2x2 * m3x1)));

    /// <summary>
    /// Find the determinant of a 4 by 4 matrix.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m1x3">The M1X3.</param>
    /// <param name="m1x4">The M1X4.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <param name="m2x3">The M2X3.</param>
    /// <param name="m2x4">The M2X4.</param>
    /// <param name="m3x1">The M3X1.</param>
    /// <param name="m3x2">The M3X2.</param>
    /// <param name="m3x3">The M3X3.</param>
    /// <param name="m3x4">The M3X4.</param>
    /// <param name="m4x1">The M4X1.</param>
    /// <param name="m4x2">The M4X2.</param>
    /// <param name="m4x3">The M4X3.</param>
    /// <param name="m4x4">The M4X4.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://sites.google.com/site/physics2d/
    /// This is an expanded version of the Ogre determinant() method, to give better performance in C#. Generated using a script.
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MatrixDeterminant<T>(
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4)
        where T : INumber<T>
        => (m1x1 * ((m2x2 * ((m3x3 * m4x4) - (m4x3 * m3x4))) - (m2x3 * ((m3x2 * m4x4) - (m4x2 * m3x4))) + (m2x4 * ((m3x2 * m4x3) - (m4x2 * m3x3)))))
         - (m1x2 * ((m2x1 * ((m3x3 * m4x4) - (m4x3 * m3x4))) - (m2x3 * ((m3x1 * m4x4) - (m4x1 * m3x4))) + (m2x4 * ((m3x1 * m4x3) - (m4x1 * m3x3)))))
         + (m1x3 * ((m2x1 * ((m3x2 * m4x4) - (m4x2 * m3x4))) - (m2x2 * ((m3x1 * m4x4) - (m4x1 * m3x4))) + (m2x4 * ((m3x1 * m4x2) - (m4x1 * m3x2)))))
         - (m1x4 * ((m2x1 * ((m3x2 * m4x3) - (m4x2 * m3x3))) - (m2x2 * ((m3x1 * m4x3) - (m4x1 * m3x3))) + (m2x3 * ((m3x1 * m4x2) - (m4x1 * m3x2)))));

    /// <summary>
    /// Find the determinant of a 5 by 5 matrix.
    /// </summary>
    /// <param name="m1x1">The M1X1.</param>
    /// <param name="m1x2">The M1X2.</param>
    /// <param name="m1x3">The M1X3.</param>
    /// <param name="m1x4">The M1X4.</param>
    /// <param name="m1x5">The M1X5.</param>
    /// <param name="m2x1">The M2X1.</param>
    /// <param name="m2x2">The M2X2.</param>
    /// <param name="m2x3">The M2X3.</param>
    /// <param name="m2x4">The M2X4.</param>
    /// <param name="m2x5">The M2X5.</param>
    /// <param name="m3x1">The M3X1.</param>
    /// <param name="m3x2">The M3X2.</param>
    /// <param name="m3x3">The M3X3.</param>
    /// <param name="m3x4">The M3X4.</param>
    /// <param name="m3x5">The M3X5.</param>
    /// <param name="m4x1">The M4X1.</param>
    /// <param name="m4x2">The M4X2.</param>
    /// <param name="m4x3">The M4X3.</param>
    /// <param name="m4x4">The M4X4.</param>
    /// <param name="m4x5">The M4X5.</param>
    /// <param name="m5x1">The M5X1.</param>
    /// <param name="m5x2">The M5X2.</param>
    /// <param name="m5x3">The M5X3.</param>
    /// <param name="m5x4">The M5X4.</param>
    /// <param name="m5x5">The M5X5.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MatrixDeterminant<T>(
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5)
        where T : INumber<T>
        => (m1x1 * MatrixDeterminant(m2x2, m2x3, m2x4, m2x5, m3x2, m3x3, m3x4, m3x5, m4x2, m4x3, m4x4, m4x5, m5x2, m5x3, m5x4, m5x5))
         - (m1x2 * MatrixDeterminant(m2x1, m2x3, m2x4, m2x5, m3x1, m3x3, m3x4, m3x5, m4x1, m4x3, m4x4, m4x5, m5x1, m5x3, m5x4, m5x5))
         + (m1x3 * MatrixDeterminant(m2x1, m2x2, m2x4, m2x5, m3x1, m3x2, m3x4, m3x5, m4x1, m4x2, m4x4, m4x5, m5x1, m5x2, m5x4, m5x5))
         - (m1x4 * MatrixDeterminant(m2x1, m2x2, m2x3, m2x5, m3x1, m3x2, m3x3, m3x5, m4x1, m4x2, m4x3, m4x5, m5x1, m5x2, m5x3, m5x5))
         + (m1x5 * MatrixDeterminant(m2x1, m2x2, m2x3, m2x4, m3x1, m3x2, m3x3, m3x4, m4x1, m4x2, m4x3, m4x4, m5x1, m5x2, m5x3, m5x4));

    /// <summary>
    /// Find the determinant of a 6 by 6 matrix.
    /// </summary>
    /// <param name="m1x1">a.</param>
    /// <param name="m1x2">The b.</param>
    /// <param name="m1x3">The c.</param>
    /// <param name="m1x4">The d.</param>
    /// <param name="m1x5">The e.</param>
    /// <param name="m1x6">The f.</param>
    /// <param name="m2x1">The g.</param>
    /// <param name="m2x2">The h.</param>
    /// <param name="m2x3">The i.</param>
    /// <param name="m2x4">The j.</param>
    /// <param name="m2x5">The k.</param>
    /// <param name="m2x6">The l.</param>
    /// <param name="m3x1">The m.</param>
    /// <param name="m3x2">The n.</param>
    /// <param name="m3x3">The o.</param>
    /// <param name="m3x4">The p.</param>
    /// <param name="m3x5">The q.</param>
    /// <param name="m3x6">The r.</param>
    /// <param name="m4x1">The s.</param>
    /// <param name="m4x2">The t.</param>
    /// <param name="m4x3">The u.</param>
    /// <param name="m4x4">The v.</param>
    /// <param name="m4x5">The w.</param>
    /// <param name="m4x6">The x.</param>
    /// <param name="m5x1">The y.</param>
    /// <param name="m5x2">The z.</param>
    /// <param name="m5x3">The aa.</param>
    /// <param name="m5x4">The bb.</param>
    /// <param name="m5x5">The cc.</param>
    /// <param name="m5x6">The dd.</param>
    /// <param name="m6x1">The ee.</param>
    /// <param name="m6x2">The ff.</param>
    /// <param name="m6x3">The gg.</param>
    /// <param name="m6x4">The hh.</param>
    /// <param name="m6x5">The ii.</param>
    /// <param name="m6x6">The jj.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MatrixDeterminant<T>(
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5, T m1x6,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5, T m2x6,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5, T m3x6,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5, T m4x6,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5, T m5x6,
        T m6x1, T m6x2, T m6x3, T m6x4, T m6x5, T m6x6)
        where T : INumber<T>
        => (m1x1 * MatrixDeterminant(m2x2, m2x3, m2x4, m2x5, m2x6, m3x2, m3x3, m3x4, m3x5, m3x6, m4x2, m4x3, m4x4, m4x5, m4x6, m5x2, m5x3, m5x4, m5x5, m5x6, m6x2, m6x3, m6x4, m6x5, m6x6))
         - (m1x2 * MatrixDeterminant(m2x1, m2x3, m2x4, m2x5, m2x6, m3x1, m3x3, m3x4, m3x5, m3x6, m4x1, m4x3, m4x4, m4x5, m4x6, m5x1, m5x3, m5x4, m5x5, m5x6, m6x1, m6x3, m6x4, m6x5, m6x6))
         + (m1x3 * MatrixDeterminant(m2x1, m2x2, m2x4, m2x5, m2x6, m3x1, m3x2, m3x4, m3x5, m3x6, m4x1, m4x2, m4x4, m4x5, m4x6, m5x1, m5x2, m5x4, m5x5, m5x6, m6x1, m6x2, m6x4, m6x5, m6x6))
         - (m1x4 * MatrixDeterminant(m2x1, m2x2, m2x3, m2x5, m2x6, m3x1, m3x2, m3x3, m3x5, m3x6, m4x1, m4x2, m4x3, m4x5, m4x6, m5x1, m5x2, m5x3, m5x5, m5x6, m6x1, m6x2, m6x3, m6x5, m6x6))
         + (m1x5 * MatrixDeterminant(m2x1, m2x2, m2x3, m2x4, m2x6, m3x1, m3x2, m3x3, m3x4, m3x6, m4x1, m4x2, m4x3, m4x4, m4x6, m5x1, m5x2, m5x3, m5x4, m5x6, m6x1, m6x2, m6x3, m6x4, m6x6))
         - (m1x6 * MatrixDeterminant(m2x1, m2x2, m2x3, m2x4, m2x5, m3x1, m3x2, m3x3, m3x4, m3x5, m4x1, m4x2, m4x3, m4x4, m4x5, m5x1, m5x2, m5x3, m5x4, m5x5, m6x1, m6x2, m6x3, m6x4, m6x5));
    #endregion Determinant

    #region Inverse Determinant
    /// <summary>
    /// Find the inverse of the determinant of a 2 by 2 matrix.
    /// </summary>
    /// <param name="m1x1">a.</param>
    /// <param name="m1x2">The b.</param>
    /// <param name="m2x1">The c.</param>
    /// <param name="m2x2">The d.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MatrixInverseDeterminant<T>(
        T m1x1, T m1x2,
        T m2x1, T m2x2)
        where T : INumber<T>
        => T.One / ((m1x1 * m2x2)
          - (m1x2 * m2x1));

    /// <summary>
    /// Find the inverse of the determinant of a 3 by 3 matrix.
    /// </summary>
    /// <param name="m1x1">a.</param>
    /// <param name="m1x2">The b.</param>
    /// <param name="m1x3">The c.</param>
    /// <param name="m2x1">The d.</param>
    /// <param name="m2x2">The e.</param>
    /// <param name="m2x3">The f.</param>
    /// <param name="m3x1">The g.</param>
    /// <param name="m3x2">The h.</param>
    /// <param name="m3x3">The i.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MatrixInverseDeterminant<T>(
        T m1x1, T m1x2, T m1x3,
        T m2x1, T m2x2, T m2x3,
        T m3x1, T m3x2, T m3x3)
        where T : INumber<T>
        => T.One / ((m1x1 * MatrixDeterminant(m2x2, m2x3, m3x2, m3x3))
          - (m1x2 * MatrixDeterminant(m2x1, m2x3, m3x1, m3x3))
          + (m1x3 * MatrixDeterminant(m2x1, m2x2, m3x1, m3x2)));

    /// <summary>
    /// Find the inverse of the determinant of a 4 by 4 matrix.
    /// </summary>
    /// <param name="m1x1">a.</param>
    /// <param name="m1x2">The b.</param>
    /// <param name="m1x3">The c.</param>
    /// <param name="m1x4">The d.</param>
    /// <param name="m2x1">The e.</param>
    /// <param name="m2x2">The f.</param>
    /// <param name="m2x3">The g.</param>
    /// <param name="m2x4">The h.</param>
    /// <param name="m3x1">The i.</param>
    /// <param name="m3x2">The j.</param>
    /// <param name="m3x3">The k.</param>
    /// <param name="m3x4">The l.</param>
    /// <param name="m4x1">The m.</param>
    /// <param name="m4x2">The n.</param>
    /// <param name="m4x3">The o.</param>
    /// <param name="m4x4">The p.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/onlyuser/Legacy/blob/master/msvb/Dex3d/Math.bas
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MatrixInverseDeterminant<T>(
        T m1x1, T m1x2, T m1x3, T m1x4,
        T m2x1, T m2x2, T m2x3, T m2x4,
        T m3x1, T m3x2, T m3x3, T m3x4,
        T m4x1, T m4x2, T m4x3, T m4x4)
        where T : INumber<T>
        => T.One / ((m1x1 * MatrixDeterminant(m2x2, m2x3, m2x4, m3x2, m3x3, m3x4, m4x2, m4x3, m4x4))
          - (m1x2 * MatrixDeterminant(m2x1, m2x3, m2x4, m3x1, m3x3, m3x4, m4x1, m4x3, m4x4))
          + (m1x3 * MatrixDeterminant(m2x1, m2x2, m2x4, m3x1, m3x2, m3x4, m4x1, m4x2, m4x4))
          - (m1x4 * MatrixDeterminant(m2x1, m2x2, m2x3, m3x1, m3x2, m3x3, m4x1, m4x2, m4x3)));

    /// <summary>
    /// Find the inverse of the determinant of a 5 by 5 matrix.
    /// </summary>
    /// <param name="m1x1">a.</param>
    /// <param name="m1x2">The b.</param>
    /// <param name="m1x3">The c.</param>
    /// <param name="m1x4">The d.</param>
    /// <param name="m1x5">The e.</param>
    /// <param name="m2x1">The f.</param>
    /// <param name="m2x2">The g.</param>
    /// <param name="m2x3">The h.</param>
    /// <param name="m2x4">The i.</param>
    /// <param name="m2x5">The j.</param>
    /// <param name="m3x1">The k.</param>
    /// <param name="m3x2">The l.</param>
    /// <param name="m3x3">The m.</param>
    /// <param name="m3x4">The n.</param>
    /// <param name="m3x5">The o.</param>
    /// <param name="m4x1">The p.</param>
    /// <param name="m4x2">The q.</param>
    /// <param name="m4x3">The r.</param>
    /// <param name="m4x4">The s.</param>
    /// <param name="m4x5">The t.</param>
    /// <param name="m5x1">The u.</param>
    /// <param name="m5x2">The v.</param>
    /// <param name="m5x3">The w.</param>
    /// <param name="m5x4">The x.</param>
    /// <param name="m5x5">The y.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MatrixInverseDeterminant<T>(
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5)
        where T : INumber<T>
        => T.One / ((m1x1 * MatrixDeterminant(m2x2, m2x3, m2x4, m2x5, m3x2, m3x3, m3x4, m3x5, m4x2, m4x3, m4x4, m4x5, m5x2, m5x3, m5x4, m5x5))
          - (m1x2 * MatrixDeterminant(m2x1, m2x3, m2x4, m2x5, m3x1, m3x3, m3x4, m3x5, m4x1, m4x3, m4x4, m4x5, m5x1, m5x3, m5x4, m5x5))
          + (m1x3 * MatrixDeterminant(m2x1, m2x2, m2x4, m2x5, m3x1, m3x2, m3x4, m3x5, m4x1, m4x2, m4x4, m4x5, m5x1, m5x2, m5x4, m5x5))
          - (m1x4 * MatrixDeterminant(m2x1, m2x2, m2x3, m2x5, m3x1, m3x2, m3x3, m3x5, m4x1, m4x2, m4x3, m4x5, m5x1, m5x2, m5x3, m5x5))
          + (m1x5 * MatrixDeterminant(m2x1, m2x2, m2x3, m2x4, m3x1, m3x2, m3x3, m3x4, m4x1, m4x2, m4x3, m4x4, m5x1, m5x2, m5x3, m5x4)));

    /// <summary>
    /// Find the inverse of the determinant of a 6 by 6 matrix.
    /// </summary>
    /// <param name="m1x1">a.</param>
    /// <param name="m1x2">The b.</param>
    /// <param name="m1x3">The c.</param>
    /// <param name="m1x4">The d.</param>
    /// <param name="m1x5">The e.</param>
    /// <param name="m1x6">The f.</param>
    /// <param name="m2x1">The g.</param>
    /// <param name="m2x2">The h.</param>
    /// <param name="m2x3">The i.</param>
    /// <param name="m2x4">The j.</param>
    /// <param name="m2x5">The k.</param>
    /// <param name="m2x6">The l.</param>
    /// <param name="m3x1">The m.</param>
    /// <param name="m3x2">The n.</param>
    /// <param name="m3x3">The o.</param>
    /// <param name="m3x4">The p.</param>
    /// <param name="m3x5">The q.</param>
    /// <param name="m3x6">The r.</param>
    /// <param name="m4x1">The s.</param>
    /// <param name="m4x2">The t.</param>
    /// <param name="m4x3">The u.</param>
    /// <param name="m4x4">The v.</param>
    /// <param name="m4x5">The w.</param>
    /// <param name="m4x6">The x.</param>
    /// <param name="m5x1">The y.</param>
    /// <param name="m5x2">The z.</param>
    /// <param name="m5x3">The aa.</param>
    /// <param name="m5x4">The bb.</param>
    /// <param name="m5x5">The cc.</param>
    /// <param name="m5x6">The dd.</param>
    /// <param name="m6x1">The ee.</param>
    /// <param name="m6x2">The ff.</param>
    /// <param name="m6x3">The gg.</param>
    /// <param name="m6x4">The hh.</param>
    /// <param name="m6x5">The ii.</param>
    /// <param name="m6x6">The jj.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MatrixInverseDeterminant<T>(
        T m1x1, T m1x2, T m1x3, T m1x4, T m1x5, T m1x6,
        T m2x1, T m2x2, T m2x3, T m2x4, T m2x5, T m2x6,
        T m3x1, T m3x2, T m3x3, T m3x4, T m3x5, T m3x6,
        T m4x1, T m4x2, T m4x3, T m4x4, T m4x5, T m4x6,
        T m5x1, T m5x2, T m5x3, T m5x4, T m5x5, T m5x6,
        T m6x1, T m6x2, T m6x3, T m6x4, T m6x5, T m6x6)
        where T : INumber<T>
        => T.One / ((m1x1 * MatrixDeterminant(m2x2, m2x3, m2x4, m2x5, m2x6, m3x2, m3x3, m3x4, m3x5, m3x6, m4x2, m4x3, m4x4, m4x5, m4x6, m5x2, m5x3, m5x4, m5x5, m5x6, m6x2, m6x3, m6x4, m6x5, m6x6))
          - (m1x2 * MatrixDeterminant(m2x1, m2x3, m2x4, m2x5, m2x6, m3x1, m3x3, m3x4, m3x5, m3x6, m4x1, m4x3, m4x4, m4x5, m4x6, m5x1, m5x3, m5x4, m5x5, m5x6, m6x1, m6x3, m6x4, m6x5, m6x6))
          + (m1x3 * MatrixDeterminant(m2x1, m2x2, m2x4, m2x5, m2x6, m3x1, m3x2, m3x4, m3x5, m3x6, m4x1, m4x2, m4x4, m4x5, m4x6, m5x1, m5x2, m5x4, m5x5, m5x6, m6x1, m6x2, m6x4, m6x5, m6x6))
          - (m1x4 * MatrixDeterminant(m2x1, m2x2, m2x3, m2x5, m2x6, m3x1, m3x2, m3x3, m3x5, m3x6, m4x1, m4x2, m4x3, m4x5, m4x6, m5x1, m5x2, m5x3, m5x5, m5x6, m6x1, m6x2, m6x3, m6x5, m6x6))
          + (m1x5 * MatrixDeterminant(m2x1, m2x2, m2x3, m2x4, m2x6, m3x1, m3x2, m3x3, m3x4, m3x6, m4x1, m4x2, m4x3, m4x4, m4x6, m5x1, m5x2, m5x3, m5x4, m5x6, m6x1, m6x2, m6x3, m6x4, m6x6))
          - (m1x6 * MatrixDeterminant(m2x1, m2x2, m2x3, m2x4, m2x5, m3x1, m3x2, m3x3, m3x4, m3x5, m4x1, m4x2, m4x3, m4x4, m4x5, m5x1, m5x2, m5x3, m5x4, m5x5, m6x1, m6x2, m6x3, m6x4, m6x5)));
    #endregion Inverse Determinant

    #region Dot Product
    /// <summary>
    /// Dots the product.
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>(Span2D<T> a, Span2D<T> b)
        where T : INumber<T>
    {
        var rowsA = a.Height;
        var colsA = a.Width;
        var rowsB = b.Height;
        var colsB = b.Width;

        if (rowsA != rowsB || colsA != colsB)
        {
            throw new Exception();
        }

        T result = T.Zero;
        for (var i = 0; i < rowsA; i++)
        {
            for (var j = 0; j < colsA; j++)
            {
                result += a[i, j] * b[i, j];
            }
        }

        return result;
    }

    /// <summary>
    /// Dots the product matrix2x2.
    /// </summary>
    /// <param name="m1x1A">The M1X1 a.</param>
    /// <param name="m1x2A">The M1X2 a.</param>
    /// <param name="m2x1A">The M2X1 a.</param>
    /// <param name="m2x2A">The M2X2 a.</param>
    /// <param name="m1x1B">The M1X1 b.</param>
    /// <param name="m1x2B">The M1X2 b.</param>
    /// <param name="m2x1B">The M2X1 b.</param>
    /// <param name="m2x2B">The M2X2 b.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.physicsforums.com/threads/dot-product-2x2-matrix.688717/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProductMatrix2x2<T>(
        T m1x1A, T m1x2A,
        T m2x1A, T m2x2A,
        T m1x1B, T m1x2B,
        T m2x1B, T m2x2B)
        where T : INumber<T>
        => (m1x1A * m1x1B) + (m1x2A * m1x2B)
         + (m2x1A * m2x1B) + (m2x2A * m2x2B);

    /// <summary>
    /// Dots the product matrix3x3.
    /// </summary>
    /// <param name="m1x1A">The M1X1 a.</param>
    /// <param name="m1x2A">The M1X2 a.</param>
    /// <param name="m1x3A">The M1X3 a.</param>
    /// <param name="m2x1A">The M2X1 a.</param>
    /// <param name="m2x2A">The M2X2 a.</param>
    /// <param name="m2x3A">The M2X3 a.</param>
    /// <param name="m3x1A">The M3X1 a.</param>
    /// <param name="m3x2A">The M3X2 a.</param>
    /// <param name="m3x3A">The M3X3 a.</param>
    /// <param name="m1x1B">The M1X1 b.</param>
    /// <param name="m1x2B">The M1X2 b.</param>
    /// <param name="m1x3B">The M1X3 b.</param>
    /// <param name="m2x1B">The M2X1 b.</param>
    /// <param name="m2x2B">The M2X2 b.</param>
    /// <param name="m2x3B">The M2X3 b.</param>
    /// <param name="m3x1B">The M3X1 b.</param>
    /// <param name="m3x2B">The M3X2 b.</param>
    /// <param name="m3x3B">The M3X3 b.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.physicsforums.com/threads/dot-product-2x2-matrix.688717/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProductMatrix3x3<T>(
        T m1x1A, T m1x2A, T m1x3A,
        T m2x1A, T m2x2A, T m2x3A,
        T m3x1A, T m3x2A, T m3x3A,
        T m1x1B, T m1x2B, T m1x3B,
        T m2x1B, T m2x2B, T m2x3B,
        T m3x1B, T m3x2B, T m3x3B)
        where T : INumber<T>
        => (m1x1A * m1x1B) + (m1x2A * m1x2B) + (m1x3A * m1x3B)
         + (m2x1A * m2x1B) + (m2x2A * m2x2B) + (m2x3A * m2x3B)
         + (m3x1A * m3x1B) + (m3x2A * m3x2B) + (m3x3A * m3x3B);

    /// <summary>
    /// Dots the product matrix4x4.
    /// </summary>
    /// <param name="m1x1A">The M1X1 a.</param>
    /// <param name="m1x2A">The M1X2 a.</param>
    /// <param name="m1x3A">The M1X3 a.</param>
    /// <param name="m1x4A">The M1X4 a.</param>
    /// <param name="m2x1A">The M2X1 a.</param>
    /// <param name="m2x2A">The M2X2 a.</param>
    /// <param name="m2x3A">The M2X3 a.</param>
    /// <param name="m2x4A">The M2X4 a.</param>
    /// <param name="m3x1A">The M3X1 a.</param>
    /// <param name="m3x2A">The M3X2 a.</param>
    /// <param name="m3x3A">The M3X3 a.</param>
    /// <param name="m3x4A">The M3X4 a.</param>
    /// <param name="m4x1A">The M4X1 a.</param>
    /// <param name="m4x2A">The M4X2 a.</param>
    /// <param name="m4x3A">The M4X3 a.</param>
    /// <param name="m4x4A">The M4X4 a.</param>
    /// <param name="m1x1B">The M1X1 b.</param>
    /// <param name="m1x2B">The M1X2 b.</param>
    /// <param name="m1x3B">The M1X3 b.</param>
    /// <param name="m1x4B">The M1X4 b.</param>
    /// <param name="m2x1B">The M2X1 b.</param>
    /// <param name="m2x2B">The M2X2 b.</param>
    /// <param name="m2x3B">The M2X3 b.</param>
    /// <param name="m2x4B">The M2X4 b.</param>
    /// <param name="m3x1B">The M3X1 b.</param>
    /// <param name="m3x2B">The M3X2 b.</param>
    /// <param name="m3x3B">The M3X3 b.</param>
    /// <param name="m3x4B">The M3X4 b.</param>
    /// <param name="m4x1B">The M4X1 b.</param>
    /// <param name="m4x2B">The M4X2 b.</param>
    /// <param name="m4x3B">The M4X3 b.</param>
    /// <param name="m4x4B">The M4X4 b.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.physicsforums.com/threads/dot-product-2x2-matrix.688717/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProductMatrix4x4<T>(
        T m1x1A, T m1x2A, T m1x3A, T m1x4A,
        T m2x1A, T m2x2A, T m2x3A, T m2x4A,
        T m3x1A, T m3x2A, T m3x3A, T m3x4A,
        T m4x1A, T m4x2A, T m4x3A, T m4x4A,
        T m1x1B, T m1x2B, T m1x3B, T m1x4B,
        T m2x1B, T m2x2B, T m2x3B, T m2x4B,
        T m3x1B, T m3x2B, T m3x3B, T m3x4B,
        T m4x1B, T m4x2B, T m4x3B, T m4x4B)
        where T : INumber<T>
        => (m1x1A * m1x1B) + (m1x2A * m1x2B) + (m1x3A * m1x3B) + (m1x4A * m1x4B)
         + (m2x1A * m2x1B) + (m2x2A * m2x2B) + (m2x3A * m2x3B) + (m2x4A * m2x4B)
         + (m3x1A * m3x1B) + (m3x2A * m3x2B) + (m3x3A * m3x3B) + (m3x4A * m3x4B)
         + (m4x1A * m4x1B) + (m4x2A * m4x2B) + (m4x3A * m4x3B) + (m4x4A * m4x4B);

    /// <summary>
    /// Dots the product matrix5x5.
    /// </summary>
    /// <param name="m1x1A">The M1X1 a.</param>
    /// <param name="m1x2A">The M1X2 a.</param>
    /// <param name="m1x3A">The M1X3 a.</param>
    /// <param name="m1x4A">The M1X4 a.</param>
    /// <param name="m1x5A">The M1X5 a.</param>
    /// <param name="m2x1A">The M2X1 a.</param>
    /// <param name="m2x2A">The M2X2 a.</param>
    /// <param name="m2x3A">The M2X3 a.</param>
    /// <param name="m2x4A">The M2X4 a.</param>
    /// <param name="m2x5A">The M2X5 a.</param>
    /// <param name="m3x1A">The M3X1 a.</param>
    /// <param name="m3x2A">The M3X2 a.</param>
    /// <param name="m3x3A">The M3X3 a.</param>
    /// <param name="m3x4A">The M3X4 a.</param>
    /// <param name="m3x5A">The M3X5 a.</param>
    /// <param name="m4x1A">The M4X1 a.</param>
    /// <param name="m4x2A">The M4X2 a.</param>
    /// <param name="m4x3A">The M4X3 a.</param>
    /// <param name="m4x4A">The M4X4 a.</param>
    /// <param name="m4x5A">The M4X5 a.</param>
    /// <param name="m5x1A">The M5X1 a.</param>
    /// <param name="m5x2A">The M5X2 a.</param>
    /// <param name="m5x3A">The M5X3 a.</param>
    /// <param name="m5x4A">The M5X4 a.</param>
    /// <param name="m5x5A">The M5X5 a.</param>
    /// <param name="m1x1B">The M1X1 b.</param>
    /// <param name="m1x2B">The M1X2 b.</param>
    /// <param name="m1x3B">The M1X3 b.</param>
    /// <param name="m1x4B">The M1X4 b.</param>
    /// <param name="m1x5B">The M1X5 b.</param>
    /// <param name="m2x1B">The M2X1 b.</param>
    /// <param name="m2x2B">The M2X2 b.</param>
    /// <param name="m2x3B">The M2X3 b.</param>
    /// <param name="m2x4B">The M2X4 b.</param>
    /// <param name="m2x5B">The M2X5 b.</param>
    /// <param name="m3x1B">The M3X1 b.</param>
    /// <param name="m3x2B">The M3X2 b.</param>
    /// <param name="m3x3B">The M3X3 b.</param>
    /// <param name="m3x4B">The M3X4 b.</param>
    /// <param name="m3x5B">The M3X5 b.</param>
    /// <param name="m4x1B">The M4X1 b.</param>
    /// <param name="m4x2B">The M4X2 b.</param>
    /// <param name="m4x3B">The M4X3 b.</param>
    /// <param name="m4x4B">The M4X4 b.</param>
    /// <param name="m4x5B">The M4X5 b.</param>
    /// <param name="m5x1B">The M5X1 b.</param>
    /// <param name="m5x2B">The M5X2 b.</param>
    /// <param name="m5x3B">The M5X3 b.</param>
    /// <param name="m5x4B">The M5X4 b.</param>
    /// <param name="m5x5B">The M5X5 b.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.physicsforums.com/threads/dot-product-2x2-matrix.688717/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProductMatrix5x5<T>(
        T m1x1A, T m1x2A, T m1x3A, T m1x4A, T m1x5A,
        T m2x1A, T m2x2A, T m2x3A, T m2x4A, T m2x5A,
        T m3x1A, T m3x2A, T m3x3A, T m3x4A, T m3x5A,
        T m4x1A, T m4x2A, T m4x3A, T m4x4A, T m4x5A,
        T m5x1A, T m5x2A, T m5x3A, T m5x4A, T m5x5A,
        T m1x1B, T m1x2B, T m1x3B, T m1x4B, T m1x5B,
        T m2x1B, T m2x2B, T m2x3B, T m2x4B, T m2x5B,
        T m3x1B, T m3x2B, T m3x3B, T m3x4B, T m3x5B,
        T m4x1B, T m4x2B, T m4x3B, T m4x4B, T m4x5B,
        T m5x1B, T m5x2B, T m5x3B, T m5x4B, T m5x5B)
        where T : INumber<T>
        => (m1x1A * m1x1B) + (m1x2A * m1x2B) + (m1x3A * m1x3B) + (m1x4A * m1x4B) + (m1x5A * m1x5B)
         + (m2x1A * m2x1B) + (m2x2A * m2x2B) + (m2x3A * m2x3B) + (m2x4A * m2x4B) + (m2x5A * m2x5B)
         + (m3x1A * m3x1B) + (m3x2A * m3x2B) + (m3x3A * m3x3B) + (m3x4A * m3x4B) + (m3x5A * m3x5B)
         + (m4x1A * m4x1B) + (m4x2A * m4x2B) + (m4x3A * m4x3B) + (m4x4A * m4x4B) + (m4x5A * m4x5B)
         + (m5x1A * m5x1B) + (m5x2A * m5x2B) + (m5x3A * m5x3B) + (m5x4A * m5x4B) + (m5x5A * m5x5B);

    /// <summary>
    /// Dots the product matrix6x6.
    /// </summary>
    /// <param name="m1x1A">The M1X1 a.</param>
    /// <param name="m1x2A">The M1X2 a.</param>
    /// <param name="m1x3A">The M1X3 a.</param>
    /// <param name="m1x4A">The M1X4 a.</param>
    /// <param name="m1x5A">The M1X5 a.</param>
    /// <param name="m1x6A">The M1X6 a.</param>
    /// <param name="m2x1A">The M2X1 a.</param>
    /// <param name="m2x2A">The M2X2 a.</param>
    /// <param name="m2x3A">The M2X3 a.</param>
    /// <param name="m2x4A">The M2X4 a.</param>
    /// <param name="m2x5A">The M2X5 a.</param>
    /// <param name="m2x6A">The M2X6 a.</param>
    /// <param name="m3x1A">The M3X1 a.</param>
    /// <param name="m3x2A">The M3X2 a.</param>
    /// <param name="m3x3A">The M3X3 a.</param>
    /// <param name="m3x4A">The M3X4 a.</param>
    /// <param name="m3x5A">The M3X5 a.</param>
    /// <param name="m3x6A">The M3X6 a.</param>
    /// <param name="m4x1A">The M4X1 a.</param>
    /// <param name="m4x2A">The M4X2 a.</param>
    /// <param name="m4x3A">The M4X3 a.</param>
    /// <param name="m4x4A">The M4X4 a.</param>
    /// <param name="m4x5A">The M4X5 a.</param>
    /// <param name="m4x6A">The M4X6 a.</param>
    /// <param name="m5x1A">The M5X1 a.</param>
    /// <param name="m5x2A">The M5X2 a.</param>
    /// <param name="m5x3A">The M5X3 a.</param>
    /// <param name="m5x4A">The M5X4 a.</param>
    /// <param name="m5x5A">The M5X5 a.</param>
    /// <param name="m5x6A">The M5X6 a.</param>
    /// <param name="m6x1A">The M6X1 a.</param>
    /// <param name="m6x2A">The M6X2 a.</param>
    /// <param name="m6x3A">The M6X3 a.</param>
    /// <param name="m6x4A">The M6X4 a.</param>
    /// <param name="m6x5A">The M6X5 a.</param>
    /// <param name="m6x6A">The M6X6 a.</param>
    /// <param name="m1x1B">The M1X1 b.</param>
    /// <param name="m1x2B">The M1X2 b.</param>
    /// <param name="m1x3B">The M1X3 b.</param>
    /// <param name="m1x4B">The M1X4 b.</param>
    /// <param name="m1x5B">The M1X5 b.</param>
    /// <param name="m1x6B">The M1X6 b.</param>
    /// <param name="m2x1B">The M2X1 b.</param>
    /// <param name="m2x2B">The M2X2 b.</param>
    /// <param name="m2x3B">The M2X3 b.</param>
    /// <param name="m2x4B">The M2X4 b.</param>
    /// <param name="m2x5B">The M2X5 b.</param>
    /// <param name="m2x6B">The M2X6 b.</param>
    /// <param name="m3x1B">The M3X1 b.</param>
    /// <param name="m3x2B">The M3X2 b.</param>
    /// <param name="m3x3B">The M3X3 b.</param>
    /// <param name="m3x4B">The M3X4 b.</param>
    /// <param name="m3x5B">The M3X5 b.</param>
    /// <param name="m3x6B">The M3X6 b.</param>
    /// <param name="m4x1B">The M4X1 b.</param>
    /// <param name="m4x2B">The M4X2 b.</param>
    /// <param name="m4x3B">The M4X3 b.</param>
    /// <param name="m4x4B">The M4X4 b.</param>
    /// <param name="m4x5B">The M4X5 b.</param>
    /// <param name="m4x6B">The M4X6 b.</param>
    /// <param name="m5x1B">The M5X1 b.</param>
    /// <param name="m5x2B">The M5X2 b.</param>
    /// <param name="m5x3B">The M5X3 b.</param>
    /// <param name="m5x4B">The M5X4 b.</param>
    /// <param name="m5x5B">The M5X5 b.</param>
    /// <param name="m5x6B">The M5X6 b.</param>
    /// <param name="m6x1B">The M6X1 b.</param>
    /// <param name="m6x2B">The M6X2 b.</param>
    /// <param name="m6x3B">The M6X3 b.</param>
    /// <param name="m6x4B">The M6X4 b.</param>
    /// <param name="m6x5B">The M6X5 b.</param>
    /// <param name="m6x6B">The M6X6 b.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://www.physicsforums.com/threads/dot-product-2x2-matrix.688717/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProductMatrix6x6<T>(
        T m1x1A, T m1x2A, T m1x3A, T m1x4A, T m1x5A, T m1x6A,
        T m2x1A, T m2x2A, T m2x3A, T m2x4A, T m2x5A, T m2x6A,
        T m3x1A, T m3x2A, T m3x3A, T m3x4A, T m3x5A, T m3x6A,
        T m4x1A, T m4x2A, T m4x3A, T m4x4A, T m4x5A, T m4x6A,
        T m5x1A, T m5x2A, T m5x3A, T m5x4A, T m5x5A, T m5x6A,
        T m6x1A, T m6x2A, T m6x3A, T m6x4A, T m6x5A, T m6x6A,
        T m1x1B, T m1x2B, T m1x3B, T m1x4B, T m1x5B, T m1x6B,
        T m2x1B, T m2x2B, T m2x3B, T m2x4B, T m2x5B, T m2x6B,
        T m3x1B, T m3x2B, T m3x3B, T m3x4B, T m3x5B, T m3x6B,
        T m4x1B, T m4x2B, T m4x3B, T m4x4B, T m4x5B, T m4x6B,
        T m5x1B, T m5x2B, T m5x3B, T m5x4B, T m5x5B, T m5x6B,
        T m6x1B, T m6x2B, T m6x3B, T m6x4B, T m6x5B, T m6x6B)
        where T : INumber<T>
        => (m1x1A * m1x1B) + (m1x2A * m1x2B) + (m1x3A * m1x3B) + (m1x4A * m1x4B) + (m1x5A * m1x5B) + (m1x6A * m1x6B)
         + (m2x1A * m2x1B) + (m2x2A * m2x2B) + (m2x3A * m2x3B) + (m2x4A * m2x4B) + (m2x5A * m2x5B) + (m2x6A * m2x6B)
         + (m3x1A * m3x1B) + (m3x2A * m3x2B) + (m3x3A * m3x3B) + (m3x4A * m3x4B) + (m3x5A * m3x5B) + (m3x6A * m3x6B)
         + (m4x1A * m4x1B) + (m4x2A * m4x2B) + (m4x3A * m4x3B) + (m4x4A * m4x4B) + (m4x5A * m4x5B) + (m4x6A * m4x6B)
         + (m5x1A * m5x1B) + (m5x2A * m5x2B) + (m5x3A * m5x3B) + (m5x4A * m5x4B) + (m5x5A * m5x5B) + (m5x6A * m5x6B)
         + (m6x1A * m6x1B) + (m6x2A * m6x2B) + (m6x3A * m6x3B) + (m6x4A * m6x4B) + (m6x5A * m6x5B) + (m6x6A * m6x6B);
    #endregion

    #region Diagonalize Matrix
    /// <summary>
    /// Diagonalizes the matrix.
    /// Atr. * A
    /// </summary>
    /// <param name="originalMatrix">The original matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    public static T[,] DiagonalizeMatrix<T>(Span2D<T> originalMatrix) where T : INumber<T> => MatrixMatrixScalarMultiplication(Transpose(originalMatrix), originalMatrix);

    /// <summary>
    /// Diagonalizes the matrix.
    /// Atr. * A
    /// </summary>
    /// <param name="originalMatrix">The original matrix.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    public static T[,] DiagonalizeMatrix<T>(Span2D<T> originalMatrix, int accuracy) where T : IFloatingPointIeee754<T> => MatrixMatrixScalarMultiplication(Transpose(originalMatrix, accuracy), originalMatrix, accuracy);

    /// <summary>
    /// Diagonalizes the matrix.
    /// Atr. * A
    /// </summary>
    /// <param name="originalMatrix">The original matrix.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    public static T[,] DiagonalizeMatrix<T>(Span2D<T> originalMatrix, int rows, int columns, int accuracy) where T : IFloatingPointIeee754<T> => MatrixMatrixScalarMultiplication(Transpose(originalMatrix, rows, columns, accuracy), columns, rows, originalMatrix, rows, columns, accuracy);
    #endregion

    #region Decompose to Lower and Upper Matrices
    /// <summary>
    /// Compute LU decomposition on a squared matrix
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T[,] Lower, T[,] Upper) DecomposeToLowerUpper<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var rows = matrix.Height;
        var cols = matrix.Width;

        if (!IsSquareMatrix(matrix))
        {
            return (new T[1, 1], new T[1, 1]);
        }
        else
        {
            var lower = new T[rows, cols];
            var upper = new T[rows, cols];

            for (var i = 0; i < rows; i++)
            {
                lower[i, i] = T.One;
            }

            for (var i = 0; i < rows; i++)
            {
                for (var j = i; j < rows; j++)
                {
                    var sumU = T.Zero;
                    for (var k = 0; k < i; k++)
                    {
                        sumU += lower[i, k] * upper[k, j];
                    }

                    upper[i, j] = matrix[i, j] - sumU;
                }

                for (var j = i; j < rows; j++)
                {
                    var sumL = T.Zero;
                    for (var k = 0; k < i; k++)
                    {
                        sumL += lower[j, k] * upper[k, i];
                    }

                    lower[j, i] = (matrix[j, i] - sumL) / upper[i, i];
                }
            }

            return (lower, upper);
        }
    }
    #endregion

    #region Resolve Linear Equation Lower Triangular Matrix
    /// <summary>
    /// Resolve the following linear equation LY = f
    /// where L is a lower triangular matrix
    /// </summary>
    /// <param name="matrix">The data.</param>
    /// <param name="fMatrix">vector of shape (d,1)</param>
    /// <returns>
    /// Y vector y of shape (d,1)
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] ResolveLinearEquationLowerTriangularMatrix<T>(Span2D<T> matrix, Span2D<T> fMatrix)
        where T : INumber<T>
    {
        var row = matrix.Height;
        var rowf = fMatrix.Height;
        var colf = fMatrix.Width;
        var violations = !IsLowerMatrix(matrix) || row != rowf || colf > 1 || row < 2;
        if (violations)
        {
            return new T[1, 1];
        }

        var yMatrix = new T[row, 1];

        yMatrix[0, 0] = fMatrix[0, 0] / matrix[0, 0];

        for (var m = 1; m < row; m++)
        {
            T sum = T.Zero;
            for (var i = 0; i < m; i++)
            {
                sum += matrix[m, i] * yMatrix[i, 0];
            }

            yMatrix[m, 0] = (fMatrix[m, 0] - sum) / matrix[m, m];
        }

        return yMatrix;
    }
    #endregion

    #region Resolve Linear Equation Upper Triangular Matrix
    /// <summary>
    /// Resolve the following linear equation UX = y
    /// where U is a upper triangular matrix
    /// </summary>
    /// <param name="matrix">The data.</param>
    /// <param name="yMatrix">vector of shape (d,1)</param>
    /// <returns>
    /// X vector y of shape (d,1)
    /// </returns>
    /// <acknowledgment>
    /// https://github.com/SarahFrem/AutoRegressive_model_cs/blob/master/Matrix.cs#L219
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] ResolveLinearEquation_UpperTriangularMatrix<T>(Span2D<T> matrix, Span2D<T> yMatrix)
        where T : INumber<T>
    {
        var row = matrix.Height;
        var rowy = yMatrix.Height;
        var coly = yMatrix.Width;
        var violations = !IsUpperMatrix(matrix) || row != rowy || coly > 1;
        if (violations)
        {
            return new T[1, 1];
        }

        var xMatrix = new T[row, 1];

        for (var i = row - 1; i >= 0; i--)
        {
            T sum = T.Zero;
            for (var k = i + 1; k < row; k++)
            {
                sum += matrix[i, k] * xMatrix[k, 0];
            }

            xMatrix[i, 0] = (yMatrix[i, 0] - sum) / matrix[i, i];
        }

        return xMatrix;
    }
    #endregion

    #region Solve LU Matrix
    /// <summary>
    /// Solve A*X = B
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="pivot">The pivot.</param>
    /// <param name="B">A Matrix with as many rows as A and any number of columns.</param>
    /// <returns>
    /// X so that L*U*X = B(piv,:)
    /// </returns>
    /// <exception cref="ArgumentException">Matrix row dimensions must agree.</exception>
    /// <exception cref="SystemException">Matrix is singular.</exception>
    /// <acknowledgment>
    /// https://www.codeproject.com/articles/5835/dotnetmatrix-simple-matrix-library-for-net
    /// </acknowledgment>
    public static T[,] LUSolve<T>(Span2D<T> matrix, Span<int> pivot, Span2D<T> B)
        where T : INumber<T>
    {
        var m = matrix.Height;
        var n = matrix.Width;
        var m2 = B.Height;
        var n2 = B.Width;
        if (m2 != m)
        {
            throw new ArgumentException("Matrix row dimensions must agree.");
        }
        if (!IsNonSingular(matrix))
        {
            throw new SystemException("Matrix is singular.");
        }

        // Copy right hand side with pivoting
        var nx = n2;
        var Xmat = GetMatrix(B, pivot, 0, nx - 1);

        // Solve L*Y = B(piv,:)
        for (var k = 0; k < n; k++)
        {
            for (var i = k + 1; i < n; i++)
            {
                for (var j = 0; j < nx; j++)
                {
                    Xmat[i, j] -= Xmat[k, j] * matrix[i, k];
                }
            }
        }

        // Solve U*X = Y;
        for (var k = n - 1; k >= 0; k--)
        {
            for (var j = 0; j < nx; j++)
            {
                Xmat[k, j] /= matrix[k, k];
            }
            for (var i = 0; i < k; i++)
            {
                for (var j = 0; j < nx; j++)
                {
                    Xmat[i, j] -= Xmat[k, j] * matrix[i, k];
                }
            }
        }

        return Xmat;
    }
    #endregion

    #region Solve QR Matrix
    /// <summary>
    /// Least squares solution of A*X = B
    /// </summary>
    /// <param name="QR">The qr.</param>
    /// <param name="Rdiag">The rdiag.</param>
    /// <param name="B">A Matrix with as many rows as A and any number of columns.</param>
    /// <returns>
    /// X that minimizes the two norm of Q*R*X-B.
    /// </returns>
    /// <exception cref="ArgumentException">Matrix row dimensions must agree.</exception>
    /// <exception cref="SystemException">Matrix is rank deficient.</exception>
    /// <acknowledgment>
    /// https://www.codeproject.com/articles/5835/dotnetmatrix-simple-matrix-library-for-net
    /// </acknowledgment>
    public static T[,] QRSolve<T>(T[,] QR, Span<T> Rdiag, Span2D<T> B)
        where T : INumber<T>
    {
        var m = QR.GetLength(0);
        var n = QR.GetLength(1);
        var m2 = B.Height;
        var n2 = B.Width;
        if (m2 != m)
        {
            throw new ArgumentException("GeneralMatrix row dimensions must agree.");
        }
        if (!IsFullRank(Rdiag))
        {
            throw new SystemException("Matrix is rank deficient.");
        }

        // Copy right hand side
        var nx = n2;
        var X = CopyMatrix(B);

        // Compute Y = transpose(Q)*B
        for (var k = 0; k < n; k++)
        {
            for (var j = 0; j < nx; j++)
            {
                var s = T.Zero;
                for (var i = k; i < m; i++)
                {
                    s += QR[i, k] * X[i, j];
                }
                s = (-s) / QR[k, k];
                for (var i = k; i < m; i++)
                {
                    X[i, j] += s * QR[i, k];
                }
            }
        }

        // Solve R*X = Y;
        for (var k = n - 1; k >= 0; k--)
        {
            for (var j = 0; j < nx; j++)
            {
                X[k, j] /= Rdiag[k];
            }
            for (var i = 0; i < k; i++)
            {
                for (var j = 0; j < nx; j++)
                {
                    X[i, j] -= X[k, j] * QR[i, k];
                }
            }
        }

        return GetMatrix<T>(X, 0, n - 1, 0, nx - 1);
    }
    #endregion

    #region Solve Cholesky Matrix
    /// <summary>
    /// Solve A*X = B
    /// </summary>
    /// <param name="L">The l.</param>
    /// <param name="B">A Matrix with as many rows as A and any number of columns.</param>
    /// <returns>
    /// X so that L*L'*X = B
    /// </returns>
    /// <exception cref="ArgumentException">Matrix row dimensions must agree.</exception>
    /// <exception cref="SystemException">Matrix is not symmetric positive definite.</exception>
    /// <acknowledgment>
    /// https://www.codeproject.com/articles/5835/dotnetmatrix-simple-matrix-library-for-net
    /// </acknowledgment>
    public static T[,] CholeskySolve<T>(Span2D<T> L, Span2D<T> B)
        where T : INumber<T>
    {
        var m = L.Height;
        var n = L.Width;
        if (B.Height != n)
        {
            throw new ArgumentException("Matrix row dimensions must agree.");
        }
        if (m != n)
        {
            throw new SystemException("Matrix is not symmetric positive definite.");
        }

        // Copy right hand side.
        var X = CopyMatrix(B);
        var nx = n;

        // Solve L*Y = B;
        for (var k = 0; k < n; k++)
        {
            for (var i = k + 1; i < n; i++)
            {
                for (var j = 0; j < nx; j++)
                {
                    X[i, j] -= X[k, j] * L[i, k];
                }
            }
            for (var j = 0; j < nx; j++)
            {
                X[k, j] /= L[k, k];
            }
        }

        // Solve L'*X = Y;
        for (var k = n - 1; k >= 0; k--)
        {
            for (var j = 0; j < nx; j++)
            {
                X[k, j] /= L[k, k];
            }
            for (var i = 0; i < k; i++)
            {
                for (var j = 0; j < nx; j++)
                {
                    X[i, j] -= X[k, j] * L[k, i];
                }
            }
        }

        return X;
    }
    #endregion




    #region 1: Least Squares Method Prepare Matrix
    /// <summary>
    /// LSM, step 1: Prepare the matrix.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <param name="numberOfSamples">The number of samples.</param>
    /// <param name="columnsAccordingToMode">The columns according to mode.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T[,], T[,]) LeastSquaresMethodPrepareMatrix<T>(Span2D<T> data, int numberOfSamples, int columnsAccordingToMode)
        where T : INumber<T>
    {
        var cube = false;
        if (columnsAccordingToMode == 4)
        {
            cube = true;
        }
        else if (columnsAccordingToMode != 3)
        {
            throw new Exception("LSM error");
        }

        var vector_columns = 1;
        var the_result_matrix = new T[numberOfSamples, columnsAccordingToMode];
        var the_result_vector = new T[numberOfSamples, vector_columns];
        for (var i = 0; i < numberOfSamples; i++)
        {
            for (var j = 0; j < columnsAccordingToMode; j++)
            {
                the_result_matrix[i, j] = j switch
                {
                    0 => the_result_matrix[i, j] = cube ? data[i, 0] * data[i, 0] * data[i, 0] : data[i, 0] * data[i, 0],
                    1 => the_result_matrix[i, j] = cube ? data[i, 0] * data[i, 0] : data[i, 0],
                    2 => the_result_matrix[i, j] = cube ? data[i, 0] : T.One,
                    3 => the_result_matrix[i, j] = T.One,
                    _ => throw new NotImplementedException(),
                };
            }

            the_result_vector[i, 0] = data[i, 1];
        }

        return (the_result_matrix, the_result_vector);
    }
    #endregion

    // ToDo: Port the rest of the LSM.
    #region 3: Least Squares Method Solution
    /// <summary>
    /// LSM, step 3: The solution extraction.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] LeastSquaresMethodSolution<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var rows = matrix.Height;
        var columns = matrix.Width;
        var result = new T[rows];
        var column_index = columns - 1;
        for (var i = 0; i < rows; i++)
        {
            result[i] = matrix[i, column_index];
        }

        return result;
    }

    /// <summary>
    /// LSM, step 3: The solution extraction.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] LeastSquaresMethodSolution<T>(Span2D<T> matrix, int rows, int columns)
        where T : INumber<T>
    {
        var result = new T[rows];
        var column_index = columns - 1;
        for (var i = 0; i < rows; i++)
        {
            result[i] = matrix[i, column_index];
        }

        return result;
    }
    #endregion

    #region Least Squares Method Sort
    /// <summary>
    /// LSM, sort.
    /// </summary>
    /// <param name="data">The data.</param>
    /// <param name="numberOfSamples">The number of samples.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] LeastSquaresMethodSort<T>(Span2D<T> data, int numberOfSamples)
        where T : INumber<T>
    {
        var swapped = true;
        var temp = CopyMatrix(data, numberOfSamples, 2);
        while (swapped)
        {
            swapped = false;
            for (var i = 0; i < numberOfSamples - 1; i++)
            {
                if (temp[i, 0] > temp[i + 1, 0] || temp[i, 0] == temp[i + 1, 0] && temp[i, 1] > temp[i + 1, 1])
                {
                    SwapRows<T>(temp, numberOfSamples, 2, i, i + 1);
                    swapped = true;
                }
            }
        }

        return temp;
    }
    #endregion

    // ToDo: Figure out what this is.
    #region Extract A2
    /// <summary>
    /// Extract A2.
    /// </summary>
    /// <param name="theBigOne">The big one.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,]? ExtractA2<T>(Span2D<T> theBigOne)
        where T : INumber<T>
    {
        var rows = theBigOne.Height;
        var columns = theBigOne.Width;
        var A2_rows = rows - 1;
        var A2_columns = columns - 1;
        var A2_matrix = new T[A2_rows, A2_columns];
        if (A2_rows != 0 && A2_columns != 0)
        {
            for (var i = 1; i < rows; i++)
            {
                for (var j = 1; j < columns; j++)
                {
                    A2_matrix[i - 1, j - 1] = theBigOne[i, j];
                }
            }
        }
        else
        {
            A2_matrix = new T[0, 0];
        }

        return A2_matrix;
    }

    /// <summary>
    /// Extract A2.
    /// </summary>
    /// <param name="theBigOne">The big one.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,]? ExtractA2<T>(Span2D<T> theBigOne, int rows, int columns)
        where T : INumber<T>
    {
        var A2_rows = rows - 1;
        var A2_columns = columns - 1;
        var A2_matrix = new T[A2_rows, A2_columns];
        if (A2_rows != 0 && A2_columns != 0)
        {
            for (var i = 1; i < rows; i++)
            {
                for (var j = 1; j < columns; j++)
                {
                    A2_matrix[i - 1, j - 1] = theBigOne[i, j];
                }
            }
        }
        else
        {
            A2_matrix = new T[0, 0];
        }

        return A2_matrix;
    }
    #endregion

    // ToDo: Figure out what is supposed to use this.
    #region Power Iteration Row Swap
    /// <summary>
    /// Tricky row swap to make Power Iteration faster.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] SwappingSomeRows<T>(Span2D<T> matrix)
        where T : INumber<T>
    {
        var bingo = false;
        var rows = matrix.Height;
        var columns = matrix.Width;
        var result = new T[rows, columns];
        if (rows == columns && columns == 2)
        {
            for (var j = 0; j < columns; j++)
            {
                if (matrix[0, j] == T.Zero)
                {
                    bingo = true;
                }
            }
            if (bingo)
            {
                result = CopyMatrix(matrix);
                SwapRows<T>(result, rows, columns, 0, 1);
            }
        }
        if (!bingo)
        {
            result = matrix.ToArray();
        }

        return result;
    }

    /// <summary>
    /// Tricky row swap to make Power Iteration faster.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="matrix">The matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] SwappingSomeRows<T>(int rows, int columns, Span2D<T> matrix)
        where T : INumber<T>
    {
        var bingo = false;
        var result = new T[rows, columns];
        if (rows == columns && columns == 2)
        {
            for (var j = 0; j < columns; j++)
            {
                if (matrix[0, j] == T.Zero)
                {
                    bingo = true;
                }
            }
            if (bingo)
            {
                result = CopyMatrix(matrix);
                SwapRows<T>(result, rows, columns, 0, 1);
            }
        }
        if (!bingo)
        {
            result = matrix.ToArray();
        }

        return result;
    }
    #endregion

    // ToDo: Figure out how to port everything else.
    #region Eigenvalue Multiplicity
    /// <summary>
    /// Find the Eigenvalue the multiplicity.
    /// </summary>
    /// <param name="eigenvalues">The eigenvalues.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Dictionary<T, int> EigenvalueMultiplicity<T>(Span<T> eigenvalues)
        where T : INumber<T>
    {
        var Eigenvalues_and_Multiplicity = new Dictionary<T, int>();
        for (var i = 0; i < eigenvalues.Length; i++)
        {
            if (!Eigenvalues_and_Multiplicity.ContainsKey(eigenvalues[i]))
            {
                Eigenvalues_and_Multiplicity.Add(eigenvalues[i], 1);
            }
            else
            {
                Eigenvalues_and_Multiplicity[eigenvalues[i]]++;
            }
        }

        return Eigenvalues_and_Multiplicity;
    }

    /// <summary>
    /// Find the Eigenvalue the multiplicity.
    /// </summary>
    /// <param name="eigenvalues">The eigenvalues.</param>
    /// <param name="N">The n.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Dictionary<T, int> EigenvalueMultiplicity<T>(Span<T> eigenvalues, int N)
        where T : INumber<T>
    {
        var Eigenvalues_and_Multiplicity = new Dictionary<T, int>();
        for (var i = 0; i < N; i++)
        {
            if (!Eigenvalues_and_Multiplicity.ContainsKey(eigenvalues[i]))
            {
                Eigenvalues_and_Multiplicity.Add(eigenvalues[i], 1);
            }
            else
            {
                Eigenvalues_and_Multiplicity[eigenvalues[i]]++;
            }
        }

        return Eigenvalues_and_Multiplicity;
    }
    #endregion

    // ToDo: Work out what this is supposed to do.
    #region Solution Finder
    /// <summary>
    /// Solution finder.
    /// </summary>
    /// <param name="tempMatrix">The temporary matrix.</param>
    /// <param name="rank">The rank.</param>
    /// <param name="row">The row.</param>
    /// <param name="freePositionsInTheRow">The free positions in the row.</param>
    /// <param name="tempValue">The temporary value.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static T[,] SolutionFinder<T>(Span2D<T> tempMatrix, int rank, int row, List<int> freePositionsInTheRow, T tempValue, int index)
        where T : INumber<T>
    {
        var N = tempMatrix.Height;
        var Kernel_dimension = N - rank;
        var Temp_countings = new T[Kernel_dimension, N + 1];
        //var free_positions_count = free_positions_in_the_row.Count;
        var i = 0; // row index

        while (i < Kernel_dimension) // tonight i have to check this out
        {
            T temp_value_copy = T.Zero;
            var random_vectors = Factories.Vectors_1_0<T>(Kernel_dimension, freePositionsInTheRow.Count, index);
            //MessageBox.Show(Convert_MX_VR_to_string(Kernel_dimension, free_positions_in_the_row.Count - 1, random_vectors) + "Rnd");
            for (var free = 0; free < freePositionsInTheRow.Count - 1; free++)
            {
                Temp_countings[i, freePositionsInTheRow[free]] = random_vectors[i, free];
                temp_value_copy += Temp_countings[i, freePositionsInTheRow[free]] * tempMatrix[row, freePositionsInTheRow[free]];
            }
            //MessageBox.Show(Convert.ToString(temp_value_copy));
            var the_last_free_second_index = freePositionsInTheRow[^1];
            Temp_countings[i, the_last_free_second_index] = (-T.One) * temp_value_copy / tempMatrix[row, the_last_free_second_index];
            //MessageBox.Show(Convert_MX_VR_to_string(Kernel_dimension, N + 1, Temp_countings) + "Temp countings");
            i++;
        }

        return Temp_countings;
    }

    /// <summary>
    /// Solution finder.
    /// </summary>
    /// <param name="tempMatrix">The temporary matrix.</param>
    /// <param name="N">The n.</param>
    /// <param name="rank">The rank.</param>
    /// <param name="row">The row.</param>
    /// <param name="freePositionsInTheRow">The free positions in the row.</param>
    /// <param name="tempValue">The temporary value.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static T[,] SolutionFinder<T>(Span2D<T> tempMatrix, int N, int rank, int row, List<int> freePositionsInTheRow, T tempValue, int index)
        where T : INumber<T>
    {
        var Kernel_dimension = N - rank;
        var Temp_countings = new T[Kernel_dimension, N + 1];
        //var free_positions_count = free_positions_in_the_row.Count;
        var i = 0; // row index

        while (i < Kernel_dimension) // tonight i have to check this out
        {
            T temp_value_copy = T.Zero;
            var random_vectors = Factories.Vectors_1_0<T>(Kernel_dimension, freePositionsInTheRow.Count, index);
            //MessageBox.Show(Convert_MX_VR_to_string(Kernel_dimension, free_positions_in_the_row.Count - 1, random_vectors) + "Rnd");
            for (var free = 0; free < freePositionsInTheRow.Count - 1; free++)
            {
                Temp_countings[i, freePositionsInTheRow[free]] = random_vectors[i, free];
                temp_value_copy += Temp_countings[i, freePositionsInTheRow[free]] * tempMatrix[row, freePositionsInTheRow[free]];
            }
            //MessageBox.Show(Convert.ToString(temp_value_copy));
            var the_last_free_second_index = freePositionsInTheRow[^1];
            Temp_countings[i, the_last_free_second_index] = (-T.One) * temp_value_copy / tempMatrix[row, the_last_free_second_index];
            //MessageBox.Show(Convert_MX_VR_to_string(Kernel_dimension, N + 1, Temp_countings) + "Temp countings");
            i++;
        }

        return Temp_countings;
    }
    #endregion

    #region Validate Spectral Decomposition
    /// <summary>
    /// Spectral decomposition check.
    /// </summary>
    /// <param name="original">The original.</param>
    /// <param name="matrix1">The matrix 1.</param>
    /// <param name="matrix2">The matrix 2.</param>
    /// <param name="matrix3">The matrix 3.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool ValidateSpectralDecomposition<T>(Span2D<T> original, Span2D<T> matrix1, Span2D<T> matrix2, Span2D<T> matrix3)
        where T : IFloatingPointIeee754<T>
    {
        var N = original.Height;
        var temp_matrix = MatrixMatrixScalarMultiplication(matrix1, N, N, matrix2, N, N, 15);
        var result_matrix = MatrixMatrixScalarMultiplication(temp_matrix, N, N, matrix3, N, N, 5);
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, result_matrix));
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_original));
        return MatricesEquality(original, result_matrix, N, N);
    }

    /// <summary>
    /// Spectral decomposition check.
    /// </summary>
    /// <param name="original">The original.</param>
    /// <param name="N">The n.</param>
    /// <param name="matrix1">The matrix 1.</param>
    /// <param name="matrix2">The matrix 2.</param>
    /// <param name="matrix3">The matrix 3.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool ValidateSpectralDecomposition<T>(Span2D<T> original, int N, Span2D<T> matrix1, Span2D<T> matrix2, Span2D<T> matrix3)
        where T : IFloatingPointIeee754<T>
    {
        var temp_matrix = MatrixMatrixScalarMultiplication(matrix1, N, N, matrix2, N, N, 15);
        var result_matrix = MatrixMatrixScalarMultiplication(temp_matrix, N, N, matrix3, N, N, 5);
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, result_matrix));
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_original));
        return MatricesEquality(original, result_matrix, N, N);
    }
    #endregion

    // ToDo: Figure out what this is supposed to do.
    #region Create Orthogonal Spectral Decomposition
    /// <summary>
    /// Creates the orthogonal spectral decomposition.
    /// Coefficient and Inverse checker
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="inversedMatrix">The inversed matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[,]? CreateOrthogonalSpectralDecomposition<T, TResult>(Span2D<T> matrix, Span2D<T> inversedMatrix)
        where T : INumber<T>
        where TResult : IFloatingPointIeee754<TResult>
    {
        var N = matrix.Height;
        var the_result = new TResult[N, N];
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_matrix) + " : the original");
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_inversed_matrix) + " : the inversed");
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, Matrix_Multiplication(N, N, the_matrix, N, N, the_inversed_matrix, 15)) + " : Mult");
        for (var i = 0; i < N; i++)
        {
            for (var j = 0; j < N; j++)
            {
                try
                {
                    the_result[i, j] = TResult.Sqrt(TResult.CreateChecked(matrix[i, j] * inversedMatrix[j, i]));
                }
                catch (Exception The_Exception)
                {
                    the_result[i, j] = TResult.Zero;
                    throw new Exception(The_Exception.Message);
                }

                if (matrix[i, j] < T.Zero)
                {
                    the_result[i, j] = TResult.NegativeOne * the_result[i, j];
                }
            }
        }

        //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_result) + " : the result");
        var the_result_tr = Transpose<TResult>(the_result, N, N, 15);
        var checker = MatrixMatrixScalarMultiplication<TResult>(the_result, N, N, the_result_tr, N, N, 4);
        var identity_matrix = Factories.MultiplicativeIdentity<TResult>(N, N);
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, checker) + " : checker");
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, identity_matrix) + " : IDE");
        //T coefficient = the_matrix[0, 0] / the_inveresed_matrix[0, 0];
        return MatricesEquality<TResult>(checker, identity_matrix) ? the_result : new TResult[0, 0];
    }

    /// <summary>
    /// Creates the orthogonal spectral decomposition.
    /// Coefficient and Inverse checker
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="N">The n.</param>
    /// <param name="inversedMatrix">The inversed matrix.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private static TResult[,]? CreateOrthogonalSpectralDecomposition<T, TResult>(Span2D<T> matrix, int N, Span2D<T> inversedMatrix)
        where T : INumber<T>
        where TResult : IFloatingPointIeee754<TResult>
    {
        var the_result = new TResult[N, N];
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_matrix) + " : the original");
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_inversed_matrix) + " : the inversed");
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, Matrix_Multiplication(N, N, the_matrix, N, N, the_inversed_matrix, 15)) + " : Mult");
        for (var i = 0; i < N; i++)
        {
            for (var j = 0; j < N; j++)
            {
                try
                {
                    the_result[i, j] = TResult.Sqrt(TResult.CreateChecked(matrix[i, j] * inversedMatrix[j, i]));
                }
                catch (Exception The_Exception)
                {
                    the_result[i, j] = TResult.Zero;
                    throw new Exception(The_Exception.Message);
                }

                if (matrix[i, j] < T.Zero)
                {
                    the_result[i, j] = TResult.NegativeOne * the_result[i, j];
                }
            }
        }

        //MessageBox.Show(Convert_MX_VR_to_string(N, N, the_result) + " : the result");
        var the_result_tr = Transpose<TResult>(the_result, N, N, 15);
        var checker = MatrixMatrixScalarMultiplication<TResult>(the_result, N, N, the_result_tr, N, N, 4);
        var identity_matrix = Factories.MultiplicativeIdentity<TResult>(N, N);
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, checker) + " : checker");
        //MessageBox.Show(Convert_MX_VR_to_string(N, N, identity_matrix) + " : IDE");
        //T coefficient = the_matrix[0, 0] / the_inveresed_matrix[0, 0];
        return MatricesEquality<TResult>(checker, identity_matrix) ? the_result : new TResult[0, 0];
    }
    #endregion

    // ToDo: Figure out what this is supposed to do.
    #region Singular Decomposition Sigma Matrix
    /// <summary>
    /// SVDs the create sigma matrix.
    /// The Xi matrix
    /// </summary>
    /// <param name="sMatrix">The s matrix.</param>
    /// <param name="rank">The rank.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] SingularValueDecompositionCreateSigmaMatrix<T>(Span2D<T> sMatrix, int rank)
        where T : INumber<T>
    {
        var rows = sMatrix.Height;
        var columns = sMatrix.Width;
        var the_Xi_matrix = new T[rows, columns];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                the_Xi_matrix[i, j] = i < rank && j < rank ? sMatrix[i, j] : T.Zero;
            }
        }

        return the_Xi_matrix;
    }

    /// <summary>
    /// SVDs the create sigma matrix.
    /// The Xi matrix
    /// </summary>
    /// <param name="sMatrix">The s matrix.</param>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="rank">The rank.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] SingularValueDecompositionCreateSigmaMatrix<T>(Span2D<T> sMatrix, int rows, int columns, int rank)
        where T : INumber<T>
    {
        var the_Xi_matrix = new T[rows, columns];
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                the_Xi_matrix[i, j] = i < rank && j < rank ? sMatrix[i, j] : T.Zero;
            }
        }

        return the_Xi_matrix;
    }
    #endregion

    // ToDo: Work out what this is supposed to do.
    #region Singular Value Decomposition V1 Matrix
    /// <summary>
    /// SVDs the create v1 matrix.
    /// The V1 matrix
    /// </summary>
    /// <param name="vMatrix">The v matrix.</param>
    /// <param name="rank">The rank.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] SingularValueDecompositionCreateV1Matrix<T>(Span2D<T> vMatrix, int rank)
    {
        var N = vMatrix.Height;
        var the_V1_matrix = new T[N, rank];
        for (var i = 0; i < N; i++)
        {
            for (var j = 0; j < rank; j++)
            {
                the_V1_matrix[i, j] = vMatrix[i, j];
            }
        }

        return the_V1_matrix;
    }

    /// <summary>
    /// SVDs the create v1 matrix.
    /// The V1 matrix
    /// </summary>
    /// <param name="vMatrix">The v matrix.</param>
    /// <param name="N">The n.</param>
    /// <param name="rank">The rank.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] SingularValueDecompositionCreateV1Matrix<T>(Span2D<T> vMatrix, int N, int rank)
    {
        var the_V1_matrix = new T[N, rank];
        for (var i = 0; i < N; i++)
        {
            for (var j = 0; j < rank; j++)
            {
                the_V1_matrix[i, j] = vMatrix[i, j];
            }
        }

        return the_V1_matrix;
    }
    #endregion

    #region Cholesky Decomposition
    /// <summary>
    /// Calculates the Cholesky decomposition.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (bool positiveDefiniteness, bool, TResult[,] lowerMatrix, TResult[,] upperMatrix) CholeskyDecomposition<T, TResult>(Span2D<T> matrix, int accuracy)
        where T : INumber<T>
        where TResult : IFloatingPointIeee754<TResult>
    {
        var n = matrix.Height;
        var positiveDefiniteness = true;
        var lowerMatrix = new TResult[n, n];
        for (var k = 0; k < n && positiveDefiniteness; k++)
        {
            var temporarySum = TResult.Zero;
            for (var j = 0; j <= k - 1; j++)
            {
                temporarySum += TResult.Pow(TResult.CreateChecked(lowerMatrix[k, j]), TResult.CreateChecked(2));
            }

            var definitenessCheck = TResult.CreateChecked(matrix[k, k]) - temporarySum;

            if (definitenessCheck <= TResult.Zero)
            {
                positiveDefiniteness = false;
            }
            else
            {
                lowerMatrix[k, k] = TResult.Sqrt(definitenessCheck);

                for (var i = k + 1; i < n; i++)
                {
                    temporarySum = TResult.Zero;
                    for (var j = 0; j <= k - 1; j++)
                    {
                        temporarySum += lowerMatrix[i, j] * lowerMatrix[k, j];
                    }

                    lowerMatrix[i, k] = TResult.One / lowerMatrix[k, k] * (TResult.CreateChecked(matrix[i, k]) - temporarySum);
                }
            }
        }

        var upperMatrix = Transpose<TResult>(lowerMatrix, n, n, 15);
        var resultCheckerMatrix = MatrixMatrixScalarMultiplication<TResult>(lowerMatrix, n, n, upperMatrix, n, n, accuracy);

        var result_check = false;
        if (MatricesEquality<TResult>(Cast<T, TResult>(matrix), resultCheckerMatrix, n, n))
        {
            result_check = true;
        }

        return (positiveDefiniteness, result_check, Round<TResult, TResult>(lowerMatrix, n, n, accuracy), Round<TResult, TResult>(upperMatrix, n, n, accuracy));
    }

    /// <summary>
    /// Calculates the Cholesky decomposition.
    /// </summary>
    /// <param name="matrix">The matrix.</param>
    /// <param name="n">The n.</param>
    /// <param name="accuracy">The accuracy.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (bool positiveDefiniteness, bool, TResult[,] lowerMatrix, TResult[,] upperMatrix) CholeskyDecomposition<T, TResult>(Span2D<T> matrix, int n, int accuracy)
        where T : INumber<T>
        where TResult : IFloatingPointIeee754<TResult>
    {
        var positiveDefiniteness = true;
        var lowerMatrix = new TResult[n, n];
        for (var k = 0; k < n && positiveDefiniteness; k++)
        {
            var temporarySum = TResult.Zero;
            for (var j = 0; j <= k - 1; j++)
            {
                temporarySum += TResult.Pow(lowerMatrix[k, j], TResult.CreateChecked(2));
            }

            var definitenessCheck = TResult.CreateChecked(matrix[k, k]) - temporarySum;

            if (definitenessCheck <= TResult.Zero)
            {
                positiveDefiniteness = false;
            }
            else
            {
                lowerMatrix[k, k] = TResult.Sqrt(definitenessCheck);

                for (var i = k + 1; i < n; i++)
                {
                    temporarySum = TResult.Zero;
                    for (var j = 0; j <= k - 1; j++)
                    {
                        temporarySum += lowerMatrix[i, j] * lowerMatrix[k, j];
                    }

                    lowerMatrix[i, k] = TResult.One / lowerMatrix[k, k] * (TResult.CreateChecked(matrix[i, k]) - temporarySum);
                }
            }
        }

        var upperMatrix = Transpose<TResult>(lowerMatrix, n, n, 15);
        var resultCheckerMatrix = MatrixMatrixScalarMultiplication<TResult>(lowerMatrix, n, n, upperMatrix, n, n, accuracy);

        var result_check = false;
        if (MatricesEquality<TResult>(Cast<T, TResult>(matrix), resultCheckerMatrix, n, n))
        {
            result_check = true;
        }

        return (positiveDefiniteness, result_check, Round<TResult, TResult>(lowerMatrix, n, n, accuracy), Round<TResult, TResult>(upperMatrix, n, n, accuracy));
    }
    #endregion
}
