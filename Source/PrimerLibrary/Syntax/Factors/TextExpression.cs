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

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.Json.Serialization;

namespace PrimerLibrary
{
    /// <summary>
    /// Draw some text.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class TextExpression
        : IExpression, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TextExpression" /> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public TextExpression(string text, bool editable = false)
        {
            Parent = null;
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
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        [JsonIgnore]
        public IExpression? Parent { get; set; }

        /// <summary>
        /// Gets or sets the sign of the expression.
        /// </summary>
        /// <value>
        /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
        /// </value>
        public int Sign { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CoefficientFactor"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }
        #endregion

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public SizeF Dimensions(Graphics graphics, Font font, float scale)
        {
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            return graphics.MeasureString(string.IsNullOrEmpty(Text) ? " " : Text, tempFont);
        }

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float scale, float x, float y, bool drawBounds = false)
        {
            var size = Dimensions(graphics, font, scale);
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.Red, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size);
            }

            if (!string.IsNullOrWhiteSpace(Text))
            {
                //TextRenderer.DrawText(graphics, Text, tempFont, new Point((int)x, (int)y), Color.Lime);
                graphics.DrawString(Text, tempFont, brush, x, y);
            }
            else
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size);
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
        public HashSet<IRenderable> Layout(Graphics graphics, Font font, Brush? brush, Pen? pen, float scale, PointF location, bool drawBorders = false)
        {
            var size = Dimensions(graphics, font, scale);
            var map = new HashSet<IRenderable>();

            if (drawBorders)
            {
                using var dashedPen = new Pen(Color.Red, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                map.Add(new RectangleElement(location, size, null, dashedPen));
            }

            if (!string.IsNullOrWhiteSpace(Text))
            {
                map.Add(new TextElement(Text, font, brush, null, new RectangleF(location, size)));
            }
            else
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                map.Add(new RectangleElement(location, size, null, dashedPen));
            }

            return map;
        }
    }
}
