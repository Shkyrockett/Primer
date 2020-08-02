// <copyright file="TermExpression.cs" company="Shkyrockett" >
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
using System.Drawing.Drawing2D;
using System.Linq;
using static System.Math;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class TermExpression
        : IExpression, INegatable, IEditable
    {
        #region Fields
        /// <summary>
        /// The space between the top and bottom items.
        /// </summary>
        private const float Gap = 0;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TermExpression" /> class.
        /// </summary>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="expressions">The expressions.</param>
        public TermExpression(double coefficient, params IVariable[] expressions)
            : this(null, new CoefficientExpression(coefficient), false, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TermExpression"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="expressions">The expressions.</param>
        public TermExpression(IExpression? parent, double coefficient, params IVariable[] expressions)
            : this(parent, new CoefficientExpression(coefficient), false, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TermExpression" /> class.
        /// </summary>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        /// <param name="expressions">The expressions.</param>
        public TermExpression(double coefficient, bool editable = false, params IVariable[] expressions)
            : this(null, new CoefficientExpression(coefficient), editable, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TermExpression"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        /// <param name="expressions">The expressions.</param>
        public TermExpression(IExpression? parent, double coefficient, bool editable = false, params IVariable[] expressions)
            : this(parent, new CoefficientExpression(coefficient), editable, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TermExpression" /> class.
        /// </summary>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="expressions">The expressions.</param>
        public TermExpression(CoefficientExpression coefficient, params IVariable[] expressions)
            : this(null, coefficient, false, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TermExpression"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="expressions">The expressions.</param>
        public TermExpression(IExpression? parent, CoefficientExpression coefficient, params IVariable[] expressions)
            : this(parent, coefficient, false, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TermExpression"/> class.
        /// </summary>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        /// <param name="expressions">The expressions.</param>
        public TermExpression(CoefficientExpression coefficient, bool editable = false, params IVariable[] expressions)
            : this(null, coefficient, editable, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TermExpression" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="coefficient">The coefficient.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        /// <param name="expressions">The expressions.</param>
        public TermExpression(IExpression? parent, CoefficientExpression coefficient, bool editable = false, params IVariable[] expressions)
        {
            Parent = parent;
            Coefficient = coefficient;
            Expressions = new List<IVariable>(expressions);
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
        public CoefficientExpression Coefficient { get; private set; }

        /// <summary>
        /// Gets or sets the expressions.
        /// </summary>
        /// <value>
        /// The expressions.
        /// </value>
        public List<IVariable> Expressions { get; set; }

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
        public bool IsNegative { get { return Coefficient.IsNegative; } set { Coefficient.IsNegative = value; } }

        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        /// <value>
        /// The size of the font.
        /// </value>
        public float FontSize { get; set; } = 20;

        /// <summary>
        /// Gets a value indicating whether this <see cref="CoefficientExpression"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }
        #endregion

        public IExpression Plus(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public IExpression Add(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public IExpression Negate(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public IExpression Subtract(IExpression expression)
        {
            throw new NotImplementedException();
        }

        public IExpression Multiply(IExpression expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Set font sizes for sub-equations.
        /// </summary>
        /// <param name="fontSize"></param>
        public void SetFontSizes(float fontSize)
        {
            FontSize = fontSize;
            foreach (var expression in Expressions)
            {
                expression.SetFontSizes(fontSize);
            }
        }

        /// <summary>
        /// Return the object's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public SizeF GetSize(Graphics graphics, Font font) => GetSizes(graphics, font, out _, out _, out _);

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float x, float y)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            var size = GetSizes(graphics, tempFont, out SizeF coefficientSize, out var operatorSizes, out var nomialSizes);

#if DrawBox
            using var dashedPen = new Pen(Color.Red, 0)
            {
                DashStyle = DashStyle.Dash
            };
            graphics.DrawRectangle(dashedPen, x, y, size.Width, size.Height);
#endif

            using StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            Coefficient.Draw(graphics, tempFont, brush, pen, x, y + size.Height - coefficientSize.Height);
            x += coefficientSize.Width;

            var expression = Expressions?.Count > 0 ? Expressions[0] : null;
            var operatorSize = operatorSizes.Length > 0 ? operatorSizes[0] : graphics.MeasureString("", tempFont);
            var nomialSize = nomialSizes.Length > 0 ? nomialSizes[0] : graphics.MeasureString(" ", tempFont);

            // Draw the left.
            expression?.Draw(graphics, tempFont, brush, pen, x, y + (size.Height - nomialSize.Height) / 2f);
            x += nomialSize.Width;
            for (int i = 1; i < (Expressions?.Count ?? 0); i++)
            {
                expression = Expressions?[i];
                operatorSize = operatorSizes[i];
                nomialSize = nomialSizes[i];

                // Draw the Operator.
                if (expression?.IsNegative ?? false)
                {
                    var operatorRect = new RectangleF(
                        x + Gap,
                        y,
                        operatorSize.Width,
                        size.Height
                        );
                    graphics.DrawString("-", tempFont, brush, operatorRect, stringFormat);
                    x += operatorSize.Width;
                }

                // Draw the rest.
                expression?.Draw(graphics, tempFont, brush, pen, x, y + (size.Height - nomialSize.Height) / 2f);
                x += nomialSize.Width;
            }
        }

        /// <summary>
        /// Return various sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="coefficientSize">Size of the coefficient.</param>
        /// <param name="operatorSizes">The operator sizes.</param>
        /// <param name="nomialSizes">The nomial sizes.</param>
        /// <returns></returns>
        private unsafe SizeF GetSizes(Graphics graphics, Font font, out SizeF coefficientSize, out Span<SizeF> operatorSizes, out Span<SizeF> nomialSizes)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            coefficientSize = Coefficient.GetSize(graphics, tempFont);
            var width = coefficientSize.Width;
            var maxHeight = coefficientSize.Height;
            nomialSizes = new SizeF[Expressions.Count];
            operatorSizes = new SizeF[Expressions.Count];
            var isFirst = true;
            for (int i = 0; i < Expressions.Count; i++)
            {
                var expression = Expressions[i];
                SizeF nomialSize = nomialSizes[i] = expression.GetSize(graphics, tempFont);
                maxHeight = Max(maxHeight, nomialSize.Height);
                var operatorSize = operatorSizes[i] = graphics.MeasureString(isFirst | expression.IsNegative ? "" : "+", tempFont);
                width += nomialSize.Width + (isFirst | expression.IsNegative ? 0 : operatorSize.Width);
                isFirst = false;
            }

            return new SizeF(width + Gap * 2, maxHeight);
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
        public HashSet<IRenderable> Layout(Graphics graphics, Font font, Brush? brush, Pen? pen, PointF location, bool drawBorders = false)
        {
            var size = GetSizes(graphics, font, out SizeF coefficientSize, out var operatorSizes, out var nomialSizes);
            (var x, var y) = (location.X, location.Y);
            var map = new HashSet<IRenderable>();

            if (drawBorders)
            {
                using var dashedPen = new Pen(Color.Red, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                map.Add(new RectangleElement(location, size, null, dashedPen));
            }

            using StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            map.UnionWith(Coefficient.Layout(graphics, font, brush, pen, new PointF(x, y + size.Height - coefficientSize.Height), drawBorders));
            x += coefficientSize.Width;

            var expression = Expressions?.Count > 0 ? Expressions[0] : null;
            var operatorSize = operatorSizes.Length > 0 ? operatorSizes[0] : graphics.MeasureString("", font);
            var nomialSize = nomialSizes.Length > 0 ? nomialSizes[0] : graphics.MeasureString(" ", font);

            // Draw the left.
            map.UnionWith(expression.Layout(graphics, font, brush, pen, new PointF(x, y + (size.Height - nomialSize.Height) / 2f), drawBorders));
            x += nomialSize.Width;
            for (int i = 1; i < (Expressions?.Count ?? 0); i++)
            {
                expression = Expressions?[i];
                operatorSize = operatorSizes[i];
                nomialSize = nomialSizes[i];

                // Draw the Operator.
                if (expression?.IsNegative ?? false)
                {
                    var operatorRect = new RectangleF(
                        x + Gap,
                        y,
                        operatorSize.Width,
                        size.Height
                        );
                    map.Add(new TextElement("-", font, brush, pen, operatorRect, stringFormat));
                    x += operatorSize.Width;
                }

                // Draw the rest.
                map.UnionWith(expression.Layout(graphics, font, brush, pen, new PointF(x, y + (size.Height - nomialSize.Height) / 2f), drawBorders));
                x += nomialSize.Width;
            }

            return map;
        }
    }
}
