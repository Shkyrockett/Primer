// <copyright file="GestureId.cs" company="Shkyrockett" >
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
        /// Gesture IDs
        /// </summary>
        public enum GestureId
        {
            /// <summary>
            /// GID_BEGIN
            /// </summary>
            Begin = 1,

            /// <summary>
            /// GID_END
            /// </summary>
            End = 2,

            /// <summary>
            /// GID_ZOOM
            /// </summary>
            Zoom = 3,

            /// <summary>
            /// GID_PAN
            /// </summary>
            Pan = 4,

            /// <summary>
            /// GID_ROTATE
            /// </summary>
            Rotate = 5,

            /// <summary>
            /// GID_TWOFINGERTAP
            /// </summary>
            TwoFingerTap = 6,

            /// <summary>
            /// GID_PRESSANDTAP
            /// </summary>
            PressAndTap = 7
        }
    }
}
