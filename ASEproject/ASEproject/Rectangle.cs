using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    public class Rectangle : Shape
    {
        /// </summary>
        /// The height and width of the rectangle
        /// </summary>

        protected int height;
        protected int width;

        /// </summary>
        /// Draws rectangle.
        /// </summary>
        /// <param name="myGraphics">Graphics to draw onto the bitmap.</param>
        /// <param name="point">The point to draw from.</param>
        public override void DrawShape(Graphics myGraphics, Point point)
        {
            Pen pen = new Pen(Colour, 2);
            myGraphics.DrawRectangle(pen, point.X, point.Y, height, width);
        }

        /// </summary>
        /// Rectangle constructor method.
        /// </summary>
        /// <param name="Colour">The color of the rectangle.</param>
        /// <param name="XPos">The X-coordinate of the rectangle's position.</param>
        /// <param name="YPos">The Y-coordinate of the rectangle's position.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        public Rectangle(Color Colour, int myX, int myY, int height, int width) : base(Colour, myX, myY)
        {
            this.height = height;
            this.width = width;

        }


    }
}
