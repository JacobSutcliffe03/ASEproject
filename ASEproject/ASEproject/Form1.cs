using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEproject
{
    public partial class Form1 : Form
    {
        Pen pen;
        Canvas canvas;
        String command;

        /// <summary>
        /// Constructor for form window.
        /// </summary>

        public Form1()
        {
            InitializeComponent(); // Initializes the form.
            pen = new Pen(Color.Red, 5); // Initializes a Pen.
            canvas = new Canvas(300, 350); // Initializes the canvas.

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Save the programs to txt file.
        /// </summary>
        public void SaveBTN_Click(object sender, EventArgs e)
        {
            // Creating a save file.
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                string programText = string.Empty;
                saveFileDialog.Filter = "Text|*.txt|All Files|*.*"; // Filters file type.

                // Null Check
                if (!string.IsNullOrWhiteSpace(ProgramTB.Text))
                {
                    programText = ProgramTB.Text; // Assigns the content of the program textbox
                    saveFileDialog.ShowDialog();  // Shows the dialog for saving the file
                    string filePath = saveFileDialog.FileName; // Gets the file path

                    if (!string.IsNullOrEmpty(filePath)) // If a file path is provided
                    {
                        // Writes the content of the program textbox to the selected file
                        System.IO.File.WriteAllText(filePath, programText);
                        MessageBox.Show("Program saved.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Save confirmation message
                    }
                }
            }
        }

        /// <summary>
        /// load program from a text file.
        /// </summary>
        public void OpenBTN_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files|*.txt|All Files|*.*";  // Filter for text files.
                if (openFileDialog.ShowDialog() == DialogResult.OK) // Opens file dialog to select a file.
                {
                    string selectedFilePath = openFileDialog.FileName; // Retrieves the selected file path.
                    string commandsToLoad = System.IO.File.ReadAllText(selectedFilePath); // Reads the content of the selected files.
                    ProgramTB.Text = commandsToLoad; // Populates the multi line textbox with the loaded commands

                }
            }

        }

        /// <summary>
        /// Event handler for executing the commands that are entered.
        /// </summary>
        private void RunBTN_Click(object sender, EventArgs e)
        {
            command = CommandLineTB.Text; // Gets the command from a single-line text box.

            CommandParser cp = new CommandParser(command, pen, canvas); //processes the command.

            Bitmap myBitmap = canvas.GetBitmap();
            OutputPB.Image = myBitmap; // Updates bitmap.

            command = ProgramTB.Text;
            string[] commands = command.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); // Gets commands from program TB.

            foreach (var cmd in commands) // loop through commands
            {
                CommandParser commandprocessor = new CommandParser(cmd, pen, canvas); // Processes commands.
            }

        }

        /// <summary>
        /// Event handler for validating commands.
        /// </summary>

        private void SyntaxBTN_Click(object sender, EventArgs e)
        {
            string CL = CommandLineTB.Text; //code in command line
            string ML = ProgramTB.Text; //code in program textbox
            string[] codeList = { CL, ML }; //List of values from program TB and Commandline

            StringBuilder validationResults = new StringBuilder(); // create a string builder for validation 
            foreach (string code in codeList) //loop/step through commands through the commands
            {
                string[] elems = code.Split(' '); //split commands

                if (elems.Length > 0) //null length check
                {
                    string command = elems[0];

                    try
                    {


                        switch (command) //switch case for commands 
                        {
                            case "moveto":
                                if (elems.Length == 3)
                                {
                                    if (int.TryParse(elems[1], out _) && int.TryParse(elems[2], out _)) //checks if the command is valid
                                    {
                                        validationResults.AppendLine("Valid command");
                                    }
                                    else
                                    {
                                        validationResults.AppendLine("Invalid parameter types for moveto");
                                    }
                                }
                                else
                                {
                                    validationResults.AppendLine("Invalid parameters for moveto");
                                }
                                break;

                            case "circle":
                                if (elems.Length >= 2 && int.TryParse(elems[1], out _))
                                {
                                    validationResults.AppendLine("Valid command");
                                }
                                else
                                {
                                    validationResults.AppendLine("Invalid parameters for circle");
                                }
                                break;

                            case "rectangle":
                                if (elems.Length == 3)
                                {
                                    if (int.TryParse(elems[1], out _) && int.TryParse(elems[2], out _))
                                    {
                                        validationResults.AppendLine("Valid command");
                                    }
                                    else
                                    {
                                        validationResults.AppendLine("Invalid parameters for rectangle");
                                    }
                                }


                                break;

                            case "triangle":
                                if (elems.Length == 2)
                                {
                                    if (int.TryParse(elems[1], out _))
                                    {
                                        validationResults.AppendLine("Valid command");
                                    }
                                    else
                                    {
                                        validationResults.AppendLine("Invalid parameters for triangle");
                                    }
                                }

                                break;


                            case "clear":

                                break;

                            case "reset":

                                break;

                            case "drawto":

                                if (elems.Length == 3)
                                {
                                    if (int.TryParse(elems[1], out _) && int.TryParse(elems[2], out _)) //checking parameters
                                    {
                                        validationResults.AppendLine("Valid command");
                                    }
                                    else
                                    {
                                        validationResults.AppendLine("Invalid parameter types for drawto");
                                    }
                                }
                                else
                                {
                                    validationResults.AppendLine("Incalid parameters for drawto");
                                }
                                break;


                            default:
                                validationResults.AppendLine(" ");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        validationResults.AppendLine($"Error: {ex.Message}");
                    }
                }
                else
                {
                    validationResults.AppendLine("Invalid command");
                }
            }

            MessageBox.Show(validationResults.ToString(), "Syntax Check");

        }
    }
}