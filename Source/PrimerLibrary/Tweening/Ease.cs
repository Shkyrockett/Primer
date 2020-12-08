// <copyright file="Ease.cs" >
//     Copyright © 2013 - 2018 Jacob Albano. All rights reserved.
// </copyright>
// <author id="jacobalbano">Jacob Albano</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks> Based on: https://github.com/jacobalbano/glide </remarks>

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using static MathematicsNotationLibrary.Mathematics;
using static System.MathF;

namespace PrimerLibrary
{
    /// <summary>
    /// Static class with useful easer functions that can be used by Tweens.
    /// </summary>
    public static class Ease
    {
        #region Constants
        /// <summary>
        /// The bounce key1 (const). Value: 1d / 2.75d.
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        private const float bounceKey1 = 1f / 2.75f;

        /// <summary>
        /// The bounce key2 (const). Value: 2d / 2.75d.
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        private const float bounceKey2 = 2f / 2.75f;

        /// <summary>
        /// The bounce key3 (const). Value: 1.5d / 2.75d.
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        private const float bounceKey3 = 1.5f / 2.75f;

        /// <summary>
        /// The bounce key4 (const). Value: 2.5d / 2.75d.
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        private const float bounceKey4 = 2.5f / 2.75f;

        /// <summary>
        /// The bounce key5 (const). Value: 2.25d / 2.75d.
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        private const float bounceKey5 = 2.25f / 2.75f;

        /// <summary>
        /// The bounce key6 (const). Value: 2.625d / 2.75d.
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        private const float bounceKey6 = 2.625f / 2.75f;
        #endregion Constants

        #region To and Fro Easing Methods
        /// <summary>
        /// Ease a value to its target and then back with another easing function. Use this to wrap two other easing functions.
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<float, float> ToAndFro(Func<float, float> easer1, Func<float, float> easer2, float b, float c, float d) => t => (t < 0.5f) ? ToAndFro(easer1(t), b, c, d) : ToAndFro(easer2(t), b, c, d);

        /// <summary>
        /// Ease a value to its target and then back with another easing function. Use this to wrap two other easing functions.
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<float, float> ToAndFro(Func<float, float> easer1, Func<float, float> easer2) => t => (t < 0.5f) ? ToAndFro(easer1(t)) : ToAndFro(easer2(t));

        /// <summary>
        /// Ease a value to its target and then back. Use this to wrap another easing function.
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<float, float> ToAndFro(Func<float, float> easer, float b, float c, float d) => t => ToAndFro(easer(t), b, c, d);

        /// <summary>
        /// Ease a value to its target and then back. Use this to wrap another easing function.
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Func<float, float> ToAndFro(Func<float, float> easer) => t => ToAndFro(easer(t));

        /// <summary>
        /// Ease a value to its target and then back.
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToAndFro(float t, float b, float c, float d) => (c * (t < 0.5f ? t * 2f : 1f + ((t - 0.5f) / 0.5f * -1f)) / d) + b;

        /// <summary>
        /// Ease a value to its target and then back.
        /// </summary>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ToAndFro(float t) => t < 0.5f ? t * 2f : 1f + ((t - 0.5f) / 0.5f * -1f);
        #endregion To and Fro Easing Methods

        #region Parabolic
        /// <summary>
        /// Parabolic to and fro method.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Parabolic(float t, float b, float c, float d) => (c * ((-4f * t * t) + (4f * t)) / d) + b;

        /// <summary>
        /// Parabolic to and fro method.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <remarks>
        /// <para>This is the parabola $y=-4t^2+4t+0$ where the Vertex form is: $y=-4(t-1/2)^2+1$.
        /// The x-intercepts are at 0 and 1 respectively, with the peak of the vertex at (1/2, 1) which makes it ideal for scaling.</para>
        /// </remarks>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Parabolic(float t) => (-4f * t * t) + (4f * t);
        #endregion Parabolic

        #region Linear Easing Methods
        /// <summary>
        /// Easing equation function for a simple linear tweening, with no easing.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Linear(float t, float b, float c, float d) => (c * t / d) + b;

        /// <summary>
        /// Easing equation function for a simple linear tweening, with no easing.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Linear(float t) => t;
        #endregion Linear Easing Methods

        #region Quadratic Easing Methods
        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuadIn(float t, float b, float c, float d) => (c * (t /= d) * t) + b;

        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuadIn(float t) => t * t;

        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuadOut(float t, float b, float c, float d) => (-c * (t /= d) * (t - 2f)) + b;

        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuadOut(float t) => -t * (t - 2f);

        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuadInOut(float t, float b, float c, float d) => ((t /= d * 0.5f) < 1) ? (c * 0.5f * t * t) + b : (-c * 0.5f * (((--t) * (t - 2f)) - 1f)) + b;

        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuadInOut(float t) => t <= 0.5f ? t * t * 2f : 1f - ((--t) * t * 2f);

        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuadOutIn(float t, float b, float c, float d) => (t < d * 0.5f) ? QuadOut(t * 2f, b, c * 0.5f, d) : QuadIn((t * 2f) - d, b + (c * 0.5f), c * 0.5f, d);

        /// <summary>
        /// Easing equation function for a quadratic (t^2) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuadOutIn(float t) => (t < 0.5f) ? QuadOut(t * 2f) : QuadIn((t * 2f) - 1f);
        #endregion Quadratic Easing Methods

        #region Cubic Easing Methods
        /// <summary>
        /// Easing equation function for a cubic (t^3) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CubicIn(float t, float b, float c, float d) => (c * (t /= d) * t * t) + b;

        /// <summary>
        /// Easing equation function for a cubic (t^3) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CubicIn(float t) => t * t * t;

        /// <summary>
        /// Easing equation function for a cubic (t^3) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CubicOut(float t, float b, float c, float d) => (c * (((t = (t / d) - 1f) * t * t) + 1f)) + b;

        /// <summary>
        /// Cubic out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CubicOut(float t) => 1f + ((--t) * t * t);

        /// <summary>
        /// Easing equation function for a cubic (t^3) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CubicInOut(float t, float b, float c, float d) => ((t /= d * 0.5f) < 1f) ? (c * 0.5f * t * t * t) + b : (c * 0.5f * (((t -= 2f) * t * t) + 2f)) + b;

        /// <summary>
        /// Cubic in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CubicInOut(float t) => t <= 0.5f ? t * t * t * 4f : 1f + ((--t) * t * t * 4f);

        /// <summary>
        /// Easing equation function for a cubic (t^3) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CubicOutIn(float t, float b, float c, float d) => (t < d * 0.5f) ? CubicOut(t * 2f, b, c * 0.5f, d) : CubicIn((t * 2f) - d, b + (c * 0.5f), c * 0.5f, d);

        /// <summary>
        /// Easing equation function for a cubic (t^3) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CubicOutIn(float t) => (t < 0.5f) ? CubicOut(t * 2f) : CubicIn((t * 2f) - 1f);
        #endregion Cubic Easing Methods

        #region Quartic Easing Methods
        /// <summary>
        /// Easing equation function for a quartic (t^4) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuartIn(float t, float b, float c, float d) => (c * (t /= d) * t * t * t) + b;

        /// <summary>
        /// Quart in.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuartIn(float t) => t * t * t * t;

        /// <summary>
        /// Easing equation function for a quartic (t^4) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuartOut(float t, float b, float c, float d) => (-c * (((t = (t / d) - 1f) * t * t * t) - 1f)) + b;

        /// <summary>
        /// Quart out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuartOut(float t) => 1f - ((--t) * t * t * t);

        /// <summary>
        /// Easing equation function for a quartic (t^4) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuartInOut(float t, float b, float c, float d) => ((t /= d * 0.5f) < 1f) ? (c * 0.5f * t * t * t * t) + b : (-c * 0.5f * (((t -= 2f) * t * t * t) - 2f)) + b;

        /// <summary>
        /// Quart in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuartInOut(float t) => t <= 0.5f ? t * t * t * t * 8f : ((1f - ((t = (t * 2f) - 2f) * t * t * t)) * 0.5f) + 0.5f;

        /// <summary>
        /// Easing equation function for a quartic (t^4) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuartOutIn(float t, float b, float c, float d) => (t < d / 2d) ? QuartOut(t * 2f, b, c * 0.5f, d) : QuartIn((t * 2f) - d, b + (c * 0.5f), c * 0.5f, d);

        /// <summary>
        /// Easing equation function for a quartic (t^4) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuartOutIn(float t) => (t < 0.5f) ? QuartOut(t * 2f) : QuartIn((t * 2f) - 1f);
        #endregion Quartic Easing Methods

        #region Quintic Easing Methods
        /// <summary>
        /// Easing equation function for a quintic (t^5) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuintIn(float t, float b, float c, float d) => (c * (t /= d) * t * t * t * t) + b;

        /// <summary>
        /// Quint in.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuintIn(float t) => t * t * t * t * t;

        /// <summary>
        /// Easing equation function for a quintic (t^5) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuintOut(float t, float b, float c, float d) => (c * (((t = (t / d) - 1f) * t * t * t * t) + 1f)) + b;

        /// <summary>
        /// Quint out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuintOut(float t) => ((t -= 1f) * t * t * t * t) + 1f;

        /// <summary>
        /// Easing equation function for a quintic (t^5) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuintInOut(float t, float b, float c, float d) => ((t /= d * 0.5f) < 1f) ? (c * 0.5f * t * t * t * t * t) + b : (c * 0.5f * (((t -= 2f) * t * t * t * t) + 2f)) + b;

        /// <summary>
        /// Quint in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuintInOut(float t) => ((t *= 2f) < 1f) ? t * t * t * t * t * 0.5f : (((t -= 2f) * t * t * t * t) + 2f) * 0.5f;

        /// <summary>
        /// Easing equation function for a quintic (t^5) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuintOutIn(float t, float b, float c, float d) => (t < d * 0.5f) ? QuintOut(t * 2f, b, c * 0.5f, d) : QuintIn((t * 2f) - d, b + (c * 0.5f), c * 0.5f, d);

        /// <summary>
        /// Easing equation function for a quintic (t^5) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float QuintOutIn(float t) => (t < 0.5f) ? QuintOut(t * 2f) : QuintIn((t * 2f) - 1f);
        #endregion Quintic Easing Methods

        #region Exponential Easing Methods
        /// <summary>
        /// Easing equation function for an exponential (2^t) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ExpoIn(float t, float b, float c, float d) => (t == 0f) ? b : (c * Pow(2f, 10f * ((t / d) - 1f))) + b;

        /// <summary>
        /// Exponential in.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ExpoIn(float t) => Pow(2f, 10f * (t - 1f));

        /// <summary>
        /// Easing equation function for an exponential (2^t) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ExpoOut(float t, float b, float c, float d) => (t == d) ? b + c : (c * (-Pow(2f, -10f * t / d) + 1f)) + b;

        /// <summary>
        /// Exponential out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ExpoOut(float t) => (Abs(t - 1f) < float.Epsilon) ? 1f : -Pow(2f, -10f * t) + 1f;

        /// <summary>
        /// Easing equation function for an exponential (2^t) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ExpoInOut(float t, float b, float c, float d) => (t == 0f) ? b : (t == d) ? b + c : ((t /= d * 0.5f) < 1f) ? (c * 0.5f * Pow(2f, 10f * (t - 1f))) + b : (c * 0.5f * (-Pow(2f, -10f * --t) + 2f)) + b;

        /// <summary>
        /// Exponential in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ExpoInOut(float t) => (Abs(t - 1f) < float.Epsilon) ? 1f : (t < 0.5f ? Pow(2f, 10f * ((t * 2f) - 1f)) * 0.5f : (-Pow(2f, -10f * ((t * 2f) - 1f)) + 2f) * 0.5f);

        /// <summary>
        /// Easing equation function for an exponential (2^t) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ExpoOutIn(float t, float b, float c, float d) => (t < d * 0.5f) ? ExpoOut(t * 2f, b, c * 0.5f, d) : ExpoIn((t * 2f) - d, b + (c * 0.5f), c * 0.5f, d);

        /// <summary>
        /// Easing equation function for an exponential (2^t) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ExpoOutIn(float t) => (t < 0.5f) ? ExpoOut(t * 2f) : ExpoIn((t * 2f) - 1f);
        #endregion Exponential Easing Methods

        #region Sine Easing Methods
        /// <summary>
        /// Easing equation function for a sinusoidal (sin(t)) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SineIn(float t, float b, float c, float d) => (-c * Cos(t / d * Hau)) + c + b;

        /// <summary>
        /// Sine in.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SineIn(float t) => (Abs(t - 1f) < float.Epsilon) ? 1f : (-Cos(Hau * t) + 1f);

        /// <summary>
        /// Easing equation function for a sinusoidal (sin(t)) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SineOut(float t, float b, float c, float d) => (c * Sin(t / d * Hau)) + b;

        /// <summary>
        /// Sine out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SineOut(float t) => Sin(Hau * t);

        /// <summary>
        /// Easing equation function for a sinusoidal (sin(t)) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SineInOut(float t, float b, float c, float d) => ((t /= d * 0.5f) < 1f) ? (c * 0.5f * Sin(Hau * t)) + b : (-c * 0.5f * (Cos(Hau * --t) - 2f)) + b;

        /// <summary>
        /// Sine in and out
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SineInOut(float t) => (-Cos(PI * t) * 0.5f) + 0.5f;

        /// <summary>
        /// Easing equation function for a sinusoidal (sin(t)) easing in/out:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SineOutIn(float t, float b, float c, float d) => (t < d * 0.5d) ? SineOut(t * 2, b, c * 0.5f, d) : SineIn((t * 2) - d, b + (c * 0.5f), c * 0.5f, d);

        /// <summary>
        /// Easing equation function for a sinusoidal (sin(t)) easing in/out:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float SineOutIn(float t) => (t < 0.5f) ? SineOut(t * 2f) : SineIn((t * 2f) - 1f);
        #endregion Sine Easing Methods

        #region Circular Easing Methods
        /// <summary>
        /// Easing equation function for a circular (sqrt(1-t^2)) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CircIn(float t, float b, float c, float d) => (-c * (Sqrt(1f - ((t /= d) * t)) - 1f)) + b;

        /// <summary>
        /// Circle in.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CircIn(float t) => -(Sqrt(1f - (t * t)) - 1f);

        /// <summary>
        /// Easing equation function for a circular (sqrt(1-t^2)) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CircOut(float t, float b, float c, float d) => (c * Sqrt(1f - ((t = (t / d) - 1f) * t))) + b;

        /// <summary>
        /// Circle out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CircOut(float t) => Sqrt(1f - ((t - 1f) * (t - 1f)));

        /// <summary>
        /// Easing equation function for a circular (sqrt(1-t^2)) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CircInOut(float t, float b, float c, float d) => ((t /= d * 0.5f) < 1f) ? (-c * 0.5f * (Sqrt(1f - (t * t)) - 1f)) + b : (c * 0.5f * (Sqrt(1f - ((t -= 2f) * t)) + 1f)) + b;

        /// <summary>
        /// Circle in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CircInOut(float t) => t <= 0.5f ? (Sqrt(1f - (t * t * 4f)) - 1f) * -0.5f : (Sqrt(1f - (((t * 2f) - 2f) * ((t * 2f) - 2f))) + 1f) * 0.5f;

        /// <summary>
        /// Easing equation function for a circular (sqrt(1-t^2)) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CircOutIn(float t, float b, float c, float d) => (t < d * 0.5f) ? CircOut(t * 2f, b, c * 0.5f, d) : CircIn((t * 2f) - d, b + (c * 0.5f), c * 0.5f, d);

        /// <summary>
        /// Easing equation function for a circular (sqrt(1-t^2)) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float CircOutIn(float t) => (t < 0.5f) ? CircOut(t * 2f) : CircIn((t * 2f) - 1f);
        #endregion Circular Easing Methods

        #region Elastic Easing Methods
        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ElasticIn(float t, float b, float c, float d)
        {
            if ((t /= d) == 1f)
            {
                return b + c;
            }

            var p = d * 0.3f;
            var s = p / 4f;

            return -(c * Pow(2f, 10f * (t -= 1f)) * Sin(((t * d) - s) * (2f * PI) / p)) + b;
        }

        /// <summary>
        /// Elastic in.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ElasticIn(float t) => Sin(13f * Hau * t) * Pow(2f, 10f * (t - 1f));

        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ElasticOut(float t, float b, float c, float d)
        {
            if ((t /= d) == 1f)
            {
                return b + c;
            }

            var p = d * 0.3f;
            var s = p / 4f;

            return (c * Pow(2f, -10f * t) * Sin(((t * d) - s) * (2f * PI) / p)) + c + b;
        }

        /// <summary>
        /// Elastic out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ElasticOut(float t) => (Abs(t - 1f) < float.Epsilon) ? 1f : ((Sin(-13f * Hau * (t + 1f)) * Pow(2f, -10f * t)) + 1f);

        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ElasticInOut(float t, float b, float c, float d)
        {
            if ((t /= d * 0.5f) == 2f)
            {
                return b + c;
            }

            var p = d * (0.3f * 1.5f);
            var s = p / 4f;

            if (t < 1f)
            {
                return (-0.5f * (c * Pow(2f, 10f * (t -= 1f)) * Sin(((t * d) - s) * (2f * PI) / p))) + b;
            }

            return (c * Pow(2f, -10f * (t -= 1f)) * Sin(((t * d) - s) * (2f * PI) / p) * 0.5f) + c + b;
        }

        /// <summary>
        /// Elastic in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ElasticInOut(float t) => (t < 0.5f) ? (0.5f * Sin(13f * Hau * (2f * t)) * Pow(2f, 10f * ((2f * t) - 1f))) : (0.5f * ((Sin(-13f * Hau * ((2f * t) - 1f + 1f)) * Pow(2f, -10f * ((2f * t) - 1f))) + 2f));

        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ElasticOutIn(float t, float b, float c, float d) => (t < d * 0.5f) ? ElasticOut(t * 2f, b, c * 0.5f, d) : ElasticIn((t * 2f) - d, b + (c * 0.5f), c * 0.5f, d);

        /// <summary>
        /// Easing equation function for an elastic (exponentially decaying sine wave) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ElasticOutIn(float t) => (t < 0.5f) ? ElasticOut(t * 2f) : ElasticIn((t * 2f) - 1f);
        #endregion Elastic Easing Methods

        #region Bounce Easing Methods
        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BounceIn(float t, float b, float c, float d) => c - BounceOut(d - t, 0f, c, d) + b;

        /// <summary>
        /// Bounce in.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BounceIn(float t)
        {
            t = 1f - t;
            if (t < bounceKey1)
            {
                return 1f - (7.5625f * t * t);
            }

            if (t < bounceKey2)
            {
                return 1f - ((7.5625f * (t - bounceKey3) * (t - bounceKey3)) + 0.75f);
            }

            if (t < bounceKey4)
            {
                return 1f - ((7.5625f * (t - bounceKey5) * (t - bounceKey5)) + 0.9375f);
            }

            return 1f - ((7.5625f * (t - bounceKey6) * (t - bounceKey6)) + 0.984375f);
        }

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BounceOut(float t, float b, float c, float d)
        {
            if ((t /= d) < (1f / 2.75f))
            {
                return (c * (7.5625f * t * t)) + b;
            }
            else if (t < (2f / 2.75f))
            {
                return (c * ((7.5625f * (t -= 1.5f / 2.75f) * t) + 0.75f)) + b;
            }
            else if (t < (2.5f / 2.75f))
            {
                return (c * ((7.5625f * (t -= 2.25f / 2.75f) * t) + 0.9375f)) + b;
            }
            else
            {
                return (c * ((7.5625f * (t -= 2.625f / 2.75f) * t) + 0.984375f)) + b;
            }
        }

        /// <summary>
        /// Bounce out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BounceOut(float t)
        {
            if (t < bounceKey1)
            {
                return 7.5625f * t * t;
            }
            else if (t < bounceKey2)
            {
                return (7.5625f * (t - bounceKey3) * (t - bounceKey3)) + 0.75f;
            }
            else if (t < bounceKey4)
            {
                return (7.5625f * (t - bounceKey5) * (t - bounceKey5)) + 0.9375f;
            }
            else
            {
                return (7.5625f * (t - bounceKey6) * (t - bounceKey6)) + 0.984375f;
            }
        }

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BounceEaseInOut(float t, float b, float c, float d) => t < d * 0.5f ? (BounceIn(t * 2f, 0f, c, d) * 0.5f) + b : (BounceOut((t * 2f) - d, 0f, c, d) * 0.5f) + (c * 0.5f) + b;

        /// <summary>
        /// Bounce in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BounceInOut(float t)
        {
            if (t < 0.5f)
            {
                t = 1f - (t * 2f);
                if (t < bounceKey1)
                {
                    return (1f - (7.5625f * t * t)) * 0.5f;
                }
                else if (t < bounceKey2)
                {
                    return (1f - ((7.5625f * (t - bounceKey3) * (t - bounceKey3)) + 0.75f)) * 0.5f;
                }
                else if (t < bounceKey4)
                {
                    return (1f - ((7.5625f * (t - bounceKey5) * (t - bounceKey5)) + 0.9375f)) * 0.5f;
                }
                else
                {
                    return (1f - ((7.5625f * (t - bounceKey6) * (t - bounceKey6)) + 0.984375f)) * 0.5f;
                }
            }

            t = (t * 2f) - 1f;
            if (t < bounceKey1)
            {
                return (7.5625f * t * t * 0.5f) + 0.5f;
            }
            else if (t < bounceKey2)
            {
                return (((7.5625f * (t - bounceKey3) * (t - bounceKey3)) + 0.75f) * 0.5f) + 0.5f;
            }
            else if (t < bounceKey4)
            {
                return (((7.5625f * (t - bounceKey5) * (t - bounceKey5)) + 0.9375f) * 0.5f) + 0.5f;
            }
            else
            {
                return (((7.5625f * (t - bounceKey6) * (t - bounceKey6)) + 0.984375f) * 0.5f) + 0.5f;
            }
        }

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BounceOutIn(float t, float b, float c, float d) => (t < d * 0.5f) ? BounceOut(t * 2f, b, c * 0.5f, d) : BounceIn((t * 2f) - d, b + (c * 0.5f), c * 0.5f, d);

        /// <summary>
        /// Easing equation function for a bounce (exponentially decaying parabolic bounce) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BounceOutIn(float t) => (t < 0.5f) ? BounceOut(t * 2f) : BounceIn((t * 2f) - 1f);
        #endregion Bounce Easing Methods

        #region Back Easing Methods
        /// <summary>
        /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing in:
        /// accelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BackIn(float t, float b, float c, float d) => (c * (t /= d) * t * (((1.70158f + 1) * t) - 1.70158f)) + b;

        /// <summary>
        /// Back in.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BackIn(float t) => t * t * ((2.70158f * t) - 1.70158f);

        /// <summary>
        /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing out:
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BackOut(float t, float b, float c, float d) => (c * (((t = (t / d) - 1f) * t * (((1.70158f + 1f) * t) + 1.70158f)) + 1f)) + b;

        /// <summary>
        /// Back out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BackOut(float t) => 1f - ((--t) * t * ((-2.70158f * t) - 1.70158f));

        /// <summary>
        /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing in/out:
        /// acceleration until halfway, then deceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BackInOut(float t, float b, float c, float d)
        {
            var s = 1.70158f;
            return ((t /= d * 0.5f) < 1f) ? (c * 0.5f * (t * t * ((((s *= 1.525f) + 1f) * t) - s))) + b : (c * 0.5f * (((t -= 2f) * t * ((((s *= 1.525f) + 1f) * t) + s)) + 2f)) + b;
        }

        /// <summary>
        /// Back in and out.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns>Eased timescale.</returns>
        /// <acknowledgment>
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BackInOut(float t)
        {
            t *= 2f;
            if (t < 1f)
            {
                return t * t * ((2.70158f * t) - 1.70158f) * 0.5f;
            }

            t--;
            return ((1f - ((--t) * t * ((-2.70158f * t) - 1.70158f))) * 0.5f) + 0.5f;
        }

        /// <summary>
        /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <param name="b">Starting value.</param>
        /// <param name="c">Final value.</param>
        /// <param name="d">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        /// <acknowledgment>
        /// From: https://github.com/darrendavid/wpf-animation
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BackOutIn(float t, float b, float c, float d) => (t < d * 0.5f) ? BackOut(t * 2f, b, c * 0.5f, d) : BackIn((t * 2f) - d, b + (c * 0.5f), c * 0.5f, d);

        /// <summary>
        /// Easing equation function for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) easing out/in:
        /// deceleration until halfway, then acceleration.
        /// </summary>
        /// <param name="t">Current time elapsed in ticks.</param>
        /// <returns></returns>
        /// <acknowledgment>
        /// https://github.com/darrendavid/wpf-animation
        /// https://github.com/jacobalbano/glide
        /// </acknowledgment>
        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float BackOutIn(float t) => (t < 0.5f) ? BackOut(t * 2f) : BackIn((t * 2f) - 1f);
        #endregion Back Easing Methods
    }
}
