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
            this.GrowingTreeBreadthLabel = new System.Windows.Forms.Label();
            this.AlgorithmLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.GeneratorDelayLabel = new System.Windows.Forms.Label();
            this.RendererDelayLabel = new System.Windows.Forms.Label();
            this.InfiniteMapCheckBox = new System.Windows.Forms.CheckBox();
            this.TrackChangesCheckBox = new System.Windows.Forms.CheckBox();
            this.GrowingTreeGroupBox = new System.Windows.Forms.GroupBox();
            this.GrowingTreeRunLabel = new System.Windows.Forms.Label();
            this.GrowingTreeBraidLabel = new System.Windows.Forms.Label();
            this.BiasesGroupBox = new System.Windows.Forms.GroupBox();
            this.GrowingTreeTreesLabel = new System.Windows.Forms.Label();
            this.GrowingTreeTreesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.RecursiveDivisionGroupBox = new System.Windows.Forms.GroupBox();
            this.GrowingTreeRunLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.GrowingTreeBraidLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.GrowingTreeBreadthLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.RendererDelayLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.GeneratorDelayLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.GrowingTreeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeTreesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeRunLogarithmicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBraidLogarithmicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBreadthLogarithmicTrackBar)).BeginInit();
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
            this.AlgorithmComboBox.Location = new System.Drawing.Point(74, 198);
            this.AlgorithmComboBox.Name = "AlgorithmComboBox";
            this.AlgorithmComboBox.Size = new System.Drawing.Size(156, 21);
            this.AlgorithmComboBox.TabIndex = 2;
            this.AlgorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.AlgorithmComboBox_SelectedIndexChanged);
            // 
            // GrowingTreeBreadthLabel
            // 
            this.GrowingTreeBreadthLabel.AutoSize = true;
            this.GrowingTreeBreadthLabel.Location = new System.Drawing.Point(28, 68);
            this.GrowingTreeBreadthLabel.Name = "GrowingTreeBreadthLabel";
            this.GrowingTreeBreadthLabel.Size = new System.Drawing.Size(64, 13);
            this.GrowingTreeBreadthLabel.TabIndex = 17;
            this.GrowingTreeBreadthLabel.Text = "Breadth: 0%";
            // 
            // AlgorithmLabel
            // 
            this.AlgorithmLabel.AutoSize = true;
            this.AlgorithmLabel.Location = new System.Drawing.Point(15, 201);
            this.AlgorithmLabel.Name = "AlgorithmLabel";
            this.AlgorithmLabel.Size = new System.Drawing.Size(53, 13);
            this.AlgorithmLabel.TabIndex = 4;
            this.AlgorithmLabel.Text = "Algorithm:";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(13, 59);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(38, 13);
            this.WidthLabel.TabIndex = 5;
            this.WidthLabel.Text = "Width:";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(57, 56);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(89, 20);
            this.WidthTextBox.TabIndex = 6;
            this.WidthTextBox.Text = "49";
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(57, 82);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(89, 20);
            this.HeightTextBox.TabIndex = 8;
            this.HeightTextBox.Text = "49";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(10, 85);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(41, 13);
            this.HeightLabel.TabIndex = 7;
            this.HeightLabel.Text = "Height:";
            // 
            // GeneratorDelayLabel
            // 
            this.GeneratorDelayLabel.AutoSize = true;
            this.GeneratorDelayLabel.Location = new System.Drawing.Point(11, 122);
            this.GeneratorDelayLabel.Name = "GeneratorDelayLabel";
            this.GeneratorDelayLabel.Size = new System.Drawing.Size(113, 13);
            this.GeneratorDelayLabel.TabIndex = 9;
            this.GeneratorDelayLabel.Text = "Generator delay: 0 ms.";
            // 
            // RendererDelayLabel
            // 
            this.RendererDelayLabel.AutoSize = true;
            this.RendererDelayLabel.Location = new System.Drawing.Point(11, 154);
            this.RendererDelayLabel.Name = "RendererDelayLabel";
            this.RendererDelayLabel.Size = new System.Drawing.Size(110, 13);
            this.RendererDelayLabel.TabIndex = 11;
            this.RendererDelayLabel.Text = "Renderer delay: 0 ms.";
            // 
            // InfiniteMapCheckBox
            // 
            this.InfiniteMapCheckBox.AutoSize = true;
            this.InfiniteMapCheckBox.Location = new System.Drawing.Point(180, 58);
            this.InfiniteMapCheckBox.Name = "InfiniteMapCheckBox";
            this.InfiniteMapCheckBox.Size = new System.Drawing.Size(80, 17);
            this.InfiniteMapCheckBox.TabIndex = 13;
            this.InfiniteMapCheckBox.Text = "Infinite map";
            this.InfiniteMapCheckBox.UseVisualStyleBackColor = true;
            // 
            // TrackChangesCheckBox
            // 
            this.TrackChangesCheckBox.AutoSize = true;
            this.TrackChangesCheckBox.Location = new System.Drawing.Point(180, 85);
            this.TrackChangesCheckBox.Name = "TrackChangesCheckBox";
            this.TrackChangesCheckBox.Size = new System.Drawing.Size(98, 17);
            this.TrackChangesCheckBox.TabIndex = 16;
            this.TrackChangesCheckBox.Text = "Track changes";
            this.TrackChangesCheckBox.UseVisualStyleBackColor = true;
            this.TrackChangesCheckBox.CheckedChanged += new System.EventHandler(this.TrackChangesCheckBox_CheckedChanged);
            // 
            // GrowingTreeGroupBox
            // 
            this.GrowingTreeGroupBox.Controls.Add(this.GrowingTreeTreesNumericUpDown);
            this.GrowingTreeGroupBox.Controls.Add(this.GrowingTreeTreesLabel);
            this.GrowingTreeGroupBox.Controls.Add(this.GrowingTreeRunLogarithmicTrackBar);
            this.GrowingTreeGroupBox.Controls.Add(this.GrowingTreeRunLabel);
            this.GrowingTreeGroupBox.Controls.Add(this.GrowingTreeBraidLogarithmicTrackBar);
            this.GrowingTreeGroupBox.Controls.Add(this.GrowingTreeBraidLabel);
            this.GrowingTreeGroupBox.Controls.Add(this.BiasesGroupBox);
            this.GrowingTreeGroupBox.Controls.Add(this.GrowingTreeBreadthLogarithmicTrackBar);
            this.GrowingTreeGroupBox.Controls.Add(this.GrowingTreeBreadthLabel);
            this.GrowingTreeGroupBox.Location = new System.Drawing.Point(12, 229);
            this.GrowingTreeGroupBox.Name = "GrowingTreeGroupBox";
            this.GrowingTreeGroupBox.Size = new System.Drawing.Size(334, 583);
            this.GrowingTreeGroupBox.TabIndex = 19;
            this.GrowingTreeGroupBox.TabStop = false;
            this.GrowingTreeGroupBox.Text = "Growing tree settings";
            this.GrowingTreeGroupBox.Visible = false;
            // 
            // GrowingTreeRunLabel
            // 
            this.GrowingTreeRunLabel.AutoSize = true;
            this.GrowingTreeRunLabel.Location = new System.Drawing.Point(28, 135);
            this.GrowingTreeRunLabel.Name = "GrowingTreeRunLabel";
            this.GrowingTreeRunLabel.Size = new System.Drawing.Size(53, 13);
            this.GrowingTreeRunLabel.TabIndex = 19;
            this.GrowingTreeRunLabel.Text = "Run: 50%";
            // 
            // GrowingTreeBraidLabel
            // 
            this.GrowingTreeBraidLabel.AutoSize = true;
            this.GrowingTreeBraidLabel.Location = new System.Drawing.Point(28, 101);
            this.GrowingTreeBraidLabel.Name = "GrowingTreeBraidLabel";
            this.GrowingTreeBraidLabel.Size = new System.Drawing.Size(51, 13);
            this.GrowingTreeBraidLabel.TabIndex = 21;
            this.GrowingTreeBraidLabel.Text = "Braid: 0%";
            // 
            // BiasesGroupBox
            // 
            this.BiasesGroupBox.Location = new System.Drawing.Point(12, 176);
            this.BiasesGroupBox.Name = "BiasesGroupBox";
            this.BiasesGroupBox.Size = new System.Drawing.Size(310, 157);
            this.BiasesGroupBox.TabIndex = 23;
            this.BiasesGroupBox.TabStop = false;
            this.BiasesGroupBox.Text = "Biases";
            // 
            // GrowingTreeTreesLabel
            // 
            this.GrowingTreeTreesLabel.AutoSize = true;
            this.GrowingTreeTreesLabel.Location = new System.Drawing.Point(28, 31);
            this.GrowingTreeTreesLabel.Name = "GrowingTreeTreesLabel";
            this.GrowingTreeTreesLabel.Size = new System.Drawing.Size(37, 13);
            this.GrowingTreeTreesLabel.TabIndex = 24;
            this.GrowingTreeTreesLabel.Text = "Trees:";
            // 
            // GrowingTreeTreesNumericUpDown
            // 
            this.GrowingTreeTreesNumericUpDown.Location = new System.Drawing.Point(85, 29);
            this.GrowingTreeTreesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GrowingTreeTreesNumericUpDown.Name = "GrowingTreeTreesNumericUpDown";
            this.GrowingTreeTreesNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.GrowingTreeTreesNumericUpDown.TabIndex = 25;
            this.GrowingTreeTreesNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RecursiveDivisionGroupBox
            // 
            this.RecursiveDivisionGroupBox.Location = new System.Drawing.Point(355, 229);
            this.RecursiveDivisionGroupBox.Name = "RecursiveDivisionGroupBox";
            this.RecursiveDivisionGroupBox.Size = new System.Drawing.Size(334, 583);
            this.RecursiveDivisionGroupBox.TabIndex = 26;
            this.RecursiveDivisionGroupBox.TabStop = false;
            this.RecursiveDivisionGroupBox.Text = "Recursive division settings";
            this.RecursiveDivisionGroupBox.Visible = false;
            // 
            // GrowingTreeRunLogarithmicTrackBar
            // 
            this.GrowingTreeRunLogarithmicTrackBar.Location = new System.Drawing.Point(110, 135);
            this.GrowingTreeRunLogarithmicTrackBar.LogMaximum = 1D;
            this.GrowingTreeRunLogarithmicTrackBar.LogMiddle = 0.5D;
            this.GrowingTreeRunLogarithmicTrackBar.LogMinimum = 0D;
            this.GrowingTreeRunLogarithmicTrackBar.Maximum = 1000;
            this.GrowingTreeRunLogarithmicTrackBar.Name = "GrowingTreeRunLogarithmicTrackBar";
            this.GrowingTreeRunLogarithmicTrackBar.Size = new System.Drawing.Size(213, 45);
            this.GrowingTreeRunLogarithmicTrackBar.TabIndex = 20;
            this.GrowingTreeRunLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GrowingTreeRunLogarithmicTrackBar.Value = 500;
            this.GrowingTreeRunLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.GrowingTreeRunLogarithmicTrackBar_ValueChanged);
            // 
            // GrowingTreeBraidLogarithmicTrackBar
            // 
            this.GrowingTreeBraidLogarithmicTrackBar.Location = new System.Drawing.Point(110, 101);
            this.GrowingTreeBraidLogarithmicTrackBar.LogMaximum = 1D;
            this.GrowingTreeBraidLogarithmicTrackBar.LogMiddle = 0.5D;
            this.GrowingTreeBraidLogarithmicTrackBar.LogMinimum = 0D;
            this.GrowingTreeBraidLogarithmicTrackBar.Maximum = 1000;
            this.GrowingTreeBraidLogarithmicTrackBar.Name = "GrowingTreeBraidLogarithmicTrackBar";
            this.GrowingTreeBraidLogarithmicTrackBar.Size = new System.Drawing.Size(213, 45);
            this.GrowingTreeBraidLogarithmicTrackBar.TabIndex = 22;
            this.GrowingTreeBraidLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GrowingTreeBraidLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.GrowingTreeBraidLogarithmicTrackBar_ValueChanged);
            // 
            // GrowingTreeBreadthLogarithmicTrackBar
            // 
            this.GrowingTreeBreadthLogarithmicTrackBar.Location = new System.Drawing.Point(110, 68);
            this.GrowingTreeBreadthLogarithmicTrackBar.LogMaximum = 1D;
            this.GrowingTreeBreadthLogarithmicTrackBar.LogMiddle = 0.2D;
            this.GrowingTreeBreadthLogarithmicTrackBar.LogMinimum = 0D;
            this.GrowingTreeBreadthLogarithmicTrackBar.Maximum = 1000;
            this.GrowingTreeBreadthLogarithmicTrackBar.Name = "GrowingTreeBreadthLogarithmicTrackBar";
            this.GrowingTreeBreadthLogarithmicTrackBar.Size = new System.Drawing.Size(213, 45);
            this.GrowingTreeBreadthLogarithmicTrackBar.TabIndex = 18;
            this.GrowingTreeBreadthLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GrowingTreeBreadthLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.BreadthLogarithmicTrackBar_ValueChanged);
            // 
            // RendererDelayLogarithmicTrackBar
            // 
            this.RendererDelayLogarithmicTrackBar.Location = new System.Drawing.Point(137, 154);
            this.RendererDelayLogarithmicTrackBar.LogMaximum = 1000D;
            this.RendererDelayLogarithmicTrackBar.LogMiddle = 16D;
            this.RendererDelayLogarithmicTrackBar.LogMinimum = 0D;
            this.RendererDelayLogarithmicTrackBar.Maximum = 1000;
            this.RendererDelayLogarithmicTrackBar.Name = "RendererDelayLogarithmicTrackBar";
            this.RendererDelayLogarithmicTrackBar.Size = new System.Drawing.Size(210, 45);
            this.RendererDelayLogarithmicTrackBar.TabIndex = 15;
            this.RendererDelayLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RendererDelayLogarithmicTrackBar.Value = 500;
            this.RendererDelayLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.RendererDelayLogarithmicTrackBar_ValueChanged);
            // 
            // GeneratorDelayLogarithmicTrackBar
            // 
            this.GeneratorDelayLogarithmicTrackBar.Location = new System.Drawing.Point(137, 122);
            this.GeneratorDelayLogarithmicTrackBar.LogMaximum = 10000D;
            this.GeneratorDelayLogarithmicTrackBar.LogMiddle = 100D;
            this.GeneratorDelayLogarithmicTrackBar.LogMinimum = 0D;
            this.GeneratorDelayLogarithmicTrackBar.Maximum = 1000;
            this.GeneratorDelayLogarithmicTrackBar.Name = "GeneratorDelayLogarithmicTrackBar";
            this.GeneratorDelayLogarithmicTrackBar.Size = new System.Drawing.Size(213, 45);
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
            this.Controls.Add(this.RecursiveDivisionGroupBox);
            this.Controls.Add(this.AlgorithmComboBox);
            this.Controls.Add(this.GrowingTreeGroupBox);
            this.Controls.Add(this.TrackChangesCheckBox);
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
            this.Controls.Add(this.GenerateButton);
            this.Controls.Add(this.MainPictureBox);
            this.Name = "MainForm";
            this.Text = "Maze generator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.GrowingTreeGroupBox.ResumeLayout(false);
            this.GrowingTreeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeTreesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeRunLogarithmicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBraidLogarithmicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBreadthLogarithmicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RendererDelayLogarithmicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneratorDelayLogarithmicTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.ComboBox AlgorithmComboBox;
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
        private System.Windows.Forms.CheckBox TrackChangesCheckBox;
        private System.Windows.Forms.Label GrowingTreeBreadthLabel;
        private LogarithmicTrackBar GrowingTreeBreadthLogarithmicTrackBar;
        private System.Windows.Forms.GroupBox GrowingTreeGroupBox;
        private LogarithmicTrackBar GrowingTreeRunLogarithmicTrackBar;
        private System.Windows.Forms.Label GrowingTreeRunLabel;
        private LogarithmicTrackBar GrowingTreeBraidLogarithmicTrackBar;
        private System.Windows.Forms.Label GrowingTreeBraidLabel;
        private System.Windows.Forms.GroupBox BiasesGroupBox;
        private System.Windows.Forms.NumericUpDown GrowingTreeTreesNumericUpDown;
        private System.Windows.Forms.Label GrowingTreeTreesLabel;
        private System.Windows.Forms.GroupBox RecursiveDivisionGroupBox;
    }
}

