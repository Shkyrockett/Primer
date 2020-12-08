// <copyright file="GestureConfigurationFlags.cs" company="Shkyrockett" >
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Gesture configuration flags
        /// </summary>
        [Flags]
        public enum GestureConfigurationFlags
        {
            /// <summary>
            /// The gc allgestures
            /// </summary>
            GC_ALLGESTURES = 0x00000001,

            /// <summary>
            /// The gc zoom
            /// </summary>
            GC_ZOOM = 0x00000001,

            /// <summary>
            /// The gc pan
            /// </summary>
            GC_PAN = 0x00000001,

            /// <summary>
            /// The gc pan with single finger vertically
            /// </summary>
            GC_PAN_WITH_SINGLE_FINGER_VERTICALLY = 0x00000002,

            /// <summary>
            /// The gc pan with single finger horizontally
            /// </summary>
            GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY = 0x00000004,

            /// <summary>
            /// The gc pan with gutter
            /// </summary>
            GC_PAN_WITH_GUTTER = 0x00000008,

            /// <summary>
            /// The gc pan with inertia
            /// </summary>
            GC_PAN_WITH_INERTIA = 0x00000010,

            /// <summary>
            /// The gc rotate
            /// </summary>
            GC_ROTATE = 0x00000001,

            /// <summary>
            /// The gc twofingertap
            /// </summary>
            GC_TWOFINGERTAP = 0x00000001,

            /// <summary>
            /// The gc pressandtap
            /// </summary>
            GC_PRESSANDTAP = 0x00000001,
        }
    }
}
