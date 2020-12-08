// <copyright file="SetCaretBlinkTime.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
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
    internal static partial class User32
    {
        /// <summary>
        /// Sets the caret blink time to the specified number of milliseconds. The blink time is the elapsed time, in milliseconds, required to invert the caret's pixels.
        /// </summary>
        /// <param name="uMSeconds">The new blink time, in milliseconds.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// The user can set the blink time using the Control Panel. Applications should respect the setting that the user has chosen. The SetCaretBlinkTime function should only be used by application that allow the user to set the blink time, such as a Control Panel applet.
        /// If you change the blink time, subsequently activated applications will use the modified blink time, even if you restore the previous blink time when you lose the keyboard focus or become inactive. This is due to the multithreaded environment, where deactivation of your application is not synchronized with the activation of another application. This feature allows the system to activate another application even if the current application is not responding.
        /// </remarks>
        /// <acknowledgment>
        /// https://docs.microsoft.com/windows/win32/api/winuser/nf-winuser-setcaretblinktime
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DllImport(Libraries.User32, SetLastError = true)]
        public static extern bool SetCaretBlinkTime(uint uMSeconds);
    }
}
