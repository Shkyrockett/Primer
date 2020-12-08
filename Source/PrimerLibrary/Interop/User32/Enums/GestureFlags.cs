// <copyright file="GestureFlags.cs" company="Shkyrockett" >
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Gesture flags - GestureInfo.flags
        /// </summary>
        [Flags]
        public enum GestureFlags
        {
            /// <summary>
            /// GF_BEGIN
            /// </summary>
            Begin = 0x1,

            /// <summary>
            /// GF_INERTIA
            /// </summary>
            Inertia = 0x2,

            /// <summary>
            /// GF_END
            /// </summary>
            End = 0x4
        }
    }
}
