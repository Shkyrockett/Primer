// <copyright file="ITerm.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
//     Based on the code at: http://csharphelper.com/blog/2017/09/recursively-draw-equations-in-c/ by Rod Stephens.
// </remarks>

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.IExpression" />
    public interface ITerm
        : IExpression
    {
        /// <summary>
        /// Gets a value indicating whether this instance is first term.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is first term; otherwise, <see langword="false" />.
        /// </value>
        bool IsFirstTerm { get; }

        /// <summary>
        /// Gets a value indicating whether this instance is constant.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is constant; otherwise, <see langword="false" />.
        /// </value>
        bool IsConstant { get; }
    }
}
