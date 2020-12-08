// <copyright file="VariableFactor.cs" company="Shkyrockett" >
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

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// Draw some text.
    /// </summary>
    /// <seealso cref="MathematicsNotationLibrary.IExpression" />
    /// <seealso cref="MathematicsNotationLibrary.INegatable" />
    public class VariableFactor
        : IExponatable, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="VariableFactor" /> class.
        /// </summary>
        /// <param name="name">The text.</param>
        /// <param name="value">The value.</param>
        /// <param name="exponent">The exponent.</param>
        /// <param name="sequence">The sequence.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public VariableFactor(char name, double value, IExpression? exponent = null, INumeric? sequence = null, bool editable = false)
        {
            Parent = null;
            Name = name.Italicize();
            Value = value;
            Sequence = sequence;
            if (Sequence is IChild s) s.Parent = this;
            Exponent = exponent;
            if (Exponent is IChild e) e.Parent = this;
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
        public INumeric? Sequence { get; set; }

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
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the numeric value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public double Value { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="NumericFactor"/> is editable.
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
        public PointF? Location { get => Bounds?.Location; set => Bounds = Bounds switch { null when value is PointF p => new RectangleF(p, SizeF.Empty), RectangleF b when value is PointF d => new RectangleF(d, b.Size), _ => null, }; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        [JsonIgnore]
        public SizeF? Size { get => Bounds?.Size; set => Bounds = Bounds switch { null when value is SizeF s => new RectangleF(PointF.Empty, s), RectangleF b when value is SizeF s => new RectangleF(b.Location, s), _ => null, }; }

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
        /// <param name="exponentSize">Size of the exponent.</param>
        /// <param name="sequenceSize">Size of the sequence.</param>
        /// <returns></returns>
        private SizeF Layout(Graphics graphics, Font font, float scale, out SizeF variableSize, out SizeF exponentSize, out SizeF sequenceSize)
        {
            Scale = scale;
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            var emHeightUnit = graphics.ConvertGraphicsUnits(tempFont.Size, tempFont.Unit, GraphicsUnit.Pixel);
            var designToUnit = emHeightUnit / tempFont.FontFamily.GetEmHeight(tempFont.Style);
            //var ascent = designToUnit * tempFont.FontFamily.GetCellAscent(tempFont.Style);
            //var descent = designToUnit * tempFont.FontFamily.GetCellDescent(tempFont.Style);
            var lineSpacing = designToUnit * tempFont.FontFamily.GetLineSpacing(tempFont.Style);

            if (string.IsNullOrEmpty(Name))
            {
                variableSize = new SizeF(0f, lineSpacing);
            }
            else
            {
                variableSize = graphics.MeasureString(Name, tempFont, Point.Empty, StringFormat.GenericTypographic);
                variableSize.Height = lineSpacing;
            }

            sequenceSize = Sequence?.Layout(graphics, font, scale * Mathematics.SequenceScale) ?? SizeF.Empty;

            exponentSize = Exponent?.Layout(graphics, font, scale * Mathematics.ExponentScale) ?? SizeF.Empty;

            Size = new SizeF(
                variableSize.Width + MathF.Max(exponentSize.Width, sequenceSize.Width),
                variableSize.Height + ((sequenceSize.Width == 0) ? 0f : sequenceSize.Height * Mathematics.SequenceOffsetScale) + ((exponentSize.Width == 0) ? 0f : exponentSize.Height * Mathematics.ExponentOffsetScale));
            return Size.Value;
        }

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="variableBounds">The variable bounds.</param>
        /// <param name="exponentBounds">The exponent bounds.</param>
        /// <param name="sequenceBounds">The sequence bounds.</param>
        /// <returns></returns>
        private RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF variableBounds, out RectangleF exponentBounds, out RectangleF sequenceBounds)
        {
            var size = Layout(graphics, font, scale, out var variableSize, out var exponentSize, out var sequenceSize);
            Bounds = new RectangleF(location, size);

            exponentBounds = exponentSize.Width > 0
                ? new RectangleF(new(location.X + variableSize.Width, location.Y), exponentSize)
                : RectangleF.Empty;

            sequenceBounds = sequenceSize.Width > 0
                ? new RectangleF(new(location.X + variableSize.Width, location.Y + size.Height - sequenceSize.Height), sequenceSize)
                : RectangleF.Empty;

            location.Y += exponentSize.Height * Mathematics.ExponentOffsetScale;
            variableBounds = new RectangleF(location, variableSize);

            return Bounds.Value;
        }

        /// <summary>
        /// Return the equation's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public SizeF Layout(Graphics graphics, Font font, float scale) => Layout(graphics, font, scale, out _, out _, out _);

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale) => Layout(graphics, font, location, scale, out _, out _, out _);

        /// <summary>
        /// Draw the equation.
        /// </summary>
        /// <param name="graphics">The GDI graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="pen">The pen.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="drawBounds">if set to <see langword="true" /> [draw bounds].</param>
        /// <returns></returns>
        public void Draw(Graphics graphics, Font font, Brush brush, Pen pen, PointF location, float scale, bool drawBounds = false)
        {
            var bounds = Layout(graphics, font, location, scale, out var variableBounds, out var exponentBounds, out var sequenceBounds);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.DarkCyan, 0)
                {
                    DashStyle = DashStyle.Dash
                };

                graphics.DrawRectangle(dashedPen, exponentBounds);
                graphics.DrawRectangle(dashedPen, sequenceBounds);
                graphics.DrawRectangle(dashedPen, bounds);
            }

            if (exponentBounds.Width > 0)
            {
                Exponent?.Draw(graphics, font, brush, pen, exponentBounds.Location, scale * Mathematics.ExponentScale, drawBounds);
            }

            if (sequenceBounds.Width > 0)
            {
                Sequence?.Draw(graphics, font, brush, pen, sequenceBounds.Location, scale * Mathematics.SequenceScale, drawBounds);
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
                graphics.DrawString(Name, tempFont, brush, variableBounds.Location, StringFormat.GenericTypographic);
            }
        }

        /// <summary>
        /// Expressions of this instance.
        /// </summary>
        /// <returns></returns>
        public HashSet<IExpression> Expressions()
        {
            var set = new HashSet<IExpression>() { this };
            if (Exponent is not null) set.UnionWith(Exponent.Expressions());
            if (Sequence is not null) set.UnionWith(Sequence.Expressions());
            return set;
        }
    }
}
