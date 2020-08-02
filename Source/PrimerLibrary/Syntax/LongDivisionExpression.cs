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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

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

        /// <summary>
        /// The divisor
        /// </summary>
        private readonly IExpression Divisor;

        /// <summary>
        /// The dividend
        /// </summary>
        private readonly IExpression Dividend;

        /// <summary>
        /// The quotient
        /// </summary>
        private readonly IExpression Quotient;

        /// <summary>
        /// The remainder
        /// </summary>
        private readonly IExpression Remainder;

        /// <summary>
        /// The stack
        /// </summary>
        private readonly List<IExpression> Stack;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LongDivisionExpression"/> class.
        /// </summary>
        /// <param name="divisor">The divisor.</param>
        /// <param name="dividend">The dividend.</param>
        /// <param name="quotient">The quotient.</param>
        /// <param name="remainder">The remainder.</param>
        /// <param name="stack">The stack.</param>
        public LongDivisionExpression(IExpression divisor, IExpression dividend, IExpression quotient, IExpression remainder, List<IExpression> stack)
            : this(null, divisor, dividend, quotient, remainder, stack)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LongDivisionExpression"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="divisor">The divisor.</param>
        /// <param name="dividend">The dividend.</param>
        /// <param name="quotient">The quotient.</param>
        /// <param name="remainder">The remainder.</param>
        /// <param name="stack">The stack.</param>
        public LongDivisionExpression(IExpression? parent, IExpression divisor, IExpression dividend, IExpression quotient, IExpression remainder, List<IExpression> stack)
        {
            Parent = parent;
            Divisor = divisor;
            Dividend = dividend;
            Quotient = quotient;
            Remainder = remainder;
            Stack = stack;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public IExpression? Parent { get; set; }

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
        /// Gets or sets the font size1.
        /// </summary>
        /// <value>
        /// The font size1.
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

        public IExpression Plus(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public IExpression Add(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public IExpression Negate(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public IExpression Subtract(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public IExpression Multiply(IExpression expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set font sizes for sub-equations.
        /// </summary>
        /// <param name="fontSize"></param>
        public void SetFontSizes(float fontSize)
        {
            FontSize = fontSize;
            Divisor.SetFontSizes(fontSize);
            Dividend.SetFontSizes(fontSize);
            Quotient.SetFontSizes(fontSize);
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public SizeF GetSize(Graphics graphics, Font font)
        {
            return GetSizes(graphics, font, out _, out _, out _, out _, out _);
        }

        /// <summary>
        /// Calculate sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="divisorSize">Size of the divisor.</param>
        /// <param name="dividendSize">Size of the dividend.</param>
        /// <param name="quotientSize">Size of the quotient.</param>
        /// <param name="remainderSize">Size of the remainder.</param>
        /// <param name="stackSize">Size of the stack.</param>
        /// <returns></returns>
        private SizeF GetSizes(Graphics graphics, Font font, out SizeF divisorSize, out SizeF dividendSize, out SizeF quotientSize, out SizeF remainderSize, out SizeF stackSize)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);

            divisorSize = Divisor.GetSize(graphics, tempFont);
            dividendSize = Dividend.GetSize(graphics, tempFont);
            quotientSize = Quotient.GetSize(graphics, tempFont);
            remainderSize = Remainder.GetSize(graphics, tempFont);
            stackSize = new SizeF(dividendSize.Width, Stack.Sum((s) => s.GetSize(graphics, font).Height));

            // See how tall we must be.
            var height = ExtraHeight + divisorSize.Height + quotientSize.Height + stackSize.Height;

            // Calculate our width.
            var width = divisorSize.Width + dividendSize.Width + remainderSize.Width + ExtraWidth;

            // Set our size.
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
            var size = GetSizes(graphics, font, out SizeF divisorSize, out SizeF dividendSize, out SizeF quotientSize, out SizeF remainderSize, out SizeF stackSize);
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);

            // Draw here.
            _ = size;
            _ = dividendSize;
            _ = quotientSize;
            _ = remainderSize;
            _ = stackSize;

            Divisor.Draw(graphics, font, brush, pen, x, y + remainderSize.Height);
            Dividend.Draw(graphics, font, brush, pen, x + divisorSize.Width + ExtraWidth, y + remainderSize.Height);

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
            var size = GetSizes(graphics, font, out SizeF divisorSize, out SizeF dividendSize, out SizeF quotientSize, out SizeF remainderSize, out SizeF stackSize);
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
