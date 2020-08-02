namespace PrimerLibrary
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
            foreach (var subExpression in nomial.Terms)
            {
                subExpression.Multiply(expression);
            }
        }
    }
}
