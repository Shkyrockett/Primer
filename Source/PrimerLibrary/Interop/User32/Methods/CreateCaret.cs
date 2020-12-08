// <copyright file="CreateCaret.cs" company="Shkyrockett" >
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
        /// Creates a new shape for the system caret and assigns ownership of the caret to the specified window. The caret shape can be a line, a block, or a bitmap.
        /// </summary>
        /// <param name="hWnd">A handle to the window that owns the caret.</param>
        /// <param name="hBitmap">A handle to the bitmap that defines the caret shape. If this parameter is NULL, the caret is solid. If this parameter is (HBITMAP) 1, the caret is gray. If this parameter is a bitmap handle, the caret is the specified bitmap. The bitmap handle must have been created by the CreateBitmap, CreateDIBitmap, or LoadBitmap function.
        /// If hBitmap is a bitmap handle, CreateCaret ignores the nWidth and nHeight parameters; the bitmap defines its own width and height.</param>
        /// <param name="nWidth">The width of the caret, in logical units. If this parameter is zero, the width is set to the system-defined window border width. If hBitmap is a bitmap handle, CreateCaret ignores this parameter.</param>
        /// <param name="nHeight">The height of the caret, in logical units. If this parameter is zero, the height is set to the system-defined window border height. If hBitmap is a bitmap handle, CreateCaret ignores this parameter.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero. To get extended error information, call GetLastError.
        /// </returns>
        /// <remarks>
        /// The nWidth and nHeight parameters specify the caret's width and height, in logical units; the exact width and height, in pixels, depend on the window's mapping mode.
        /// CreateCaret automatically destroys the previous caret shape, if any, regardless of the window that owns the caret. The caret is hidden until the application calls the ShowCaret function to make the caret visible.
        /// The system provides one caret per queue. A window should create a caret only when it has the keyboard focus or is active. The window should destroy the caret before losing the keyboard focus or becoming inactive.
        /// DPI Visualization
        /// This API does not participate in DPI visualization. The width and height parameters are interpreted as logical sizes in terms of the window in question. The calling thread is not taken into consideration.
        /// </remarks>
        /// <example>
        /// For an example, see Creating and Displaying a Caret. https://docs.microsoft.com/windows/win32/menurc/using-carets
        /// </example>
        /// <acknowledgment>
        /// https://docs.microsoft.com/windows/win32/api/winuser/nf-winuser-createcaret
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DllImport(Libraries.User32, SetLastError = true)]
        public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);
    }
}
