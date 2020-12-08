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

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MathematicsNotationLibrary.IExpression" />
    public class IntegralFunction
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
        /// Initializes a new instance of the <see cref="IntegralFunction"/> class.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <param name="above">The above.</param>
        /// <param name="below">The below.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public IntegralFunction(IExpression contents, IExpression above, IExpression below, bool editable = false)
        {
            Parent = null;
            Argument = contents;
            if (Argument is IChild c) c.Parent = this;
            UpperLimit = above;
            if (UpperLimit is IChild a) a.Parent = this;
            LowerLimit = below;
            if (LowerLimit is IChild b) b.Parent = this;
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
        /// Gets a value indicating whether this <see cref="NumericFactor"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        /// <value>
        /// The bounds.
        /// </value>
        [JsonIgnore]
        public RectangleF? Bounds { get; set; }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [JsonIgnore]
        public PointF? Location { get => Bounds?.Location; set => Bounds = Bounds switch { null when value is PointF p => new RectangleF(p, SizeF.Empty), RectangleF b when value is PointF d => new RectangleF(d, b.Size), _ => null, }; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        [JsonIgnore]
        public SizeF? Size { get => Bounds?.Size; set => Bounds = Bounds switch { null when value is SizeF s => new RectangleF(PointF.Empty, s), RectangleF b when value is SizeF s => new RectangleF(b.Location, s), _ => null, }; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        [JsonIgnore]
        public float? Scale { get; set; }
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
        private SizeF Layout(Graphics graphics, Font font, float scale, out SizeF argumentSize, out SizeF upperLimitSize, out SizeF lowerLimitSize, out float symbolAreaWidth, out float symbolAreaHeight, out float symbolWidth, out float symbolHeight)
        {
            Scale = scale;
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            argumentSize = Argument.Layout(graphics, font, scale);
            upperLimitSize = UpperLimit.Layout(graphics, font, scale * Mathematics.LimitScale);
            lowerLimitSize = LowerLimit.Layout(graphics, font, scale * Mathematics.LimitScale);

            var height = Max((upperLimitSize.Height + lowerLimitSize.Height) * Mathematics.Two, argumentSize.Height);
            symbolHeight = height - (upperLimitSize.Height + lowerLimitSize.Height);
            symbolWidth = symbolHeight * WidthFraction;

            symbolAreaWidth = Max(Max(upperLimitSize.Width, lowerLimitSize.Width), symbolWidth);
            symbolAreaHeight = height;

            var width = argumentSize.Width + symbolAreaWidth;

            return new SizeF(width, height);
        }

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="argumentBounds">The argument bounds.</param>
        /// <param name="upperLimitBounds">The upper limit bounds.</param>
        /// <param name="lowerLimitBounds">The lower limit bounds.</param>
        /// <param name="symbolAreaWidth">Width of the symbol area.</param>
        /// <param name="symbolAreaHeight">Height of the symbol area.</param>
        /// <param name="symbolWidth">Width of the symbol.</param>
        /// <param name="symbolHeight">Height of the symbol.</param>
        /// <returns></returns>
        private RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF argumentBounds, out RectangleF upperLimitBounds, out RectangleF lowerLimitBounds, out float symbolAreaWidth, out float symbolAreaHeight, out float symbolWidth, out float symbolHeight)
        {
            var size = Layout(graphics, font, scale, out var argumentSize, out var upperLimitSize, out var lowerLimitSize, out symbolAreaWidth, out symbolAreaHeight, out symbolWidth, out symbolHeight);
            Bounds = new RectangleF(location, size);
            var above_x = location.X + ((symbolAreaWidth - upperLimitSize.Width) * Mathematics.LimitScale);
            upperLimitBounds = new RectangleF(new(above_x, location.Y), upperLimitSize);
            var below = new PointF(location.X + ((symbolAreaWidth - lowerLimitSize.Width) * Mathematics.LimitScale), location.Y + upperLimitSize.Height + symbolHeight - symbolWidth + symbolWidth);
            lowerLimitBounds = new RectangleF(below, lowerLimitSize);
            var contents = new PointF(location.X + symbolAreaWidth, location.Y + ((size.Height - argumentSize.Height) * Mathematics.LimitScale));
            argumentBounds = new RectangleF(contents, argumentSize);
            return Bounds ?? Rectangle.Empty;
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public SizeF Layout(Graphics graphics, Font font, float scale) => Layout(graphics, font, scale, out _, out _, out _, out _, out _, out _, out _);

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale) => Layout(graphics, font, location, scale, out _, out _, out _, out _, out _, out _, out _);

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        /// <returns></returns>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, PointF location, float scale, bool drawBounds = false)
        {
            var bounds = Layout(graphics, font, location, scale, out var argumentBounds, out var upperLimitBounds, out var lowerLimitBounds, out var symbolAreaWidth, out _, out var symbolWidth, out var symbolHeight);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.Orange, 1)
                {
                    DashStyle = DashStyle.Dash
                };

                graphics.DrawRectangle(dashedPen, bounds);
                graphics.DrawRectangle(dashedPen, argumentBounds);
                graphics.DrawRectangle(dashedPen, upperLimitBounds);
                graphics.DrawRectangle(dashedPen, lowerLimitBounds);
            }

            // Draw Above.
            UpperLimit.Draw(graphics, font, brush, pen, upperLimitBounds.Location, scale * Mathematics.LimitScale, drawBounds);

            // Draw the sigma symbol.
            var x1 = location.X + ((symbolAreaWidth + symbolWidth) * Mathematics.LimitScale);
            var y1 = location.Y + upperLimitBounds.Height;
            var x2 = x1 - (symbolWidth * 0.5f) - (symbolWidth * 0.0625f);
            var y2 = y1 + symbolWidth;
            var x3 = x2;
            var y3 = y1 + symbolHeight - symbolWidth;
            var x4 = x3 - (symbolWidth * 0.5f) - (symbolWidth * 0.0625f);
            var y4 = y3 + symbolWidth;
            var x5 = x3 + (symbolWidth * 0.0625f * 2f);
            var y5 = y3;
            var x6 = x2 + (symbolWidth * 0.0625f * 2f);
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
            LowerLimit.Draw(graphics, font, brush, pen, lowerLimitBounds.Location, scale * Mathematics.LimitScale, drawBounds);

            // Draw the contents.
            Argument.Draw(graphics, font, brush, pen, argumentBounds.Location, scale, drawBounds);
        }

        /// <summary>
        /// Expressions of this instance.
        /// </summary>
        /// <returns></returns>
        public HashSet<IExpression> Expressions()
        {
            var set = new HashSet<IExpression>() { this };
            if (Argument is not null) set.UnionWith(Argument.Expressions());
            if (UpperLimit is not null) set.UnionWith(UpperLimit.Expressions());
            if (LowerLimit is not null) set.UnionWith(LowerLimit.Expressions());
            return set;
        }
    }
}
