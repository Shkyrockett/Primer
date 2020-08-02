// <copyright file="IExpression.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
//     Based on the code at: http://csharphelper.com/blog/2017/09/recursively-draw-equations-in-c/ by Rod Stephens.
// </remarks>

using System.Drawing;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface IExpression
        : IEditable, ILayout
    {
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        IExpression? Parent { get; set; }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        SizeF GetSize(Graphics graphics, Font font);

        /// <summary>
        /// Sets the font sizes.
        /// </summary>
        /// <param name="fontSize">Size of the font.</param>
        void SetFontSizes(float fontSize);

        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float x, float y);
    }
}
