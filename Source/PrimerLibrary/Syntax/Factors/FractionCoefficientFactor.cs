// <copyright file="FractionCoefficientFactor.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.Json.Serialization;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    /// <seealso cref="PrimerLibrary.IEditable" />
    public class FractionCoefficientFactor
        : ICoefficient, INegatable, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FractionCoefficientFactor" /> class.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public FractionCoefficientFactor(int numerator, int denominator, bool editable = false)
        {
            Parent = null;
            Numerator = numerator;
            Denominator = denominator;
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
        /// Gets or sets the exponent.
        /// </summary>
        /// <value>
        /// The exponent.
        /// </value>
        public IExpression? Exponent { get; set; }

        /// <summary>
        /// Gets or sets the numerator.
        /// </summary>
        /// <value>
        /// The numerator.
        /// </value>
        public int Numerator { get; set; }

        /// <summary>
        /// Gets or sets the denominator.
        /// </summary>
        /// <value>
        /// The denominator.
        /// </value>
        public int Denominator { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public float Value { get => Numerator / Denominator; set => (Numerator, Denominator) = FractionConverter.ConvertToFraction(value); }

        /// <summary>
        /// Gets or sets the sign of the expression.
        /// </summary>
        /// <value>
        /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
        /// </value>
        public int Sign { get => Math.Sign(Value); set => Value *= Math.Sign(Value) == Math.Sign(value) ? 1f : -1f; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is negative.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is negative; otherwise, <see langword="false" />.
        /// </value>
        public bool IsNegative { get => Math.Sign(Value) == -1d; set => Value *= (value == (Math.Sign(Value) == -1d)) ? 1f : -1f; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IEditable" /> is editable.
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
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="fractionSize">Size of the fraction.</param>
        /// <param name="slashSize">Size of the slash.</param>
        /// <param name="numeratorSize">Size of the numerator.</param>
        /// <param name="denominatorSize">Size of the denominator.</param>
        /// <param name="exponentSize">Size of the exponent.</param>
        /// <returns></returns>
        private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF fractionSize, out SizeF slashSize, out SizeF numeratorSize, out SizeF denominatorSize, out SizeF exponentSize)
        {
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            var emHeightUnitTemp = graphics.ConvertGraphicsUnits(tempFont.Size, tempFont.Unit, GraphicsUnit.Pixel);
            var designToUnitTemp = emHeightUnitTemp / tempFont.FontFamily.GetEmHeight(tempFont.Style);
            //var ascentTemp = designToUnit * tempFont.FontFamily.GetCellAscent(tempFont.Style);
            //var descentTemp = designToUnit * tempFont.FontFamily.GetCellDescent(tempFont.Style);
            var lineSpacingTemp = designToUnitTemp * tempFont.FontFamily.GetLineSpacing(tempFont.Style);

            slashSize = graphics.MeasureString("/", tempFont, Point.Empty, StringFormat.GenericTypographic);
            slashSize.Height = lineSpacingTemp;

            using var smallFont = new Font(font.FontFamily, font.Size * scale * MathConstants.ThreeQuarters, font.Style);
            var emHeightUnitSmall = graphics.ConvertGraphicsUnits(tempFont.Size, tempFont.Unit, GraphicsUnit.Pixel);
            var designToUnitSmall = emHeightUnitSmall / tempFont.FontFamily.GetEmHeight(tempFont.Style);
            //var ascentSmall = designToUnit * tempFont.FontFamily.GetCellAscent(tempFont.Style);
            //var descentSmall = designToUnit * tempFont.FontFamily.GetCellDescent(tempFont.Style);
            var lineSpacingSmall = designToUnitSmall * tempFont.FontFamily.GetLineSpacing(tempFont.Style);

            numeratorSize = graphics.MeasureString(Numerator.ToString(), smallFont, Point.Empty, StringFormat.GenericTypographic);
            //numeratorSize.Height = lineSpacingSmall;
            denominatorSize = graphics.MeasureString(Denominator.ToString(), smallFont, Point.Empty, StringFormat.GenericTypographic);
            //denominatorSize.Height = lineSpacingSmall;

            var (width, height) = slashSize;

            width += (numeratorSize.Width * MathConstants.OneThird) < numeratorSize.Width ? numeratorSize.Width - (numeratorSize.Width * MathConstants.OneThird) : 0f;
            width += (denominatorSize.Width * MathConstants.OneThird) < denominatorSize.Width ? denominatorSize.Width - (denominatorSize.Width * MathConstants.OneThird) : 0f;

            fractionSize = new SizeF(width, height);

            using var exponentFont = new Font(font.FontFamily, font.Size * scale * MathConstants.ExponentScale, font.Style);
            exponentSize = Exponent?.Dimensions(graphics, font, scale * MathConstants.ExponentScale) ?? new SizeF(0f, graphics.MeasureString(" ", exponentFont, Point.Empty, StringFormat.GenericTypographic).Height);

            width += exponentSize.Width;
            height += exponentSize.Height * MathConstants.ExponentOffsetScale;

            return new SizeF(width, height);
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public SizeF Dimensions(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _, out _, out _);

        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float scale, PointF location, bool drawBounds = false)
        {
            var bounds = Layout(graphics, font, location, scale, out var slashBounds, out var numeratorBounds, out var denominatorBounds, out var exponentBounds);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.LightCyan, 0)
                {
                    DashStyle = DashStyle.Dash
                };

                graphics.DrawRectangle(dashedPen, bounds);
            }

            if (exponentBounds.Width > 0)
            {
                Exponent?.Draw(graphics, font, brush, pen, scale * MathConstants.ExponentScale, exponentBounds.Location, drawBounds);
            }

            using var smallFont = new Font(font.FontFamily, font.Size * scale * MathConstants.ThreeQuarters, font.Style);
            graphics.DrawString(Numerator.ToString(), smallFont, brush, numeratorBounds.Location, StringFormat.GenericTypographic);

            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            graphics.DrawString("/", tempFont, brush, slashBounds.Location, StringFormat.GenericTypographic);

            graphics.DrawString(Denominator.ToString(), smallFont, brush, denominatorBounds.Location, StringFormat.GenericTypographic);
        }

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale) => Layout(graphics, font, location, scale, out _, out _, out _, out _);

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="slashBounds">The slash bounds.</param>
        /// <param name="numeratorBounds">The numerator bounds.</param>
        /// <param name="denominatorBounds">The denominator bounds.</param>
        /// <param name="exponentBounds">The exponent bounds.</param>
        /// <returns></returns>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF slashBounds, out RectangleF numeratorBounds, out RectangleF denominatorBounds, out RectangleF exponentBounds)
        {
            var size = Dimensions(graphics, font, scale, out var fractionSize, out var slashSize, out var numeratorSize, out var denominatorSize, out var exponentSize);
            Bounds = new RectangleF(location, size);

            if (exponentSize.Width > 0)
            {
                exponentBounds = new RectangleF(new(location.X + fractionSize.Width, location.Y), exponentSize);
                location.Y += exponentSize.Height * MathConstants.ExponentOffsetScale;
            }
            else exponentBounds = Rectangle.Empty;

            numeratorBounds = new RectangleF(location, numeratorSize);
            var left = (numeratorSize.Width * MathConstants.OneThird) < numeratorSize.Width ? numeratorSize.Width - (numeratorSize.Width * MathConstants.OneThird) : 0f;
            slashBounds = new RectangleF(new PointF(location.X + left, location.Y), slashSize);
            denominatorBounds = new RectangleF(new PointF(location.X + (fractionSize.Width - denominatorSize.Width), location.Y + (slashSize.Height - denominatorSize.Height)), denominatorSize);
            return Bounds ?? Rectangle.Empty;
        }

        /// <summary>
        /// Expressions of this instance.
        /// </summary>
        /// <returns></returns>
        public HashSet<IExpression> Expressions()
        {
            var set = new HashSet<IExpression>() { this };
            if (Exponent is not null) set.UnionWith(Exponent.Expressions());
            return set;
        }
    }
}
