namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface IArithmatic
    {
        /// <summary>
        /// Gets or sets the sign of the expression.
        /// </summary>
        /// <value>
        /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
        /// </value>
        public int Sign { get; set; }

        /// <summary>
        /// Pluses the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IExpression Plus(IExpression expression);

        /// <summary>
        /// Adds the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IExpression Add(IExpression expression);

        /// <summary>
        /// Negates the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IExpression Negate(IExpression expression);

        /// <summary>
        /// Subtracts the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IExpression Subtract(IExpression expression);

        /// <summary>
        /// Multiplies the specified expression.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IExpression Multiply(IExpression expression);
    }
}
