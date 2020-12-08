// <copyright file="IRenderable.cs" company="Shkyrockett" >
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
    /// <seealso cref="MathematicsNotationLibrary.IBoundable" />
    public interface IRenderable
        : IBoundable
    {
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
        void Draw(Graphics graphics) => Draw(graphics, Brush, Pen);

        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        void Draw(Graphics graphics, Brush? brush, Pen? pen);
    }
}
