// <copyright file="DestroyCaret.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

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
            /// Destroys the caret's current shape, frees the caret from the window, and removes the caret from the screen.
            /// </summary>
            /// <returns>
            /// If the function succeeds, the return value is nonzero.
            /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            /// <remarks>
            /// DestroyCaret destroys the caret only if a window in the current task owns the caret. If a window that is not in the current task owns the caret, DestroyCaret does nothing and returns FALSE.
            /// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active. The window should destroy the caret before losing the keyboard focus or becoming inactive.
            /// </remarks>
            /// <example>
            /// For an example, see Destroying a Caret https://docs.microsoft.com/windows/win32/menurc/using-carets
            /// </example>
            /// <acknowledgment>
            /// https://docs.microsoft.com/windows/win32/api/winuser/nf-winuser-destroycaret
            /// </acknowledgment>
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            [DllImport(Libraries.User32, SetLastError = true)]
            public static extern bool DestroyCaret();
        }
    }
}
