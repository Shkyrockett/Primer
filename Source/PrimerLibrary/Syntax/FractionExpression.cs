// <copyright file="FractionExpression.cs" company="Shkyrockett" >
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
using static System.Math;

namespace PrimerLibrary
{
    /// <summary>
    /// Draw one item over another.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class FractionExpression
        : IExpression, INegatable, IEditable
    {
        #region Fields
        /// <summary>
        /// True to draw a separator line.
        /// </summary>
        public bool DrawSeparator;

        /// <summary>
        /// The space between the top and bottom items.
        /// </summary>
        private const float Gap = 0;

        /// <summary>
        /// Extra width for the separator (on each side).
        /// </summary>
        private const float ExtraWidth = 6;

        /// <summary>
        /// The numerator
        /// </summary>
        private readonly IExpression Numerator;

        /// <summary>
        /// The denominator
        /// </summary>
        private readonly IExpression Denominator;

        /// <summary>
        /// The font size
        /// </summary>
        private float FontSize = 20;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize a new object.
        /// </summary>
        /// <param name="topExpression">The top expression.</param>
        /// <param name="denominatorExpression">The denominator expression.</param>
        /// <param name="showHorizontalBar">if set to <see langword="true" /> [show horizontal bar].</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public FractionExpression(IExpression topExpression, IExpression denominatorExpression, bool showHorizontalBar = true, bool editable = false)
        {
            Numerator = topExpression;
            Denominator = denominatorExpression;
            DrawSeparator = showHorizontalBar;
            Editable = editable;
        }

        /// <summary>
        /// Initialize a new object.
        /// </summary>
        /// <param name="topText">The top text.</param>
        /// <param name="bottomText">The bottom text.</param>
        /// <param name="showHorizontalBar">if set to <see langword="true" /> [show horizontal bar].</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public FractionExpression(string topText, string bottomText, bool showHorizontalBar = true, bool editable = false)
            : this(new TextExpression(topText), new TextExpression(bottomText), showHorizontalBar, editable)
        { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether this instance is negative.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is negative; otherwise, <see langword="false" />.
        /// </value>
        public bool IsNegative { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CoefficientExpression"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }
        #endregion

        /// <summary>
        /// Set font sizes for sub-equations.
        /// </summary>
        /// <param name="fontSize"></param>
        public void SetFontSizes(float fontSize)
        {
            FontSize = fontSize;
            Numerator.SetFontSizes(fontSize * 0.75f);
            Denominator.SetFontSizes(fontSize * 0.75f);
        }

        /// <summary>
        /// Return the object's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public SizeF GetSize(Graphics graphics, Font font) => GetSizes(graphics, font, out _, out _);

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void Draw(Graphics graphics, Font font, Pen pen, Brush brush, float x, float y)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            var size = GetSizes(graphics, tempFont, out SizeF top_size, out SizeF bottom_size);

            // Draw the separator.
            if (DrawSeparator)
            {
                var separator_y = y + top_size.Height + Gap / 2;
                graphics.DrawLine(pen,
                    x, separator_y,
                    x + size.Width, separator_y);
            }

            // Draw the top.
            var top_x = x + (size.Width - top_size.Width) / 2;
            Numerator.Draw(graphics, tempFont, pen, brush, top_x, y);

            // Draw the bottom.
            var bottom_x = x + (size.Width - bottom_size.Width) / 2;
            var bottom_y = y + top_size.Height + Gap;
            Denominator.Draw(graphics, tempFont, pen, brush, bottom_x, bottom_y);
        }

        /// <summary>
        /// Return various sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="topSize">Size of the top.</param>
        /// <param name="bottomSize">Size of the bottom.</param>
        /// <returns></returns>
        private SizeF GetSizes(Graphics graphics, Font font, out SizeF topSize, out SizeF bottomSize)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            topSize = Numerator.GetSize(graphics, tempFont);
            bottomSize = Denominator.GetSize(graphics, tempFont);
            return new SizeF(Max(topSize.Width, bottomSize.Width) + 2 * ExtraWidth, topSize.Height + bottomSize.Height + Gap);
        }
    }
}
