// <copyright file="Operations.Algebratics.cs" company="Shkyrockett" >
//     Copyright © 2020 Shkyrockett. All rights reserved.
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
using static System.Math;

namespace MathematicsNotationLibrary
{
    /// <summary>
    /// Algebraic Operations class.
    /// </summary>
    public static partial class Operations
    {
        /// <summary>
        /// The inverse sqrt.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// The <see cref="double" />.
        /// </returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double InverseSqrt(double number) => 1d / Sqrt(number);

        /// <summary>
        /// Returns the specified root a specified number.
        /// </summary>
        /// <param name="x">A double-precision floating-point number to find the specified root of.</param>
        /// <param name="y">A double-precision floating-point number that specifies a root.</param>
        /// <returns>
        /// The y root of the number x.
        /// </returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Root(float x, float y) => (x < 0f && MathF.Abs((y % 2f) - 1f) < float.Epsilon) ? -MathF.Pow(-x, 1f / y) : MathF.Pow(x, 1f / y);

        /// <summary>
        /// Returns the specified root a specified number.
        /// </summary>
        /// <param name="x">A double-precision floating-point number to find the specified root of.</param>
        /// <param name="y">A double-precision floating-point number that specifies a root.</param>
        /// <returns>
        /// The y root of the number x.
        /// </returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double Root(double x, double y) => (x < 0d && Math.Abs((y % 2d) - 1d) < double.Epsilon) ? -Pow(-x, 1d / y) : Pow(x, 1d / y);

        /// <summary>
        /// Cube root equivalent of the sqrt function. (note that there are actually
        /// three roots: one real, two complex, and we don't care about the latter):
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <acknowledgment>
        /// http://stackoverflow.com/questions/26823024/cubic-bezier-reverse-getpoint-equation-float-for-vector-vector-for-float?answertab=active#tab-top
        /// </acknowledgment>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CubeRoot(double value) => value < 0d ? -Cbrt(-value) : Cbrt(value);

        /// <summary>
        /// The inverse cube root.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        /// The <see cref="double" />.
        /// </returns>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double InverseCubeRoot(double number) => 1d / CubeRoot(number);

        /// <summary>
        /// Newton's (Newton-Raphson) method for finding Real roots on univariate function. <br/>
        /// When using bounds, algorithm falls back to secant if newton goes out of range.
        /// Bisection is fall-back for secant when determined secant is not efficient enough.
        /// </summary>
        /// <param name="x0">Initial root guess</param>
        /// <param name="f">Function which root we are trying to find</param>
        /// <param name="df">Derivative of function f</param>
        /// <param name="maxIterations">Maximum number of algorithm iterations</param>
        /// <param name="min">Left bound value</param>
        /// <param name="max">Right bound value</param>
        /// <returns>
        /// root
        /// </returns>
        /// <remarks>
        /// <para>https://github.com/thelonious/kld-polynomial
        /// http://en.wikipedia.org/wiki/Newton%27s_method
        /// http://en.wikipedia.org/wiki/Secant_method
        /// http://en.wikipedia.org/wiki/Bisection_method</para>
        /// </remarks>
        //[DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double NewtonSecantBisection(double x0, Func<double, double> f, Func<double, double> df, int maxIterations, double? min = null, double? max = null)
        {
            if (f is null)
            {
                throw new ArgumentNullException(nameof(f));
            }

            var prev_dfx = 0d;
            var prev_x_ef_correction = 0d;
            var y_atmin = 0d;
            var y_atmax = 0d;
            var x = x0;
            const int ACCURACY = 14;
            var min_correction_factor = Pow(10, -ACCURACY);
            var isBounded = min != null && max != null;
            if (isBounded)
            {
                if (min > max)
                {
                    throw new Exception("newton root finding: min must be greater than max");
                }

                y_atmin = f(min!.Value);
                y_atmax = f(max!.Value);
                if (Sign(y_atmin) == Sign(y_atmax))
                {
                    throw new Exception("newton root finding: y values of bounds must be of opposite sign");
                }
            }

            double x_correction;
            bool isEnoughCorrection()
            {
                // stop if correction is too small
                // or if correction is in simple loop
                return (Math.Abs(x_correction) <= min_correction_factor * Math.Abs(x))
                    || (prev_x_ef_correction == x - x_correction - x);
            }

            //var stepMethod;
            //var details = [];
            for (var i = 0; i < maxIterations; i++)
            {
                var dfx = df(x);
                if (dfx == 0)
                {
                    if (prev_dfx == 0)
                    {
                        // error
                        throw new Exception("newton root finding: df(x) is zero");
                        //return null;
                    }
                    else
                    {
                        // use previous derivation value
                        dfx = prev_dfx;
                    }
                    // or move x a little?
                    // dfx = df(x != 0 ? x + x * 1e-15 : 1e-15);
                }
                //stepMethod = 'newton';
                prev_dfx = dfx;
                var y = f(x);
                x_correction = y / dfx;
                var x_new = x - x_correction;
                if (isEnoughCorrection())
                {
                    break;
                }

                if (isBounded)
                {
                    if (Sign(y) == Sign(y_atmax))
                    {
                        max = x;
                        y_atmax = y;
                    }
                    else if (Sign(y) == Sign(y_atmin))
                    {
                        min = x;
                        y_atmin = y;
                    }
                    else
                    {
                        x = x_new;
                        //console.log("newton root finding: sign(y) not matched.");
                        break;
                    }

                    if ((x_new < min) || (x_new > max))
                    {
                        if (Sign(y_atmin) == Sign(y_atmax))
                        {
                            break;
                        }

                        const int RATIO_LIMIT = 50;
                        const double AIMED_BISECT_OFFSET = 0.25; // [0, 0.5)
                        var dy = y_atmax - y_atmin;
                        var dx = max - min;

                        x_correction = dy == 0 ? x - (min.Value + (dx.Value * 0.5)) : Math.Abs(dy / Min(y_atmin, y_atmax)) > RATIO_LIMIT ? x - (min.Value + (dx.Value * (0.5 + (Math.Abs(y_atmin) < Math.Abs(y_atmax) ? -AIMED_BISECT_OFFSET : AIMED_BISECT_OFFSET)))) : x - (min.Value - (y_atmin / dy * dx.Value));
                        x_new = x - x_correction;

                        if (isEnoughCorrection())
                        {
                            break;
                        }
                    }
                }
                //details.push([stepMethod, i, x, x_new, x_correction, min, max, y]);
                prev_x_ef_correction = x - x_new;
                x = x_new;
            }
            //details.push([stepMethod, i, x, x_new, x_correction, min, max, y]);
            //console.log(details.join('\r\n'));
            //if (i == max_iterations)
            //    console.log('newt: steps=' + ((i==max_iterations)? i:(i + 1)));
            return x;
        }
    }
}
