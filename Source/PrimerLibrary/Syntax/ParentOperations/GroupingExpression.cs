// <copyright file="GroupingExpression.cs" company="Shkyrockett" >
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
using System.Drawing.Drawing2D;
using System.Text.Json.Serialization;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class GroupingExpression
        : IExpression, INegatable, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupingExpression" /> class.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <param name="leftBarStyle">The left bar style.</param>
        /// <param name="rightBarStyle">The right bar style.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public GroupingExpression(IExpression contents, BarStyles leftBarStyle, BarStyles rightBarStyle, bool editable = false)
        {
            Parent = null;
            Contents = contents;
            if (Contents is IExpression c) c.Parent = this;
            LeftBarStyle = leftBarStyle;
            RightBarStyle = rightBarStyle;
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
        /// Gets or sets the sign of the expression.
        /// </summary>
        /// <value>
        /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
        /// </value>
        public int Sign { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is negative.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is negative; otherwise, <see langword="false" />.
        /// </value>
        public bool IsNegative { get; set; }

        /// <summary>
        /// Gets the contents.
        /// </summary>
        /// <value>
        /// The contents.
        /// </value>
        public IExpression Contents { get; }

        /// <summary>
        /// Gets the left bar style.
        /// </summary>
        /// <value>
        /// The left bar style.
        /// </value>
        public BarStyles LeftBarStyle { get; }

        /// <summary>
        /// Gets the right bar style.
        /// </summary>
        /// <value>
        /// The right bar style.
        /// </value>
        public BarStyles RightBarStyle { get; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CoefficientFactor"/> is editable.
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
        public PointF? Location { get { return Bounds?.Location; } set { if (Bounds is RectangleF b && value is PointF p) Bounds = new RectangleF(p, b.Size); } }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        [JsonIgnore]
        public SizeF? Size { get { return Bounds?.Size; } set { if (Bounds is RectangleF b && value is SizeF s) Bounds = new RectangleF(b.Location, s); } }

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
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="contentsSize">Size of the contents.</param>
        /// <param name="leftSize">Size of the left.</param>
        /// <param name="leftScale">The left scale.</param>
        /// <param name="rightSize">Size of the right.</param>
        /// <param name="rightScale">The right scale.</param>
        /// <returns></returns>
        public SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF contentsSize, out SizeF leftSize, out float leftScale, out SizeF rightSize, out float rightScale)
        {
            contentsSize = Contents.Dimensions(graphics, font, scale);
            (leftSize, leftScale) = Utilities.CalculateCharacterSizeForHeight(graphics, font, Utilities.BarStyleStringLeft(LeftBarStyle), contentsSize.Height, StringFormat.GenericTypographic);
            (rightSize, rightScale) = Utilities.CalculateCharacterSizeForHeight(graphics, font, Utilities.BarStyleStringRight(RightBarStyle), contentsSize.Height, StringFormat.GenericTypographic);
            return new SizeF(contentsSize.Width + leftSize.Width + rightSize.Width, contentsSize.Height);
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public SizeF Dimensions(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _, out _, out _);

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
            var size = Dimensions(graphics, font, scale, out SizeF contentsSize, out SizeF leftSize, out float leftScale, out SizeF rightSize, out float rightScale);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.Orange, 1)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size);
                graphics.DrawRectangle(dashedPen, x + leftSize.Width, y, contentsSize);
                graphics.DrawRectangle(dashedPen, x + leftSize.Width + contentsSize.Width, y, rightSize);
            }

            Utilities.DrawLeftBar(graphics, font, pen, brush, leftScale, x, y, LeftBarStyle);
            x += leftSize.Width;
            Contents.Draw(graphics, font, brush, pen, scale, x, y, drawBounds);
            x += contentsSize.Width;
            Utilities.DrawRightBar(graphics, font, pen, brush, rightScale, x, y, RightBarStyle);
        }

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale)
        {
            Bounds = new RectangleF(location, Dimensions(graphics, font, scale));
            return Bounds ?? Rectangle.Empty;
        }
    }
}
