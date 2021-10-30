// <copyright file="ShowCaret.cs" company="Shkyrockett" >
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
            /// Makes the caret visible on the screen at the caret's current position. When the caret becomes visible, it begins flashing automatically.
            /// </summary>
            /// <param name="hWnd">A handle to the window that owns the caret. If this parameter is NULL, ShowCaret searches the current task for the window that owns the caret.</param>
            /// <returns>
            /// If the function succeeds, the return value is nonzero.
            /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            /// <remarks>
            /// ShowCaret shows the caret only if the specified window owns the caret, the caret has a shape, and the caret has not been hidden two or more times in a row. If one or more of these conditions is not met, ShowCaret does nothing and returns FALSE.
            /// Hiding is cumulative. If your application calls HideCaret five times in a row, it must also call ShowCaret five times before the caret reappears.
            /// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active. The window should destroy the caret before losing the keyboard focus or becoming inactive.
            /// </remarks>
            /// <example>
            /// For an example, see Creating and Displaying a Caret. https://docs.microsoft.com/windows/win32/menurc/using-carets
            /// </example>
            /// <acknowledgment>
            /// https://docs.microsoft.com/windows/win32/api/winuser/nf-winuser-showcaret
            /// </acknowledgment>
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            [DllImport(Libraries.User32, SetLastError = true)]
            public static extern bool ShowCaret(IntPtr hWnd);
        }
    }
}
