// <copyright file="SigmaExpression.cs" company="Shkyrockett" >
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
    /// The sigma expression class.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class SigmaExpression
        : IExpression, INegatable, IEditable
    {
        #region Fields
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
        /// Initializes a new instance of the <see cref="SigmaExpression" /> class.
        /// </summary>
        /// <param name="argument">The contents.</param>
        /// <param name="upperLimit">The above.</param>
        /// <param name="lowerLimit">The below.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public SigmaExpression(IExpression? argument, IExpression? upperLimit, RelationalOperation? lowerLimit, bool editable = false)
        {
            Parent = null;
            Argument = argument;
            if (Argument is IExpression c) c.Parent = this;
            UpperLimit = upperLimit;
            if (UpperLimit is IExpression a) a.Parent = this;
            LowerLimit = lowerLimit;
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
        /// Gets the argument.
        /// </summary>
        /// <value>
        /// The argument.
        /// </value>
        public IExpression? Argument { get; }

        /// <summary>
        /// Gets the upper limit.
        /// </summary>
        /// <value>
        /// The upper limit.
        /// </value>
        public IExpression? UpperLimit { get; }

        /// <summary>
        /// Gets the lower limit.
        /// </summary>
        /// <value>
        /// The lower limit.
        /// </value>
        public RelationalOperation? LowerLimit { get; }

        /// <summary>
        /// Gets or sets the sign of the expression.
        /// </summary>
        /// <value>
        /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
        /// </value>
        public int Sign { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is negative.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is negative; otherwise, <see langword="false" />.
        /// </value>
        public bool IsNegative { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CoefficientFactor"/> is editable.
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
        public PointF? Location { get { return Bounds?.Location; } set { if (Bounds is RectangleF b && value is PointF p) Bounds = new RectangleF(p, b.Size); } }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        [JsonIgnore]
        public SizeF? Size { get { return Bounds?.Size; } set { if (Bounds is RectangleF b && value is SizeF s) Bounds = new RectangleF(b.Location, s); } }

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
        /// <param name="contentsSize">Size of the contents.</param>
        /// <param name="aboveSize">Size of the above.</param>
        /// <param name="belowSize">Size of the below.</param>
        /// <param name="symbolAreaWidth">Width of the symbol area.</param>
        /// <param name="symbolAreaHeight">Height of the symbol area.</param>
        /// <param name="symbolWidth">Width of the symbol.</param>
        /// <param name="symbolHeight">Height of the symbol.</param>
        /// <returns></returns>
        private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF contentsSize, out SizeF aboveSize, out SizeF belowSize, out float symbolAreaWidth, out float symbolAreaHeight, out float symbolWidth, out float symbolHeight)
        {
            contentsSize = Argument?.Dimensions(graphics, font, scale) ?? graphics.MeasureString(" ", font, PointF.Empty, StringFormat.GenericTypographic);
            aboveSize = UpperLimit?.Dimensions(graphics, font, scale * 0.5f) ?? graphics.MeasureString(" ", font, PointF.Empty, StringFormat.GenericTypographic);
            belowSize = LowerLimit?.Dimensions(graphics, font, scale * 0.5f) ?? graphics.MeasureString(" ", font, PointF.Empty, StringFormat.GenericTypographic);

            var height = Max(1.5f * (aboveSize.Height + belowSize.Height), contentsSize.Height);
            symbolHeight = height - aboveSize.Height - belowSize.Height;
            symbolWidth = symbolHeight * AspectRatio;

            symbolAreaWidth = Max(Max(aboveSize.Width, belowSize.Width), symbolWidth);
            symbolAreaHeight = symbolHeight + aboveSize.Height + belowSize.Height;

            var width = contentsSize.Width + symbolAreaWidth;

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
            var size = Dimensions(graphics, font, scale, out SizeF contents_size, out SizeF above_size, out SizeF below_size, out var symbol_area_width, out var symbol_area_height, out var symbol_width, out var symbol_height);

            // Draw Above.
            var above_x = x + ((symbol_area_width - above_size.Width) * 0.5f);
            var above_y = y + ((size.Height - symbol_area_height) * 0.5f);
            UpperLimit?.Draw(graphics, font, brush, pen, scale * 0.5f, above_x, above_y, drawBounds);

            // Draw the sigma symbol.
            var x1 = x + ((symbol_area_width - symbol_width) * 0.5f);
            var x2 = x1 + symbol_width;
            var y1 = above_y + above_size.Height;
            var y2 = y1 + (symbol_height * 0.5f);
            var y3 = y1 + symbol_height;
            PointF[] sigma_pts =
                {
                    new PointF(x2, y1 + (symbol_height * FootFraction)),
                    new PointF(x2, y1),
                    new PointF(x1, y1),
                    new PointF(x2, y2),
                    new PointF(x1, y3),
                    new PointF(x2, y3),
                    new PointF(x2, y3 - (symbol_height * FootFraction)),
                };
            graphics.DrawLines(pen, sigma_pts);

            // Draw Below.
            var below_x = x + ((symbol_area_width - below_size.Width) * 0.5f);
            var below_y = y3;
            LowerLimit?.Draw(graphics, font, brush, pen, scale * 0.5f, below_x, below_y, drawBounds);

            // Draw the contents.
            var contents_x = x + symbol_area_width;
            var contents_y = y + ((size.Height - contents_size.Height) * 0.5f);
            Argument?.Draw(graphics, font, brush, pen, scale, contents_x, contents_y, drawBounds);
        }

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale)
        {
            Bounds = new RectangleF(location, Dimensions(graphics, font, scale, out SizeF contents_size, out SizeF above_size, out SizeF below_size, out var symbol_area_width, out var symbol_area_height, out var symbol_width, out var symbol_height)); ;
            return Bounds ?? Rectangle.Empty;
        }
    }
}
