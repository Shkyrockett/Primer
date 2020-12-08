// <copyright file="WMTouchEventArgs.cs" company="Shkyrockett" >
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

internal static partial class Interop
{
    /// <summary>
    /// 
    /// </summary>
    internal static partial class User32
    {
        /// <summary>
        /// 
        /// </summary>
        public class WMTouchEventArgs
            : EventArgs
        {
            /// <summary>
            /// The touch x client coordinate in pixels
            /// </summary>
            private int x;

            /// <summary>
            /// The touch y client coordinate in pixels
            /// </summary>
            private int y;

            /// <summary>
            /// The contact identifier
            /// </summary>
            private int id;

            /// <summary>
            /// The mask which fields in the structure are valid
            /// </summary>
            private int mask;

            /// <summary>
            /// The flags
            /// </summary>
            private TouchEventFlags flags;

            /// <summary>
            /// The touch event time
            /// </summary>
            private int time;

            /// <summary>
            /// The x size of the contact area in pixels
            /// </summary>
            private int contactX;

            /// <summary>
            /// The y size of the contact area in pixels
            /// </summary>
            private int contactY;

            /// <summary>
            /// Gets or sets the touch x client coordinate in pixels.
            /// </summary>
            /// <value>
            /// The location x.
            /// </value>
            public int LocationX { get { return x; } set { x = value; } }

            /// <summary>
            /// Gets or sets the touch y client coordinate in pixels.
            /// </summary>
            /// <value>
            /// The location y.
            /// </value>
            public int LocationY { get { return y; } set { y = value; } }

            /// <summary>
            /// Gets or sets the contact identifier.
            /// </summary>
            /// <value>
            /// The identifier.
            /// </value>
            public int Id { get { return id; } set { id = value; } }

            /// <summary>
            /// Gets or sets the mask which fields in the structure are valid.
            /// </summary>
            /// <value>
            /// The mask.
            /// </value>
            public int Mask { get { return mask; } set { mask = value; } }

            /// <summary>
            /// Gets or sets the flags.
            /// </summary>
            /// <value>
            /// The flags.
            /// </value>
            public TouchEventFlags Flags { get { return flags; } set { flags = value; } }

            /// <summary>
            /// Gets or sets the touch event time.
            /// </summary>
            /// <value>
            /// The time.
            /// </value>
            public int Time { get { return time; } set { time = value; } }

            /// <summary>
            /// Gets or sets the x size of the contact area in pixels.
            /// </summary>
            /// <value>
            /// The contact x.
            /// </value>
            public int ContactX { get { return contactX; } set { contactX = value; } }

            /// <summary>
            /// Gets or sets the y size of the contact area in pixels.
            /// </summary>
            /// <value>
            /// The contact y.
            /// </value>
            public int ContactY { get { return contactY; } set { contactY = value; } }

            /// <summary>
            /// Gets a value indicating whether this instance is primary contact.
            /// </summary>
            /// <value>
            ///   <see langword="true" /> if this instance is primary contact; otherwise, <see langword="false" />.
            /// </value>
            public bool IsPrimaryContact { get { return (flags & TouchEventFlags.Primary) != 0; } }

            /// <summary>
            /// Initializes a new instance of the <see cref="WMTouchEventArgs"/> class.
            /// </summary>
            public WMTouchEventArgs()
            {
            }
        }
    }
}
