// <copyright file="TouchInput.cs" company="Shkyrockett" >
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
using System.Runtime.InteropServices;

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
        [StructLayout(LayoutKind.Sequential)]
        public struct TouchInput
        {
            /// <summary>
            /// The x
            /// </summary>
            public int x;

            /// <summary>
            /// The y
            /// </summary>
            public int y;

            /// <summary>
            /// The h source
            /// </summary>
            public IntPtr hSource;

            /// <summary>
            /// The dw identifier
            /// </summary>
            public int dwID;

            /// <summary>
            /// The dw flags
            /// </summary>
            public TouchEventFlags dwFlags;

            /// <summary>
            /// The dw mask
            /// </summary>
            public int dwMask;

            /// <summary>
            /// The dw time
            /// </summary>
            public int dwTime;

            /// <summary>
            /// The dw extra information
            /// </summary>
            public IntPtr dwExtraInfo;

            /// <summary>
            /// The cx contact
            /// </summary>
            public int cxContact;

            /// <summary>
            /// The cy contact
            /// </summary>
            public int cyContact;

            /// <summary>
            /// Gets the size.
            /// </summary>
            /// <returns></returns>
            public static int GetSize() => Marshal.SizeOf(new TouchInput());
        }
    }
}
