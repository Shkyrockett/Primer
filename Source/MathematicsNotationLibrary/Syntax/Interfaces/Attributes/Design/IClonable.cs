// <copyright file="IClonable.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IClonable<T>
    where T : IExpression
{
    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns></returns>
    T Clone();
}
