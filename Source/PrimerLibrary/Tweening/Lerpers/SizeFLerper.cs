// <copyright file="Size2DLerper.cs" company="Shkyrockett" >
//     Copyright © 2013 - 2018 Jacob Albano. All rights reserved.
// </copyright>
// <author id="jacobalbano">Jacob Albano</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks> Based on: https://bitbucket.org/jacobalbano/glide </remarks>

using System.Drawing;
using static System.MathF;

namespace PrimerLibrary
{
    /// <summary>
    /// The size2d lerper class.
    /// </summary>
    public class SizeFLerper
        : IMemberLerper
    {
        /// <summary>
        /// The from.
        /// </summary>
        private SizeF from;

        /// <summary>
        /// The to.
        /// </summary>
        private SizeF to;

        /// <summary>
        /// The range.
        /// </summary>
        private SizeF range;

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="fromValue">The fromValue.</param>
        /// <param name="toValue">The toValue.</param>
        /// <param name="behavior">The behavior.</param>
        public void Initialize(object fromValue, object toValue, LerpBehaviors behavior)
        {
            from = (SizeF)fromValue;
            to = (SizeF)toValue;
            range = new SizeF(to.Width - from.Width, to.Height - from.Height);
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
            var width = from.Width + (range.Width * t);
            var height = from.Height + (range.Height * t);

            if (behavior.HasFlag(LerpBehaviors.Round))
            {
                width = Round(width);
                height = Round(height);
            }

            var current = (SizeF)currentValue;
            return new SizeF(
                (Abs(range.Width) < float.Epsilon) ? current.Width : width,
                (Abs(range.Height) < float.Epsilon) ? current.Height : height);
        }
    }
}
