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

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.Json.Serialization;
using static System.Math;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// The sigma expression class.
    /// </summary>
    public class SigmaFunction
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
        /// Initializes a new instance of the <see cref="SigmaFunction" /> class.
        /// </summary>
        /// <param name="argument">The contents.</param>
        /// <param name="upperLimit">The above.</param>
        /// <param name="lowerLimit">The below.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public SigmaFunction(IExpression? argument, IExpression? upperLimit, RelationalOperation? lowerLimit, bool editable = false)
        {
            Parent = null;
            Argument = argument;
            if (Argument is IChild c) c.Parent = this;
            UpperLimit = upperLimit;
            if (UpperLimit is IChild a) a.Parent = this;
            LowerLimit = lowerLimit;
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
        /// Gets or sets a value indicating whether the value is either positive or negative.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if [plus or minus]; otherwise, <see langword="false" />.
        /// </value>
        public bool PlusOrMinus { get; set; }

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
        /// <param name="contentsSize">Size of the contents.</param>
        /// <param name="aboveSize">Size of the above.</param>
        /// <param name="belowSize">Size of the below.</param>
        /// <param name="symbolAreaWidth">Width of the symbol area.</param>
        /// <param name="symbolAreaHeight">Height of the symbol area.</param>
        /// <param name="symbolWidth">Width of the symbol.</param>
        /// <param name="symbolHeight">Height of the symbol.</param>
        /// <returns></returns>
        private SizeF Layout(Graphics graphics, Font font, float scale, out SizeF contentsSize, out SizeF aboveSize, out SizeF belowSize, out float symbolAreaWidth, out float symbolAreaHeight, out float symbolWidth, out float symbolHeight)
        {
            Scale = scale;
            contentsSize = Argument?.Layout(graphics, font, scale) ?? graphics.MeasureString(" ", font, PointF.Empty, StringFormat.GenericTypographic);
            aboveSize = UpperLimit?.Layout(graphics, font, scale * 0.5f) ?? graphics.MeasureString(" ", font, PointF.Empty, StringFormat.GenericTypographic);
            belowSize = LowerLimit?.Layout(graphics, font, scale * 0.5f) ?? graphics.MeasureString(" ", font, PointF.Empty, StringFormat.GenericTypographic);

            var height = Max(1.5f * (aboveSize.Height + belowSize.Height), contentsSize.Height);
            symbolHeight = height - aboveSize.Height - belowSize.Height;
            symbolWidth = symbolHeight * AspectRatio;

            symbolAreaWidth = Max(Max(aboveSize.Width, belowSize.Width), symbolWidth);
            symbolAreaHeight = symbolHeight + aboveSize.Height + belowSize.Height;

            var width = contentsSize.Width + symbolAreaWidth;

            return new SizeF(width, height);
        }

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="contentsBounds">The contents bounds.</param>
        /// <param name="aboveBounds">The above bounds.</param>
        /// <param name="belowBounds">The below bounds.</param>
        /// <param name="symbolAreaWidth">Width of the symbol area.</param>
        /// <param name="symbolAreaHeight">Height of the symbol area.</param>
        /// <param name="symbolWidth">Width of the symbol.</param>
        /// <param name="symbolHeight">Height of the symbol.</param>
        /// <returns></returns>
        private RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF contentsBounds, out RectangleF aboveBounds, out RectangleF belowBounds, out float symbolAreaWidth, out float symbolAreaHeight, out float symbolWidth, out float symbolHeight)
        {
            var size = Layout(graphics, font, scale, out var contentsSize, out var aboveSize, out var belowSize, out symbolAreaWidth, out symbolAreaHeight, out symbolWidth, out symbolHeight);
            Bounds = new RectangleF(location, size);
            aboveBounds = new RectangleF(new PointF(location.X + ((symbolAreaWidth - aboveSize.Width) * 0.5f), location.Y + ((size.Height - symbolAreaHeight) * 0.5f)), aboveSize);
            belowBounds = new RectangleF(new PointF(location.X + ((symbolAreaWidth - belowSize.Width) * 0.5f), aboveBounds.Y + aboveBounds.Height + symbolHeight), belowSize);
            contentsBounds = new RectangleF(new PointF(location.X + symbolAreaWidth, location.Y + ((size.Height - contentsSize.Height) * 0.5f)), contentsSize);
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
            var bounds = Layout(graphics, font, location, scale, out var contentsBounds, out var aboveBounds, out var belowBounds, out var symbolAreaWidth, out _, out var symbolWidth, out var symbolHeight);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.Orange, 1)
                {
                    DashStyle = DashStyle.Dash
                };

                graphics.DrawRectangle(dashedPen, bounds);
                graphics.DrawRectangle(dashedPen, contentsBounds);
                graphics.DrawRectangle(dashedPen, aboveBounds);
                graphics.DrawRectangle(dashedPen, belowBounds);
            }

            // Draw Above.
            UpperLimit?.Draw(graphics, font, brush, pen, aboveBounds.Location, scale * 0.5f, drawBounds);

            // Draw the sigma symbol.
            var x1 = location.X + ((symbolAreaWidth - symbolWidth) * 0.5f);
            var x2 = x1 + symbolWidth;
            var y1 = aboveBounds.Y + aboveBounds.Height;
            var y2 = y1 + (symbolHeight * 0.5f);
            var y3 = y1 + symbolHeight;
            PointF[] sigma_pts =
                {
                    new PointF(x2, y1 + (symbolHeight * FootFraction)),
                    new PointF(x2, y1),
                    new PointF(x1, y1),
                    new PointF(x2, y2),
                    new PointF(x1, y3),
                    new PointF(x2, y3),
                    new PointF(x2, y3 - (symbolHeight * FootFraction)),
                };
            graphics.DrawLines(pen, sigma_pts);

            // Draw Below.
            LowerLimit?.Draw(graphics, font, brush, pen, belowBounds.Location, scale * 0.5f, drawBounds);

            // Draw the contents.
            Argument?.Draw(graphics, font, brush, pen, contentsBounds.Location, scale, drawBounds);
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
