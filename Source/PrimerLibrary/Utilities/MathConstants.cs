using static System.MathF;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public static class MathConstants
    {
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
