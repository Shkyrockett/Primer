// <copyright file="RootFactor.cs" company="Shkyrockett" >
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

namespace MathematicsNotationLibrary;

/// <summary>
/// The root equation class.
/// </summary>
/// <seealso cref="IExpression" />
/// <seealso cref="INegatable" />
public class RootFunction
    : IExponatable, INegatable, IEditable
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="RootFunction" /> class.
    /// </summary>
    /// <param name="index">The index.</param>
    /// <param name="radicand">The radicand.</param>
    /// <param name="sequence">The sequence.</param>
    /// <param name="exponent">The exponent.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    public RootFunction(ICoefficient index, IExpression radicand, INumeric? sequence = null, IExpression? exponent = null, bool editable = false)
    {
        Parent = null;
        Index = index;
        if (Index is IExpression i)
        {
            i.Parent = this;
        }

        Radicand = radicand;
        if (Radicand is IExpression r)
        {
            r.Parent = this;
        }

        Sequence = sequence;
        if (Radicand is ICoefficient s)
        {
            s.Parent = this;
        }

        Exponent = exponent;
        if (Radicand is ICoefficient e)
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
    /// Gets the radical.
    /// </summary>
    /// <value>
    /// The radical.
    /// </value>
    public RadicalFigure? Radical { get; private set; }

    /// <summary>
    /// Gets the index.
    /// </summary>
    /// <value>
    /// The index.
    /// </value>
    public ICoefficient? Index { get; }

    /// <summary>
    /// Gets the radicand.
    /// </summary>
    /// <value>
    /// The radicand.
    /// </value>
    public IExpression? Radicand { get; }

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
    /// Gets or sets a value indicating whether the value is either positive or negative.
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
    /// Calculate sizes.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="indexSize">Size of the index.</param>
    /// <param name="radicandSize">Size of the radicand.</param>
    /// <param name="radicalSize">Size of the radical.</param>
    /// <param name="radicalFullSize">Full size of the radical.</param>
    /// <param name="radicalScale">The radical scale.</param>
    /// <param name="barWidth">Width of the bar.</param>
    /// <param name="sequenceSize">Size of the sequence.</param>
    /// <param name="exponentSize">Size of the exponent.</param>
    /// <returns></returns>
    private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF indexSize, out SizeF radicandSize, out SizeF radicalSize, out SizeF radicalFullSize, out float radicalScale, out float barWidth, out SizeF sequenceSize, out SizeF exponentSize)
    {
        Scale = scale;
        const string Character = "√";
        (var width, var height) = (0f, 0f);

        using var indexFont = new Font(font.FontFamily, font.Size * scale * Mathematics.IndexScale, font.Style);
        indexSize = Index?.Layout(graphics, font, scale * Mathematics.IndexScale) ?? graphics.MeasureString(" ", indexFont, PointF.Empty, StringFormat.GenericTypographic);

        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        radicandSize = Radicand?.Layout(graphics, font, scale) ?? graphics.MeasureString(" ", tempFont, PointF.Empty, StringFormat.GenericTypographic);
        width += radicandSize.Width;
        height += radicandSize.Height;

        (radicalSize, radicalScale) = Utilities.CalculateCharacterSizeForHeight(graphics, font, Character, height, StringFormat.GenericTypographic);
        using var radicalFont = new Font(font.FontFamily, font.Size * radicalScale, font.Style);
        radicalFullSize = graphics.MeasureString(Character, radicalFont, PointF.Empty, StringFormat.GenericDefault);
        width += radicalSize.Width;
        height = Math.Max(height, radicalFullSize.Height);

        barWidth = Utilities.MeasureGlyphs(graphics, tempFont, "-", StringFormat.GenericTypographic).Height;
        width += barWidth;

        using var sequenceFont = new Font(font.FontFamily, font.Size * scale * Mathematics.SequenceScale, font.Style);
        sequenceSize = Sequence?.Layout(graphics, font, scale) ?? new SizeF(0f, graphics.MeasureString(" ", sequenceFont, Point.Empty, StringFormat.GenericTypographic).Height);

        using var exponentFont = new Font(font.FontFamily, font.Size * scale * Mathematics.ExponentScale, font.Style);
        exponentSize = Exponent?.Layout(graphics, font, scale) ?? new SizeF(0f, graphics.MeasureString(" ", exponentFont, Point.Empty, StringFormat.GenericTypographic).Height);

        width += Math.Max(sequenceSize.Width, exponentSize.Width);
        height += ((Sequence is null) ? 0f : sequenceSize.Height * Mathematics.SequenceOffsetScale) + ((Exponent is null) ? 0f : exponentSize.Height * Mathematics.ExponentOffsetScale);

        return new SizeF(width, height);
    }

    /// <summary>
    /// Return the equation's size.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    public SizeF Layout(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _, out _, out _, out _, out _, out _);

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
        var bounds = Layout(graphics, font, location, scale, out var indexBounds, out var raticandBounds, out var radicalBounds, out var radicalFullSize, out var radicalScale, out var sequenceBounds, out var exponentBounds);

        if (drawBounds)
        {
            using var dashedPen = new Pen(Color.Brown, 1)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, indexBounds);
            graphics.DrawRectangle(dashedPen, bounds);
        }

        if (sequenceBounds.Width > 0)
        {
            Sequence?.Draw(graphics, font, brush, pen, sequenceBounds.Location, scale * Mathematics.SequenceScale, drawBounds);
        }

        if (exponentBounds.Width > 0)
        {
            Exponent?.Draw(graphics, font, brush, pen, exponentBounds.Location, scale * Mathematics.ExponentScale, drawBounds);
        }

        graphics.DrawRadical(font, pen, brush, location, raticandBounds.Size, radicalBounds.Size, radicalFullSize, radicalScale, drawBounds);

        if (!(Index is ICoefficient i && i.Value == Mathematics.Two))
        {
            Index?.Draw(graphics, font, brush, pen, location, scale * Mathematics.IndexScale, drawBounds);
        }

        Radicand?.Draw(graphics, font, brush, pen, raticandBounds.Location, scale, drawBounds);
    }

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="location">The location.</param>
    /// <returns></returns>
    public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale) => (Bounds = Layout(graphics, font, location, scale, out _, out _, out _, out _, out _, out _, out _)) ?? Rectangle.Empty;

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="indexBounds">The index bounds.</param>
    /// <param name="raticandBounds">The raticand bounds.</param>
    /// <param name="radicalBounds">The radical bounds.</param>
    /// <param name="radicalFullSize">Full size of the radical.</param>
    /// <param name="radicalScale">The radical scale.</param>
    /// <param name="sequenceBounds">The sequence bounds.</param>
    /// <param name="exponentBounds">The exponent bounds.</param>
    /// <returns></returns>
    private RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF indexBounds, out RectangleF raticandBounds, out RectangleF radicalBounds, out SizeF radicalFullSize, out float radicalScale, out RectangleF sequenceBounds, out RectangleF exponentBounds)
    {
        var size = Dimensions(graphics, font, scale, out var indexSize, out var radicandSize, out var radicalSize, out radicalFullSize, out radicalScale, out var barWidth, out var sequenceSize, out var exponentSize);
        Bounds = new RectangleF(location, size);

        sequenceBounds = (sequenceSize.Width > 0) ? new RectangleF(new(location.X + radicalSize.Width + radicandSize.Width + barWidth, location.Y + (size.Height - sequenceSize.Height + (sequenceSize.Height * Mathematics.SequenceOffsetScale))), radicandSize) : RectangleF.Empty;
        if (exponentSize.Width > 0)
        {
            exponentBounds = new RectangleF(new(location.X + radicalSize.Width + radicandSize.Width + barWidth, location.Y), radicalSize);
            location.Y += radicalFullSize.Height - radicalSize.Height;
        }
        else
        {
            exponentBounds = RectangleF.Empty;
        }

        radicalBounds = new RectangleF(location, radicalSize);
        indexBounds = !(Index is ICoefficient i && i.Value == Mathematics.Two) ? new RectangleF(location, indexSize) : RectangleF.Empty;
        location.X += radicalSize.Width;
        raticandBounds = new RectangleF(new(location.X, location.Y + ((radicandSize.Height - radicalSize.Height) * Mathematics.OneHalf)), radicandSize);
        return Bounds.Value;
    }

    /// <summary>
    /// Expressions of this instance.
    /// </summary>
    /// <returns></returns>
    public HashSet<IExpression> Expressions()
    {
        var set = new HashSet<IExpression>() { this };
        if (Radical is not null)
        {
            set.UnionWith(Radical.Expressions());
        }

        if (Index is not null)
        {
            set.UnionWith(Index.Expressions());
        }

        if (Radicand is not null)
        {
            set.UnionWith(Radicand.Expressions());
        }

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
