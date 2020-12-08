// <copyright file="Caret.cs" company="Shkyrockett" >
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
using System.Drawing;

/// <summary>
/// 
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// 
    /// </summary>
    internal static partial class User32
    {
        /// <summary>
        /// 
        /// </summary>
        public static class Caret
        {
            /// <summary>
            /// Creates the specified system caret.
            /// </summary>
            /// <param name="windowHandle">The window handle.</param>
            /// <param name="bitmapHandle">The bitmap handle.</param>
            /// <param name="width">Width of the caret.</param>
            /// <param name="height">Height of the caret.</param>
            /// <returns></returns>
            public static bool Create(IntPtr windowHandle, IntPtr bitmapHandle, int width, int height)
            {
                try
                {
                    return CreateCaret(windowHandle, bitmapHandle, width, height);
                }
                catch (Exception ex)
                {
                    // Let's pretend CreateCaret() is available on Linux
                    if ((ex is DllNotFoundException) || (ex is EntryPointNotFoundException))
                    {
                        return true;
                    }

                    throw;
                }
            }

            public static bool Show(IntPtr hWnd)
            {
                try
                {
                    return ShowCaret(hWnd);
                }
                catch (Exception ex)
                {
                    // Let's pretend ShowCaret() is available on Linux
                    if ((ex is DllNotFoundException) || (ex is EntryPointNotFoundException))
                    {
                        return true;
                    }

                    throw;
                }
            }

            public static bool Hide(IntPtr hWnd)
            {
                try
                {
                    return HideCaret(hWnd);
                }
                catch (Exception ex)
                {
                    // Let's pretend HideCaret() is available on Linux
                    if ((ex is DllNotFoundException) || (ex is EntryPointNotFoundException))
                    {
                        return true;
                    }

                    throw;
                }
            }

            public static bool Destroy()
            {
                try
                {
                    return DestroyCaret();
                }
                catch (Exception ex)
                {
                    // Let's pretend DestroyCaret() is available on Linux
                    if ((ex is DllNotFoundException) || (ex is EntryPointNotFoundException))
                    {
                        return true;
                    }

                    throw;
                }
            }

            public static bool SetPos(int X, int Y)
            {
                try
                {
                    return SetCaretPos(X, Y);
                }
                catch (Exception ex)
                {
                    // Let's pretend SetCaretPos() is available on Linux
                    if ((ex is DllNotFoundException) || (ex is EntryPointNotFoundException))
                    {
                        return false;
                    }

                    throw;
                }
            }

            public static Point GetPos()
            {
                try
                {
                    GetCaretPos(out var point);
                    return point;
                }
                catch (Exception ex)
                {
                    // Let's pretend SetCaretPos() is available on Linux
                    if ((ex is DllNotFoundException) || (ex is EntryPointNotFoundException))
                    {
                        return Point.Empty;
                    }

                    throw;
                }
            }

            public static uint GetGlobalCaretBlinkTime()
            {
                try
                {
                    return GetCaretBlinkTime();
                }
                catch (Exception ex)
                {
                    // Let's pretend SetCaretPos() is available on Linux
                    if ((ex is DllNotFoundException) || (ex is EntryPointNotFoundException))
                    {
                        return 0;
                    }

                    throw;
                }
            }

            public static bool SetGlobalCaretBlinkTime(uint miliseconds)
            {
                try
                {
                    return SetCaretBlinkTime(miliseconds);
                }
                catch (Exception ex)
                {
                    // Let's pretend SetCaretPos() is available on Linux
                    if ((ex is DllNotFoundException) || (ex is EntryPointNotFoundException))
                    {
                        return true;
                    }

                    throw;
                }
            }
        }
    }
}
