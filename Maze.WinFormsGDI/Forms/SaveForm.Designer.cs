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
            this.MainSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.MainTablessTabControl = new Maze.WinFormsGDI.Controls.TablessTabControl();
            this.SaveMethodTabPage = new System.Windows.Forms.TabPage();
            this.SaveMethodNextButton = new System.Windows.Forms.Button();
            this.SaveMethodGroupBox = new System.Windows.Forms.GroupBox();
            this.ImageSaveMethodRB = new System.Windows.Forms.RadioButton();
            this.NBTSaveMethodRB = new System.Windows.Forms.RadioButton();
            this.NBTSettingsTabPage = new System.Windows.Forms.TabPage();
            this.NBTSettingsBackButton = new System.Windows.Forms.Button();
            this.NBTSettingsNextButton = new System.Windows.Forms.Button();
            this.NBTAddFloorCheckBox = new System.Windows.Forms.CheckBox();
            this.NBTAddCeilingCheckBox = new System.Windows.Forms.CheckBox();
            this.NBTFloorIDNUD = new System.Windows.Forms.NumericUpDown();
            this.NBTCeilingIDNUD = new System.Windows.Forms.NumericUpDown();
            this.NBTWallsIDNUD = new System.Windows.Forms.NumericUpDown();
            this.NBTWallIDLabel = new System.Windows.Forms.Label();
            this.NBTWallsDataNUD = new System.Windows.Forms.NumericUpDown();
            this.NBTCeilingDataNUD = new System.Windows.Forms.NumericUpDown();
            this.NBTFloorDataNUD = new System.Windows.Forms.NumericUpDown();
            this.NBTPathDataNUD = new System.Windows.Forms.NumericUpDown();
            this.NBTPathIDLabel = new System.Windows.Forms.Label();
            this.NBTPathIDNUD = new System.Windows.Forms.NumericUpDown();
            this.MainTablessTabControl.SuspendLayout();
            this.SaveMethodTabPage.SuspendLayout();
            this.SaveMethodGroupBox.SuspendLayout();
            this.NBTSettingsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NBTFloorIDNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTCeilingIDNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTWallsIDNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTWallsDataNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTCeilingDataNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTFloorDataNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTPathDataNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTPathIDNUD)).BeginInit();
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
            this.NBTSettingsTabPage.Controls.Add(this.NBTPathDataNUD);
            this.NBTSettingsTabPage.Controls.Add(this.NBTPathIDLabel);
            this.NBTSettingsTabPage.Controls.Add(this.NBTPathIDNUD);
            this.NBTSettingsTabPage.Controls.Add(this.NBTWallsDataNUD);
            this.NBTSettingsTabPage.Controls.Add(this.NBTCeilingDataNUD);
            this.NBTSettingsTabPage.Controls.Add(this.NBTFloorDataNUD);
            this.NBTSettingsTabPage.Controls.Add(this.NBTWallIDLabel);
            this.NBTSettingsTabPage.Controls.Add(this.NBTWallsIDNUD);
            this.NBTSettingsTabPage.Controls.Add(this.NBTCeilingIDNUD);
            this.NBTSettingsTabPage.Controls.Add(this.NBTFloorIDNUD);
            this.NBTSettingsTabPage.Controls.Add(this.NBTAddCeilingCheckBox);
            this.NBTSettingsTabPage.Controls.Add(this.NBTAddFloorCheckBox);
            this.NBTSettingsTabPage.Controls.Add(this.NBTSettingsBackButton);
            this.NBTSettingsTabPage.Controls.Add(this.NBTSettingsNextButton);
            this.NBTSettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.NBTSettingsTabPage.Name = "NBTSettingsTabPage";
            this.NBTSettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.NBTSettingsTabPage.Size = new System.Drawing.Size(276, 235);
            this.NBTSettingsTabPage.TabIndex = 1;
            this.NBTSettingsTabPage.Text = "NBT Settings";
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
            // NBTSettingsNextButton
            // 
            this.NBTSettingsNextButton.Location = new System.Drawing.Point(193, 212);
            this.NBTSettingsNextButton.Name = "NBTSettingsNextButton";
            this.NBTSettingsNextButton.Size = new System.Drawing.Size(75, 23);
            this.NBTSettingsNextButton.TabIndex = 4;
            this.NBTSettingsNextButton.Text = "Next >>";
            this.NBTSettingsNextButton.UseVisualStyleBackColor = true;
            this.NBTSettingsNextButton.Click += new System.EventHandler(this.NBTSettingsNextButton_Click);
            // 
            // NBTAddFloorCheckBox
            // 
            this.NBTAddFloorCheckBox.AutoSize = true;
            this.NBTAddFloorCheckBox.Location = new System.Drawing.Point(8, 6);
            this.NBTAddFloorCheckBox.Name = "NBTAddFloorCheckBox";
            this.NBTAddFloorCheckBox.Size = new System.Drawing.Size(107, 17);
            this.NBTAddFloorCheckBox.TabIndex = 6;
            this.NBTAddFloorCheckBox.Text = "Add floor with ID:";
            this.NBTAddFloorCheckBox.UseVisualStyleBackColor = true;
            // 
            // NBTAddCeilingCheckBox
            // 
            this.NBTAddCeilingCheckBox.AutoSize = true;
            this.NBTAddCeilingCheckBox.Location = new System.Drawing.Point(8, 32);
            this.NBTAddCeilingCheckBox.Name = "NBTAddCeilingCheckBox";
            this.NBTAddCeilingCheckBox.Size = new System.Drawing.Size(117, 17);
            this.NBTAddCeilingCheckBox.TabIndex = 7;
            this.NBTAddCeilingCheckBox.Text = "Add ceiling with ID:";
            this.NBTAddCeilingCheckBox.UseVisualStyleBackColor = true;
            // 
            // NBTFloorIDNUD
            // 
            this.NBTFloorIDNUD.Location = new System.Drawing.Point(121, 5);
            this.NBTFloorIDNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NBTFloorIDNUD.Name = "NBTFloorIDNUD";
            this.NBTFloorIDNUD.Size = new System.Drawing.Size(66, 20);
            this.NBTFloorIDNUD.TabIndex = 10;
            this.NBTFloorIDNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NBTCeilingIDNUD
            // 
            this.NBTCeilingIDNUD.Location = new System.Drawing.Point(121, 31);
            this.NBTCeilingIDNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NBTCeilingIDNUD.Name = "NBTCeilingIDNUD";
            this.NBTCeilingIDNUD.Size = new System.Drawing.Size(66, 20);
            this.NBTCeilingIDNUD.TabIndex = 11;
            this.NBTCeilingIDNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NBTWallsIDNUD
            // 
            this.NBTWallsIDNUD.Location = new System.Drawing.Point(121, 57);
            this.NBTWallsIDNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NBTWallsIDNUD.Name = "NBTWallsIDNUD";
            this.NBTWallsIDNUD.Size = new System.Drawing.Size(66, 20);
            this.NBTWallsIDNUD.TabIndex = 13;
            this.NBTWallsIDNUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NBTWallIDLabel
            // 
            this.NBTWallIDLabel.AutoSize = true;
            this.NBTWallIDLabel.Location = new System.Drawing.Point(70, 59);
            this.NBTWallIDLabel.Name = "NBTWallIDLabel";
            this.NBTWallIDLabel.Size = new System.Drawing.Size(45, 13);
            this.NBTWallIDLabel.TabIndex = 14;
            this.NBTWallIDLabel.Text = "Wall ID:";
            // 
            // NBTWallsDataNUD
            // 
            this.NBTWallsDataNUD.Location = new System.Drawing.Point(193, 57);
            this.NBTWallsDataNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NBTWallsDataNUD.Name = "NBTWallsDataNUD";
            this.NBTWallsDataNUD.Size = new System.Drawing.Size(66, 20);
            this.NBTWallsDataNUD.TabIndex = 17;
            // 
            // NBTCeilingDataNUD
            // 
            this.NBTCeilingDataNUD.Location = new System.Drawing.Point(193, 31);
            this.NBTCeilingDataNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NBTCeilingDataNUD.Name = "NBTCeilingDataNUD";
            this.NBTCeilingDataNUD.Size = new System.Drawing.Size(66, 20);
            this.NBTCeilingDataNUD.TabIndex = 16;
            // 
            // NBTFloorDataNUD
            // 
            this.NBTFloorDataNUD.Location = new System.Drawing.Point(193, 5);
            this.NBTFloorDataNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NBTFloorDataNUD.Name = "NBTFloorDataNUD";
            this.NBTFloorDataNUD.Size = new System.Drawing.Size(66, 20);
            this.NBTFloorDataNUD.TabIndex = 15;
            // 
            // NBTPathDataNUD
            // 
            this.NBTPathDataNUD.Location = new System.Drawing.Point(193, 83);
            this.NBTPathDataNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NBTPathDataNUD.Name = "NBTPathDataNUD";
            this.NBTPathDataNUD.Size = new System.Drawing.Size(66, 20);
            this.NBTPathDataNUD.TabIndex = 20;
            // 
            // NBTPathIDLabel
            // 
            this.NBTPathIDLabel.AutoSize = true;
            this.NBTPathIDLabel.Location = new System.Drawing.Point(70, 85);
            this.NBTPathIDLabel.Name = "NBTPathIDLabel";
            this.NBTPathIDLabel.Size = new System.Drawing.Size(46, 13);
            this.NBTPathIDLabel.TabIndex = 19;
            this.NBTPathIDLabel.Text = "Path ID:";
            // 
            // NBTPathIDNUD
            // 
            this.NBTPathIDNUD.Location = new System.Drawing.Point(121, 83);
            this.NBTPathIDNUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NBTPathIDNUD.Name = "NBTPathIDNUD";
            this.NBTPathIDNUD.Size = new System.Drawing.Size(66, 20);
            this.NBTPathIDNUD.TabIndex = 18;
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
            this.NBTSettingsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NBTFloorIDNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTCeilingIDNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTWallsIDNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTWallsDataNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTCeilingDataNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTFloorDataNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTPathDataNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NBTPathIDNUD)).EndInit();
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
        private System.Windows.Forms.SaveFileDialog MainSaveFileDialog;
        private System.Windows.Forms.CheckBox NBTAddFloorCheckBox;
        private System.Windows.Forms.CheckBox NBTAddCeilingCheckBox;
        private System.Windows.Forms.NumericUpDown NBTWallsIDNUD;
        private System.Windows.Forms.NumericUpDown NBTCeilingIDNUD;
        private System.Windows.Forms.NumericUpDown NBTFloorIDNUD;
        private System.Windows.Forms.NumericUpDown NBTPathDataNUD;
        private System.Windows.Forms.Label NBTPathIDLabel;
        private System.Windows.Forms.NumericUpDown NBTPathIDNUD;
        private System.Windows.Forms.NumericUpDown NBTWallsDataNUD;
        private System.Windows.Forms.NumericUpDown NBTCeilingDataNUD;
        private System.Windows.Forms.NumericUpDown NBTFloorDataNUD;
        private System.Windows.Forms.Label NBTWallIDLabel;
    }
}