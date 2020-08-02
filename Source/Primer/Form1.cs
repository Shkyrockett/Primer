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

using PrimerLibrary;
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
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            canvas1.Font = new Font("Cambria Math", 20);
            canvas1.Expression = new IntegralExpression(
                new RelationalExpression(ComparisonOperators.Equals,
                new NomialExpression(
                new GroupingExpression(
                new FractionExpression(new NomialExpression(new LogarithmExpression(new VariableExpression('a'), new CoefficientExpression(10), new CoefficientExpression(1))), new NomialExpression(new VariableExpression('b'))), BarStyles.Parenthesis, BarStyles.Parenthesis),
                new GroupingExpression(
                new MatrixExpression(2, 2, false, false, new FractionExpression(new TextExpression("∑"), new TextExpression("b")), new RootExpression(new TextExpression("2"), new TextExpression("2")), new SigmaExpression(new TextExpression("4"), new TextExpression("4"), new TextExpression("4")), new TextExpression("4")), BarStyles.Parenthesis, BarStyles.Parenthesis),
                new TermExpression(4, new VariableExpression('c'))
                ),
                new NomialExpression(new TermExpression(new CoefficientExpression(4), new PowerExpression(new VariableExpression('b'), new TextExpression("2"))))
                ), new TextExpression("√"), new TextExpression("⎷"));

            canvas1.AutoSize = true;
        }

        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            using FileStream fs = File.Create(@"C:\Users\shkyr\Desktop\test.json");
            await JsonSerializer.SerializeAsync(fs, canvas1.Expression);
        }
    }
}
