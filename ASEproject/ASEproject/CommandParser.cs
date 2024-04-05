using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASEproject
{
    /// <summary>
    /// Parses and processes different commands for the project.
    /// </summary>
    public class CommandParser
    {
        /// <summary>
        /// Initializes a new instance of the MyCommandParser class.
        /// </summary>
        /// <param name="command">The command to be processed.</param>
        /// <param name="pen">The pen used for drawing.</param>
        /// <param name="canvas">The canvas where the shapes are drawn.</param>
        /// 
        private string lastCommand;
        public static Dictionary<string, int> variables = new Dictionary<string, int>();
        public CommandParser(string command, Pen pen, Canvas canvas)
        {


            Console.WriteLine("command: " + command);
            string[] elems = command.Split(' ');
            lastCommand = command;

            // moves the cursor to the selected location.
            if (elems[0] == "moveto")
            {
                int x = Int32.Parse(elems[1]);
                int y = Int32.Parse(elems[2]);
                canvas.MoveTo(x, y);

            }
            else if (elems[0] == "circle")
            {
                if (elems.Length == 2)
                {
                    int radius = ifVariableOrValue(elems[1]);
                    Shape circle = new Circle(pen.Color, canvas.GetCurrentLocation().X, canvas.GetCurrentLocation().Y, radius);
                    canvas.DrawShape(circle);
                }
                else
                {
                    Console.WriteLine("Invalid 'circle' command syntax.");
                }

            }


            // draws a circle on the bitmap.

            else if (elems[0] == "rectangle")
            {
                if (elems.Length == 3)
                {
                    int width = ifVariableOrValue(elems[1]);
                    int height = ifVariableOrValue(elems[2]);
                    Shape rectangle = new Rectangle(pen.Color, 15, 15, width, height);
                    canvas.DrawShape(rectangle);
                }
                else
                {
                    Console.WriteLine("Invalid 'rectangle' command syntax.");
                }
            }
            // draws a rectangle on the bitmap.
            else if (elems[0] == "triangle")
            {
                int sideLength = Int32.Parse(elems[1]);
                Shape triangle = new Triangle(pen.Color, 15, 15, sideLength);
                canvas.DrawShape(triangle);

            }
            //draws a triangle on the bitmap.

            else if (elems[0] == "clear")
            {
                canvas.Clear();
            }
            //clears bitmap.

            else if (elems[0] == "reset")
            {
                canvas.Reset();
            }
            //resets the cursor to origin.

            else if (elems[0] == "drawto")
            {
                int x = Int32.Parse(elems[1]);
                int y = Int32.Parse(elems[2]);
                canvas.DrawTo(x, y);
            }
            //draws a line to a point.
            else if (elems[0] == "colour")
            {
                ColorCommand(elems, pen);
            }
            //Change Pen colour
            else if (elems[0] == "let")
            {
                Console.WriteLine("let called");
                string name = elems[1];
                string expression = string.Join(" ", elems.Skip(3));

                if (TryEvaluateExpression(expression, out int value))
                {
                    variables[name] = value;
                }
                else
                {
                    Console.WriteLine($"Error evaluating expression for variable {name}");
                }
            }

            else if (elems[0] == "repeat")
            {

                LoopCommand(elems, pen, canvas);

            }
            else if (elems[0] == "if")
            {
                IfCommand(elems, pen, canvas);
            }