// <copyright file="IEditable.cs" company="Shkyrockett" >
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
    public interface IEditable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IEditable"/> is editable.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if editable; otherwise, <see langword="false" />.
        /// </value>
        bool Editable { get; set; }
    }
}
