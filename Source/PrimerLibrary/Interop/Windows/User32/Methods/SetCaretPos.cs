// <copyright file="SetCaretPos.cs" company="Shkyrockett" >
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
            /// Moves the caret to the specified coordinates. If the window that owns the caret was created with the CS_OWNDC class style, then the specified coordinates are subject to the mapping mode of the device context associated with that window.
            /// </summary>
            /// <param name="X">The new x-coordinate of the caret.</param>
            /// <param name="Y">The new y-coordinate of the caret.</param>
            /// <returns>
            /// If the function succeeds, the return value is nonzero.
            /// If the function fails, the return value is zero. To get extended error information, call GetLastError. https://docs.microsoft.com/windows/desktop/api/errhandlingapi/nf-errhandlingapi-getlasterror
            /// </returns>
            /// <remarks>
            /// SetCaretPos moves the caret whether the caret is hidden.
            /// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active. The window should destroy the caret before losing the keyboard focus or becoming inactive. A window can set the caret position only if it owns the caret.
            /// DPI Virtualization
            /// This API does not participate in DPI virtualization. The provided position is interpreted as logical coordinates in terms of the window associated with the caret. The calling thread is not taken into consideration.
            /// </remarks>
            /// <example>
            /// For an example, see Creating and Displaying a Caret. https://docs.microsoft.com/windows/desktop/menurc/using-carets
            /// </example>
            /// <acknowledgment>
            /// https://docs.microsoft.com/windows/win32/api/winuser/nf-winuser-setcaretpos
            /// </acknowledgment>
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            [DllImport(Libraries.User32, SetLastError = true)]
            public static extern bool SetCaretPos(int X, int Y);
        }
    }
}
