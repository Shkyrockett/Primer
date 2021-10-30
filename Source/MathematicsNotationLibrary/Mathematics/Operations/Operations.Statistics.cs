// <copyright file="Operations.Statistics.cs" company="Shkyrockett" >
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
    #region Summation
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/#generic-math
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Sum<T, TResult>(Span<T> values)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var result = TResult.Zero;

        foreach (var value in values)
        {
            result += TResult.Create(value);
        }

        return result;
    }
    #endregion

    #region Averaging
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/#generic-math
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Average<T, TResult>(Span<T> values)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        var sum = Sum<T, TResult>(values);
        return TResult.Create(sum) / TResult.Create(values.Length);
    }
    #endregion

    #region Standard Deviation
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="values"></param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/#generic-math
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult StandardDeviation<T, TResult>(Span<T> values)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        var standardDeviation = TResult.Zero;

        if (!values.IsEmpty)
        {
            TResult average = Average<T, TResult>(values);
            TResult sum = Sum<TResult, TResult>(values.Select((value) =>
            {
                var deviation = TResult.Create(value) - average;
                return deviation * deviation;
            }));
            standardDeviation = TResult.Sqrt(sum / TResult.Create(values.Length - 1));
        }

        return standardDeviation;
    }
    #endregion
}
