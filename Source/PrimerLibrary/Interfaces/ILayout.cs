// <copyright file="ILayout.cs" company="Shkyrockett" >
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

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILayout
        : IBoundable, ILocatable, ISizable, IScalable
    {
        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        RectangleF Layout(Graphics graphics, Font font, PointF location, float scale);
    }
}
