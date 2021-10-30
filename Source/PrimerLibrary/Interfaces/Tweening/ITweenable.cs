// <copyright file="ITween.cs" company="Shkyrockett" >
//     Copyright © 2013 - 2018 Jacob Albano. All rights reserved.
// </copyright>
// <author id="jacobalbano">Jacob Albano</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks> Based on: https://github.com/jacobalbano/glide </remarks>

using System;

namespace PrimerLibrary;

/// <summary>
/// 
/// </summary>
public interface ITweenable
{
    /// <summary>
    /// Gets or sets the time remaining.
    /// </summary>
    /// <value>
    /// The time remaining.
    /// </value>
    double TimeRemaining { get; }

    /// <summary>
    /// Gets or sets the completion.
    /// </summary>
    /// <value>
    /// The completion.
    /// </value>
    double Completion { get; }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="ITweenable" /> is looping.
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if looping; otherwise, <see langword="false" />.
    /// </value>
    bool Looping { get; }

    /// <summary>
    /// Gets or sets the target.
    /// </summary>
    /// <value>
    /// The target.
    /// </value>
    object Target { get; }

    /// <summary>
    /// Adds the lerp.
    /// </summary>
    /// <param name="lerper">The lerper.</param>
    /// <param name="info">The information.</param>
    /// <param name="first">From.</param>
    /// <param name="last">To.</param>
    void AddLerp(IMemberLerper lerper, IMemberAccessor info, object first, object last);

    /// <summary>
    /// Updates the specified elapsed.
    /// </summary>
    /// <param name="elapsed">The elapsed.</param>
    void UpdateTween(float elapsed);

    #region Behavior
    /// <summary>
    /// Froms the specified values.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <returns></returns>
    ITweenable From(object values);

    /// <summary>
    /// Eases the specified ease.
    /// </summary>
    /// <param name="ease">The ease.</param>
    /// <returns></returns>
    ITweenable Ease(Func<float, float> ease);

    /// <summary>
    /// Called when [begin].
    /// </summary>
    /// <param name="callback">The callback.</param>
    /// <returns></returns>
    ITweenable OnBegin(Action callback);

    /// <summary>
    /// Called when [update].
    /// </summary>
    /// <param name="callback">The callback.</param>
    /// <returns></returns>
    ITweenable OnUpdate(Action callback);

    /// <summary>
    /// Called when [complete].
    /// </summary>
    /// <param name="callback">The callback.</param>
    /// <returns></returns>
    ITweenable OnComplete(Action callback);

    /// <summary>
    /// Repeats the specified times.
    /// </summary>
    /// <param name="times">The times.</param>
    /// <returns></returns>
    ITweenable Repeat(int times = -1);

    /// <summary>
    /// Repeats the delay.
    /// </summary>
    /// <param name="delay">The delay.</param>
    /// <returns></returns>
    ITweenable RepeatDelay(float delay);

    /// <summary>
    /// Reflects this instance.
    /// </summary>
    /// <returns></returns>
    ITweenable Reflect();

    /// <summary>
    /// Reverses this instance.
    /// </summary>
    /// <returns></returns>
    ITweenable Reverse();

    /// <summary>
    /// Rotations the specified unit.
    /// </summary>
    /// <param name="unit">The unit.</param>
    /// <returns></returns>
    ITweenable Rotation(RotationUnit unit = RotationUnit.Degrees);

    /// <summary>
    /// Rounds this instance.
    /// </summary>
    /// <returns></returns>
    ITweenable Round();
    #endregion

    #region Control
    /// <summary>
    /// Cancels this instance.
    /// </summary>
    void CancelTween();

    /// <summary>
    /// Cancels the specified properties.
    /// </summary>
    /// <param name="properties">The properties.</param>
    void CancelTween(params string[] properties);

    /// <summary>
    /// Cancels the and complete.
    /// </summary>
    void CancelTweenAndComplete();

    /// <summary>
    /// Pauses this instance.
    /// </summary>
    void PauseTween();

    /// <summary>
    /// Pauses the toggle.
    /// </summary>
    void PauseTweenToggle();

    /// <summary>
    /// Resumes this instance.
    /// </summary>
    void ResumeTween();
    #endregion
}
