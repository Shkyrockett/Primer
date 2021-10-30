// <copyright file="TextExpression.cs" company="Shkyrockett" >
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
/// Draw some text.
/// </summary>
/// <seealso cref="IExpression" />
/// <seealso cref="INegatable" />
public class TextExpression
    : IExpression, IEditable
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="TextExpression" /> class.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    public TextExpression(string text, bool editable = false)
    {
        Parent = null;
        Text = text;
        Editable = editable;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the text.
    /// </summary>
    /// <value>
    /// The text.
    /// </value>
    public string Text { get; set; }

    /// <summary>
    /// Gets or sets the parent.
    /// </summary>
    /// <value>
    /// The parent.
    /// </value>
    [JsonIgnore]
    public IExpression? Parent { get; set; }

    /// <summary>
    /// Gets or sets the sign of the expression.
    /// </summary>
    /// <value>
    /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
    /// </value>
    public int Sign { get; set; }

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
    /// <returns></returns>
    public SizeF Layout(Graphics graphics, Font font, float scale)
    {
        Scale = scale;
        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        return graphics.MeasureString(string.IsNullOrEmpty(Text) ? " " : Text, tempFont);
    }

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
        var bounds = Layout(graphics, font, location, scale);

        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        if (drawBounds)
        {
            using var dashedPen = new Pen(Color.Red, 0)
            {
                DashStyle = DashStyle.Dash
            };
            graphics.DrawRectangle(dashedPen, bounds);
        }

        if (!string.IsNullOrWhiteSpace(Text))
        {
            //TextRenderer.DrawText(graphics, Text, tempFont, new Point((int)x, (int)y), Color.Lime);
            graphics.DrawString(Text, tempFont, brush, bounds.Location);
        }
        else
        {
            using var dashedPen = new Pen(Color.Gray, 0)
            {
                DashStyle = DashStyle.Dash
            };
            graphics.DrawRectangle(dashedPen, bounds);
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
    public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale)
    {
        Bounds = new RectangleF(location, Layout(graphics, font, scale));
        return Bounds ?? Rectangle.Empty;
    }

    /// <summary>
    /// Expressions of this instance.
    /// </summary>
    /// <returns></returns>
    public HashSet<IExpression> Expressions()
    {
        var set = new HashSet<IExpression>() { this };
        return set;
    }
}
