// <copyright file="IFunction.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
/// <seealso cref="IFactor" />
public interface IFunction
    : IFactor
{
    /// <summary>
    /// Gets or sets the argument of the function.
    /// </summary>
    /// <value>
    /// The argument.
    /// </value>
    IExpression? Argument { get; set; }
}
