﻿// <copyright file="VariableFactor.cs" company="Shkyrockett" >
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.Json.Serialization;

namespace PrimerLibrary
{
    /// <summary>
    /// Draw some text.
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    /// <seealso cref="PrimerLibrary.INegatable" />
    /// <seealso cref="PrimerLibrary.IVariable" />
    public class VariableFactor
        : IExponentableFactor, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableFactor" /> class.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="sequence">The sequence.</param>
        /// <param name="exponent">The exponent.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public VariableFactor(char text, ICoefficient? sequence = null, IExpression? exponent = null, bool editable = false)
        {
            Parent = null;
            Text = text.Italicize();
            Sequence = sequence;
            if (Sequence is IExpression s) s.Parent = this;
            Exponent = exponent;
            if (Exponent is IExpression e) e.Parent = this;
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
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="CoefficientFactor"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        public bool Editable { get; set; }

        /// <summary>
        /// Gets the bounds.
        /// </summary>
        /// <value>
        /// The bounds.
        /// </value>
        [JsonIgnore]
        public RectangleF? Bounds { get; set; }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>
        /// The location.
        /// </value>
        [JsonIgnore]
        public PointF? Location { get { return Bounds?.Location; } set { if (Bounds is RectangleF b && value is PointF p) Bounds = new RectangleF(p, b.Size); } }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        [JsonIgnore]
        public SizeF? Size { get { return Bounds?.Size; } set { if (Bounds is RectangleF b && value is SizeF s) Bounds = new RectangleF(b.Location, s); } }

        /// <summary>
        /// Gets or sets the scale.
        /// </summary>
        /// <value>
        /// The scale.
        /// </value>
        [JsonIgnore]
        public float? Scale { get; set; }
        #endregion

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="variableSize">Size of the variable.</param>
        /// <param name="sequenceSize">Size of the sequence.</param>
        /// <param name="exponentSize">Size of the exponent.</param>
        /// <returns></returns>
        private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF variableSize, out SizeF sequenceSize, out SizeF exponentSize)
        {
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            var emHeightUnit = graphics.ConvertGraphicsUnits(tempFont.Size, tempFont.Unit, GraphicsUnit.Pixel);
            var designToUnit = emHeightUnit / tempFont.FontFamily.GetEmHeight(tempFont.Style);
            //var ascent = designToUnit * tempFont.FontFamily.GetCellAscent(tempFont.Style);
            //var descent = designToUnit * tempFont.FontFamily.GetCellDescent(tempFont.Style);
            var lineSpacing = designToUnit * tempFont.FontFamily.GetLineSpacing(tempFont.Style);

            variableSize = graphics.MeasureString(string.IsNullOrEmpty(Text) ? " " : Text, tempFont, Point.Empty, StringFormat.GenericTypographic);
            if (string.IsNullOrEmpty(Text))
            {
                variableSize = new SizeF(0f, lineSpacing);
            }
            else
            {
                variableSize = graphics.MeasureString(Text, tempFont, Point.Empty, StringFormat.GenericTypographic);
                variableSize.Height = lineSpacing;
            }

            using var sequenceFont = new Font(font.FontFamily, font.Size * scale * MathConstants.SequenceScale, font.Style);
            sequenceSize = Sequence?.Dimensions(graphics, font, scale) ?? new SizeF(0f, graphics.MeasureString(" ", sequenceFont, Point.Empty, StringFormat.GenericTypographic).Height);

            using var exponentFont = new Font(font.FontFamily, font.Size * scale * MathConstants.ExponentScale, font.Style);
            exponentSize = Exponent?.Dimensions(graphics, font, scale) ?? new SizeF(0f, graphics.MeasureString(" ", exponentFont, Point.Empty, StringFormat.GenericTypographic).Height);

            return new SizeF(variableSize.Width + Math.Max(sequenceSize.Width, exponentSize.Width), variableSize.Height + ((sequenceSize.Width == 0) ? 0f : sequenceSize.Height * MathConstants.SequenceOffsetScale) + ((exponentSize.Width == 0) ? 0f : exponentSize.Height * MathConstants.ExponentOffsetScale));
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public SizeF Dimensions(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _);

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
            SizeF size = Dimensions(graphics, font, scale, out var variableSize, out var sequenceSize, out var exponentSize);
            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.DarkCyan, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size.Width, size.Height);
            }

            if (sequenceSize.Width > 0)
            {
                Sequence?.Draw(graphics, font, brush, pen, scale * MathConstants.SequenceScale, x + variableSize.Width, y + variableSize.Height - (sequenceSize.Height * MathConstants.SequenceOffsetScale), drawBounds);
            }

            if (exponentSize.Width > 0)
            {
                Exponent?.Draw(graphics, font, brush, pen, scale * MathConstants.ExponentScale, x + variableSize.Width, y, drawBounds);
                y += exponentSize.Height * MathConstants.ExponentOffsetScale;
            }

            if (!string.IsNullOrWhiteSpace(Text))
            {
                using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
                graphics.DrawString(Text, tempFont, brush, x, y, StringFormat.GenericTypographic);
            }
        }

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="location">The location.</param>
        /// <returns></returns>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale)
        {
            Bounds = new RectangleF(location, Dimensions(graphics, font, scale, out var variableSize, out var sequenceSize, out var exponentSize));
            return Bounds ?? Rectangle.Empty;
        }
    }
}
