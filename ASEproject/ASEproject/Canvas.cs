using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEproject
{
    /// <summary>
    /// canvas used for drawing shapes on bitmap.
    /// </summary>
    public class Canvas
    {
        private List<string> executedCommands = new List<string>();
        private Graphics g;
        public Point p;
        private Bitmap myBitmap;
        public Point currentLocation;
        private Color currentPenColor = Color.Black;
        /// <summary>
        /// Handles drawing shapes.
        /// </summary>
        /// <param name="shape">The shape class being referenced.</param>
        public void DrawShape(Shape shape)
        {
            shape.DrawShape(g, p);
            executedCommands.Add(shape.ToString());
            // Storing the command for now, assuming ToString() provides command details
        }
        /// <summary>
        /// Retrives the executed commands
        /// </summary>
        /// <returns></returns>
        public List<string> GetExecutedCommands()
        {
            return executedCommands;
        }
        /// <summary>
        /// Moves the drawing position to a specified location.
        /// </summary>
        /// <param name="x">The X-coordinate of the new position.</param>
        /// <param name="y">The Y-coordinate of the new position.</param>
        public void MoveTo(int x, int y)
        {
            p = new Point(x, y);
            currentLocation = p;
        }
        /// <summary>
        /// Clears the canvas/Picture Box.
        /// </summary>
        public void Clear()
        {
            myBitmap = new Bitmap(myBitmap.Width, myBitmap.Height);
            g = Graphics.FromImage(myBitmap);
        }
        /// <summary>
        /// Set position to origin.
        /// </summary>
        public void Reset()
        {
            MoveTo(0, 0);
        }

        /// <summary>
        /// Draws a line from the current position to a point.
        /// </summary>
        /// <param name="x">X-coordinate of end point.</param>
        /// <param name="y">Y-coordinate of end point.</param>
        public void DrawTo(int x, int y)
        {
            Pen pen = new Pen(currentPenColor, 5);
            g.DrawLine(pen, p.X, p.Y, x, y);
            p = new Point(x, y);
            currentLocation = p;
        }

        /// <summary>
        /// Initializing canvas.
        /// </summary>
        /// <param name="width">The width of canvas.</param>
        /// <param name="height">The height of canvas.</param>
        public Canvas(int width, int height)
        {
            myBitmap = new Bitmap(width, height);
            g = Graphics.FromImage(myBitmap);

        }

        public Canvas()
        {
        }

        /// <summary>
        /// Getter method for the bitmap.
        /// </summary>
        /// <returns>The bitmap being drawn to.</returns>
        public Bitmap GetBitmap()
        {
            return myBitmap;
        }

        /// <summary>
        /// Getter for current position.
        /// </summary>
        /// <returns>Current position</returns>
        public Point GetCurrentLocation()
        {
            return currentLocation;
        }
        public void SetCurrentPenColor(Color Colour)
        {
            currentPenColor = Colour;
        }
    }
}