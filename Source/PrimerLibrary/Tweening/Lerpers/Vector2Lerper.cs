// <copyright file="Vector2Lerper.cs" company="Shkyrockett" >
//     Copyright © 2013 - 2018 Jacob Albano. All rights reserved.
// </copyright>
// <author id="jacobalbano">Jacob Albano</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks> Based on: https://bitbucket.org/jacobalbano/glide </remarks>

using System.Numerics;
using static System.MathF;

namespace PrimerLibrary
{
    /// <summary>
    /// The vector2d lerper class.
    /// </summary>
    public class Vector2Lerper
        : IMemberLerper
    {
        /// <summary>
        /// The from.
        /// </summary>
        private Vector2 from;

        /// <summary>
        /// The to.
        /// </summary>
        private Vector2 to;

        /// <summary>
        /// The range.
        /// </summary>
        private Vector2 range;

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="fromValue">The fromValue.</param>
        /// <param name="toValue">The toValue.</param>
        /// <param name="behavior">The behavior.</param>
        public void Initialize(object fromValue, object toValue, LerpBehaviors behavior)
        {
            from = (Vector2)fromValue;
            to = (Vector2)toValue;
            range = new Vector2(to.X - from.X, to.Y - from.Y);
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

            if (behavior.HasFlag(LerpBehaviors.Round))
            {
                i = Round(i);
                j = Round(j);
            }

            var current = (Vector2)currentValue;
            return new Vector2(
                (Abs(range.X) < float.Epsilon) ? current.X : i,
                (Abs(range.Y) < float.Epsilon) ? current.Y : j);
        }
    }
}
