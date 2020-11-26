// <copyright file="Point2DLerper.cs" company="Shkyrockett" >
//     Copyright © 2013 - 2018 Jacob Albano. All rights reserved.
// </copyright>
// <author id="jacobalbano">Jacob Albano</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks> Based on: https://github.com/jacobalbano/glide </remarks>

using System.Drawing;
using static System.MathF;

namespace PrimerLibrary
{
    /// <summary>
    /// The point2d lerper class.
    /// </summary>
    public class PointFLerper
        : IMemberLerper
    {
        /// <summary>
        /// The from.
        /// </summary>
        private PointF from;

        /// <summary>
        /// The to.
        /// </summary>
        private PointF to;

        /// <summary>
        /// The range.
        /// </summary>
        private PointF range;

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="fromValue">The fromValue.</param>
        /// <param name="toValue">The toValue.</param>
        /// <param name="behavior">The behavior.</param>
        public void Initialize(object fromValue, object toValue, LerpBehaviors behavior)
        {
            from = (PointF)fromValue;
            to = (PointF)toValue;
            range = new PointF(to.X - from.X, to.Y - from.Y);
        }

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="fromValue">The fromValue.</param>
        /// <param name="toValue">The toValue.</param>
        /// <param name="behavior">The behavior.</param>
        public void Initialize(PointF fromValue, PointF toValue, LerpBehaviors behavior)
        {
            _ = behavior;
            from = fromValue;
            to = toValue;
            range = new PointF(to.X - from.X, to.Y - from.Y);
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
            var x = from.X + (range.X * t);
            var y = from.Y + (range.Y * t);

            if (behavior.HasFlag(LerpBehaviors.Round))
            {
                x = Round(x);
                y = Round(y);
            }

            var current = (PointF)currentValue;
            return new PointF(
                (Abs(range.X) < float.Epsilon) ? current.X : x,
                (Abs(range.Y) < float.Epsilon) ? current.X : y);
        }
    }
}
