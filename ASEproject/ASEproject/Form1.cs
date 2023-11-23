using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASEproject
{
    public partial class FormWindow : Form
    {
        /// <summary>
        /// Bitmap to display in picturebox
        /// </summary>
        Bitmap OutputBitmap;
        Canvas MyCanvas;
        
        /// <summary>
        /// Initialise widgets on form.
        /// </summary>
        public FormWindow()
        {
            InitializeComponent();
            OutputBitmap = new Bitmap(OutputPB.Width, OutputPB.Height);
            MyCanvas = new Canvas(Graphics.FromImage(OutputBitmap));
        }

        private void SyntaxBTN_Click(object sender, EventArgs e)
        {

        }

        private void OpenBTN_Click(object sender, EventArgs e)
        {

        }

        private void SaveBTN_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Displays contents of bitmap onto picture box widget.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputPB_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0);
        }

        /// <summary>
        /// Iteraterativly calls parsecommand on lines in textbox widgets.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunBTN_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ProgramTB.Lines.Length; i++)
                {
                   MyCanvas.ParseCommand(ProgramTB.Lines[i]);
                }
                MyCanvas.ParseCommand(CommandLineTB.Text);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            Refresh();
        }
    }
}
