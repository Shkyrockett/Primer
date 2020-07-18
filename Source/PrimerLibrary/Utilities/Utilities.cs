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

using System.Collections.Generic;
using System.Drawing;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// The comparison operator dictionary
        /// </summary>
        public static Dictionary<ComparisonOperators, string> ComparisonOperatorDictionary = new Dictionary<ComparisonOperators, string>
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
        public static Dictionary<char, string> ItalicLetterDictionary = new Dictionary<char, string>
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
        /// Finds the font.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="text">The text.</param>
        /// <param name="limits">The limits.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public static Font FindFont(this Graphics graphics, string text, SizeF limits, Font font)
        {
            var RealSize = graphics.MeasureString(text, font);
            var HeightScaleRatio = limits.Height / RealSize.Height;
            var WidthScaleRatio = limits.Width / RealSize.Width;
            var ScaleRatio = (HeightScaleRatio < WidthScaleRatio) ? HeightScaleRatio : WidthScaleRatio;
            var ScaleFontSize = font.Size * ScaleRatio;
            return new Font(font.FontFamily, ScaleFontSize, font.Style/*, GraphicsUnit.Pixel*/);
        }

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
    }
}
