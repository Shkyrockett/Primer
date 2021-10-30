// <copyright file="CanvasControl.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

using MathematicsNotationLibrary;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using static Interop.Windows.User32;

namespace PrimerLibrary;

/// <summary>
/// 
/// </summary>
/// <seealso cref="System.Windows.Forms.UserControl" />
public partial class CanvasControl
    : UserControl
{
    #region Events
    internal event EventHandler<WMTouchEventArgs>? Touchdown;   // touch down event handler
    internal event EventHandler<WMTouchEventArgs>? Touchup;     // touch up event handler
    internal event EventHandler<WMTouchEventArgs>? TouchMove;   // touch move event handler
    #endregion

    #region Fields
    /// <summary>
    /// The panning
    /// </summary>
    private bool panning;

    /// <summary>
    /// The starting point
    /// </summary>
    private PointF ptFirst = PointF.Empty;

    /// <summary>
    /// The pan point
    /// </summary>
    private PointF panPoint = PointF.Empty;

    /// <summary>
    /// The i arguments
    /// </summary>
    private int iArguments = 0;

    /// <summary>
    /// The scale.
    /// </summary>
    private float scale = 1f;
    #endregion

    #region Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="CanvasControl" /> class.
    /// </summary>
    public CanvasControl()
    {
        DoubleBuffered = true;
        InitializeComponent();
        Expression = new RelationalOperation(ComparisonOperators.Equals, null, null);
    }
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the expression.
    /// </summary>
    /// <value>
    /// The expression.
    /// </value>
    public IExpression Expression { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether [render boundaries].
    /// </summary>
    /// <value>
    ///   <see langword="true" /> if [render boundaries]; otherwise, <see langword="false" />.
    /// </value>
    public bool RenderBoundaries { get; set; }

    /// <summary>
    /// Gets or sets the background color for the control.
    /// </summary>
    //[DefaultValue(System.Drawing.SystemColors.Window)]
    public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }
    #endregion

    #region Windows Proc
    /// <summary>
    /// Since there is no managed layer at the moment that supports event handlers for WM_GESTURENOTIFY and WM_GESTURE messages we have to override WndProc function in m - Message object
    /// </summary>
    /// <param name="m">The m.</param>
    /// <returns></returns>
    /// <exception cref="GestureConfig"></exception>
    protected override void WndProc(ref Message m)
    {
        var handled = ((WindowsMessages)m.Msg) switch
        {
            WindowsMessages.WM_GESTURENOTIFY => DecodeGestureNotify(ref m),
            WindowsMessages.WM_GESTURE => DecodeGesture(ref m),
            WindowsMessages.WM_TOUCH => DecodeTouch(ref m),
            _ => false,
        };

        // Filter message back up to parents.
        base.WndProc(ref m);

        if (handled)
        {
            // Acknowledge event if handled.
            try
            {
                m.Result = new IntPtr(1);
            }
            catch (Exception excep)
            {
                Debug.Print("Could not allocate result ptr");
                Debug.Print(excep.ToString());
            }
        }
    }

    /// <summary>
    /// Decodes the gesture notify.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.Exception">Error in execution of SetGestureConfig</exception>
    private bool DecodeGestureNotify(ref Message m)
    {
        _ = m;
        // This is the right place to define the list of gestures that this application will support. By populating GESTURECONFIG structure and calling SetGestureConfig function. We can choose gestures that we want to handle in our application. In this app we decide to  handle all gestures.
        var gc = new GestureConfig
        {
            dwID = 0, // gesture ID
            dwWant = GestureConfigurationFlags.GC_ALLGESTURES, // settings related to gesture ID that are to be turned on
            dwBlock = 0 // settings related to gesture ID that are to be
        };
        // We must p/invoke into user32 [winuser.h]
        bool bResult = SetGestureConfig(
            Handle, // window for which configuration is specified
            0,      // reserved, must be 0
            1,      // count of GESTURECONFIG structures
            ref gc, // array of GESTURECONFIG structures, dwIDs will be processed in the order specified and repeated occurrences will overwrite previous ones
            GestureConfig.GetSize() // sizeof(GESTURECONFIG)
        );

        if (!bResult)
        {
            throw new Exception("Error in execution of SetGestureConfig");
        }

        return true;
    }

    /// <summary>
    /// Decodes the gesture. Handler of gestures in: m - Message object
    /// </summary>
    /// <param name="m">The m.</param>
    /// <returns></returns>
    private bool DecodeGesture(ref Message m)
    {
        GestureInfo gi;
        try
        {
            gi = new GestureInfo
            {
                cbSize = GestureInfo.GetSize()
            };

            // Load the gesture information.
            if (!GetGestureInfo(m.LParam, ref gi))
            {
                return false;
            }
        }
        catch (Exception excep)
        {
            Debug.Print("Could not allocate resources to decode gesture");
            Debug.Print(excep.ToString());
            return false;
        }

        var previousScale = scale;
        switch (gi.dwID)
        {
            case GestureId.Begin:
            case GestureId.End:
                break;
            case GestureId.Zoom:
                switch (gi.dwFlags)
                {
                    case GestureFlags.Begin:
                        iArguments = (int)(gi.ullArguments & ULL_ARGUMENTS_BIT_MASK);
                        ptFirst = Mathematics.ZoomAtTransposedMatrix(panPoint, PointToClient(gi.ptsLocation), previousScale, scale);
                        break;
                    default:
                        scale = (gi.ullArguments & ULL_ARGUMENTS_BIT_MASK) / (float)iArguments;
                        scale = scale < Mathematics.scale_per_delta ? Mathematics.scale_per_delta : scale;
                        panPoint = Mathematics.ZoomAtTransposedMatrix(panPoint, PointToClient(gi.ptsLocation), previousScale, scale);
                        Invalidate();
                        break;
                }
                break;
            case GestureId.Pan:
                switch (gi.dwFlags)
                {
                    case GestureFlags.Begin:
                        panning = true;
                        ptFirst = Mathematics.ScreenToObjectTransposedMatrix(panPoint, PointToClient(gi.ptsLocation), scale);
                        panPoint = Mathematics.ScreenToObjectTransposedMatrix(ptFirst, PointToClient(gi.ptsLocation), scale);
                        break;
                    case GestureFlags.End:
                        panning = false;
                        break;
                    default:
                        if (panning)
                        {
                            panPoint = Mathematics.ScreenToObjectTransposedMatrix(ptFirst, PointToClient(gi.ptsLocation), scale);
                            Invalidate();
                        }
                        break;
                }
                break;
            case GestureId.Rotate:
                switch (gi.dwFlags)
                {
                    case GestureFlags.Begin:
                        iArguments = 0;
                        break;

                    default:
                        ptFirst.X = gi.ptsLocation.x;
                        ptFirst.Y = gi.ptsLocation.y;
                        ptFirst = PointToClient(Point.Truncate(ptFirst));

                        // Gesture handler returns cumulative rotation angle. However we
                        // have to pass the delta angle to our function responsible 
                        // to process the rotation gesture.
                        //dwo.Rotate(
                        //    ArgToRadians(gi.ullArguments & ULL_ARGUMENTS_BIT_MASK)
                        //    - ArgToRadians(iArguments),
                        //    ptFirst.X, ptFirst.Y
                        //);

                        Invalidate();

                        iArguments = (int)(gi.ullArguments & ULL_ARGUMENTS_BIT_MASK);
                        break;
                }
                break;
            case GestureId.TwoFingerTap:
                // Toggle drawing of diagonals
                //dwo.ToggleDrawDiagonals();
                Invalidate();
                break;
            case GestureId.PressAndTap:
                if (gi.dwFlags == GestureFlags.Begin)
                {
                    // Shift drawing color
                    //dwo.ShiftColor();
                    Invalidate();
                }
                break;
        }

        return true;
    }

    /// <summary>
    /// Decodes and handles WM_TOUCH message. Unpacks message arguments and invokes appropriate touch events.
    /// </summary>
    /// <param name="m">The window message.</param>
    /// <returns>whether the message has been handled</returns>
    private bool DecodeTouch(ref Message m)
    {
        // More than one touch-input may be associated with a touch message,
        // so an array is needed to get all event information.
        var inputCount = LoWord(m.WParam.ToInt32()); // Number of touch inputs, actual per-contact messages

        // Array of TOUCHINPUT structures
        var inputs = new TouchInput[inputCount]; // Allocate the storage for the parameters of the per-contact messages

        // Unpack message parameters into the array of TOUCHINPUT structures, each
        // representing a message for one single contact.
        if (!GetTouchInputInfo(m.LParam, inputCount, inputs, TouchInput.GetSize()))
        {
            // Get touch info failed.
            return false;
        }

        // For each contact, dispatch the message to the appropriate message
        // handler.
        var handled = false; // Boolean, is message handled
        for (var i = 0; i < inputCount; i++)
        {
            var ti = inputs[i];

            // Assign a handler to this message.
            EventHandler<WMTouchEventArgs>? handler = default;     // Touch event handler
            if ((ti.dwFlags & TouchEventFlags.Down) != 0)
            {
                handler = Touchdown;
            }
            else if ((ti.dwFlags & TouchEventFlags.Up) != 0)
            {
                handler = Touchup;
            }
            else if ((ti.dwFlags & TouchEventFlags.Move) != 0)
            {
                handler = TouchMove;
            }

            // Convert message parameters into touch event arguments and handle the event.
            if (handler != null)
            {
                // Convert the raw touch-input message into a touch-event.
                var te = new WMTouchEventArgs
                {
                    // TOUCHINFO point coordinates and contact size is in 1/100 of a pixel; convert it to pixels.
                    // Also convert screen to client coordinates.
                    ContactY = ti.cyContact / 100,
                    ContactX = ti.cxContact / 100,
                    Id = ti.dwID
                }; // Touch event arguments
                {
                    var pt = PointToClient(new Point(ti.x / 100, ti.y / 100));
                    te.LocationX = pt.X;
                    te.LocationY = pt.Y;
                }
                te.Time = ti.dwTime;
                te.Mask = ti.dwMask;
                te.Flags = ti.dwFlags;

                // Invoke the event handler.
                handler(this, te);

                // Mark this event as handled.
                handled = true;
            }
        }

        CloseTouchInputHandle(m.LParam);

        return handled;
    }
    #endregion

    #region Event handlers
    /// <summary>
    /// Handles the Paint event of the Canvas control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Canvas_Paint(object sender, PaintEventArgs e)
    {
        var window = new SizeF(Size.Width - 1f, Size.Height - 1f);
        var bounds = new RectangleF(PointF.Empty, window);
        var padding = Math.Min(window.Width * 0.25f, window.Height * 0.25f);
        var outer = new SizeF(window.Width - padding, window.Height - padding);

        var g = e.Graphics;
        var inner = Expression.Layout(g, base.Font, 1f);
        var cScale = Utilities.FitSizeWithin(inner, outer);
        inner = Expression.Layout(g, base.Font, cScale);

        PointF location = new((window.Width - inner.Width) * 0.5f, (window.Height - inner.Height) * 0.5f);

        g.Clear(BackColor);
        g.ResetTransform();
        g.ScaleTransform(scale, scale);
        g.TranslateTransform(panPoint.X, panPoint.Y);
        g.TextRenderingHint = TextRenderingHint.AntiAlias;
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.CompositingQuality = CompositingQuality.HighQuality;
        g.CompositingMode = CompositingMode.SourceOver;

        Expression?.Draw(g, base.Font, Brushes.Black, Pens.Black, location, cScale, RenderBoundaries);

        g.ResetTransform();
        g.DrawRectangle(Pens.CornflowerBlue, bounds);
#if DEBUG
        using var font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        TextRenderer.DrawText(g, $"Pan Point: {panPoint}\n\rScale: {scale}\n\r🌎 Mouse Pos: {MousePosition}", font, new Point(0, 0), ForeColor);
#endif
    }

    /// <summary>
    /// Handles the Resize event of the Canvas control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Canvas_Resize(object sender, EventArgs e) => Invalidate();

    /// <summary>
    /// Handles the Move event of the Canvas control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void Canvas_Move(object sender, EventArgs e) => Invalidate();

    /// <summary>
    /// Handles the MouseDown event of the CanvasControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void CanvasControl_MouseDown(object sender, MouseEventArgs e)
    {
        var translateScalePoint = Mathematics.ScreenToObjectTransposedMatrix(panPoint, e.Location, scale);
        var scalePoint = Mathematics.ScreenToObject(e.Location, scale);

        // See what we're over.
        if (e.Button == MouseButtons.Left)
        { }
        else if (e.Button == MouseButtons.Middle)
        {
            panning = true;
            ptFirst = translateScalePoint;
            panPoint = Mathematics.ScreenToObjectTransposedMatrix(ptFirst, e.Location, scale);

            // Get ready to work on the new polygon.
            MouseMove -= CanvasControl_MouseMove;
            MouseMove += CanvasControl_MouseMove_Panning;
            MouseUp += CanvasControl_MouseUp_Panning;
        }
        else if (e.Button == MouseButtons.Right)
        { }
        else if (e.Button == MouseButtons.XButton1)
        { }
        else if (e.Button == MouseButtons.XButton2)
        { }

        // Redraw.
        Invalidate();
    }

    /// <summary>
    /// Canvases the control mouse move.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="MouseEventArgs"/> instance containing the event data.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void CanvasControl_MouseMove(object? sender, MouseEventArgs e)
    {
        //var mousePoint = Mathematics.ScreenToObjectTransposedMatrix(panPoint, e.Location, scale);
        //Cursor =
        //    MouseIsOverCornerPoint(mousePoint, envelope).Success ? Cursors.Arrow :
        //    MouseIsOverCornerPoint(mousePoint, group).Success ? Cursors.Arrow :
        //    MouseIsOverEdge(mousePoint, group).Success ? Cursors.Cross :
        //    MouseIsOverPolygon(mousePoint, group).Success ? Cursors.Hand :
        //    Cursors.Cross;
        Invalidate();
    }

    /// <summary>
    /// Handles the Panning event of the Canvas control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void CanvasControl_MouseMove_Panning(object? sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Middle && panning)
        {
            panPoint = Mathematics.ScreenToObjectTransposedMatrix(ptFirst, e.Location, scale);
            Invalidate();
        }
    }

    /// <summary>
    /// Handles the MouseUp Panning event of the Canvas control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void CanvasControl_MouseUp_Panning(object? sender, MouseEventArgs e)
    {
        MouseMove += CanvasControl_MouseMove;
        MouseMove -= CanvasControl_MouseMove_Panning;
        MouseUp -= CanvasControl_MouseUp_Panning;

        if (e.Button == MouseButtons.Middle && panning)
        {
            panning = false;
            Invalidate();
        }
    }

    /// <summary>
    /// Handles the MouseWheel event of the Form1 control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    private void CanvasControl_MouseWheel(object sender, MouseEventArgs e)
    {
        var previousScale = scale;
        scale = Mathematics.MouseWheelScaleFactor(scale, e.Delta);
        scale = scale < Mathematics.scale_per_delta ? Mathematics.scale_per_delta : scale;
        panPoint = Mathematics.ZoomAtTransposedMatrix(panPoint, e.Location, previousScale, scale);
        Invalidate();
    }
    #endregion

    /// <summary>
    /// Extracts lower 16-bit word from an 32-bit int.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <returns></returns>
    private static int LoWord(int number) => number & 0xffff;
}
