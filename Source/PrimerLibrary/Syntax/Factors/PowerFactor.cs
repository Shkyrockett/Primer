﻿// <copyright file="PowerFactor.cs" company="Shkyrockett" >
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
using System.Drawing.Drawing2D;
using System.Text.Json.Serialization;

namespace PrimerLibrary
{
    /// <summary>
    /// Draw an item to a power.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    /// <seealso cref="PrimerLibrary.IVariable" />
    public class PowerFactor
        : IExpression, INegatable, IVariable, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="PowerFactor"/> class.
        /// </summary>
        /// <param name="baseText">The base text.</param>
        /// <param name="powerText">The power text.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public PowerFactor(string baseText, string powerText, bool editable = false)
            : this(new TextExpression(baseText), new TextExpression(powerText), editable)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerFactor"/> class.
        /// </summary>
        /// <param name="baseExpression">The base expression.</param>
        /// <param name="powerExpression">The power expression.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public PowerFactor(IExpression baseExpression, IExpression powerExpression, bool editable = false)
        {
            Parent = null;
            Base = baseExpression;
            if (Base is IExpression b) b.Parent = this;
            Exponent = powerExpression;
            if (Exponent is IExpression e) e.Parent = this;
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
        /// Return various sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="baseSize">Size of the base.</param>
        /// <param name="powerSize">Size of the power.</param>
        /// <returns></returns>
        private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF baseSize, out SizeF powerSize)
        {
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            baseSize = Base?.Dimensions(graphics, font, scale) ?? graphics.MeasureString(" ", tempFont, PointF.Empty, StringFormat.GenericTypographic);
            using var smallFont = new Font(font.FontFamily, font.Size * MathConstants.ExponentScale, font.Style);
            powerSize = Exponent?.Dimensions(graphics, font, scale * MathConstants.ExponentScale) ?? graphics.MeasureString(" ", smallFont, PointF.Empty, StringFormat.GenericTypographic);
            return new SizeF(baseSize.Width + powerSize.Width, baseSize.Height + (powerSize.Height * MathConstants.ExponentOffsetScale));
        }

        /// <summary>
        /// Return the object's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public SizeF Dimensions(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _);

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
            var size = Dimensions(graphics, font, scale, out SizeF baseSize, out SizeF powerSize);

            if (Base is null && Exponent is null)
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size.Width, size.Height);
            }

            // Draw the base.
            var baseY = y + (powerSize.Height * MathConstants.ExponentOffsetScale);
            if (Base is not null)
            {
                Base.Draw(graphics, font, brush, pen, scale * MathConstants.ExponentScale, x, baseY, drawBounds);
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
            var powerX = x + baseSize.Width;
            if (Exponent is not null)
            {
                Exponent?.Draw(graphics, font, brush, pen, scale * MathConstants.ExponentScale, powerX, y, drawBounds);
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
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale)
        {
            Bounds = new RectangleF(location, Dimensions(graphics, font, scale, out SizeF baseSize, out SizeF powerSize));
            return Bounds ?? Rectangle.Empty;
        }
    }
}
