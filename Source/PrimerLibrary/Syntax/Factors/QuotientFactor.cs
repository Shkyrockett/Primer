// <copyright file="QuotientFactor.cs" company="Shkyrockett" >
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
using static System.Math;

namespace PrimerLibrary
{
    /// <summary>
    /// Draw one item over another.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    [JsonConverter(typeof(QuotientFactor))]
    public class QuotientFactor
        : IExponentableFactor, IGroupable, INegatable, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="QuotientFactor"/> class.
        /// </summary>
        /// <param name="dividend">The top text.</param>
        /// <param name="divisor">The bottom text.</param>
        /// <param name="showHorizontalBar">if set to <see langword="true" /> [show horizontal bar].</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public QuotientFactor(string dividend, string divisor, bool showHorizontalBar = true, bool editable = false)
            : this(new TextExpression(dividend), new TextExpression(divisor), showHorizontalBar, editable)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuotientFactor"/> class.
        /// </summary>
        /// <param name="dividend">The top expression.</param>
        /// <param name="divisor">The denominator expression.</param>
        /// <param name="showHorizontalBar">if set to <see langword="true" /> [show horizontal bar].</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public QuotientFactor(IExpression dividend, IExpression divisor, bool showHorizontalBar = true, bool editable = false)
        {
            Parent = null;
            Dividend = dividend;
            if (Dividend is IExpression t) t.Parent = this;
            Divisor = divisor;
            if (Divisor is IExpression b) b.Parent = this;
            ShowHorizontalBar = showHorizontalBar;
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
        /// Gets the numerator.
        /// </summary>
        /// <value>
        /// The numerator.
        /// </value>
        public IExpression Dividend { get; }

        /// <summary>
        /// Gets the denominator.
        /// </summary>
        /// <value>
        /// The denominator.
        /// </value>
        public IExpression Divisor { get; }

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        public ICoefficient? Sequence { get; set; }

        /// <summary>
        /// Gets or sets the exponent.
        /// </summary>
        /// <value>
        /// The exponent.
        /// </value>
        public IExpression? Exponent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show horizontal bar].
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if [show horizontal bar]; otherwise, <see langword="false" />.
        /// </value>
        public bool ShowHorizontalBar { get; set; }

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
        /// Return various sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="dividendSize">Size of the top.</param>
        /// <param name="divisorSize">Size of the bottom.</param>
        /// <param name="barSize">Size of the bar.</param>
        /// <returns></returns>
        private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF dividendSize, out SizeF divisorSize, out SizeF barSize)
        {
            dividendSize = Dividend.Dimensions(graphics, font, scale);
            divisorSize = Divisor.Dimensions(graphics, font, scale);
            var width = Max(dividendSize.Width, divisorSize.Width);
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            var bar = ShowHorizontalBar ? Utilities.MeasureGlyphs(graphics, tempFont, "-", StringFormat.GenericTypographic) : new RectangleF(0f, 0f, width, 0f);
            width += bar.Height * MathConstants.Two;
            barSize = new SizeF(width, bar.Height);
            return new SizeF(width, dividendSize.Height + divisorSize.Height/* + barSize.Height*/);
        }

        /// <summary>
        /// Return the object's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public SizeF Dimensions(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _);

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
            var size = Dimensions(graphics, font, scale, out var dividendSize, out var divisorSize, out var barSize);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.Orange, 1)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size);
                graphics.DrawRectangle(dashedPen, x + ((size.Width - dividendSize.Width) * MathConstants.OneHalf), y, dividendSize);
                graphics.DrawRectangle(dashedPen, x + ((size.Width - divisorSize.Width) * MathConstants.OneHalf), y + dividendSize.Height, divisorSize);
            }

            // Draw the top.
            var top_x = x + ((size.Width - dividendSize.Width) * MathConstants.OneHalf);
            Dividend.Draw(graphics, font, brush, pen, scale, top_x, y, drawBounds);

            // Draw the separator.
            if (ShowHorizontalBar)
            {
                graphics.FillRectangle(brush, x, y + (dividendSize.Height - (barSize.Height * MathConstants.OneAndAHalf)), barSize.Width, barSize.Height);
                //y += barSize.Height;
            }

            // Draw the divisor.
            Divisor.Draw(graphics, font, brush, pen, scale, x + ((size.Width - divisorSize.Width) * MathConstants.OneHalf), y + (size.Height - divisorSize.Height), drawBounds);
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
            Bounds = new RectangleF(location, Dimensions(graphics, font, scale, out var dividendSize, out var divisorSize, out var barSize));
            return Bounds ?? Rectangle.Empty;
        }
    }
}
