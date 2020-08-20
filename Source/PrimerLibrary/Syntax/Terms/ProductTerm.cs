// <copyright file="ProductTerm.cs" company="Shkyrockett" >
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
using System.Text.Json.Serialization;
using static System.Math;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    [JsonConverter(typeof(ProductTerm))]
    public class ProductTerm
        : ITerm, INegatable, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTerm" /> class.
        /// </summary>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="expressions">The expressions.</param>
        public ProductTerm(float coefficient, params IFactor[] expressions)
            : this(new CoefficientFactor(coefficient), false, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTerm" /> class.
        /// </summary>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        /// <param name="expressions">The expressions.</param>
        public ProductTerm(float coefficient, bool editable = false, params IFactor[] expressions)
            : this(new CoefficientFactor(coefficient), editable, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTerm" /> class.
        /// </summary>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="expressions">The expressions.</param>
        public ProductTerm(ICoefficient coefficient, params IFactor[] expressions)
            : this(coefficient, false, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTerm" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        /// <param name="expressions">The expressions.</param>
        public ProductTerm(ICoefficient coefficient, bool editable = false, params IFactor[] expressions)
        {
            Parent = null;
            Coefficient = coefficient;
            if (Coefficient is IExpression c) c.Parent = this;
            Factors = new List<IFactor>(expressions);
            for (int i = 0; i < Factors.Count; i++)
            {
                if (Factors[i] is IExpression f) f.Parent = this;
            }
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
        /// Gets the coefficient.
        /// </summary>
        /// <value>
        /// The coefficient.
        /// </value>
        [JsonInclude, JsonPropertyName("Editable")]
        public ICoefficient Coefficient { get; private set; }

        /// <summary>
        /// Gets or sets the expressions.
        /// </summary>
        /// <value>
        /// The expressions.
        /// </value>
        [JsonInclude, JsonPropertyName("Editable")]
        public List<IFactor> Factors { get; set; }

        /// <summary>
        /// Gets or sets the sign of the expression.
        /// </summary>
        /// <value>
        /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
        /// </value>
        public int Sign
        {
            get { return Coefficient?.Sign ?? 1; }
            set
            {
                if (Coefficient is null)
                {
                    Coefficient = new CoefficientFactor(value);
                }
                else
                {
                    Coefficient.Sign = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is negative.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is negative; otherwise, <see langword="false" />.
        /// </value>
        public bool IsNegative
        {
            get { return Coefficient?.IsNegative ?? false; }
            set
            {
                if (Coefficient is null)
                {
                    Coefficient = new CoefficientFactor(1);
                }
                else
                {
                    Coefficient.IsNegative = value;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CoefficientFactor"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is first term.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is first term; otherwise, <see langword="false" />.
        /// </value>
        public bool IsFirstTerm => (Parent is not NomialExpression) || (Parent is NomialExpression p) && ReferenceEquals(p.Terms?[0], this);

        /// <summary>
        /// Gets a value indicating whether this instance is constant.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if this instance is constant; otherwise, <see langword="false" />.
        /// </value>
        public bool IsConstant => Coefficient is not null && (Factors is null || Factors.Count < 1);
        #endregion

        /// <summary>
        /// Return various sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="coefficientSize">Size of the coefficient.</param>
        /// <param name="factorsSizes">The nomial sizes.</param>
        /// <returns></returns>
        private unsafe SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF coefficientSize, out Span<SizeF> factorsSizes)
        {
            var (width, maxHeight) = coefficientSize = Coefficient.Dimensions(graphics, font, scale);

            factorsSizes = new SizeF[Factors.Count];
            for (int i = 0; i < Factors.Count; i++)
            {
                var factorSize = factorsSizes[i] = Factors[i].Dimensions(graphics, font, scale);
                maxHeight = Max(maxHeight, factorSize.Height);
                width += factorSize.Width;
            }

            return new SizeF(width, maxHeight);
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
            var size = Dimensions(graphics, font, scale, out SizeF coefficientSize, out var factorsSizes);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.Red, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size.Width, size.Height);
            }

            Coefficient?.Draw(graphics, font, brush, pen, scale, x, y + ((size.Height - coefficientSize.Height) * MathConstants.OneHalf), drawBounds);
            x += coefficientSize.Width;

            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            var factor = Factors?.Count > 0 ? Factors[0] : null;
            var factorSize = factorsSizes.Length > 0 ? factorsSizes[0] : graphics.MeasureString(" ", tempFont, PointF.Empty, StringFormat.GenericTypographic);
            factor?.Draw(graphics, font, brush, pen, scale, x, y + ((size.Height - factorSize.Height) * MathConstants.OneHalf), drawBounds);
            x += factorSize.Width;

            for (int i = 1; i < (Factors?.Count ?? 0); i++)
            {
                factor = Factors?[i];
                factorSize = factorsSizes[i];

                factor?.Draw(graphics, font, brush, pen, scale, x, y + (size.Height - (factorSize.Height * MathConstants.OneHalf)), drawBounds);
                x += factorSize.Width;
            }
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
        public HashSet<IRenderable> Layout(Graphics graphics, Font font, Brush brush, Pen pen, float scale, PointF location, bool drawBorders = false)
        {
            var size = Dimensions(graphics, font, scale, out SizeF coefficientSize, out var nomialSizes);
            (var x, var y) = (location.X, location.Y);
            var map = new HashSet<IRenderable>();

            return map;
        }
    }
}
