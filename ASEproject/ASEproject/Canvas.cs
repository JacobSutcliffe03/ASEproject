using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Holds attributes and methods for manipulating graphics object.
    /// </summary>
    class Canvas
    {
        Graphics g;
        Pen Pen;
        Brush Brush;
        /// <summary>
        /// Current pen position.
        /// </summary>
        int xPos, yPos;
        /// <summary>
        /// flag for changing fill mode.
        /// </summary>
        bool fill = false;

        /// <summary>
        /// Constructor for canvas object.
        /// </summary>
        /// <param name="g"></param>
        public Canvas(Graphics g) 
        {
            this.g = g;
            xPos = yPos = 0;
            Pen = new Pen(Color.Black, 1);
            Brush = new SolidBrush(Color.Black);
        }

        /// <summary>
        /// Formats, parses, matches then runs given string.
        /// </summary>
        /// <param name="line">Commands to be parsed</param>
        public void ParseCommand(String line)
        {
            //Formatting strings.
            line = line.ToLower().Trim();
            String[] split = line.Split(' ');
            String command = split[0];
            String[] param = split[1].Split(',');

            //Check for commands with non-integer parameters.
            if (command == "fill")
            {
                FillShapes(param[0]);
            }
            if (command == "colour")
            {
                changeColour(param[0]);
            }
            if (command == "clear") 
            {
                ClearPB();
            }

            //Parse parameters.
            var parameters = new int[param.Length];
            try 
            { 
                for (int i = 0; i < param.Length; i++)
                {
                    parameters[i] = int.Parse(param[i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Matching commands and running methods.
            switch (command)
            {
                case null:
                    param = null;
                    break;
                case "moveto":
                    try
                    { 
                        MoveTo(parameters[0], parameters[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "drawto":
                    try
                    {
                        DrawLine(parameters[0], parameters[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "triangle":
                    try
                    {
                        DrawTriangle(parameters[0], parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "rectangle":
                    try
                    {
                        DrawRectangle(parameters[0], parameters[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "circle":
                    try
                    {
                        DrawCircle(xPos, yPos, parameters[0]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "clear":
                    try
                    {
                        ClearPB();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                default:
                    param = null; 
                    break;
            }

        }

        /// <summary>
        /// Moves the pens position without drawing.
        /// </summary>
        /// <param name="toX">int Move to pen to x coordinate.</param>
        /// <param name="toY">int Move to pen to y coordinate.</param>
        public void MoveTo(int toX, int toY)
        {
            xPos = toX;
            yPos = toY;
        }

        /// <summary>
        /// Draws a line between current pen position and (toX, toY).
        /// </summary>
        /// <param name="toX">int Draws to x coordinate.</param>
        /// <param name="toY">int Draws to y coordinate.</param>
        public void DrawLine(int toX, int toY) 
        {
            g.DrawLine(Pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;
        }

        /// <summary>
        /// Controls fill mode.
        /// </summary>
        /// <param name="fillFlag">string if true then starts fill mode.</param>
        public void FillShapes(string fillFlag) 
        {
            if (fillFlag == "true")
            {
                fill = true;
            }
            else
            {
                fill = false;
            }
        }

        /// <summary>
        /// Changes pen colour.
        /// </summary>
        /// <param name="colour">string colour drawn by pen.</param>
        public void changeColour(string colour)
        {
            switch (colour)
            {
                case "red":
                    Pen.Color = Color.Red;
                    Brush = new SolidBrush(Color.Red);
                    break;        
                case "green":
                    Pen.Color = Color.Green;
                    Brush = new SolidBrush(Color.Green);
                    break;
                case "blue":
                    Pen.Color = Color.Blue;
                    Brush = new SolidBrush(Color.Blue);
                    break;
                case "black" :
                    Pen.Color = Color.Black;
                    Brush = new SolidBrush(Color.Black);
                    break;
                default: 
                    Console.WriteLine("Invalid parameters"); break;
            }
        }

        /// <summary>
        /// Draws a rectangle on graphics object.
        /// </summary>
        /// <param name="width">int</param>
        /// <param name="height">int</param>
        public void DrawRectangle(int width, int height)
        {          
            if (fill == true)
            {
                g.FillRectangle(Brush, xPos, yPos, width, height);
            }
            else
            {
                g.DrawRectangle(Pen, xPos, yPos, width, height);
            }

        }

        /// <summary>
        /// Draws a circle on graphics object.
        /// </summary>
        /// <param name="xPos">float Current pen x position.</param>
        /// <param name="yPos">float Current pen y position.</param>
        /// <param name="radius">float</param>
        public void DrawCircle(float xPos, float yPos, float radius)
        {          
            if (fill == true)
            {
                g.FillEllipse(Brush, xPos - radius, yPos - radius, radius*2, radius*2);
            }
            else
            {
                g.DrawEllipse(Pen, xPos - radius, yPos - radius, radius*2, radius*2);
            }
        }

        /// <summary>
        /// Draws a triangle between three points.
        /// </summary>
        /// <param name="p1x">int</param>
        /// <param name="p1y">int</param>
        /// <param name="p2x">int</param>
        /// <param name="p2y">int</param>
        /// <param name="p3x">int</param>
        /// <param name="p3y">int</param>
        public void DrawTriangle(int p1x, int p1y, int p2x, int p2y, int p3x, int p3y)
        {
            if (fill == true)
            {
                g.FillPolygon(Brush, new Point[] { new Point(p1x, p1y), new Point(p2x, p2y), new Point(p3x, p3y) });
            }
            else
            {
                g.DrawPolygon(Pen, new Point[] { new Point(p1x, p1y), new Point(p2x, p2y), new Point(p3x, p3y) });
            }
        }

        /// <summary>
        /// Clears graphics object.
        /// </summary>
        public void ClearPB() 
        {
            g.Clear(Color.LightGray);
        }

    }
}
