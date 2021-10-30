// <copyright file="IBoundable.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Drawing;

namespace MathematicsNotationLibrary;

/// <summary>
/// An interface that defines and object with a bounding axis aligned rectangle
/// </summary>
public interface IBoundable
{
    /// <summary>
    /// Gets the rectangle.
    /// </summary>
    /// <value>The <see cref="RectangleF"/>.</value>
    RectangleF? Bounds { get; set; }
}
