﻿// <copyright file="SigmaExpression.cs" company="Shkyrockett" >
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
    /// The sigma expression class.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class SigmaExpression
        : IExpression, INegatable, IEditable
    {
        #region Fields
        /// <summary>
        /// The contents
        /// </summary>
        private readonly IExpression Contents;

        /// <summary>
        /// The above
        /// </summary>
        private readonly IExpression Above;

        /// <summary>
        /// The below
        /// </summary>
        private readonly IExpression Below;

        /// <summary>
        /// The font size
        /// </summary>
        private float FontSize = 20;

        /// <summary>
        /// Dimensions.
        /// </summary>
        private const float FootFraction = 0.2f;

        /// <summary>
        /// Dimensions.
        /// </summary>
        private const float AspectRatio = 0.6666f;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize the contents.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <param name="above">The above.</param>
        /// <param name="below">The below.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public SigmaExpression(IExpression contents, IExpression above, IExpression below, bool editable = false)
        {
            Contents = contents;
            Above = above;
            Below = below;
            Editable = editable;
        }
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
            Contents.SetFontSizes(fontSize);
            Above.SetFontSizes(fontSize / 2f);
            Below.SetFontSizes(fontSize / 2f);
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public SizeF GetSize(Graphics graphics, Font font)
        {
            GetSizes(graphics, font, out _, out _, out _, out SizeF our_size, out _, out _, out _, out _);
            return our_size;
        }

        /// <summary>
        /// Get sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="contentsSize">Size of the contents.</param>
        /// <param name="aboveSize">Size of the above.</param>
        /// <param name="belowSize">Size of the below.</param>
        /// <param name="ourSize">Our size.</param>
        /// <param name="symbolAreaWidth">Width of the symbol area.</param>
        /// <param name="symbolAreaHeight">Height of the symbol area.</param>
        /// <param name="symbolWidth">Width of the symbol.</param>
        /// <param name="symbolHeight">Height of the symbol.</param>
        private void GetSizes(Graphics graphics, Font font, out SizeF contentsSize, out SizeF aboveSize, out SizeF belowSize, out SizeF ourSize, out float symbolAreaWidth, out float symbolAreaHeight, out float symbolWidth, out float symbolHeight)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            contentsSize = Contents.GetSize(graphics, tempFont);
            aboveSize = Above.GetSize(graphics, tempFont);
            belowSize = Below.GetSize(graphics, tempFont);

            var height = Max(1.5f * (aboveSize.Height + belowSize.Height), contentsSize.Height);
            symbolHeight = height - aboveSize.Height - belowSize.Height;
            symbolWidth = symbolHeight * AspectRatio;

            symbolAreaWidth = Max(Max(aboveSize.Width, belowSize.Width), symbolWidth);
            symbolAreaHeight = symbolHeight + aboveSize.Height + belowSize.Height;

            var width = contentsSize.Width + symbolAreaWidth;

            ourSize = new SizeF(width, height);
        }

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
            GetSizes(graphics, tempFont, out SizeF contents_size, out SizeF above_size, out SizeF below_size, out SizeF our_size, out var symbol_area_width, out var symbol_area_height, out var symbol_width, out var symbol_height);

            // Draw Above.
            var above_x = x + (symbol_area_width - above_size.Width) / 2f;
            var above_y = y + (our_size.Height - symbol_area_height) / 2f;
            Above.Draw(graphics, tempFont, pen, brush, above_x, above_y);

            // Draw the sigma symbol.
            var x1 = x + (symbol_area_width - symbol_width) / 2f;
            var x2 = x1 + symbol_width;
            var y1 = above_y + above_size.Height;
            var y2 = y1 + symbol_height / 2f;
            var y3 = y1 + symbol_height;
            PointF[] sigma_pts =
                {
                    new PointF(x2, y1 + symbol_height * FootFraction),
                    new PointF(x2, y1),
                    new PointF(x1, y1),
                    new PointF(x2, y2),
                    new PointF(x1, y3),
                    new PointF(x2, y3),
                    new PointF(x2, y3 - symbol_height * FootFraction),
                };
            graphics.DrawLines(pen, sigma_pts);

            // Draw Below.
            var below_x = x + (symbol_area_width - below_size.Width) / 2f;
            var below_y = y3;
            Below.Draw(graphics, tempFont, pen, brush, below_x, below_y);

            // Draw the contents.
            var contents_x = x + symbol_area_width;
            var contents_y = y + (our_size.Height - contents_size.Height) / 2f;
            Contents.Draw(graphics, tempFont, pen, brush, contents_x, contents_y);
        }
    }
}