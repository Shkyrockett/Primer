// <copyright file="IntegralExpression.cs" company="Shkyrockett" >
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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.Json.Serialization;
using static System.Math;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    public class IntegralExpression
        : IExpression, IEditable
    {
        #region Fields
        /// <summary>
        /// Dimensions.
        /// </summary>
        private const float WidthFraction = 0.2f;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegralExpression"/> class.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <param name="above">The above.</param>
        /// <param name="below">The below.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public IntegralExpression(IExpression contents, IExpression above, IExpression below, bool editable = false)
            : this(null, contents, above, below, editable)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegralExpression"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="contents">The contents.</param>
        /// <param name="above">The above.</param>
        /// <param name="below">The below.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public IntegralExpression(IExpression? parent, IExpression contents, IExpression above, IExpression below, bool editable = false)
        {
            Parent = parent;
            Contents = contents;
            Above = above;
            Below = below;
            Editable = editable;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the contents.
        /// </summary>
        /// <value>
        /// The contents.
        /// </value>
        [JsonPropertyName("Contents")]
        public IExpression Contents { get; set; }

        /// <summary>
        /// Gets or sets the above.
        /// </summary>
        /// <value>
        /// The above.
        /// </value>
        [JsonPropertyName("Above")]
        public IExpression Above { get; set; }

        /// <summary>
        /// Gets or sets the below.
        /// </summary>
        /// <value>
        /// The below.
        /// </value>
        [JsonPropertyName("Below")]
        public IExpression Below { get; set; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        [JsonIgnore()]
        public IExpression? Parent { get; set; }

        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        /// <value>
        /// The size of the font.
        /// </value>
        public float FontSize { get; set; } = 20;

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
        public SizeF GetSize(Graphics graphics, Font font) => GetSizes(graphics, font, out _, out _, out _, out _, out _, out _, out _);

        /// <summary>
        /// Get sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="contentsSize">Size of the contents.</param>
        /// <param name="aboveSize">Size of the above.</param>
        /// <param name="belowSize">Size of the below.</param>
        /// <param name="symbolAreaWidth">Width of the symbol area.</param>
        /// <param name="symbolAreaHeight">Height of the symbol area.</param>
        /// <param name="symbolWidth">Width of the symbol.</param>
        /// <param name="symbolHeight">Height of the symbol.</param>
        /// <returns></returns>
        private SizeF GetSizes(Graphics graphics, Font font, out SizeF contentsSize, out SizeF aboveSize, out SizeF belowSize, out float symbolAreaWidth, out float symbolAreaHeight, out float symbolWidth, out float symbolHeight)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            contentsSize = Contents.GetSize(graphics, tempFont);
            aboveSize = Above.GetSize(graphics, tempFont);
            belowSize = Below.GetSize(graphics, tempFont);

            var height = Max(
                2f * (aboveSize.Height + belowSize.Height),
                contentsSize.Height);
            symbolHeight = height - (aboveSize.Height + belowSize.Height);
            symbolWidth = symbolHeight * WidthFraction;

            symbolAreaWidth = Max(
                Max(aboveSize.Width, belowSize.Width),
                symbolWidth);
            symbolAreaHeight = height;

            var width = contentsSize.Width + symbolAreaWidth;

            return new SizeF(width, height);
        }

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float x, float y)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            var size = GetSizes(graphics, font, out SizeF contents_size, out SizeF above_size, out SizeF below_size, out var symbol_area_width, out _, out var symbol_width, out var symbol_height);

            // Draw Above.
            var above_x = x + (symbol_area_width - above_size.Width) / 2f;
            Above.Draw(graphics, tempFont, brush, pen, above_x, y);

            // Draw the sigma symbol.
            var x1 = x + (symbol_area_width + symbol_width) / 2f;
            var y1 = y + above_size.Height;
            var x2 = x1 - symbol_width / 2f - symbol_width * 0.0625f;
            var y2 = y1 + symbol_width;
            var x3 = x2;
            var y3 = y1 + symbol_height - symbol_width;
            var x4 = x3 - symbol_width / 2f - symbol_width * 0.0625f;
            var y4 = y3 + symbol_width;
            var x5 = x3 + (symbol_width * 0.0625f) * 2;
            var y5 = y3;
            var x6 = x2 + (symbol_width * 0.0625f) * 2;
            var y6 = y2;
            PointF[] integral_pts =
                {
                    new PointF(x1, y1),
                    new PointF(x2, y2),
                    new PointF(x3, y3),
                    new PointF(x4, y4),
                    new PointF(x5, y5),
                    new PointF(x6, y6),
                    new PointF(x1, y1),
                };
            graphics.FillClosedCurve(brush, integral_pts);
            graphics.DrawCurve(pen, integral_pts);

            // Draw Below.
            var below_x = x + (symbol_area_width - below_size.Width) / 2f;
            var below_y = y4;
            Below.Draw(graphics, tempFont, brush, pen, below_x, below_y);

            // Draw the contents.
            var contents_x = x + symbol_area_width;
            var contents_y = y + (size.Height - contents_size.Height) / 2f;
            Contents.Draw(graphics, tempFont, brush, pen, contents_x, contents_y);
        }

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="location">The location.</param>
        /// <param name="drawBorders">if set to <see langword="true" /> [draw borders].</param>
        /// <returns></returns>
        public HashSet<IRenderable> Layout(Graphics graphics, Font font, Brush brush, Pen pen, PointF location, bool drawBorders = false)
        {
            var size = GetSizes(graphics, font, out SizeF contents_size, out SizeF above_size, out SizeF below_size, out var symbol_area_width, out _, out var symbol_width, out var symbol_height);
            var map = new HashSet<IRenderable>();

            if (drawBorders)
            {
                using var dashedPen = new Pen(Color.Red, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                map.Add(new RectangleElement(location, size, null, dashedPen));
            }

            // ToDo: Layout here.

            return map;
        }
    }
}
