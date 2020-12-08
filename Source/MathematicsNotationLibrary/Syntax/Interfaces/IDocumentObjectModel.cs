// <copyright file="IDocumentObjectModel.cs" company="Shkyrockett" >
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
    /// 
    /// </summary>
    public interface IDocumentObjectModel
        : ILayout
    {
        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="drawBorders">if set to <see langword="true" /> [draw borders].</param>
        void Draw(Graphics graphics, Font font, Brush brush, Pen pen, PointF location, float scale, bool drawBorders = false);
    }
}
