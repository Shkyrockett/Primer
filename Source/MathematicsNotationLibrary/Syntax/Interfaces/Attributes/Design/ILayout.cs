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

using System.Collections.Generic;
using System.Drawing;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILayout
        : IBoundable, ILocatable, ISizable, IScalable
    {
        /// <summary>
        /// Calculates the layout sizes for the specified graphics and scale.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public SizeF Layout(Graphics graphics, Font font, float scale);

        /// <summary>
        /// Calculates the layout bounding rectangles for the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale);

        /// <summary>
        /// Expressions of this instance.
        /// </summary>
        /// <returns></returns>
        public HashSet<IExpression> Expressions();
    }
}
