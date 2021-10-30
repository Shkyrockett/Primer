// <copyright file="GetTouchInputInfo.cs" company="Shkyrockett" >
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
        internal static partial class User32
        {
            /// <summary>
            /// Gets the touch input information.
            /// </summary>
            /// <param name="hTouchInput">The h touch input.</param>
            /// <param name="cInputs">The c inputs.</param>
            /// <param name="pInputs">The p inputs.</param>
            /// <param name="cbSize">Size of the cb.</param>
            /// <returns></returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
            [DllImport(Libraries.User32)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetTouchInputInfo(IntPtr hTouchInput, int cInputs, [In, Out] TouchInput[] pInputs, int cbSize);
        }
    }
}
