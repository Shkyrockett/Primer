// <copyright file="CustomFunction.cs" company="Shkyrockett" >
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

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
/// <seealso cref="IExpression" />
/// <seealso cref="IFunction" />
/// <seealso cref="IFactor" />
/// <seealso cref="IGroupable" />
public class CustomFunction
    : IExpression, IChild, IFunction, IFactor, ISequenceable, IExponatable, IGroupable
{
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="CustomFunction" /> class.
    /// </summary>
    /// <param name="functionName">Name of the function.</param>
    /// <param name="variableName">Name of the variable.</param>
    /// <param name="argument">The argument.</param>
    /// <param name="sequence">The sequence.</param>
    /// <param name="exponent">The exponent.</param>
    /// <param name="groupingStyle">The grouping style.</param>
    public CustomFunction(string functionName, string variableName, IExpression? argument, INumeric? sequence = null, IExpression? exponent = null, BarStyles groupingStyle = BarStyles.None)
        : this(null, functionName, variableName, argument, sequence, exponent, groupingStyle)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomFunction" /> class.
    /// </summary>
    /// <param name="parent">The parent.</param>
    /// <param name="functionName">Name of the function.</param>
    /// <param name="variableName">Name of the variable.</param>
    /// <param name="argument">The argument.</param>
    /// <param name="sequence">The sequence.</param>
    /// <param name="exponent">The exponent.</param>
    /// <param name="groupingStyle">The grouping style.</param>
    public CustomFunction(IExpression? parent, string functionName, string variableName, IExpression? argument, INumeric? sequence = null, IExpression? exponent = null, BarStyles groupingStyle = BarStyles.None)
    {
        Parent = parent;
        FunctionName = functionName.Italicize();
        VariableName = variableName.Italicize();
        Argument = argument;
        if (Argument is IChild a)
        {
            a.Parent = this;
        }

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

        GroupingStyle = groupingStyle;
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the parent.
    /// </summary>
    /// <value>
    /// The parent.
    /// </value>
    public IExpression? Parent { get; set; }

    /// <summary>
    /// Gets or sets the name of the function.
    /// </summary>
    /// <value>
    /// The name of the function.
    /// </value>
    public string FunctionName { get; set; }

    /// <summary>
    /// Gets or sets the name of the variable.
    /// </summary>
    /// <value>
    /// The name of the function.
    /// </value>
    public string VariableName { get; set; }

    /// <summary>
    /// Gets or sets the argument of the function.
    /// </summary>
    /// <value>
    /// The argument.
    /// </value>
    public IExpression? Argument { get; set; }

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
    /// Gets or sets the grouping style.
    /// </summary>
    /// <value>
    /// The grouping style.
    /// </value>
    public BarStyles GroupingStyle { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="IGroupable" /> is group.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if group; otherwise, <see langword="false" />.
    /// </value>
    public bool Group { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="CustomFunction"/> is editable.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
    /// </value>
    public bool Editable { get; set; }

    /// <summary>
    /// Gets or sets the bounds.
    /// </summary>
    /// <value>
    /// The bounds.
    /// </value>
    public RectangleF? Bounds { get; set; }

    /// <summary>
    /// Gets or sets the location.
    /// </summary>
    /// <value>
    /// The location.
    /// </value>
    public PointF? Location { get; set; }

    /// <summary>
    /// Gets or sets the size.
    /// </summary>
    /// <value>
    /// The size.
    /// </value>
    public SizeF? Size { get; set; }

    /// <summary>
    /// Gets or sets the scale.
    /// </summary>
    /// <value>
    /// The scale.
    /// </value>
    public float? Scale { get; set; }
    #endregion

    #region Methods
    /// <summary>
    /// Gets the text for the function.
    /// </summary>
    /// <returns></returns>
    private string GetText() => $"{FunctionName}({VariableName}) = ";

    /// <summary>
    /// Calculates the specified dimensions.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="functionSize">Size of the function.</param>
    /// <param name="argumentSize">Size of the argument.</param>
    /// <returns></returns>
    private SizeF Layout(Graphics graphics, Font font, float scale, out SizeF functionSize, out SizeF argumentSize)
    {
        Scale = scale;
        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);

        functionSize = graphics.MeasureString(GetText(), tempFont);
        argumentSize = Argument?.Layout(graphics, font, scale) ?? graphics.MeasureString(" ", tempFont);

        Size = new SizeF(functionSize.Width + argumentSize.Width, MathF.Max(argumentSize.Height, functionSize.Height));
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
    /// <param name="argumentBounds">The argument bounds.</param>
    /// <returns></returns>
    private RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF functionBounds, out RectangleF argumentBounds)
    {
        var size = Layout(graphics, font, scale, out var functionSize, out var argumentSize);
        Bounds = new RectangleF(location, size);

        functionBounds = new RectangleF(new PointF(location.X, location.Y + ((size.Height - functionSize.Height) * Mathematics.OneHalf)), functionSize);
        argumentBounds = new RectangleF(new PointF(location.X + functionSize.Width, location.Y + ((size.Height - argumentSize.Height) * Mathematics.OneHalf)), argumentSize);
        return Bounds ?? Rectangle.Empty;
    }

    /// <summary>
    /// Calculates the specified dimensions.
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
    /// Draws the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="brush">The brush.</param>
    /// <param name="pen">The pen.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
    /// <exception cref="NotImplementedException"></exception>
    public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, PointF location, float scale, bool drawBounds = false)
    {
        var bounds = Layout(graphics, font, location, scale, out var functionBounds, out var argumentBounds);

        if (drawBounds)
        {
            using var dashedPen = new Pen(Color.DarkBlue, 0)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, functionBounds);
            graphics.DrawRectangle(dashedPen, argumentBounds);
            graphics.DrawRectangle(dashedPen, bounds);
        }

        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        graphics.DrawString(GetText(), tempFont, brush, functionBounds.Location);
        Argument?.Draw(graphics, font, brush, pen, argumentBounds.Location, scale, drawBounds);
    }

    /// <summary>
    /// Expressionses this instance.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public HashSet<IExpression> Expressions()
    {
        var set = new HashSet<IExpression>() { this };
        if (Argument is not null)
        {
            set.UnionWith(Argument.Expressions());
        }

        if (Sequence is not null)
        {
            set.UnionWith(Sequence.Expressions());
        }

        return set;
    }
    #endregion
}
