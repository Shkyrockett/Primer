// <copyright file="TextExpression.cs" company="Shkyrockett" >
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

namespace PrimerLibrary
{
    /// <summary>
    /// Draw some text.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class TextExpression
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
        /// <param name="text">The text.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public TextExpression(string text, bool editable = false)
        {
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
            return graphics.MeasureString(string.IsNullOrEmpty(Text) ? " " : Text, tempFont);
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
            if (!string.IsNullOrWhiteSpace(Text))
            {
                graphics.DrawString(Text, tempFont, brush, x, y);
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
