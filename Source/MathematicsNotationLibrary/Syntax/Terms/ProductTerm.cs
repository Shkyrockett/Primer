// <copyright file="ProductTerm.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
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

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
/// <seealso cref="ITerm" />
/// <seealso cref="IEditable" />
/// <seealso cref="INegatable" />
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
        : this(new NumericFactor(coefficient), false, expressions)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductTerm" /> class.
    /// </summary>
    /// <param name="coefficient">The coefficient.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    /// <param name="expressions">The expressions.</param>
    public ProductTerm(float coefficient, bool editable = false, params IFactor[] expressions)
        : this(new NumericFactor(coefficient), editable, expressions)
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
    /// <param name="coefficient">The coefficient.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    /// <param name="expressions">The expressions.</param>
    public ProductTerm(ICoefficient coefficient, bool editable = false, params IFactor[] expressions)
    {
        Parent = null;
        Coefficient = coefficient;
        if (Coefficient is IChild c)
        {
            c.Parent = this;
        }

        Factors = new List<IFactor>(expressions);
        for (var i = 0; i < Factors.Count; i++)
        {
            if (Factors[i] is IExpression f)
            {
                f.Parent = this;
            }
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
    public ICoefficient? Coefficient { get; set; }

    /// <summary>
    /// Gets or sets the expressions.
    /// </summary>
    /// <value>
    /// The expressions.
    /// </value>
    [JsonInclude, JsonPropertyName("Editable")]
    public List<IFactor> Factors { get; set; }

    /// <summary>
    /// Gets a value indicating whether this instance is first term.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if this instance is first term; otherwise, <see langword="false" />.
    /// </value>
    [JsonIgnore]
    public bool IsFirstTerm => (Parent is not NomialExpression) || (Parent is NomialExpression p) && ReferenceEquals(p.Terms?[0], this);

    /// <summary>
    /// Gets a value indicating whether this instance is constant.
    /// </summary>
    /// <value>
    /// <see langword="true" /> if this instance is constant; otherwise, <see langword="false" />.
    /// </value>
    [JsonIgnore]
    public bool IsConstant => Coefficient is not null && (Factors is null || Factors.Count < 1);

    /// <summary>
    /// Gets or sets the sign of the expression.
    /// </summary>
    /// <value>
    /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
    /// </value>
    [JsonIgnore]
    public int Sign
    {
        get => Coefficient?.Sign ?? 1;
        set
        {
            if (Coefficient is null)
            {
                Coefficient = new NumericFactor(value);
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
    [JsonIgnore]
    public bool IsNegative
    {
        get => Coefficient?.IsNegative ?? false;
        set
        {
            if (Coefficient is null)
            {
                Coefficient = new NumericFactor(1);
            }
            else
            {
                Coefficient.IsNegative = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [plus or minus].
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
    /// Return various sizes.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="coefficientSize">Size of the coefficient.</param>
    /// <param name="factorsSizes">The nomial sizes.</param>
    /// <returns></returns>
    private unsafe SizeF Layout(Graphics graphics, Font font, float scale, out SizeF coefficientSize, out Span<SizeF> factorsSizes)
    {
        var (width, maxHeight) = coefficientSize = Coefficient?.Layout(graphics, font, scale) ?? SizeF.Empty;

        factorsSizes = new SizeF[Factors.Count];
        for (var i = 0; i < Factors.Count; i++)
        {
            var factorSize = factorsSizes[i] = Factors[i].Layout(graphics, font, scale);
            maxHeight = Max(maxHeight, factorSize.Height);
            width += factorSize.Width;
        }

        return new SizeF(width, maxHeight);
    }

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="coefficientBounds">The coefficient bounds.</param>
    /// <param name="factorsBounds">The factors bounds.</param>
    /// <returns></returns>
    private RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF coefficientBounds, out Span<RectangleF> factorsBounds)
    {
        var size = Layout(graphics, font, scale, out var coefficientSize, out var factorsSizes);
        Bounds = new RectangleF(location, size);
        coefficientBounds = new RectangleF(new(location.X, location.Y + ((size.Height - coefficientSize.Height) * Mathematics.OneHalf)), coefficientSize);
        location.X += coefficientSize.Width;
        factorsBounds = new RectangleF[factorsSizes.Length];
        for (var i = 0; i < (Factors?.Count ?? 0); i++)
        {
            var factorSize = factorsSizes[i];
            factorsBounds[i] = new RectangleF(new(location.X, location.Y + ((size.Height - factorSize.Height) * Mathematics.OneHalf)), factorSize);
            location.X += factorSize.Width;
        }

        return Bounds ?? Rectangle.Empty;
    }

    /// <summary>
    /// Return the object's size.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    public SizeF Layout(Graphics graphics, Font font, float scale) => Layout(graphics, font, scale, out _, out _);

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="location">The location.</param>
    /// <returns></returns>
    public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale) => Layout(graphics, font, location, scale, out _, out _);

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
        var bounds = Layout(graphics, font, location, scale, out var coefficientBounds, out var factorsBounds);

        if (drawBounds)
        {
            using var dashedPen = new Pen(Color.Red, 0)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, bounds);
        }

        Coefficient?.Draw(graphics, font, brush, pen, coefficientBounds.Location, scale, drawBounds);
        for (var i = 0; i < (Factors?.Count ?? 0); i++)
        {
            var factor = Factors?[i];
            factor?.Draw(graphics, font, brush, pen, factorsBounds[i].Location, scale, drawBounds);
        }
    }

    /// <summary>
    /// Expressions of this instance.
    /// </summary>
    /// <returns></returns>
    public HashSet<IExpression> Expressions()
    {
        var set = new HashSet<IExpression>() { this };
        if (Coefficient is not null)
        {
            set.UnionWith(Coefficient.Expressions());
        }

        foreach (var factor in Factors)
        {
            set.UnionWith(factor.Expressions());
        }
        return set;
    }
}
