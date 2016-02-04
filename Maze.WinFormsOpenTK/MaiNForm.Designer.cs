namespace Maze.WinFormsOpenTK
{
    partial class MainForm
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
            this.MainGLControl = new OpenTK.GLControl();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainGLControl
            // 
            this.MainGLControl.BackColor = System.Drawing.Color.Black;
            this.MainGLControl.Location = new System.Drawing.Point(197, 12);
            this.MainGLControl.Name = "MainGLControl";
            this.MainGLControl.Size = new System.Drawing.Size(600, 600);
            this.MainGLControl.TabIndex = 0;
            this.MainGLControl.VSync = false;
            this.MainGLControl.Load += new System.EventHandler(this.MainGLControl_Load);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(9, 533);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(179, 23);
            this.GenerateButton.TabIndex = 1;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(9, 12);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(179, 45);
            this.trackBar1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 622);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.MainGLControl);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl MainGLControl;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

