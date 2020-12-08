// <copyright file="RegisterTouchWindow.cs" company="Shkyrockett" >
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
    internal static partial class User32
    {
        /// <summary>
        /// Registers the touch window.
        /// </summary>
        /// <param name="hWnd">The h WND.</param>
        /// <param name="ulFlags">The ul flags.</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DllImport(Libraries.User32)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RegisterTouchWindow(IntPtr hWnd, ulong ulFlags);
    }
}
