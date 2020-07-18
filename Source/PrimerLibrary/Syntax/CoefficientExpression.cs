// <copyright file="CoefficientExpression.cs" company="Shkyrockett" >
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
    /// Draw some text.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class CoefficientExpression
        : IExpression, INegatable, IEditable
    {
        #region Fields
        /// <summary>
        /// The font size
        /// </summary>
        public float FontSize = 20;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize the text.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public CoefficientExpression(double value = 1, bool editable = false)
        {
            Value = value;
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
        public double Value { get; set; } = 1;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is negative.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is negative; otherwise, <see langword="false" />.
        /// </value>
        public bool IsNegative { get { return Sign(Value) == -1d; } set { Value *= value == (Sign(Value) == -1d) ? 1 : -1; } }

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
        public void SetFontSizes(float fontSize) => FontSize = fontSize;

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public SizeF GetSize(Graphics graphics, Font font)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            return graphics.MeasureString(Value != 1 ? Value.ToString("R") : "", tempFont, Point.Empty, StringFormat.GenericTypographic);
        }

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
            SizeF size = GetSize(graphics, tempFont);
#if DrawBox
            using var dashed_pen = new Pen(Color.Red, 0)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
            };
            graphics.DrawRectangle(dashed_pen, x, y, size.Width, size.Height);
#endif
            if (Value != 1)
            {
                graphics.DrawString(Value.ToString("R"), tempFont, brush, x, y);
            }
            else
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size.Width, size.Height);

            }
        }
    }
}
