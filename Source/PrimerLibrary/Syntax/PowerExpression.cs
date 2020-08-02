// <copyright file="PowerExpression.cs" company="Shkyrockett" >
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

namespace PrimerLibrary
{
    /// <summary>
    /// Draw an item to a power.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    /// <seealso cref="PrimerLibrary.IVariable" />
    public class PowerExpression
        : IExpression, INegatable, IVariable, IEditable
    {
        #region Fields
        /// <summary>
        /// The offset
        /// </summary>
        public float Offset = 0.5f;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PowerExpression"/> class.
        /// </summary>
        /// <param name="baseText">The base text.</param>
        /// <param name="powerText">The power text.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public PowerExpression(string baseText, string powerText, bool editable = false)
            : this(null, new TextExpression(baseText), new TextExpression(powerText), editable)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerExpression"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="baseText">The base text.</param>
        /// <param name="powerText">The power text.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public PowerExpression(IExpression? parent, string baseText, string powerText, bool editable = false)
            : this(parent, new TextExpression(baseText), new TextExpression(powerText), editable)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerExpression"/> class.
        /// </summary>
        /// <param name="baseExpression">The base expression.</param>
        /// <param name="powerExpression">The power expression.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public PowerExpression(IExpression baseExpression, IExpression powerExpression, bool editable = false)
            : this(null, baseExpression, powerExpression, editable)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerExpression"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="baseExpression">The base expression.</param>
        /// <param name="powerExpression">The power expression.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public PowerExpression(IExpression? parent, IExpression baseExpression, IExpression powerExpression, bool editable = false)
        {
            Parent = parent;
            Base = baseExpression;
            Exponent = powerExpression;
            Editable = editable;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the base.
        /// </summary>
        /// <value>
        /// The base.
        /// </value>
        public IExpression Base { get; }

        /// <summary>
        /// Gets the exponent.
        /// </summary>
        /// <value>
        /// The exponent.
        /// </value>
        public IExpression Exponent { get; }

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
        /// Gets or sets the size of the font.
        /// </summary>
        /// <value>
        /// The size of the font.
        /// </value>
        public float FontSize { get; set; } = 20f;

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
            Base.SetFontSizes(fontSize);
            Exponent.SetFontSizes(fontSize * 0.75f);
        }

        /// <summary>
        /// Return the object's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public SizeF GetSize(Graphics graphics, Font font) => GetSizes(graphics, font, Offset, out _, out _);

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
            var size = GetSizes(graphics, font, Offset, out SizeF baseSize, out SizeF powerSize);

            if (Base is null && Exponent is null)
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size.Width, size.Height);
            }

            // Draw the base.
            var base_y = y + powerSize.Height * Offset;
            if (Base is not null)
            {
                Base.Draw(graphics, font, brush, pen, x, base_y);
            }
            else
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, baseSize.Width, baseSize.Height);
            }

            // Draw the power.
            var power_x = x + baseSize.Width;
            if (Exponent is not null)
            {
                Exponent.Draw(graphics, font, brush, pen, power_x, y);
            }
            else
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, powerSize.Width, powerSize.Height);
            }
        }

        /// <summary>
        /// Return various sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="baseSize">Size of the base.</param>
        /// <param name="powerSize">Size of the power.</param>
        /// <returns></returns>
        private SizeF GetSizes(Graphics graphics, Font font, float offset, out SizeF baseSize, out SizeF powerSize)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            baseSize = Base?.GetSize(graphics, tempFont) ?? graphics.MeasureString(" ", tempFont);
            using var smallFont = new Font(font.FontFamily, FontSize * offset, font.Style);
            powerSize = Exponent?.GetSize(graphics, smallFont) ?? graphics.MeasureString(" ", smallFont);
            return new SizeF(baseSize.Width + powerSize.Width, baseSize.Height + powerSize.Height * offset);
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
            var size = GetSizes(graphics, font, Offset, out SizeF baseSize, out SizeF powerSize);
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
