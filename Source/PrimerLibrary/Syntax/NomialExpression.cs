// <copyright file="NomialExpression.cs" company="Shkyrockett" >
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
    public class NomialExpression
        : IExpression, IGroupable, ILayout, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationalExpression" /> class.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        public NomialExpression(params INegatable[] expressions)
            : this(null, false, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NomialExpression"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="expressions">The expressions.</param>
        public NomialExpression(IExpression? parent, params INegatable[] expressions)
            : this(parent, false, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="NomialExpression"/> class.
        /// </summary>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        /// <param name="expressions">The expressions.</param>
        public NomialExpression(bool editable = false, params INegatable[] expressions)
            : this(null, editable, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelationalExpression" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        /// <param name="expressions">The expressions.</param>
        public NomialExpression(IExpression? parent, bool editable = false, params INegatable[] expressions)
        {
            Parent = parent;
            Terms = new List<INegatable>((expressions?.Length > 0) ? expressions : new INegatable[] { new TextExpression("") });
            Editable = editable;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the expressions.
        /// </summary>
        /// <value>
        /// The expressions.
        /// </value>
        public List<INegatable> Terms { get; set; }

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
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public IExpression? Parent { get; set; }

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

        /// <summary>
        /// Gets the spacing between each term.
        /// </summary>
        /// <value>
        /// The spacing.
        /// </value>
        public static float Spacing { get; set; } = 2;

        /// <summary>
        /// Gets or sets the x margin.
        /// </summary>
        /// <value>
        /// The x margin.
        /// </value>
        public float XMargin { get; set; }

        /// <summary>
        /// Gets or sets the y margin.
        /// </summary>
        /// <value>
        /// The y margin.
        /// </value>
        public float YMargin { get; set; }
        #endregion

        /// <summary>
        /// Set font sizes for sub-equations.
        /// </summary>
        /// <param name="fontSize"></param>
        public void SetFontSizes(float fontSize)
        {
            FontSize = fontSize;
            foreach (var expression in Terms)
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
        public SizeF GetSize(Graphics graphics, Font font) => LayoutSizes(graphics, font, out _, out _, out _, out _, out _);

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
            var size = LayoutSizes(graphics, tempFont, out var contentsSize, out var operatorSizes, out var nomialSizes, out var leftGroup, out var rightGroup);

#if DrawBox
            using var dashedPen = new Pen(Color.Red, 0)
            {
                DashStyle = DashStyle.Dash
            };
            graphics.DrawRectangle(dashedPen, x, y, size.Width, size.Height);
#endif

            //if (Group)
            //{
            //    (SizeF groupSize, Font newFont, string left, string right) = Utilities.CalculateGroupingFont(graphics, font, BarStyles.Parenthesis, size, Spacing, Spacing);
            //}

            using StringFormat stringFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var expression = Terms?.Count > 0 ? Terms[0] : null;
            var operatorSize = operatorSizes.Length > 0 ? operatorSizes[0] : graphics.MeasureString("", tempFont);
            var nomialSize = nomialSizes.Length > 0 ? nomialSizes[0] : graphics.MeasureString(" ", tempFont);

            // Draw the left.
            expression?.Draw(graphics, tempFont, brush, pen, x, y + (size.Height - nomialSize.Height) / 2f);
            x += nomialSize.Width;
            for (int i = 1; i < (Terms?.Count ?? 0); i++)
            {
                expression = Terms?[i];
                operatorSize = operatorSizes[i];
                nomialSize = nomialSizes[i];

                // Draw the Operator.
                if (!(expression?.IsNegative ?? false))
                {
                    var operatorRect = new RectangleF(
                        x + Spacing,
                        y,
                        operatorSize.Width,
                        size.Height
                        );
                    graphics.DrawString("+", tempFont, brush, operatorRect, stringFormat);
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
        /// <param name="contentsSize">Size of the contents.</param>
        /// <param name="operatorSizes">The operator sizes.</param>
        /// <param name="nomialSizes">The nomial sizes.</param>
        /// <param name="leftGroup">The left group.</param>
        /// <param name="rightGroup">The right group.</param>
        /// <returns></returns>
        private unsafe SizeF LayoutSizes(Graphics graphics, Font font, out SizeF contentsSize, out Span<SizeF> operatorSizes, out Span<SizeF> nomialSizes, out SizeF leftGroup, out SizeF rightGroup)
        {
            var maxHeight = 0f;
            var width = 0f;
            nomialSizes = new SizeF[Terms.Count];
            operatorSizes = new SizeF[Terms.Count];
            var isFirst = true;
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);
            for (int i = 0; i < Terms.Count; i++)
            {
                var expression = Terms[i];
                SizeF nomialSize = nomialSizes[i] = expression.GetSize(graphics, tempFont);
                maxHeight = Max(maxHeight, nomialSize.Height);
                var operatorSize = operatorSizes[i] = graphics.MeasureString(isFirst | expression.IsNegative ? "" : "+", tempFont);
                width += nomialSize.Width + (isFirst | expression.IsNegative ? 0 : operatorSize.Width);
                isFirst = false;
            }

            contentsSize = new SizeF(width + Spacing * 2f, maxHeight);

            if (Group)
            {
                SizeF size = Utilities.CalculateGroupingSymbolsWidth(graphics, font, BarStyles.Parenthesis, new SizeF(width, maxHeight), Spacing, Spacing);
                leftGroup = rightGroup = size;
                width += size.Width * 2f;
            }
            else
            {
                leftGroup = rightGroup = new SizeF(0, maxHeight);
            }

            return new SizeF(width + Spacing * 2f, maxHeight);
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
        public HashSet<IRenderable> Layout(Graphics graphics, Font font, Brush brush, Pen pen, PointF location, bool drawBorders = false)
        {
            var size = LayoutSizes(graphics, font, out var contentsSize, out var operatorSizes, out var nomialSizes, out var leftGroup, out var rightGroup);
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

            if (Group)
            {
                (string leftBar, string rightBar) = Utilities.BarStyleStrings(GroupingStyle);
                Font groupingFont = Utilities.CalculateGroupingFont(graphics, font, GroupingStyle, contentsSize, Spacing, Spacing);
                map.Add(new TextElement(leftBar, groupingFont, brush, pen, new RectangleF(new PointF(x, y), leftGroup), stringFormat));
                x += leftGroup.Width;
                map.Add(new TextElement(rightBar, groupingFont, brush, pen, new RectangleF(new PointF(x + contentsSize.Width, y), rightGroup), stringFormat));
            }

            var expression = Terms?.Count > 0 ? Terms[0] : null;
            var operatorSize = operatorSizes.Length > 0 ? operatorSizes[0] : graphics.MeasureString("", font);
            var nomialSize = nomialSizes.Length > 0 ? nomialSizes[0] : graphics.MeasureString(" ", font);

            // Draw the left.
            if (expression is not null) map.UnionWith(expression.Layout(graphics, font, brush, pen, new PointF(x, y + (size.Height - nomialSize.Height) / 2f)));
            x += nomialSize.Width;
            for (int i = 1; i < (Terms?.Count ?? 0); i++)
            {
                expression = Terms?[i];
                operatorSize = operatorSizes[i];
                nomialSize = nomialSizes[i];

                // Draw the Operator.
                if (!(expression?.IsNegative ?? false))
                {
                    var operatorRect = new RectangleF(
                        x + Spacing,
                        y,
                        operatorSize.Width,
                        size.Height
                        );
                    map.Add(new TextElement("+", font, brush, pen, operatorRect, stringFormat));
                    x += operatorSize.Width;
                }

                // Draw the rest.
                if (expression is not null) map.UnionWith(expression.Layout(graphics, font, brush, pen, new PointF(x, y + (size.Height - nomialSize.Height) / 2f)));
                x += nomialSize.Width;
            }

            return map;
        }
    }
}
