// <copyright file="GetCaretPos.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Drawing;
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
            /// Copies the caret's position to the specified POINT structure.
            /// </summary>
            /// <param name="lpPoint">A pointer to the POINT structure that is to receive the client coordinates of the caret.</param>
            /// <returns>
            /// If the function succeeds, the return value is nonzero.
            /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
            /// </returns>
            /// <remarks>
            /// The caret position is always given in the client coordinates of the window that contains the caret.
            /// DPI Virtualization
            /// This API does not participate in DPI virtualization. The returned values are interpreted as logical sizes in terms of the window in question. The calling thread is not taken into consideration.
            /// </remarks>
            /// <acknowledgment>
            /// https://docs.microsoft.com/windows/win32/api/winuser/nf-winuser-getcaretpos
            /// </acknowledgment>
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            [DllImport(Libraries.User32, SetLastError = true)]
            public static extern bool GetCaretPos(out Point lpPoint);
        }
    }
}
