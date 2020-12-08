// <copyright file="Utilities.cs" company="Shkyrockett" >
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

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class Utilities
    {
        #region Constants
        /// <summary>
        /// The comparison operator dictionary
        /// </summary>
        internal static readonly Dictionary<ComparisonOperators, string> ComparisonOperatorDictionary = new()
        {
            { ComparisonOperators.Equals,               "=" },
            { ComparisonOperators.NotEquals,            "≠" },
            { ComparisonOperators.LessThan,             "<" },
            { ComparisonOperators.GreaterThan,          ">" },
            { ComparisonOperators.LessThanOrEquals,     "≤" },
            { ComparisonOperators.GreaterThanOrEquals,  "≥" },
            { ComparisonOperators.Approximate,          "≈" },
        };

        /// <summary>
        /// The italic letters
        /// </summary>
        internal static readonly Dictionary<char, string> ItalicLetterDictionary = new()
        {
            { 'a', "𝑎" },
            { 'b', "𝑏" },
            { 'c', "𝑐" },
            { 'd', "𝑑" },
            { 'e', "𝑒" },
            { 'f', "𝑓" },
            { 'g', "𝑔" },
            { 'h', "𝘩" },
            { 'i', "𝑖" },
            { 'j', "𝑗" },
            { 'k', "𝑘" },
            { 'l', "𝑙" },
            { 'm', "𝑚" },
            { 'n', "𝑛" },
            { 'o', "𝑜" },
            { 'p', "𝑝" },
            { 'q', "𝑞" },
            { 'r', "𝑟" },
            { 's', "𝑠" },
            { 't', "𝑡" },
            { 'u', "𝑢" },
            { 'v', "𝑣" },
            { 'w', "𝑤" },
            { 'x', "𝑥" },
            { 'y', "𝑦" },
            { 'z', "𝑧" },
            { 'A', "𝐴" },
            { 'B', "𝐵" },
            { 'C', "𝐶" },
            { 'D', "𝐷" },
            { 'E', "𝐸" },
            { 'F', "𝐹" },
            { 'G', "𝐺" },
            { 'H', "𝐻" },
            { 'I', "𝐼" },
            { 'J', "𝐽" },
            { 'K', "𝐾" },
            { 'L', "𝐿" },
            { 'M', "𝑀" },
            { 'N', "𝑁" },
            { 'O', "𝑂" },
            { 'P', "𝑃" },
            { 'Q', "𝑄" },
            { 'R', "𝑅" },
            { 'S', "𝑆" },
            { 'T', "𝑇" },
            { 'U', "𝑈" },
            { 'V', "𝑉" },
            { 'W', "𝑊" },
            { 'X', "𝑋" },
            { 'Y', "𝑌" },
            { 'Z', "𝑍" },
        };

        /// <summary>
        /// The right bar style dictionary
        /// </summary>
        internal static readonly Dictionary<BarStyles, string> LeftBarStyleDictionary = new()
        {
            { BarStyles.Bar, "|" },
            { BarStyles.Bracket, "[" },
            { BarStyles.Brace, "{" },
            { BarStyles.AngleBracket, "<" },
            { BarStyles.Parenthesis, "(" },
        };

        /// <summary>
        /// The left bar style dictionary
        /// </summary>
        internal static readonly Dictionary<BarStyles, string> RightBarStyleDictionary = new()
        {
            { BarStyles.Bar, "|" },
            { BarStyles.Bracket, "]" },
            { BarStyles.Brace, "}" },
            { BarStyles.AngleBracket, ">" },
            { BarStyles.Parenthesis, ")" },
        };

        /// <summary>
        /// The superscript numbers
        /// </summary>
        internal static readonly Dictionary<char, char> SuperscriptNumbers = new()
        {
            { '0', '⁰' },
            { '1', '¹' },
            { '2', '²' },
            { '3', '³' },
            { '4', '⁴' },
            { '5', '⁵' },
            { '6', '⁶' },
            { '7', '⁷' },
            { '8', '⁸' },
            { '9', '⁹' },
            { '+', '⁺' },
            { '-', '⁻' },
            { '=', '⁼' },
            { '(', '⁽' },
            { ')', '⁾' },
        };

        /// <summary>
        /// The subscript numbers
        /// </summary>
        internal static readonly Dictionary<char, char> SubscriptNumbers = new()
        {
            { '0', '₀' },
            { '1', '₁' },
            { '2', '₂' },
            { '3', '₃' },
            { '4', '₄' },
            { '5', '₅' },
            { '6', '₆' },
            { '7', '₇' },
            { '8', '₈' },
            { '9', '₉' },
            { '+', '₊' },
            { '-', '₋' },
            { '=', '₌' },
            { '(', '₍' },
            { ')', '₎' },
        };
        #endregion

        #region Graphics Methods
        /// <summary>
        /// Measures the glyph.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="text">The text.</param>
        /// <param name="stringFormat">The string format.</param>
        /// <returns></returns>
        public static RectangleF MeasureGlyphs(this Graphics graphics, Font font, string text, StringFormat? stringFormat = null)
        {
            using var textPath = new GraphicsPath();
            textPath.AddString(text, font.FontFamily, (int)font.Style, graphics.DpiY * font.Size / 72f, Point.Empty, stringFormat);
            return textPath.GetBounds();
        }

        /// <summary>
        /// Draws the radical.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="location">The location.</param>
        /// <param name="radicandSize">Size of the radicand.</param>
        /// <param name="radicalSize">Size of the radical.</param>
        /// <param name="radicalFullSize">Full size of the radical.</param>
        /// <param name="radicalScale">The radical scale.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        public static void DrawRadical(this Graphics graphics, Font font, Pen pen, Brush brush, PointF location, SizeF radicandSize, SizeF radicalSize, SizeF radicalFullSize, float radicalScale, bool drawBounds = false)
        {
            _ = pen;
            var diff = radicalFullSize.Height - radicalSize.Height;
            var offsetRect = new RectangleF(location.X + radicalSize.Width, location.Y - (diff * 0.5f), diff, diff * 1.5f);
            location.Y += diff;

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.DodgerBlue, 1)
                {
                    DashStyle = DashStyle.Dash
                };
                //graphics.DrawRectangle(dashedPen, x, y, radicalFullSize);
                graphics.DrawRectangle(dashedPen, location.X, location.Y, radicalSize.Width, radicalSize.Height);
                graphics.DrawRectangle(dashedPen, offsetRect);
            }

            using var radicalFont = new Font(font.FontFamily, font.Size * radicalScale, font.Style);
            using var radicalPath = new GraphicsPath();

            //graphics.DrawString("√", radicalFont, brush, new PointF(x, y + ((radicandSize.Height - radicalSize.Height) * 0.5f)), StringFormat.GenericTypographic);
            radicalPath.AddString("√", radicalFont.FontFamily, (int)radicalFont.Style, graphics.ConvertGraphicsUnits(radicalFont.Size, GraphicsUnit.Point, GraphicsUnit.Pixel), location, StringFormat.GenericTypographic);
            using var stretchedRadicalPath = UpdateGraphicsPath(radicalPath, offsetRect, new PointF(radicandSize.Width, 0));

            //graphics.DrawPath(pen, stretchedRadicalPath);
            graphics.FillPath(brush, stretchedRadicalPath);
        }

        /// <summary>
        /// Draw a left bar.
        /// </summary>
        /// <param name="graphics">The gr.</param>
        /// <param name="font">The font.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <param name="barStyle">The bar style.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        /// <exception cref="ArgumentOutOfRangeException">LeftBarStyle - Unknown BarStyles value {LeftBarStyle}</exception>
        public static void DrawLeftBar(this Graphics graphics, Font font, Pen pen, Brush brush, float scale, PointF location, BarStyles barStyle, bool drawBounds = false)
        {
            _ = pen;
            var character = BarStyleStringLeft(barStyle);
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            if (drawBounds)
            {
                var size = graphics.MeasureString(character, tempFont, PointF.Empty, StringFormat.GenericTypographic);
                using var dashedPen = new Pen(Color.Magenta, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, location.X, location.Y, size.Width, size.Height);
            }

            graphics.DrawString(character, tempFont, brush, location, StringFormat.GenericTypographic);
        }

        /// <summary>
        /// Draw a right bar.
        /// </summary>
        /// <param name="graphics">The gr.</param>
        /// <param name="font">The font.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <param name="barStyle">The bar style.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        /// <exception cref="ArgumentOutOfRangeException">RightBarStyle - Unknown BarStyles value {RightBarStyle}</exception>
        public static void DrawRightBar(this Graphics graphics, Font font, Pen pen, Brush brush, float scale, PointF location, BarStyles barStyle, bool drawBounds = false)
        {
            _ = pen;
            var character = BarStyleStringRight(barStyle);
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            if (drawBounds)
            {
                var size = graphics.MeasureString(character, tempFont, PointF.Empty, StringFormat.GenericTypographic);
                using var dashedPen = new Pen(Color.Magenta, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, location, size);
            }

            graphics.DrawString(character, tempFont, brush, location, StringFormat.GenericTypographic);
        }
        #endregion

        /// <summary>
        /// Gets the operator string.
        /// </summary>
        /// <param name="operator">The op.</param>
        /// <returns>
        /// The operator string.
        /// </returns>
        public static string GetString(this ComparisonOperators @operator) => ComparisonOperatorDictionary.ContainsKey(@operator) ? ComparisonOperatorDictionary[@operator] : string.Empty;

        /// <summary>
        /// Italicizes the specified character.
        /// </summary>
        /// <param name="character">The character.</param>
        /// <returns></returns>
        public static string Italicize(this char character) => ItalicLetterDictionary.ContainsKey(character) ? ItalicLetterDictionary[character] : character.ToString();

        /// <summary>
        /// Italicizes the specified character.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static string Italicize(this string text)
        {
            var result = text;
            for (var i = 0; i < text.Length; i++)
            {
                var letter = text[i];
                if (ItalicLetterDictionary.ContainsKey(letter))
                {
                    result = result.Replace(letter.ToString(), ItalicLetterDictionary[letter]);
                }
            }

            return result;
        }

        /// <summary>
        /// Superscripts the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static string SuperscriptNumber(this string number)
        {
            var result = number;
            for (var i = 0; i < number.Length; i++)
            {
                var letter = number[i];
                if (SuperscriptNumbers.ContainsKey(letter))
                {
                    result = result.Replace(letter, SuperscriptNumbers[letter]);
                }
            }

            return result;
        }

        /// <summary>
        /// Subscripts the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public static string SubscriptNumber(this string number)
        {
            var result = number;
            for (var i = 0; i < number.Length; i++)
            {
                var letter = number[i];
                if (SubscriptNumbers.ContainsKey(letter))
                {
                    result = result.Replace(letter, SubscriptNumbers[letter]);
                }
            }

            return result;
        }

        /// <summary>
        /// Bars the style string.
        /// </summary>
        /// <param name="barStyles">The bar styles.</param>
        /// <returns></returns>
        public static string BarStyleStringLeft(BarStyles barStyles) => LeftBarStyleDictionary.ContainsKey(barStyles) ? LeftBarStyleDictionary[barStyles] : string.Empty;

        /// <summary>
        /// Bars the style string.
        /// </summary>
        /// <param name="barStyles">The bar styles.</param>
        /// <returns></returns>
        public static string BarStyleStringRight(BarStyles barStyles) => RightBarStyleDictionary.ContainsKey(barStyles) ? RightBarStyleDictionary[barStyles] : string.Empty;

        /// <summary>
        /// Calculates the size and font of the character size for a height.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="character">The character.</param>
        /// <param name="height">The height.</param>
        /// <param name="stringFormat">The string format.</param>
        /// <returns></returns>
        public static (SizeF size, float scale) CalculateCharacterSizeForHeight(Graphics graphics, Font font, string character, float height, StringFormat? stringFormat = null)
        {
            if (string.IsNullOrEmpty(character)) return (new SizeF(0f, height), 1f);

            var realSize = graphics.MeasureString(character, font, PointF.Empty, stringFormat);
            var heightScaleRatio = height / realSize.Height;
            var scaleFontSize = font.Size * heightScaleRatio;
            using var newFont = new Font(font.FontFamily, scaleFontSize, font.Style/*, GraphicsUnit.Pixel*/);
            realSize = graphics.MeasureString(character, newFont, PointF.Empty, stringFormat);
            return (realSize, heightScaleRatio);
        }

        /// <summary>
        /// Fits the size within.
        /// </summary>
        /// <param name="inner">The inner.</param>
        /// <param name="outer">The outer.</param>
        /// <returns></returns>
        public static float FitSizeWithin(SizeF inner, SizeF outer)
        {
            var innerAspectRatio = inner.Width / inner.Height;
            var outerAspectRatio = outer.Width / outer.Height;
            return (innerAspectRatio >= outerAspectRatio) ? (outer.Width / inner.Width) : (outer.Height / inner.Height);
        }

        /// <summary>
        /// Convert from one type of unit to another.
        /// http://csharphelper.com/blog/2014/08/get-font-metrics-in-c/
        /// https://github.com/tracyacai/sharpmap/blob/master/SharpMap/Rendering/Symbolizer/Utility.cs
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="value">The value.</param>
        /// <param name="fromUnit">From unit.</param>
        /// <param name="toUnit">To unit.</param>
        /// <returns></returns>
        /// <exception cref="Exception">
        /// Unknown input unit {fromUnit} in FontInfo.ConvertUnits
        /// or
        /// Unknown output unit {toUnit} in FontInfo.ConvertUnits
        /// </exception>
        public static float ConvertGraphicsUnits(this Graphics graphics, float value, GraphicsUnit fromUnit, GraphicsUnit toUnit)
        {
            if (fromUnit == toUnit) return value;

            // Convert to pixels. 
            switch (fromUnit)
            {
                case GraphicsUnit.World:
                    value *= graphics.DpiY / graphics.PageScale;
                    break;
                case GraphicsUnit.Display:
                    value *= graphics.DpiY / (graphics.DpiY < 100f ? 72f : 100f);
                    break;
                case GraphicsUnit.Pixel:
                    // Do nothing.
                    break;
                case GraphicsUnit.Point:
                    value *= graphics.DpiY / 72f;
                    break;
                case GraphicsUnit.Inch:
                    value *= graphics.DpiY;
                    break;
                case GraphicsUnit.Document:
                    value *= graphics.DpiY / 300f;
                    break;
                case GraphicsUnit.Millimeter:
                    value *= graphics.DpiY / 25.4F;
                    break;
                default:
                    throw new Exception($"Unknown input unit {fromUnit} in FontInfo.ConvertUnits");
            }

            // Convert from pixels to the new units. 
            switch (toUnit)
            {
                case GraphicsUnit.World:
                    value /= graphics.DpiY / graphics.PageScale;
                    break;
                case GraphicsUnit.Display:
                    value /= graphics.DpiY / (graphics.DpiY < 100f ? 72f : 100f);
                    break;
                case GraphicsUnit.Pixel:
                    // Do nothing.
                    break;
                case GraphicsUnit.Point:
                    value /= graphics.DpiY / 72f;
                    break;
                case GraphicsUnit.Inch:
                    value /= graphics.DpiY;
                    break;
                case GraphicsUnit.Document:
                    value /= graphics.DpiY / 300f;
                    break;
                case GraphicsUnit.Millimeter:
                    value /= graphics.DpiY / 25.4F;
                    break;
                default:
                    throw new Exception($"Unknown output unit {toUnit} in FontInfo.ConvertUnits");
            }

            return value;
        }

        /// <summary>
        /// Updates the graphics path. https://stackoverflow.com/a/2843204
        /// </summary>
        /// <param name="graphicPath">The g p.</param>
        /// <param name="rectangle">The r f.</param>
        /// <param name="delta">The delta.</param>
        /// <returns></returns>
        public static GraphicsPath UpdateGraphicsPath(GraphicsPath graphicPath, RectangleF rectangle, PointF delta)
        {
            // Find the points in gP that are inside rF and move them by delta.
            var updatePoints = graphicPath?.PathData?.Points ?? Array.Empty<PointF>();
            var updateTypes = graphicPath?.PathData?.Types ?? Array.Empty<byte>();
            for (var i = 0; i < graphicPath?.PointCount; i++)
            {
                if (rectangle.Contains(updatePoints[i]))
                {
                    updatePoints[i].X += delta.X;
                    updatePoints[i].Y += delta.Y;
                }
            }

            return new GraphicsPath(updatePoints, updateTypes);
        }
    }
}
