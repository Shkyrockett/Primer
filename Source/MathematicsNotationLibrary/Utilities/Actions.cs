// <copyright file="Actions.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
public static class Actions
{
    /// <summary>
    /// Distributes the specified expression.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <param name="nomial">The nomial.</param>
    public static void Distribute(IExpression expression, NomialExpression nomial)
    {
        _ = expression;
        foreach (var subExpression in nomial.Terms)
        {
            _ = subExpression;
            //subExpression.Multiply(expression);
        }
    }
}
