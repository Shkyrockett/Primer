// <copyright file="RelationalOperation.cs" company="Shkyrockett" >
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
    [JsonConverter(typeof(CoefficientFactor))]
    public class RelationalOperation
        : IExpression, IEditable
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationalOperation" /> class.
        /// </summary>
        /// <param name="operator">The operator.</param>
        /// <param name="leftExpression">The left expression.</param>
        /// <param name="rightExpression">The right expression.</param>
        /// <param name="editable">if set to <see langword="true" /> [editable].</param>
        public RelationalOperation(ComparisonOperators @operator, IExpression? leftExpression, IExpression? rightExpression, bool editable = false)
        {
            Parent = null;
            Comparand = leftExpression;
            if (Comparand is IExpression l) l.Parent = this;
            Comparanda = rightExpression;
            if (Comparanda is IExpression r) r.Parent = this;
            Operator = @operator;
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
        /// Gets or sets the operator.
        /// </summary>
        /// <value>
        /// The operator.
        /// </value>
        [JsonInclude, JsonPropertyName("Operator"), JsonConverter(typeof(ComparisonOperators))]
        public ComparisonOperators Operator { get; set; }

        /// <summary>
        /// Gets the comparand.
        /// </summary>
        /// <value>
        /// The comparand.
        /// </value>
        [JsonInclude, JsonPropertyName("Comparand")]
        [JsonConverter(typeof(NomialExpression))]
        public IExpression? Comparand { get; }

        /// <summary>
        /// Gets the comparanda.
        /// </summary>
        /// <value>
        /// The comparanda.
        /// </value>
        [JsonInclude, JsonPropertyName("Comparanda")]
        [JsonConverter(typeof(NomialExpression))]
        public IExpression? Comparanda { get; }

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
        /// <param name="comparandSize">Size of the left.</param>
        /// <param name="operatorSize">Size of the operator.</param>
        /// <param name="comparandaSize">Size of the right.</param>
        /// <returns></returns>
        private SizeF Dimensions(Graphics graphics, Font font, float scale, out SizeF comparandSize, out SizeF operatorSize, out SizeF comparandaSize)
        {
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            var emHeightUnit = graphics.ConvertGraphicsUnits(tempFont.Size, tempFont.Unit, GraphicsUnit.Pixel);
            var designToUnit = emHeightUnit / tempFont.FontFamily.GetEmHeight(tempFont.Style);
            //var ascent = designToUnit * tempFont.FontFamily.GetCellAscent(tempFont.Style);
            //var descent = designToUnit * tempFont.FontFamily.GetCellDescent(tempFont.Style);
            var lineSpacing = designToUnit * tempFont.FontFamily.GetLineSpacing(tempFont.Style);

            operatorSize = graphics.MeasureString(Operator.GetString(), tempFont, Point.Empty, StringFormat.GenericTypographic);
            operatorSize.Height = lineSpacing;
            comparandSize = Comparand?.Dimensions(graphics, font, scale) ?? graphics.MeasureString(" ", tempFont, PointF.Empty, StringFormat.GenericTypographic);
            comparandaSize = Comparanda?.Dimensions(graphics, font, scale) ?? graphics.MeasureString(" ", tempFont, PointF.Empty, StringFormat.GenericTypographic);
            var height = operatorSize.Height;
            height = Max(height, comparandSize.Height);
            height = Max(height, comparandaSize.Height);
            return new SizeF(comparandSize.Width + operatorSize.Width + comparandaSize.Width, height);
        }

        /// <summary>
        /// Return the object's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            SizeF size = Dimensions(graphics, font, scale, out var comparandSize, out var operatorSize, out var comparandaSize);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.Violet, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, size);
            }

            // Draw the left Expression.
            if (Comparand is not null)
            {
                Comparand?.Draw(graphics, font, brush, pen, scale, x, y + ((size.Height - comparandSize.Height) * MathConstants.OneHalf), drawBounds);
            }
            else
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, comparandSize.Width, comparandSize.Height);
            }

            // Advance X.
            x += comparandSize.Width;

            // Draw the Operator.
            using var tempFont = new Font(font.FontFamily, font.Size * scale, font.Style);
            graphics.DrawString(Operator.GetString(), tempFont, brush, x, y + ((size.Height - operatorSize.Height) * MathConstants.OneHalf), StringFormat.GenericTypographic);

            // Advance X.
            x += operatorSize.Width;

            // Draw the right.
            if (Comparanda is not null)
            {
                Comparanda?.Draw(graphics, font, brush, pen, scale, x, y + ((size.Height - comparandaSize.Height) * MathConstants.OneHalf), drawBounds);
            }
            else
            {
                using var dashedPen = new Pen(Color.Gray, 0)
                {
                    DashStyle = DashStyle.Dash
                };
                graphics.DrawRectangle(dashedPen, x, y, comparandSize.Width, comparandSize.Height);
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
            SizeF size = Dimensions(graphics, font, scale, out var comparandSize, out var operatorSize, out var comparandaSize);
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
