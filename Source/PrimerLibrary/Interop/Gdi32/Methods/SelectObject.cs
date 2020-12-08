// <copyright file="SelectObject.cs" company="Shkyrockett" >
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
        /// The SelectObject function selects an object into the specified device context (DC). The new object replaces the previous object of the same type.
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="hgdiobj">A handle to the object to be selected. The specified object must have been created by using one of the following functions.</param>
        /// <returns>
        /// If the selected object is not a region and the function succeeds, the return value is a handle to the object being replaced. If the selected object is a region and the function succeeds, the return value is one of the following values.
        /// If an error occurs and the selected object is not a region, the return value is NULL. Otherwise, it is HGDI_ERROR.
        /// </returns>
        /// <remarks>
        /// This function returns the previously selected object of the specified type. An application should always replace a new object with the original, default object after it has finished drawing with the new object.
        /// An application cannot select a single bitmap into more than one DC at a time.
        /// ICM: If the object being selected is a brush or a pen, color management is performed.
        /// </remarks>
        /// <acknowledgment>
        /// https://docs.microsoft.com/windows/win32/api/wingdi/nf-wingdi-selectobject
        /// </acknowledgment>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [DllImport(Libraries.Gdi32, EntryPoint = "SelectObject")]
        private static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);
    }
}
