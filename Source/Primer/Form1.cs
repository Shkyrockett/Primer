// <copyright file="Form1.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using MathematicsNotationLibrary;
using System;
using System.Drawing;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace Primer
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Form1
        : Form
    {
        /// <summary>
        /// The render boundaries.
        /// </summary>
        private readonly bool renderBoundaries = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            canvas1.Font = new Font("Cambria Math", 12F, FontStyle.Regular, GraphicsUnit.Point);
            canvas1.Expression = new RelationalOperation(
                ComparisonOperators.NotEquals,
                new NomialExpression(
                new ProductTerm(new FractionFactor(1, 2) { Exponent = new NumericFactor(2) },
                new QuotientFactor(
                new NomialExpression(new ProductTerm(new NumericFactor(1), new VariableFactor('x', 0, new NumericFactor(2), new NumericFactor(1))), new ProductTerm(new NumericFactor(-1, new NumericFactor(2)))),
                new NomialExpression(new ProductTerm(new NumericFactor(1), new VariableFactor('a', 0, new NumericFactor(3), new NumericFactor(1))))
                )
                ),
                new ProductTerm(new NumericFactor(1),
                new QuotientFactor(
                new NomialExpression(new ProductTerm(new NumericFactor(1), new VariableFactor('y', 0, new NumericFactor(2), new NumericFactor(1))), new ProductTerm(new NumericFactor(-1, new NumericFactor(4)))),
                new NomialExpression(new ProductTerm(new NumericFactor(1), new VariableFactor('b', 0, new NumericFactor(5), new NumericFactor(1))))
                )
                )
                ),
                new NomialExpression(
                new ProductTerm(new NumericFactor(1) { PlusOrMinus = true }, new RootFunction(new NumericFactor(3), new NumericFactor(2), new NumericFactor(1), new NumericFactor(6))),
                new ProductTerm(new NumericFactor(1), new MatrixFactor(3, 3, new ProductTerm(1), new ProductTerm(0), new ProductTerm(0), new ProductTerm(0), new ProductTerm(1), new ProductTerm(0), new ProductTerm(0), new ProductTerm(0), new ProductTerm(1)) { Sequence = new NumericFactor(1), Exponent = new NumericFactor(7) })
                )
                );
            canvas1.RenderBoundaries = renderBoundaries;
        }

        /// <summary>
        /// Handles the ClickAsync event of the Button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            var json = JsonSerializer.Serialize(canvas1.Expression);
            await File.WriteAllTextAsync(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.json"), json);
        }
    }
}
