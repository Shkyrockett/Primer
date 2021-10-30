// <copyright file="PointS.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System.Drawing;
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
            /// 
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct PointS
            {
                /// <summary>
                /// The x
                /// </summary>
                public short x;

                /// <summary>
                /// The y
                /// </summary>
                public short y;

                /// <summary>
                /// Performs an implicit conversion from <see cref="PointS"/> to <see cref="Point"/>.
                /// </summary>
                /// <param name="point">The point.</param>
                /// <returns>
                /// The result of the conversion.
                /// </returns>
                public static implicit operator Point(PointS point) => new(point.x, point.y);

                /// <summary>
                /// Performs an implicit conversion from <see cref="PointS"/> to <see cref="Point"/>.
                /// </summary>
                /// <param name="point">The point.</param>
                /// <returns>
                /// The result of the conversion.
                /// </returns>
                public static implicit operator PointF(PointS point) => new(point.x, point.y);
            }
        }
    }
}
