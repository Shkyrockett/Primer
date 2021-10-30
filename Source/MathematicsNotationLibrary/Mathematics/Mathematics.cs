// <copyright file="Mathematics.cs" company="Shkyrockett" >
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
using System.Drawing;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
public static partial class Mathematics
{
    /// <summary>
    /// The scale per mouse wheel delta.
    /// </summary>
    public const float scale_per_delta = 0.1f / 120f;

    /// <summary>
    /// Scales the factor.
    /// </summary>
    /// <param name="scale">The scale.</param>
    /// <param name="delta">The delta.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static float MouseWheelScaleFactor(float scale, int delta)
    {
        scale += delta * scale_per_delta;
        return (scale <= 0) ? 2f * float.Epsilon : scale;
    }

    #region Point Manipulation Methods
    /// <summary>
    /// Inverses the scale point.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF ScreenToObject_(PointF point, float scale)
    {
        var invScale = 1f / scale;
        return new PointF(invScale * point.X, invScale * point.Y);
    }

    /// <summary>
    /// Screens to object.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF ScreenToObject(PointF point, float scale) => new(point.X / scale, point.Y / scale);

    /// <summary>
    /// Inverses the translation and scale of a point.
    /// </summary>
    /// <param name="offset">The offset.</param>
    /// <param name="point">The point.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF ScreenToObject_(PointF offset, PointF point, float scale)
    {
        var invScale = 1f / scale;
        return new PointF((point.X - offset.X) * invScale, (point.Y - offset.Y) * invScale);
    }

    /// <summary>
    /// Screens to object. https://stackoverflow.com/a/37269366
    /// </summary>
    /// <param name="offset">The offset.</param>
    /// <param name="point">The screen point.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF ScreenToObject(PointF offset, PointF point, float scale) => new((point.X - offset.X) / scale, (point.Y - offset.Y) / scale);

    /// <summary>
    /// Screens to object transposed matrix.
    /// </summary>
    /// <param name="offset">The offset.</param>
    /// <param name="screenPoint">The screen point.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF ScreenToObjectTransposedMatrix_(PointF offset, PointF screenPoint, float scale)
    {
        var invScale = 1f / scale;
        return new PointF((screenPoint.X * invScale) - offset.X, (screenPoint.Y * invScale) - offset.Y);
    }

    /// <summary>
    /// Screens to object transposed matrix. https://stackoverflow.com/a/37269366
    /// </summary>
    /// <param name="offset">The offset.</param>
    /// <param name="screenPoint">The screen point.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF ScreenToObjectTransposedMatrix(PointF offset, PointF screenPoint, float scale) => new((screenPoint.X / scale) - offset.X, (screenPoint.Y / scale) - offset.Y);

    /// <summary>
    /// Objects to screen.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF ObjectToScreen(PointF point, float scale) => new(point.X * scale, point.Y * scale);

    /// <summary>
    /// Objects to screen. https://stackoverflow.com/a/37269366
    /// </summary>
    /// <param name="offset">The offset.</param>
    /// <param name="point">The object point.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF ObjectToScreen(PointF offset, PointF point, float scale) => new(offset.X + (point.X * scale), offset.Y + (point.Y * scale));

    /// <summary>
    /// Objects to screen transposed matrix. https://stackoverflow.com/a/37269366
    /// </summary>
    /// <param name="offset">The offset.</param>
    /// <param name="objectPoint">The object point.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF ObjectToScreenTransposedMatrix(PointF offset, PointF objectPoint, float scale) => new((offset.X + objectPoint.X) * scale, (offset.Y + objectPoint.Y) * scale);

    /// <summary>
    /// Zooms at. https://stackoverflow.com/a/37269366
    /// </summary>
    /// <param name="offset">The offset.</param>
    /// <param name="cursor">The cursor.</param>
    /// <param name="previousScale">The previous scale.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF ZoomAt(PointF offset, PointF cursor, float previousScale, float scale)
    {
        var point = ScreenToObject(offset, cursor, previousScale);
        point = ObjectToScreen(offset, point, scale);
        return new PointF(offset.X + ((cursor.X - point.X) / scale), offset.Y + ((cursor.Y - point.Y) / scale));
    }

    /// <summary>
    /// Zooms at for a transposed matrix. https://stackoverflow.com/a/37269366
    /// </summary>
    /// <param name="offset">The offset.</param>
    /// <param name="cursor">The cursor.</param>
    /// <param name="previousScale">The previous scale.</param>
    /// <param name="scale">The scale.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF ZoomAtTransposedMatrix(PointF offset, PointF cursor, float previousScale, float scale)
    {
        var point = ScreenToObjectTransposedMatrix(offset, cursor, previousScale);
        point = ObjectToScreenTransposedMatrix(offset, point, scale);
        return new PointF(offset.X + ((cursor.X - point.X) / scale), offset.Y + ((cursor.Y - point.Y) / scale));
    }

    #region Subtract Point
    /// <summary>
    /// Subtracts the specified subtrahend.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subtrahend">The subtrahend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF Subtract(this PointF minuend, PointF subtrahend) => new(minuend.X - subtrahend.X, minuend.Y - subtrahend.Y);

    /// <summary>
    /// Subtracts the specified subtrahend.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subtrahend">The subtrahend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF Subtract(this PointF minuend, Point subtrahend) => new(minuend.X - subtrahend.X, minuend.Y - subtrahend.Y);

    /// <summary>
    /// Subtracts the specified subtrahend.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subtrahend">The subtrahend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF Subtract(this Point minuend, PointF subtrahend) => new(minuend.X - subtrahend.X, minuend.Y - subtrahend.Y);

    /// <summary>
    /// Subtracts the specified subtrahend.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subtrahend">The subtrahend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Point Subtract(this Point minuend, Point subtrahend) => new(minuend.X - subtrahend.X, minuend.Y - subtrahend.Y);
    #endregion

    #region Add Point
    /// <summary>
    /// Adds the specified subtrahend.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subtrahend">The subtrahend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF Add(this PointF minuend, PointF subtrahend) => new(minuend.X + subtrahend.X, minuend.Y + subtrahend.Y);

    /// <summary>
    /// Adds the specified subtrahend.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subtrahend">The subtrahend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF Add(this PointF minuend, Point subtrahend) => new(minuend.X + subtrahend.X, minuend.Y + subtrahend.Y);

    /// <summary>
    /// Adds the specified subtrahend.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subtrahend">The subtrahend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF Add(this Point minuend, PointF subtrahend) => new(minuend.X + subtrahend.X, minuend.Y + subtrahend.Y);

    /// <summary>
    /// Adds the specified subtrahend.
    /// </summary>
    /// <param name="minuend">The minuend.</param>
    /// <param name="subtrahend">The subtrahend.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Point Add(this Point minuend, Point subtrahend) => new(minuend.X + subtrahend.X, minuend.Y + subtrahend.Y);
    #endregion

    #region Scale Point
    /// <summary>
    /// Scales the specified multiplier.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="scaler">The scaler.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF Scale(this PointF multiplicand, float scaler) => new(multiplicand.X * scaler, multiplicand.Y * scaler);

    /// <summary>
    /// Scales the specified multiplier.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="scaler">The scaler.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF Scale(this PointF multiplicand, SizeF scaler) => new(multiplicand.X * scaler.Width, multiplicand.Y * scaler.Height);

    /// <summary>
    /// Scales the specified scaler.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="scaler">The scaler.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF Scale(this Point multiplicand, float scaler) => new(multiplicand.X * scaler, multiplicand.Y * scaler);

    /// <summary>
    /// Scales the specified scaler.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="scaler">The scaler.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF Scale(this Point multiplicand, SizeF scaler) => new(multiplicand.X * scaler.Width, multiplicand.Y * scaler.Height);

    /// <summary>
    /// Scales the specified scaler.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="scaler">The scaler.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Point Scale(this Point multiplicand, int scaler) => new(multiplicand.X * scaler, multiplicand.Y * scaler);

    /// <summary>
    /// Scales the specified scaler.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="scaler">The scaler.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static Point Scale(this Point multiplicand, Size scaler) => new(multiplicand.X * scaler.Width, multiplicand.Y * scaler.Height);
    #endregion Scale Point

    #region Point To String
    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="format">The format.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string ToString(this PointF point, string format, IFormatProvider provider) => $"{{X={point.X.ToString(format, provider)}, Y={point.Y.ToString(format, provider)}}}";

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="format">The format.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string ToString(this Point point, string format, IFormatProvider provider) => $"{{X={point.X.ToString(format, provider)}, Y={point.Y.ToString(format, provider)}}}";
    #endregion Point To String
    #endregion Point Manipulation Methods
}
