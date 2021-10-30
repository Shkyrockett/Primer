// <copyright file="PowerFactor.cs" company="Shkyrockett" >
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

namespace MathematicsNotationLibrary;

/// <summary>
/// Draw an item to a power.
/// </summary>
/// <seealso cref="IExpression" />
/// <seealso cref="INegatable" />
/// <seealso cref="IExponatable" />
/// <seealso cref="IFactor" />
/// <seealso cref="IEditable" />
public class PowerFactor
    : IExpression, INegatable, IExponatable, IFactor, IEditable
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
        if (Base is IChild b)
        {
            b.Parent = this;
        }

        Exponent = powerExpression;
        if (Exponent is IChild s)
        {
            s.Parent = this;
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
    /// Return various sizes.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="baseSize">Size of the base.</param>
    /// <param name="powerSize">Size of the power.</param>
    /// <returns></returns>
    private SizeF Layout(Graphics graphics, Font font, float scale, out SizeF baseSize, out SizeF powerSize)
    {
        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        baseSize = Base?.Layout(graphics, font, scale) ?? graphics.MeasureString(" ", tempFont, PointF.Empty, StringFormat.GenericTypographic);
        using var smallFont = new Font(font.FontFamily, font.Size * Mathematics.ExponentScale, font.Style);
        powerSize = Exponent?.Layout(graphics, font, scale * Mathematics.ExponentScale) ?? graphics.MeasureString(" ", smallFont, PointF.Empty, StringFormat.GenericTypographic);
        return new SizeF(baseSize.Width + powerSize.Width, baseSize.Height + (powerSize.Height * Mathematics.ExponentOffsetScale));
    }

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="baseBounds">The base bounds.</param>
    /// <param name="powerBounds">The power bounds.</param>
    /// <returns></returns>
    private RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF baseBounds, out RectangleF powerBounds)
    {
        var size = Layout(graphics, font, scale, out var baseSize, out var powerSize);
        Bounds = new RectangleF(location, size);
        var baseY = location.Y + (powerSize.Height * Mathematics.ExponentOffsetScale);
        baseBounds = new RectangleF(new(location.X, baseY), baseSize);
        var powerX = location.X + baseSize.Width;
        powerBounds = new RectangleF(new(powerX, location.Y), powerSize);
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
        var bounds = Layout(graphics, font, location, scale, out var baseBounds, out var powerBounds);

        if (drawBounds)
        {
            using var dashedPen = new Pen(Color.Red, 0)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, bounds);
        }

        if (Base is null && Exponent is null)
        {
            using var dashedPen = new Pen(Color.Gray, 0)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, bounds);
        }

        // Draw the base.
        if (Base is not null)
        {
            Base.Draw(graphics, font, brush, pen, baseBounds.Location, scale * Mathematics.ExponentScale, drawBounds);
        }
        else
        {
            using var dashedPen = new Pen(Color.Gray, 0)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, baseBounds);
        }

        // Draw the power.
        if (Exponent is not null)
        {
            Exponent?.Draw(graphics, font, brush, pen, powerBounds.Location, scale * Mathematics.ExponentScale, drawBounds);
        }
        else
        {
            using var dashedPen = new Pen(Color.Gray, 0)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, powerBounds);
        }
    }

    /// <summary>
    /// Expressions of this instance.
    /// </summary>
    /// <returns></returns>
    public HashSet<IExpression> Expressions()
    {
        var set = new HashSet<IExpression>() { this };
        if (Base is not null)
        {
            set.UnionWith(Base.Expressions());
        }

        if (Exponent is not null)
        {
            set.UnionWith(Exponent.Expressions());
        }

        return set;
    }
}
