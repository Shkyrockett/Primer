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

using System.Drawing;
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
        /// The font size
        /// </summary>
        private float FontSize = 20;

        /// <summary>
        /// Dimensions.
        /// </summary>
        private const float WidthFraction = 0.2f;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize the contents.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <param name="above">The above.</param>
        /// <param name="below">The below.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public IntegralExpression(IExpression contents, IExpression above, IExpression below, bool editable = false)
        {
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
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void Draw(Graphics graphics, Font font, Pen pen, Brush brush, float x, float y)
        {
            SizeF size = GetSizes(graphics, font, out SizeF contents_size, out SizeF above_size, out SizeF below_size, out var symbol_area_width, out _, out var symbol_width, out var symbol_height);
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);

            // Draw Above.
            var above_x = x + (symbol_area_width - above_size.Width) / 2f;
            Above.Draw(graphics, tempFont, pen, brush, above_x, y);

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
            Below.Draw(graphics, tempFont, pen, brush, below_x, below_y);

            // Draw the contents.
            var contents_x = x + symbol_area_width;
            var contents_y = y + (size.Height - contents_size.Height) / 2f;
            Contents.Draw(graphics, tempFont, pen, brush, contents_x, contents_y);
        }
    }
}
