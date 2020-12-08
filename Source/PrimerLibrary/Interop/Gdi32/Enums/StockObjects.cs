// <copyright file="StockObjects.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

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
        /// 
        /// </summary>
        public enum StockObjects
        {
            /// <summary>
            /// The white brush
            /// </summary>
            WHITE_BRUSH = 0,

            /// <summary>
            /// The ltgray brush
            /// </summary>
            LTGRAY_BRUSH = 1,

            /// <summary>
            /// The gray brush
            /// </summary>
            GRAY_BRUSH = 2,

            /// <summary>
            /// The dkgray brush
            /// </summary>
            DKGRAY_BRUSH = 3,

            /// <summary>
            /// The black brush
            /// </summary>
            BLACK_BRUSH = 4,

            /// <summary>
            /// The null brush
            /// </summary>
            NULL_BRUSH = 5,

            /// <summary>
            /// The hollow brush
            /// </summary>
            HOLLOW_BRUSH = NULL_BRUSH,

            /// <summary>
            /// The white pen
            /// </summary>
            WHITE_PEN = 6,

            /// <summary>
            /// The black pen
            /// </summary>
            BLACK_PEN = 7,

            /// <summary>
            /// The null pen
            /// </summary>
            NULL_PEN = 8,

            /// <summary>
            /// The oem fixed font
            /// </summary>
            OEM_FIXED_FONT = 10,

            /// <summary>
            /// The ANSI fixed font
            /// </summary>
            ANSI_FIXED_FONT = 11,

            /// <summary>
            /// The ANSI variable font
            /// </summary>
            ANSI_VAR_FONT = 12,

            /// <summary>
            /// The system font
            /// </summary>
            SYSTEM_FONT = 13,

            /// <summary>
            /// The device default font
            /// </summary>
            DEVICE_DEFAULT_FONT = 14,

            /// <summary>
            /// The default palette
            /// </summary>
            DEFAULT_PALETTE = 15,

            /// <summary>
            /// The system fixed font
            /// </summary>
            SYSTEM_FIXED_FONT = 16,

            /// <summary>
            /// The default GUI font
            /// </summary>
            DEFAULT_GUI_FONT = 17,

            /// <summary>
            /// The dc brush
            /// </summary>
            DC_BRUSH = 18,

            /// <summary>
            /// The dc pen
            /// </summary>
            DC_PEN = 19,
        }
    }
}
