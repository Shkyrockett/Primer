// <copyright file="NumericFactor.cs" company="Shkyrockett" >
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
/// <seealso cref="ICoefficient" />
/// <seealso cref="INegatable" />
/// <seealso cref="IEditable" />
[JsonConverter(typeof(NumericFactor))]
public class NumericFactor
    : ICoefficient, IChild, IEditable
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="NumericFactor"/> class.
    /// </summary>
    /// <param name="factor">The factor.</param>
    /// <param name="exponent">The exponent.</param>
    /// <param name="sequence">The sequence.</param>
    /// <param name="editable">The editable.</param>
    public NumericFactor(NumericFactor factor, IExpression? exponent = null, INumeric? sequence = null, bool? editable = null)
        : this(factor.Value, exponent ?? factor.Exponent, sequence ?? factor.Sequence, editable ?? factor.Editable)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NumericFactor" /> class.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="exponent">The exponent.</param>
    /// <param name="sequence">The sequence.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    public NumericFactor(double value = 1, IExpression? exponent = null, INumeric? sequence = null, bool editable = false)
    {
        Parent = null;
        Value = value;
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
    /// Gets or sets the value.
    /// </summary>
    /// <value>
    /// The value.
    /// </value>
    public double Value { get; set; } = 1;

    /// <summary>
    /// Gets or sets the sign of the numeric factor.
    /// </summary>
    /// <value>
    /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
    /// </value>
    public int Sign { get => Sign(Value); set => Value = (Sign(Value) == Sign(value)) ? Value : -Value; }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is negative.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if this instance is negative; otherwise, <see langword="false" />.
    /// </value>
    public bool IsNegative { get => Sign(Value) == -1d; set => Value *= (value == (Sign(Value) == -1d)) ? 1f : -1f; }

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

            return (isConstant, Abs(Value)) switch
            {
                (false, 1) => $"{opr}",
                (true, 1) => $"{opr}{Abs(Value)}",
                (true, _) => $"{opr}{Abs(Value)}",
                (_, 0) => $"{opr}{Abs(Value)}",
                (_, _) => $"{opr}{Abs(Value)}",
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
    /// Return the equation's size.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="coefficientSize">Size of the coefficient.</param>
    /// <param name="exponentSize">Size of the exponent.</param>
    /// <param name="sequenceSize">Size of the sequence.</param>
    /// <returns></returns>
    private SizeF Layout(Graphics graphics, Font font, float scale, out SizeF coefficientSize, out SizeF exponentSize, out SizeF sequenceSize)
    {
        Scale = scale;
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

        sequenceSize = Sequence?.Layout(graphics, font, scale * Mathematics.SequenceScale) ?? SizeF.Empty;

        exponentSize = Exponent?.Layout(graphics, font, scale * Mathematics.ExponentScale) ?? SizeF.Empty;

        Size = new SizeF(
            coefficientSize.Width + MathF.Max(exponentSize.Width, sequenceSize.Width),
            coefficientSize.Height + ((sequenceSize.Width == 0) ? 0f : sequenceSize.Height * Mathematics.SequenceOffsetScale) + ((exponentSize.Width == 0) ? 0f : exponentSize.Height * Mathematics.ExponentOffsetScale));
        return Size.Value;
    }

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="coefficientBounds">The coefficient bounds.</param>
    /// <param name="exponentBounds">The exponent bounds.</param>
    /// <param name="sequenceBounds">The sequence bounds.</param>
    /// <returns></returns>
    private RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF coefficientBounds, out RectangleF exponentBounds, out RectangleF sequenceBounds)
    {
        var size = Layout(graphics, font, scale, out var coefficientSize, out var exponentSize, out var sequenceSize);
        Bounds = new RectangleF(location, size);

        exponentBounds = exponentSize.Width > 0
            ? new RectangleF(new(location.X + coefficientSize.Width, location.Y), exponentSize)
            : RectangleF.Empty;

        sequenceBounds = sequenceSize.Width > 0
            ? new RectangleF(new(location.X + coefficientSize.Width, location.Y + size.Height - sequenceSize.Height), sequenceSize)
            : RectangleF.Empty;

        location.Y += exponentSize.Height * Mathematics.ExponentOffsetScale;
        coefficientBounds = new RectangleF(location, coefficientSize);

        return Bounds.Value;
    }

    /// <summary>
    /// Return the equation's size.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    public SizeF Layout(Graphics graphics, Font font, float scale) => Layout(graphics, font, scale, out _, out _, out _);

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale) => Layout(graphics, font, location, scale, out _, out _, out _);

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
        var bounds = Layout(graphics, font, location, scale, out var coefficientBounds, out var exponentBounds, out var sequenceBounds);

        if (drawBounds)
        {
            using var dashedPen = new Pen(Color.Red, 0)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, coefficientBounds);
            graphics.DrawRectangle(dashedPen, exponentBounds);
            graphics.DrawRectangle(dashedPen, sequenceBounds);
            graphics.DrawRectangle(dashedPen, bounds);
        }

        if (exponentBounds.Width > 0)
        {
            Exponent?.Draw(graphics, font, brush, pen, exponentBounds.Location, scale * Mathematics.ExponentScale, drawBounds);
        }

        if (sequenceBounds.Width > 0)
        {
            Sequence?.Draw(graphics, font, brush, pen, sequenceBounds.Location, scale * Mathematics.SequenceScale, drawBounds);
        }

        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        if (!string.IsNullOrEmpty(Text))
        {
            graphics.DrawString(Text, tempFont, brush, coefficientBounds.Location, StringFormat.GenericTypographic);
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
