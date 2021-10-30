// <copyright file="GetCaretBlinkTime.cs" company="Shkyrockett" >
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
            /// Retrieves the time required to invert the caret's pixels. The user can set this value.
            /// </summary>
            /// <returns>
            /// If the function succeeds, the return value is the blink time, in milliseconds.
            /// A return value of INFINITE indicates that the caret does not blink.
            /// A return value is zero indicates that the function has failed. To get extended error information, call GetLastError.
            /// </returns>
            /// <acknowledgment>
            /// https://docs.microsoft.com/windows/win32/api/winuser/nf-winuser-getcaretblinktime
            /// </acknowledgment>
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            [DllImport(Libraries.User32, SetLastError = true)]
            public static extern uint GetCaretBlinkTime();
        }
    }
}
