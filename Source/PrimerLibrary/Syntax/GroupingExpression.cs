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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

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
        #region Fields
        /// <summary>
        /// The contents.
        /// </summary>
        private readonly IExpression contents;

        /// <summary>
        /// Extra space around the content.
        /// </summary>
        public float MarginX = 5;

        /// <summary>
        /// Extra space around the content.
        /// </summary>
        public float MarginY = 5;

        /// <summary>
        /// Width of bars.
        /// </summary>
        private const float BracketWidth = 8;

        /// <summary>
        /// Width of bars.
        /// </summary>
        private const float BracesWidth = 6;

        /// <summary>
        /// Width of bars.
        /// </summary>
        private const float PointyBracketWidthFraction = 0.1f;

        /// <summary>
        /// Width of bars.
        /// </summary>
        private const float ParenthesisWidthFraction = 0.1f;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupingExpression"/> class.
        /// </summary>
        /// <param name="contents">The contents.</param>
        /// <param name="leftBarStyle">The left bar style.</param>
        /// <param name="rightBarStyle">The right bar style.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public GroupingExpression(IExpression contents, BarStyles leftBarStyle, BarStyles rightBarStyle, bool editable = false)
            : this(null, contents, leftBarStyle, rightBarStyle, editable)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupingExpression"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="contents">The contents.</param>
        /// <param name="leftBarStyle">The left bar style.</param>
        /// <param name="rightBarStyle">The right bar style.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public GroupingExpression(IExpression? parent, IExpression contents, BarStyles leftBarStyle, BarStyles rightBarStyle, bool editable = false)
        {
            Parent = parent;
            this.contents = contents;
            LeftBarStyle = leftBarStyle;
            RightBarStyle = rightBarStyle;
            Editable = editable;
        }
        #endregion

        #region Properties
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
            contents.SetFontSizes(fontSize);
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public SizeF GetSize(Graphics graphics, Font font)
        {
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);

            // Get the content's height.
            SizeF size = contents.GetSize(graphics, tempFont);

            // Add vertical space.
            size.Height += 2 * MarginY;

            // Add room for the bars.
            size.Width +=
                2 * MarginX +
                GetBarWidth(graphics, tempFont, size.Height, LeftBarStyle) +
                GetBarWidth(graphics, tempFont, size.Height, RightBarStyle);

            return size;
        }

        /// <summary>
        /// Return the size of a bar.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="ourHeight">Our height.</param>
        /// <param name="barStyle">The bar style.</param>
        /// <returns></returns>
        private float GetBarWidth(Graphics graphics, Font font, float ourHeight, BarStyles barStyle)
        {
            _ = graphics;
            _ = font;

            return barStyle switch
            {
                BarStyles.Bar => 1,
                BarStyles.Brace => 2 * BracesWidth,
                BarStyles.Bracket => BracketWidth,
                BarStyles.AngleBracket => ourHeight * PointyBracketWidthFraction,
                BarStyles.Parenthesis => ourHeight * ParenthesisWidthFraction,
                BarStyles.None => 0,
                _ => throw new ArgumentOutOfRangeException("bar_style", $"Unknown BarStyles value {LeftBarStyle}"),
            };
        }

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float x, float y)
        {
            // Get our size.
            var size = GetSize(graphics, font);
            using var tempFont = new Font(font.FontFamily, FontSize, font.Style);

#if DrawBox
            using (var dashed_pen = new Pen(Color.Orange, 1))
            {
                dashed_pen.DashStyle = DashStyle.Dash;
                graphics.DrawRectangle(dashed_pen, x, y, size.Width, size.Height);
            }
#endif

            // Draw the bars.
            DrawLeftBar(size, x, y, graphics, tempFont, pen, brush);
            DrawRightBar(size, x, y, graphics, tempFont, pen, brush);

            // Draw the contents.
            var contents_x = x + MarginX + GetBarWidth(graphics, tempFont, size.Height, LeftBarStyle);
            contents.Draw(graphics, tempFont, brush, pen, contents_x, y + MarginY);
        }

        /// <summary>
        /// Draw a left bar.
        /// </summary>
        /// <param name="ourSize">Our size.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="gr">The gr.</param>
        /// <param name="font">The font.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <exception cref="ArgumentOutOfRangeException">LeftBarStyle - Unknown BarStyles value {LeftBarStyle}</exception>
        private void DrawLeftBar(SizeF ourSize, float x, float y, Graphics gr, Font font, Pen pen, Brush brush)
        {
            _ = font;
            x += MarginX;
            switch (LeftBarStyle)
            {
                case BarStyles.Bar:
                    {
                        var bar_width = PointyBracketWidthFraction * ourSize.Height;
                        gr.FillRectangle(brush, x - bar_width * 0.0625f, y, bar_width * 0.0625f * 2, ourSize.Height);
                        gr.DrawRectangle(pen, x - bar_width * 0.0625f, y, bar_width * 0.0625f * 2, ourSize.Height);
                        break;
                    }
                case BarStyles.Bracket:
                    {
                        var bar_width = PointyBracketWidthFraction * ourSize.Height;
                        PointF[] bracket_pts =
                        {
                            new PointF(x + BracketWidth, y),
                            new PointF(x - bar_width * 0.0625f, y),
                            new PointF(x - bar_width * 0.0625f, y + ourSize.Height),
                            new PointF(x + BracketWidth, y + ourSize.Height),
                        };
                        gr.FillRectangle(brush, x - bar_width * 0.0625f, y, bar_width * 0.0625f * 2, ourSize.Height);
                        gr.DrawRectangle(pen, x - bar_width * 0.0625f, y, bar_width * 0.0625f * 2, ourSize.Height);
                        gr.DrawLines(pen, bracket_pts);
                        break;
                    }
                case BarStyles.Brace:
                    PointF[] brace_pts =
                    {
                        new PointF(x + 2 * BracesWidth, y),
                        new PointF(x + BracesWidth, y + 2 * BracesWidth),
                        new PointF(x + BracesWidth, y + ourSize.Height / 2 - 2 * BracesWidth),
                        new PointF(x, y + ourSize.Height / 2),
                        new PointF(x, y + ourSize.Height / 2),
                        new PointF(x + BracesWidth, y + ourSize.Height / 2 + 2 * BracesWidth),
                        new PointF(x + BracesWidth, y + ourSize.Height - 2 * BracesWidth),
                        new PointF(x + 2 * BracesWidth, y + ourSize.Height),
                    };
                    gr.DrawCurve(pen, brace_pts);
                    break;
                case BarStyles.AngleBracket:
                    var pointy_bracket_width = PointyBracketWidthFraction * ourSize.Height;
                    PointF[] point_bracket_pts =
                    {
                        new PointF(x + pointy_bracket_width, y),
                        new PointF(x, y + ourSize.Height / 2),
                        new PointF(x + pointy_bracket_width, y + ourSize.Height),
                    };
                    gr.DrawLines(pen, point_bracket_pts);
                    break;
                case BarStyles.Parenthesis:
                    var parenthesis_width = PointyBracketWidthFraction * ourSize.Height;
                    PointF[] parenthesis_pts =
                    {
                        new PointF(x + parenthesis_width, y),
                        new PointF(x + parenthesis_width / 2  - parenthesis_width * 0.0625f, y + 2 * parenthesis_width),
                        new PointF(x + parenthesis_width / 2  - parenthesis_width * 0.0625f, y + ourSize.Height - 2 * parenthesis_width),
                        new PointF(x + parenthesis_width, y + ourSize.Height),
                        new PointF(x + parenthesis_width / 2 + (parenthesis_width * 0.0625f) * 2, y + ourSize.Height - 2 * parenthesis_width),
                        new PointF(x + parenthesis_width / 2 + (parenthesis_width * 0.0625f) * 2, y + 2 * parenthesis_width),
                        new PointF(x + parenthesis_width, y),
                    };
                    gr.FillClosedCurve(brush, parenthesis_pts);
                    gr.DrawCurve(pen, parenthesis_pts);
                    break;
                case BarStyles.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("LeftBarStyle", $"Unknown BarStyles value {LeftBarStyle}");
            }
        }

        /// <summary>
        /// Draw a right bar.
        /// </summary>
        /// <param name="ourSize">Our size.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="gr">The gr.</param>
        /// <param name="font">The font.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <exception cref="ArgumentOutOfRangeException">RightBarStyle - Unknown BarStyles value {RightBarStyle}</exception>
        private void DrawRightBar(SizeF ourSize, float x, float y, Graphics gr, Font font, Pen pen, Brush brush)
        {
            _ = font;
            x += ourSize.Width - MarginX;
            switch (RightBarStyle)
            {
                case BarStyles.Bar:
                    {
                        var bar_width = PointyBracketWidthFraction * ourSize.Height;
                        gr.FillRectangle(brush, x, y, bar_width * 0.0625f * 2, ourSize.Height);
                        gr.DrawRectangle(pen, x, y, bar_width * 0.0625f * 2, ourSize.Height);
                        break;
                    }
                case BarStyles.Bracket:
                    {
                        var bar_width = PointyBracketWidthFraction * ourSize.Height;
                        PointF[] bracket_pts =
                        {
                            new PointF(x - BracketWidth, y),
                            new PointF(x + bar_width * 0.0625f, y),
                            new PointF(x + bar_width * 0.0625f, y + ourSize.Height),
                            new PointF(x - BracketWidth, y + ourSize.Height),
                        };
                        gr.FillRectangle(brush, x, y, bar_width * 0.0625f * 2, ourSize.Height);
                        gr.DrawRectangle(pen, x, y, bar_width * 0.0625f * 2, ourSize.Height);
                        gr.DrawLines(pen, bracket_pts);
                        break;
                    }
                case BarStyles.Brace:
                    PointF[] brace_pts =
                    {
                        new PointF(x - 2 * BracesWidth, y),
                        new PointF(x - BracesWidth, y + 2 * BracesWidth),
                        new PointF(x - BracesWidth, y + ourSize.Height / 2 - 2 * BracesWidth),
                        new PointF(x, y + ourSize.Height / 2),
                        new PointF(x, y + ourSize.Height / 2),
                        new PointF(x - BracesWidth, y + ourSize.Height / 2 + 2 * BracesWidth),
                        new PointF(x - BracesWidth, y + ourSize.Height - 2 * BracesWidth),
                        new PointF(x - 2 * BracesWidth, y + ourSize.Height),
                    };
                    gr.DrawCurve(pen, brace_pts);
                    break;
                case BarStyles.AngleBracket:
                    var pointy_bracket_width = PointyBracketWidthFraction * ourSize.Height;
                    PointF[] point_bracket_pts =
                    {
                        new PointF(x - pointy_bracket_width, y),
                        new PointF(x, y + ourSize.Height / 2),
                        new PointF(x - pointy_bracket_width, y + ourSize.Height),
                    };
                    gr.DrawLines(pen, point_bracket_pts);
                    break;
                case BarStyles.Parenthesis:
                    var parenthesis_width = PointyBracketWidthFraction * ourSize.Height;
                    PointF[] parenthesis_pts =
                    {
                        new PointF(x - parenthesis_width, y),
                        new PointF(x - parenthesis_width / 2  - parenthesis_width * 0.0625f, y + 2 * parenthesis_width),
                        new PointF(x - parenthesis_width / 2  - parenthesis_width * 0.0625f, y + ourSize.Height - 2 * parenthesis_width),
                        new PointF(x - parenthesis_width, y + ourSize.Height),
                        new PointF(x - parenthesis_width / 2 + (parenthesis_width * 0.0625f) * 2, y + ourSize.Height - 2 * parenthesis_width),
                        new PointF(x - parenthesis_width / 2 + (parenthesis_width * 0.0625f) * 2, y + 2 * parenthesis_width),
                        new PointF(x - parenthesis_width, y),
                    };
                    gr.FillClosedCurve(brush, parenthesis_pts);
                    gr.DrawCurve(pen, parenthesis_pts);
                    break;
                case BarStyles.None:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("RightBarStyle", $"Unknown BarStyles value {RightBarStyle}");
            }
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
            var size = GetSize(graphics, font);
            var map = new HashSet<IRenderable>();

            if (drawBorders)
            {
                using var dashedPen = new Pen(Color.Red, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                map.Add(new RectangleElement(location, size, null, dashedPen));
            }

            // ToDo: Layout here.

            return map;
        }
    }
}
