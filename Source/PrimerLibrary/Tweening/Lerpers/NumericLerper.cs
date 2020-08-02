using System;
using System.Globalization;
using static PrimerLibrary.MathConstants;
using static System.MathF;

namespace PrimerLibrary
{
    /// <summary>
    /// The numeric lerper class.
    /// </summary>
    public class NumericLerper
        : IMemberLerper
    {
        #region Fields
        /// <summary>
        /// The from.
        /// </summary>
        private float from;

        /// <summary>
        /// The to.
        /// </summary>
        private float to;

        /// <summary>
        /// The range.
        /// </summary>
        private float range;
        #endregion Fields

        /// <summary>
        /// Initialize.
        /// </summary>
        /// <param name="fromValue">The fromValue.</param>
        /// <param name="toValue">The toValue.</param>
        /// <param name="behavior">The behavior.</param>
        public void Initialize(object fromValue, object toValue, LerpBehaviors behavior)
        {
            from = Convert.ToSingle(fromValue, CultureInfo.InvariantCulture);
            to = Convert.ToSingle(toValue, CultureInfo.InvariantCulture);
            range = to - from;

            if (behavior.HasFlag(LerpBehaviors.Rotation))
            {
                var angle = from;
                if (behavior.HasFlag(LerpBehaviors.RotationRadians))
                {
                    angle *= Degree;
                }

                if (angle < 0d)
                {
                    angle = 360f + angle;
                }

                var r = angle + range;
                var d = r - angle;
                var a = Abs(d);

                range = a >= 180f ? (360f - a) * (d > 0f ? -1f : 1f) : d;
            }
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
            var value = from + (range * t);
            if (behavior.HasFlag(LerpBehaviors.Rotation))
            {
                if (behavior.HasFlag(LerpBehaviors.RotationRadians))
                {
                    value *= Degree;
                }

                value %= 360f;

                if (value < 0)
                {
                    value += 360f;
                }

                if (behavior.HasFlag(LerpBehaviors.RotationRadians))
                {
                    value *= Radian;
                }
            }

            if (behavior.HasFlag(LerpBehaviors.Round))
            {
                value = Round(value);
            }

            var type = currentValue?.GetType();
            return Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
        }
    }
}
