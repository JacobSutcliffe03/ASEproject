namespace ASEproject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenBTN = new System.Windows.Forms.Button();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.RunBTN = new System.Windows.Forms.Button();
            this.SyntaxBTN = new System.Windows.Forms.Button();
            this.ProgramTB = new System.Windows.Forms.TextBox();
            this.CommandLineTB = new System.Windows.Forms.TextBox();
            this.OutputPB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.OutputPB)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenBTN
            // 
            this.OpenBTN.Location = new System.Drawing.Point(12, 12);
            this.OpenBTN.Name = "OpenBTN";
            this.OpenBTN.Size = new System.Drawing.Size(75, 23);
            this.OpenBTN.TabIndex = 0;
            this.OpenBTN.Text = "Open";
            this.OpenBTN.UseVisualStyleBackColor = true;
            this.OpenBTN.Click += new System.EventHandler(this.OpenBTN_Click);
            // 
            // SaveBTN
            // 
            this.SaveBTN.Location = new System.Drawing.Point(93, 12);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(75, 23);
            this.SaveBTN.TabIndex = 1;
            this.SaveBTN.Text = "Save";
            this.SaveBTN.UseVisualStyleBackColor = true;
            this.SaveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // RunBTN
            // 
            this.RunBTN.Location = new System.Drawing.Point(12, 338);
            this.RunBTN.Name = "RunBTN";
            this.RunBTN.Size = new System.Drawing.Size(75, 23);
            this.RunBTN.TabIndex = 2;
            this.RunBTN.Text = "Run";
            this.RunBTN.UseVisualStyleBackColor = true;
            this.RunBTN.Click += new System.EventHandler(this.RunBTN_Click);
            // 
            // SyntaxBTN
            // 
            this.SyntaxBTN.Location = new System.Drawing.Point(93, 338);
            this.SyntaxBTN.Name = "SyntaxBTN";
            this.SyntaxBTN.Size = new System.Drawing.Size(75, 23);
            this.SyntaxBTN.TabIndex = 3;
            this.SyntaxBTN.Text = "Syntax";
            this.SyntaxBTN.UseVisualStyleBackColor = true;
            this.SyntaxBTN.Click += new System.EventHandler(this.SyntaxBTN_Click);
            // 
            // ProgramTB
            // 
            this.ProgramTB.Location = new System.Drawing.Point(12, 41);
            this.ProgramTB.Multiline = true;
            this.ProgramTB.Name = "ProgramTB";
            this.ProgramTB.Size = new System.Drawing.Size(374, 265);
            this.ProgramTB.TabIndex = 5;
            // 
            // CommandLineTB
            // 
            this.CommandLineTB.Location = new System.Drawing.Point(13, 312);
            this.CommandLineTB.Name = "CommandLineTB";
            this.CommandLineTB.Size = new System.Drawing.Size(373, 20);
            this.CommandLineTB.TabIndex = 6;
            // 
            // OutputPB
            // 
            this.OutputPB.BackColor = System.Drawing.SystemColors.ControlDark;
            this.OutputPB.Location = new System.Drawing.Point(416, 41);
            this.OutputPB.Name = "OutputPB";
            this.OutputPB.Size = new System.Drawing.Size(357, 265);
            this.OutputPB.TabIndex = 7;
            this.OutputPB.TabStop = false;

            // 
            // FormWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 374);
            this.Controls.Add(this.OutputPB);
            this.Controls.Add(this.CommandLineTB);
            this.Controls.Add(this.ProgramTB);
            this.Controls.Add(this.SyntaxBTN);
            this.Controls.Add(this.RunBTN);
            this.Controls.Add(this.SaveBTN);
            this.Controls.Add(this.OpenBTN);
            this.Name = "FormWindow";
            this.Text = "ASE graphics project";
            ((System.ComponentModel.ISupportInitialize)(this.OutputPB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OpenBTN;
        private System.Windows.Forms.Button SaveBTN;
        private System.Windows.Forms.Button RunBTN;
        private System.Windows.Forms.Button SyntaxBTN;
        private System.Windows.Forms.TextBox ProgramTB;
        private System.Windows.Forms.TextBox CommandLineTB;
        private System.Windows.Forms.PictureBox OutputPB;
    }
}
