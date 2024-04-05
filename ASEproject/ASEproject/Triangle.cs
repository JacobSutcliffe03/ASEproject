using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    public class Triangle : Shape
    {
        protected int sideLength;

        /// <summary>
        /// Draws triangle.
        /// </summary>
        /// <param name="Colour">The color of the triangle.</param>
        /// <param name="XPos">The X-coordinate of the triangle.</param>
        /// <param name="YPos">The Y-coordinate of the triangle.</param>
        /// <param name="sideLength">side length of the triangle.</param>
        public override void DrawShape(Graphics myGraphics, Point point)
        {
            Pen myPen = new Pen(Colour, 2);
            Point[] points = new Point[3];
            points[0] = new Point(point.X, point.Y - sideLength);
            points[1] = new Point(point.X - (sideLength / 2), point.Y + (sideLength / 2));
            points[2] = new Point(point.X + (sideLength / 2), point.Y + (sideLength / 2));

            myGraphics.DrawPolygon(myPen, points);
        }
        /// <summary>
        /// Triangle constuctor method.
        /// </summary>
        /// <param name="myGraphics">The graphics object to be drawn to bitmap.</param>
        /// <param name="point">The point drawn from.</param>
        public Triangle(Color Colour, int XPos, int YPos, int sideLength) : base(Colour, XPos, YPos)
        {
            this.sideLength = sideLength;


        }
    }
}