// <copyright file="Drawing.cs" company="Shkyrockett" >
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
using System.Drawing;
using System.Runtime.CompilerServices;

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
        public static class Drawing
        {
            /// <summary>
            /// Selects the object.
            /// </summary>
            /// <param name="handle">The handle.</param>
            /// <param name="objectHandle">The object handle.</param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static IntPtr SelectObject(IntPtr handle, IntPtr objectHandle) => Gdi32.SelectObject(handle, objectHandle);

            /// <summary>
            /// Gets the stock object.
            /// </summary>
            /// <param name="stockObject">The stock object.</param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static IntPtr GetStockObject(StockObjects stockObject) => Gdi32.GetStockObject(stockObject);

            /// <summary>
            /// Texts the out.
            /// </summary>
            /// <param name="handle">The handle.</param>
            /// <param name="xStart">The x start.</param>
            /// <param name="yStart">The y start.</param>
            /// <param name="text">The text.</param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool TextOut(IntPtr handle, int xStart, int yStart, string text) => Gdi32.TextOut(handle, xStart, yStart, text, text.Length);

            /// <summary>
            /// Texts the out.
            /// </summary>
            /// <param name="handle">The handle.</param>
            /// <param name="xStart">The x start.</param>
            /// <param name="yStart">The y start.</param>
            /// <param name="text">The text.</param>
            /// <param name="len">The length.</param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool TextOut(IntPtr handle, int xStart, int yStart, IntPtr text, int len) => Gdi32.TextOut(handle, xStart, yStart, text, len);

            /// <summary>
            /// Gets the text extent point.
            /// </summary>
            /// <param name="dcHandle">The dc handle.</param>
            /// <param name="text">The text.</param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static Size GetTextExtentPoint(IntPtr dcHandle, string text) => GetTextExtentPoint32(dcHandle, text, text.Length, out var lpSize) ? lpSize : Size.Empty;
        }
    }
}
