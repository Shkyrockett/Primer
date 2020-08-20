// <copyright file="RootFactor.cs" company="Shkyrockett" >
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
using System.Text.Json.Serialization;

namespace PrimerLibrary
{
    /// <summary>
    /// The root equation class.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    public class RootFactor
        : IExponentableFactor, INegatable, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RootFactor" /> class.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="radicand">The radicand.</param>
        /// <param name="sequence">The sequence.</param>
        /// <param name="exponent">The exponent.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public RootFactor(ICoefficient index, IExpression radicand, ICoefficient? sequence = null, IExpression? exponent = null, bool editable = false)
        {
            Parent = null;
            Index = index;
            if (Index is IExpression i) i.Parent = this;
            Radicand = radicand;
            if (Radicand is IExpression r) r.Parent = this;
            Sequence = sequence;
            if (Radicand is ICoefficient s) s.Parent = this;
            Exponent = exponent;
            if (Radicand is ICoefficient e) e.Parent = this;
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
        /// Gets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public ICoefficient? Index { get; }

        /// <summary>
        /// Gets the radicand.
        /// </summary>
        /// <value>
        /// The radicand.
        /// </value>
        public IExpression? Radicand { get; }

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        /// <value>
        /// The sequence.
        /// </value>
        public ICoefficient? Sequence { get; set; }

        /// <summary>
        /// Gets or sets the exponent.
        /// </summary>
        /// <value>
        /// The exponent.
        /// </value>
        public IExpression? Exponent { get; set; }

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
        /// Gets a value indicating whether this <see cref="CoefficientFactor"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }
        #endregion

        /// <summary>
        /// Calculate sizes.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="indexSize">Size of the index.</param>
        /// <param name="radicandSize">Size of the radicand.</param>
        /// <param name="radicalSize">Size of the radical.</param>
        /// <param name="radicalFullSize">Full size of the radical.</param>
        /// <param name="radicalScale">The radical scale.</param>
        /// <param name="barWidth">Width of the bar.</param>
        /// <param name="sequenceSize">Size of the sequence.</param>
        /// <param name="exponentSize">Size of the exponent.</param>
        /// <returns></returns>
        private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF indexSize, out SizeF radicandSize, out SizeF radicalSize, out SizeF radicalFullSize, out float radicalScale, out float barWidth, out SizeF sequenceSize, out SizeF exponentSize)
        {
            const string Character = "√";
            (var width, var height) = (0f, 0f);

            using var indexFont = new Font(font.FontFamily, font.Size * scale * MathConstants.IndexScale, font.Style);
            indexSize = Index?.Dimensions(graphics, font, scale * MathConstants.IndexScale) ?? graphics.MeasureString(" ", indexFont, PointF.Empty, StringFormat.GenericTypographic);

            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            radicandSize = Radicand?.Dimensions(graphics, font, scale) ?? graphics.MeasureString(" ", tempFont, PointF.Empty, StringFormat.GenericTypographic);
            width += radicandSize.Width;
            height += radicandSize.Height;

            (radicalSize, radicalScale) = Utilities.CalculateCharacterSizeForHeight(graphics, font, Character, height, StringFormat.GenericTypographic);
            using var radicalFont = new Font(font.FontFamily, font.Size * radicalScale, font.Style);
            radicalFullSize = graphics.MeasureString(Character, radicalFont, PointF.Empty, StringFormat.GenericDefault);
            width += radicalSize.Width;
            height = Math.Max(height, radicalFullSize.Height);

            barWidth = Utilities.MeasureGlyphs(graphics, tempFont, "-", StringFormat.GenericTypographic).Height;
            width += barWidth;

            using var sequenceFont = new Font(font.FontFamily, font.Size * scale * MathConstants.SequenceScale, font.Style);
            sequenceSize = Sequence?.Dimensions(graphics, font, scale) ?? new SizeF(0f, graphics.MeasureString(" ", sequenceFont, Point.Empty, StringFormat.GenericTypographic).Height);

            using var exponentFont = new Font(font.FontFamily, font.Size * scale * MathConstants.ExponentScale, font.Style);
            exponentSize = Exponent?.Dimensions(graphics, font, scale) ?? new SizeF(0f, graphics.MeasureString(" ", exponentFont, Point.Empty, StringFormat.GenericTypographic).Height);

            width += Math.Max(sequenceSize.Width, exponentSize.Width);
            height += ((Sequence is null) ? 0f : sequenceSize.Height * MathConstants.SequenceOffsetScale) + ((Exponent is null) ? 0f : exponentSize.Height * MathConstants.ExponentOffsetScale);

            return new SizeF(width, height);
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public SizeF Dimensions(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _, out _, out _, out _, out _, out _);

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
            var size = Dimensions(graphics, font, scale, out var indexSize, out var radicandSize, out SizeF radicalSize, out SizeF radicalFullSize, out var radicalScale, out var barWidth, out var sequenceSize, out var exponentSize);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.Brown, 1)
                {
                    DashStyle = DashStyle.Dash
                };
                //graphics.DrawRectangle(dashedPen, x, y, indexSize);
                graphics.DrawRectangle(dashedPen, x, y, size);
            }

            if (sequenceSize.Width > 0)
            {
                Sequence?.Draw(graphics, font, brush, pen, scale * MathConstants.SequenceScale, x + radicalSize.Width + radicandSize.Width + barWidth, y + (size.Height - sequenceSize.Height + (sequenceSize.Height * MathConstants.SequenceOffsetScale)), drawBounds);
            }

            if (exponentSize.Width > 0)
            {
                Exponent?.Draw(graphics, font, brush, pen, scale * MathConstants.ExponentScale, x + radicalSize.Width + radicandSize.Width + barWidth, y, drawBounds);
                y += exponentSize.Height * MathConstants.ExponentOffsetScale;
            }

            graphics.DrawRadical(font, pen, brush, x, y, radicandSize, radicalSize, radicalFullSize, radicalScale, drawBounds);
            y += radicalFullSize.Height - radicalSize.Height;

            if (!(Index is ICoefficient i && i.Value == MathConstants.Two)) Index?.Draw(graphics, font, brush, pen, scale * MathConstants.IndexScale, x, y, drawBounds);
            x += radicalSize.Width;

            Radicand?.Draw(graphics, font, brush, pen, scale, x, y + ((radicandSize.Height - radicalSize.Height) * MathConstants.OneHalf), drawBounds);
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
            var size = Dimensions(graphics, font, scale, out var indexSize, out var radicandSize, out SizeF radicalSize, out SizeF radicalFullSize, out var radicalScale, out var barWidth, out var sequenceSize, out var exponentSize);
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
