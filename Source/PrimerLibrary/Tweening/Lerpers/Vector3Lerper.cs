﻿// <copyright file="Vector3Lerper.cs" company="Shkyrockett" >
//     Copyright © 2013 - 2018 Jacob Albano. All rights reserved.
// </copyright>
// <author id="jacobalbano">Jacob Albano</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks> Based on: https://github.com/jacobalbano/glide </remarks>

using System.Numerics;
using static System.MathF;

namespace PrimerLibrary
{
    /// <summary>
    /// The vector3d lerper class.
    /// </summary>
    public class Vector3Lerper
        : IMemberLerper
    {
        /// <summary>
        /// The from.
        /// </summary>
        private Vector3 from;

        /// <summary>
        /// The to.
        /// </summary>
        private Vector3 to;

        /// <summary>
        /// The range.
        /// </summary>
        private Vector3 range;

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="fromValue">The fromValue.</param>
        /// <param name="toValue">The toValue.</param>
        /// <param name="behavior">The behavior.</param>
        public void Initialize(object fromValue, object toValue, LerpBehaviors behavior)
        {
            from = (Vector3)fromValue;
            to = (Vector3)toValue;
            range = new Vector3(to.X - from.X, to.Y - from.Y, to.Z - from.Z);
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="fromValue">The fromValue.</param>
        /// <param name="toValue">The toValue.</param>
        /// <param name="behavior">The behavior.</param>
        public void Initialize(Vector3 fromValue, Vector3 toValue, LerpBehaviors behavior)
        {
            _ = behavior;
            from = fromValue;
            to = toValue;
            range = new Vector3(to.X - from.X, to.Y - from.Y, to.Z - from.Z);
        }

        /// <summary>
        /// The interpolate.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <param name="currentValue">The currentValue.</param>
        /// <param name="behavior">The behavior.</param>
        /// <returns>The <see cref="object"/>.</returns>
        public object Interpolate(float t, object currentValue, LerpBehaviors behavior)
        {
            var i = from.X + (range.X * t);
            var j = from.Y + (range.Y * t);
            var k = from.Z + (range.Z * t);

            if (behavior.HasFlag(LerpBehaviors.Round))
            {
                i = Round(i);
                j = Round(j);
                k = Round(k);
            }

            var current = (Vector3)currentValue;
            return new Vector3(
                (Abs(range.X) < float.Epsilon) ? current.X : i,
                (Abs(range.Y) < float.Epsilon) ? current.Y : j,
                (Abs(range.Z) < float.Epsilon) ? current.Z : k);
        }
    }
}
