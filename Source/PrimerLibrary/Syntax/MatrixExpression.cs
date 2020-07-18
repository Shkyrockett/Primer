// <copyright file="MatrixExpression.cs" company="Shkyrockett" >
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

using System.Drawing;
using System.Linq;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class MatrixExpression
        : IExpression, INegatable, IEditable
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
        /// The items to draw.
        /// </summary>
        private readonly IExpression[,] Items;

        /// <summary>
        /// Space to add between rows and columns;
        /// </summary>
        private const float RowSpace = 4;

        /// <summary>
        /// Space to add between rows and columns;
        /// </summary>
        private const float ColSpace = 4;

        /// <summary>
        /// True if we should make rows/columns have the same sizes.
        /// </summary>
        private readonly bool UniformRowSize;

        /// <summary>
        /// True if we should make rows/columns have the same sizes.
        /// </summary>
        private readonly bool UniformColSize;

        /// <summary>
        /// The font size
        /// </summary>
        private float FontSize = 20;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize the items.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <param name="uniformRowSize">if set to <see langword="true" /> [uniform row size].</param>
        /// <param name="uniformColSize">if set to <see langword="true" /> [uniform col size].</param>
        /// <param name="items">The items.</param>
        public MatrixExpression(int rows, int cols, bool uniformRowSize, bool uniformColSize, params IExpression[] items)
            : this(rows, cols, uniformRowSize, uniformColSize, false, items)
        { }

        /// <summary>
        /// Initialize the items.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <param name="uniformRowSize">if set to <see langword="true" /> [uniform row size].</param>
        /// <param name="uniformColSize">if set to <see langword="true" /> [uniform col size].</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        /// <param name="items">The items.</param>
        public MatrixExpression(int rows, int cols, bool uniformRowSize, bool uniformColSize, bool editable = false, params IExpression[] items)
        {
            NumRows = rows;
            NumCols = cols;
            UniformRowSize = uniformRowSize;
            UniformColSize = uniformColSize;

            Items = new IExpression[rows, cols];
            for (int i = 0, row = 0; row < NumRows; row++)
            {
                for (var col = 0; col < NumCols; col++, i++)
                {
                    if (i >= items.Length) break;
                    Items[row, col] = items[i];
                }
                if (i >= items.Length) break;
            }

            Editable = editable;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether this instance is negative.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is negative; otherwise, <see langword="false" />.
        /// </value>
        public bool IsNegative { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CoefficientExpression"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }
        #endregion

        /// <summary>
        /// Set font sizes for sub-equations.
        /// </summary>
        /// <param name="fontSize"></param>
        public void SetFontSizes(float fontSize)
        {
            FontSize = fontSize;
            for (int i = 0, row = 0; row < NumRows; row++)
            {
                for (var col = 0; col < NumCols; col++, i++)
                {
                    Items[row, col].SetFontSizes(fontSize);
                }
            }
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public SizeF GetSize(Graphics graphics, Font font) => MeasureRowsAndColumns(graphics, font, out _, out _, out _);

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void Draw(Graphics graphics, Font font, Pen pen, Brush brush, float x, float y)
        {
            var size = MeasureRowsAndColumns(graphics, font, out var operatorSize, out var row_heights, out var col_widths);
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);

#if DrawBox
            using (var dashed_pen = new Pen(Color.Blue, 1))
            {
                dashed_pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                graphics.DrawRectangle(dashed_pen, x, y, size.Width, size.Height);
            }
#endif

            using StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            if (IsNegative)
            {
                var operatorRect = new RectangleF(
                    x,
                    y,
                    operatorSize.Width,
                    size.Height
                    );
                graphics.DrawString("-", tempFont, brush, operatorRect, stringFormat);
                x += operatorSize.Width;
            }

            // Draw the items.
            var row_y = y;
            for (var row = 0; row < NumRows; row++)
            {
                var col_x = x;
                for (var col = 0; col < NumCols; col++)
                {
                    if (Items[row, col] != null)
                    {
                        // Get the item's size.
                        SizeF item_size = Items[row, col].GetSize(graphics, tempFont);

                        // Draw the item.
                        var item_x = col_x + (col_widths[col] - item_size.Width) / 2;
                        var item_y = row_y + (row_heights[row] - item_size.Height) / 2;
                        Items[row, col].Draw(graphics, tempFont, pen, brush, item_x, item_y);
                    }

                    // Move to the next column.
                    col_x += col_widths[col] + ColSpace;
                }

                // Move to the next row.
                row_y += row_heights[row] + RowSpace;
            }
        }

        /// <summary>
        /// Measure the row and column sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="operatorSize">Size of the operator.</param>
        /// <param name="rowHeights">The row heights.</param>
        /// <param name="colWidths">The col widths.</param>
        private SizeF MeasureRowsAndColumns(Graphics graphics, Font font, out SizeF operatorSize, out float[] rowHeights, out float[] colWidths)
        {
            // Make room for the values.
            rowHeights = new float[NumRows];
            colWidths = new float[NumCols];

            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            operatorSize = graphics.MeasureString(IsNegative ? "-" : "", tempFont);

            // Get the largest row heights and column widths.
            for (var row = 0; row < NumRows; row++)
            {
                for (var col = 0; col < NumCols; col++)
                {
                    if (Items[row, col] != null)
                    {
                        SizeF item_size = Items[row, col].GetSize(graphics, font);
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

            return new SizeF(colWidths.Sum() + (colWidths.Length - 1) * ColSpace, rowHeights.Sum() + (rowHeights.Length - 1) * RowSpace);
        }
    }
}
