// <copyright file="RelationalOperation.cs" company="Shkyrockett" >
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
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using static System.Math;

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
/// <seealso cref="IExpression" />
[JsonConverter(typeof(NumericFactor))]
public class RelationalOperation
    : IExpression, IEditable
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="RelationalOperation" /> class.
    /// </summary>
    /// <param name="operator">The operator.</param>
    /// <param name="leftExpression">The left expression.</param>
    /// <param name="rightExpression">The right expression.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    public RelationalOperation(ComparisonOperators @operator, IExpression? leftExpression, IExpression? rightExpression, bool editable = false)
    {
        Parent = null;
        Comparand = leftExpression;
        if (Comparand is IExpression l)
        {
            l.Parent = this;
        }

        Comparanda = rightExpression;
        if (Comparanda is IExpression r)
        {
            r.Parent = this;
        }

        Operator = @operator;
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
    /// Gets or sets the operator.
    /// </summary>
    /// <value>
    /// The operator.
    /// </value>
    [JsonInclude, JsonPropertyName("Operator"), JsonConverter(typeof(ComparisonOperators))]
    public ComparisonOperators Operator { get; set; }

    /// <summary>
    /// Gets the comparand.
    /// </summary>
    /// <value>
    /// The comparand.
    /// </value>
    [JsonInclude, JsonPropertyName("Comparand")]
    [JsonConverter(typeof(NomialExpression))]
    public IExpression? Comparand { get; }

    /// <summary>
    /// Gets the comparanda.
    /// </summary>
    /// <value>
    /// The comparanda.
    /// </value>
    [JsonInclude, JsonPropertyName("Comparanda")]
    [JsonConverter(typeof(NomialExpression))]
    public IExpression? Comparanda { get; }

    /// <summary>
    /// Gets a value indicating whether this <see cref="NumericFactor"/> is editable.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
    /// </value>
    [JsonInclude, JsonPropertyName("Editable")]
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
    /// <param name="comparandSize">Size of the left.</param>
    /// <param name="operatorSize">Size of the operator.</param>
    /// <param name="comparandaSize">Size of the right.</param>
    /// <returns></returns>
    private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF comparandSize, out SizeF operatorSize, out SizeF comparandaSize)
    {
        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        var emHeightUnit = graphics.ConvertGraphicsUnits(tempFont.Size, tempFont.Unit, GraphicsUnit.Pixel);
        var designToUnit = emHeightUnit / tempFont.FontFamily.GetEmHeight(tempFont.Style);
        //var ascent = designToUnit * tempFont.FontFamily.GetCellAscent(tempFont.Style);
        //var descent = designToUnit * tempFont.FontFamily.GetCellDescent(tempFont.Style);
        var lineSpacing = designToUnit * tempFont.FontFamily.GetLineSpacing(tempFont.Style);

        operatorSize = graphics.MeasureString(Operator.GetString(), tempFont, Point.Empty, StringFormat.GenericTypographic);
        operatorSize.Height = lineSpacing;
        comparandSize = Comparand?.Layout(graphics, font, scale) ?? graphics.MeasureString(" ", tempFont, PointF.Empty, StringFormat.GenericTypographic);
        comparandaSize = Comparanda?.Layout(graphics, font, scale) ?? graphics.MeasureString(" ", tempFont, PointF.Empty, StringFormat.GenericTypographic);
        var height = operatorSize.Height;
        height = Max(height, comparandSize.Height);
        height = Max(height, comparandaSize.Height);
        Size = new SizeF(comparandSize.Width + operatorSize.Width + comparandaSize.Width, height);
        return Size.Value;
    }

    /// <summary>
    /// Return the object's size.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public SizeF Layout(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _);

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
        var bounds = Layout(graphics, font, location, scale, out var comparandBounds, out var operatorBounds, out var comparandaBounds);

        if (drawBounds)
        {
            using var dashedPen = new Pen(Color.Violet, 0)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, bounds);
            graphics.DrawRectangle(dashedPen, comparandBounds);
            graphics.DrawRectangle(dashedPen, operatorBounds);
            graphics.DrawRectangle(dashedPen, comparandaBounds);
        }

        // Draw the left Expression.
        if (Comparand is not null)
        {
            Comparand?.Draw(graphics, font, brush, pen, comparandBounds.Location, scale, drawBounds);
        }
        else
        {
            using var dashedPen = new Pen(Color.Gray, 0)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, comparandBounds);
        }

        // Advance X.
        location.X += comparandBounds.Width;

        // Draw the Operator.
        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        graphics.DrawString(Operator.GetString(), tempFont, brush, operatorBounds.Location, StringFormat.GenericTypographic);

        // Advance X.
        location.X += operatorBounds.Width;

        // Draw the right.
        if (Comparanda is not null)
        {
            Comparanda?.Draw(graphics, font, brush, pen, comparandaBounds.Location, scale, drawBounds);
        }
        else
        {
            using var dashedPen = new Pen(Color.Gray, 0)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, comparandaBounds);
        }
    }

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
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="comparandBounds">The comparand bounds.</param>
    /// <param name="operatorBounds">The operator bounds.</param>
    /// <param name="comparandaBounds">The comparanda bounds.</param>
    /// <returns></returns>
    public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF comparandBounds, out RectangleF operatorBounds, out RectangleF comparandaBounds)
    {
        var size = Dimensions(graphics, font, scale, out var comparandSize, out var operatorSize, out var comparandaSize);
        Bounds = new RectangleF(location, size);
        comparandBounds = new RectangleF(new(location.X, location.Y + ((size.Height - comparandSize.Height) * Mathematics.OneHalf)), comparandSize);
        location.X += comparandSize.Width;
        operatorBounds = new RectangleF(new(location.X, location.Y + ((size.Height - operatorSize.Height) * Mathematics.OneHalf)), operatorSize);
        location.X += operatorSize.Width;
        comparandaBounds = new RectangleF(new(location.X, location.Y + ((size.Height - comparandaSize.Height) * Mathematics.OneHalf)), comparandaSize);
        return Bounds ?? Rectangle.Empty;
    }

    /// <summary>
    /// Expressions of this instance.
    /// </summary>
    /// <returns></returns>
    public HashSet<IExpression> Expressions()
    {
        var set = new HashSet<IExpression>() { this };
        if (Comparand is not null)
        {
            set.UnionWith(Comparand.Expressions());
        }

        if (Comparanda is not null)
        {
            set.UnionWith(Comparanda.Expressions());
        }

        return set;
    }
}
