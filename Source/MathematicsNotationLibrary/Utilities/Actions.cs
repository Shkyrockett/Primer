﻿namespace MathematicsNotationLibrary
{
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
}
