// <copyright file="Operations.Vectors.Algebratics.cs" company="Shkyrockett" >
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
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
public static partial class Operations
{
    #region Vector Angles
    /// <summary>
    /// Returns the Angle of a line.
    /// </summary>
    /// <param name="x1">Horizontal Component of Point Starting Point</param>
    /// <param name="y1">Vertical Component of Point Starting Point</param>
    /// <param name="x2">Horizontal Component of Ending Point</param>
    /// <param name="y2">Vertical Component of Ending Point</param>
    /// <returns>
    /// Returns the Angle of a line.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Angle<T, TResult>(T x1, T y1, T x2, T y2) where T : INumber<T> where TResult : IFloatingPoint<TResult> => TResult.Atan2(TResult.Create(y1 - y2), TResult.Create(x1 - x2));

    /// <summary>
    /// The angle.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="z2">The z2.</param>
    /// <returns>
    /// The angle.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Angle<T, TResult>(T x1, T y1, T z1, T x2, T y2, T z2) where T : INumber<T> where TResult : IFloatingPoint<TResult> => (TResult.Abs(TResult.Create(x1 - x2)) < TResult.Epsilon && TResult.Abs(TResult.Create(y1 - y2)) < TResult.Epsilon && TResult.Abs(TResult.Create(z1 - z2)) < TResult.Epsilon) ? TResult.Zero : TResult.Acos(TResult.Min(TResult.One, DotProduct(Normalize<T, TResult>(x1, y1, z1), Normalize<T, TResult>(x2, y2, z2))));

    /// <summary>
    /// The angle vector.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="x3">The x3.</param>
    /// <param name="y3">The y3.</param>
    /// <returns>
    /// Return the angle ABC.
    /// Return a value between T.Pi and -PI.
    /// Note that the value is the opposite of what you might
    /// expect because Y coordinates increase downward.
    /// </returns>
    /// <acknowledgment>
    /// http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult AngleVector<T, TResult>(T x1, T y1, T x2, T y2, T x3, T y3) where T : INumber<T> where TResult : IFloatingPoint<TResult> => TResult.Atan2(TResult.Create(CrossProductTriple(x1, y1, x2, y2, x3, y3)), TResult.Create(DeltaDotProduct(x1, y1, x2, y2, x3, y3)));

    /// <summary>
    /// Find the absolute positive value of a radian angle from two points.
    /// </summary>
    /// <param name="x1">Horizontal Component of Point Starting Point</param>
    /// <param name="y1">Vertical Component of Point Starting Point</param>
    /// <param name="x2">Horizontal Component of Ending Point</param>
    /// <param name="y2">Vertical Component of Ending Point</param>
    /// <returns>
    /// The absolute angle of a line in radians.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult AbsoluteAngle<T, TResult>(
        T x1, T y1,
        T x2, T y2)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        // Find the angle of point a and point b.
        var test = -Angle<T, TResult>(x1, y1, x2, y2) % TResult.Pi;
        return test < TResult.Zero ? test += TResult.Pi : test;
    }

    /// <summary>
    /// Finds the angle between two vectors.
    /// </summary>
    /// <param name="uX">The uX.</param>
    /// <param name="uY">The uY.</param>
    /// <param name="vX">The vX.</param>
    /// <param name="vY">The vY.</param>
    /// <returns>
    /// The angle between two vectors.
    /// </returns>
    /// <acknowledgment>
    /// http://james-ramsden.com/angle-between-two-vectors/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult AngleBetween<T, TResult>(T uX, T uY, T vX, T vY) where T : INumber<T> where TResult : IFloatingPoint<TResult> => TResult.Acos(TResult.Create((uX * vX) + (uY * vY)) / TResult.Sqrt(TResult.Create(((uX * uX) + (uY * uY)) * ((vX * vX) + (vY * vY)))));

    /// <summary>
    /// Finds the angle between two vectors.
    /// </summary>
    /// <param name="uX">The uX.</param>
    /// <param name="uY">The uY.</param>
    /// <param name="uZ">The uZ.</param>
    /// <param name="vX">The vX.</param>
    /// <param name="vY">The vY.</param>
    /// <param name="vZ">The vZ.</param>
    /// <returns>
    /// The angle between two vectors.
    /// </returns>
    /// <acknowledgment>
    /// http://james-ramsden.com/angle-between-two-vectors/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult AngleBetween<T, TResult>(T uX, T uY, T uZ, T vX, T vY, T vZ) where T : INumber<T> where TResult : IFloatingPoint<TResult> => TResult.Acos(TResult.Create((uX * vX) + (uY * vY) + (uZ * vZ)) / TResult.Sqrt(TResult.Create(((uX * uX) + (uY * uY) + (uZ * uZ)) * ((vX * vX) + (vY * vY) + (vZ * vZ)))));
    #endregion

    #region Angle Vectors
    /// <summary>
    /// Rotates the angle vector.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="cos">The cos.</param>
    /// <param name="sin">The sin.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T cos, T sin) RotateAngleVector<T>(T x, T y, T cos, T sin) where T : INumber<T> => ((x * cos) - (y * sin), (x * sin) + (y * cos));

    /// <summary>
    /// Find the incidence category of vector Angles.
    /// </summary>
    /// <param name="cos1">The cos1.</param>
    /// <param name="sin1">The sin1.</param>
    /// <param name="cos2">The cos2.</param>
    /// <param name="sin2">The sin2.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Incidence AngleVectorIncidence<T>(T cos1, T sin1, T cos2, T sin2) where T : IFloatingPoint<T> => AngleVectorIncidence(cos1, sin1, cos2, sin2, T.Epsilon);

    /// <summary>
    /// Find the incidence category of vector Angles.
    /// </summary>
    /// <param name="cos1">The cos1.</param>
    /// <param name="sin1">The sin1.</param>
    /// <param name="cos2">The cos2.</param>
    /// <param name="sin2">The sin2.</param>
    /// <param name="epsilon">The epsilon.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Incidence AngleVectorIncidence<T>(T cos1, T sin1, T cos2, T sin2, T epsilon)
        where T : IFloatingPoint<T>
    {
        var crossProduct = CrossProduct(cos1, sin1, cos2, sin2);
        return T.Abs(crossProduct) < epsilon
            ? Incidence.Parallel
            : T.Abs(T.One - crossProduct) < epsilon
            ? Incidence.Perpendicular : Incidence.Oblique;
    }
    #endregion

    #region Vector ABS
    /// <summary>
    /// The abs.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <returns>
    /// The abs.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Abs<T, TResult>(T i, T j) where T : INumber<T> where TResult : IFloatingPoint<TResult> => Magnitude<T, TResult>(i, j);

    /// <summary>
    /// The abs.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="k">The k.</param>
    /// <returns>
    /// The abs.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Abs<T, TResult>(T i, T j, T k) where T : INumber<T> where TResult : IFloatingPoint<TResult> => Magnitude<T, TResult>(i, j, k);
    #endregion

    #region Invert
    /// <summary>
    /// Inverts the vector parametrically.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) InvertVectorParametric<T>(T x, T y) where T : INumber<T> => (T.One / x, T.One / y);

    /// <summary>
    /// Inverts the vector parametrically.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) InvertVectorParametric<T>(T x, T y, T z) where T : INumber<T> => (T.One / x, T.One / y, T.One / z);

    /// <summary>
    /// Inverts the vector parametrically.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    /// <param name="w">The w.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W) InvertVectorParametric<T>(T x, T y, T z, T w) where T : INumber<T> => (T.One / x, T.One / y, T.One / z, T.One / w);

    /// <summary>
    /// Inverts the vector parametrically.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    /// <param name="w">The w.</param>
    /// <param name="v">The v.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V) InvertVectorParametric<T>(T x, T y, T z, T w, T v) where T : INumber<T> => (T.One / x, T.One / y, T.One / z, T.One / w, T.One / v);

    /// <summary>
    /// Inverts the vector parametrically.
    /// </summary>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    /// <param name="w">The w.</param>
    /// <param name="v">The v.</param>
    /// <param name="u">The u.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W, T V, T U) InvertVectorParametric<T>(T x, T y, T z, T w, T v, T u) where T : INumber<T> => (T.One / x, T.One / y, T.One / z, T.One / w, T.One / v, T.One / u);
    #endregion Invert

    #region Unit
    /// <summary>
    /// Unit of a 2D Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector to Unitize.</param>
    /// <param name="j">The j component of the Vector to Unitize.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult I, TResult J) Unit<T, TResult>(T i, T j) where T : INumber<T> where TResult : IFloatingPoint<TResult> => ScaleVector(TResult.Create(i), TResult.Create(j), TResult.One / TResult.Sqrt(TResult.Create((i * i) + (j * j))));

    /// <summary>
    /// Unit of a 3D Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector to Unitize.</param>
    /// <param name="j">The j component of the Vector to Unitize.</param>
    /// <param name="k">The k component of the Vector to Unitize.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult I, TResult J, TResult K) Unit<T, TResult>(T i, T j, T k) where T : INumber<T> where TResult : IFloatingPoint<TResult> => ScaleVector(TResult.Create(i), TResult.Create(j), TResult.Create(k), TResult.One / TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k))));

    /// <summary>
    /// Unit of a 4D Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector to Unitize.</param>
    /// <param name="j">The j component of the Vector to Unitize.</param>
    /// <param name="k">The k component of the Vector to Unitize.</param>
    /// <param name="l">The l component of the Vector to Unitize.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult I, TResult J, TResult K, TResult L) Unit<T, TResult>(T i, T j, T k, T l) where T : INumber<T> where TResult : IFloatingPoint<TResult> => ScaleVector(TResult.Create(i), TResult.Create(j), TResult.Create(k), TResult.Create(l), TResult.One / TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k) + (l * l))));
    #endregion Unit

    #region Magnitude
    /// <summary>
    /// Calculates the magnitude or length of a Vector.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="vector">The Vector.</param>
    /// <returns>
    /// Returns the Magnitude of the Vector.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Magnitude<T, TResult>(Span<T> vector) where T : INumber<T> where TResult : IFloatingPoint<TResult> => TResult.Sqrt(TResult.Create(MagnitudeSquared(vector)));

    /// <summary>
    /// Calculates the magnitude or length of a two dimensional Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector.</param>
    /// <param name="j">The j component of the Vector.</param>
    /// <returns>
    /// Returns the magnitude of the two dimensional Vector.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Magnitude<T, TResult>(T i, T j) where T : INumber<T> where TResult : IFloatingPoint<TResult> => TResult.Sqrt(TResult.Create((i * i) + (j * j)));

    /// <summary>
    /// Calculates the magnitude or length of a three dimensional Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector.</param>
    /// <param name="j">The j component of the Vector.</param>
    /// <param name="k">The k component of the Vector.</param>
    /// <returns>
    /// Returns the magnitude of the three dimensional Vector.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Magnitude<T, TResult>(T i, T j, T k) where T : INumber<T> where TResult : IFloatingPoint<TResult> => TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k)));

    /// <summary>
    /// Calculates the magnitude or length of a four dimensional Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector.</param>
    /// <param name="j">The j component of the Vector.</param>
    /// <param name="k">The k component of the Vector.</param>
    /// <param name="l">The l component of the Vector.</param>
    /// <returns>
    /// Returns the magnitude of the four dimensional Vector.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Magnitude<T, TResult>(T i, T j, T k, T l) where T : INumber<T> where TResult : IFloatingPoint<TResult> => TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k) + (l * l)));

    /// <summary>
    /// Calculates the magnitude or length of a five dimensional Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector.</param>
    /// <param name="j">The j component of the Vector.</param>
    /// <param name="k">The k component of the Vector.</param>
    /// <param name="l">The l component of the Vector.</param>
    /// <param name="m">The m component of the Vector.</param>
    /// <returns>
    /// Returns the magnitude of the five dimensional vector.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Magnitude<T, TResult>(T i, T j, T k, T l, T m) where T : INumber<T> where TResult : IFloatingPoint<TResult> => TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k) + (l * l) + (m * m)));

    /// <summary>
    /// Calculates the magnitude or length of a six dimensional Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector.</param>
    /// <param name="j">The j component of the Vector.</param>
    /// <param name="k">The k component of the Vector.</param>
    /// <param name="l">The l component of the Vector.</param>
    /// <param name="m">The m component of the Vector.</param>
    /// <param name="n">The n component of the Vector.</param>
    /// <returns>
    /// Returns the magnitude of the six dimensional Vector.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Magnitude<T, TResult>(T i, T j, T k, T l, T m, T n) where T : INumber<T> where TResult : IFloatingPoint<TResult> => TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k) + (l * l) + (m * m) + (n * n)));
    #endregion Modulus Magnitude

    #region Magnitude Squared
    /// <summary>
    /// Calculates the squared magnitude, squared length, or self dot-product of a vector.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="vector">The Vector</param>
    /// <returns>Returns the squared magnitude of the Vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MagnitudeSquared<T>(Span<T> vector)
        where T : INumber<T>
    {
        T result = T.Zero;
        foreach (var value in vector)
        {
            result += value * value;
        }

        return result;
    }

    /// <summary>
    /// Calculates the squared magnitude, squared length, or self dot-product of a two dimensional Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector.</param>
    /// <param name="j">The j component of the Vector.</param>
    /// <returns>Returns the squared magnitude of the two dimensional Vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MagnitudeSquared<T>(T i, T j) where T : INumber<T> => (i * i) + (j * j);

    /// <summary>
    /// Calculates the squared magnitude, squared length, or self dot-product of a three dimensional Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector.</param>
    /// <param name="j">The j component of the Vector.</param>
    /// <param name="k">The k component of the Vector.</param>
    /// <returns>Returns the squared magnitude of the three dimensional Vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MagnitudeSquared<T>(T i, T j, T k) where T : INumber<T> => (i * i) + (j * j) + (k * k);

    /// <summary>
    /// Calculates the squared magnitude, squared length, or self dot-product of a four dimensional Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector.</param>
    /// <param name="j">The j component of the Vector.</param>
    /// <param name="k">The k component of the Vector.</param>
    /// <param name="l">The l component of the Vector.</param>
    /// <returns>Returns the squared magnitude of the four dimensional Vector.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MagnitudeSquared<T>(T i, T j, T k, T l) where T : INumber<T> => (i * i) + (j * j) + (k * k) + (l * l);

    /// <summary>
    /// Calculates the squared magnitude, squared length, or self dot-product of a five dimensional Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector.</param>
    /// <param name="j">The j component of the Vector.</param>
    /// <param name="k">The k component of the Vector.</param>
    /// <param name="l">The l component of the Vector.</param>
    /// <param name="m">The m component of the Vector.</param>
    /// <returns>
    /// Returns the squared magnitude of the five dimensional Vector.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MagnitudeSquared<T>(T i, T j, T k, T l, T m) where T : INumber<T> => (i * i) + (j * j) + (k * k) + (l * l) + (m * m);

    /// <summary>
    /// Calculates the squared magnitude, squared length, or self dot-product of a six dimensional Vector.
    /// </summary>
    /// <param name="i">The i component of the Vector.</param>
    /// <param name="j">The j component of the Vector.</param>
    /// <param name="k">The k component of the Vector.</param>
    /// <param name="l">The l component of the Vector.</param>
    /// <param name="m">The m component of the Vector.</param>
    /// <param name="n">The n component of the Vector.</param>
    /// <returns>
    /// Returns the squared magnitude of the six dimensional Vector.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MagnitudeSquared<T>(T i, T j, T k, T l, T m, T n) where T : INumber<T> => (i * i) + (j * j) + (k * k) + (l * l) + (m * m) + (n * n);
    #endregion

    #region Vector Dot Products
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult DotProduct<T, TResult>(Span<T> left, Span<T> right)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        if (left.Length != right.Length)
        {
            throw new ArgumentException($"The {nameof(left)} and {nameof(right)} parameter Spans must have the same length.");
        }

        TResult value = TResult.Zero;
        for (int i = 0; i < left.Length; i++)
        {
            value += TResult.Create(left[i] * right[i]);
        }

        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>(Span<T> left, Span<T> right)
        where T : INumber<T>
    {
        if (left.Length != right.Length)
        {
            throw new ArgumentException($"The {nameof(left)} and {nameof(right)} parameter Spans must have the same length.");
        }

        T value = T.Zero;
        for (int i = 0; i < left.Length; i++)
        {
            value += T.Create(left[i] * right[i]);
        }

        return value;
    }

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="tuple">X, Y, Z components in tuple form.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>((T X, T Y) tuple, T x2, T y2) where T : INumber<T> => DotProduct(tuple.X, tuple.Y, x2, y2);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="tuple1">First set of X, Y, Z components in tuple form.</param>
    /// <param name="tuple2">Second set of X, Y, Z components in tuple form.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>((T X, T Y) tuple1, (T X, T Y) tuple2) where T : INumber<T> => DotProduct(tuple1.X, tuple1.Y, tuple2.X, tuple2.Y);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="tuple">X, Y, Z components in tuple form.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <param name="z2">Second Point Z component.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>((T X, T Y, T Z) tuple, T x2, T y2, T z2) where T : INumber<T> => DotProduct(tuple.X, tuple.Y, tuple.Z, x2, y2, z2);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="tuple1">First set of X, Y, Z components in tuple form.</param>
    /// <param name="tuple2">Second set of X, Y, Z components in tuple form.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>((T X, T Y, T Z) tuple1, (T X, T Y, T Z) tuple2) where T : INumber<T> => DotProduct(tuple1.X, tuple1.Y, tuple1.Z, tuple2.X, tuple2.Y, tuple2.Z);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="tuple">X, Y, Z components in tuple form.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <param name="z2">Second Point Z component.</param>
    /// <param name="w2">The w2.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>((T X, T Y, T Z, T W) tuple, T x2, T y2, T z2, T w2) where T : INumber<T> => DotProduct(tuple.X, tuple.Y, tuple.Z, tuple.W, x2, y2, z2, w2);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="tuple1">First set of X, Y, Z components in tuple form.</param>
    /// <param name="tuple2">Second set of X, Y, Z components in tuple form.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>((T X, T Y, T Z, T W) tuple1, (T X, T Y, T Z, T W) tuple2) where T : INumber<T> => DotProduct(tuple1.X, tuple1.Y, tuple1.Z, tuple1.W, tuple2.X, tuple2.Y, tuple2.Z, tuple2.W);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="tuple">X, Y, Z components in tuple form.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <param name="z2">Second Point Z component.</param>
    /// <param name="w2">The w2.</param>
    /// <param name="v2">The v2.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>((T X, T Y, T Z, T W, T V) tuple, T x2, T y2, T z2, T w2, T v2) where T : INumber<T> => DotProduct(tuple.X, tuple.Y, tuple.Z, tuple.W, tuple.V, x2, y2, z2, w2, v2);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="tuple1">First set of X, Y, Z components in tuple form.</param>
    /// <param name="tuple2">Second set of X, Y, Z components in tuple form.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>((T X, T Y, T Z, T W, T V) tuple1, (T X, T Y, T Z, T W, T V) tuple2) where T : INumber<T> => DotProduct(tuple1.X, tuple1.Y, tuple1.Z, tuple1.W, tuple1.V, tuple2.X, tuple2.Y, tuple2.Z, tuple2.W, tuple2.V);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="x1">First Point X component.</param>
    /// <param name="y1">First Point Y component.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    /// <remarks>
    /// <para>The dot product "·" is calculated with DotProduct = X ^ 2 + Y ^ 2</para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>(T x1, T y1, T x2, T y2) where T : INumber<T> => (x1 * x2) + (y1 * y2);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="x1">First Point X component.</param>
    /// <param name="y1">First Point Y component.</param>
    /// <param name="z1">First Point Z component.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <param name="z2">Second Point Z component.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>(T x1, T y1, T z1, T x2, T y2, T z2) where T : INumber<T> => (x1 * x2) + (y1 * y2) + (z1 * z2);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="x1">First Point X component.</param>
    /// <param name="y1">First Point Y component.</param>
    /// <param name="z1">First Point Z component.</param>
    /// <param name="w1">First Point W component.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <param name="z2">Second Point Z component.</param>
    /// <param name="w2">Second Point W component.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>(T x1, T y1, T z1, T w1, T x2, T y2, T z2, T w2) where T : INumber<T> => (x1 * x2) + (y1 * y2) + (z1 * z2) + (w1 * w2);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="x1">First Point X component.</param>
    /// <param name="y1">First Point Y component.</param>
    /// <param name="z1">First Point Z component.</param>
    /// <param name="w1">First Point W component.</param>
    /// <param name="v1">First Point V component.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <param name="z2">Second Point Z component.</param>
    /// <param name="w2">Second Point W component.</param>
    /// <param name="v2">Second Point V component.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>(T x1, T y1, T z1, T w1, T v1, T x2, T y2, T z2, T w2, T v2) where T : INumber<T> => (x1 * x2) + (y1 * y2) + (z1 * z2) + (w1 * w2) + (v1 * v2);

    /// <summary>
    /// Calculates the dot Aka. scalar or inner product of a vector.
    /// </summary>
    /// <param name="x1">First Point X component.</param>
    /// <param name="y1">First Point Y component.</param>
    /// <param name="z1">First Point Z component.</param>
    /// <param name="w1">First Point W component.</param>
    /// <param name="v1">First Point V component.</param>
    /// <param name="u1">The u1.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <param name="z2">Second Point Z component.</param>
    /// <param name="w2">Second Point W component.</param>
    /// <param name="v2">Second Point V component.</param>
    /// <param name="u2">The u2.</param>
    /// <returns>
    /// The Dot Product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>(T x1, T y1, T z1, T w1, T v1, T u1, T x2, T y2, T z2, T w2, T v2, T u2) where T : INumber<T> => (x1 * x2) + (y1 * y2) + (z1 * z2) + (w1 * w2) + (v1 * v2) + (u1 * u2);
    #endregion

    #region Dot Product Triple Vector
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="left"></param>
    /// <param name="middle"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult DotProduct<T, TResult>(Span<T> left, Span<T> middle, Span<T> right)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        if (left.Length != right.Length || left.Length != middle.Length)
        {
            throw new ArgumentException($"The {nameof(left)}, {nameof(middle)} and {nameof(right)} parameter Spans must have the same length.");
        }

        TResult value = TResult.Zero;
        for (int i = 0; i < left.Length; i++)
        {
            value += TResult.Create((left[i] - middle[i]) * (right[i] - middle[i]));
        }

        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="middle"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DotProduct<T>(Span<T> left, Span<T> middle, Span<T> right)
        where T : INumber<T>
    {
        if (left.Length != right.Length || left.Length != middle.Length)
        {
            throw new ArgumentException($"The {nameof(left)}, {nameof(middle)} and {nameof(right)} parameter Spans must have the same length.");
        }

        T value = T.Zero;
        for (int i = 0; i < left.Length; i++)
        {
            value += (left[i] - middle[i]) * (right[i] - middle[i]);
        }

        return value;
    }

    /// <summary>
    /// The Dot Product of the Vector of three points
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="x3">The x3.</param>
    /// <param name="y3">The y3.</param>
    /// <returns>
    /// Return the dot product AB · BC.
    /// </returns>
    /// <remarks>
    /// <para>Note that AB · BC = |AB| * |BC| * Cos(theta).</para>
    /// </remarks>
    /// <acknowledgment>
    /// http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DeltaDotProduct<T>(T x1, T y1, T x2, T y2, T x3, T y3) where T : INumber<T> => ((x1 - x2) * (x3 - x2)) + ((y1 - y2) * (y3 - y2));

    /// <summary>
    /// The Dot Product of the Vector of three points
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="z2">The z2.</param>
    /// <param name="x3">The x3.</param>
    /// <param name="y3">The y3.</param>
    /// <param name="z3">The z3.</param>
    /// <returns>
    /// Return the dot product AB · BC.
    /// </returns>
    /// <remarks>
    /// <para>Note that AB · BC = |AB| * |BC| * Cos(theta).</para>
    /// </remarks>
    /// <acknowledgment>
    /// http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DeltaDotProduct<T>(T x1, T y1, T z1, T x2, T y2, T z2, T x3, T y3, T z3) where T : INumber<T> => ((x1 - x2) * (x3 - x2)) + ((y1 - y2) * (y3 - y2)) + ((z1 - z2) * (z3 - z2));

    /// <summary>
    /// The Dot Product of the Vector of three points
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="w1">The w1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="z2">The z2.</param>
    /// <param name="w2">The w2.</param>
    /// <param name="x3">The x3.</param>
    /// <param name="y3">The y3.</param>
    /// <param name="z3">The z3.</param>
    /// <param name="w3">The w3.</param>
    /// <returns>
    /// Return the dot product AB · BC.
    /// </returns>
    /// <remarks>
    /// <para>Note that AB · BC = |AB| * |BC| * Cos(theta).</para>
    /// </remarks>
    /// <acknowledgment>
    /// http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DeltaDotProduct<T>(T x1, T y1, T z1, T w1, T x2, T y2, T z2, T w2, T x3, T y3, T z3, T w3) where T : INumber<T> => ((x1 - x2) * (x3 - x2)) + ((y1 - y2) * (y3 - y2)) + ((z1 - z2) * (z3 - z2)) + ((w1 - w2) * (w3 - w2));

    /// <summary>
    /// The Dot Product of the Vector of three points
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="w1">The w1.</param>
    /// <param name="v1">The v1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="z2">The z2.</param>
    /// <param name="w2">The w2.</param>
    /// <param name="v2">The v2.</param>
    /// <param name="x3">The x3.</param>
    /// <param name="y3">The y3.</param>
    /// <param name="z3">The z3.</param>
    /// <param name="w3">The w3.</param>
    /// <param name="v3">The v3.</param>
    /// <returns>
    /// Return the dot product AB · BC.
    /// </returns>
    /// <remarks>
    /// <para>Note that AB · BC = |AB| * |BC| * Cos(theta).</para>
    /// </remarks>
    /// <acknowledgment>
    /// http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DeltaDotProduct<T>(T x1, T y1, T z1, T w1, T v1, T x2, T y2, T z2, T w2, T v2, T x3, T y3, T z3, T w3, T v3) where T : INumber<T> => ((x1 - x2) * (x3 - x2)) + ((y1 - y2) * (y3 - y2)) + ((z1 - z2) * (z3 - z2)) + ((w1 - w2) * (w3 - w2)) + ((v1 - v2) * (v3 - v2));

    /// <summary>
    /// The Dot Product of the Vector of three points
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="w1">The w1.</param>
    /// <param name="v1">The v1.</param>
    /// <param name="u1">The u1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="z2">The z2.</param>
    /// <param name="w2">The w2.</param>
    /// <param name="v2">The v2.</param>
    /// <param name="u2">The u2.</param>
    /// <param name="x3">The x3.</param>
    /// <param name="y3">The y3.</param>
    /// <param name="z3">The z3.</param>
    /// <param name="w3">The w3.</param>
    /// <param name="v3">The v3.</param>
    /// <param name="u3">The u3.</param>
    /// <returns>
    /// Return the dot product AB · BC.
    /// </returns>
    /// <remarks>
    /// <para>Note that AB · BC = |AB| * |BC| * Cos(theta).</para>
    /// </remarks>
    /// <acknowledgment>
    /// http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T DeltaDotProduct<T>(T x1, T y1, T z1, T w1, T v1, T u1, T x2, T y2, T z2, T w2, T v2, T u2, T x3, T y3, T z3, T w3, T v3, T u3) where T : INumber<T> => ((x1 - x2) * (x3 - x2)) + ((y1 - y2) * (y3 - y2)) + ((z1 - z2) * (z3 - z2)) + ((w1 - w2) * (w3 - w2)) + ((v1 - v2) * (v3 - v2)) + ((u1 - u2) * (u3 - u2));
    #endregion Dot Product Triple Vector

    #region Cross Product
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] CrossProduct<T, TResult>(Span<T> left, Span<T> right)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        if (left.Length != right.Length)
        {
            throw new ArgumentException($"The {nameof(left)} and {nameof(right)} parameter Spans must have the same length.");
        }

        var value = new TResult[] { TResult.Zero };
        //for (int i = 0; i < left.Length; i++)
        //{
        //    value += TResult.Create(left[i] * right[i]);
        //}

        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] CrossProduct<T>(Span<T> left, Span<T> right)
        where T : INumber<T>
    {
        if (left.Length != right.Length)
        {
            throw new ArgumentException($"The {nameof(left)} and {nameof(right)} parameter Spans must have the same length.");
        }

        var value = new T[] { T.Zero };
        //for (int i = 0; i < left.Length; i++)
        //{
        //    value += T.Create(left[i] * right[i]);
        //}

        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="left"></param>
    /// <param name="middle"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] CrossProduct<T, TResult>(Span<T> left, Span<T> middle, Span<T> right)
        where T : INumber<T>
        where TResult : INumber<TResult>
    {
        if (left.Length != right.Length || left.Length != middle.Length)
        {
            throw new ArgumentException($"The {nameof(left)}, {nameof(middle)} and {nameof(right)} parameter Spans must have the same length.");
        }

        var value = new TResult[] { TResult.Zero };
        //for (int i = 0; i < left.Length; i++)
        //{
        //    value += TResult.Create((left[i] - middle[i]) * (right[i] - middle[i]));
        //}

        return value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="left"></param>
    /// <param name="middle"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T[] CrossProduct<T>(Span<T> left, Span<T> middle, Span<T> right)
        where T : INumber<T>
    {
        if (left.Length != right.Length || left.Length != middle.Length)
        {
            throw new ArgumentException($"The {nameof(left)}, {nameof(middle)} and {nameof(right)} parameter Spans must have the same length.");
        }

        var value = new T[] { T.Zero };
        //for (int i = 0; i < left.Length; i++)
        //{
        //    value += (left[i] - middle[i]) * (right[i] - middle[i]);
        //}

        return value;
    }

    /// <summary>
    /// Cross Product of two points.
    /// </summary>
    /// <param name="t1">The t1.</param>
    /// <param name="t2">The t2.</param>
    /// <returns>
    /// the cross product AB · BC.
    /// </returns>
    /// <remarks>
    /// <para>Note that AB · BC = |AB| * |BC| * Cos(theta).</para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T CrossProduct<T>((T x, T y) t1, (T x, T y) t2) where T : INumber<T> => CrossProduct(t1.x, t1.y, t2.x, t2.y);

    /// <summary>
    /// The cross product.
    /// </summary>
    /// <param name="t1">The t1.</param>
    /// <param name="t2">The t2.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) CrossProduct<T>((T x, T y, T z) t1, (T x, T y, T z) t2) where T : INumber<T> => CrossProduct(t1.x, t1.y, t1.z, t2.x, t2.y, t2.z);

    /// <summary>
    /// Cross Product of two points.
    /// </summary>
    /// <param name="x1">First Point X component.</param>
    /// <param name="y1">First Point Y component.</param>
    /// <param name="x2">Second Point X component.</param>
    /// <param name="y2">Second Point Y component.</param>
    /// <returns>the cross product AB · BC.</returns>
    /// <remarks><para>Note that AB · BC = |AB| * |BC| * Cos(theta).</para></remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T CrossProduct<T>(T x1, T y1, T x2, T y2) where T : INumber<T> => (x1 * y2) - (y1 * x2);

    /// <summary>
    /// The cross product.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="z2">The z2.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z) CrossProduct<T>(T x1, T y1, T z1, T x2, T y2, T z2) where T : INumber<T> => (X: (y1 * z2) - (z1 * y2), Y: (z1 * x2) - (x1 * z2), Z: (x1 * y2) - (y1 * x2));
    #endregion Cross Product

    #region Cross Product Triple
    /// <summary>
    /// The cross product vector.
    /// The cross product is a vector perpendicular to AB
    /// and BC having length |AB| * |BC| * Sin(theta) and
    /// with direction given by the right-hand rule.
    /// For two vectors in the X-Y plane, the result is a
    /// vector with X and Y components 0 so the Z component
    /// gives the vector's length and direction.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="x3">The x3.</param>
    /// <param name="y3">The y3.</param>
    /// <returns>Return the cross product AB x BC.</returns>
    /// <acknowledgment>
    /// http://csharphelper.com/blog/2014/07/determine-whether-a-point-is-inside-a-polygon-in-c/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T CrossProductTriple<T>(T x1, T y1, T x2, T y2, T x3, T y3) where T : INumber<T> => ((x1 - x2) * (y3 - y2)) - ((y1 - y2) * (x3 - x2));

    /// <summary>
    /// Cross4 computes the four-dimensional cross product of the three vectors U, V and W, in that order. It returns the resulting four-vector.
    /// https://web.archive.org/web/20040213224251/http://research.microsoft.com/~hollasch/thesis/chapter2.html
    /// </summary>
    /// <param name="uI">The u i.</param>
    /// <param name="uJ">The u j.</param>
    /// <param name="uK">The u k.</param>
    /// <param name="uL">The u l.</param>
    /// <param name="vI">The v i.</param>
    /// <param name="vJ">The v j.</param>
    /// <param name="vK">The v k.</param>
    /// <param name="vL">The v l.</param>
    /// <param name="wI">The w i.</param>
    /// <param name="wJ">The w j.</param>
    /// <param name="wK">The w k.</param>
    /// <param name="wL">The w l.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y, T Z, T W)
        CrossProductTriple<T>(
        T uI, T uJ, T uK, T uL,
        T vI, T vJ, T vK, T vL,
        T wI, T wJ, T wK, T wL) where T : INumber<T>
    {
        // Calculate intermediate values.
        var a = (vI * wJ) - (vJ * wI);
        var b = (vI * wK) - (vK * wI);
        var c = (vI * wL) - (vL * wI);
        var d = (vJ * wK) - (vK * wJ);
        var e = (vJ * wL) - (vL * wJ);
        var f = (vK * wL) - (vL * wK);

        // Calculate the result-vector components.
        return (
            (uJ * f) - (uK * e) + (uL * d),
            -(uI * f) + (uK * c) - (uL * b),
            (uI * e) - (uJ * c) + (uL * a),
            -(uI * d) + (uJ * b) - (uK * a)
         );
    }
    #endregion Cross Product Triple

    #region Complex Product
    /// <summary>
    /// The complex product.
    /// </summary>
    /// <param name="x0">The x0.</param>
    /// <param name="y0">The y0.</param>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://stackoverflow.com/questions/1476497/multiply-two-point-objects
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) ComplexProduct<T>(
        T x0, T y0,
        T x1, T y1) where T : INumber<T>
        => (
            (x0 * x1) - (y0 * y1),
            (x0 * y1) + (y0 * x1)
            );
    #endregion Complex Product

    #region Mixed Product
    /// <summary>
    /// The mixed product.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="z2">The z2.</param>
    /// <param name="x3">The x3.</param>
    /// <param name="y3">The y3.</param>
    /// <param name="z3">The z3.</param>
    /// <returns>
    /// The mixed product.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static T MixedProduct<T>(T x1, T y1, T z1, T x2, T y2, T z2, T x3, T y3, T z3) where T : INumber<T> => DotProduct(CrossProduct(x1, y1, z1, x2, y2, z2), x3, y3, z3);
    #endregion Mixed Product

    #region Normalize Vector
    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y) Normalize<T, TResult>((T i, T j) tuple) where T : INumber<T> where TResult : IFloatingPoint<TResult> => Normalize<T, TResult>(tuple.i, tuple.j);

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) Normalize<T, TResult>((T i, T j, T k) tuple) where T : INumber<T> where TResult : IFloatingPoint<TResult> => Normalize<T, TResult>(tuple.i, tuple.j, tuple.k);

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="tuple">The tuple.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W) Normalize<T, TResult>((T i, T j, T k, T l) tuple) where T : INumber<T> where TResult : IFloatingPoint<TResult> => Normalize<T, TResult>(tuple.i, tuple.j, tuple.k, tuple.l);

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult Normalize<T, TResult>(T i) where T : INumber<T> where TResult : IFloatingPoint<TResult> => TResult.Create(i) / TResult.Sqrt(TResult.Create(i * i));

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y) Normalize<T, TResult>(T i, T j) where T : INumber<T> where TResult : IFloatingPoint<TResult> => (TResult.Create(i) / TResult.Sqrt(TResult.Create((i * i) + (j * j))), TResult.Create(j) / TResult.Sqrt(TResult.Create((i * i) + (j * j))));

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="k">The k.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) Normalize<T, TResult>(T i, T j, T k) where T : INumber<T> where TResult : IFloatingPoint<TResult> => (TResult.Create(i) / TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k))), TResult.Create(j) / TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k))), TResult.Create(k) / TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k))));

    /// <summary>
    /// Normalize a Vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <param name="k">The k.</param>
    /// <param name="l">The l.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W) Normalize<T, TResult>(T i, T j, T k, T l) where T : INumber<T> where TResult : IFloatingPoint<TResult> => (TResult.Create(i) / TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k) + (l * l))), TResult.Create(j) / TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k) + (l * l))), TResult.Create(k) / TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k) + (l * l))), TResult.Create(l) / TResult.Sqrt(TResult.Create((i * i) + (j * j) + (k * k) + (l * l))));
    #endregion

    #region Normalize Vectors
    /// <summary>
    /// Find the Normal of Two points.
    /// </summary>
    /// <param name="i1">The x component of the first Point.</param>
    /// <param name="j1">The y component of the first Point.</param>
    /// <param name="i2">The x component of the second Point.</param>
    /// <param name="j2">The y component of the second Point.</param>
    /// <returns>
    /// The Normal of two Points
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y) NormalizeVectors<T, TResult>(T i1, T j1, T i2, T j2) where T : INumber<T> where TResult : IFloatingPoint<TResult> => (TResult.Create(i1) / TResult.Sqrt(TResult.Create((i1 * i2) + (j1 * j2))), TResult.Create(j1) / TResult.Sqrt(TResult.Create((i1 * i2) + (j1 * j2))));

    /// <summary>
    /// Find the Normal of Two vectors.
    /// </summary>
    /// <param name="i1">The x component of the first Point.</param>
    /// <param name="j1">The y component of the first Point.</param>
    /// <param name="k1">The z component of the second Point.</param>
    /// <param name="i2">The x component of the second Point.</param>
    /// <param name="j2">The y component of the second Point.</param>
    /// <param name="k2">The z component of the second Point.</param>
    /// <returns>
    /// The Normal of two Points
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) NormalizeVectors<T, TResult>(T i1, T j1, T k1, T i2, T j2, T k2) where T : INumber<T> where TResult : IFloatingPoint<TResult> => (TResult.Create(i1) / TResult.Sqrt(TResult.Create((i1 * i2) + (j1 * j2) + (k1 * k2))), TResult.Create(j1) / TResult.Sqrt(TResult.Create((i1 * i2) + (j1 * j2) + (k1 * k2))), TResult.Create(k1) / TResult.Sqrt(TResult.Create((i1 * i2) + (j1 * j2) + (k1 * k2))));

    /// <summary>
    /// Find the Normal of Two vectors.
    /// </summary>
    /// <param name="i1">The x component of the first Point.</param>
    /// <param name="j1">The y component of the first Point.</param>
    /// <param name="k1">The z component of the first Point.</param>
    /// <param name="l1">The l1.</param>
    /// <param name="i2">The x component of the second Point.</param>
    /// <param name="j2">The y component of the second Point.</param>
    /// <param name="k2">The z component of the second Point.</param>
    /// <param name="l2">The l2.</param>
    /// <returns>
    /// The Normal of two Points
    /// </returns>
    /// <acknowledgment>
    /// http://www.fundza.com/vectors/normalize/
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z, TResult W) NormalizeVectors<T, TResult>(T i1, T j1, T k1, T l1, T i2, T j2, T k2, T l2) where T : INumber<T> where TResult : IFloatingPoint<TResult> => (TResult.Create(i1) / TResult.Sqrt(TResult.Create((i1 * i2) + (j1 * j2) + (k1 * k2) + (l1 * l2))), TResult.Create(j1) / TResult.Sqrt(TResult.Create((i1 * i2) + (j1 * j2) + (k1 * k2) + (l1 * l2))), TResult.Create(k1) / TResult.Sqrt(TResult.Create((i1 * i2) + (j1 * j2) + (k1 * k2) + (l1 * l2))), TResult.Create(l1) / TResult.Sqrt(TResult.Create((i1 * i2) + (j1 * j2) + (k1 * k2) + (l1 * l2))));
    #endregion Normalize Vectors

    #region Unit Normal
    /// <summary>
    /// Get the unit normal.
    /// </summary>
    /// <param name="pt1X">The pt1X.</param>
    /// <param name="pt1Y">The pt1Y.</param>
    /// <param name="pt2X">The pt2X.</param>
    /// <param name="pt2Y">The pt2Y.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.angusj.com
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y) UnitNormal<T, TResult>(T pt1X, T pt1Y, T pt2X, T pt2Y)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        var dx = TResult.Create(pt2X - pt1X);
        var dy = TResult.Create(pt2Y - pt1Y);
        if ((dx == TResult.Zero) && (dy == TResult.Zero))
        {
            return (TResult.Zero, TResult.Zero);
        }

        var f = TResult.One / TResult.Sqrt(TResult.Create((dx * dx) + (dy * dy)));
        dx *= f;
        dy *= f;

        return (dy, -dx);
    }
    #endregion Unit Normal

    #region Perpendicular Clockwise
    /// <summary>
    /// Find the Clockwise Perpendicular of a Vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>To get the perpendicular vector in two dimensions use I = -J, J = I</para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) PerpendicularClockwise<T>(T i, T j) where T : INumber<T> => (-j, i);
    #endregion Perpendicular Clockwise

    #region Perpendicular Counter Clockwise
    /// <summary>
    /// Find the Counter Clockwise Perpendicular of a Vector.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <param name="j">The j.</param>
    /// <returns></returns>
    /// <remarks>
    /// <para>To get the perpendicular vector in two dimensions use I = -J, J = I</para>
    /// </remarks>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T X, T Y) PerpendicularCounterClockwise<T>(T i, T j) where T : INumber<T> => (j, -i);
    #endregion Perpendicular Counter Clockwise

    #region Rotate Point
    /// <summary>
    /// Rotate a point around the world origin.
    /// </summary>
    /// <param name="x">The x component of the point to rotate.</param>
    /// <param name="y">The y component of the point to rotate.</param>
    /// <param name="angle">The angle to rotate in pi radians.</param>
    /// <returns>
    /// A point rotated about the origin by the specified pi radian angle.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y) RotatePoint2D<T, TResult>(T x, T y, TResult angle) where T : INumber<T> where TResult : IFloatingPoint<TResult> => RotatePoint2D(x, y, TResult.Cos(angle), TResult.Sin(angle), T.Zero, T.Zero);

    /// <summary>
    /// Rotate a point around the world origin.
    /// </summary>
    /// <param name="x">The x component of the point to rotate.</param>
    /// <param name="y">The y component of the point to rotate.</param>
    /// <param name="cos">The cos.</param>
    /// <param name="sin">The sin.</param>
    /// <returns>
    /// A point rotated about the origin by the specified pi radian angle.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y) RotatePoint2D<T, TResult>(T x, T y, TResult cos, TResult sin) where T : INumber<T> where TResult : IFloatingPoint<TResult> => RotatePoint2D(x, y, cos, sin, T.Zero, T.Zero);

    /// <summary>
    /// Rotate a point around a fulcrum point.
    /// </summary>
    /// <param name="x">The x component of the point to rotate.</param>
    /// <param name="y">The y component of the point to rotate.</param>
    /// <param name="angle">The angle to rotate the point in pi radians.</param>
    /// <param name="cx">The x component of the fulcrum point to rotate the point around.</param>
    /// <param name="cy">The y component of the fulcrum point to rotate the point around.</param>
    /// <returns>
    /// A point rotated about the fulcrum point by the specified pi radian angle.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y) RotatePoint2D<T, TResult>(T x, T y, TResult angle, T cx, T cy) where T : INumber<T> where TResult : IFloatingPoint<TResult> => RotatePoint2D(x, y, TResult.Cos(angle), TResult.Sin(angle), cx, cy);

    /// <summary>
    /// Rotate a point around a fulcrum point.
    /// </summary>
    /// <param name="x">The x component of the point to rotate.</param>
    /// <param name="y">The y component of the point to rotate.</param>
    /// <param name="cos">The cos.</param>
    /// <param name="sin">The sin.</param>
    /// <param name="cx">The x component of the fulcrum point to rotate the point around.</param>
    /// <param name="cy">The y component of the fulcrum point to rotate the point around.</param>
    /// <returns>
    /// A point rotated about the fulcrum point by the specified pi radian angle.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y) RotatePoint2D<T, TResult>(T x, T y, TResult cos, TResult sin, T cx, T cy)
        where T : INumber<T> where TResult : IFloatingPoint<TResult>
    {
        var deltaX = TResult.Create(x - cx);
        var deltaY = TResult.Create(y - cy);
        return (TResult.Create(cx) + ((deltaX * cos) - (deltaY * sin)),
                TResult.Create(cy) + ((deltaX * sin) + (deltaY * cos)));
    }
    #endregion Rotate Point

    #region Pitch Rotate X
    /// <summary>
    /// The rotate x.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="yOff">The yOff.</param>
    /// <param name="zOff">The zOff.</param>
    /// <param name="rad">The rad.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) PitchRotateX<T, TResult>(T x1, T y1, T z1, T yOff, T zOff, TResult rad) where T : INumber<T> where TResult : IFloatingPoint<TResult> => PitchRotateX(x1, y1, z1, yOff, zOff, TResult.Sin(rad), TResult.Cos(rad));

    /// <summary>
    /// The rotate x.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="rad">The rad.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) PitchRotateX<T, TResult>(T x1, T y1, T z1, TResult rad) where T : INumber<T> where TResult : IFloatingPoint<TResult> => PitchRotateX(x1, y1, z1, TResult.Sin(rad), TResult.Cos(rad));

    /// <summary>
    /// The rotate x.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="sin">The sin.</param>
    /// <param name="cos">The cos.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) PitchRotateX<T, TResult>(T x1, T y1, T z1, TResult sin, TResult cos) where T : INumber<T> where TResult : IFloatingPoint<TResult> => (TResult.Create(x1), (TResult.Create(y1) * cos) - (TResult.Create(z1) * sin), (TResult.Create(y1) * sin) + (TResult.Create(z1) * cos));

    /// <summary>
    /// The rotate x.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="yOff">The yOff.</param>
    /// <param name="zOff">The zOff.</param>
    /// <param name="sin">The Sine of the angle.</param>
    /// <param name="cos">The Cosine of the angle.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) PitchRotateX<T, TResult>(T x1, T y1, T z1, T yOff, T zOff, TResult sin, TResult cos) where T : INumber<T> where TResult : IFloatingPoint<TResult> => (TResult.Create(x1), (TResult.Create(y1) * cos) - (TResult.Create(z1) * sin) + ((TResult.Create(yOff) * (TResult.One - cos)) + (TResult.Create(zOff) * sin)), (TResult.Create(y1) * sin) + (TResult.Create(z1) * cos) + ((TResult.Create(zOff) * (TResult.One - cos)) - (TResult.Create(yOff) * sin)));
    #endregion Pitch Rotate X

    #region Yaw Rotate Y
    /// <summary>
    /// The rotate y.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="rad">The rad.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) YawRotateY<T, TResult>(T x1, T y1, T z1, TResult rad) where T : INumber<T> where TResult : IFloatingPoint<TResult> => YawRotateY(x1, y1, z1, TResult.Sin(rad), TResult.Cos(rad));

    /// <summary>
    /// The rotate y.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="xOff">The xOff.</param>
    /// <param name="zOff">The zOff.</param>
    /// <param name="rad">The rad.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) YawRotateY<T, TResult>(T x1, T y1, T z1, T xOff, T zOff, TResult rad) where T : INumber<T> where TResult : IFloatingPoint<TResult> => YawRotateY(x1, y1, z1, xOff, zOff, TResult.Sin(rad), TResult.Cos(rad));

    /// <summary>
    /// The rotate y.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="sin">The Sine of the angle.</param>
    /// <param name="cos">The Cosine of the angle.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) YawRotateY<T, TResult>(T x1, T y1, T z1, TResult sin, TResult cos) where T : INumber<T> where TResult : IFloatingPoint<TResult> => ((TResult.Create(z1) * sin) + (TResult.Create(x1) * cos), TResult.Create(y1), (TResult.Create(z1) * cos) - (TResult.Create(x1) * sin));

    /// <summary>
    /// The rotate y.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="xOff">The xOff.</param>
    /// <param name="zOff">The zOff.</param>
    /// <param name="sin">The Sine of the angle.</param>
    /// <param name="cos">The Cosine of the angle.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) YawRotateY<T, TResult>(T x1, T y1, T z1, T xOff, T zOff, TResult sin, TResult cos) where T : INumber<T> where TResult : IFloatingPoint<TResult> => ((TResult.Create(z1) * sin) + (TResult.Create(x1) * cos) + ((TResult.Create(xOff) * (TResult.One - cos)) - (TResult.Create(zOff) * sin)), TResult.Create(y1), (TResult.Create(z1) * cos) - (TResult.Create(x1) * sin) + ((TResult.Create(zOff) * (TResult.One - cos)) + (TResult.Create(xOff) * sin)));
    #endregion Yaw Rotate Y

    #region Roll Rotate Z
    /// <summary>
    /// The rotate z.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="rad">The rad.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) RollRotateZ<T, TResult>(T x1, T y1, T z1, TResult rad) where T : INumber<T> where TResult : IFloatingPoint<TResult> => RollRotateZ(x1, y1, z1, TResult.Sin(rad), TResult.Cos(rad));

    /// <summary>
    /// The rotate z.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="xOff">The xOff.</param>
    /// <param name="yOff">The yOff.</param>
    /// <param name="rad">The rad.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) RollRotateZ<T, TResult>(T x1, T y1, T z1, T xOff, T yOff, TResult rad) where T : INumber<T> where TResult : IFloatingPoint<TResult> => RollRotateZ(x1, y1, z1, xOff, yOff, TResult.Sin(rad), TResult.Cos(rad));

    /// <summary>
    /// The rotate z.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="sin">The sin.</param>
    /// <param name="cos">The cos.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) RollRotateZ<T, TResult>(T x1, T y1, T z1, TResult sin, TResult cos) where T : INumber<T> where TResult : IFloatingPoint<TResult> => ((TResult.Create(x1) * cos) - (TResult.Create(y1) * sin), (TResult.Create(x1) * sin) + (TResult.Create(y1) * cos), TResult.Create(z1));

    /// <summary>
    /// The rotate z.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="xOff">The xOff.</param>
    /// <param name="yOff">The yOff.</param>
    /// <param name="sin">The Sine of the angle.</param>
    /// <param name="cos">The Cosine of the angle.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) RollRotateZ<T, TResult>(T x1, T y1, T z1, T xOff, T yOff, TResult sin, TResult cos) where T : INumber<T> where TResult : IFloatingPoint<TResult> => ((TResult.Create(x1) * cos) - (TResult.Create(y1) * sin) + ((TResult.Create(xOff) * (TResult.One - cos)) + (TResult.Create(yOff) * sin)), (TResult.Create(x1) * sin) + (TResult.Create(y1) * cos) + ((TResult.Create(yOff) * (TResult.One - cos)) - (TResult.Create(xOff) * sin)), TResult.Create(z1));
    #endregion Roll Rotate Z

    #region Projection
    /// <summary>
    /// The projection.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="z2">The z2.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) Projection<T, TResult>(T x1, T y1, T z1, T x2, T y2, T z2) where T : INumber<T> where TResult : IFloatingPoint<TResult> => (TResult.Create(x2 * DotProduct(x1, y1, z1, x2, y2, z2)) / Magnitude<T, TResult>(x2, y2, z2) * Magnitude<T, TResult>(x2, y2, z2), TResult.Create(y2 * DotProduct(x1, y1, z1, x2, y2, z2)) / Magnitude<T, TResult>(x2, y2, z2) * Magnitude<T, TResult>(x2, y2, z2), TResult.Create(z2 * DotProduct(x1, y1, z1, x2, y2, z2)) / Magnitude<T, TResult>(x2, y2, z2) * Magnitude<T, TResult>(x2, y2, z2));
    #endregion Projection

    #region Rejection
    /// <summary>
    /// The rejection.
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="z1">The z1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="z2">The z2.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) Rejection<T, TResult>(T x1, T y1, T z1, T x2, T y2, T z2) where T : INumber<T> where TResult : IFloatingPoint<TResult> => (TResult.Create(x1) - (TResult.Create(x2 * DotProduct(x1, y1, z1, x2, y2, z2)) / Magnitude<T, TResult>(x2, y2, z2) * Magnitude<T, TResult>(x2, y2, z2)), TResult.Create(z1) - (TResult.Create(y2 * DotProduct(x1, y1, z1, x2, y2, z2)) / Magnitude<T, TResult>(x2, y2, z2) * Magnitude<T, TResult>(x2, y2, z2)), TResult.Create(z1) - (TResult.Create(z2 * DotProduct(x1, y1, z1, x2, y2, z2)) / Magnitude<T, TResult>(x2, y2, z2) * Magnitude<T, TResult>(x2, y2, z2)));
    #endregion Rejection

    #region Reflect
    /// <summary>
    /// Calculates the reflection of a point off a line segment
    /// </summary>
    /// <param name="x1">The x1.</param>
    /// <param name="y1">The y1.</param>
    /// <param name="x2">The x2.</param>
    /// <param name="y2">The y2.</param>
    /// <param name="axisX">The axis x.</param>
    /// <param name="axisY">The axis y.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (T I, T J) Reflect<T>(T x1, T y1, T x2, T y2, T axisX, T axisY) where T : INumber<T>
    {
        var (i, j) = DeltaVector(x1, y1, x2, y2);
        var magnatude = DotProduct(i, j, i, j) / T.Create(2);
        var reflection = CrossProduct(i, j, CrossProduct(x2, y2, x1, y1), DotProduct(axisX, axisY, i, j));
        return ((magnatude * reflection) - axisX,
                (magnatude * reflection) - axisY);
    }
    #endregion Reflect

    #region Reflection
    /// <summary>
    /// The reflection.
    /// </summary>
    /// <param name="i1">The i1.</param>
    /// <param name="j1">The j1.</param>
    /// <param name="k1">The k1.</param>
    /// <param name="i2">The i2.</param>
    /// <param name="j2">The j2.</param>
    /// <param name="k2">The k2.</param>
    /// <returns>
    /// The <see cref="ValueTuple{T1, T2, T3}" />.
    /// </returns>
    /// <acknowledgment>
    /// http://www.codeproject.com/Articles/17425/A-Vector-Type-for-C
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static (TResult X, TResult Y, TResult Z) Reflection<T, TResult>(
        T i1, T j1, T k1,
        T i2, T j2, T k2) where T : INumber<T> where TResult : IFloatingPoint<TResult>
    {
        // if v2 has a right angle to vector, return -vector and stop
        if (TResult.Abs(TResult.Abs(Angle<T, TResult>(i1, j1, k1, i2, j2, k2)) - (TResult.Pi / TResult.Create(2))) < TResult.Epsilon)
        {
            return (TResult.Create(-i1), TResult.Create(-j1), TResult.Create(-k1));
        }

        (var x, var y, var z) = Projection<T, TResult>(i1, j1, k1, i2, j2, k2);
        return (
            ((TResult.Create(2) * x) - TResult.Create(i1)) * Magnitude<T, TResult>(i1, j1, k1),
            ((TResult.Create(2) * y) - TResult.Create(j1)) * Magnitude<T, TResult>(i1, j1, k1),
            ((TResult.Create(2) * z) - TResult.Create(k1)) * Magnitude<T, TResult>(i1, j1, k1)
            );
    }
    #endregion Reflection

    #region Vector Euclidean Norm
    /// <summary>
    /// Euclidean norm.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult EuclideanNorm<T, TResult>(Span<T> vector)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        var result = T.Zero;
        for (var i = 0; i < vector.Length; i++)
        {
            result += vector[i] * vector[i];
        }

        return TResult.Sqrt(TResult.Create(result));
    }

    /// <summary>
    /// Euclidean norm.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="length">The length.</param>
    /// <returns></returns>
    /// <acknowledgment>
    /// https://github.com/GeorgiSGeorgiev/ExtendedMatrixCalculator
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult EuclideanNorm<T, TResult>(Span<T> vector, int length)
        where T : INumber<T>
        where TResult : IFloatingPoint<TResult>
    {
        var result = T.Zero;
        for (var i = 0; i < length; i++)
        {
            result += vector[i] * vector[i];
        }

        return TResult.Sqrt(TResult.Create(result));
    }
    #endregion
}
