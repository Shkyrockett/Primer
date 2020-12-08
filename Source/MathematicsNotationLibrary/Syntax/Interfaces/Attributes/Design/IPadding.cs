// <copyright file="IPadding.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPadding
    {
        /// <summary>
        /// Gets or sets the left padding.
        /// </summary>
        /// <value>
        /// The left padding.
        /// </value>
        float LeftPadding { get; set; }

        /// <summary>
        /// Gets or sets the top padding.
        /// </summary>
        /// <value>
        /// The top padding.
        /// </value>
        float TopPadding { get; set; }

        /// <summary>
        /// Gets or sets the right padding.
        /// </summary>
        /// <value>
        /// The right padding.
        /// </value>
        float RightPadding { get; set; }

        /// <summary>
        /// Gets or sets the bottom padding.
        /// </summary>
        /// <value>
        /// The bottom padding.
        /// </value>
        float BottomPadding { get; set; }

        /// <summary>
        /// Gets or sets the spacing padding.
        /// </summary>
        /// <value>
        /// The spacing padding.
        /// </value>
        float SpacingPadding { get; set; }
    }
}
