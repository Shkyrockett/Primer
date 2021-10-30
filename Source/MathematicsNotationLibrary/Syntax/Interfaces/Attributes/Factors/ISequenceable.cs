// <copyright file="IExponentableFactor.cs" company="Shkyrockett" >
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
public interface ISequenceable
    : IFactor
{
    /// <summary>
    /// Gets or sets the sequence.
    /// </summary>
    /// <value>
    /// The sequence.
    /// </value>
    public INumeric? Sequence { get; set; }
}
