﻿// <copyright file="RelationalExpression.cs" company="Shkyrockett" >
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
using static System.Math;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    public class RelationalExpression
        : IExpression, IEditable
    {
        #region Fields
        /// <summary>
        /// The space between the top and bottom items.
        /// </summary>
        private const float Gap = 2;

        /// <summary>
        /// The numerator
        /// </summary>
        private readonly IExpression? Left;

        /// <summary>
        /// The denominator
        /// </summary>
        private readonly IExpression? Right;

        /// <summary>
        /// The font size
        /// </summary>
        public float FontSize = 20;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationalExpression" /> class.
        /// </summary>
        /// <param name="operator">The operator.</param>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="rightExpression">The right expression.</param>
        public RelationalExpression(ComparisonOperators @operator, IExpression? leftExpression, IExpression? rightExpression, bool editable = false)
        {
            Left = leftExpression;
            Right = rightExpression;
            Operator = @operator;
            Editable = editable;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the operator.
        /// </summary>
        /// <value>
        /// The operator.
        /// </value>
        public ComparisonOperators Operator { get; set; }

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
            Left?.SetFontSizes(fontSize);
            Right?.SetFontSizes(fontSize);
        }

        /// <summary>
        /// Return the object's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public SizeF GetSize(Graphics graphics, Font font) => GetSizes(graphics, font, out _, out _, out _);

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void Draw(Graphics graphics, Font font, Pen pen, Brush brush, float x, float y)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            SizeF size = GetSizes(graphics, tempFont, out var leftSize, out var operatorSize, out var rightSide);

#if DrawBox
            using var dashed_pen = new Pen(Color.Red, 0)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };
            graphics.DrawRectangle(dashed_pen, x, y, size.Width, size.Height);
#endif
            using StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            // Draw the left Expression.
            if (Left is not null)
            {
                Left?.Draw(graphics, tempFont, pen, brush, x, y + ((size.Height - leftSize.Height) / 2f));
            }
            else
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, leftSize.Width, leftSize.Height);
            }

            // Advance X.
            x += leftSize.Width;

            // Draw the Operator.
            var operatorRect = new RectangleF(x + Gap, y, operatorSize.Width, size.Height);
            graphics.DrawString(Operator.GetString(), tempFont, brush, operatorRect, stringFormat);

            // Advance X.
            x += operatorSize.Width;

            // Draw the right.
            if (Right is not null)
            {
                Right?.Draw(graphics, tempFont, pen, brush, x + (Gap * 2), y + ((size.Height - rightSide.Height) / 2f));
            }
            else
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, leftSize.Width, leftSize.Height);
            }
        }

        /// <summary>
        /// Return various sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="leftSize">Size of the left.</param>
        /// <param name="operatorSize">Size of the operator.</param>
        /// <param name="rightSize">Size of the right.</param>
        /// <returns></returns>
        private SizeF GetSizes(Graphics graphics, Font font, out SizeF leftSize, out SizeF operatorSize, out SizeF rightSize)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            operatorSize = graphics.MeasureString(Operator.GetString(), tempFont, Point.Empty, StringFormat.GenericTypographic);
            leftSize = Left?.GetSize(graphics, tempFont) ?? graphics.MeasureString(" ", tempFont);
            rightSize = Right?.GetSize(graphics, tempFont) ?? graphics.MeasureString(" ", tempFont);
            return new SizeF(operatorSize.Width + leftSize.Width + rightSize.Width + (Gap * 2), Max(leftSize.Height, rightSize.Height));
        }
    }
}