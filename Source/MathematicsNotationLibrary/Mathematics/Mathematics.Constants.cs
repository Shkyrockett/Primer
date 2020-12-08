// <copyright file="Mathematics.Constants.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using static MathematicsNotationLibrary.Operations;
using static System.MathF;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// The Mathematics class.
    /// </summary>
    public static partial class Mathematics
    {
        #region Epsilons, Minimums, Maximums
        /// <summary>
        /// The horizontal Value: float.NegativeInfinity.
        /// </summary>
        public const float horizontal = float.NegativeInfinity;

        /// <summary>
        /// Negative zero.
        /// </summary>
        /// <remarks>
        /// <para>Might be useful with Atan2
        /// http://www.charlespetzold.com/blog/2008/09/180741.html</para>
        /// </remarks>
        public const float NegativeZero = -0f;//1 / float.NegativeInfinity;

        /// <summary>
        /// The tolerance Value: 1e-6f.
        /// </summary>
        public const float Tolerance = 1e-6f;

        /// <summary>
        /// The accuracy Value: 15f.
        /// </summary>
        public const float Accuracy = 15f;

        /// <summary>
        /// Error difference for line intersection tests.
        /// </summary>
        public const float Epsilon = 5.684341886080801536e-12f;

        /// <summary>
        /// Smallest such that 1.0 + <see cref="Epsilon"/> != 1.0
        /// </summary>
        public const float DoubleEpsilon = 2.2204460492503131e-016f;

        /// <summary>
        /// Smallest such that 1.0 + <see cref="FloatEpsilon"/> != 1.0
        /// </summary>
        public const float FloatEpsilon = 1.192092896e-07f;

        /// <summary>
        /// The nearest value to 0 Cosine can produce for a right angle.
        /// </summary>
        public static readonly float CosineZeroEpsilon = Cos(Hau); //6.123233995736766E-17;

        /// <summary>
        /// The nearest value to 0 Cosine can produce for a reverse right angle.
        /// </summary>
        public static readonly float CosineNegitiveZeroEpsilon = Cos(Pau);

        /// <summary>
        /// The near zero epsilon Value: 1E-20.
        /// </summary>
        public const double NearZeroEpsilon = 1E-20;

        /// <summary>
        /// Number close to zero, where float.MinValue is -float.MaxValue
        /// </summary>
        public const float FloatMin = 1.175494351e-38f;

        /// <summary>
        /// SlopeMax is a large value "close to infinity" (Close to the largest value allowed for the data
        /// type). Used in the Slope of a LineSeg
        /// </summary>

        public const float SlopeMax = 9223372036854775807f;

        /// <summary>
        /// The float round limit.
        /// </summary>
        public static readonly double DoubleRoundLimit = 1E+16;

        /// <summary>
        /// The default arc tolerance Value: 0.25.
        /// </summary>
        public const float DefaultArcTolerance = 0.25f;

        /// <summary>
        /// The lo range32 Value: 0x7FFF.
        /// </summary>
        public const int LoRange32 = 0x7FFF;

        /// <summary>
        /// The hi range32 Value: 0x7FFF.
        /// </summary>
        public const int HiRange32 = 0x7FFF;

        /// <summary>
        /// The lo range64 Value: 0x3FFFFFFF.
        /// </summary>
        public const long LoRange64 = 0x3FFFFFFF;

        /// <summary>
        /// The hi range64 Value: 0x3FFFFFFFFFFFFFFFL.
        /// </summary>
        public const long HiRange64 = 0x3FFFFFFFFFFFFFFFL;
        #endregion Epsilons, Minimums, Maximums

        #region Pi Derivations
        /// <summary>
        /// Represents the inverse of Pi, or the quotient of one over pi.
        /// </summary>
        public const float InversePi = 1f / PI; // 0.31830988618379067153776752674503f;

        /// <summary>
        /// Represents the inverse of Tau, or the quotient of one over 2 pi.
        /// </summary>
        public const float InverseTau = 1f / Tau; // 0.15915494309189533576888376337251f;

        /// <summary>
        /// Represents the value of the float inverse of Pi, or the quotient of two over pi.
        /// </summary>
        public const float Inverse2OverPi = 2f / PI; // 0.63661977236758134307553505349006f;

        /// <summary>
        /// Represents the ratio of the radius of a circle to the first sixteenth of that circle.
        /// One sixteenth Tau or a eighth Pi.
        /// </summary>
        /// <remarks><para>PI / 8</para></remarks>
        public const float EighthPi = 0.125f * PI; // 0.39269908169872415480783042290994f;

        /// <summary>
        /// Represents the ratio of the radius of a circle to the first eighth of that circle.
        /// One eighth Tau or a quarter Pi. A 45 degree angle.
        /// </summary>
        /// <remarks><para>PI / 4</para></remarks>
        public const float Quart = 0.25f * PI; // 0.78539816339744830961566084581988f;

        /// <summary>
        /// Represents the ratio of the radius of a circle to the first quarter of that circle.
        /// One quarter Tau or half Pi. A right angle in mathematics.
        /// </summary>
        /// <remarks><para>PI / 2</para></remarks>
        public const float Hau = 0.5f * PI; // 1.5707963267948966192313216916398f;

        ///// <summary>
        ///// Represents the ratio of the circumference of a circle to its diameter, specified
        ///// by the constant, π (Pi).
        ///// One half Tau or One Pi.
        ///// </summary>
        ///// <value>≈3.1415926535897931...</value>
        //public const float Pi = PI; // 3.1415926535897932384626433832795f;

        /// <summary>
        /// Represents the ratio of the radius of a circle to the third quarter of that circle.
        /// Three quarter tau, or one and a half pi.
        /// </summary>
        /// <remarks>
        /// <para>Three quarter tau, or one and a half pi are just too long and awkward.
        /// Randal Munro's joke "compromise" works well enough for a name: http://xkcd.com/1292/</para>
        /// </remarks>
        /// <acknowledgment>
        /// Randal Munro http://xkcd.com/1292/ 
        /// </acknowledgment>
        public const float Pau = 1.5f * PI; // 4.7123889803846898576939650749193f;

        ///// <summary>
        ///// Represents the ratio of the circumference of a circle to its radius, specified
        ///// by the proposed constant, τ (Tau).
        ///// One Tau or two Pi.
        ///// </summary>
        ///// <value>≈6.28318...</value>
        //public const float Tau = 2f * PI; // 6.283185307179586476925286766559f;

        /// <summary>
        /// One Radian.
        /// </summary>
        /// <remarks><para>PI / 180</para></remarks>
        public const float Radian = PI / 180f; // 0.01745329251994329576923690768489f;

        /// <summary>
        /// One half radian.
        /// </summary>
        public const float HalfRadian = PI / 90f;

        /// <summary>
        /// One degree.
        /// </summary>
        /// <remarks><para>180 / PI</para></remarks>
        public const float Degree = 180f / PI; // 57.295779513082320876798154814105f;
        #endregion Pi Derivations

        /// <summary>
        /// Represents the golden ratio as specified by the constant, φ (phi).
        /// </summary>
        /// <value>≈1.61803...</value>
        public static readonly float Phi = (1f + Sqrt(5)) * 0.5f; // 1.6180339887498948482045868343656f;

        /// <summary>
        ///  Represents the plastic constant as specified by the constant, ρ.
        /// </summary>
        /// <value>≈1.32471...</value>
        public static readonly float Rho = Root(0.5f + (1f / 6f * Sqrt(23f / 3f)), 3f) + Root(0.5f - (1f / 6f * Sqrt(23f / 3f)), 3f);

        #region Sine Cosine of Regular Angles.
        /// <summary>
        /// The cosine of 0.
        /// </summary>
        public static readonly float Cos0 = Cos(0);

        /// <summary>
        /// The cosine of PI.
        /// </summary>
        public static readonly float CosHau = Cos(Hau);

        /// <summary>
        /// The cosine of Pi.
        /// </summary>
        public static readonly float CosPi = Cos(PI);

        /// <summary>
        /// The cosine of Pau.
        /// </summary>
        public static readonly float CosPau = Cos(Pau);

        /// <summary>
        /// The sine of 0.
        /// </summary>
        public static readonly float Sin0 = Sin(0);

        /// <summary>
        /// The sine of half Pi.
        /// </summary>
        public static readonly float SinHau = Sin(Hau);

        /// <summary>
        /// The sine of Pi.
        /// </summary>
        public static readonly float SinPi = Sin(PI);

        /// <summary>
        /// The sine of Pau.
        /// </summary>
        public static readonly float SinPau = Sin(Pau);
        #endregion

        #region Roots
        /// <summary>
        /// Represents the inverse square root of 2.
        /// </summary>
        public static readonly float InvSqrt2 = 1f / Sqrt(2f); // 0.70710678118654752440084436210485f;

        /// <summary>
        /// Represents the float inverse square root of Pi.
        /// </summary>
        public static readonly float Inv2SqrtPi = 2f / Sqrt(PI); // 1.1283791670955125738961589031215f;

        /// <summary>
        /// Represents the constant value of the square root of 2.
        /// </summary>
        /// <value>≈1.41421...</value>
        public static readonly float Sqrt2 = Sqrt(2f); // 1.4142135623730950488016887242097f;

        /// <summary>
        /// Represents the constant value of the square root of 3.
        /// </summary>
        /// <value>≈1.73205...</value>
        public static readonly float Sqrt3 = Sqrt(3f); // 1.7320508075688772935274463415059f;

        /// <summary>
        /// Represents the constant value of the square root of 5.
        /// </summary>
        /// <value>≈2.23606...</value>
        public static readonly float Sqrt5 = Sqrt(5f); // 2.2360679774997896964091736687313f;

        /// <summary>
        /// Represents the constant value of the cube root of 2.
        /// </summary>
        /// <value></value>
        public static readonly float Cbrt2 = Cbrt(2f);

        /// <summary>
        /// Represents the constant value of the cube root of 3.
        /// </summary>
        /// <value></value>
        public static readonly float Cbrt3 = Cbrt(3f);

        /// <summary>
        /// Represents the constant value of the cube root of 5.
        /// </summary>
        /// <value></value>
        public static readonly float Cbrt5 = Cbrt(5f);
        #endregion Roots

        #region Fractions
        /// <summary>
        /// The zero Value: 0.
        /// </summary>
        public const float Zero = 0f;

        /// <summary>
        /// The one sixty fourth Value: 1f / 64f.
        /// </summary>
        public const float OneSixtyfourth = 1f / 64f;

        /// <summary>
        /// The one thirty second Value: 1f / 32f.
        /// </summary>
        public const float OneThirtysecond = 1f / 32f;

        /// <summary>
        /// The three sixty fourth Value: 3f / 64f.
        /// </summary>
        public const float ThreeSixtyfourth = 3f / 64f;

        /// <summary>
        /// The one sixteenth Value: 1f / 16f.
        /// </summary>
        public const float OneSixteenth = 1f / 16f;

        /// <summary>
        /// The five sixty fourth Value: 5f / 64f.
        /// </summary>
        public const float FiveSixtyfourth = 5f / 64f;

        /// <summary>
        /// The three thirty second Value: 3f / 32f.
        /// </summary>
        public const float ThreeThirtysecond = 3f / 32f;

        /// <summary>
        /// The seven sixty fourth Value: 7f / 64f.
        /// </summary>
        public const float SevenSixtyfourth = 7f / 64f;

        /// <summary>
        /// The one eighth Value: 1f / 8f.
        /// </summary>
        public const float OneEighth = 1f / 8f;

        /// <summary>
        /// The nine sixty fourth Value: 9f / 64f.
        /// </summary>
        public const float NineSixtyfourth = 9f / 64f;

        /// <summary>
        /// The five thirty second Value: 5f / 32f.
        /// </summary>
        public const float FiveThirtysecond = 5f / 32f;

        /// <summary>
        /// The eleven sixty fourth Value: 11f / 64f.
        /// </summary>
        public const float ElevenSixtyfourth = 11f / 64f;

        /// <summary>
        /// The three sixteenth Value: 3f / 16f.
        /// </summary>
        public const float ThreeSixteenth = 3f / 16f;

        /// <summary>
        /// The thirteen sixty fourth Value: 13f / 64f.
        /// </summary>
        public const float ThirteenSixtyfourth = 13f / 64f;

        /// <summary>
        /// The seven thirty second Value: 7f / 32f.
        /// </summary>
        public const float SevenThirtysecond = 7f / 32f;

        /// <summary>
        /// The fifteen sixty fourth Value: 15f / 64f.
        /// </summary>
        public const float FifteenSixtyfourth = 15f / 64f;

        /// <summary>
        /// The one quarter Value: 1f / 4f.
        /// </summary>
        public const float OneQuarter = 1f / 4f;

        /// <summary>
        /// The seventeen sixty fourth Value: 17f / 64f.
        /// </summary>
        public const float SeventeenSixtyfourth = 17f / 64f;

        /// <summary>
        /// The nine thirty second Value: 9f / 32f.
        /// </summary>
        public const float NineThirtysecond = 9f / 32f;

        /// <summary>
        /// The nineteen sixty fourth Value: 19f / 64f.
        /// </summary>
        public const float NineteenSixtyfourth = 19f / 64f;

        /// <summary>
        /// The five sixteenth Value: 5f / 16f.
        /// </summary>
        public const float FiveSixteenth = 5f / 16f;

        /// <summary>
        /// The twenty one sixty fourth Value: 21f / 64f.
        /// </summary>
        public const float TwentyoneSixtyfourth = 21f / 64f;

        /// <summary>
        /// The one third Value: 1f / 3f.
        /// </summary>
        public const float OneThird = 1f / 3f;

        /// <summary>
        /// The eleven thirty second Value: 11f / 32f.
        /// </summary>
        public const float ElevenThirtysecond = 11f / 32f;

        /// <summary>
        /// The twenty three sixty fourth Value: 23f / 64f.
        /// </summary>
        public const float TwentythreeSixtyfourth = 23f / 64f;

        /// <summary>
        /// The three eighths Value: 3f / 8f.
        /// </summary>
        public const float ThreeEighths = 3f / 8f;

        /// <summary>
        /// The twenty five sixty fourth Value: 25f / 64f.
        /// </summary>
        public const float TwentyfiveSixtyfourth = 25f / 64f;

        /// <summary>
        /// The thirteen thirty second Value: 13f / 32f.
        /// </summary>
        public const float ThirteenThirtysecond = 13f / 32f;

        /// <summary>
        /// The twenty seven sixty fourth Value: 27f / 64f.
        /// </summary>
        public const float TwentysevenSixtyfourth = 27f / 64f;

        /// <summary>
        /// The seven sixteenth Value: 7f / 16f.
        /// </summary>
        public const float SevenSixteenth = 7f / 16f;

        /// <summary>
        /// The twenty nine sixty fourth Value: 29f / 64f.
        /// </summary>
        public const float TwentynineSixtyfourth = 29f / 64f;

        /// <summary>
        /// The fifteen thirty second Value: 15f / 32f.
        /// </summary>
        public const float FifteenThirtysecond = 15f / 32f;

        /// <summary>
        /// The thirty one sixty fourth Value: 31f / 64f.
        /// </summary>
        public const float ThirtyoneSixtyfourth = 31f / 64f;

        /// <summary>
        /// The one half Value: 1f * 0.5f.
        /// </summary>
        public const float OneHalf = 1f * 0.5f;

        /// <summary>
        /// The thirty three sixty fourth Value: 33f / 64f.
        /// </summary>
        public const float ThirtythreeSixtyfourth = 33f / 64f;

        /// <summary>
        /// The seventeen thirty second Value: 17f / 32f.
        /// </summary>
        public const float SeventeenThirtysecond = 17f / 32f;

        /// <summary>
        /// The thirty five sixty fourth Value: 35f / 64f.
        /// </summary>
        public const float ThirtyfiveSixtyfourth = 35f / 64f;

        /// <summary>
        /// The nine sixteenth Value: 9f / 16f.
        /// </summary>
        public const float NineSixteenth = 9f / 16f;

        /// <summary>
        /// The thirty seven sixty fourth Value: 37f / 64f.
        /// </summary>
        public const float ThirtysevenSixtyfourth = 37f / 64f;

        /// <summary>
        /// The nineteen thirty second Value: 19f / 32f.
        /// </summary>
        public const float NineteenThirtysecond = 19f / 32f;

        /// <summary>
        /// The thirty nine sixty fourth Value: 39f / 64f.
        /// </summary>
        public const float ThirtynineSixtyfourth = 39f / 64f;

        /// <summary>
        /// The five eighths Value: 5f / 8f.
        /// </summary>
        public const float FiveEighths = 5f / 8f;

        /// <summary>
        /// The forty one sixty fourth Value: 41f / 64f.
        /// </summary>
        public const float FortyoneSixtyfourth = 41f / 64f;

        /// <summary>
        /// The twenty one thirty second Value: 21f / 32f.
        /// </summary>
        public const float TwentyoneThirtysecond = 21f / 32f;

        /// <summary>
        /// The two thirds Value: 2f / 3f.
        /// </summary>
        public const float TwoThirds = 2f / 3f;

        /// <summary>
        /// The forty three sixty fourth Value: 43f / 64f.
        /// </summary>
        public const float FortythreeSixtyfourth = 43f / 64f;

        /// <summary>
        /// The eleven sixteenth Value: 11f / 16f.
        /// </summary>
        public const float ElevenSixteenth = 11f / 16f;

        /// <summary>
        /// The forty five sixty fourth Value: 45f / 64f.
        /// </summary>
        public const float FortyfiveSixtyfourth = 45f / 64f;

        /// <summary>
        /// The twenty three thirty second Value: 23f / 32f.
        /// </summary>
        public const float TwentythreeThirtysecond = 23f / 32f;

        /// <summary>
        /// The forty seven sixty fourth Value: 47f / 64f.
        /// </summary>
        public const float FortysevenSixtyfourth = 47f / 64f;

        /// <summary>
        /// The three quarters Value: 3f / 4f.
        /// </summary>
        public const float ThreeQuarters = 3f / 4f;

        /// <summary>
        /// The forty nine sixty fourth Value: 49f / 64f.
        /// </summary>
        public const float FortynineSixtyfourth = 49f / 64f;

        /// <summary>
        /// The twenty five thirty second Value: 25f / 32f.
        /// </summary>
        public const float TwentyfiveThirtysecond = 25f / 32f;

        /// <summary>
        /// The fifty one sixty fourth Value: 51f / 64f.
        /// </summary>
        public const float FiftyoneSixtyfourth = 51f / 64f;

        /// <summary>
        /// The thirteen sixteenth Value: 13f / 16f.
        /// </summary>
        public const float ThirteenSixteenth = 13f / 16f;

        /// <summary>
        /// The fifty three sixty fourth Value: 53f / 64f.
        /// </summary>
        public const float FiftythreeSixtyfourth = 53f / 64f;

        /// <summary>
        /// The twenty seven thirty second Value: 27f / 32f.
        /// </summary>
        public const float TwentysevenThirtysecond = 27f / 32f;

        /// <summary>
        /// The fifty five sixty fourth Value: 55f / 64f.
        /// </summary>
        public const float FiftyfiveSixtyfourth = 55f / 64f;

        /// <summary>
        /// The seven eighths Value: 7f / 8f.
        /// </summary>
        public const float SevenEighths = 7f / 8f;

        /// <summary>
        /// The fifty seven sixty fourth Value: 57f / 64f.
        /// </summary>
        public const float FiftysevenSixtyfourth = 57f / 64f;

        /// <summary>
        /// The twenty nine thirty second Value: 29f / 32f.
        /// </summary>
        public const float TwentynineThirtysecond = 29f / 32f;

        /// <summary>
        /// The fifty nine sixty fourth Value: 59f / 64f.
        /// </summary>
        public const float FiftynineSixtyfourth = 59f / 64f;

        /// <summary>
        /// The fifteen sixteenth Value: 15f / 16f.
        /// </summary>
        public const float FifteenSixteenth = 15f / 16f;

        /// <summary>
        /// The sixty one sixty fourth Value: 61f / 64f.
        /// </summary>
        public const float SixtyoneSixtyfourth = 61f / 64f;

        /// <summary>
        /// The thirty one thirty second Value: 31f / 32f.
        /// </summary>
        public const float ThirtyoneThirtysecond = 31f / 32f;

        /// <summary>
        /// The sixty three sixty fourth Value: 63f / 64f.
        /// </summary>
        public const float SixtythreeSixtyfourth = 63f / 64f;

        /// <summary>
        /// The one Value: 1f.
        /// </summary>
        public const float One = 1f;

        /// <summary>
        /// The one twenty seventh Value: 1 / 27.
        /// </summary>
        public const float OneTwentySeventh = 1f / 27f;

        /// <summary>
        /// The two.
        /// </summary>
        public const float Two = 2f;
        #endregion Fractions

        #region Color Constants
        /// <summary>
        /// The lower limit for percentages.
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const float PercentMin = 0f;

        /// <summary>
        /// The upper limit for percentages.
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const float PercentMax = 1f;

        /// <summary>
        /// The lower limit for H.
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const float HueMin = 0f;

        /// <summary>
        /// The upper limit for H.
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const float HueMax = 360f;

        /// <summary>
        /// The lower limit for R, G, B (integer version).
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const byte RGBMin = 0;

        /// <summary>
        /// The upper limit for R, G, B (integer version).
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const byte RGBMax = 255;

        /// <summary>
        /// The lower limit for R, G, B (integer version).
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const byte CMYKMin = 0;

        /// <summary>
        /// The upper limit for R, G, B (integer version).
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const byte CMYKMax = 100;

        /// <summary>
        /// The lower limit for I in YIQ.
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const float YIQMinI = -0.5957f;

        /// <summary>
        /// The upper limit for I in YIQ.
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const float YIQMaxI = 0.5957f;

        /// <summary>
        /// The lower limit for Q in YIQ.
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const float YIQMinQ = -0.5226f;

        /// <summary>
        /// The upper limit for Q in YIQ.
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const float YIQMaxQ = 0.5226f;

        /// <summary>
        /// The lower limit for U in YUV.
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const float YUVMinU = -0.436f;

        /// <summary>
        /// The upper limit for U in YUV.
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const float YUVMaxU = 0.436f;

        /// <summary>
        /// The lower limit for V in YUV.
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const float YUVMinV = -0.615f;

        /// <summary>
        /// The upper limit for V in YUV.
        /// </summary>
        /// <remarks><para>https://github.com/dystopiancode/colorspace-conversions/</para></remarks>
        public const float YUVMaxV = 0.615f;
        #endregion Color Constants

        #region Logarithms
        ///// <summary>
        /////
        ///// </summary>
        //public const float E = Math.E; // 2.7182818284590452353602874713527f;

        /// <summary>
        /// The base 2 natural log of e.
        /// </summary>
        public const float Log2E = 1.44269504088896340736f;

        /// <summary>
        /// The base 10 natural log of e.
        /// </summary>
        public const float Log10E = 0.434294481903251827651f; // 0.43429448190325182765112891891661f;

        /// <summary>
        /// The base 2 natural log.
        /// </summary>
        public const float LN2 = 0.693147180559945309417f;

        /// <summary>
        /// The base 10 natural log.
        /// </summary>
        public const float LN10 = 2.30258509299404568402f;

        /// <summary>
        /// The Log of Two.
        /// </summary>
        public static readonly float LogTwo = Log(2f);

        /// <summary>
        /// The Log of Ten.
        /// </summary>
        public static readonly float LogTen = Log(10f);

        /// <summary>
        /// The inverse of the log of two.
        /// </summary>
        public static readonly float InverseLogTwo = 1f / LogTwo;
        #endregion Logarithms

        #region Matrices
        /// <summary>
        /// The identity matrix 2x2.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2,
            float m2x1, float m2x2
            ) IdentityMatrix2x2 =
            (1f, 0f,
            0f, 1f);

        /// <summary>
        /// The identity matrix 3x3.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3,
            float m2x1, float m2x2, float m2x3,
            float m3x1, float m3x2, float m3x3
            ) IdentityMatrix3x3 =
            (1f, 0f, 0f,
            0f, 1f, 0f,
            0f, 0f, 1f);

        /// <summary>
        /// The identity matrix 4x4.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4,
            float m2x1, float m2x2, float m2x3, float m2x4,
            float m3x1, float m3x2, float m3x3, float m3x4,
            float m4x1, float m4x2, float m4x3, float m4x4
            ) IdentityMatrix4x4 =
            (1f, 0f, 0f, 0f,
            0f, 1f, 0f, 0f,
            0f, 0f, 1f, 0f,
            0f, 0f, 0f, 1f);

        /// <summary>
        /// The identity matrix 5x5.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5
            ) IdentityMatrix5x5 =
            (1f, 0f, 0f, 0f, 0f,
            0f, 1f, 0f, 0f, 0f,
            0f, 0f, 1f, 0f, 0f,
            0f, 0f, 0f, 1f, 0f,
            0f, 0f, 0f, 0f, 1f);

        /// <summary>
        /// The identity matrix 6x6.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5, float m1x6,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5, float m2x6,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5, float m3x6,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5, float m4x6,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5, float m5x6,
            float m6x1, float m6x2, float m6x3, float m6x4, float m6x5, float m6x6
            ) IdentityMatrix6x6 =
            (1f, 0f, 0f, 0f, 0f, 0f,
            0f, 1f, 0f, 0f, 0f, 0f,
            0f, 0f, 1f, 0f, 0f, 0f,
            0f, 0f, 0f, 1f, 0f, 0f,
            0f, 0f, 0f, 0f, 1f, 0f,
            0f, 0f, 0f, 0f, 0f, 1f);

        /// <summary>
        /// The identity matrix 7x7.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5, float m1x6, float m1x7,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5, float m2x6, float m2x7,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5, float m3x6, float m3x7,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5, float m4x6, float m4x7,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5, float m5x6, float m5x7,
            float m6x1, float m6x2, float m6x3, float m6x4, float m6x5, float m6x6, float m6x7,
            float m7x1, float m7x2, float m7x3, float m7x4, float m7x5, float m7x6, float m7x7
            ) IdentityMatrix7x7 =
            (1f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 1f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 1f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 1f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 1f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 1f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 1f);

        /// <summary>
        /// The identity matrix 8x8.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5, float m1x6, float m1x7, float m1x8,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5, float m2x6, float m2x7, float m2x8,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5, float m3x6, float m3x7, float m3x8,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5, float m4x6, float m4x7, float m4x8,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5, float m5x6, float m5x7, float m5x8,
            float m6x1, float m6x2, float m6x3, float m6x4, float m6x5, float m6x6, float m6x7, float m6x8,
            float m7x1, float m7x2, float m7x3, float m7x4, float m7x5, float m7x6, float m7x7, float m7x8,
            float m8x1, float m8x2, float m8x3, float m8x4, float m8x5, float m8x6, float m8x7, float m8x8
            ) IdentityMatrix8x8 =
            (1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 1f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 1f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 0f, 1f);

        /// <summary>
        /// The identity matrix 9x9.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5, float m1x6, float m1x7, float m1x8, float m1x9,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5, float m2x6, float m2x7, float m2x8, float m2x9,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5, float m3x6, float m3x7, float m3x8, float m3x9,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5, float m4x6, float m4x7, float m4x8, float m4x9,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5, float m5x6, float m5x7, float m5x8, float m5x9,
            float m6x1, float m6x2, float m6x3, float m6x4, float m6x5, float m6x6, float m6x7, float m6x8, float m6x9,
            float m7x1, float m7x2, float m7x3, float m7x4, float m7x5, float m7x6, float m7x7, float m7x8, float m7x9,
            float m8x1, float m8x2, float m8x3, float m8x4, float m8x5, float m8x6, float m8x7, float m8x8, float m8x9,
            float m9x1, float m9x2, float m9x3, float m9x4, float m9x5, float m9x6, float m9x7, float m9x8, float m9x9
            ) IdentityMatrix9x9 =
            (1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 1f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 0f, 1f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 1f);

        /// <summary>
        /// The identity matrix 10x10.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5, float m1x6, float m1x7, float m1x8, float m1x9, float m1x10,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5, float m2x6, float m2x7, float m2x8, float m2x9, float m2x10,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5, float m3x6, float m3x7, float m3x8, float m3x9, float m3x10,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5, float m4x6, float m4x7, float m4x8, float m4x9, float m4x10,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5, float m5x6, float m5x7, float m5x8, float m5x9, float m5x10,
            float m6x1, float m6x2, float m6x3, float m6x4, float m6x5, float m6x6, float m6x7, float m6x8, float m6x9, float m6x10,
            float m7x1, float m7x2, float m7x3, float m7x4, float m7x5, float m7x6, float m7x7, float m7x8, float m7x9, float m7x10,
            float m8x1, float m8x2, float m8x3, float m8x4, float m8x5, float m8x6, float m8x7, float m8x8, float m8x9, float m8x10,
            float m9x1, float m9x2, float m9x3, float m9x4, float m9x5, float m9x6, float m9x7, float m9x8, float m9x9, float m9x10,
            float m10x1, float m10x2, float m10x3, float m10x4, float m10x5, float m10x6, float m10x7, float m10x8, float m10x9, float m10x10
            ) IdentityMatrix10x10 =
            (1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 0f, 1f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 1f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 1f);

        /// <summary>
        /// The identity matrix 11x11.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5, float m1x6, float m1x7, float m1x8, float m1x9, float m1x10, float m1x11,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5, float m2x6, float m2x7, float m2x8, float m2x9, float m2x10, float m2x11,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5, float m3x6, float m3x7, float m3x8, float m3x9, float m3x10, float m3x11,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5, float m4x6, float m4x7, float m4x8, float m4x9, float m4x10, float m4x11,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5, float m5x6, float m5x7, float m5x8, float m5x9, float m5x10, float m5x11,
            float m6x1, float m6x2, float m6x3, float m6x4, float m6x5, float m6x6, float m6x7, float m6x8, float m6x9, float m6x10, float m6x11,
            float m7x1, float m7x2, float m7x3, float m7x4, float m7x5, float m7x6, float m7x7, float m7x8, float m7x9, float m7x10, float m7x11,
            float m8x1, float m8x2, float m8x3, float m8x4, float m8x5, float m8x6, float m8x7, float m8x8, float m8x9, float m8x10, float m8x11,
            float m9x1, float m9x2, float m9x3, float m9x4, float m9x5, float m9x6, float m9x7, float m9x8, float m9x9, float m9x10, float m9x11,
            float m10x1, float m10x2, float m10x3, float m10x4, float m10x5, float m10x6, float m10x7, float m10x8, float m10x9, float m10x10, float m10x11,
            float m11x1, float m11x2, float m11x3, float m11x4, float m11x5, float m11x6, float m11x7, float m11x8, float m11x9, float m11x10, float m11x11
            ) IdentityMatrix11x11 =
            (1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 0f, 1f, 0f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 1f, 0f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 1f, 0f,
             0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 1f);

        /// <summary>
        /// The cubic Hermite Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4,
            float m2x1, float m2x2, float m2x3, float m2x4,
            float m3x1, float m3x2, float m3x3, float m3x4,
            float m4x1, float m4x2, float m4x3, float m4x4
            ) CubicHermiteBernsteinBasisMatrix =
            (1, 0, 0, 0,
            0, 1, 0, 0,
            -3, -2, 3, -1,
            2, 1, -2, 1);

        /// <summary>
        /// The linear Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2,
            float m2x1, float m2x2
            ) LinearBezierBernsteinBasisMatrix =
            (1f, 0f,
            -1f, 1f);

        /// <summary>
        /// The inverse linear Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2,
            float m2x1, float m2x2
            ) InverseLinearBezierBernsteinBasisMatrix =
            (1f, 0f,
            1f, 1f);

        /// <summary>
        /// The quadratic Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3,
            float m2x1, float m2x2, float m2x3,
            float m3x1, float m3x2, float m3x3
            ) QuadraticBezierBernsteinBasisMatrix =
            (1f, 0f, 0f,
            -2f, 2f, 0f,
            1f, -2f, 1f);

        /// <summary>
        /// The inverse quadratic Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3,
            float m2x1, float m2x2, float m2x3,
            float m3x1, float m3x2, float m3x3
            ) InverseQuadraticBezierBernsteinBasisMatrix =
            (1f, 0f, 0f,
            1f, OneHalf, 0f,
            1f, 1f, 1f);

        /// <summary>
        /// The cubic Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4,
            float m2x1, float m2x2, float m2x3, float m2x4,
            float m3x1, float m3x2, float m3x3, float m3x4,
            float m4x1, float m4x2, float m4x3, float m4x4
            ) CubicBezierBernsteinBasisMatrix =
            (1f, 0f, 0f, 0f,
            -3f, 3f, 0f, 0f,
            3f, -6f, 3f, 0f,
            -1f, 3f, -3f, 1f);

        /// <summary>
        /// The inverse cubic Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4,
            float m2x1, float m2x2, float m2x3, float m2x4,
            float m3x1, float m3x2, float m3x3, float m3x4,
            float m4x1, float m4x2, float m4x3, float m4x4
            ) InverseCubicBezierBernsteinBasisMatrix =
            (1f, 0f, 0f, 0f,
            1f, OneThird, 0f, 0f,
            1f, TwoThirds, OneThird, 0f,
            1f, 1f, 1f, 1f);

        /// <summary>
        /// The quartic Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5
            ) QuarticBezierBernsteinBasisMatrix =
            (1f, 0f, 0f, 0f, 0f,
            -4f, 4f, 0f, 0f, 0f,
            6f, -12f, 6f, 0f, 0f,
            -4f, 12f, -12f, 4f, 0f,
            1f, -4f, 6f, -4f, 1f);

        /// <summary>
        /// The inverse quartic Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5
            ) InverseQuarticBezierBernsteinBasisMatrix =
            (1f, 0f, 0f, 0f, 0f,
            1f, OneQuarter, 0f, 0f, 0f,
            1f, ThreeQuarters, TwoThirds, 0f, 0f,
            1f, ThreeQuarters, ThreeQuarters, OneQuarter, 0f,
            1f, 1f, 1f, 1f, 1f);

        /// <summary>
        /// The quintic Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5, float m1x6,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5, float m2x6,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5, float m3x6,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5, float m4x6,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5, float m5x6,
            float m6x1, float m6x2, float m6x3, float m6x4, float m6x5, float m6x6
            ) QuinticBezierBernsteinBasisMatrix =
            (1f, 0f, 0f, 0f, 0f, 0f,
            -5f, 5f, 0f, 0f, 0f, 0f,
            10f, -20f, 10f, 0f, 0f, 0f,
            -10f, 30f, -30f, 10f, 0f, 0f,
            5f, -20f, 30f, -20f, 5f, 0f,
            -1f, 5f, -10f, 10f, -5f, 1f);

        /// <summary>
        /// The sextic Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5, float m1x6, float m1x7,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5, float m2x6, float m2x7,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5, float m3x6, float m3x7,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5, float m4x6, float m4x7,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5, float m5x6, float m5x7,
            float m6x1, float m6x2, float m6x3, float m6x4, float m6x5, float m6x6, float m6x7,
            float m7x1, float m7x2, float m7x3, float m7x4, float m7x5, float m7x6, float m7x7
            ) SexticBezierBernsteinBasisMatrix =
            (1f, 0f, 0f, 0f, 0f, 0f, 0f,
            -6f, 6f, 0f, 0f, 0f, 0f, 0f,
            15f, -30f, 15f, 0f, 0f, 0f, 0f,
            -20f, 60f, -60f, 20f, 0f, 0f, 0f,
            15f, -60f, 90f, -60f, 15f, 0f, 0f,
            -6f, 30f, -60f, 60f, -30f, 6f, 0f,
            1f, -6f, 15f, -20f, 15f, -6f, 1f);

        /// <summary>
        /// The septic Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5, float m1x6, float m1x7, float m1x8,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5, float m2x6, float m2x7, float m2x8,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5, float m3x6, float m3x7, float m3x8,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5, float m4x6, float m4x7, float m4x8,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5, float m5x6, float m5x7, float m5x8,
            float m6x1, float m6x2, float m6x3, float m6x4, float m6x5, float m6x6, float m6x7, float m6x8,
            float m7x1, float m7x2, float m7x3, float m7x4, float m7x5, float m7x6, float m7x7, float m7x8,
            float m8x1, float m8x2, float m8x3, float m8x4, float m8x5, float m8x6, float m8x7, float m8x8
            ) SepticBezierBernsteinBasisMatrix =
            (1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
            -7f, 7f, 0f, 0f, 0f, 0f, 0f, 0f,
            21f, -42f, 21f, 0f, 0f, 0f, 0f, 0f,
            -35f, 105f, -105f, 35f, 0f, 0f, 0f, 0f,
            35f, -140f, 210f, -140f, 35f, 0f, 0f, 0f,
            -21f, 105f, -210f, 210f, -105f, 21f, 0f, 0f,
            7f, -42f, 105f, -140f, 105f, -42f, 7f, 0f,
            -1f, 7f, -21f, 35f, -35f, 21f, -7f, 1f);

        /// <summary>
        /// The octic Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5, float m1x6, float m1x7, float m1x8, float m1x9,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5, float m2x6, float m2x7, float m2x8, float m2x9,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5, float m3x6, float m3x7, float m3x8, float m3x9,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5, float m4x6, float m4x7, float m4x8, float m4x9,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5, float m5x6, float m5x7, float m5x8, float m5x9,
            float m6x1, float m6x2, float m6x3, float m6x4, float m6x5, float m6x6, float m6x7, float m6x8, float m6x9,
            float m7x1, float m7x2, float m7x3, float m7x4, float m7x5, float m7x6, float m7x7, float m7x8, float m7x9,
            float m8x1, float m8x2, float m8x3, float m8x4, float m8x5, float m8x6, float m8x7, float m8x8, float m8x9,
            float m9x1, float m9x2, float m9x3, float m9x4, float m9x5, float m9x6, float m9x7, float m9x8, float m9x9
            ) OcticBezierBernsteinBasisMatrix =
            (1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
            -8f, 8f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
            28f, -56f, 28f, 0f, 0f, 0f, 0f, 0f, 0f,
            -56f, 168f, -168f, 56f, 0f, 0f, 0f, 0f, 0f,
            70f, -280f, 420f, -280f, 70f, 0f, 0f, 0f, 0f,
            -56f, 280f, -560f, 560f, -280f, 56f, 0f, 0f, 0f,
            28f, -168f, 420f, -560f, 420f, -168f, 28f, 0f, 0f,
            -8f, 56f, -168f, 280f, -280f, 168f, -56f, 8f, 0f,
            1f, -8f, 28f, -56f, 70f, -56f, 28f, -8f, 1f);

        /// <summary>
        /// The nonic Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5, float m1x6, float m1x7, float m1x8, float m1x9, float m1x10,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5, float m2x6, float m2x7, float m2x8, float m2x9, float m2x10,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5, float m3x6, float m3x7, float m3x8, float m3x9, float m3x10,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5, float m4x6, float m4x7, float m4x8, float m4x9, float m4x10,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5, float m5x6, float m5x7, float m5x8, float m5x9, float m5x10,
            float m6x1, float m6x2, float m6x3, float m6x4, float m6x5, float m6x6, float m6x7, float m6x8, float m6x9, float m6x10,
            float m7x1, float m7x2, float m7x3, float m7x4, float m7x5, float m7x6, float m7x7, float m7x8, float m7x9, float m7x10,
            float m8x1, float m8x2, float m8x3, float m8x4, float m8x5, float m8x6, float m8x7, float m8x8, float m8x9, float m8x10,
            float m9x1, float m9x2, float m9x3, float m9x4, float m9x5, float m9x6, float m9x7, float m9x8, float m9x9, float m9x10,
            float m10x1, float m10x2, float m10x3, float m10x4, float m10x5, float m10x6, float m10x7, float m10x8, float m10x9, float m10x10
            ) NonicBezierBernsteinBasisMatrix =
            (1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
            -9f, 9f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
            36f, -72f, 36f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
            -84f, 252f, -252f, 84f, 0f, 0f, 0f, 0f, 0f, 0f,
            126f, -504f, 756f, -504f, 126f, 0f, 0f, 0f, 0f, 0f,
            -126f, 630f, -1260f, 1260f, -630f, 126f, 0f, 0f, 0f, 0f,
            84f, -504f, 1260f, -1680f, 1260f, -504f, 84f, 0f, 0f, 0f,
            -36f, 252f, -756f, 1260f, -1260f, 756f, -252f, 72f, 0f, 0f,
            9f, -72f, 252f, -504f, 630f, -504f, 252f, -72f, 9f, 0f,
            -1f, 9f, -36f, 84f, -126f, 126, -84f, 36, 9f, 1f);

        /// <summary>
        /// The decic Bezier Bernstein basis matrix.
        /// </summary>
        public static readonly (
            float m1x1, float m1x2, float m1x3, float m1x4, float m1x5, float m1x6, float m1x7, float m1x8, float m1x9, float m1x10, float m1x11,
            float m2x1, float m2x2, float m2x3, float m2x4, float m2x5, float m2x6, float m2x7, float m2x8, float m2x9, float m2x10, float m2x11,
            float m3x1, float m3x2, float m3x3, float m3x4, float m3x5, float m3x6, float m3x7, float m3x8, float m3x9, float m3x10, float m3x11,
            float m4x1, float m4x2, float m4x3, float m4x4, float m4x5, float m4x6, float m4x7, float m4x8, float m4x9, float m4x10, float m4x11,
            float m5x1, float m5x2, float m5x3, float m5x4, float m5x5, float m5x6, float m5x7, float m5x8, float m5x9, float m5x10, float m5x11,
            float m6x1, float m6x2, float m6x3, float m6x4, float m6x5, float m6x6, float m6x7, float m6x8, float m6x9, float m6x10, float m6x11,
            float m7x1, float m7x2, float m7x3, float m7x4, float m7x5, float m7x6, float m7x7, float m7x8, float m7x9, float m7x10, float m7x11,
            float m8x1, float m8x2, float m8x3, float m8x4, float m8x5, float m8x6, float m8x7, float m8x8, float m8x9, float m8x10, float m8x11,
            float m9x1, float m9x2, float m9x3, float m9x4, float m9x5, float m9x6, float m9x7, float m9x8, float m9x9, float m9x10, float m9x11,
            float m10x1, float m10x2, float m10x3, float m10x4, float m10x5, float m10x6, float m10x7, float m10x8, float m10x9, float m10x10, float m10x11,
            float m11x1, float m11x2, float m11x3, float m11x4, float m11x5, float m11x6, float m11x7, float m11x8, float m11x9, float m11x10, float m11x11
            ) DecicBezierBernsteinBasisMatrix =
            (1f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
            -10f, 10f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
            45f, -90f, 45f, 0f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
            -120f, 360f, -360f, 120f, 0f, 0f, 0f, 0f, 0f, 0f, 0f,
            210f, -840f, 1260f, -840f, 210f, 0f, 0f, 0f, 0f, 0f, 0f,
            -252f, 1260f, -2520f, 2520f, -1260f, 252f, 0f, 0f, 0f, 0f, 0f,
            210f, -1260f, 3150f, -4200f, 3150f, -1260f, 210f, 0f, 0f, 0f, 0f,
            -120f, 840f, -2520f, 4200f, -4200f, 2520f, -840f, 120f, 0f, 0f, 0f,
            45f, -360f, 1260f, -2520f, 3150f, -2520f, 1260f, -360f, 45f, 0f, 0f,
            -10f, 90f, -360f, 840f, -1260f, 1260, -840f, 360, 90f, 10f, 0f,
            1f, -10f, 45f, -120f, 210f, -252f, 210f, -120f, 45f, -10f, 1f);
        #endregion Matrices

        #region Gauss Tables
        /// <summary>
        /// Gauss abscissa table
        /// </summary>
        /// <acknowledgment>
        /// https://code.google.com/archive/p/degrafa/source/default/source
        /// </acknowledgment>
        public static readonly float[] abscissa = new float[]
        {
            // N=2
            -0.5773502692f,
                0.5773502692f,
            // N=3
            -0.7745966692f,
                0.7745966692f,
                0.0000000000f,
            // N=4
            -0.8611363116f,
                0.8611363116f,
            -0.3399810436f,
                0.3399810436f,
            // N=5
            -0.9061798459f,
                0.9061798459f,
            -0.5384693101f,
                0.5384693101f,
                0.0000000000f,
            // N=6
            -0.9324695142f,
                0.9324695142f,
            -0.6612093865f,
                0.6612093865f,
            -0.2386191861f,
                0.2386191861f,
            // N=7
            -0.9491079123f,
                0.9491079123f,
            -0.7415311856f,
                0.7415311856f,
            -0.4058451514f,
                0.4058451514f,
                0.0000000000f,
            // N=8
            -0.9602898565f,
                0.9602898565f,
            -0.7966664774f,
                0.7966664774f,
            -0.5255324099f,
                0.5255324099f,
            -0.1834346425f,
                0.1834346425f
        };

        /// <summary>
        /// Gauss weight table
        /// </summary>
        /// <acknowledgment>
        /// https://code.google.com/archive/p/degrafa/source/default/source
        /// </acknowledgment>
        public static readonly float[] weight = new float[]
        {
            // N=2
            1.0000000000f,
            1.0000000000f,
            // N=3
            0.5555555556f,
            0.5555555556f,
            0.8888888888f,
            // N=4
            0.3478548451f,
            0.3478548451f,
            0.6521451549f,
            0.6521451549f,
            // N=5
            0.2369268851f,
            0.2369268851f,
            0.4786286705f,
            0.4786286705f,
            0.5688888888f,
            // N=6
            0.1713244924f,
            0.1713244924f,
            0.3607615730f,
            0.3607615730f,
            0.4679139346f,
            0.4679139346f,
            // N=7
            0.1294849662f,
            0.1294849662f,
            0.2797053915f,
            0.2797053915f,
            0.3818300505f,
            0.3818300505f,
            0.4179591837f,
            // N=8
            0.1012285363f,
            0.1012285363f,
            0.2223810345f,
            0.2223810345f,
            0.3137066459f,
            0.3137066459f,
            0.3626837834f,
            0.3626837834f
        };
        #endregion Gauss Tables
    }
}
