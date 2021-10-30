// <copyright file="CanvasControl.Designer.cs" company="Shkyrockett" >
//     Copyright © 2020 - 2021 Shkyrockett. All rights reserved.
// </copyright>
// <author id="shkyrockett">Shkyrockett</author>
// <license>
//     Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </license>
// <summary></summary>
// <remarks>
// </remarks>

namespace PrimerLibrary;

/// <summary>
/// 
/// </summary>
/// <seealso cref="System.Windows.Forms.UserControl" />
partial class CanvasControl
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components is not null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.SuspendLayout();
        // 
        // CanvasControl
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Name = "CanvasControl";
        this.Paint += new System.Windows.Forms.PaintEventHandler(this.Canvas_Paint);
        this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CanvasControl_MouseDown);
        this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CanvasControl_MouseMove);
        this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.CanvasControl_MouseWheel);
        this.Move += new System.EventHandler(this.Canvas_Move);
        this.Resize += new System.EventHandler(this.Canvas_Resize);
        this.ResumeLayout(false);

    }

    #endregion
}
