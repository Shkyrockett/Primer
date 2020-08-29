// <copyright file="LongDivisionFigure.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Drawing;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IFigure" />
    public class LongDivisionFigure
        : IFigure
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LongDivisionFigure"/> class.
        /// </summary>
        public LongDivisionFigure()
        { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public IExpression? Parent { get; set; }

        /// <summary>
        /// Gets the dividend bounds.
        /// </summary>
        /// <value>
        /// The dividend bounds.
        /// </value>
        public SizeF DividendSize { get { return (Parent is LongDivisionExpression p && p.Dividend is IExpression d) ? d?.Bounds?.Size ?? SizeF.Empty : SizeF.Empty; } }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="LongDivisionFigure"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get { return false; } set {; } }

        /// <summary>
        /// Gets or sets the bounds.
        /// </summary>
        /// <value>
        /// The bounds.
        /// </value>
        public RectangleF? Bounds { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        public PointF? Location { get { return Bounds?.Location; } set { if (Bounds is RectangleF b && value is PointF p) Bounds = new RectangleF(p, b.Size); } }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public SizeF? Size { get { return Bounds?.Size; } set { if (Bounds is RectangleF b && value is SizeF s) Bounds = new RectangleF(b.Location, s); } }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        public float? Scale { get; set; }
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
            return SizeF.Empty;
        }

        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="drawBorders">if set to <see langword="true" /> [draw borders].</param>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float scale, float x, float y, bool drawBorders = false)
        {
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
