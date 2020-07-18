// <copyright file="RootExpression.cs" company="Shkyrockett" >
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
using System.Drawing;

namespace PrimerLibrary
{
    /// <summary>
    /// The root equation class.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class RootExpression
        : IExpression, INegatable, IEditable
    {
        #region Fields
        /// <summary>
        /// Gap between items and horizontal lines.
        /// </summary>
        private readonly float ExtraHeight = 2;

        /// <summary>
        /// Extra width of line under the index.
        /// </summary>
        private readonly float ExtraWidth = 4;

        /// <summary>
        /// The index
        /// </summary>
        private readonly IExpression Index;

        /// <summary>
        /// The radicand
        /// </summary>
        private readonly IExpression Radicand;

        /// <summary>
        /// The angle for the radical sign.
        /// </summary>
        private readonly float Angle = 80f * MathF.PI / 180f;

        /// <summary>
        /// The font size
        /// </summary>
        private float FontSize = 20;
        #endregion

        #region Constructors
        /// <summary>
        /// Initialize the equation.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="radicand">The radicand.</param>
        public RootExpression(IExpression index, IExpression radicand)
        {
            Index = index;
            Radicand = radicand;
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
            Index.SetFontSizes(fontSize * 0.75f);
            Radicand.SetFontSizes(fontSize);
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public SizeF GetSize(Graphics graphics, Font font)
        {
            return GetSizes(graphics, font, out _, out _);
        }

        /// <summary>
        /// Calculate sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="indexSize">Size of the index.</param>
        /// <param name="radicandSize">Size of the radicand.</param>
        /// <returns></returns>
        private SizeF GetSizes(Graphics graphics, Font font, out SizeF indexSize, out SizeF radicandSize)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);

            // Get the sizes of the index and radicand.
            indexSize = Index.GetSize(graphics, tempFont);
            radicandSize = Radicand.GetSize(graphics, tempFont);

            // See how tall we must be.
            var height = ExtraHeight + Math.Max(2 * indexSize.Height, radicandSize.Height);

            // Calculate our width.
            var width = indexSize.Width + radicandSize.Width + (float)Math.Cos(Angle) * 1.5f * height + ExtraWidth;

            // Set our size.
            return new SizeF(width, height);
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
            var our_size = GetSizes(graphics, font, out SizeF index_size, out SizeF radicand_size);
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);

            // Draw the radical symbol.
            float cos = MathF.Cos(Angle);
            float sin = MathF.Sin(Angle);
            float offset = 2f;
            var x1 = x + index_size.Width + ExtraWidth;
            var x2 = x1 + cos * our_size.Height / 2f;
            var x3 = x2 + cos * our_size.Height;
            var x4 = x + our_size.Width;
            var y1 = y + our_size.Height / 2f + ExtraHeight;
            var y2 = y + our_size.Height + ExtraHeight;
            var y3 = y;
            var y4 = y;
            PointF[] pts =
            {
                new PointF(x3, y3),
                new PointF(x2, y2 - offset * (1f / cos)),
                new PointF(x1, y1),
                new PointF(x, y1),
                new PointF(x1 - offset * (1f / sin), y1),
                new PointF(x2, y2),
                new PointF(x3 + offset, y3),
                new PointF(x4, y4),
                new PointF(x3, y3),
            };
            graphics.FillPolygon(brush, pts);
            graphics.DrawLines(pen, pts);

            //graphics.DrawLine(pen, x4, y4, x3, y4);
            //var checkFont = graphics.FindFont("√", radicand_size, tempFont);

            //graphics.DrawString("√", checkFont, brush, new PointF(x, y));

            // Draw the index.
            var index_x = x + ExtraWidth;
            var index_y = y + (our_size.Height / 2f - index_size.Height) / 2f;
            Index.Draw(graphics, tempFont, pen, brush, index_x, index_y);

            // Draw the radicand.
            var randicand_x = x3;
            var randicand_y = y + ExtraHeight + (our_size.Height - ExtraHeight - radicand_size.Height) / 2f;
            Radicand.Draw(graphics, tempFont, pen, brush, randicand_x, randicand_y);
        }
    }
}
