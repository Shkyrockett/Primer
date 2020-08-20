// <copyright file="MatrixFactor.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
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

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class MatrixFactor
        : IExponentableFactor, IGroupable, IEditable
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
        /// <param name="group">if set to <see langword="true" /> [group].</param>
        /// <param name="groupingStyle">The grouping style.</param>
        /// <param name="items">The items.</param>
        public MatrixFactor(int rows, int cols, params IExpression[] items)
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
        public MatrixFactor(int rows, int cols, bool group, BarStyles groupingStyle, params IExpression[] items)
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
        public MatrixFactor(int rows, int cols, bool uniformRowSize, bool uniformColSize, bool group, BarStyles groupingStyle, params IExpression[] items)
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
        public MatrixFactor(int rows, int cols, bool uniformRowSize, bool uniformColSize, bool group, BarStyles groupingStyle, bool editable = false, params IExpression[] items)
        {
            Parent = null;
            NumRows = rows;
            NumCols = cols;
            UniformRowSize = uniformRowSize;
            UniformColSize = uniformColSize;
            Group = group;
            GroupingStyle = groupingStyle;

            Items = new IExpression[rows, cols];
            for (int i = 0, row = 0; row < NumRows; row++)
            {
                for (var col = 0; col < NumCols; col++, i++)
                {
                    if (i >= items.Length) break;
                    Items[row, col] = items[i];
                    if (Items[row, col] is IExpression c) c.Parent = this;
                }
                if (i >= items.Length) break;
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
        public IExpression[,] Items { get; }

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
        public ICoefficient? Sequence { get; set; }

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
        /// Gets a value indicating whether this <see cref="CoefficientFactor"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }
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
        private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF matrixSize, out float gap, out float[] rowHeights, out float[] colWidths, out SizeF leftGroup, out float leftScale, out SizeF rightGroup, out float rightScale, out SizeF sequenceSize, out SizeF exponentSize)
        {
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
                    if (Items[row, col] != null)
                    {
                        SizeF item_size = Items[row, col].Dimensions(graphics, font, scale);
                        if (rowHeights[row] < item_size.Height) rowHeights[row] = item_size.Height;
                        if (colWidths[col] < item_size.Width) colWidths[col] = item_size.Width;
                    }
                }
            }

            // See if we want uniform row heights.
            if (UniformRowSize)
            {
                // Get the maximum row height.
                var max_height = rowHeights.Max();

                // Set all rows to this height.
                for (var row = 0; row < NumRows; row++) rowHeights[row] = max_height;
            }

            // See if we want uniform column widths.
            if (UniformColSize)
            {
                // Get the maximum col width.
                var max_width = colWidths.Max();

                // Set all cols to this width.
                for (var col = 0; col < NumCols; col++) colWidths[col] = max_width;
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

            using var sequenceFont = new Font(font.FontFamily, font.Size * scale * MathConstants.SequenceScale, font.Style);
            sequenceSize = Sequence?.Dimensions(graphics, font, scale) ?? new SizeF(0f, graphics.MeasureString(" ", sequenceFont, Point.Empty, StringFormat.GenericTypographic).Height);

            using var exponentFont = new Font(font.FontFamily, font.Size * scale * MathConstants.ExponentScale, font.Style);
            exponentSize = Exponent?.Dimensions(graphics, font, scale) ?? new SizeF(0f, graphics.MeasureString(" ", exponentFont, Point.Empty, StringFormat.GenericTypographic).Height);
            width += Math.Max(sequenceSize.Width, exponentSize.Width);
            height += (Sequence is not null) ? sequenceSize.Height * MathConstants.SequenceOffsetScale : 0f;
            height += (Exponent is not null) ? exponentSize.Height * MathConstants.ExponentOffsetScale : 0f;

            return new SizeF(width, Math.Max(height, leftGroup.Height));
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public SizeF Dimensions(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _, out _, out _, out _, out _, out _, out _, out _);

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float scale, float x, float y, bool drawBounds = false)
        {
            var size = Dimensions(graphics, font, scale, out SizeF matrixSize, out var gap, out var rowHeights, out var colWidths, out var leftGroup, out var leftScale, out var rightGroup, out var rightScale, out var sequenceSize, out var exponentSize);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.Blue, 1)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size);
                graphics.DrawRectangle(dashedPen, x + leftGroup.Width, y + ((size.Height - matrixSize.Height) * MathConstants.OneHalf), matrixSize);
            }

            if (sequenceSize.Width > 0)
            {
                Sequence?.Draw(graphics, font, brush, pen, scale * MathConstants.SequenceScale, x + matrixSize.Width + leftGroup.Width + rightGroup.Width, y + size.Height - sequenceSize.Height + sequenceSize.Height * MathConstants.SequenceOffsetScale, drawBounds);
            }

            if (exponentSize.Width > 0)
            {
                Exponent?.Draw(graphics, font, brush, pen, scale * MathConstants.ExponentScale, x + matrixSize.Width + leftGroup.Width + rightGroup.Width, y, drawBounds);
                y += exponentSize.Height * MathConstants.ExponentOffsetScale;
            }

            if (Group)
            {
                Utilities.DrawLeftBar(graphics, font, pen, brush, leftScale, x, y - (gap * MathConstants.OneHalf), GroupingStyle, drawBounds);
                x += leftGroup.Width;
                Utilities.DrawRightBar(graphics, font, pen, brush, rightScale, x + matrixSize.Width, y - (gap * MathConstants.OneHalf), GroupingStyle, drawBounds);
            }

            // Draw the items.
            var rowY = y + ((size.Height - matrixSize.Height) * MathConstants.OneHalf);
            for (var row = 0; row < NumRows; row++)
            {
                var colX = x;
                for (var col = 0; col < NumCols; col++)
                {
                    if (Items[row, col] != null)
                    {
                        // Get the item's size.
                        var itemSize = Items[row, col].Dimensions(graphics, font, scale);

                        // Draw the item.
                        var item_x = colX + ((colWidths[col] - itemSize.Width) * 0.5f);
                        var item_y = rowY + ((rowHeights[row] - itemSize.Height) * 0.5f);
                        Items[row, col].Draw(graphics, font, brush, pen, scale, item_x, item_y, drawBounds);
                    }

                    // Move to the next column.
                    colX += colWidths[col] + gap;
                }

                // Move to the next row.
                rowY += rowHeights[row];
            }
        }

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <param name="drawBorders">if set to <see langword="true" /> [draw borders].</param>
        /// <returns></returns>
        public HashSet<IRenderable> Layout(Graphics graphics, Font font, Brush brush, Pen pen, float scale, PointF location, bool drawBorders = false)
        {
            var size = Dimensions(graphics, font, scale, out SizeF matrixSize, out var gap, out var rowHeights, out var colWidths, out var leftGroup, out var leftScale, out var rightGroup, out var rightScale, out var sequenceSize, out var exponentSize);
            var map = new HashSet<IRenderable>();

            // ToDo: Layout here.

            return map;
        }
    }
}
