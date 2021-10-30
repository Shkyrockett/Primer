// <copyright file="FractionCoefficientFactor.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
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

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
/// <seealso cref="ICoefficient" />
/// <seealso cref="INegatable" />
/// <seealso cref="IEditable" />
[JsonConverter(typeof(FractionFactor))]
public class FractionFactor
    : ICoefficient, IChild, IEditable
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="FractionFactor"/> class.
    /// </summary>
    /// <param name="factor">The factor.</param>
    /// <param name="exponent">The exponent.</param>
    /// <param name="sequence">The sequence.</param>
    /// <param name="editable">The editable.</param>
    public FractionFactor(FractionFactor factor, IExpression? exponent = null, INumeric? sequence = null, bool? editable = null)
        : this(factor.Numerator, factor.Denominator, exponent ?? factor.Exponent, sequence ?? factor.Sequence, editable ?? factor.Editable)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FractionFactor"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="exponent">The exponent.</param>
    /// <param name="sequence">The sequence.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    public FractionFactor(double value, IExpression? exponent = null, INumeric? sequence = null, bool editable = false)
        : this(Operations.RoundToMixedFraction(value, 16), exponent, sequence, editable)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FractionFactor"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    /// <param name="exponent">The exponent.</param>
    /// <param name="sequence">The sequence.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    public FractionFactor((int numerator, int denominator) tuple, IExpression? exponent = null, INumeric? sequence = null, bool editable = false)
        : this(0, tuple.numerator, tuple.denominator, exponent, sequence, editable)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FractionFactor"/> class.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    /// <param name="exponent">The exponent.</param>
    /// <param name="sequence">The sequence.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    public FractionFactor((int whole, int numerator, int denominator) tuple, IExpression? exponent = null, INumeric? sequence = null, bool editable = false)
        : this(tuple.whole, tuple.numerator, tuple.denominator, exponent, sequence, editable)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FractionFactor"/> class.
    /// </summary>
    /// <param name="numerator">The numerator.</param>
    /// <param name="denominator">The denominator.</param>
    /// <param name="exponent">The exponent.</param>
    /// <param name="sequence">The sequence.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    public FractionFactor(int numerator, int denominator, IExpression? exponent = null, INumeric? sequence = null, bool editable = false)
        : this(0, numerator, denominator, exponent, sequence, editable)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FractionFactor" /> class.
    /// </summary>
    /// <param name="whole">The whole.</param>
    /// <param name="numerator">The numerator.</param>
    /// <param name="denominator">The denominator.</param>
    /// <param name="exponent">The exponent.</param>
    /// <param name="sequence">The sequence.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    public FractionFactor(int whole, int numerator, int denominator, IExpression? exponent = null, INumeric? sequence = null, bool editable = false)
    {
        Parent = null;
        Whole = whole;
        Numerator = numerator;
        Denominator = denominator;
        Sequence = sequence;
        if (Sequence is IChild s)
        {
            s.Parent = this;
        }

        Exponent = exponent;
        if (Exponent is IChild e)
        {
            e.Parent = this;
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
    /// Gets or sets the sequence.
    /// </summary>
    /// <value>
    /// The sequence.
    /// </value>
    public INumeric? Sequence { get; set; }

    /// <summary>
    /// Gets or sets the exponent.
    /// </summary>
    /// <value>
    /// The exponent.
    /// </value>
    public IExpression? Exponent { get; set; }

    /// <summary>
    /// Gets or sets the whole.
    /// </summary>
    /// <value>
    /// The whole.
    /// </value>
    public int Whole { get; set; }

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
    public double Value { get => Whole + Numerator / Denominator; set => (Whole, Numerator, Denominator) = Operations.RoundToMixedFraction(value, 16); }

    /// <summary>
    /// Gets or sets the sign of the expression.
    /// </summary>
    /// <value>
    /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
    /// </value>
    public int Sign { get => Math.Sign(Whole + (double)Numerator / Denominator); set => Value *= Math.Sign(Value) == Math.Sign(value) ? 1f : -1f; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is negative.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if this instance is negative; otherwise, <see langword="false" />.
    /// </value>
    public bool IsNegative { get => Math.Sign(Value) == -1d; set => Value *= (value == (Math.Sign(Value) == -1d)) ? 1f : -1f; }

    /// <summary>
    /// Gets or sets a value indicating whether [plus or minus].
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if [plus or minus]; otherwise, <see langword="false" />.
    /// </value>
    public bool PlusOrMinus { get; set; }

    /// <summary>
    /// Gets the text that represents the mixed rational.
    /// </summary>
    /// <value>
    /// The text.
    /// </value>
    public string Text
    {
        get
        {
            var isConstant = IsConstant;
            var opr = (Value, plusOrMinus: PlusOrMinus, IsFirstTerm || isConstant) switch
            {
                ( < 0, false, false) => $"−",   // Subtract.
                ( < 0, false, true) => $"-",    // Negative
                ( < 0, true, _) => $"∓",        // Minus or Plus.
                (_, false, false) => $"+",      // Add.
                (_, false, true) => $"",        // Positive.
                (_, true, _) => $"±",           // Plus or Minus.
            };

            var whole = Math.Abs(Whole);
            var numerator = Math.Abs(Numerator);
            var denominator = Math.Abs(Denominator);
            return (isConstant, whole, numerator, denominator) switch
            {
                (false, 1, 0, _) => $"{opr}",
                (true, _, 0, _) => $"{opr}{whole}",
                (true, _, _, 0) => $"Undefined",
                (_, 0, _, _) => $"{opr}{Utilities.SuperscriptNumber(numerator.ToString())}⁄{Utilities.SubscriptNumber(denominator.ToString())}",
                (_, _, _, _) => $"{opr}{whole} {Utilities.SuperscriptNumber(numerator.ToString())}⁄{Utilities.SubscriptNumber(denominator.ToString())}",
            };
        }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is first term.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if this instance is first term; otherwise, <see langword="false" />.
    /// </value>
    public bool IsFirstTerm => Parent is not ITerm || Parent is ITerm p && p.IsFirstTerm;

    /// <summary>
    /// Gets a value indicating whether this instance is coefficient.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if this instance is coefficient; otherwise, <see langword="false" />.
    /// </value>
    public bool IsCoefficient => (Parent is ITerm p) && ReferenceEquals(p.Coefficient, this);

    /// <summary>
    /// Gets a value indicating whether this instance is constant.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if this instance is constant; otherwise, <see langword="false" />.
    /// </value>
    public bool IsConstant => Parent is INumericValueFactor || Parent is ITerm t && t is ProductTerm p && p.Factors?.Count < 1;

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
    /// <param name="exponentSize">Size of the exponent.</param>
    /// <param name="sequenceSize">Size of the sequence.</param>
    /// <returns></returns>
    private SizeF Layout(Graphics graphics, Font font, float scale, out SizeF fractionSize, out SizeF exponentSize, out SizeF sequenceSize)
    {
        Scale = scale;
        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        var emHeightUnitTemp = graphics.ConvertGraphicsUnits(tempFont.Size, tempFont.Unit, GraphicsUnit.Pixel);
        var designToUnitTemp = emHeightUnitTemp / tempFont.FontFamily.GetEmHeight(tempFont.Style);
        var lineSpacingTemp = designToUnitTemp * tempFont.FontFamily.GetLineSpacing(tempFont.Style);

        var fraction = Text;
        fractionSize = SizeF.Empty;
        fractionSize = graphics.MeasureString(fraction, tempFont, Point.Empty, StringFormat.GenericTypographic);

        var size = fractionSize;

        using var sequenceFont = new Font(font.FontFamily, font.Size * scale * Mathematics.SequenceScale, font.Style);
        sequenceSize = Sequence?.Layout(graphics, font, scale) ?? new SizeF(0f, graphics.MeasureString(" ", sequenceFont, Point.Empty, StringFormat.GenericTypographic).Height);

        using var exponentFont = new Font(font.FontFamily, font.Size * scale * Mathematics.ExponentScale, font.Style);
        exponentSize = Exponent?.Layout(graphics, font, scale * Mathematics.ExponentScale) ?? new SizeF(0f, graphics.MeasureString(" ", exponentFont, Point.Empty, StringFormat.GenericTypographic).Height);

        size.Width += exponentSize.Width;
        size.Height += exponentSize.Height * Mathematics.ExponentOffsetScale;
        return size;
    }

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="fractionBounds">The slash bounds.</param>
    /// <param name="exponentBounds">The exponent bounds.</param>
    /// <param name="sequenceBounds">The sequence bounds.</param>
    /// <returns></returns>
    private RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF fractionBounds, out RectangleF exponentBounds, out RectangleF sequenceBounds)
    {
        var size = Layout(graphics, font, scale, out var fractionSize, out var exponentSize, out var sequenceSize);
        Bounds = new RectangleF(location, size);

        sequenceBounds = sequenceSize.Width > 0
            ? new RectangleF(new(location.X + fractionSize.Width, location.Y + fractionSize.Height - (sequenceSize.Height * Mathematics.SequenceOffsetScale)), sequenceSize)
            : RectangleF.Empty;

        if (exponentSize.Width > 0)
        {
            exponentBounds = new RectangleF(new(location.X + fractionSize.Width, location.Y), exponentSize);
            location.Y += exponentSize.Height * Mathematics.ExponentOffsetScale;
        }
        else
        {
            exponentBounds = Rectangle.Empty;
        }

        fractionBounds = new RectangleF(location, fractionSize);

        return Bounds ?? Rectangle.Empty;
    }

    /// <summary>
    /// Return the equation's size.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public SizeF Layout(Graphics graphics, Font font, float scale) => Layout(graphics, font, scale, out _, out _, out _);

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="location">The location.</param>
    /// <returns></returns>
    public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale) => Layout(graphics, font, location, scale, out _, out _, out _);

    /// <summary>
    /// Draws the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="brush">The brush.</param>
    /// <param name="pen">The pen.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, PointF location, float scale, bool drawBounds = false)
    {
        var bounds = Layout(graphics, font, location, scale, out var fractionBounds, out var exponentBounds, out var sequenceBounds);

        if (drawBounds)
        {
            using var dashedPen = new Pen(Color.LightCyan, 0)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, exponentBounds);
            graphics.DrawRectangle(dashedPen, sequenceBounds);
            graphics.DrawRectangle(dashedPen, bounds);
        }

        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        graphics.DrawString(Text, tempFont, brush, fractionBounds.Location, StringFormat.GenericTypographic);

        if (sequenceBounds.Width > 0)
        {
            Sequence?.Draw(graphics, font, brush, pen, sequenceBounds.Location, scale * Mathematics.SequenceScale, drawBounds);
        }

        if (exponentBounds.Width > 0)
        {
            Exponent?.Draw(graphics, font, brush, pen, exponentBounds.Location, scale * Mathematics.ExponentScale, drawBounds);
        }
    }

    /// <summary>
    /// Expressions of this instance.
    /// </summary>
    /// <returns></returns>
    public HashSet<IExpression> Expressions()
    {
        var set = new HashSet<IExpression>() { this };
        if (Exponent is not null)
        {
            set.UnionWith(Exponent.Expressions());
        }

        if (Sequence is not null)
        {
            set.UnionWith(Sequence.Expressions());
        }

        return set;
    }
}
