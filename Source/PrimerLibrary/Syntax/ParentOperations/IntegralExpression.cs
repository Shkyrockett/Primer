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
        /// <param name="parent">The parent.</param>
        /// <param name="contents">The contents.</param>
        /// <param name="above">The above.</param>
        /// <param name="below">The below.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public IntegralExpression(IExpression contents, IExpression above, IExpression below, bool editable = false)
        {
            Parent = null;
            Argument = contents;
            if (Argument is IExpression c) c.Parent = this;
            UpperLimit = above;
            if (UpperLimit is IExpression a) a.Parent = this;
            LowerLimit = below;
            if (LowerLimit is IExpression b) b.Parent = this;
            Editable = editable;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        [JsonIgnore]
        public IExpression? Parent { get; set; }

        /// <summary>
        /// Gets or sets the contents.
        /// </summary>
        /// <value>
        /// The contents.
        /// </value>
        [JsonPropertyName("Argument")]
        public IExpression Argument { get; set; }

        /// <summary>
        /// Gets or sets the above.
        /// </summary>
        /// <value>
        /// The above.
        /// </value>
        [JsonPropertyName("UpperLimit")]
        public IExpression UpperLimit { get; set; }

        /// <summary>
        /// Gets or sets the below.
        /// </summary>
        /// <value>
        /// The below.
        /// </value>
        [JsonPropertyName("LowerLimit")]
        public IExpression LowerLimit { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CoefficientFactor"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }
        #endregion

        /// <summary>
        /// Get sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="argumentSize">Size of the contents.</param>
        /// <param name="upperLimitSize">Size of the above.</param>
        /// <param name="lowerLimitSize">Size of the below.</param>
        /// <param name="symbolAreaWidth">Width of the symbol area.</param>
        /// <param name="symbolAreaHeight">Height of the symbol area.</param>
        /// <param name="symbolWidth">Width of the symbol.</param>
        /// <param name="symbolHeight">Height of the symbol.</param>
        /// <returns></returns>
        private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF argumentSize, out SizeF upperLimitSize, out SizeF lowerLimitSize, out float symbolAreaWidth, out float symbolAreaHeight, out float symbolWidth, out float symbolHeight)
        {
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            argumentSize = Argument.Dimensions(graphics, font, scale);
            upperLimitSize = UpperLimit.Dimensions(graphics, font, scale * MathConstants.LimitScale);
            lowerLimitSize = LowerLimit.Dimensions(graphics, font, scale * MathConstants.LimitScale);

            var height = Max((upperLimitSize.Height + lowerLimitSize.Height) * MathConstants.Two, argumentSize.Height);
            symbolHeight = height - (upperLimitSize.Height + lowerLimitSize.Height);
            symbolWidth = symbolHeight * WidthFraction;

            symbolAreaWidth = Max(Max(upperLimitSize.Width, lowerLimitSize.Width), symbolWidth);
            symbolAreaHeight = height;

            var width = argumentSize.Width + symbolAreaWidth;

            return new SizeF(width, height);
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public SizeF Dimensions(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _, out _, out _, out _, out _);

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float scale, float x, float y, bool drawBounds = false)
        {
            var size = Dimensions(graphics, font, scale, out SizeF contents_size, out SizeF above_size, out SizeF below_size, out var symbol_area_width, out _, out var symbol_width, out var symbol_height);

            // Draw Above.
            var above_x = x + ((symbol_area_width - above_size.Width) * MathConstants.LimitScale);
            UpperLimit.Draw(graphics, font, brush, pen, scale * MathConstants.LimitScale, above_x, y, drawBounds);

            // Draw the sigma symbol.
            var x1 = x + ((symbol_area_width + symbol_width) * MathConstants.LimitScale);
            var y1 = y + above_size.Height;
            var x2 = x1 - (symbol_width * 0.5f) - (symbol_width * 0.0625f);
            var y2 = y1 + symbol_width;
            var x3 = x2;
            var y3 = y1 + symbol_height - symbol_width;
            var x4 = x3 - (symbol_width * 0.5f) - (symbol_width * 0.0625f);
            var y4 = y3 + symbol_width;
            var x5 = x3 + (symbol_width * 0.0625f * 2f);
            var y5 = y3;
            var x6 = x2 + (symbol_width * 0.0625f * 2f);
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
            var below_x = x + ((symbol_area_width - below_size.Width) * MathConstants.LimitScale);
            var below_y = y4;
            LowerLimit.Draw(graphics, font, brush, pen, scale * MathConstants.LimitScale, below_x, below_y, drawBounds);

            // Draw the contents.
            var contents_x = x + symbol_area_width;
            var contents_y = y + ((size.Height - contents_size.Height) * MathConstants.LimitScale);
            Argument.Draw(graphics, font, brush, pen, scale, contents_x, contents_y, drawBounds);
        }

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <param name="drawBorders">if set to <see langword="true" /> [draw borders].</param>
        /// <returns></returns>
        public HashSet<IRenderable> Layout(Graphics graphics, Font font, Brush brush, Pen pen, float scale, PointF location, bool drawBorders = false)
        {
            var size = Dimensions(graphics, font, scale, out SizeF contents_size, out SizeF above_size, out SizeF below_size, out var symbol_area_width, out _, out var symbol_width, out var symbol_height);
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
