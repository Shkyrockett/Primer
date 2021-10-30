// <copyright file="Extensions.cs" company="Shkyrockett" >
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
using System.Numerics;
using System.Runtime.CompilerServices;

namespace MathematicsNotationLibrary;

/// <summary>
/// 
/// </summary>
public static partial class Extensions
{
    #region Primitive Deconstruction
    /// <summary>
    /// Deconstructs the specified size.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Deconstruct(this Size size, out int width, out int height) => (width, height) = (size.Width, size.Height);

    /// <summary>
    /// Deconstructs the specified size.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Deconstruct(this SizeF size, out float width, out float height) => (width, height) = (size.Width, size.Height);

    /// <summary>
    /// Deconstructs the specified point.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Deconstruct(this Point point, out int x, out int y) => (x, y) = (point.X, point.Y);

    /// <summary>
    /// Deconstructs the specified point.
    /// </summary>
    /// <param name="point">The point.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Deconstruct(this PointF point, out float x, out float y) => (x, y) = (point.X, point.Y);

    /// <summary>
    /// Deconstructs the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Deconstruct(this Vector2 vector, out float x, out float y) => (x, y) = (vector.X, vector.Y);

    /// <summary>
    /// Deconstructs the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Deconstruct(this Vector3 vector, out float x, out float y, out float z) => (x, y, z) = (vector.X, vector.Y, vector.Z);

    /// <summary>
    /// Deconstructs the specified vector.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="z">The z.</param>
    /// <param name="w">The w.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Deconstruct(this Vector4 vector, out float w, out float x, out float y, out float z) => (w, x, y, z) = (vector.W, vector.X, vector.Y, vector.Z);

    /// <summary>
    /// Deconstructs the specified vector.
    /// </summary>
    /// <param name="rectangle">The rectangle.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Deconstruct(this Rectangle rectangle, out int x, out int y, out int width, out int height) => (x, y, width, height) = (rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

    /// <summary>
    /// Deconstructs the specified vector.
    /// </summary>
    /// <param name="rectangle">The rectangle.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void Deconstruct(this RectangleF rectangle, out float x, out float y, out float width, out float height) => (x, y, width, height) = (rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
    #endregion

    #region Primitive Subtract
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
    #endregion

    #region Primitive Add
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
    #endregion

    #region Primitive Scale
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
    public static PointF Scale(this Point multiplicand, double scaler) => new((float)(multiplicand.X * scaler), (float)(multiplicand.Y * scaler));

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
    public static PointF Scale(this PointF multiplicand, double scaler) => new((float)(multiplicand.X * scaler), (float)(multiplicand.Y * scaler));

    /// <summary>
    /// Scales the specified multiplier.
    /// </summary>
    /// <param name="multiplicand">The multiplicand.</param>
    /// <param name="scaler">The scaler.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static PointF Scale(this PointF multiplicand, SizeF scaler) => new(multiplicand.X * scaler.Width, multiplicand.Y * scaler.Height);
    #endregion Scale Point

    #region Primitive To String
    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="format">The format.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string ToString(this Size size, string format, IFormatProvider provider) => $"{{{nameof(Size.Width)}={size.Width.ToString(format, provider)},  {nameof(Size.Height)}={size.Height.ToString(format, provider)}}}";

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <param name="size">The size.</param>
    /// <param name="format">The format.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string ToString(this SizeF size, string format, IFormatProvider provider) => $"{{{nameof(SizeF.Width)}={size.Width.ToString(format, provider)}, {nameof(SizeF.Height)}={size.Height.ToString(format, provider)}}}";

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
    public static string ToString(this Point point, string format, IFormatProvider provider) => $"{{{nameof(Point.X)}={point.X.ToString(format, provider)}, {nameof(Point.Y)}={point.Y.ToString(format, provider)}}}";

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
    public static string ToString(this PointF point, string format, IFormatProvider provider) => $"{{{nameof(PointF.X)}={point.X.ToString(format, provider)}, {nameof(PointF.Y)}={point.Y.ToString(format, provider)}}}";

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="format">The format.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string ToString(this Vector2 vector, string format, IFormatProvider provider) => $"{{{nameof(Vector2.X)}={vector.X.ToString(format, provider)}, {nameof(Vector2.Y)}={vector.Y.ToString(format, provider)}}}";

    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <param name="vector">The vector.</param>
    /// <param name="format">The format.</param>
    /// <param name="provider">The provider.</param>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static string ToString(this Vector3 vector, string format, IFormatProvider provider) => $"{{{nameof(Vector3.X)}={vector.X.ToString(format, provider)}, {nameof(Vector3.Y)}={vector.Y.ToString(format, provider)}, {nameof(Vector3.Z)}={vector.Z.ToString(format, provider)}}}";
    #endregion Point To String

    #region Extensions To Add Missing Graphics Methods
    /// <summary>
    /// Fills the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="brush">The brush.</param>
    /// <param name="rectangle">The rectangle.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FillRectangle(this Graphics graphics, Brush brush, RectangleF rectangle) => graphics.FillRectangle(brush, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

    /// <summary>
    /// Fills the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="brush">The brush.</param>
    /// <param name="point">The point.</param>
    /// <param name="size">The size.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FillRectangle(this Graphics graphics, Brush brush, Point point, Size size) => graphics.FillRectangle(brush, point.X, point.Y, size.Width, size.Height);

    /// <summary>
    /// Fills the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="brush">The brush.</param>
    /// <param name="point">The point.</param>
    /// <param name="size">The size.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FillRectangle(this Graphics graphics, Brush brush, PointF point, SizeF size) => graphics.FillRectangle(brush, point.X, point.Y, size.Width, size.Height);

    /// <summary>
    /// Fills the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="brush">The brush.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="size">The size.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FillRectangle(this Graphics graphics, Brush brush, int x, int y, Size size) => graphics.FillRectangle(brush, x, y, size.Width, size.Height);

    /// <summary>
    /// Fills the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="brush">The brush.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="size">The size.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FillRectangle(this Graphics graphics, Brush brush, float x, float y, SizeF size) => graphics.FillRectangle(brush, x, y, size.Width, size.Height);

    /// <summary>
    /// Fills the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="brush">The brush.</param>
    /// <param name="point">The point.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FillRectangle(this Graphics graphics, Brush brush, Point point, int width, int height) => graphics.FillRectangle(brush, point.X, point.Y, width, height);

    /// <summary>
    /// Fills the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="brush">The brush.</param>
    /// <param name="point">The point.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void FillRectangle(this Graphics graphics, Brush brush, PointF point, float width, float height) => graphics.FillRectangle(brush, point.X, point.Y, width, height);

    /// <summary>
    /// Draws the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="pen">The pen.</param>
    /// <param name="rectangle">The rectangle.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void DrawRectangle(this Graphics graphics, Pen pen, RectangleF rectangle) => graphics.DrawRectangle(pen, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);

    /// <summary>
    /// Draws the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="pen">The pen.</param>
    /// <param name="point">The point.</param>
    /// <param name="size">The size.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void DrawRectangle(this Graphics graphics, Pen pen, Point point, Size size) => graphics.DrawRectangle(pen, point.X, point.Y, size.Width, size.Height);

    /// <summary>
    /// Draws the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="pen">The pen.</param>
    /// <param name="point">The point.</param>
    /// <param name="size">The size.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void DrawRectangle(this Graphics graphics, Pen pen, PointF point, SizeF size) => graphics.DrawRectangle(pen, point.X, point.Y, size.Width, size.Height);

    /// <summary>
    /// Draws the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="pen">The pen.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="size">The size.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void DrawRectangle(this Graphics graphics, Pen pen, int x, int y, Size size) => graphics.DrawRectangle(pen, x, y, size.Width, size.Height);

    /// <summary>
    /// Draws the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="pen">The pen.</param>
    /// <param name="x">The x.</param>
    /// <param name="y">The y.</param>
    /// <param name="size">The size.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void DrawRectangle(this Graphics graphics, Pen pen, float x, float y, SizeF size) => graphics.DrawRectangle(pen, x, y, size.Width, size.Height);

    /// <summary>
    /// Draws the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="pen">The pen.</param>
    /// <param name="point">The point.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void DrawRectangle(this Graphics graphics, Pen pen, Point point, int width, int height) => graphics.DrawRectangle(pen, point.X, point.Y, width, height);

    /// <summary>
    /// Draws the rectangle.
    /// </summary>
    /// <param name="graphics">The graphics.</param>
    /// <param name="pen">The pen.</param>
    /// <param name="point">The point.</param>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static void DrawRectangle(this Graphics graphics, Pen pen, PointF point, float width, float height) => graphics.DrawRectangle(pen, point.X, point.Y, width, height);
    #endregion

    /// <summary>
    ///  Projects each element of a sequence into a new form. (map in every other language)
    /// </summary>        
    /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
    /// <param name="selector">A transform function to apply (map) to each element.</param>
    /// <returns>A sequence whose elements are the result of invoking the transform function on each element (mapping) of source.</returns>
    /// <acknowledgment>
    /// https://github.com/jackmott/LinqFaster/blob/master/LinqFaster/Select.cs#L167
    /// </acknowledgment>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static TResult[] Select<T, TResult>(this Span<T> source, Func<T, TResult> selector)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (selector == null)
        {
            throw new ArgumentNullException(nameof(selector));
        }

        var result = new TResult[source.Length];
        for (int i = 0; i < source.Length; i++)
        {
            result[i] = selector(source[i]);
        }

        return result;
    }
}
