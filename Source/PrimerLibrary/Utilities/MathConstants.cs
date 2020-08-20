using static System.MathF;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class MathConstants
    {
        /// <summary>
        /// The limit scale.
        /// </summary>
        public const float LimitScale = 1f / 2f;

        /// <summary>
        /// The index scale.
        /// </summary>
        public const float IndexScale = 1f / 2f;

        /// <summary>
        /// The exponent scale.
        /// </summary>
        public const float ExponentScale = 3f / 4f;

        /// <summary>
        /// The exponent offset scale.
        /// </summary>
        public const float ExponentOffsetScale = 1f / 4f;

        /// <summary>
        /// The sequence scale.
        /// </summary>
        public const float SequenceScale = 3f / 4f;

        /// <summary>
        /// The sequence offset scale.
        /// </summary>
        public const float SequenceOffsetScale = 1f / 4f;

        /// <summary>
        /// The zero.
        /// </summary>
        public const float Zero = 0f;

        /// <summary>
        /// The one quarter.
        /// </summary>
        public const float OneQuarter = 1f / 4f;

        /// <summary>
        /// The one third.
        /// </summary>
        public static float OneThird = 1f / 3f;

        /// <summary>
        /// The one half.
        /// </summary>
        public static float OneHalf = 1f / 2f;

        /// <summary>
        /// The three quarters.
        /// </summary>
        public static float ThreeQuarters = 3f / 4f;

        /// <summary>
        /// The two thirds.
        /// </summary>
        public static float TwoThirds = 2f / 3f;

        /// <summary>
        /// The one.
        /// </summary>
        public static float One = 1f;

        /// <summary>
        /// The one and a half.
        /// </summary>
        public static float OneAndAHalf = 3f / 2f;

        /// <summary>
        /// The two.
        /// </summary>
        public static float Two = 2f;

        /// <summary>
        /// Represents the ratio of the radius of a circle to the first quarter of that circle.
        /// One quarter Tau or half Pi. A right angle in mathematics.
        /// </summary>
        /// <remarks><para>PI / 2</para></remarks>
        public const float HalfPi = 0.5f * PI; // 1.5707963267948966192313216916398d;

        /// <summary>
        /// Represents the ratio of the circumference of a circle to its radius, specified
        /// by the proposed constant, τ (Tau).
        /// One Tau or two Pi.
        /// </summary>
        /// <value>≈6.28318...</value>
        public const float Tau = 2f * PI; // 6.283185307179586476925286766559d;

        /// <summary>
        /// One Radian.
        /// </summary>
        /// <remarks><para>PI / 180</para></remarks>
        public const float Radian = PI / 180f; // 0.01745329251994329576923690768489d;

        /// <summary>
        /// One half radian.
        /// </summary>
        public const float HalfRadian = PI / 90f;

        /// <summary>
        /// One degree.
        /// </summary>
        /// <remarks><para>180 / PI</para></remarks>
        public const float Degree = 180f / PI; // 57.295779513082320876798154814105d;
    }
}
