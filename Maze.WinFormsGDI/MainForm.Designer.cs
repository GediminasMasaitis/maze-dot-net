using Maze.WinFormsGDI.Controls;

namespace Maze.WinFormsGDI
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
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.AlgorithmComboBox = new System.Windows.Forms.ComboBox();
            this.GrowingTreePanel = new System.Windows.Forms.Panel();
            this.AlgorithmLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.GeneratorDelayLabel = new System.Windows.Forms.Label();
            this.RendererDelayLabel = new System.Windows.Forms.Label();
            this.InfiniteMapCheckBox = new System.Windows.Forms.CheckBox();
            this.RendererDelayLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.GeneratorDelayLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RendererDelayLogarithmicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneratorDelayLogarithmicTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.BackColor = System.Drawing.Color.Black;
            this.MainPictureBox.Location = new System.Drawing.Point(355, 3);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(900, 900);
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(13, 15);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(336, 28);
            this.GenerateButton.TabIndex = 1;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // AlgorithmComboBox
            // 
            this.AlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmComboBox.FormattingEnabled = true;
            this.AlgorithmComboBox.Location = new System.Drawing.Point(69, 55);
            this.AlgorithmComboBox.Name = "AlgorithmComboBox";
            this.AlgorithmComboBox.Size = new System.Drawing.Size(156, 21);
            this.AlgorithmComboBox.TabIndex = 2;
            // 
            // GrowingTreePanel
            // 
            this.GrowingTreePanel.Location = new System.Drawing.Point(32, 270);
            this.GrowingTreePanel.Name = "GrowingTreePanel";
            this.GrowingTreePanel.Size = new System.Drawing.Size(197, 447);
            this.GrowingTreePanel.TabIndex = 3;
            // 
            // AlgorithmLabel
            // 
            this.AlgorithmLabel.AutoSize = true;
            this.AlgorithmLabel.Location = new System.Drawing.Point(10, 58);
            this.AlgorithmLabel.Name = "AlgorithmLabel";
            this.AlgorithmLabel.Size = new System.Drawing.Size(53, 13);
            this.AlgorithmLabel.TabIndex = 4;
            this.AlgorithmLabel.Text = "Algorithm:";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(12, 97);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(38, 13);
            this.WidthLabel.TabIndex = 5;
            this.WidthLabel.Text = "Width:";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(56, 94);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(89, 20);
            this.WidthTextBox.TabIndex = 6;
            this.WidthTextBox.Text = "21";
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(231, 94);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(89, 20);
            this.HeightTextBox.TabIndex = 8;
            this.HeightTextBox.Text = "21";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(184, 97);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(41, 13);
            this.HeightLabel.TabIndex = 7;
            this.HeightLabel.Text = "Height:";
            // 
            // GeneratorDelayLabel
            // 
            this.GeneratorDelayLabel.AutoSize = true;
            this.GeneratorDelayLabel.Location = new System.Drawing.Point(10, 129);
            this.GeneratorDelayLabel.Name = "GeneratorDelayLabel";
            this.GeneratorDelayLabel.Size = new System.Drawing.Size(113, 13);
            this.GeneratorDelayLabel.TabIndex = 9;
            this.GeneratorDelayLabel.Text = "Generator delay: 0 ms.";
            // 
            // RendererDelayLabel
            // 
            this.RendererDelayLabel.AutoSize = true;
            this.RendererDelayLabel.Location = new System.Drawing.Point(10, 161);
            this.RendererDelayLabel.Name = "RendererDelayLabel";
            this.RendererDelayLabel.Size = new System.Drawing.Size(110, 13);
            this.RendererDelayLabel.TabIndex = 11;
            this.RendererDelayLabel.Text = "Renderer delay: 0 ms.";
            // 
            // InfiniteMapCheckBox
            // 
            this.InfiniteMapCheckBox.AutoSize = true;
            this.InfiniteMapCheckBox.Location = new System.Drawing.Point(254, 59);
            this.InfiniteMapCheckBox.Name = "InfiniteMapCheckBox";
            this.InfiniteMapCheckBox.Size = new System.Drawing.Size(80, 17);
            this.InfiniteMapCheckBox.TabIndex = 13;
            this.InfiniteMapCheckBox.Text = "Infinite map";
            this.InfiniteMapCheckBox.UseVisualStyleBackColor = true;
            // 
            // RendererDelayLogarithmicTrackBar
            // 
            this.RendererDelayLogarithmicTrackBar.Location = new System.Drawing.Point(134, 161);
            this.RendererDelayLogarithmicTrackBar.LogMaximum = 1000D;
            this.RendererDelayLogarithmicTrackBar.LogMiddle = 16D;
            this.RendererDelayLogarithmicTrackBar.LogMinimum = 0D;
            this.RendererDelayLogarithmicTrackBar.Maximum = 1000;
            this.RendererDelayLogarithmicTrackBar.Name = "RendererDelayLogarithmicTrackBar";
            this.RendererDelayLogarithmicTrackBar.Size = new System.Drawing.Size(200, 45);
            this.RendererDelayLogarithmicTrackBar.TabIndex = 15;
            this.RendererDelayLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RendererDelayLogarithmicTrackBar.Value = 500;
            this.RendererDelayLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.RendererDelayLogarithmicTrackBar_ValueChanged);
            // 
            // GeneratorDelayLogarithmicTrackBar
            // 
            this.GeneratorDelayLogarithmicTrackBar.Location = new System.Drawing.Point(136, 129);
            this.GeneratorDelayLogarithmicTrackBar.LogMaximum = 10000D;
            this.GeneratorDelayLogarithmicTrackBar.LogMiddle = 100D;
            this.GeneratorDelayLogarithmicTrackBar.LogMinimum = 0D;
            this.GeneratorDelayLogarithmicTrackBar.Maximum = 1000;
            this.GeneratorDelayLogarithmicTrackBar.Name = "GeneratorDelayLogarithmicTrackBar";
            this.GeneratorDelayLogarithmicTrackBar.Size = new System.Drawing.Size(198, 45);
            this.GeneratorDelayLogarithmicTrackBar.TabIndex = 14;
            this.GeneratorDelayLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GeneratorDelayLogarithmicTrackBar.Value = 500;
            this.GeneratorDelayLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.GeneratorDelayLogarithmicTrackBar_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 911);
            this.Controls.Add(this.GeneratorDelayLabel);
            this.Controls.Add(this.RendererDelayLabel);
            this.Controls.Add(this.RendererDelayLogarithmicTrackBar);
            this.Controls.Add(this.GeneratorDelayLogarithmicTrackBar);
            this.Controls.Add(this.InfiniteMapCheckBox);
            this.Controls.Add(this.HeightTextBox);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.WidthTextBox);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.AlgorithmLabel);
            this.Controls.Add(this.GrowingTreePanel);
            this.Controls.Add(this.AlgorithmComboBox);
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.MainPictureBox);
            this.Name = "MainForm";
            this.Text = "Maze generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RendererDelayLogarithmicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneratorDelayLogarithmicTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.ComboBox AlgorithmComboBox;
        private System.Windows.Forms.Panel GrowingTreePanel;
        private System.Windows.Forms.Label AlgorithmLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label GeneratorDelayLabel;
        private System.Windows.Forms.Label RendererDelayLabel;
        private System.Windows.Forms.CheckBox InfiniteMapCheckBox;
        private LogarithmicTrackBar GeneratorDelayLogarithmicTrackBar;
        private LogarithmicTrackBar RendererDelayLogarithmicTrackBar;
    }
}

