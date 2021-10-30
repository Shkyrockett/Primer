// <copyright file="Factories.Matricies.cs" company="Shkyrockett" >
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
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
public static partial class Factories
{
    #region Create a Matrix from a List of Row Vectors
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="vectors"></param>
    /// <returns></returns>
    public static T[,] MatrixFromVectorRows<T>(IVector<T>[] vectors)
        where T : INumber<T>
    {
        var columns = 0;
        var rows = vectors.Length;
        foreach (var vector in vectors)
        {
            columns = vector.Items.Length is int len ? len > columns ? len : columns : columns;
        }

        var matrix = new T[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = vectors[i].Items[j] ?? T.Zero;
            }
        }

        return matrix;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="vectors"></param>
    /// <returns></returns>
    public static T[,] MatrixFromVectorRows<T>(Span<T[]> vectors)
        where T : INumber<T>
    {
        var columns = 0;
        var rows = vectors.Length;
        foreach (var vector in vectors)
        {
            columns = vector.Length is int len ? len > columns ? len : columns : columns;
        }

        var matrix = new T[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = vectors[i][j] ?? T.Zero;
            }
        }

        return matrix;
    }
    #endregion

    #region Create a Matrix from a list of Vector Columns
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="vectors"></param>
    /// <returns></returns>
    public static T[,] MatrixFromVectorColumns<T>(IVector<T>[] vectors)
        where T : INumber<T>
    {
        var rows = 0;
        var columns = vectors.Length;
        foreach (var vector in vectors)
        {
            rows = vector.Items.Length is int len ? len > rows ? len : rows : rows;
        }

        var matrix = new T[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = vectors[j].Items[i] ?? T.Zero;
            }
        }

        return matrix;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="vectors"></param>
    /// <returns></returns>
    public static T[,] MatrixFromVectorColumns<T>(Span<T[]> vectors)
        where T : INumber<T>
    {
        var rows = 0;
        var columns = vectors.Length;
        foreach (var vector in vectors)
        {
            rows = vector.Length is int len ? len > rows ? len : rows : rows;
        }

        var matrix = new T[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = vectors[j][i] ?? T.Zero;
            }
        }

        return matrix;
    }
    #endregion

    #region List the Columns of a Matrix
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="matrix"></param>
    /// <returns></returns>
    public static T[][] MatrixColumns<T>(Span2D<T> matrix)
    {
        var rows = matrix.Height;

        var vectors = new T[rows][];

        for (int i = 0; i < rows; i++)
        {
            vectors[i] = matrix.GetColumn(i).ToArray();
        }

        return vectors;
    }

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    ///// <param name="matrix"></param>
    ///// <returns></returns>
    //public static ValueVector<T>[] MatrixVectorColumns<T>(Span2D<T> matrix)
    //    where T : INumber<T>
    //{
    //    var rows = matrix.Height;

    //    var vectors = new ValueVector<T>[rows];

    //    for (int i = 0; i < rows; i++)
    //    {
    //        vectors[i] = new ValueVector<T>(matrix.GetColumn(i).ToArray());
    //    }

    //    return vectors;
    //}
    #endregion

    #region List the Rows of a Matrix
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="matrix"></param>
    /// <returns></returns>
    public static T[][] MatrixRows<T>(Span2D<T> matrix)
    {
        var columns = matrix.Width;

        var vectors = new T[columns][];

        for (int i = 0; i < columns; i++)
        {
            vectors[i] = matrix.GetRow(i).ToArray();
        }

        return vectors;
    }

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    ///// <param name="matrix"></param>
    ///// <returns></returns>
    //public static ValueVector<T>[] MatrixVectorRows<T>(Span2D<T> matrix)
    //    where T : INumber<T>
    //{
    //    var columns = matrix.Width;

    //    var vectors = new ValueVector<T>[columns];

    //    for (int i = 0; i < columns; i++)
    //    {
    //        vectors[i] = new ValueVector<T>(matrix.GetRow(i).ToArray());
    //    }

    //    return vectors;
    //}
    #endregion

    #region Matrix Multiplicative Identity
    /// <summary>
    /// Creates the multiplicative identity matrix.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] MultiplicativeIdentity<T>(int rows, int columns)
        where T : INumber<T>
    {
        var identity = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                identity[i, j] = i == j ? T.One : T.Zero;
            }
        }

        return identity;
    }
    #endregion

    #region Matrix Additive Identity
    /// <summary>
    /// Creates the additive identity matrix.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] AdditiveIdentity<T>(int rows, int columns)
        where T : INumber<T>
    {
        var identity = new T[rows, columns];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < columns; j++)
            {
                identity[i, j] = T.Zero;
            }
        }

        return identity;
    }
    #endregion

    #region Matrix Randomization
    /// <summary>
    /// Random matrix generator.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] RandomNonZeroMatrix<T>(int rows, int columns) where T : INumber<T> => RandomNonZeroMatrix(rows, columns, T.Zero, T.One / T.Create(1000));

    /// <summary>
    /// Random matrix generator.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="columns">The columns.</param>
    /// <param name="lower"></param>
    /// <param name="upper"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] RandomNonZeroMatrix<T>(int rows, int columns, T lower, T upper)
        where T : INumber<T>
    {
        var nonZero = false;

        var matrix = new T[rows, columns];

        while (!nonZero)
        {
            for (var i = 0; i < rows; i++)
            {
                nonZero = false;

                for (var j = 0; j < columns; j++)
                {
                    matrix[i, j] = Operations.Random(lower, upper);

                    if (matrix[i, j] != T.Zero)
                    {
                        nonZero = true;
                    }
                }
            }
        }

        return matrix;
    }
    #endregion

    /// <summary>
    /// Generates the 1 0 vectors.
    /// </summary>
    /// <param name="kernel_dim">The kernel dim.</param>
    /// <param name="length">The length.</param>
    /// <param name="index">The index.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] Vectors_1_0<T>(int kernel_dim, int length, int index)
        where T : INumber<T>
    {
        var The_Result = new T[kernel_dim, length - 1];
        for (var i = 0; i < kernel_dim; i++)
        {
            //int Matrix_Rank = 0;
            var the_zero_position = i - 1;
            for (var j = 0; j < length - 1; j++)
            {
                The_Result[i, j] = i >= length && index == 0 || j == the_zero_position ? T.Zero : j == 0 ? -T.One : T.One;
            }
        }

        //Matrix_Rank = Matrix_Rank_Finder(kernel_dim, length - 1, The_Result, 7);
        //MessageBox.Show(Convert.ToString(Random_Matrix_Rank) + " :Rank");
        return The_Result;
    }

    #region Create Lambda Matrix
    /// <summary>
    /// Spectral decomposition. Creates the lambda matrix.
    /// </summary>
    /// <param name="eigenvalues">The eigenvalues.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] CreateLambdaMatrix<T>(Span<T> eigenvalues)
        where T : INumber<T>
    {
        var numberOfEigenvalues = eigenvalues.Length;
        var bigLambda = new T[numberOfEigenvalues, numberOfEigenvalues];
        for (var i = 0; i < numberOfEigenvalues; i++)
        {
            bigLambda[i, i] = eigenvalues[i];
        }

        return bigLambda;
    }

    /// <summary>
    /// Spectral decomposition. Creates the lambda matrix.
    /// </summary>
    /// <param name="eigenvalues">The eigenvalues.</param>
    /// <param name="numberOfEigenvalues">The number of eigenvalues.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] CreateLambdaMatrix<T>(Span<T> eigenvalues, int numberOfEigenvalues)
        where T : INumber<T>
    {
        var bigLambda = new T[numberOfEigenvalues, numberOfEigenvalues];
        for (var i = 0; i < numberOfEigenvalues; i++)
        {
            bigLambda[i, i] = eigenvalues[i];
        }
        return bigLambda;
    }

    /// <summary>
    /// Lambda Matrix Final Function.
    /// </summary>
    /// <param name="Eigenvalues">The eigenvalues.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] LambdaAllTogether<T>((int, T[], int[]) Eigenvalues)
        where T : INumber<T>
    {
        var total_number_of_eigenvalues = 0;
        for (var i = 0; i < Eigenvalues.Item1; i++)
        {
            total_number_of_eigenvalues += Eigenvalues.Item3[i];
        }

        var The_Eigenvalues_Vector = new T[total_number_of_eigenvalues];
        var k = 0;
        for (var j = 0; j < Eigenvalues.Item1; j++)
        {
            var single_eigenvalue = Eigenvalues.Item3[j];
            while (single_eigenvalue > 0)
            {
                single_eigenvalue--;
                The_Eigenvalues_Vector[k] = Eigenvalues.Item2[j];
                if (k < total_number_of_eigenvalues)
                {
                    k++;
                }
                else
                {
                    throw new Exception("Lambda Error");
                }
            }
        }

        var Big_Lambda = CreateLambdaMatrix<T>(The_Eigenvalues_Vector, total_number_of_eigenvalues);
        return Big_Lambda;
    }
    #endregion

    #region Change the Eigenvalues order
    /// <summary>
    /// Changes the values order.
    /// </summary>
    /// <param name="Eigenvalues">The eigenvalues.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (int, T[], int[]) ChangeTheValuesOrder<T>((int, T[], int[]) Eigenvalues)
        where T : INumber<T>
    {
        var Eigenvalues_copy = (Eigenvalues.Item1, Eigenvalues.Item2, Eigenvalues.Item3);
        var changed = true;
        while (changed)
        {
            changed = false;
            for (var i = 0; i < Eigenvalues_copy.Item1 - 1; i++)
            {
                if (Eigenvalues_copy.Item2[i] < Eigenvalues_copy.Item2[i + 1])
                {
                    changed = true;
                    //var temp = Eigenvalues_copy.Item2[i];
                    Eigenvalues_copy.Item2[i] = Eigenvalues_copy.Item2[i + 1];
                    Eigenvalues_copy.Item2[i + 1] = Eigenvalues_copy.Item2[i];
                    //var temp1 = Eigenvalues_copy.Item3[i];
                    Eigenvalues_copy.Item3[i] = Eigenvalues_copy.Item3[i + 1];
                    Eigenvalues_copy.Item3[i + 1] = Eigenvalues_copy.Item3[i];
                }
            }
        }

        return (Eigenvalues_copy.Item1, Eigenvalues_copy.Item2, Eigenvalues_copy.Item3);
    }
    #endregion

    #region Singular Value Decomposition Matrix
    /// <summary>
    /// SVDs the singular matrix.
    /// S matrix, Sqrt. Eigenvalues
    /// </summary>
    /// <param name="singularValues">The singular values.</param>
    /// <param name="Rank">The rank.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[,] SingularValueDecompositionSingularMatrix<T>(Span<T> singularValues, int Rank)
        where T : INumber<T>
    {
        var the_result = new T[Rank, Rank];
        for (var i = 0; i < Rank; i++)
        {
            for (var j = 0; j < Rank; j++)
            {
                the_result[i, j] = i == j ? singularValues[i] : T.Zero;
            }
        }

        return the_result;
    }
    #endregion
}
