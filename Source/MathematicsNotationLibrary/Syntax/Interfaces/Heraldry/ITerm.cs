// <copyright file="ITerm.cs" company="Shkyrockett" >
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
    /// <seealso cref="MathematicsNotationLibrary.IExpression" />
    public interface ITerm
        : IExpression, INegatable
    {
        /// <summary>
        /// Gets or sets the coefficient.
        /// </summary>
        /// <value>
        /// The coefficient.
        /// </value>
        public ICoefficient? Coefficient { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is first term.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is first term; otherwise, <see langword="false" />.
        /// </value>
        public bool IsFirstTerm { get; }

        /// <summary>
        /// Gets or sets the sign.
        /// </summary>
        /// <value>
        /// The sign.
        /// </value>
        public new int Sign { get => Coefficient?.Sign ?? 1; set { if (Coefficient is not null) Coefficient.Sign = value; } }

        /// <summary>
        /// Gets a value indicating whether this instance is constant.
        /// </summary>
        /// <value>
        ///   <see langword="true" /> if this instance is constant; otherwise, <see langword="false" />.
        /// </value>
        bool IsConstant { get; }
    }
}
