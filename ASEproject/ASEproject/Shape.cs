using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    //Shape Class to be inherited from.
    public abstract class Shape
    {
        protected Color Colour;
        protected int XPos, YPos;

        public abstract void DrawShape(Graphics g, Point point);
        public Shape(Color colour, int x, int y)
        {
            this.Colour = colour;
            this.XPos = x; this.YPos = y;

        }

        public override string ToString()
        {
            return base.ToString() + XPos + " " + YPos;
        }
    }
}
