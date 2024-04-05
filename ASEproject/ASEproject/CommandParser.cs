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
