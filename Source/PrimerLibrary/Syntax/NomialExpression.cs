// <copyright file="NomialExpression.cs" company="Shkyrockett" >
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
using static System.Math;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    public class NomialExpression
        : IExpression, IEditable
    {
        #region Fields
        /// <summary>
        /// The space between the top and bottom items.
        /// </summary>
        private const float Gap = 2;

        /// <summary>
        /// The font size
        /// </summary>
        public float FontSize = 20;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationalExpression" /> class.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        public NomialExpression(params INegatable[] expressions)
            : this(false, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelationalExpression" /> class.
        /// </summary>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        /// <param name="expressions">The expressions.</param>
        public NomialExpression(bool editable = false, params INegatable[] expressions)
        {
            Expressions = new List<INegatable>((expressions?.Length > 0) ? expressions : new INegatable[] { new TextExpression("") });
            Editable = editable;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the expressions.
        /// </summary>
        /// <value>
        /// The expressions.
        /// </value>
        public List<INegatable> Expressions { get; set; }

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
            foreach (var expression in Expressions)
            {
                expression.SetFontSizes(fontSize);
            }
        }

        /// <summary>
        /// Return the object's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public SizeF GetSize(Graphics graphics, Font font) => GetSizes(graphics, font, out _, out _);

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
            var size = GetSizes(graphics, tempFont, out var operatorSizes, out var nomialSizes);

#if DrawBox
            using var dashedPen = new Pen(Color.Red, 0)
            {
                DashStyle = DashStyle.Dash
            };
            graphics.DrawRectangle(dashedPen, x, y, size.Width, size.Height);
#endif

            using StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var expression = Expressions?.Count > 0 ? Expressions[0] : null;
            var operatorSize = operatorSizes.Length > 0 ? operatorSizes[0] : graphics.MeasureString("", tempFont);
            var nomialSize = nomialSizes.Length > 0 ? nomialSizes[0] : graphics.MeasureString(" ", tempFont);

            // Draw the left.
            expression?.Draw(graphics, tempFont, pen, brush, x, y + (size.Height - nomialSize.Height) / 2f);
            x += nomialSize.Width;
            for (int i = 1; i < (Expressions?.Count ?? 0); i++)
            {
                expression = Expressions?[i];
                operatorSize = operatorSizes[i];
                nomialSize = nomialSizes[i];

                // Draw the Operator.
                if (!(expression?.IsNegative ?? false))
                {
                    var operatorRect = new RectangleF(
                        x + Gap,
                        y,
                        operatorSize.Width,
                        size.Height
                        );
                    graphics.DrawString("+", tempFont, brush, operatorRect, stringFormat);
                    x += operatorSize.Width;
                }

                // Draw the rest.
                expression?.Draw(graphics, tempFont, pen, brush, x, y + (size.Height - nomialSize.Height) / 2f);
                x += nomialSize.Width;
            }
        }

        /// <summary>
        /// Return various sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="operatorSizes">The operator sizes.</param>
        /// <param name="nomialSizes">The nomial sizes.</param>
        /// <returns></returns>
        private unsafe SizeF GetSizes(Graphics graphics, Font font, out Span<SizeF> operatorSizes, out Span<SizeF> nomialSizes)
        {
            var maxHeight = 0f;
            var width = 0f;
            nomialSizes = new SizeF[Expressions.Count];
            operatorSizes = new SizeF[Expressions.Count];
            var isFirst = true;
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            for (int i = 0; i < Expressions.Count; i++)
            {
                var expression = Expressions[i];
                SizeF nomialSize = nomialSizes[i] = expression.GetSize(graphics, tempFont);
                maxHeight = Max(maxHeight, nomialSize.Height);
                var operatorSize = operatorSizes[i] = graphics.MeasureString(isFirst | expression.IsNegative ? "" : "+", tempFont);
                width += nomialSize.Width + (isFirst | expression.IsNegative ? 0 : operatorSize.Width);
                isFirst = false;
            }

            return new SizeF(width + Gap * 2, maxHeight);
        }
    }
}
