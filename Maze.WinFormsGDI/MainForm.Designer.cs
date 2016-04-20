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
            this.GeneratorDelayTextBox = new System.Windows.Forms.TextBox();
            this.GeneratorDelayLabel = new System.Windows.Forms.Label();
            this.RendererDelayTextBox = new System.Windows.Forms.TextBox();
            this.RendererDelayLabel = new System.Windows.Forms.Label();
            this.InfiniteMapCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.BackColor = System.Drawing.Color.Black;
            this.MainPictureBox.Location = new System.Drawing.Point(246, 4);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(900, 900);
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(13, 15);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(216, 28);
            this.GenerateButton.TabIndex = 1;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // AlgorithmComboBox
            // 
            this.AlgorithmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlgorithmComboBox.FormattingEnabled = true;
            this.AlgorithmComboBox.Location = new System.Drawing.Point(73, 61);
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
            this.AlgorithmLabel.Location = new System.Drawing.Point(14, 64);
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
            this.WidthTextBox.Size = new System.Drawing.Size(52, 20);
            this.WidthTextBox.TabIndex = 6;
            this.WidthTextBox.Text = "21";
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(177, 94);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(52, 20);
            this.HeightTextBox.TabIndex = 8;
            this.HeightTextBox.Text = "21";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(133, 97);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(41, 13);
            this.HeightLabel.TabIndex = 7;
            this.HeightLabel.Text = "Height:";
            // 
            // GeneratorDelayTextBox
            // 
            this.GeneratorDelayTextBox.Location = new System.Drawing.Point(101, 159);
            this.GeneratorDelayTextBox.Name = "GeneratorDelayTextBox";
            this.GeneratorDelayTextBox.Size = new System.Drawing.Size(52, 20);
            this.GeneratorDelayTextBox.TabIndex = 10;
            this.GeneratorDelayTextBox.Text = "100";
            this.GeneratorDelayTextBox.TextChanged += new System.EventHandler(this.GeneratorDelayTextBox_TextChanged);
            // 
            // GeneratorDelayLabel
            // 
            this.GeneratorDelayLabel.AutoSize = true;
            this.GeneratorDelayLabel.Location = new System.Drawing.Point(10, 162);
            this.GeneratorDelayLabel.Name = "GeneratorDelayLabel";
            this.GeneratorDelayLabel.Size = new System.Drawing.Size(85, 13);
            this.GeneratorDelayLabel.TabIndex = 9;
            this.GeneratorDelayLabel.Text = "Generator delay:";
            // 
            // RendererDelayTextBox
            // 
            this.RendererDelayTextBox.Location = new System.Drawing.Point(101, 185);
            this.RendererDelayTextBox.Name = "RendererDelayTextBox";
            this.RendererDelayTextBox.Size = new System.Drawing.Size(52, 20);
            this.RendererDelayTextBox.TabIndex = 12;
            this.RendererDelayTextBox.Text = "16";
            this.RendererDelayTextBox.TextChanged += new System.EventHandler(this.RendererDelayTextBox_TextChanged);
            // 
            // RendererDelayLabel
            // 
            this.RendererDelayLabel.AutoSize = true;
            this.RendererDelayLabel.Location = new System.Drawing.Point(10, 188);
            this.RendererDelayLabel.Name = "RendererDelayLabel";
            this.RendererDelayLabel.Size = new System.Drawing.Size(82, 13);
            this.RendererDelayLabel.TabIndex = 11;
            this.RendererDelayLabel.Text = "Renderer delay:";
            // 
            // InfiniteMapCheckBox
            // 
            this.InfiniteMapCheckBox.AutoSize = true;
            this.InfiniteMapCheckBox.Location = new System.Drawing.Point(20, 125);
            this.InfiniteMapCheckBox.Name = "InfiniteMapCheckBox";
            this.InfiniteMapCheckBox.Size = new System.Drawing.Size(80, 17);
            this.InfiniteMapCheckBox.TabIndex = 13;
            this.InfiniteMapCheckBox.Text = "Infinite map";
            this.InfiniteMapCheckBox.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 911);
            this.Controls.Add(this.InfiniteMapCheckBox);
            this.Controls.Add(this.RendererDelayTextBox);
            this.Controls.Add(this.RendererDelayLabel);
            this.Controls.Add(this.GeneratorDelayTextBox);
            this.Controls.Add(this.GeneratorDelayLabel);
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
        private System.Windows.Forms.TextBox GeneratorDelayTextBox;
        private System.Windows.Forms.Label GeneratorDelayLabel;
        private System.Windows.Forms.TextBox RendererDelayTextBox;
        private System.Windows.Forms.Label RendererDelayLabel;
        private System.Windows.Forms.CheckBox InfiniteMapCheckBox;
    }
}

