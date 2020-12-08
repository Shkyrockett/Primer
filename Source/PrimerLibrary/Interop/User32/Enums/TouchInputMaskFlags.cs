// <copyright file="TouchInputMaskFlags.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;

/// <summary>
/// 
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// 
    /// </summary>
    internal static partial class User32
    {
        /// <summary>
        /// 
        /// </summary>
        [Flags]
        public enum TouchInputMaskFlags
        {
            /// <summary>
            /// The dwTime field contains a system generated value
            /// </summary>
            TIMEFROMSYSTEM = 0x0001,

            /// <summary>
            /// The dwExtraInfo field is valid
            /// </summary>
            EXTRAINFO = 0x0002,

            /// <summary>
            /// The cxContact and cyContact fields are valid
            /// </summary>
            CONTACTAREA = 0x0004
        }
    }
}