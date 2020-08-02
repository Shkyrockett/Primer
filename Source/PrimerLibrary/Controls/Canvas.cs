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

using System.Drawing;
using System.Drawing.Drawing2D;
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
        private bool Resizing;

        /// <summary>
        /// Initializes a new instance of the <see cref="Canvas"/> class.
        /// </summary>
        public Canvas()
        {
            InitializeComponent();

            Expression = new RelationalExpression(ComparisonOperators.Equals, null, null);
        }

        /// <summary>
        /// Gets or sets the expression.
        /// </summary>
        /// <value>
        /// The expression.
        /// </value>
        public IExpression Expression { get; set; }

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
            if (AutoSize && !Resizing && Expression is not null)
            {
                Resizing = true;
                var size = Expression.GetSize(e.Graphics, Font).ToSize();
                Width = size.Width + 2;
                Height = size.Height + 2;
                Resizing = false;
            }

            //base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Expression?.Draw(e.Graphics, Font, Brushes.Black, Pens.Black, 0, 0);
        }
    }
}
