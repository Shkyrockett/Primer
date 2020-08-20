﻿// <copyright file="INegatable.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using static System.Math;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    public interface INegatable
        : IExpression
    {
        /// <summary>
        /// Gets or sets the sign of the expression.
        /// </summary>
        /// <value>
        /// The sign of the expression. -1 for negative, +1 for positive, 0 for 0.
        /// </value>
        public int Sign { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is negative.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is negative; otherwise, <see langword="false" />.
        /// </value>
        bool IsNegative { get { return Sign(Sign) == -1d; } set { Sign *= value == (Sign(Sign) == -1d) ? 1 : -1; } }
    }
}