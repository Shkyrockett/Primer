// <copyright file="PowerExpression.cs" company="Shkyrockett" >
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
    /// Draw an item to a power.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    /// <seealso cref="PrimerLibrary.IVariable" />
    public class PowerExpression
        : IExpression, INegatable, IVariable, IEditable
    {
        #region Fields
        /// <summary>
        /// The base
        /// </summary>
        private readonly IExpression Base;

        /// <summary>
        /// The power
        /// </summary>
        private readonly IExpression Power;

        /// <summary>
        /// The offset
        /// </summary>
        public float Offset = 1f / 2f;

        /// <summary>
        /// The font size
        /// </summary>
        public float FontSize = 20f;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize a new object.
        /// </summary>
        /// <param name="baseExpression">The base expression.</param>
        /// <param name="powerExpression">The power expression.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public PowerExpression(IExpression baseExpression, IExpression powerExpression, bool editable = false)
        {
            Base = baseExpression;
            Power = powerExpression;
            Editable = editable;
        }

        /// <summary>
        /// Initialize a new object.
        /// </summary>
        /// <param name="baseText">The base text.</param>
        /// <param name="powerText">The power text.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public PowerExpression(string baseText, string powerText, bool editable = false)
            : this(new TextExpression(baseText), new TextExpression(powerText), editable)
        { }
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
            Base.SetFontSizes(fontSize);
            Power.SetFontSizes(fontSize * 0.75f);
        }

        /// <summary>
        /// Return the object's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public SizeF GetSize(Graphics graphics, Font font) => GetSizes(graphics, font, Offset, out _, out _);

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
            var size = GetSizes(graphics, font, Offset, out SizeF baseSize, out SizeF powerSize);

            if (Base is null && Power is null)
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size.Width, size.Height);
            }

            // Draw the base.
            var base_y = y + powerSize.Height * Offset;
            if (Base is not null)
            {
                Base.Draw(graphics, font, pen, brush, x, base_y);
            }
            else
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, baseSize.Width, baseSize.Height);
            }

            // Draw the power.
            var power_x = x + baseSize.Width;
            if (Power is not null)
            {
                Power.Draw(graphics, font, pen, brush, power_x, y);
            }
            else
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, powerSize.Width, powerSize.Height);
            }
        }

        /// <summary>
        /// Return various sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="baseSize">Size of the base.</param>
        /// <param name="powerSize">Size of the power.</param>
        /// <returns></returns>
        private SizeF GetSizes(Graphics graphics, Font font, float offset, out SizeF baseSize, out SizeF powerSize)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            baseSize = Base?.GetSize(graphics, tempFont) ?? graphics.MeasureString(" ", tempFont);
            using var smallFont = new Font(font.FontFamily, FontSize * offset, font.Style);
            powerSize = Power?.GetSize(graphics, smallFont) ?? graphics.MeasureString(" ", tempFont);
            return new SizeF(baseSize.Width + powerSize.Width, baseSize.Height + powerSize.Height * offset);
        }
    }
}
