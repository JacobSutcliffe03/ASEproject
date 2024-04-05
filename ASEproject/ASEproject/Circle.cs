using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// inherits shape.cs
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// int circle's radius
        /// </summary>
        protected int Radius;

        /// <summary>
        /// Draws circle.
        /// </summary>
        /// <param name="myGraphics">Graphics to draw onto the bitmap.</param>
        /// <param name="point">The point to draw from.</param>

        public override void DrawShape(Graphics myGraphics, Point point)
        {
            Pen pen = new Pen(Colour, 2);
            myGraphics.DrawEllipse(pen, point.X, point.Y, Radius * 2, Radius * 2);
        }
        /// <summary>
        /// Circle constructor.
        /// </summary>
        /// <param name="Colour">Colour of the circle.</param>
        /// <param name="XPos">X-coordinate of the circle.</param>
        /// <param name="YPos">Y-coordinate of the circle.</param>
        ///<param name="Radius">Radius of the circle.</param>
        public Circle(Color Colour, int XPos, int YPos, int Radius) : base(Colour, XPos, YPos)
        {
            this.Radius = Radius;
        }


    }
}