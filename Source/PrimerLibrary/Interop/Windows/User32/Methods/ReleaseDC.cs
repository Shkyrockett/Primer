// <copyright file="ReleaseDC.cs" company="Shkyrockett" >
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
            /// The ReleaseDC function releases a device context (DC), freeing it for use by other applications. The effect of the ReleaseDC function depends on the type of DC. It frees only common and window DCs. It has no effect on class or private DCs.
            /// </summary>
            /// <param name="hWnd">A handle to the window whose DC is to be released.</param>
            /// <param name="hDC">A handle to the DC to be released.</param>
            /// <returns>
            /// The return value indicates whether the DC was released. If the DC was released, the return value is 1.
            /// If the DC was not released, the return value is zero.
            /// </returns>
            /// <remarks>
            /// The application must call the ReleaseDC function for each call to the GetWindowDC function and for each call to the GetDC function that retrieves a common DC.
            /// An application cannot use the ReleaseDC function to release a DC that was created by calling the CreateDC function; instead, it must use the DeleteDC function. ReleaseDC must be called from the same thread that called GetDC.
            /// </remarks>
            /// <acknowledgment>
            /// https://docs.microsoft.com/windows/win32/api/winuser/nf-winuser-releasedc
            /// </acknowledgment>
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            [DllImport(Libraries.User32, EntryPoint = "ReleaseDC", SetLastError = true)]
            public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);
        }
    }
}
