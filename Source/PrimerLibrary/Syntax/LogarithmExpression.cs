// <copyright file="LogarithmExpression.cs" company="Shkyrockett" >
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    /// <seealso cref="PrimerLibrary.IEditable" />
    public class LogarithmExpression
        : IExpression, INegatable, IEditable
    {
        #region Fields
        /// <summary>
        /// The offset
        /// </summary>
        public float Offset = 0.5f;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="LogarithmExpression" /> class.
        /// </summary>
        /// <param name="argument">The argument.</param>
        /// <param name="base">The base.</param>
        /// <param name="exponent">The exponent.</param>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public LogarithmExpression(IExpression argument, IExpression @base, /*IExpression? exponent = null,*/ CoefficientExpression? coefficient = null, bool editable = false)
            : this(null, argument, @base, /*exponent,*/ coefficient, editable)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogarithmExpression" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="argument">The argument.</param>
        /// <param name="base">The base.</param>
        /// <param name="exponent">The exponent.</param>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public LogarithmExpression(IExpression? parent, IExpression argument, IExpression @base, /*IExpression? exponent = null, */CoefficientExpression? coefficient = null, bool editable = false)
        {
            Coefficient = coefficient ?? new CoefficientExpression(1);
            Argument = argument;
            Base = @base;
            //Exponent = exponent;
            Parent = parent;
            Editable = editable;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the coefficient.
        /// </summary>
        /// <value>
        /// The coefficient.
        /// </value>
        public IExpression Coefficient { get; }

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

        ///// <summary>
        ///// Gets the exponent.
        ///// </summary>
        ///// <value>
        ///// The exponent.
        ///// </value>
        //public IExpression? Exponent { get; }

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
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
        /// Gets or sets the font size1.
        /// </summary>
        /// <value>
        /// The font size1.
        /// </value>
        public float FontSize { get; set; } = 20;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IEditable" /> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }
        #endregion

        public IExpression Add(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public IExpression Multiply(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public IExpression Negate(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public IExpression Plus(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public IExpression Subtract(IExpression expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sets the font sizes.
        /// </summary>
        /// <param name="fontSize">Size of the font.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void SetFontSizes(float fontSize)
        {
            FontSize = fontSize;
            Coefficient.SetFontSizes(fontSize);
            Argument.SetFontSizes(fontSize);
            Base.SetFontSizes(fontSize * 0.75f);
        }

        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public SizeF GetSize(Graphics graphics, Font font) => GetSizes(graphics, font, Offset, out _, out _, out _, out _);

        /// <summary>
        /// Gets the sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="coefficientSize">Size of the coefficient.</param>
        /// <param name="functionSize"></param>
        /// <param name="baseSize">Size of the base.</param>
        /// <returns></returns>
        /// <param name="argumentSize">Size of the argument.</param>
        private SizeF GetSizes(Graphics graphics, Font font, float offset, out SizeF coefficientSize, out SizeF functionSize, out SizeF baseSize, out SizeF argumentSize)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            using var smallFont = new Font(font.FontFamily, FontSize * offset, font.Style);
            coefficientSize = Coefficient?.GetSize(graphics, tempFont) ?? graphics.MeasureString(" ", tempFont);
            functionSize = graphics.MeasureString(GetFunctionName(), tempFont);
            baseSize = Base?.GetSize(graphics, smallFont) ?? graphics.MeasureString(" ", smallFont);
            argumentSize = Argument?.GetSize(graphics, tempFont) ?? graphics.MeasureString(" ", tempFont);
            return new SizeF(coefficientSize.Width + functionSize.Width + baseSize.Width + argumentSize.Width, Max(Max(coefficientSize.Height, argumentSize.Height), functionSize.Height) + baseSize.Height * offset);
        }

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
        /// Draws the specified graphics.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float x, float y)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            using var smallFont = new Font(font.FontFamily, FontSize * Offset, font.Style);
            var size = GetSizes(graphics, tempFont, Offset, out var coefficientSize, out var functionSize, out var baseSize, out var argumentSize);
            Coefficient.Draw(graphics, tempFont, brush, pen, x, y);
            x += coefficientSize.Width;
            graphics.DrawString(GetFunctionName(), tempFont, brush, new PointF(x, y));
            x += functionSize.Width;
            Base.Draw(graphics, tempFont, brush, pen, x, y + size.Height * Offset);
            x += baseSize.Width;
            Argument.Draw(graphics, tempFont, brush, pen, x, y);
        }

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="location">The location.</param>
        /// <param name="drawBorders">if set to <see langword="true" /> [draw borders].</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public HashSet<IRenderable> Layout(Graphics graphics, Font font, Brush brush, Pen pen, PointF location, bool drawBorders = false)
        {
            throw new NotImplementedException();
        }
    }
}
