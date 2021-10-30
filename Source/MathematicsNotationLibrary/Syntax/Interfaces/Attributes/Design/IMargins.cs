// <copyright file="IMargins.cs" company="Shkyrockett" >
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
public interface IMargins
{
    /// <summary>
    /// Gets or sets the left margin.
    /// </summary>
    /// <value>
    /// The left margin.
    /// </value>
    float LeftMargin { get; set; }

    /// <summary>
    /// Gets or sets the top margin.
    /// </summary>
    /// <value>
    /// The top margin.
    /// </value>
    float TopMargin { get; set; }

    /// <summary>
    /// Gets or sets the right margin.
    /// </summary>
    /// <value>
    /// The right margin.
    /// </value>
    float RightMargin { get; set; }

    /// <summary>
    /// Gets or sets the bottom margin.
    /// </summary>
    /// <value>
    /// The bottom margin.
    /// </value>
    float BottomMargin { get; set; }
}
