// <copyright file="SetGestureConfig.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

/// <summary>
/// 
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// 
    /// </summary>
    internal static partial class Windows
    {
        /// <summary>
        /// 
        /// </summary>
        internal static partial class User32
        {
            /// <summary>
            /// Sets the gesture configuration.
            /// </summary>
            /// <param name="hWnd">The h WND.</param>
            /// <param name="dwReserved">The dw reserved.</param>
            /// <param name="cIDs">The c i ds.</param>
            /// <param name="pGestureConfig">The p gesture configuration.</param>
            /// <param name="cbSize">Size of the cb.</param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            [DllImport(Libraries.User32)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetGestureConfig(IntPtr hWnd, int dwReserved, int cIDs, ref GestureConfig pGestureConfig, int cbSize);
        }
    }
}
