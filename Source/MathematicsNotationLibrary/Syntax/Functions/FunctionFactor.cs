// <copyright file="FunctionFactor.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MathematicsNotationLibrary.IExponatable" />
    /// <seealso cref="MathematicsNotationLibrary.INegatable" />
    /// <seealso cref="MathematicsNotationLibrary.IEditable" />
    public class FunctionFactor
        : IExponatable, INegatable, IEditable
    {
        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        [JsonIgnore]
        public IExpression? Parent { get; set; }

        /// <summary>
        /// Gets or sets the exponent.
        /// </summary>
        /// <value>
        /// The exponent.
        /// </value>
        public IExpression? Exponent { get; set; }

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        public INumeric? Sequence { get; set; }

        /// <summary>
        /// Gets or sets the sign of the expression.
        /// </summary>
        /// <value>
        /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
        /// </value>
        public int Sign { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value is either positive or negative.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if [plus or minus]; otherwise, <see langword="false" />.
        /// </value>
        public bool PlusOrMinus { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IEditable" /> is editable.
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
        public PointF? Location { get => Bounds?.Location; set => Bounds = Bounds switch { null when value is PointF p => new RectangleF(p, SizeF.Empty), RectangleF b when value is PointF d => new RectangleF(d, b.Size), _ => null, }; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        [JsonIgnore]
        public SizeF? Size { get => Bounds?.Size; set => Bounds = Bounds switch { null when value is SizeF s => new RectangleF(PointF.Empty, s), RectangleF b when value is SizeF s => new RectangleF(b.Location, s), _ => null, }; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        [JsonIgnore]
        public float? Scale { get; set; }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public SizeF Layout(Graphics graphics, Font font, float scale) => throw new NotImplementedException();

        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, PointF location, float scale, bool drawBounds = false) => throw new NotImplementedException();

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
            Bounds = new RectangleF(location, Layout(graphics, font, scale));
            return Bounds ?? Rectangle.Empty;
        }

        /// <summary>
        /// Expressions of this instance.
        /// </summary>
        /// <returns></returns>
        public HashSet<IExpression> Expressions()
        {
            var set = new HashSet<IExpression>() { this };
            if (Exponent is not null) set.UnionWith(Exponent.Expressions());
            if (Sequence is not null) set.UnionWith(Sequence.Expressions());
            return set;
        }
    }
}
