namespace Maze.WinFormsGDI.Forms
{
    partial class SaveForm
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
            this.MainTablessTabControl = new Maze.WinFormsGDI.Controls.TablessTabControl();
            this.SaveMethodTabPage = new System.Windows.Forms.TabPage();
            this.MainTablessTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTablessTabControl
            // 
            this.MainTablessTabControl.Controls.Add(this.SaveMethodTabPage);
            this.MainTablessTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTablessTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTablessTabControl.Name = "MainTablessTabControl";
            this.MainTablessTabControl.SelectedIndex = 0;
            this.MainTablessTabControl.Size = new System.Drawing.Size(284, 261);
            this.MainTablessTabControl.TabIndex = 0;
            // 
            // SaveMethodTabPage
            // 
            this.SaveMethodTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.SaveMethodTabPage.Location = new System.Drawing.Point(4, 22);
            this.SaveMethodTabPage.Name = "SaveMethodTabPage";
            this.SaveMethodTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SaveMethodTabPage.Size = new System.Drawing.Size(276, 235);
            this.SaveMethodTabPage.TabIndex = 0;
            this.SaveMethodTabPage.Text = "Save method";
            // 
            // SaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.MainTablessTabControl);
            this.Name = "SaveForm";
            this.Text = "SaveForm";
            this.MainTablessTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TablessTabControl MainTablessTabControl;
        private System.Windows.Forms.TabPage SaveMethodTabPage;
    }
}