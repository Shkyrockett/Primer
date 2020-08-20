// <copyright file="Canvas.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class Canvas
        : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Canvas"/> class.
        /// </summary>
        public Canvas()
        {
            InitializeComponent();

            Expression = new RelationalOperation(ComparisonOperators.Equals, null, null);
        }

        /// <summary>
        /// Gets or sets the expression.
        /// </summary>
        /// <value>
        /// The expression.
        /// </value>
        public IExpression Expression { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [render boundaries].
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if [render boundaries]; otherwise, <see langword="false" />.
        /// </value>
        public bool RenderBoundaries { get; set; }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        //[DefaultValue(System.Drawing.SystemColors.Window)]
        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

        /// <summary>
        /// Handles the Paint event of the Canvas control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var window = new SizeF(Size.Width - 1f, Size.Height - 1f);
            var bounds = new RectangleF(PointF.Empty, window);
            e.Graphics.DrawRectangle(Pens.CornflowerBlue, bounds);

            var padding = Math.Min(window.Width * 0.25f, window.Height * 0.25f);
            var outer = new SizeF(window.Width - padding, window.Height - padding);
            var inner = Expression.Dimensions(e.Graphics, Font, 1f);
            var scale = Utilities.FitSizeWithin(inner, outer);
            inner = Expression.Dimensions(e.Graphics, Font, scale);

            (var x, var y) = ((window.Width - inner.Width) * 0.5f, (window.Height - inner.Height) * 0.5f);

            e.Graphics.ResetTransform();
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.CompositingMode = CompositingMode.SourceOver;

            Expression?.Draw(e.Graphics, Font, Brushes.Black, Pens.Black, scale, x, y, RenderBoundaries);
        }

        /// <summary>
        /// Handles the Resize event of the Canvas control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Canvas_Resize(object sender, EventArgs e) => Invalidate();

        /// <summary>
        /// Handles the Move event of the Canvas control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Canvas_Move(object sender, EventArgs e) => Invalidate();
    }
}
