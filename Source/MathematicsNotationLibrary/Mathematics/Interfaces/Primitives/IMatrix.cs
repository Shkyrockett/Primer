// <copyright file="IMatrix.cs" company="Shkyrockett" >
//     Copyright © 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMatrix<T>
    where T : INumber<T>
{
    /// <summary>
    /// 
    /// </summary>
    T[,] Items { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    int Rows { get; }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    int Columns { get; }

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    public int Count => Rows * Columns;

    /// <summary>
    /// 
    /// </summary>
    [IgnoreDataMember, XmlIgnore, SoapIgnore]
    T Determinant { get; }
}
