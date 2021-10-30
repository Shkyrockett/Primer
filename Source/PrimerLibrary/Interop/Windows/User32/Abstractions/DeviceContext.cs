// <copyright file="DeviceContext.cs" company="Shkyrockett" >
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
            /// 
            /// </summary>
            public static class DeviceContext
            {
                /// <summary>
                /// Gets the Device Context.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <returns></returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
                public static IntPtr GetDC(IntPtr handle) => User32.GetDC(handle);

                /// <summary>
                /// Releases the Device Context.
                /// </summary>
                /// <param name="handle">The handle.</param>
                /// <param name="dcHandle">The dc handle.</param>
                /// <returns></returns>
                [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
                public static bool ReleaseDC(IntPtr handle, IntPtr dcHandle) => User32.ReleaseDC(handle, dcHandle);
            }
        }
    }
}
