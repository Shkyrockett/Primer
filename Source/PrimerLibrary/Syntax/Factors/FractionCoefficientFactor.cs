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
        public float Value { get { return Numerator / Denominator; } set { (Numerator, Denominator) = FractionConverter.ConvertToFraction(value); } }

        /// <summary>
        /// Gets or sets the sign of the expression.
        /// </summary>
        /// <value>
        /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
        /// </value>
        public int Sign { get { return Math.Sign(Value); } set { Value *= Math.Sign(Value) == Math.Sign(value) ? 1f : -1f; } }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is negative.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is negative; otherwise, <see langword="false" />.
        /// </value>
        public bool IsNegative { get { return Math.Sign(Value) == -1d; } set { Value *= (value == (Math.Sign(Value) == -1d)) ? 1f : -1f; } }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IEditable" /> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }
        #endregion

        /// <summary>
        /// Dimensionses the specified graphics.
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
        /// Dimensionses the specified graphics.
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
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float scale, float x, float y, bool drawBounds = false)
        {
            var size = Dimensions(graphics, font, scale, out SizeF fractionSize, out var slashSize, out var numeratorSize, out var denominatorSize, out var exponentSize);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.LightCyan, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size);
            }

            if (exponentSize.Width > 0)
            {
                Exponent?.Draw(graphics, font, brush, pen, scale * MathConstants.ExponentScale, x + fractionSize.Width, y, drawBounds);
                y += exponentSize.Height * MathConstants.ExponentOffsetScale;
            }

            using var smallFont = new Font(font.FontFamily, font.Size * scale * MathConstants.ThreeQuarters, font.Style);
            graphics.DrawString(Numerator.ToString(), smallFont, brush, x, y, StringFormat.GenericTypographic);
            var left = (numeratorSize.Width * MathConstants.OneThird) < numeratorSize.Width ? numeratorSize.Width - (numeratorSize.Width * MathConstants.OneThird) : 0f;

            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            graphics.DrawString("/", tempFont, brush, x + left, y, StringFormat.GenericTypographic);

            float x1 = x + (fractionSize.Width - denominatorSize.Width);
            float y1 = y + (slashSize.Height - denominatorSize.Height);
            graphics.DrawString(Denominator.ToString(), smallFont, brush, x1, y1, StringFormat.GenericTypographic);
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
        /// <exception cref="NotImplementedException"></exception>
        public HashSet<IRenderable> Layout(Graphics graphics, Font font, Brush brush, Pen pen, float scale, PointF location, bool drawBorders = false)
        {
            var size = Dimensions(graphics, font, scale, out SizeF fractionWidth, out var slashSize, out var numeratorSize, out var denominatorSize, out var exponentSize);
            HashSet<IRenderable> map = new HashSet<IRenderable>();

            return map;
        }
    }
}
