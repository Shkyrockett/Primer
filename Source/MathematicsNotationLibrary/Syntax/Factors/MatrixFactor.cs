// <copyright file="MatrixFactor.cs" company="Shkyrockett" >
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
using System.Linq;
using System.Text.Json.Serialization;

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
/// <seealso cref="IExpression" />
public class MatrixFactor
    : IExponatable, IGroupable, IEditable
{
    #region Fields
    /// <summary>
    /// The items to draw.
    /// </summary>
    private readonly int NumRows;

    /// <summary>
    /// The items to draw.
    /// </summary>
    private readonly int NumCols;

    /// <summary>
    /// True if we should make rows/columns have the same sizes.
    /// </summary>
    private readonly bool UniformRowSize;

    /// <summary>
    /// True if we should make rows/columns have the same sizes.
    /// </summary>
    private readonly bool UniformColSize;
    #endregion

    #region Constructors
    /// <summary>
    /// Initialize the items.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="cols">The cols.</param>
    /// <param name="items">The items.</param>
    public MatrixFactor(int rows, int cols, params ProductTerm[] items)
        : this(rows, cols, true, true, true, BarStyles.Bracket, false, items)
    { }

    /// <summary>
    /// Initialize the items.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="cols">The cols.</param>
    /// <param name="group">if set to <see langword="true" /> [group].</param>
    /// <param name="groupingStyle">The grouping style.</param>
    /// <param name="items">The items.</param>
    public MatrixFactor(int rows, int cols, bool group, BarStyles groupingStyle, params ProductTerm[] items)
        : this(rows, cols, true, true, group, groupingStyle, false, items)
    { }

    /// <summary>
    /// Initialize the items.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="cols">The cols.</param>
    /// <param name="uniformRowSize">if set to <see langword="true" /> [uniform row size].</param>
    /// <param name="uniformColSize">if set to <see langword="true" /> [uniform col size].</param>
    /// <param name="group">if set to <see langword="true" /> [group].</param>
    /// <param name="groupingStyle">The grouping style.</param>
    /// <param name="items">The items.</param>
    public MatrixFactor(int rows, int cols, bool uniformRowSize, bool uniformColSize, bool group, BarStyles groupingStyle, params ProductTerm[] items)
        : this(rows, cols, uniformRowSize, uniformColSize, group, groupingStyle, false, items)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="MatrixFactor" /> class.
    /// </summary>
    /// <param name="rows">The rows.</param>
    /// <param name="cols">The cols.</param>
    /// <param name="uniformRowSize">if set to <see langword="true" /> [uniform row size].</param>
    /// <param name="uniformColSize">if set to <see langword="true" /> [uniform col size].</param>
    /// <param name="group">if set to <see langword="true" /> [group].</param>
    /// <param name="groupingStyle">The grouping style.</param>
    /// <param name="editable">if set to <see langword="true" /> [editable].</param>
    /// <param name="items">The items.</param>
    public MatrixFactor(int rows, int cols, bool uniformRowSize, bool uniformColSize, bool group, BarStyles groupingStyle, bool editable = false, params ProductTerm[] items)
    {
        Parent = null;
        NumRows = rows;
        NumCols = cols;
        UniformRowSize = uniformRowSize;
        UniformColSize = uniformColSize;
        Group = group;
        GroupingStyle = groupingStyle;

        Items = new ProductTerm[rows, cols];
        for (int i = 0, row = 0; row < NumRows; row++)
        {
            for (var col = 0; col < NumCols; col++, i++)
            {
                if (i >= items.Length)
                {
                    break;
                }

                Items[row, col] = items[i];
                if (Items[row, col] is IChild c)
                {
                    c.Parent = this;
                }
            }
            if (i >= items.Length)
            {
                break;
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
    /// Gets the items.
    /// </summary>
    /// <value>
    /// The items.
    /// </value>
    public ProductTerm[,] Items { get; }

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
    /// Measure the row and column sizes.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="matrixSize">Size of the matrix.</param>
    /// <param name="gap">The gap.</param>
    /// <param name="rowHeights">The row heights.</param>
    /// <param name="colWidths">The col widths.</param>
    /// <param name="leftGroup">The left group.</param>
    /// <param name="leftScale">The left scale.</param>
    /// <param name="rightGroup">The right group.</param>
    /// <param name="rightScale">The right scale.</param>
    /// <param name="sequenceSize">Size of the sequence.</param>
    /// <param name="exponentSize">Size of the exponent.</param>
    /// <returns></returns>
    private SizeF Layout(Graphics graphics, Font font, float scale, out SizeF matrixSize, out float gap, out float[] rowHeights, out float[] colWidths, out SizeF leftGroup, out float leftScale, out SizeF rightGroup, out float rightScale, out SizeF sequenceSize, out SizeF exponentSize)
    {
        Scale = scale;
        // Make room for the values.
        rowHeights = new float[NumRows];
        colWidths = new float[NumCols];

        using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
        gap = graphics.MeasureString("|", tempFont, PointF.Empty, StringFormat.GenericTypographic).Width;

        // Get the largest row heights and column widths.
        for (var row = 0; row < NumRows; row++)
        {
            for (var col = 0; col < NumCols; col++)
            {
                if (Items[row, col] is not null)
                {
                    var item_size = Items[row, col].Layout(graphics, font, scale);
                    if (rowHeights[row] < item_size.Height)
                    {
                        rowHeights[row] = item_size.Height;
                    }

                    if (colWidths[col] < item_size.Width)
                    {
                        colWidths[col] = item_size.Width;
                    }
                }
            }
        }

        // See if we want uniform row heights.
        if (UniformRowSize)
        {
            // Get the maximum row height.
            var max_height = rowHeights.Max();

            // Set all rows to this height.
            for (var row = 0; row < NumRows; row++)
            {
                rowHeights[row] = max_height;
            }
        }

        // See if we want uniform column widths.
        if (UniformColSize)
        {
            // Get the maximum col width.
            var max_width = colWidths.Max();

            // Set all cols to this width.
            for (var col = 0; col < NumCols; col++)
            {
                colWidths[col] = max_width;
            }
        }

        var (width, height) = matrixSize = new SizeF(colWidths.Sum() + (gap * (colWidths.Length - 1)), rowHeights.Sum());

        if (Group)
        {
            (leftGroup, leftScale) = Utilities.CalculateCharacterSizeForHeight(graphics, font, Utilities.BarStyleStringLeft(GroupingStyle), height + gap, StringFormat.GenericTypographic);
            width += leftGroup.Width;
            (rightGroup, rightScale) = Utilities.CalculateCharacterSizeForHeight(graphics, font, Utilities.BarStyleStringRight(GroupingStyle), height + gap, StringFormat.GenericTypographic);
            width += leftGroup.Width;
        }
        else
        {
            leftGroup = rightGroup = new SizeF(0, height);
            leftScale = rightScale = 1f;
        }

        using var sequenceFont = new Font(font.FontFamily, font.Size * scale * Mathematics.SequenceScale, font.Style);
        sequenceSize = Sequence?.Layout(graphics, font, scale) ?? new SizeF(0f, graphics.MeasureString(" ", sequenceFont, Point.Empty, StringFormat.GenericTypographic).Height);

        using var exponentFont = new Font(font.FontFamily, font.Size * scale * Mathematics.ExponentScale, font.Style);
        exponentSize = Exponent?.Layout(graphics, font, scale) ?? new SizeF(0f, graphics.MeasureString(" ", exponentFont, Point.Empty, StringFormat.GenericTypographic).Height);
        width += Math.Max(sequenceSize.Width, exponentSize.Width);
        height += (Sequence is not null) ? sequenceSize.Height * Mathematics.SequenceOffsetScale : 0f;
        height += (Exponent is not null) ? exponentSize.Height * Mathematics.ExponentOffsetScale : 0f;

        return new SizeF(width, Math.Max(height, leftGroup.Height));
    }

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="matrixBounds">The matrix bounds.</param>
    /// <param name="cells">The cells.</param>
    /// <param name="leftGroupBounds">The left group bounds.</param>
    /// <param name="leftScale">The left scale.</param>
    /// <param name="rightGroupBounds">The right group bounds.</param>
    /// <param name="rightScale">The right scale.</param>
    /// <param name="sequenceBounds">The sequence bounds.</param>
    /// <param name="exponentBounds">The exponent bounds.</param>
    /// <returns></returns>
    private RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF matrixBounds, out RectangleF[,] cells, out RectangleF leftGroupBounds, out float leftScale, out RectangleF rightGroupBounds, out float rightScale, out RectangleF sequenceBounds, out RectangleF exponentBounds)
    {
        var size = Layout(graphics, font, scale, out var matrixSize, out var gap, out var rowHeights, out var colWidths, out var leftGroupSize, out leftScale, out var rightGroupSize, out rightScale, out var sequenceSize, out var exponentSize);
        Bounds = new RectangleF(location, size);

        matrixBounds = new RectangleF(location.X + leftGroupSize.Width, location.Y + ((size.Height - matrixSize.Height) * Mathematics.OneHalf), matrixSize.Width - rightGroupSize.Width, matrixSize.Height);
        sequenceBounds = sequenceSize.Width > 0
            ? new RectangleF(new(location.X + matrixSize.Width + leftGroupSize.Width + rightGroupSize.Width, location.Y + size.Height - sequenceSize.Height + sequenceSize.Height * Mathematics.SequenceOffsetScale), sequenceSize)
            : RectangleF.Empty;

        if (exponentSize.Width > 0)
        {
            exponentBounds = new RectangleF(new(location.X + matrixSize.Width + leftGroupSize.Width + rightGroupSize.Width, location.Y), exponentSize);
            location.Y += exponentSize.Height * Mathematics.ExponentOffsetScale;
        }
        else
        {
            exponentBounds = RectangleF.Empty;
        }

        if (Group)
        {
            leftGroupBounds = new RectangleF(new(location.X, location.Y - (gap * Mathematics.OneHalf)), leftGroupSize);
            location.X += leftGroupSize.Width;
            rightGroupBounds = new RectangleF(new(location.X + matrixSize.Width, location.Y - (gap * Mathematics.OneHalf)), rightGroupSize);
        }
        else
        {
            leftGroupBounds = RectangleF.Empty;
            rightGroupBounds = RectangleF.Empty;
        }

        // Draw the items.
        cells = new RectangleF[NumRows, NumCols];
        var rowY = location.Y + ((size.Height - matrixSize.Height) * Mathematics.OneHalf);
        for (var row = 0; row < NumRows; row++)
        {
            var colX = location.X;
            for (var col = 0; col < NumCols; col++)
            {
                if (Items[row, col] is not null)
                {
                    // Get the item's size.
                    var itemSize = Items[row, col].Layout(graphics, font, scale);

                    // Draw the item.
                    cells[row, col] = new RectangleF(new PointF(colX + ((colWidths[col] - itemSize.Width) * 0.5f), rowY + ((rowHeights[row] - itemSize.Height) * 0.5f)), itemSize);
                }

                // Move to the next column.
                colX += colWidths[col] + gap;
            }

            // Move to the next row.
            rowY += rowHeights[row];
        }

        return Bounds ?? Rectangle.Empty;
    }

    /// <summary>
    /// Return the equation's size.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    public SizeF Layout(Graphics graphics, Font font, float scale) => Layout(graphics, font, scale, out _, out _, out _, out _, out _, out _, out _, out _, out _, out _);

    /// <summary>
    /// Layouts the specified graphics.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="location">The location.</param>
    /// <returns></returns>
    public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale) => Layout(graphics, font, location, scale, out _, out _, out _, out _, out _, out _, out _, out _);

    /// <summary>
    /// Draw the equation.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="font">The font.</param>
    /// <param name="brush">The brush.</param>
    /// <param name="pen">The pen.</param>
    /// <param name="location">The location.</param>
    /// <param name="scale">The scale.</param>
    /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
    /// <returns></returns>
    public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, PointF location, float scale, bool drawBounds = false)
    {
        var bounds = Layout(graphics, font, location, scale, out var matrixBounds, out var cells, out var leftGroupBounds, out var leftScale, out var rightGroupBounds, out var rightScale, out var sequenceBounds, out var exponentBounds);

        if (drawBounds)
        {
            using var dashedPen = new Pen(Color.Blue, 1)
            {
                DashStyle = DashStyle.Dash
            };

            graphics.DrawRectangle(dashedPen, bounds);
            graphics.DrawRectangle(dashedPen, matrixBounds);
        }

        if (sequenceBounds.Width > 0)
        {
            Sequence?.Draw(graphics, font, brush, pen, sequenceBounds.Location, scale * Mathematics.SequenceScale, drawBounds);
        }

        if (exponentBounds.Width > 0)
        {
            Exponent?.Draw(graphics, font, brush, pen, exponentBounds.Location, scale * Mathematics.ExponentScale, drawBounds);
        }

        if (Group)
        {
            Utilities.DrawLeftBar(graphics, font, pen, brush, leftScale, leftGroupBounds.Location, GroupingStyle, drawBounds);
            Utilities.DrawRightBar(graphics, font, pen, brush, rightScale, rightGroupBounds.Location, GroupingStyle, drawBounds);
        }

        // Draw the items.
        for (var row = 0; row < NumRows; row++)
        {
            for (var col = 0; col < NumCols; col++)
            {
                if (Items[row, col] is not null)
                {
                    Items[row, col].Draw(graphics, font, brush, pen, cells[row, col].Location, scale, drawBounds);
                }
            }
        }
    }

    /// <summary>
    /// Expressions of this instance.
    /// </summary>
    /// <returns></returns>
    public HashSet<IExpression> Expressions()
    {
        var set = new HashSet<IExpression>() { this };
        foreach (var item in Items)
        {
            set.UnionWith(item.Expressions());
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
