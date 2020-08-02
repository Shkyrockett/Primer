using System.Drawing;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class WindowsFormsRenderer
    {
        /// <summary>
        /// The graphics
        /// </summary>
        readonly Graphics graphics;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowsFormsRenderer"/> class.
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        public WindowsFormsRenderer(Graphics graphics)
        {
            this.graphics = graphics;
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="brush">The brush.</param>
        /// <param name="point">The point.</param>
        public void DrawText(string text, Font font, Brush brush, PointF point) => graphics.DrawString(text, font, brush, point);
    }
}
