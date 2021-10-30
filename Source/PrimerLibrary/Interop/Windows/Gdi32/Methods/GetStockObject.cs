// <copyright file="GetStockObject.cs" company="Shkyrockett" >
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
        internal static partial class Gdi32
        {
            /// <summary>
            /// The GetStockObject function retrieves a handle to one of the stock pens, brushes, fonts, or palettes.
            /// </summary>
            /// <param name="fnObject">The type of stock object. This parameter can be one of the following values.</param>
            /// <returns>
            /// If the function succeeds, the return value is a handle to the requested logical object.
            /// If the function fails, the return value is NULL.
            /// </returns>
            /// <remarks>
            /// It is not recommended that you employ this method to obtain the current font used by dialogs and windows. Instead, use the SystemParametersInfo function with the SPI_GETNONCLIENTMETRICS parameter to retrieve the current font. SystemParametersInfo will take into account the current theme and provides font information for captions, menus, and message dialogs.
            /// Use the DKGRAY_BRUSH, GRAY_BRUSH, and LTGRAY_BRUSH stock objects only in windows with the CS_HREDRAW and CS_VREDRAW styles. Using a gray stock brush in any other style of window can lead to misalignment of brush patterns after a window is moved or sized. The origins of stock brushes cannot be adjusted.
            /// The HOLLOW_BRUSH and NULL_BRUSH stock objects are equivalent.
            /// It is not necessary (but it is not harmful) to delete stock objects by calling DeleteObject.
            /// Both DC_BRUSH and DC_PEN can be used interchangeably with other stock objects like BLACK_BRUSH and BLACK_PEN. For information on retrieving the current pen or brush color, see GetDCBrushColor and GetDCPenColor. See Setting the Pen or Brush Color for an example of setting colors. The GetStockObject function with an argument of DC_BRUSH or DC_PEN can be used interchangeably with the SetDCPenColor and SetDCBrushColor functions.
            /// </remarks>
            /// <acknowledgment>
            /// https://docs.microsoft.com/windows/win32/api/wingdi/nf-wingdi-getstockobject
            /// </acknowledgment>
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            [DllImport(Libraries.Gdi32, EntryPoint = "GetStockObject")]
            private static extern IntPtr GetStockObject(StockObjects fnObject);
        }
    }
}
