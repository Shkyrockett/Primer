// <copyright file="GetTextExtentPoint32.cs" company="Shkyrockett" >
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
        internal static partial class Gdi32
        {
            /// <summary>
            /// The GetTextExtentPoint32 function computes the width and height of the specified string of text.
            /// </summary>
            /// <param name="hdc">A handle to the device context.</param>
            /// <param name="lpString">A pointer to a buffer that specifies the text string. The string does not need to be null-terminated, because the c parameter specifies the length of the string.</param>
            /// <param name="cbString">The length of the string pointed to by lpString.</param>
            /// <param name="lpSize">A pointer to a SIZE structure that receives the dimensions of the string, in logical units.</param>
            /// <returns>
            /// If the function succeeds, the return value is nonzero.
            /// If the function fails, the return value is zero.
            /// </returns>
            /// <remarks>
            /// The GetTextExtentPoint32 function uses the currently selected font to compute the dimensions of the string. The width and height, in logical units, are computed without considering any clipping.
            /// Because some devices kern characters, the sum of the extents of the characters in a string may not be equal to the extent of the string.
            /// The calculated string width takes into account the intercharacter spacing set by the SetTextCharacterExtra function and the justification set by SetTextJustification. This is true for both displaying on a screen and for printing. However, if lpDx is set in ExtTextOut, GetTextExtentPoint32 does not take into account either intercharacter spacing or justification. In addition, for EMF, the print result always takes both intercharacter spacing and justification into account.
            /// When dealing with text displayed on a screen, the calculated string width takes into account the intercharacter spacing set by the SetTextCharacterExtra function and the justification set by SetTextJustification. However, if lpDx is set in ExtTextOut, GetTextExtentPoint32 does not take into account either intercharacter spacing or justification. However, when printing with
            /// EMF:
            /// The print result ignores intercharacter spacing, although GetTextExtentPoint32 takes it into account.
            /// The print result takes justification into account, although GetTextExtentPoint32 ignores it.
            /// When this function returns the text extent, it assumes that the text is horizontal, that is, that the escapement is always 0. This is true for both the horizontal and vertical measurements of the text. Even if you use a font that specifies a nonzero escapement, this function doesn't use the angle while it computes the text extent. The app must convert it explicitly. However, when the graphics mode is set to GM_ADVANCED and the character orientation is 90 degrees from the print orientation, the values that this function return do not follow this rule. When the character orientation and the print orientation match for a given string, this function returns the dimensions of the string in the SIZE structure as { cx : 116, cy : 18 }. When the character orientation and the print orientation are 90 degrees apart for the same string, this function returns the dimensions of the string in the SIZE structure as { cx : 18, cy : 116 }.
            /// GetTextExtentPoint32 doesn't consider "\n" (new line) or "\r\n" (carriage return and new line) characters when it computes the height of a text string.
            /// </remarks>
            /// <acknowledgment>
            /// https://docs.microsoft.com/windows/win32/api/wingdi/nf-wingdi-gettextextentpoint32w
            /// </acknowledgment>
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            [DllImport(Libraries.Gdi32, CharSet = CharSet.Unicode)]
            private static extern bool GetTextExtentPoint32(IntPtr hdc, string lpString, int cbString, out Size lpSize);
        }
    }
}
