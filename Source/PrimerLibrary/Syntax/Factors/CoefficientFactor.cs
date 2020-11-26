// <copyright file="CoefficientFactor.cs" company="Shkyrockett" >
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
    /// Draw some text.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    [JsonConverter(typeof(CoefficientFactor))]
    public class CoefficientFactor
        : ICoefficient, INegatable, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CoefficientFactor" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="exponent">The exponent.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public CoefficientFactor(float value = 1, IExpression? exponent = null, bool editable = false)
        {
            Parent = null;
            Value = value;
            Exponent = exponent;
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
        /// Gets or sets the exponent.
        /// </summary>
        /// <value>
        /// The exponent.
        /// </value>
        public IExpression? Exponent { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public float Value { get; set; } = 1;

        /// <summary>
        /// Gets or sets a value indicating whether [plus or minus].
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if [plus or minus]; otherwise, <see langword="false" />.
        /// </value>
        public bool PlusOrMinus { get; set; }

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get
            {
                var value = Abs(Value).ToString("R");
                value = (!IsConstant && value == "1") ? string.Empty : value;

                if (IsNegative)
                {
                    var neg = IsFirstTerm ? "-" : "−";
                    neg = PlusOrMinus ? "∓" : neg;
                    return $"{neg}{value}";
                }
                else
                {
                    var pos = IsFirstTerm ? "" : "+";
                    pos = PlusOrMinus ? "±" : pos;
                    return $"{pos}{value}";
                }
            }
        }

        /// <summary>
        /// Gets or sets the sign of the expression.
        /// </summary>
        /// <value>
        /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
        /// </value>
        public int Sign { get => Sign(Value); set => Value *= Sign(Value) == Sign(value) ? 1f : -1f; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is negative.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is negative; otherwise, <see langword="false" />.
        /// </value>
        public bool IsNegative { get => Sign(Value) == -1d; set => Value *= (value == (Sign(Value) == -1d)) ? 1f : -1f; }

        /// <summary>
        /// Gets a value indicating whether this instance is first term.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is first term; otherwise, <see langword="false" />.
        /// </value>
        public bool IsFirstTerm => Parent is not ITerm || Parent is ITerm p && p.IsFirstTerm;

        /// <summary>
        /// Gets a value indicating whether this instance is constant.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is constant; otherwise, <see langword="false" />.
        /// </value>
        public bool IsConstant => Parent is not ITerm || Parent is ITerm p && p.IsConstant;

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
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="coefficientSize">Size of the coefficient.</param>
        /// <param name="exponentSize">Size of the exponent.</param>
        /// <returns></returns>
        private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF coefficientSize, out SizeF exponentSize)
        {
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            var emHeightUnit = graphics.ConvertGraphicsUnits(tempFont.Size, tempFont.Unit, GraphicsUnit.Pixel);
            var designToUnit = emHeightUnit / tempFont.FontFamily.GetEmHeight(tempFont.Style);
            //var ascent = designToUnit * tempFont.FontFamily.GetCellAscent(tempFont.Style);
            //var descent = designToUnit * tempFont.FontFamily.GetCellDescent(tempFont.Style);
            var lineSpacing = designToUnit * tempFont.FontFamily.GetLineSpacing(tempFont.Style);

            if (string.IsNullOrEmpty(Text))
            {
                coefficientSize = new SizeF(0f, lineSpacing);
            }
            else
            {
                coefficientSize = graphics.MeasureString(Text, tempFont, Point.Empty, StringFormat.GenericTypographic);
                coefficientSize.Height = lineSpacing;
            }

            using var exponentFont = new Font(font.FontFamily, font.Size * scale * MathConstants.ExponentScale, font.Style);
            exponentSize = Exponent?.Dimensions(graphics, font, scale * MathConstants.ExponentScale) ?? new SizeF(0f, graphics.MeasureString(" ", exponentFont, Point.Empty, StringFormat.GenericTypographic).Height);

            Size = new SizeF(coefficientSize.Width + exponentSize.Width, coefficientSize.Height + ((exponentSize.Width == 0) ? 0f : exponentSize.Height * MathConstants.ExponentOffsetScale));
            return Size.Value;
        }

        /// <summary>
        /// Return the equation's size.
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
        /// <param name="location">The location.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        /// <returns></returns>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float scale, PointF location, bool drawBounds = false)
        {
            var bounds = Layout(graphics, font, location, scale, out var coefficientBounds, out var exponentBounds);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.Red, 0)
                {
                    DashStyle = DashStyle.Dash
                };

                graphics.DrawRectangle(dashedPen, coefficientBounds);
                graphics.DrawRectangle(dashedPen, exponentBounds);
                graphics.DrawRectangle(dashedPen, bounds);
            }

            if (exponentBounds.Width > 0)
            {
                Exponent?.Draw(graphics, font, brush, pen, scale * MathConstants.ExponentScale, exponentBounds.Location, drawBounds);
            }

            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            if (!string.IsNullOrEmpty(Text)) graphics.DrawString(Text, tempFont, brush, coefficientBounds.X, coefficientBounds.Y, StringFormat.GenericTypographic);
        }

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale) => Layout(graphics, font, location, scale, out _, out _);

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="coefficientBounds">The coefficient bounds.</param>
        /// <param name="exponentBounds">The exponent bounds.</param>
        /// <returns></returns>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF coefficientBounds, out RectangleF exponentBounds)
        {
            var size = Dimensions(graphics, font, scale, out var coefficientSize, out var exponentSize);
            Bounds = new RectangleF(location, size);

            if (exponentSize.Width > 0)
            {
                exponentBounds = new RectangleF(new(location.X + coefficientSize.Width, location.Y), exponentSize);
                location.Y += exponentSize.Height * MathConstants.ExponentOffsetScale;
            }
            else exponentBounds = RectangleF.Empty;

            coefficientBounds = new RectangleF(location, coefficientSize);

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
