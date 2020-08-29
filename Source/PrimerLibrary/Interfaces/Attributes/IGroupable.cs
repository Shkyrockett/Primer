// <copyright file="IGroupable.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

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
    }
}
