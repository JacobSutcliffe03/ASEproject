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