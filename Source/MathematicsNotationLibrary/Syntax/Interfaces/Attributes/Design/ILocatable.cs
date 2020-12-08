// <copyright file="ILocatable.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Drawing;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// An interface that defines and object with a location point.
    /// </summary>
    public interface ILocatable
    {
        /// <summary>
        /// Gets the point.
        /// </summary>
        /// <value>The <see cref="PointF"/>.</value>
        PointF? Location { get; set; }
    }
}
