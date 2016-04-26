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
            this.SaveMethodNextButton = new System.Windows.Forms.Button();
            this.SaveMethodGroupBox = new System.Windows.Forms.GroupBox();
            this.ImageSaveMethodRB = new System.Windows.Forms.RadioButton();
            this.NBTSaveMethodRB = new System.Windows.Forms.RadioButton();
            this.NBTSettingsTabPage = new System.Windows.Forms.TabPage();
            this.NBTSettingsNextButton = new System.Windows.Forms.Button();
            this.NBTSettingsBackButton = new System.Windows.Forms.Button();
            this.MainTablessTabControl.SuspendLayout();
            this.SaveMethodTabPage.SuspendLayout();
            this.SaveMethodGroupBox.SuspendLayout();
            this.NBTSettingsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTablessTabControl
            // 
            this.MainTablessTabControl.Controls.Add(this.SaveMethodTabPage);
            this.MainTablessTabControl.Controls.Add(this.NBTSettingsTabPage);
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
            this.SaveMethodTabPage.Controls.Add(this.SaveMethodNextButton);
            this.SaveMethodTabPage.Controls.Add(this.SaveMethodGroupBox);
            this.SaveMethodTabPage.Location = new System.Drawing.Point(4, 22);
            this.SaveMethodTabPage.Name = "SaveMethodTabPage";
            this.SaveMethodTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SaveMethodTabPage.Size = new System.Drawing.Size(276, 235);
            this.SaveMethodTabPage.TabIndex = 0;
            this.SaveMethodTabPage.Text = "Save method";
            // 
            // SaveMethodNextButton
            // 
            this.SaveMethodNextButton.Location = new System.Drawing.Point(193, 212);
            this.SaveMethodNextButton.Name = "SaveMethodNextButton";
            this.SaveMethodNextButton.Size = new System.Drawing.Size(75, 23);
            this.SaveMethodNextButton.TabIndex = 3;
            this.SaveMethodNextButton.Text = "Next >>";
            this.SaveMethodNextButton.UseVisualStyleBackColor = true;
            this.SaveMethodNextButton.Click += new System.EventHandler(this.SaveMethodNextButton_Click);
            // 
            // SaveMethodGroupBox
            // 
            this.SaveMethodGroupBox.Controls.Add(this.ImageSaveMethodRB);
            this.SaveMethodGroupBox.Controls.Add(this.NBTSaveMethodRB);
            this.SaveMethodGroupBox.Location = new System.Drawing.Point(20, 19);
            this.SaveMethodGroupBox.Name = "SaveMethodGroupBox";
            this.SaveMethodGroupBox.Size = new System.Drawing.Size(130, 72);
            this.SaveMethodGroupBox.TabIndex = 2;
            this.SaveMethodGroupBox.TabStop = false;
            this.SaveMethodGroupBox.Text = "Save method";
            // 
            // ImageSaveMethodRB
            // 
            this.ImageSaveMethodRB.AutoSize = true;
            this.ImageSaveMethodRB.Checked = true;
            this.ImageSaveMethodRB.Location = new System.Drawing.Point(16, 19);
            this.ImageSaveMethodRB.Name = "ImageSaveMethodRB";
            this.ImageSaveMethodRB.Size = new System.Drawing.Size(54, 17);
            this.ImageSaveMethodRB.TabIndex = 0;
            this.ImageSaveMethodRB.TabStop = true;
            this.ImageSaveMethodRB.Text = "Image";
            this.ImageSaveMethodRB.UseVisualStyleBackColor = true;
            // 
            // NBTSaveMethodRB
            // 
            this.NBTSaveMethodRB.AutoSize = true;
            this.NBTSaveMethodRB.Location = new System.Drawing.Point(16, 43);
            this.NBTSaveMethodRB.Name = "NBTSaveMethodRB";
            this.NBTSaveMethodRB.Size = new System.Drawing.Size(98, 17);
            this.NBTSaveMethodRB.TabIndex = 1;
            this.NBTSaveMethodRB.Text = "NBT schematic";
            this.NBTSaveMethodRB.UseVisualStyleBackColor = true;
            // 
            // NBTSettingsTabPage
            // 
            this.NBTSettingsTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.NBTSettingsTabPage.Controls.Add(this.NBTSettingsBackButton);
            this.NBTSettingsTabPage.Controls.Add(this.NBTSettingsNextButton);
            this.NBTSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.NBTSettingsTabPage.Name = "NBTSettingsTabPage";
            this.NBTSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.NBTSettingsTabPage.Size = new System.Drawing.Size(276, 235);
            this.NBTSettingsTabPage.TabIndex = 1;
            this.NBTSettingsTabPage.Text = "NBT Settings";
            // 
            // NBTSettingsNextButton
            // 
            this.NBTSettingsNextButton.Location = new System.Drawing.Point(193, 212);
            this.NBTSettingsNextButton.Name = "NBTSettingsNextButton";
            this.NBTSettingsNextButton.Size = new System.Drawing.Size(75, 23);
            this.NBTSettingsNextButton.TabIndex = 4;
            this.NBTSettingsNextButton.Text = "Next >>";
            this.NBTSettingsNextButton.UseVisualStyleBackColor = true;
            // 
            // NBTSettingsBackButton
            // 
            this.NBTSettingsBackButton.Location = new System.Drawing.Point(112, 212);
            this.NBTSettingsBackButton.Name = "NBTSettingsBackButton";
            this.NBTSettingsBackButton.Size = new System.Drawing.Size(75, 23);
            this.NBTSettingsBackButton.TabIndex = 5;
            this.NBTSettingsBackButton.Text = "<< Back";
            this.NBTSettingsBackButton.UseVisualStyleBackColor = true;
            this.NBTSettingsBackButton.Click += new System.EventHandler(this.NBTSettingsBackButton_Click);
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
            this.SaveMethodTabPage.ResumeLayout(false);
            this.SaveMethodGroupBox.ResumeLayout(false);
            this.SaveMethodGroupBox.PerformLayout();
            this.NBTSettingsTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TablessTabControl MainTablessTabControl;
        private System.Windows.Forms.TabPage SaveMethodTabPage;
        private System.Windows.Forms.Button SaveMethodNextButton;
        private System.Windows.Forms.GroupBox SaveMethodGroupBox;
        private System.Windows.Forms.RadioButton ImageSaveMethodRB;
        private System.Windows.Forms.RadioButton NBTSaveMethodRB;
        private System.Windows.Forms.TabPage NBTSettingsTabPage;
        private System.Windows.Forms.Button NBTSettingsBackButton;
        private System.Windows.Forms.Button NBTSettingsNextButton;
    }
}