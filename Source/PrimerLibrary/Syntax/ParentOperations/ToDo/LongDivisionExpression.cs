// <copyright file="LongDivisionExpression.cs" company="Shkyrockett" >
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
using System.Linq;
using System.Text.Json.Serialization;

namespace PrimerLibrary
{
    /// <summary>
    /// The root equation class.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class LongDivisionExpression
        : IExpression, INegatable, IEditable
    {
        #region Fields
        /// <summary>
        /// Gap between items and horizontal lines.
        /// </summary>
        private readonly float ExtraHeight = 2;

        /// <summary>
        /// Extra width of line under the index.
        /// </summary>
        private readonly float ExtraWidth = 4;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LongDivisionExpression" /> class.
        /// </summary>
        /// <param name="divisor">The divisor.</param>
        /// <param name="dividend">The dividend.</param>
        /// <param name="quotient">The quotient.</param>
        /// <param name="remainder">The remainder.</param>
        /// <param name="stack">The stack.</param>
        public LongDivisionExpression(IExpression divisor, IExpression dividend, IExpression quotient, IExpression remainder, List<IExpression> stack)
        {
            Parent = null;
            this.Divisor = divisor;
            if (this.Divisor is IExpression l) l.Parent = this;
            this.Dividend = dividend;
            if (this.Dividend is IExpression b) b.Parent = this;
            this.Quotient = quotient;
            if (this.Quotient is IExpression q) q.Parent = this;
            this.Remainder = remainder;
            if (this.Remainder is IExpression r) r.Parent = this;
            this.Stack = stack;
            for (var i = 0; i < this.Stack.Count; i++)
            {
                if (this.Stack[i] is IExpression s) s.Parent = this;
            }
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
        /// Gets or sets the long division figure.
        /// </summary>
        /// <value>
        /// The long division figure.
        /// </value>
        public LongDivisionFigure? LongDivision { get; private set; }

        /// <summary>
        /// Gets or sets the dividend.
        /// </summary>
        /// <value>
        /// The dividend.
        /// </value>
        public IExpression? Dividend { get; set; }

        /// <summary>
        /// Gets or sets the divisor.
        /// </summary>
        /// <value>
        /// The divisor.
        /// </value>
        public IExpression? Divisor { get; set; }

        /// <summary>
        /// Gets or sets the quotient.
        /// </summary>
        /// <value>
        /// The quotient.
        /// </value>
        public IExpression? Quotient { get; set; }

        /// <summary>
        /// Gets or sets the remainder.
        /// </summary>
        /// <value>
        /// The remainder.
        /// </value>
        public IExpression? Remainder { get; set; }

        /// <summary>
        /// Gets or sets the stack.
        /// </summary>
        /// <value>
        /// The stack.
        /// </value>
        public List<IExpression>? Stack { get; set; }

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
        /// Calculate sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="divisorSize">Size of the divisor.</param>
        /// <param name="dividendSize">Size of the dividend.</param>
        /// <param name="quotientSize">Size of the quotient.</param>
        /// <param name="remainderSize">Size of the remainder.</param>
        /// <param name="stackSize">Size of the stack.</param>
        /// <returns></returns>
        private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF divisorSize, out SizeF dividendSize, out SizeF quotientSize, out SizeF remainderSize, out SizeF stackSize)
        {
            divisorSize = Divisor?.Dimensions(graphics, font, scale) ?? graphics.MeasureString(" ", font, PointF.Empty, StringFormat.GenericTypographic);
            dividendSize = Dividend?.Dimensions(graphics, font, scale) ?? graphics.MeasureString(" ", font, PointF.Empty, StringFormat.GenericTypographic);
            quotientSize = Quotient?.Dimensions(graphics, font, scale) ?? graphics.MeasureString(" ", font, PointF.Empty, StringFormat.GenericTypographic);
            remainderSize = Remainder?.Dimensions(graphics, font, scale) ?? graphics.MeasureString(" ", font, PointF.Empty, StringFormat.GenericTypographic);
            stackSize = new SizeF(dividendSize.Width, Stack?.Sum((s) => s.Dimensions(graphics, font, scale).Height) ?? graphics.MeasureString(" ", font, PointF.Empty, StringFormat.GenericTypographic).Width);

            // See how tall we must be.
            var height = ExtraHeight + divisorSize.Height + quotientSize.Height + stackSize.Height;

            // Calculate our width.
            var width = divisorSize.Width + dividendSize.Width + remainderSize.Width + ExtraWidth;

            // Set our size.
            return new SizeF(width, height);
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public SizeF Dimensions(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _, out _, out _);

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        /// <returns></returns>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float scale, PointF location, bool drawBounds = false)
        {
            var size = Dimensions(graphics, font, scale, out var divisorSize, out var dividendSize, out var quotientSize, out var remainderSize, out var stackSize);
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);

            // Draw here.
            _ = size;
            _ = dividendSize;
            _ = quotientSize;
            _ = remainderSize;
            _ = stackSize;

            Divisor?.Draw(graphics, font, brush, pen, scale, new(location.X, location.Y + remainderSize.Height), drawBounds);
            Dividend?.Draw(graphics, font, brush, pen, scale, new(location.X + divisorSize.Width + ExtraWidth, location.Y + remainderSize.Height), drawBounds);

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
            Bounds = new RectangleF(location, Dimensions(graphics, font, scale, out var divisorSize, out var dividendSize, out var quotientSize, out var remainderSize, out var stackSize));

            // Layout here.
            _ = divisorSize;
            _ = dividendSize;
            _ = quotientSize;
            _ = remainderSize;
            _ = stackSize;

            return Bounds ?? Rectangle.Empty;
        }

        /// <summary>
        /// Expressions of this instance.
        /// </summary>
        /// <returns></returns>
        public HashSet<IExpression> Expressions()
        {
            var set = new HashSet<IExpression>() { this };
            if (LongDivision is not null) set.UnionWith(LongDivision.Expressions());
            if (Dividend is not null) set.UnionWith(Dividend.Expressions());
            if (Divisor is not null) set.UnionWith(Divisor.Expressions());
            if (Quotient is not null) set.UnionWith(Quotient.Expressions());
            if (Remainder is not null) set.UnionWith(Remainder.Expressions());
            if (Stack is not null)
            {
                foreach (var item in Stack)
                {
                    if (item is not null) set.UnionWith(item.Expressions());
                }
            }

            return set;
        }
    }
}
