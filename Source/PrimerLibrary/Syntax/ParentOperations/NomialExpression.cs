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
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using static System.Math;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    public class NomialExpression
        : IExpression, INegatable, IGroupable, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationalOperation" /> class.
        /// </summary>
        /// <param name="expressions">The expressions.</param>
        public NomialExpression(params INegatable[] expressions)
            : this(false, expressions)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelationalOperation" /> class.
        /// </summary>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        /// <param name="expressions">The expressions.</param>
        public NomialExpression(bool editable = false, params INegatable[] expressions)
        {
            Parent = null;
            Terms = new List<INegatable>(expressions);
            for (int i = 0; i < Terms.Count; i++)
            {
                if (Terms[i] is IExpression t) t.Parent = this;
            }
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
        /// Gets or sets the expressions.
        /// </summary>
        /// <value>
        /// The expressions.
        /// </value>
        [JsonInclude, JsonPropertyName("Terms")]
        [JsonConverter(typeof(List<INegatable>))]
        public List<INegatable> Terms { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IGroupable" /> is group.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if group; otherwise, <see langword="false" />.
        /// </value>
        [JsonInclude, JsonPropertyName("Group")]
        public bool Group { get; set; }

        /// <summary>
        /// Gets or sets the bar style.
        /// </summary>
        /// <value>
        /// The bar style.
        /// </value>
        [JsonInclude, JsonPropertyName("GroupingStyle")]
        public BarStyles GroupingStyle { get; set; }

        /// <summary>
        /// Gets or sets the sign of the expression.
        /// </summary>
        /// <value>
        /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
        /// </value>
        [JsonIgnore]
        public int Sign { get { return Terms?[0].Sign ?? 1; } set { if (Terms is not null && Terms[0] is INegatable t) t.Sign = value; } }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CoefficientFactor"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        [JsonInclude, JsonPropertyName("Editable")]
        public bool Editable { get; set; }
        #endregion

        /// <summary>
        /// Return various sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="contentsSize">Size of the contents.</param>
        /// <param name="termsSizes">The nomial sizes.</param>
        /// <param name="leftGroup">The left group.</param>
        /// <param name="leftScale">The left scale.</param>
        /// <param name="rightGroup">The right group.</param>
        /// <param name="rightScale">The right scale.</param>
        /// <returns></returns>
        private unsafe SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF contentsSize, out Span<SizeF> termsSizes, out SizeF leftGroup, out float leftScale, out SizeF rightGroup, out float rightScale)
        {
            var maxHeight = 0f;
            var width = 0f;
            termsSizes = new SizeF[Terms.Count];
            for (var i = 0; i < Terms.Count; i++)
            {
                var nomialSize = termsSizes[i] = Terms[i].Dimensions(graphics, font, scale);
                maxHeight = Max(maxHeight, nomialSize.Height);
                width += nomialSize.Width;
            }

            contentsSize = new SizeF(width, maxHeight);

            if (Group)
            {
                (leftGroup, leftScale) = Utilities.CalculateCharacterSizeForHeight(graphics, font, Utilities.BarStyleStringLeft(GroupingStyle), maxHeight, StringFormat.GenericTypographic);
                width += leftGroup.Width;
                (rightGroup, rightScale) = Utilities.CalculateCharacterSizeForHeight(graphics, font, Utilities.BarStyleStringRight(GroupingStyle), maxHeight, StringFormat.GenericTypographic);
                width += leftGroup.Width;
            }
            else
            {
                leftGroup = rightGroup = new SizeF(0, maxHeight);
                leftScale = rightScale = 1f;
            }

            return new SizeF(width, maxHeight);
        }

        /// <summary>
        /// Return the object's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SizeF Dimensions(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _, out _, out _, out _);

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, float scale, float x, float y, bool drawBounds = false)
        {
            var size = Dimensions(graphics, font, scale, out var contentsSize, out var termsSizes, out var leftGroup, out var leftScale, out var rightGroup, out var rightScale);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.Lime, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size);
                graphics.DrawRectangle(dashedPen, x + leftGroup.Width, y, contentsSize);
            }

            if (Group)
            {
                Utilities.DrawLeftBar(graphics, font, pen, brush, leftScale, x, y, GroupingStyle, drawBounds);
                x += leftGroup.Width;
                Utilities.DrawRightBar(graphics, font, pen, brush, rightScale, x + contentsSize.Width, y, GroupingStyle, drawBounds);
            }

            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            var term = Terms?.Count > 0 ? Terms[0] : null;
            var termSize = termsSizes.Length > 0 ? termsSizes[0] : graphics.MeasureString(" ", tempFont);

            // Draw the left.
            term?.Draw(graphics, font, brush, pen, scale, x, y + ((size.Height - termSize.Height) * 0.5f), drawBounds);
            x += termSize.Width;
            for (int i = 1; i < (Terms?.Count ?? 0); i++)
            {
                term = Terms?[i];
                termSize = termsSizes[i];

                // Draw the rest.
                term?.Draw(graphics, font, brush, pen, scale, x, y + ((size.Height - termSize.Height) * 0.5f), drawBounds);
                x += termSize.Width;
            }
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
        public HashSet<IRenderable> Layout(Graphics graphics, Font font, Brush brush, Pen pen, float scale, PointF location, bool drawBorders = false)
        {
            var size = Dimensions(graphics, font, scale, out var contentsSize, out var nomialSizes, out var leftGroup, out var leftScale, out var rightGroup, out var rightScale);
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
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

            return map;
        }
    }
}
