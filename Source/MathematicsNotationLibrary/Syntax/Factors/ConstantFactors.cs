// <copyright file="ConstantFactors.cs" company="Shkyrockett" >
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

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
public static class ConstantFactors
{
    /// <summary>
    /// The constant negative two.
    /// </summary>
    public static readonly NumericFactor NegativeTwo = new(-2d);

    /// <summary>
    /// The constant negative one.
    /// </summary>
    public static readonly NumericFactor NegativeOne = new(-1d);

    /// <summary>
    /// The negative one half fraction.
    /// </summary>
    public static readonly FractionFactor NegativeOneHalf = new(-1, 2);

    /// <summary>
    /// The constant zero.
    /// </summary>
    public static readonly NumericFactor Zero = new(0d);

    /// <summary>
    /// The one half fraction.
    /// </summary>
    public static readonly FractionFactor OneHalf = new(1, 2);

    /// <summary>
    /// The constant one.
    /// </summary>
    public static readonly NumericFactor One = new(1d);

    /// <summary>
    /// The constant two.
    /// </summary>
    public static readonly NumericFactor Two = new(2d);

    /// <summary>
    /// The constant e.
    /// </summary>
    public static readonly VariableFactor E = new('e', Math.E);

    /// <summary>
    /// The constant three.
    /// </summary>
    public static readonly NumericFactor Three = new(3d);

    /// <summary>
    /// The pi Constant.
    /// </summary>
    public static readonly VariableFactor Pi = new('π', Math.PI);

    /// <summary>
    /// The constant four.
    /// </summary>
    public static readonly NumericFactor Four = new(4d);

    /// <summary>
    /// The constant five.
    /// </summary>
    public static readonly NumericFactor Five = new(5d);

    /// <summary>
    /// The constant six.
    /// </summary>
    public static readonly NumericFactor Six = new(6d);

    /// <summary>
    /// The tau constant.
    /// </summary>
    public static readonly VariableFactor Tau = new('τ', Math.Tau);
}
