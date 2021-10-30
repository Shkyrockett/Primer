// <copyright file="QuotientFactor.cs" company="Shkyrockett" >
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

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.Json.Serialization;
using static System.Math;

namespace MathematicsNotationLibrary;

/// <summary>
/// Draw one item over another.
/// </summary>
/// <seealso cref="IExpression" />
/// <seealso cref="INegatable" />
[JsonConverter(typeof(QuotientFactor))]
public class QuotientFactor
    : IExponatable, IGroupable, INegatable, IEditable
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="QuotientFactor"/> class.
    /// </summary>
    /// <param name="dividend">The top text.</param>
    /// <param name="divisor">The bottom text.</param>
    /// <param name="showHorizontalBar">if set to <see langword="true" /> [show horizontal bar].</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    public QuotientFactor(string dividend, string divisor, bool showHorizontalBar = true, bool editable = false)
        : this(new TextExpression(dividend), new TextExpression(divisor), showHorizontalBar, editable)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuotientFactor"/> class.
    /// </summary>
    /// <param name="dividend">The top expression.</param>
    /// <param name="divisor">The denominator expression.</param>
    /// <param name="showHorizontalBar">if set to <see langword="true" /> [show horizontal bar].</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    public QuotientFactor(IExpression dividend, IExpression divisor, bool showHorizontalBar = true, bool editable = false)
    {
        Parent = null;
        Dividend = dividend;
        if (Dividend is IExpression t)
        {
            t.Parent = this;
        }

        Divisor = divisor;
        if (Divisor is IChild b)
        {
            b.Parent = this;
        }

        ShowHorizontalBar = showHorizontalBar;
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
    /// Gets the numerator.
    /// </summary>
    /// <value>
    /// The numerator.
    /// </value>
    public IExpression Dividend { get; }

    /// <summary>
    /// Gets the denominator.
    /// </summary>
    /// <value>
    /// The denominator.
    /// </value>
    public IExpression Divisor { get; }

    /// <summary>
    /// Gets or sets the exponent.
    /// </summary>
    /// <value>
    /// The exponent.
    /// </value>
    public IExpression? Exponent { get; set; }

    /// <summary>
    /// Gets or sets the sequence.
    /// </summary>
    /// <value>
    /// The sequence.
    /// </value>
    public INumeric? Sequence { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [show horizontal bar].
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if [show horizontal bar]; otherwise, <see langword="false" />.
    /// </value>
    public bool ShowHorizontalBar { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="IGroupable" /> is group.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if group; otherwise, <see langword="false" />.
    /// </value>
    public bool Group { get; set; }

    /// <summary>
    /// Gets or sets the bar style.
    /// </summary>
    /// <value>
    /// The bar style.
    /// </value>
    public BarStyles GroupingStyle { get; set; }

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
    /// Return various sizes.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="dividendSize">Size of the top.</param>
    /// <param name="divisorSize">Size of the bottom.</param>
    /// <param name="barSize">Size of the bar.</param>
    /// <returns></returns>
    private SizeF Layout(Graphics graphics, Font font, float scale, out SizeF dividendSize, out SizeF divisorSize, out SizeF barSize)
    {
        Scale = scale;
        dividendSize = Dividend.Layout(graphics, font, scale);
        divisorSize = Divisor.Layout(graphics, font, scale);
        var width = Max(dividendSize.Width, divisorSize.Width);
        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        var bar = ShowHorizontalBar ? Utilities.MeasureGlyphs(graphics, tempFont, "-", StringFormat.GenericTypographic) : new RectangleF(0f, 0f, width, 0f);
        width += bar.Height * Mathematics.Two;
        barSize = new SizeF(width, bar.Height);
        return new SizeF(width, dividendSize.Height + divisorSize.Height/* + barSize.Height*/);
    }

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="dividendBounds">The dividend bounds.</param>
    /// <param name="divisorBounds">The divisor bounds.</param>
    /// <param name="barBounds">The bar bounds.</param>
    /// <returns></returns>
    private RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF dividendBounds, out RectangleF divisorBounds, out RectangleF barBounds)
    {
        var size = Layout(graphics, font, scale, out var dividendSize, out var divisorSize, out var barSize);
        Bounds = new RectangleF(location, size);
        var top_x = location.X + ((size.Width - dividendSize.Width) * Mathematics.OneHalf);
        dividendBounds = new RectangleF(new(top_x, location.Y), dividendSize);
        barBounds = new RectangleF(location.X, location.Y + (dividendSize.Height - (barSize.Height * Mathematics.OneAndAHalf)), barSize.Width, barSize.Height);
        divisorBounds = new RectangleF(new(location.X + ((size.Width - divisorSize.Width) * Mathematics.OneHalf), location.Y + (size.Height - divisorSize.Height)), divisorSize);
        return Bounds ?? Rectangle.Empty;
    }

    /// <summary>
    /// Return the object's size.
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
    /// <param name="scale">The scale.</param>
    /// <param name="location">The location.</param>
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
        var bounds = Layout(graphics, font, location, scale, out var dividendBounds, out var divisorBounds, out var barBounds);

        if (drawBounds)
        {
            using var dashedPen = new Pen(Color.Orange, 1)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, bounds);
            graphics.DrawRectangle(dashedPen, dividendBounds);
            graphics.DrawRectangle(dashedPen, divisorBounds);
        }

        // Draw the top.
        Dividend.Draw(graphics, font, brush, pen, dividendBounds.Location, scale, drawBounds);

        // Draw the separator.
        if (ShowHorizontalBar)
        {
            graphics.FillRectangle(brush, barBounds);
        }

        // Draw the divisor.
        Divisor.Draw(graphics, font, brush, pen, divisorBounds.Location, scale, drawBounds);
    }

    /// <summary>
    /// Expressions of this instance.
    /// </summary>
    /// <returns></returns>
    public HashSet<IExpression> Expressions()
    {
        var set = new HashSet<IExpression>() { this };
        if (Dividend is not null)
        {
            set.UnionWith(Dividend.Expressions());
        }

        if (Divisor is not null)
        {
            set.UnionWith(Divisor.Expressions());
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
