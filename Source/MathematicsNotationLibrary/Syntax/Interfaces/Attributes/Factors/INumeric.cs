// <copyright file="INumeric.cs" company="Shkyrockett" >
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
public interface INumeric
    : IExpression, INegatable, IFactor
{
    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>
    /// The value.
    /// </value>
    public double Value { get; set; }

    /// <summary>
    /// Gets or sets the sign of the number.
    /// </summary>
    /// <value>
    /// The sign.
    /// </value>
    public new int Sign { get => Math.Sign(Value); set => Value = (Math.Sign(Value) == Math.Sign(value)) ? Value : -Value; }
}
