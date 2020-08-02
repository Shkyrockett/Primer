namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGroupable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IGroupable"/> is group.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if group; otherwise, <see langword="false" />.
        /// </value>
        bool Group { get; set; }

        /// <summary>
        /// Gets or sets the bar style.
        /// </summary>
        /// <value>
        /// The bar style.
        /// </value>
        BarStyles GroupingStyle { get; set; }

        /// <summary>
        /// Gets or sets the x margin.
        /// </summary>
        /// <value>
        /// The x margin.
        /// </value>
        float XMargin { get; set; }

        /// <summary>
        /// Gets or sets the y margin.
        /// </summary>
        /// <value>
        /// The y margin.
        /// </value>
        float YMargin { get; set; }
    }
}
