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

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MathematicsNotationLibrary.IExpression" />
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
            for (var i = 0; i < Terms.Count; i++)
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
        public int Sign { get => Terms?[0].Sign ?? 1; set { if (Terms is not null && Terms[0] is INegatable t) t.Sign = value; } }

        /// <summary>
        /// Gets or sets a value indicating whether [plus or minus].
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if [plus or minus]; otherwise, <see langword="false" />.
        /// </value>
        public bool PlusOrMinus { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="NumericFactor"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        [JsonInclude, JsonPropertyName("Editable")]
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
                var nomialSize = termsSizes[i] = Terms[i].Layout(graphics, font, scale);
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

            Size = new SizeF(width, maxHeight);
            return Size.Value;
        }

        /// <summary>
        /// Return the object's size.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="scale">The scale.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public SizeF Layout(Graphics graphics, Font font, float scale) => Dimensions(graphics, font, scale, out _, out _, out _, out _, out _, out _);

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
            var bounds = Layout(graphics, font, location, scale, out var contentsBounds, out var termsBounds, out var leftGroupBounds, out var leftScale, out var rightGroupBounds, out var rightScale);

            if (drawBounds)
            {
                using var dashedPen = new Pen(Color.Lime, 0)
                {
                    DashStyle = DashStyle.Dash
                };

                graphics.DrawRectangle(dashedPen, bounds);
                graphics.DrawRectangle(dashedPen, contentsBounds);
            }

            if (Group)
            {
                Utilities.DrawLeftBar(graphics, font, pen, brush, leftScale, leftGroupBounds.Location, GroupingStyle, drawBounds);
                location.X += leftGroupBounds.Width;
                Utilities.DrawRightBar(graphics, font, pen, brush, rightScale, rightGroupBounds.Location, GroupingStyle, drawBounds);
            }

            for (var i = 0; i < (Terms?.Count ?? 0); i++)
            {
                Terms?[i]?.Draw(graphics, font, brush, pen, termsBounds[i].Location, scale, drawBounds);
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
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale) => Layout(graphics, font, location, scale, out _, out _, out _, out _, out _, out _);

        /// <summary>
        /// Layouts the specified graphics.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="font">The font.</param>
        /// <param name="location">The location.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="contentsBounds">The contents bounds.</param>
        /// <param name="termsBounds">The terms bounds.</param>
        /// <param name="leftGroupBounds">The left group bounds.</param>
        /// <param name="leftScale">The left scale.</param>
        /// <param name="rightGroupBounds">The right group bounds.</param>
        /// <param name="rightScale">The right scale.</param>
        /// <returns></returns>
        public RectangleF Layout(Graphics graphics, Font font, PointF location, float scale, out RectangleF contentsBounds, out Span<RectangleF> termsBounds, out RectangleF leftGroupBounds, out float leftScale, out RectangleF rightGroupBounds, out float rightScale)
        {
            var size = Dimensions(graphics, font, scale, out var contentsSize, out var termsSizes, out var leftGroup, out leftScale, out var rightGroup, out rightScale);
            Bounds = new RectangleF(location, size);
            contentsBounds = new RectangleF(new PointF(location.X + leftGroup.Width, location.Y), contentsSize);

            if (Group)
            {
                leftGroupBounds = new RectangleF(location, leftGroup);
                location.X += leftGroup.Width;
                rightGroupBounds = new RectangleF(new(location.X + contentsSize.Width, location.Y), rightGroup);
            }
            else
            {
                leftGroupBounds = rightGroupBounds = RectangleF.Empty;
            }

            termsBounds = new RectangleF[termsSizes.Length];
            for (var i = 0; i < (Terms?.Count ?? 0); i++)
            {
                termsBounds[i] = new RectangleF(new(location.X, location.Y + ((size.Height - termsSizes[i].Height) * 0.5f)), termsSizes[i]);
                location.X += termsSizes[i].Width;
            }

            return Bounds ?? Rectangle.Empty;
        }

        /// <summary>
        /// Expressions of this instance.
        /// </summary>
        /// <returns></returns>
        public HashSet<IExpression> Expressions()
        {
            var set = new HashSet<IExpression>() { this };
            if (Terms is not null)
            {
                foreach (var term in Terms)
                {
                    if (term is not null) set.UnionWith(term.Expressions());
                }
            }

            return set;
        }
    }
}
