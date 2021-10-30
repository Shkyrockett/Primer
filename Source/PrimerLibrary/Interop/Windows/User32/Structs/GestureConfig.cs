// <copyright file="GestureConfig.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

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
            /// Gesture configuration structure - Used in SetGestureConfig and GetGestureConfig - Note that any setting not included in either GESTURECONFIG.dwWant or GESTURECONFIG.dwBlock will use the parent window's preferences or system defaults. Touch API defined structures [winuser.h]
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct GestureConfig
            {
                /// <summary>
                /// The gesture identifier
                /// </summary>
                public GestureId dwID;

                /// <summary>
                /// The settings related to gesture ID that are to be turned on
                /// </summary>
                public GestureConfigurationFlags dwWant;

                /// <summary>
                /// The settings related to gesture ID that are to be turned off
                /// </summary>
                public GestureConfigurationFlags dwBlock;

                /// <summary>
                /// Gets the size.
                /// </summary>
                /// <returns></returns>
                public static int GetSize() => Marshal.SizeOf(new GestureConfig());
            }
        }
    }
}
