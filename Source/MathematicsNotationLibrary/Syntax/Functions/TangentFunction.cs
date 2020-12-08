// <copyright file="TangentFunction.cs" company="Shkyrockett" >
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

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MathematicsNotationLibrary.IExpression" />
    /// <seealso cref="MathematicsNotationLibrary.IFunction" />
    /// <seealso cref="MathematicsNotationLibrary.IFactor" />
    /// <seealso cref="MathematicsNotationLibrary.IGroupable" />
    public class TangentFunction
        : IExpression, IChild, IFunction, IFactor, ISequenceable, IExponatable, IGroupable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TangentFunction"/> class.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="sequence">The sequence.</param>
        /// <param name="exponent">The exponent.</param>
        /// <param name="groupingStyle">The grouping style.</param>
        public TangentFunction(IExpression? argument, INumeric? sequence = null, IExpression? exponent = null, BarStyles groupingStyle = BarStyles.None)
            : this(null, argument, sequence, exponent, groupingStyle)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TangentFunction" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="argument">The argument.</param>
        /// <param name="sequence">The sequence.</param>
        /// <param name="exponent">The exponent.</param>
        /// <param name="groupingStyle">The grouping style.</param>
        public TangentFunction(IExpression? parent, IExpression? argument, INumeric? sequence = null, IExpression? exponent = null, BarStyles groupingStyle = BarStyles.None)
        {
            Parent = parent;
            Argument = argument;
            if (Argument is IChild a) a.Parent = this;
            Sequence = sequence;
            if (Sequence is IChild s) s.Parent = this;
            Exponent = exponent;
            if (Exponent is IChild e) e.Parent = this;
            GroupingStyle = groupingStyle;
        }
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
        /// Gets or sets the argument of the function.
        /// </summary>
        /// <value>
        /// The argument.
        /// </value>
        public IExpression? Argument { get; set; }

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        public INumeric? Sequence { get; set; }

        /// <summary>
        /// Gets or sets the exponent.
        /// </summary>
        /// <value>
        /// The exponent.
        /// </value>
        public IExpression? Exponent { get; set; }

        /// <summary>
        /// Gets or sets the grouping style.
        /// </summary>
        /// <value>
        /// The grouping style.
        /// </value>
        public BarStyles GroupingStyle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IGroupable" /> is group.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if group; otherwise, <see langword="false" />.
        /// </value>
        public bool Group { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="TangentFunction"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }

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
        public PointF? Location { get; set; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public SizeF? Size { get; set; }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        public float? Scale { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public SizeF Layout(Graphics graphics, Font font, float scale) => throw new NotImplementedException();

        /// <summary>
        /// Calculates the bounding box.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale) => throw new NotImplementedException();

        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="drawBorders">if set to <see langword="true" /> [draw borders].</param>
        /// <exception cref="NotImplementedException"></exception>
        /// <exception cref="NotImplementedException"></exception>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, PointF location, float scale, bool drawBorders = false) => throw new NotImplementedException();

        /// <summary>
        /// Expressionses this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public HashSet<IExpression> Expressions() => throw new NotImplementedException();
        #endregion
    }
}
