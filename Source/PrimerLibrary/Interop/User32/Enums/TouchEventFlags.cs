// <copyright file="TouchEventFlags.cs" company="Shkyrockett" >
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
        public enum TouchEventFlags
        {
            /// <summary>
            /// The move
            /// </summary>
            Move = 0x0001,

            /// <summary>
            /// Down
            /// </summary>
            Down = 0x0002,

            /// <summary>
            /// Up
            /// </summary>
            Up = 0x0004,

            /// <summary>
            /// The in range
            /// </summary>
            InRange = 0x0008,

            /// <summary>
            /// The primary
            /// </summary>
            Primary = 0x0010,

            /// <summary>
            /// The no coalesce
            /// </summary>
            NoCoalesce = 0x0020,

            /// <summary>
            /// The pen
            /// </summary>
            Pen = 0x0040,

            /// <summary>
            /// The palm
            /// </summary>
            Palm = 0x0080
        }
    }
}
