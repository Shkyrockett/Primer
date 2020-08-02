// <copyright file="RectangleElement.cs" company="Shkyrockett" >
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
    /// <seealso cref="PrimerLibrary.IRenderable" />
    internal class RectangleElement
        : IRenderable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RectangleElement" /> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="size">The size.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        public RectangleElement(PointF location, SizeF size, Brush? brush, Pen? pen)
        {
            Bounds = new RectangleF(location, size);
            Brush = brush;
            Pen = pen;
        }

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        /// <value>
        /// The bounds.
        /// </value>
        public RectangleF Bounds { get; }

        /// <summary>
        /// Gets or sets the brush.
        /// </summary>
        /// <value>
        /// The brush.
        /// </value>
        public Brush? Brush { get; set; }

        /// <summary>
        /// Gets or sets the pen.
        /// </summary>
        /// <value>
        /// The pen.
        /// </value>
        public Pen? Pen { get; set; }

        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public void Draw(Graphics graphics) => Draw(graphics, Brush, Pen);

        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        public void Draw(Graphics graphics, Brush? brush, Pen? pen)
        {
            if (brush is not null) graphics.FillRectangle(brush, Rectangle.Round(Bounds));
            if (pen is not null) graphics.DrawRectangle(pen, Rectangle.Round(Bounds));
        }
    }
}