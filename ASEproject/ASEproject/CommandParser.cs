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

            /// <summary>
            /// Handles the 'repeat' command to loop the shapes multiple times on the canvas.
            /// </summary>
            /// <param name="elems">The array of command elems.</param>
            /// <param name="pen">The Pen object used for drawing.</param>
            /// <param name="canvas">The canvas where the shapes are drawn.</param>
            private void LoopCommand(string[] elems, Pen pen, Canvas canvas)
            {
                // Checking for valid amount of elems in command
                if (elems.Length >= 4 && (elems[2].ToLower() == "circle" || elems[2].ToLower() == "rectangle" || elems[2].ToLower() == "triangle"))
                {
                    int size1 = ifVariableOrValue(elems[3]);

                    if (int.TryParse(elems[1], out int repeatCount))
                    {
                        //repeats the loop -example - repeat 5 (repeats it 5 times)
                        for (int i = 0; i < repeatCount; i++)
                        {
                            // changes the position on the canvas to show its repeating
                            int newX = canvas.GetCurrentLocation().X + i * 5;
                            int newY = canvas.GetCurrentLocation().Y + i * 5;
                            canvas.MoveTo(newX, newY);

                            if (elems[2].ToLower() == "circle")
                            {
                                Shape circle = new Circle(pen.Color, newX, newY, size1);
                                canvas.DrawShape(circle);
                            }
                            else if (elems[2].ToLower() == "rectangle")
                            {
                                if (elems.Length >= 5)
                                {
                                    int size2 = ifVariableOrValue(elems[4]);
                                    Shape rectangle = new Rectangle(pen.Color, newX, newY, size1, size2);
                                    canvas.DrawShape(rectangle);
                                }
                            }
                            else if (elems[2].ToLower() == "triangle" && elems.Length >= 5)
                            {
                                int size2 = ifVariableOrValue(elems[4]);
                                Shape triangle = new Triangle(pen.Color, newX, newY, size1);
                                canvas.DrawShape(triangle);
                            }
                        }
                    }
                    else if (variables.ContainsKey(elems[1]))
                    {
                        // If the loop count is a variable eg. repeat x amount of times
                        int loopCount = variables[elems[1]];
                        for (int i = 0; i < loopCount; i++)
                        {
                            // changes the position on the canvas to show its repeating
                            int newX = canvas.GetCurrentLocation().X + i * 5;
                            int newY = canvas.GetCurrentLocation().Y + i * 5;
                            canvas.MoveTo(newX, newY);

                            if (elems[2].ToLower() == "circle")
                            {
                                Shape circle = new Circle(pen.Color, newX, newY, size1);
                                canvas.DrawShape(circle);
                            }
                            else if (elems[2].ToLower() == "rectangle")
                            {
                                if (elems.Length >= 5)
                                {
                                    int size2 = ifVariableOrValue(elems[4]);
                                    Shape rectangle = new Rectangle(pen.Color, newX, newY, size1, size2);
                                    canvas.DrawShape(rectangle);
                                }
                            }
                            else if (elems[2].ToLower() == "triangle" && elems.Length >= 5)
                            {
                                int size2 = ifVariableOrValue(elems[4]);
                                Shape triangle = new Triangle(pen.Color, newX, newY, size1);
                                canvas.DrawShape(triangle);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid 'repeat' command syntax. Loop count must be a variable or a numerical value.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid 'repeat' command syntax.");
                    // syntaxes for incorrect commands
                }
            }
            /// <summary>
            /// Checks if a element in command is a variable or a value.
            /// </summary>
            /// <param name="variableOrValue">The input string representing either a variable name or a numerical value.</param>
            /// <returns>The value corresponding to the variable name or the parsed numerical value.</returns>
            private int ifVariableOrValue(string variableOrValue)
            {
                if (variables.ContainsKey(variableOrValue))
                {
                    return variables[variableOrValue];
                }
                else if (Int32.TryParse(variableOrValue, out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Invalid Parameters: {variableOrValue}");
                    return 0;
                }
            }


            /// <summary>
            /// Handles the let command for variable assignment, updating the variables dictionary - let x equals 10
            /// </summary>
            /// <param name="elems">The array of command parts.</param>
            private void VariableAssignment(string[] elems)
            {

                if (elems.Length == 4 && elems[2].ToLower() == "equals")
                {
                    string variableName = elems[1];  // Do not convert to lowercase
                    int value = Int32.Parse(elems[3]);

                    // Updatse the variables dictionary with the assigned value that was inpputed in
                    if (variables.ContainsKey(variableName))
                    {
                        variables[variableName] = value;
                    }
                    else
                    {
                        variables.Add(variableName, value);
                    }

                }
            }

            /// <summary>
            /// Changes pens colour.
            /// </summary>
            /// <param name="elems">The array of command elems.</param>
            /// <param name="pen">The Pen object whose color will be set.</param>
            private void ColorCommand(string[] elems, Pen pen)
            {
                if (elems.Length > 1)
                {
                    switch (elems[1].ToLower())
                    {
                        case "black":
                            pen.Color = Color.Black;
                            break;
                        case "blue":
                            pen.Color = Color.Blue;
                            break;
                        case "green":
                            pen.Color = Color.Green;
                            break;
                        case "red":
                            pen.Color = Color.Red;
                            break;
                        default:
                            Console.WriteLine($"Invalid color: {elems[1]}");
                            break;
                    }

                }

            }
            /// <summary>
            /// This will try to evaluate the specified numerical expression and retrieves the result for it
            /// </summary>
            /// <param name="expression">The mathematical expression to be evaluated.</param>
            /// <param name="result">The result of the evaluation if successful, otherwise 0.</param>
            /// <returns>True if the expression is successfully evaluated, false otherwise.</returns>
            private bool TryEvaluateExpression(string expression, out int result)
            {
                result = 0;

                foreach (var variable in variables)
                {
                    expression = expression.Replace(variable.Key, variable.Value.ToString());
                }


                expression = expression.Replace("*", " * ");

                DataTable dt = new DataTable();

                try
                {
                    result = Convert.ToInt32(dt.Compute(expression, ""));
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }



            }
            /// <summary>
            /// Handles the if command to conditionally execute a command
            /// </summary>
            /// <param name="parts">The array of command parts.</param>
            /// <param name="pen">The Pen object used for drawing.</param>
            /// <param name="canvas">The canvas where the shapes are drawn.</param>
            private void IfCommand(string[] parts, Pen pen, Canvas canvas)
            {
                //combines the condition back into a single string to be evaluated
                string condition = string.Join(" ", parts.Skip(1).TakeWhile(p => p != "circle" && p != "rectangle" && p != "triangle"));
                bool conditionMet = false;

                if (condition.Contains("equals"))
                {
                    string[] conditionParts = condition.Split(new string[] { "equals" }, StringSplitOptions.None);

                    string variableName = conditionParts[0].Trim();
                    string stringValue = conditionParts[1].Trim();

                    //checks wether or not the variable exists in the dictionary and its value mtaches with the condition
                    if (variables.TryGetValue(variableName, out int variableValue) && variableValue == int.Parse(stringValue))
                    {
                        conditionMet = true;
                    }

                }
                if (conditionMet)
                {
                    //Extracts the command after the condition is done
                    string commandToExecute = string.Join(" ", parts.SkipWhile(p => p != "circle" && p != "rectangle" && p != "triangle"));
                    new CommandParser(commandToExecute, pen, canvas);
                }
            }
        }
    }
