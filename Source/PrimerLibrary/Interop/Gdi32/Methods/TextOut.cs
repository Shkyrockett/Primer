// <copyright file="TextOut.cs" company="Shkyrockett" >
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
    internal static partial class Gdi32
    {
        /// <summary>
        /// The TextOut function writes a character string at the specified location, using the currently selected font, background color, and text color.
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="nXStart">The x-coordinate, in logical coordinates, of the reference point that the system uses to align the string.</param>
        /// <param name="nYStart">The y-coordinate, in logical coordinates, of the reference point that the system uses to align the string.</param>
        /// <param name="lpString">A pointer to the string to be drawn. The string does not need to be zero-terminated, because cchString specifies the length of the string.</param>
        /// <param name="cbString">The length of the string pointed to by lpString, in characters.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The interpretation of the reference point depends on the current text-alignment mode. An application can retrieve this mode by calling the GetTextAlign function; an application can alter this mode by calling the SetTextAlign function. You can use the following values for text alignment. Only one flag can be chosen from those that affect horizontal and vertical alignment. In addition, only one of the two flags that alter the current position can be chosen.
        /// By default, the current position is not used or updated by this function. However, an application can call the SetTextAlign function with the fMode parameter set to TA_UPDATECP to permit the system to use and update the current position each time the application calls TextOut for a specified device context. When this flag is set, the system ignores the nXStart and nYStart parameters on subsequent TextOut calls.
        /// When the TextOut function is placed inside a path bracket, the system generates a path for the TrueType text that includes each character plus its character box. The region generated is the character box minus the text, rather than the text itself. You can obtain the region enclosed by the outline of the TrueType text by setting the background mode to transparent before placing the TextOut function in the path bracket. Following is sample code that demonstrates this procedure.
        /// </remarks>
        /// <acknowledgment>
        /// https://docs.microsoft.com/windows/win32/api/wingdi/nf-wingdi-textoutw
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DllImport(Libraries.Gdi32, CharSet = CharSet.Auto)]
        private static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart, string lpString, int cbString);

        /// <summary>
        /// The TextOut function writes a character string at the specified location, using the currently selected font, background color, and text color.
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <param name="nXStart">The x-coordinate, in logical coordinates, of the reference point that the system uses to align the string.</param>
        /// <param name="nYStart">The y-coordinate, in logical coordinates, of the reference point that the system uses to align the string.</param>
        /// <param name="lpString">A pointer to the string to be drawn. The string does not need to be zero-terminated, because cchString specifies the length of the string.</param>
        /// <param name="cbString">The length of the string pointed to by lpString, in characters.</param>
        /// <returns>
        /// If the function succeeds, the return value is nonzero.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The interpretation of the reference point depends on the current text-alignment mode. An application can retrieve this mode by calling the GetTextAlign function; an application can alter this mode by calling the SetTextAlign function. You can use the following values for text alignment. Only one flag can be chosen from those that affect horizontal and vertical alignment. In addition, only one of the two flags that alter the current position can be chosen.
        /// By default, the current position is not used or updated by this function. However, an application can call the SetTextAlign function with the fMode parameter set to TA_UPDATECP to permit the system to use and update the current position each time the application calls TextOut for a specified device context. When this flag is set, the system ignores the nXStart and nYStart parameters on subsequent TextOut calls.
        /// When the TextOut function is placed inside a path bracket, the system generates a path for the TrueType text that includes each character plus its character box. The region generated is the character box minus the text, rather than the text itself. You can obtain the region enclosed by the outline of the TrueType text by setting the background mode to transparent before placing the TextOut function in the path bracket. Following is sample code that demonstrates this procedure.
        /// </remarks>
        /// <acknowledgment>
        /// https://docs.microsoft.com/windows/win32/api/wingdi/nf-wingdi-textoutw
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DllImport(Libraries.Gdi32, CharSet = CharSet.Auto)]
        private static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart, IntPtr lpString, int cbString);
    }
}
