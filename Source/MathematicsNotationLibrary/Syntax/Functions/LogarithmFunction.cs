// <copyright file="LogarithmFactor.cs" company="Shkyrockett" >
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
/// <seealso cref="IExpression" />
/// <seealso cref="INegatable" />
/// <seealso cref="IEditable" />
public class LogarithmFunction
    : IFactor, INegatable, IEditable
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="LogarithmFunction" /> class.
    /// </summary>
    /// <param name="argument">The argument.</param>
    /// <param name="base">The base.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    public LogarithmFunction(IExpression argument, IExpression @base, bool editable = false)
    {
        Parent = null;
        Argument = argument;
        if (Argument is IChild a)
        {
            a.Parent = this;
        }

        Base = @base;
        if (Base is IChild b)
        {
            b.Parent = this;
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
    /// Gets the argument.
    /// </summary>
    /// <value>
    /// The argument.
    /// </value>
    public IExpression Argument { get; }

    /// <summary>
    /// Gets the base.
    /// </summary>
    /// <value>
    /// The base.
    /// </value>
    public IExpression Base { get; }

    /// <summary>
    /// Gets or sets the sequence.
    /// </summary>
    /// <value>
    /// The sequence.
    /// </value>
    public INumeric? Sequence { get; set; }

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
    /// Gets the name of the function.
    /// </summary>
    /// <returns></returns>
    private static string GetFunctionName() =>
        // ToDo: Add ln if Base is the natural log e, or lg if base 10, or omit the base if log base 10.
        "log";

    /// <summary>
    /// Gets the sizes.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="functionSize">Size of the function.</param>
    /// <param name="baseSize">Size of the base.</param>
    /// <param name="argumentSize">Size of the argument.</param>
    /// <returns></returns>
    private SizeF Layout(Graphics graphics, Font font, float scale, out SizeF functionSize, out SizeF baseSize, out SizeF argumentSize)
    {
        Scale = scale;
        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        using var smallFont = new Font(font.FontFamily, font.Size * Mathematics.SequenceScale, font.Style);

        functionSize = graphics.MeasureString(GetFunctionName(), tempFont);
        baseSize = Base?.Layout(graphics, font, scale * Mathematics.SequenceScale) ?? graphics.MeasureString(" ", smallFont);
        argumentSize = Argument?.Layout(graphics, font, scale) ?? graphics.MeasureString(" ", tempFont);

        Size = new SizeF(functionSize.Width + baseSize.Width + argumentSize.Width, Max(argumentSize.Height, functionSize.Height + (baseSize.Height * Mathematics.SequenceOffsetScale)));
        return Size.Value;
    }

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="functionBounds">The function bounds.</param>
    /// <param name="baseBounds">The base bounds.</param>
    /// <param name="argumentBounds">The argument bounds.</param>
    /// <returns></returns>
    private RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF functionBounds, out RectangleF baseBounds, out RectangleF argumentBounds)
    {
        var size = Layout(graphics, font, scale, out var functionSize, out var baseSize, out var argumentSize);
        Bounds = new RectangleF(location, size);

        functionBounds = new RectangleF(new PointF(location.X, location.Y + ((size.Height - functionSize.Height) * Mathematics.OneHalf)), functionSize);
        baseBounds = new RectangleF(new PointF(location.X + functionSize.Width, functionBounds.Y + (functionBounds.Height * Mathematics.SequenceOffsetScale)), baseSize);
        argumentBounds = new RectangleF(new PointF(location.X + functionSize.Width + baseSize.Width, location.Y + ((size.Height - argumentSize.Height) * Mathematics.OneHalf)), argumentSize);
        return Bounds ?? Rectangle.Empty;
    }

    /// <summary>
    /// Gets the size.
    /// </summary>
    /// <param name="graphics">The GDI graphics.</param>
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
    /// <param name="graphics">The GDI graphics.</param>
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
        var bounds = Layout(graphics, font, location, scale, out var functionBounds, out var baseBounds, out var argumentBounds);

        if (drawBounds)
        {
            using var dashedPen = new Pen(Color.DarkBlue, 0)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, functionBounds);
            graphics.DrawRectangle(dashedPen, baseBounds);
            graphics.DrawRectangle(dashedPen, argumentBounds);
            graphics.DrawRectangle(dashedPen, bounds);
        }

        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        graphics.DrawString(GetFunctionName(), tempFont, brush, functionBounds.Location);
        Base.Draw(graphics, font, brush, pen, baseBounds.Location, scale * Mathematics.SequenceScale, drawBounds);
        Argument.Draw(graphics, font, brush, pen, argumentBounds.Location, scale, drawBounds);
    }

    /// <summary>
    /// Expressions of this instance.
    /// </summary>
    /// <returns></returns>
    public HashSet<IExpression> Expressions()
    {
        var set = new HashSet<IExpression>() { this };
        if (Argument is not null)
        {
            set.UnionWith(Argument.Expressions());
        }

        if (Base is not null)
        {
            set.UnionWith(Base.Expressions());
        }

        if (Sequence is not null)
        {
            set.UnionWith(Sequence.Expressions());
        }

        return set;
    }
}
