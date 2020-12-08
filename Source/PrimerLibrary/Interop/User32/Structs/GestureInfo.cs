// <copyright file="GestureInfo.cs" company="Shkyrockett" >
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
        // One of the fields in GESTUREINFO structure is type of Int64 (8 bytes). The relevant gesture information is stored in lower 4 bytes. This bit mask is used to get 4 lower bytes from this argument.
        public const long ULL_ARGUMENTS_BIT_MASK = 0x00000000FFFFFFFF;

        /// <summary>
        /// Gesture information structure - Pass the HGESTUREINFO received in the WM_GESTURE message lParam into the GetGestureInfo function to retrieve this information. - If cbExtraArgs is non-zero, pass the HGESTUREINFO received in the WM_GESTURE message lParam into the GetGestureExtraArgs function to retrieve extended argument information.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct GestureInfo
        {
            /// <summary>
            /// The size, in bytes, of this structure (including variable length Args field)
            /// </summary>
            public int cbSize;

            /// <summary>
            /// The see GF_* flags
            /// </summary>
            public GestureFlags dwFlags;

            /// <summary>
            /// The gesture identifier, see GID_* defines
            /// </summary>
            public GestureId dwID;

            /// <summary>
            /// The handle to window targeted by this gesture
            /// </summary>
            public IntPtr hwndTarget;

            /// <summary>
            /// The current location of this gesture
            /// </summary>
            [MarshalAs(UnmanagedType.Struct)]
            internal PointS ptsLocation;

            /// <summary>
            /// The internally used
            /// </summary>
            public int dwInstanceID;

            /// <summary>
            /// The internally used
            /// </summary>
            public int dwSequenceID;

            /// <summary>
            /// The arguments for gestures whose arguments fit in 8 BYTES
            /// </summary>
            public long ullArguments;

            /// <summary>
            /// The size, in bytes, of extra arguments, if any, that accompany this gesture
            /// </summary>
            public int cbExtraArgs;

            /// <summary>
            /// Gets the size.
            /// </summary>
            /// <returns></returns>
            public static int GetSize() => Marshal.SizeOf(new GestureInfo());
        }
    }
}
