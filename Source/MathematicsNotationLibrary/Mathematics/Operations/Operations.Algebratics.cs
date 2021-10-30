// <copyright file="Operations.Algebratics.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using System;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary;

/// <summary>
/// Algebraic Operations class.
/// </summary>
public static partial class Operations
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FloatingPointConstants<T>
        where T : IFloatingPoint<T>
    {
        /// <summary>
        /// Represents the ratio of the radius of a circle to the first quarter of that circle.
        /// One quarter Tau or half Pi. A right angle in mathematics.
        /// </summary>
        /// <remarks><para>PI / 2</para></remarks>
        public static T Hau => T.Create(0.5) * T.Pi; // 1.5707963267948966192313216916398d;

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
        public static T Pau => T.Create(1.5) * T.Pi; // 4.7123889803846898576939650749193d;

        /// <summary>
        /// SlopeMax is a large value "close to infinity" (Close to the largest value allowed for the data
        /// type). Used in the Slope of a LineSeg
        /// </summary>
        public static T SlopeMax => T.Create(9223372036854775807);
    }

    #region Degree Radian Conversion
    /// <summary>
    /// Convert Degrees to Radians.
    /// </summary>
    /// <param name="degrees">Angle in Degrees.</param>
    /// <returns>
    /// Angle in Radians.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static R DegreesToRadians<D, R>(this D degrees) where D : INumber<D> where R : IFloatingPoint<R> => R.Create(degrees) * (R.Pi / R.Create(180));

    /// <summary>
    /// Convert Radians to Degrees.
    /// </summary>
    /// <param name="radians">Angle in Radians.</param>
    /// <returns>
    /// Angle in Degrees.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static D RadiansToDegrees<R, D>(this R radians) where D : INumber<D> where R : IFloatingPoint<R> => D.Create(radians * (R.Create(180) / R.Pi));
    #endregion

    #region Angle
    /// <summary>
    /// The angle.
    /// </summary>
    /// <param name="cos">The Cosine.</param>
    /// <param name="sin">The Sine.</param>
    /// <returns>
    /// The angle.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Angle<T>(T cos, T sin) where T : IFloatingPoint<T> => T.Atan2(-sin, cos);
    #endregion

    #region Angle Wrapping
    /// <summary>
    /// Find the absolute positive value of a radian angle.
    /// </summary>
    /// <param name="angle">The angle.</param>
    /// <returns>
    /// The absolute positive angle in radians.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T AbsoluteAngle<T>(this T angle)
        where T : IFloatingPoint<T>
    {
        if (T.IsNaN(angle))
        {
            return angle;
        }

        // ToDo: Need to do some testing to figure out which method is more appropriate.
        //T value = angle % Tau;
        //T value = IEEERemainder(angle, Tau);
        // The active ingredient of the IEEERemainder method is extracted here.
        var value = angle - (T.Tau * T.Round(angle * T.Create(T.One / T.Tau)));
        return value < T.Zero ? value + T.Tau : value;
    }

    /// <summary>
    /// The normalize radian.
    /// </summary>
    /// <param name="angle">The angle.</param>
    /// <returns>
    /// The normalize radian.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T NormalizeRadian<T>(T angle)
        where T : IFloatingPoint<T>
    {
        var value = (angle + T.Pi) % T.Tau;
        value += (value > T.Zero) ? -T.Pi : T.Pi;
        return value;
    }

    /// <summary>
    /// Reduces a given angle to a value between 2π and -2π.
    /// </summary>
    /// <param name="angle">The angle to reduce, in radians.</param>
    /// <returns>
    /// The new angle, in radians.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T WrapAngleModulus<T>(this T angle)
        where T : IFloatingPoint<T>
    {
        if (T.IsNaN(angle))
        {
            return angle;
        }

        var value = angle % T.Tau;
        return (value <= -T.Pi) ? value + T.Tau : value - T.Tau;
    }

    /// <summary>
    /// Reduces a given angle to a value between 2π and -2π.
    /// </summary>
    /// <param name="angle">The angle to reduce, in radians.</param>
    /// <returns>
    /// The new angle, in radians.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T WrapAngle<T>(this T angle)
        where T : IFloatingPoint<T>
    {
        if (T.IsNaN(angle))
        {
            return angle;
        }

        // The IEEERemainder method works better than the % modulus operator in this case, even if it is slower.
        //T value = IEEERemainder(angle, Tau);
        // The active ingredient of the IEEERemainder method is extracted here for performance reasons.
        var value = angle - (T.Tau * T.Round(angle / T.Tau));
        return (value <= -T.Pi) ? value + T.Tau : value - T.Tau;
    }
    #endregion

    #region Slope
    /// <summary>
    /// Slopes to radians.
    /// </summary>
    /// <param name="slope">The slope.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T SlopeToRadians<T>(this T slope) where T : IFloatingPoint<T> => T.Atan(slope);

    /// <summary>
    /// Calculates the Slope of a vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <returns>
    /// Returns the slope angle of a vector.
    /// </returns>
    /// <remarks>
    /// <para>The slope is calculated with Slope = Y / X or rise over run
    /// If the line is vertical, return something close to infinity
    /// (Close to the largest value allowed for the data type).
    /// Otherwise calculate and return the slope.</para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Slope<T, TResult>(T i, T j) where T : INumber<T> where TResult : IFloatingPoint<TResult> => TResult.Abs(TResult.Create(i)) < TResult.Epsilon ? TResult.Create(FloatingPointConstants<TResult>.SlopeMax) : TResult.Create(j / i);

    /// <summary>
    /// Returns the slope angle of a line.
    /// </summary>
    /// <param name="x1">Horizontal Component of Point Starting Point</param>
    /// <param name="y1">Vertical Component of Point Starting Point</param>
    /// <param name="x2">Horizontal Component of Ending Point</param>
    /// <param name="y2">Vertical Component of Ending Point</param>
    /// <returns>
    /// Returns the slope angle of a line.
    /// </returns>
    /// <remarks>
    /// <para>If the Line is Vertical return something close to infinity (Close to
    /// the largest value allowed for the data type).
    /// Otherwise calculate and return the slope.</para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Slope<T, TResult>(T x1, T y1, T x2, T y2) where T : INumber<T> where TResult : IFloatingPoint<TResult> => (TResult.Abs(TResult.Create(x1 - x2)) < TResult.Epsilon) ? TResult.Create(FloatingPointConstants<TResult>.SlopeMax) : TResult.Create((y2 - y1) / (x2 - x1));
    #endregion Slope

    #region Hypotenuse
    /// <summary>
    /// Hypotenuse, sqrt(a^2 + b^2) without under/overflow.
    /// </summary>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Hypotenuse<T, TResult>(T a, T b)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        TResult hypotenuse;

        switch ((a, b))
        {
            case var tuple when T.Abs(tuple.a) > T.Abs(tuple.b):
                hypotenuse = TResult.Create(b / a);
                hypotenuse = TResult.Abs(TResult.Create(a)) * TResult.Sqrt(TResult.One + hypotenuse * hypotenuse);
                break;
            case var tuple when tuple.b != T.Zero:
                hypotenuse = TResult.Create(a / b);
                hypotenuse = TResult.Abs(TResult.Create(b)) * TResult.Sqrt(TResult.One + hypotenuse * hypotenuse);
                break;
            default:
                hypotenuse = TResult.Zero;
                break;
        }

        return hypotenuse;
    }
    #endregion

    #region Ellipse Helpers
    /// <summary>
    /// Find the elliptical t that matches the coordinates of a circular angle.
    /// </summary>
    /// <param name="angle">The angle to transform into elliptic angle.</param>
    /// <param name="rx">The first radius of the ellipse.</param>
    /// <param name="ry">The second radius of the ellipse.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Based on the answer by flup at: https://stackoverflow.com/a/17762156/7004229
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult EllipticalPolarAngle<T, TResult>(TResult angle, T rx, T ry)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        var rxt = TResult.Create(rx);
        var ryt = TResult.Create(ry);
        var hau = TResult.Create(FloatingPointConstants<TResult>.Hau);
        var pau = TResult.Create(FloatingPointConstants<TResult>.Pau);

        // Wrap the angle between -2PI and 2PI.
        var theta = angle % TResult.Tau;

        // Find the elliptical t that matches the circular angle.
        return theta switch
        {
            var t when TResult.Abs(t) == hau || TResult.Abs(t) == pau => angle,
            var t when t > hau && t < pau => TResult.Atan(rxt * TResult.Tan(t) / ryt) + TResult.Pi,
            var t when t < -hau && t > -pau => TResult.Atan(rxt * TResult.Tan(t) / ryt) - TResult.Pi,
            _ => TResult.Atan(rxt * TResult.Tan(theta) / ryt),
        };
    }

    /// <summary>
    /// Find the elliptical (cos(t), sin(t)) that matches the coordinates of a circular angle.
    /// </summary>
    /// <param name="cosA">The cos a.</param>
    /// <param name="sinA">The sin a.</param>
    /// <param name="rx">The first radius of the ellipse.</param>
    /// <param name="ry">The second radius of the ellipse.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Vectorized version of the answer by flup at: https://stackoverflow.com/a/17762156/7004229
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult cosT, TResult sinT) EllipticalPolarVector<T, TResult>(TResult cosA, TResult sinA, T rx, T ry)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        // Find the elliptical t that matches the circular angle.
        if (cosA > TResult.NegativeOne && cosA < TResult.Zero || cosA > TResult.Zero && cosA < TResult.One)
        {
            var sign = TResult.Sign(cosA);
            var eCos = TResult.Sqrt(TResult.One + (TResult.Create(rx * rx) * sinA * sinA / (TResult.Create(ry * ry) * cosA * cosA)));
            return (
                sign / eCos,
                sign * (TResult.Create(rx) * sinA / (TResult.Create(ry) * cosA * eCos))
                );
        }

        return (cosA, sinA);
    }

    /// <summary>
    /// Return a "correction" angle that converts a subtended angle to a parametric angle for an
    /// ellipse with radii a and b.
    /// </summary>
    /// <param name="subtendedAngle">The subtended.</param>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult SubtendedToParametric<T, TResult>(TResult subtendedAngle, T a, T b) where T : INumber<T> where TResult : IFloatingPoint<TResult> => SubtendedToParametric(TResult.Cos(subtendedAngle), TResult.Sin(subtendedAngle), a, b);

    /// <summary>
    /// Return a "correction" angle that converts a subtended angle to a parametric angle for an
    /// ellipse with radii a and b.
    /// </summary>
    /// <param name="subtendedCos">The subtended cos.</param>
    /// <param name="subtendedSin">The subtended sin.</param>
    /// <param name="a">a.</param>
    /// <param name="b">The b.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Code ported from: https://www.khanacademy.org/computer-programming/e/6221186997551104
    /// Math from: http://mathworld.wolfram.com/Ellipse-LineIntersection.html
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult SubtendedToParametric<T, TResult>(TResult subtendedCos, TResult subtendedSin, T a, T b)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        if (a == b)
        {
            // Circle needs no correction.
            return TResult.Zero;

            // Should test to see if this might be causing problems and should be the following instead:
            //return TResult.Atan2(subtendedSin, subtendedCos);
        }

        // A ray from the origin.
        var e = TResult.Create(a * b) / TResult.Sqrt((TResult.Create(a * a) * subtendedSin * subtendedSin) + (TResult.Create(b * b) * subtendedCos * subtendedCos));

        // Where ray intersects ellipse.
        var ex = e * subtendedCos;
        var ey = e * subtendedSin;

        // Normalized.
        var parametric = TResult.Atan2(TResult.Create(a) * ey, TResult.Create(b) * ex);
        var subtended = TResult.Atan2(subtendedSin, subtendedCos);
        return parametric - subtended;
    }
    #endregion

    #region Polar Cartesian Conversion
    /// <summary>
    /// The polar to Cartesian.
    /// </summary>
    /// <param name="centerX">The centerX.</param>
    /// <param name="centerY">The centerY.</param>
    /// <param name="radius">The radius.</param>
    /// <param name="theta">The angleInRadians.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2}" />.
    /// </returns>
    /// <acknowledgment>
    /// https://codereview.stackexchange.com/q/183
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) PolarToCartesian<T>(T centerX, T centerY, T radius, T theta)
        where T : IFloatingPoint<T>
    {
        var sin = T.Sin(theta);

        // This is faster than:
        // T cos = Math.Cos(theta);
        var cos = -T.Sqrt(T.One - (sin * sin));

        return (
            X: centerX + (radius * cos),
            Y: centerY + (radius * sin)
            );
    }

    /// <summary>
    /// The Cartesian to polar.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2}" />.
    /// </returns>
    /// <acknowledgment>
    /// https://stackoverflow.com/a/34315013
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult Radius, TResult Theta) CartesianToPolar<T, TResult>(T x, T y) where T : INumber<T> where TResult : IFloatingPoint<TResult> => CartesianToPolar<T, TResult>(x, y, T.Zero, T.Zero);

    /// <summary>
    /// The Cartesian to polar.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="centerX">The centerX.</param>
    /// <param name="centerY">The centerY.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2}" />.
    /// </returns>
    /// <acknowledgment>
    /// https://stackoverflow.com/a/34315013
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult Radius, TResult Theta) CartesianToPolar<T, TResult>(T x, T y, T centerX, T centerY)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        var dx = TResult.Create(x - centerX);
        var dy = TResult.Create(y - centerY);
        var radius = TResult.Sqrt((dx * dx) + (dy * dy));
        var angle = TResult.Atan2(dy, dx);
        return (radius, angle);
    }
    #endregion

    #region Derived Equivalent Math Functions
    /// <summary>
    /// Derived math functions equivalent Secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Secant<T>(T value) where T : IFloatingPoint<T>
        => (value % T.Pi == T.Create(FloatingPointConstants<T>.Hau))
        && (value % T.Pi == -T.Create(FloatingPointConstants<T>.Hau))
        ? (T.One / T.Cos(value)) : T.Zero;

    /// <summary>
    /// Derived math functions equivalent  Co-secant
    /// </summary>
    /// <param name="Value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Cosecant<T>(T Value) where T : IFloatingPoint<T>
        => (Value % T.Pi == T.Zero)
        && (Value % T.Pi == T.Pi)
        ? (T.One / T.Sin(Value)) : T.Zero;

    /// <summary>
    /// Derived math functions equivalent Cotangent
    /// </summary>
    /// <param name="Value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T Cotangent<T>(T Value) where T : IFloatingPoint<T>
        => (Value % T.Pi == T.Zero)
        && (Value % T.Pi == T.Pi)
        ? (T.One / T.Tan(Value)) : T.Zero;

    /// <summary>
    /// Derived math functions equivalent Inverse Sine
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseSine<T>(T value) where T : IFloatingPoint<T> => value switch
    {
        var v when v == T.One => T.Create(FloatingPointConstants<T>.Hau),
        var v when v == T.NegativeOne => -T.Create(FloatingPointConstants<T>.Hau),
        var v when T.Abs(v) < T.One => T.Atan(value / T.Sqrt((-value * value) + T.One)),// Arc-sin(X)
        _ => T.Zero,
    };

    /// <summary>
    /// Derived math functions equivalent Inverse Cosine
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseCosine<T>(T value) where T : IFloatingPoint<T> => value switch
    {
        var v when v == T.One => T.Zero,
        var v when v == T.NegativeOne => T.Pi,
        var v when T.Abs(v) < T.One => T.Atan(-value / T.Sqrt((-value * value) + T.One)) + (T.Create(2) * T.Atan(T.One)),// Arc-cos(X)
        _ => T.Zero,
    };

    /// <summary>
    /// Derived math functions equivalent Inverse Secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseSecant<T>(T value) where T : IFloatingPoint<T> => value switch
    {
        var v when v == T.One => T.Zero,
        var v when v == T.NegativeOne => T.Pi,
        var v when T.Abs(v) < T.One => T.Atan(value / T.Sqrt((value * value) - T.One)) + (T.Sin(value - T.One) * (T.Create(2) * T.Atan(T.One))),// Arc-sec(X)
        _ => T.Zero,
    };

    /// <summary>
    /// Derived math functions equivalent Inverse Co-secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseCosecant<T>(T value)
        where T : IFloatingPoint<T> => value switch
        {
            var v when v == T.One => T.Create(FloatingPointConstants<T>.Hau),
            var v when v == T.NegativeOne => -T.Create(FloatingPointConstants<T>.Hau),
            var v when T.Abs(v) < T.One => T.Atan(value / T.Sqrt((value * value) - T.One)) + ((T.Sin(value) - T.One) * (T.Create(2) * T.Atan(T.One))),// Arc-co-sec(X)
            _ => T.Zero,
        };

    /// <summary>
    /// Derived math functions equivalent Inverse Cotangent
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>Arc-co-tan(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseCotangent<T>(T value) where T : IFloatingPoint<T> => T.Atan(value) + (T.Create(2) * T.Atan(T.One));

    /// <summary>
    /// Derived math functions equivalent Hyperbolic Sine
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HSin(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T HyperbolicSine<T>(T value) where T : IFloatingPoint<T> => (T.Exp(value) - T.Exp(-value)) / T.Create(2);

    /// <summary>
    /// Derived math functions equivalent Hyperbolic Cosine
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HCos(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T HyperbolicCosine<T>(T value) where T : IFloatingPoint<T> => (T.Exp(value) + T.Exp(-value)) / T.Create(2);

    /// <summary>
    /// Derived math functions equivalent Hyperbolic Tangent
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HTan(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T HyperbolicTangent<T>(T value) where T : IFloatingPoint<T> => (T.Exp(value) - T.Exp(-value)) / (T.Exp(value) + T.Exp(-value));

    /// <summary>
    /// Derived math functions equivalent Hyperbolic Secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HSec(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T HyperbolicSecant<T>(T value) where T : IFloatingPoint<T> => (T.Exp(value) + T.Exp(-value)) / T.Create(2);

    /// <summary>
    /// Derived math functions equivalent Hyperbolic Co-secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HCosec(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T HyperbolicCosecant<T>(T value) where T : IFloatingPoint<T> => (T.Exp(value) - T.Exp(-value)) / T.Create(2);

    /// <summary>
    /// Derived math functions equivalent Hyperbolic Cotangent
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HCotan(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T HyperbolicCotangent<T>(T value) where T : IFloatingPoint<T> => (T.Exp(value) + T.Exp(-value)) / (T.Exp(value) - T.Exp(-value));

    /// <summary>
    /// Derived math functions equivalent Inverse Hyperbolic Sine
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HArcsin(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseHyperbolicSine<T>(T value) where T : IFloatingPoint<T> => T.Log(value + T.Sqrt((value * value) + T.One));

    /// <summary>
    /// Derived math functions equivalent Inverse Hyperbolic Cosine
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HArccos(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseHyperbolicCosine<T>(T value) where T : IFloatingPoint<T> => T.Log(value + T.Sqrt((value * value) - T.One));

    /// <summary>
    /// Derived math functions equivalent Inverse Hyperbolic Tangent
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HArctan(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseHyperbolicTangent<T>(T value) where T : IFloatingPoint<T> => T.Log((T.One + value) / (T.One - value)) / T.Create(2);

    /// <summary>
    /// Derived math functions equivalent Inverse Hyperbolic Secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HArcsec(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseHyperbolicSecant<T>(T value) where T : IFloatingPoint<T> => T.Log((T.Sqrt((value * value * T.NegativeOne) + T.One) + T.One) / value);

    /// <summary>
    /// Derived math functions equivalent Inverse Hyperbolic Co-secant
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HArccosec(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseHyperbolicCosecant<T>(T value) where T : IFloatingPoint<T> => T.Log(((T.Sin(value) * T.Sqrt((value * value) + T.One)) + T.One) / value);

    /// <summary>
    /// Derived math functions equivalent Inverse Hyperbolic Cotangent
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>HArccotan(X)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T InverseHyperbolicCotangent<T>(T value) where T : IFloatingPoint<T> => T.Log((value + T.One) / (value - T.One)) / T.Create(2);

    /// <summary>
    /// Derived math functions equivalent Base N Logarithm
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="numberBase">The number base.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>LogN(X)
    /// Return Log(Value) / Log(NumberBase)</para>
    /// </remarks>
    /// <acknowledgment>
    /// Translated from old Microsoft VB code examples that I have since lost.
    /// The latest incarnation seems to be: https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/keywords/derived-math-functions
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T LogarithmTobaseN<T>(T value, T numberBase) where T : IFloatingPoint<T> => (numberBase == T.One) ? (T.Log(value) / T.Log(numberBase)) : T.Zero;
    #endregion Derived Equivalent Math Functions
}
