// <copyright file="LogarithmFactor.cs" company="Shkyrockett" >
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
using System.Collections.Generic;
using System.Drawing;
using System.Text.Json.Serialization;
using static System.Math;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    /// <seealso cref="PrimerLibrary.IEditable" />
    public class LogarithmFactor
        : IFactor, INegatable, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LogarithmFactor" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="argument">The argument.</param>
        /// <param name="base">The base.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public LogarithmFactor(IExpression argument, IExpression @base, bool editable = false)
        {
            Parent = null;
            Argument = argument;
            if (Argument is IExpression a) a.Parent = this;
            Base = @base;
            if (Base is IExpression b) b.Parent = this;
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
        /// Gets the argument.
        /// </summary>
        /// <value>
        /// The argument.
        /// </value>
        public IExpression Argument { get; }

        /// <summary>
        /// Gets the base.
        /// </summary>
        /// <value>
        /// The base.
        /// </value>
        public IExpression Base { get; }

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        public ICoefficient? Sequence { get; set; }

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
        /// Gets or sets a value indicating whether this <see cref="IEditable" /> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }
        #endregion

        /// <summary>
        /// Gets the name of the function.
        /// </summary>
        /// <returns></returns>
        private string GetFunctionName()
        {
            // ToDo: Add ln if Base is the natural log e, or lg if base 10, or omit the base if log base 10.
            return "log";
        }

        /// <summary>
        /// Gets the sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="functionSize">Size of the function.</param>
        /// <param name="baseSize">Size of the base.</param>
        /// <param name="argumentSize">Size of the argument.</param>
        /// <returns></returns>
        private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF functionSize, out SizeF baseSize, out SizeF argumentSize)
        {
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            using var smallFont = new Font(font.FontFamily, font.Size * MathConstants.SequenceScale, font.Style);
            functionSize = graphics.MeasureString(GetFunctionName(), tempFont);
            baseSize = Base?.Dimensions(graphics, font, scale * MathConstants.SequenceScale) ?? graphics.MeasureString(" ", smallFont);
            argumentSize = Argument?.Dimensions(graphics, tempFont, scale) ?? graphics.MeasureString(" ", tempFont);
            return new SizeF(functionSize.Width + baseSize.Width + argumentSize.Width, Max(argumentSize.Height, functionSize.Height) + (baseSize.Height * MathConstants.SequenceOffsetScale));
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public SizeF Dimensions(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _);

        /// <summary>
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float scale, float x, float y, bool drawBounds = false)
        {
            var size = Dimensions(graphics, font, scale, out var functionSize, out var baseSize, out var argumentSize);
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            graphics.DrawString(GetFunctionName(), tempFont, brush, new PointF(x, y));
            x += functionSize.Width;
            Base.Draw(graphics, font, brush, pen, scale * MathConstants.SequenceScale, x, y + (size.Height * MathConstants.SequenceOffsetScale), drawBounds);
            x += baseSize.Width;
            Argument.Draw(graphics, font, brush, pen, scale, x, y, drawBounds);
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
        /// <exception cref="NotImplementedException"></exception>
        public HashSet<IRenderable> Layout(Graphics graphics, Font font, Brush brush, Pen pen, float scale, PointF location, bool drawBorders = false)
        {
            throw new NotImplementedException();
        }
    }
}
