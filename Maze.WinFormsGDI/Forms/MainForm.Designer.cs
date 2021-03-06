﻿using Maze.WinFormsGDI.Controls;

namespace Maze.WinFormsGDI.Forms
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
            this.GrowingTreeSparsenessNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GrowingTreeSparsenessLabel = new System.Windows.Forms.Label();
            this.GrowingTreeTreesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GrowingTreeTreesLabel = new System.Windows.Forms.Label();
            this.GrowingTreeRunLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.GrowingTreeRunLabel = new System.Windows.Forms.Label();
            this.GrowingTreeBraidLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.GrowingTreeBraidLabel = new System.Windows.Forms.Label();
            this.BiasesGroupBox = new System.Windows.Forms.GroupBox();
            this.GrowingTreeResetBiasesButton = new System.Windows.Forms.Button();
            this.arrowCrossShape1 = new Maze.WinFormsGDI.Controls.ArrowCrossShape();
            this.GrowingTreeBiasDownLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.GrowingTreeBiasRightLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.GrowingTreeBiasLeftLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.GrowingTreeBiasUpLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.GrowingTreeBreadthLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.RecursiveDivisionGroupBox = new System.Windows.Forms.GroupBox();
            this.RecursiveDivisionShowInitializationStepCheckBox = new System.Windows.Forms.CheckBox();
            this.RecursiveDivisionProcessSingleCellBlocksCheckBox = new System.Windows.Forms.CheckBox();
            this.RecursiveDivisionReverseOrderLabel = new System.Windows.Forms.Label();
            this.RecursiveDivisionReverseOrderLTB = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.RecursiveDivisionProportionalSplitsLabel = new System.Windows.Forms.Label();
            this.RecursiveDivisionProportionalSplitsLTB = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.RecursiveDivisionSplitLocationLabel = new System.Windows.Forms.Label();
            this.RecursiveDivisionSplitLocationLTB = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.RecursiveDivisionFixedSplitsLabel = new System.Windows.Forms.Label();
            this.RecursiveDivisionFixedSplitsLTB = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.RecursiveDivisionRecursionLocationLabel = new System.Windows.Forms.Label();
            this.RecursiveDivisionRecursionLocationLTB = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.RecursiveDivisionFixedRecursionLabel = new System.Windows.Forms.Label();
            this.RecursiveDivisionFixedRecursionLTB = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.ShowAdvancedSettingsCheckBox = new System.Windows.Forms.CheckBox();
            this.KruskalGroupBox = new System.Windows.Forms.GroupBox();
            this.KruskalShowAllWallCheckingCheckBox = new System.Windows.Forms.CheckBox();
            this.KruskalBraidLTB = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.KruskalBraidLabel = new System.Windows.Forms.Label();
            this.BinaryTreeGroupBox = new System.Windows.Forms.GroupBox();
            this.BinaryTreeBiasLTB = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.BinaryTreeBiasLabel = new System.Windows.Forms.Label();
            this.BinaryTreeSidewinderLTB = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.BinaryTreeSidewinderLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.RendererDelayLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            this.GeneratorDelayLogarithmicTrackBar = new Maze.WinFormsGDI.Controls.LogarithmicTrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.GrowingTreeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeSparsenessNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeTreesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeRunLogarithmicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBraidLogarithmicTrackBar)).BeginInit();
            this.BiasesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBiasDownLogarithmicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBiasRightLogarithmicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBiasLeftLogarithmicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBiasUpLogarithmicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBreadthLogarithmicTrackBar)).BeginInit();
            this.RecursiveDivisionGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecursiveDivisionReverseOrderLTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecursiveDivisionProportionalSplitsLTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecursiveDivisionSplitLocationLTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecursiveDivisionFixedSplitsLTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecursiveDivisionRecursionLocationLTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecursiveDivisionFixedRecursionLTB)).BeginInit();
            this.KruskalGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KruskalBraidLTB)).BeginInit();
            this.BinaryTreeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryTreeBiasLTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryTreeSidewinderLTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RendererDelayLogarithmicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GeneratorDelayLogarithmicTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPictureBox.BackColor = System.Drawing.Color.Black;
            this.MainPictureBox.Location = new System.Drawing.Point(358, 0);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(899, 900);
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
            this.AlgorithmComboBox.Size = new System.Drawing.Size(145, 21);
            this.AlgorithmComboBox.TabIndex = 2;
            this.AlgorithmComboBox.SelectedIndexChanged += new System.EventHandler(this.SyncGroupBoxes);
            // 
            // GrowingTreeBreadthLabel
            // 
            this.GrowingTreeBreadthLabel.AutoSize = true;
            this.GrowingTreeBreadthLabel.Location = new System.Drawing.Point(28, 94);
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
            this.GrowingTreeGroupBox.Controls.Add(this.GrowingTreeSparsenessNumericUpDown);
            this.GrowingTreeGroupBox.Controls.Add(this.GrowingTreeSparsenessLabel);
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
            this.GrowingTreeGroupBox.Size = new System.Drawing.Size(334, 379);
            this.GrowingTreeGroupBox.TabIndex = 19;
            this.GrowingTreeGroupBox.TabStop = false;
            this.GrowingTreeGroupBox.Text = "Growing tree settings";
            this.GrowingTreeGroupBox.Visible = false;
            // 
            // GrowingTreeSparsenessNumericUpDown
            // 
            this.GrowingTreeSparsenessNumericUpDown.Location = new System.Drawing.Point(146, 56);
            this.GrowingTreeSparsenessNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.GrowingTreeSparsenessNumericUpDown.Name = "GrowingTreeSparsenessNumericUpDown";
            this.GrowingTreeSparsenessNumericUpDown.Size = new System.Drawing.Size(88, 20);
            this.GrowingTreeSparsenessNumericUpDown.TabIndex = 27;
            this.GrowingTreeSparsenessNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.GrowingTreeSparsenessNumericUpDown.ValueChanged += new System.EventHandler(this.SyncGrowingTreeParameters);
            // 
            // GrowingTreeSparsenessLabel
            // 
            this.GrowingTreeSparsenessLabel.AutoSize = true;
            this.GrowingTreeSparsenessLabel.Location = new System.Drawing.Point(70, 58);
            this.GrowingTreeSparsenessLabel.Name = "GrowingTreeSparsenessLabel";
            this.GrowingTreeSparsenessLabel.Size = new System.Drawing.Size(65, 13);
            this.GrowingTreeSparsenessLabel.TabIndex = 26;
            this.GrowingTreeSparsenessLabel.Text = "Sparseness:";
            // 
            // GrowingTreeTreesNumericUpDown
            // 
            this.GrowingTreeTreesNumericUpDown.Location = new System.Drawing.Point(146, 30);
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
            this.GrowingTreeTreesNumericUpDown.ValueChanged += new System.EventHandler(this.SyncGrowingTreeParameters);
            // 
            // GrowingTreeTreesLabel
            // 
            this.GrowingTreeTreesLabel.AutoSize = true;
            this.GrowingTreeTreesLabel.Location = new System.Drawing.Point(89, 32);
            this.GrowingTreeTreesLabel.Name = "GrowingTreeTreesLabel";
            this.GrowingTreeTreesLabel.Size = new System.Drawing.Size(37, 13);
            this.GrowingTreeTreesLabel.TabIndex = 24;
            this.GrowingTreeTreesLabel.Text = "Trees:";
            // 
            // GrowingTreeRunLogarithmicTrackBar
            // 
            this.GrowingTreeRunLogarithmicTrackBar.Location = new System.Drawing.Point(110, 161);
            this.GrowingTreeRunLogarithmicTrackBar.LogMaximum = 1D;
            this.GrowingTreeRunLogarithmicTrackBar.LogMiddle = 0.5D;
            this.GrowingTreeRunLogarithmicTrackBar.LogMinimum = 0D;
            this.GrowingTreeRunLogarithmicTrackBar.Maximum = 1000;
            this.GrowingTreeRunLogarithmicTrackBar.Name = "GrowingTreeRunLogarithmicTrackBar";
            this.GrowingTreeRunLogarithmicTrackBar.Size = new System.Drawing.Size(213, 45);
            this.GrowingTreeRunLogarithmicTrackBar.TabIndex = 20;
            this.GrowingTreeRunLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GrowingTreeRunLogarithmicTrackBar.Value = 500;
            this.GrowingTreeRunLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.SyncGrowingTreeParameters);
            // 
            // GrowingTreeRunLabel
            // 
            this.GrowingTreeRunLabel.AutoSize = true;
            this.GrowingTreeRunLabel.Location = new System.Drawing.Point(28, 161);
            this.GrowingTreeRunLabel.Name = "GrowingTreeRunLabel";
            this.GrowingTreeRunLabel.Size = new System.Drawing.Size(53, 13);
            this.GrowingTreeRunLabel.TabIndex = 19;
            this.GrowingTreeRunLabel.Text = "Run: 50%";
            // 
            // GrowingTreeBraidLogarithmicTrackBar
            // 
            this.GrowingTreeBraidLogarithmicTrackBar.Location = new System.Drawing.Point(110, 127);
            this.GrowingTreeBraidLogarithmicTrackBar.LogMaximum = 1D;
            this.GrowingTreeBraidLogarithmicTrackBar.LogMiddle = 0.5D;
            this.GrowingTreeBraidLogarithmicTrackBar.LogMinimum = 0D;
            this.GrowingTreeBraidLogarithmicTrackBar.Maximum = 1000;
            this.GrowingTreeBraidLogarithmicTrackBar.Name = "GrowingTreeBraidLogarithmicTrackBar";
            this.GrowingTreeBraidLogarithmicTrackBar.Size = new System.Drawing.Size(213, 45);
            this.GrowingTreeBraidLogarithmicTrackBar.TabIndex = 22;
            this.GrowingTreeBraidLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GrowingTreeBraidLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.SyncGrowingTreeParameters);
            // 
            // GrowingTreeBraidLabel
            // 
            this.GrowingTreeBraidLabel.AutoSize = true;
            this.GrowingTreeBraidLabel.Location = new System.Drawing.Point(28, 127);
            this.GrowingTreeBraidLabel.Name = "GrowingTreeBraidLabel";
            this.GrowingTreeBraidLabel.Size = new System.Drawing.Size(51, 13);
            this.GrowingTreeBraidLabel.TabIndex = 21;
            this.GrowingTreeBraidLabel.Text = "Braid: 0%";
            // 
            // BiasesGroupBox
            // 
            this.BiasesGroupBox.Controls.Add(this.GrowingTreeResetBiasesButton);
            this.BiasesGroupBox.Controls.Add(this.arrowCrossShape1);
            this.BiasesGroupBox.Controls.Add(this.GrowingTreeBiasDownLogarithmicTrackBar);
            this.BiasesGroupBox.Controls.Add(this.GrowingTreeBiasRightLogarithmicTrackBar);
            this.BiasesGroupBox.Controls.Add(this.GrowingTreeBiasLeftLogarithmicTrackBar);
            this.BiasesGroupBox.Controls.Add(this.GrowingTreeBiasUpLogarithmicTrackBar);
            this.BiasesGroupBox.Location = new System.Drawing.Point(12, 202);
            this.BiasesGroupBox.Name = "BiasesGroupBox";
            this.BiasesGroupBox.Size = new System.Drawing.Size(310, 165);
            this.BiasesGroupBox.TabIndex = 23;
            this.BiasesGroupBox.TabStop = false;
            this.BiasesGroupBox.Text = "Biases";
            // 
            // GrowingTreeResetBiasesButton
            // 
            this.GrowingTreeResetBiasesButton.Location = new System.Drawing.Point(100, 133);
            this.GrowingTreeResetBiasesButton.Name = "GrowingTreeResetBiasesButton";
            this.GrowingTreeResetBiasesButton.Size = new System.Drawing.Size(116, 23);
            this.GrowingTreeResetBiasesButton.TabIndex = 30;
            this.GrowingTreeResetBiasesButton.Text = "Reset biases";
            this.GrowingTreeResetBiasesButton.UseVisualStyleBackColor = true;
            this.GrowingTreeResetBiasesButton.Click += new System.EventHandler(this.GrowingTreeResetBiasesButton_Click);
            // 
            // arrowCrossShape1
            // 
            this.arrowCrossShape1.Location = new System.Drawing.Point(134, 43);
            this.arrowCrossShape1.Name = "arrowCrossShape1";
            this.arrowCrossShape1.Polygon = new System.Drawing.Point[] {
        new System.Drawing.Point(7, 2),
        new System.Drawing.Point(6, 2),
        new System.Drawing.Point(6, 4),
        new System.Drawing.Point(8, 4),
        new System.Drawing.Point(8, 3),
        new System.Drawing.Point(10, 5),
        new System.Drawing.Point(8, 7),
        new System.Drawing.Point(8, 6),
        new System.Drawing.Point(6, 6),
        new System.Drawing.Point(6, 8),
        new System.Drawing.Point(7, 8),
        new System.Drawing.Point(5, 10),
        new System.Drawing.Point(3, 8),
        new System.Drawing.Point(4, 8),
        new System.Drawing.Point(4, 6),
        new System.Drawing.Point(2, 6),
        new System.Drawing.Point(2, 7),
        new System.Drawing.Point(0, 5),
        new System.Drawing.Point(2, 3),
        new System.Drawing.Point(2, 4),
        new System.Drawing.Point(4, 4),
        new System.Drawing.Point(4, 2),
        new System.Drawing.Point(3, 2),
        new System.Drawing.Point(5, 0)};
            this.arrowCrossShape1.PolygonColor = System.Drawing.SystemColors.ControlDark;
            this.arrowCrossShape1.PolygonSize = 10;
            this.arrowCrossShape1.Size = new System.Drawing.Size(51, 55);
            this.arrowCrossShape1.TabIndex = 26;
            // 
            // GrowingTreeBiasDownLogarithmicTrackBar
            // 
            this.GrowingTreeBiasDownLogarithmicTrackBar.Location = new System.Drawing.Point(98, 101);
            this.GrowingTreeBiasDownLogarithmicTrackBar.LogMaximum = 1D;
            this.GrowingTreeBiasDownLogarithmicTrackBar.LogMiddle = 0.5D;
            this.GrowingTreeBiasDownLogarithmicTrackBar.LogMinimum = 0D;
            this.GrowingTreeBiasDownLogarithmicTrackBar.Maximum = 1000;
            this.GrowingTreeBiasDownLogarithmicTrackBar.Name = "GrowingTreeBiasDownLogarithmicTrackBar";
            this.GrowingTreeBiasDownLogarithmicTrackBar.Size = new System.Drawing.Size(122, 45);
            this.GrowingTreeBiasDownLogarithmicTrackBar.TabIndex = 29;
            this.GrowingTreeBiasDownLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GrowingTreeBiasDownLogarithmicTrackBar.Value = 500;
            this.GrowingTreeBiasDownLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.SyncGrowingTreeParameters);
            // 
            // GrowingTreeBiasRightLogarithmicTrackBar
            // 
            this.GrowingTreeBiasRightLogarithmicTrackBar.Location = new System.Drawing.Point(186, 61);
            this.GrowingTreeBiasRightLogarithmicTrackBar.LogMaximum = 1D;
            this.GrowingTreeBiasRightLogarithmicTrackBar.LogMiddle = 0.5D;
            this.GrowingTreeBiasRightLogarithmicTrackBar.LogMinimum = 0D;
            this.GrowingTreeBiasRightLogarithmicTrackBar.Maximum = 1000;
            this.GrowingTreeBiasRightLogarithmicTrackBar.Name = "GrowingTreeBiasRightLogarithmicTrackBar";
            this.GrowingTreeBiasRightLogarithmicTrackBar.Size = new System.Drawing.Size(122, 45);
            this.GrowingTreeBiasRightLogarithmicTrackBar.TabIndex = 28;
            this.GrowingTreeBiasRightLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GrowingTreeBiasRightLogarithmicTrackBar.Value = 500;
            this.GrowingTreeBiasRightLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.SyncGrowingTreeParameters);
            // 
            // GrowingTreeBiasLeftLogarithmicTrackBar
            // 
            this.GrowingTreeBiasLeftLogarithmicTrackBar.Location = new System.Drawing.Point(10, 61);
            this.GrowingTreeBiasLeftLogarithmicTrackBar.LogMaximum = 1D;
            this.GrowingTreeBiasLeftLogarithmicTrackBar.LogMiddle = 0.5D;
            this.GrowingTreeBiasLeftLogarithmicTrackBar.LogMinimum = 0D;
            this.GrowingTreeBiasLeftLogarithmicTrackBar.Maximum = 1000;
            this.GrowingTreeBiasLeftLogarithmicTrackBar.Name = "GrowingTreeBiasLeftLogarithmicTrackBar";
            this.GrowingTreeBiasLeftLogarithmicTrackBar.Size = new System.Drawing.Size(122, 45);
            this.GrowingTreeBiasLeftLogarithmicTrackBar.TabIndex = 27;
            this.GrowingTreeBiasLeftLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GrowingTreeBiasLeftLogarithmicTrackBar.Value = 500;
            this.GrowingTreeBiasLeftLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.SyncGrowingTreeParameters);
            // 
            // GrowingTreeBiasUpLogarithmicTrackBar
            // 
            this.GrowingTreeBiasUpLogarithmicTrackBar.Location = new System.Drawing.Point(98, 19);
            this.GrowingTreeBiasUpLogarithmicTrackBar.LogMaximum = 1D;
            this.GrowingTreeBiasUpLogarithmicTrackBar.LogMiddle = 0.5D;
            this.GrowingTreeBiasUpLogarithmicTrackBar.LogMinimum = 0D;
            this.GrowingTreeBiasUpLogarithmicTrackBar.Maximum = 1000;
            this.GrowingTreeBiasUpLogarithmicTrackBar.Name = "GrowingTreeBiasUpLogarithmicTrackBar";
            this.GrowingTreeBiasUpLogarithmicTrackBar.Size = new System.Drawing.Size(122, 45);
            this.GrowingTreeBiasUpLogarithmicTrackBar.TabIndex = 26;
            this.GrowingTreeBiasUpLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GrowingTreeBiasUpLogarithmicTrackBar.Value = 500;
            this.GrowingTreeBiasUpLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.SyncGrowingTreeParameters);
            // 
            // GrowingTreeBreadthLogarithmicTrackBar
            // 
            this.GrowingTreeBreadthLogarithmicTrackBar.Location = new System.Drawing.Point(110, 94);
            this.GrowingTreeBreadthLogarithmicTrackBar.LogMaximum = 1D;
            this.GrowingTreeBreadthLogarithmicTrackBar.LogMiddle = 0.2D;
            this.GrowingTreeBreadthLogarithmicTrackBar.LogMinimum = 0D;
            this.GrowingTreeBreadthLogarithmicTrackBar.Maximum = 1000;
            this.GrowingTreeBreadthLogarithmicTrackBar.Name = "GrowingTreeBreadthLogarithmicTrackBar";
            this.GrowingTreeBreadthLogarithmicTrackBar.Size = new System.Drawing.Size(213, 45);
            this.GrowingTreeBreadthLogarithmicTrackBar.TabIndex = 18;
            this.GrowingTreeBreadthLogarithmicTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.GrowingTreeBreadthLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.SyncGrowingTreeParameters);
            // 
            // RecursiveDivisionGroupBox
            // 
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionShowInitializationStepCheckBox);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionProcessSingleCellBlocksCheckBox);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionReverseOrderLabel);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionReverseOrderLTB);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionProportionalSplitsLabel);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionProportionalSplitsLTB);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionSplitLocationLabel);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionSplitLocationLTB);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionFixedSplitsLabel);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionFixedSplitsLTB);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionRecursionLocationLabel);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionRecursionLocationLTB);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionFixedRecursionLabel);
            this.RecursiveDivisionGroupBox.Controls.Add(this.RecursiveDivisionFixedRecursionLTB);
            this.RecursiveDivisionGroupBox.Location = new System.Drawing.Point(358, 6);
            this.RecursiveDivisionGroupBox.Name = "RecursiveDivisionGroupBox";
            this.RecursiveDivisionGroupBox.Size = new System.Drawing.Size(334, 363);
            this.RecursiveDivisionGroupBox.TabIndex = 26;
            this.RecursiveDivisionGroupBox.TabStop = false;
            this.RecursiveDivisionGroupBox.Text = "Recursive division settings";
            this.RecursiveDivisionGroupBox.Visible = false;
            // 
            // RecursiveDivisionShowInitializationStepCheckBox
            // 
            this.RecursiveDivisionShowInitializationStepCheckBox.AutoSize = true;
            this.RecursiveDivisionShowInitializationStepCheckBox.Checked = true;
            this.RecursiveDivisionShowInitializationStepCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RecursiveDivisionShowInitializationStepCheckBox.Location = new System.Drawing.Point(23, 328);
            this.RecursiveDivisionShowInitializationStepCheckBox.Name = "RecursiveDivisionShowInitializationStepCheckBox";
            this.RecursiveDivisionShowInitializationStepCheckBox.Size = new System.Drawing.Size(132, 17);
            this.RecursiveDivisionShowInitializationStepCheckBox.TabIndex = 40;
            this.RecursiveDivisionShowInitializationStepCheckBox.Text = "Show initialization step";
            this.RecursiveDivisionShowInitializationStepCheckBox.UseVisualStyleBackColor = true;
            this.RecursiveDivisionShowInitializationStepCheckBox.CheckedChanged += new System.EventHandler(this.SyncRecursiveDivisionParameters);
            // 
            // RecursiveDivisionProcessSingleCellBlocksCheckBox
            // 
            this.RecursiveDivisionProcessSingleCellBlocksCheckBox.AutoSize = true;
            this.RecursiveDivisionProcessSingleCellBlocksCheckBox.Location = new System.Drawing.Point(23, 304);
            this.RecursiveDivisionProcessSingleCellBlocksCheckBox.Name = "RecursiveDivisionProcessSingleCellBlocksCheckBox";
            this.RecursiveDivisionProcessSingleCellBlocksCheckBox.Size = new System.Drawing.Size(147, 17);
            this.RecursiveDivisionProcessSingleCellBlocksCheckBox.TabIndex = 28;
            this.RecursiveDivisionProcessSingleCellBlocksCheckBox.Text = "Process single cell blocks";
            this.RecursiveDivisionProcessSingleCellBlocksCheckBox.UseVisualStyleBackColor = true;
            this.RecursiveDivisionProcessSingleCellBlocksCheckBox.CheckedChanged += new System.EventHandler(this.SyncRecursiveDivisionParameters);
            // 
            // RecursiveDivisionReverseOrderLabel
            // 
            this.RecursiveDivisionReverseOrderLabel.AutoSize = true;
            this.RecursiveDivisionReverseOrderLabel.Location = new System.Drawing.Point(21, 254);
            this.RecursiveDivisionReverseOrderLabel.Name = "RecursiveDivisionReverseOrderLabel";
            this.RecursiveDivisionReverseOrderLabel.Size = new System.Drawing.Size(94, 13);
            this.RecursiveDivisionReverseOrderLabel.TabIndex = 38;
            this.RecursiveDivisionReverseOrderLabel.Text = "Reverse order: 0%";
            // 
            // RecursiveDivisionReverseOrderLTB
            // 
            this.RecursiveDivisionReverseOrderLTB.Location = new System.Drawing.Point(142, 254);
            this.RecursiveDivisionReverseOrderLTB.LogMaximum = 1D;
            this.RecursiveDivisionReverseOrderLTB.LogMiddle = 0.5D;
            this.RecursiveDivisionReverseOrderLTB.LogMinimum = 0D;
            this.RecursiveDivisionReverseOrderLTB.Maximum = 1000;
            this.RecursiveDivisionReverseOrderLTB.Name = "RecursiveDivisionReverseOrderLTB";
            this.RecursiveDivisionReverseOrderLTB.Size = new System.Drawing.Size(174, 45);
            this.RecursiveDivisionReverseOrderLTB.TabIndex = 39;
            this.RecursiveDivisionReverseOrderLTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RecursiveDivisionReverseOrderLTB.ValueChanged += new System.EventHandler(this.SyncRecursiveDivisionParameters);
            // 
            // RecursiveDivisionProportionalSplitsLabel
            // 
            this.RecursiveDivisionProportionalSplitsLabel.AutoSize = true;
            this.RecursiveDivisionProportionalSplitsLabel.Location = new System.Drawing.Point(21, 203);
            this.RecursiveDivisionProportionalSplitsLabel.Name = "RecursiveDivisionProportionalSplitsLabel";
            this.RecursiveDivisionProportionalSplitsLabel.Size = new System.Drawing.Size(109, 13);
            this.RecursiveDivisionProportionalSplitsLabel.TabIndex = 36;
            this.RecursiveDivisionProportionalSplitsLabel.Text = "Proportional splits: 0%";
            // 
            // RecursiveDivisionProportionalSplitsLTB
            // 
            this.RecursiveDivisionProportionalSplitsLTB.Location = new System.Drawing.Point(142, 203);
            this.RecursiveDivisionProportionalSplitsLTB.LogMaximum = 1D;
            this.RecursiveDivisionProportionalSplitsLTB.LogMiddle = 0.5D;
            this.RecursiveDivisionProportionalSplitsLTB.LogMinimum = 0D;
            this.RecursiveDivisionProportionalSplitsLTB.Maximum = 1000;
            this.RecursiveDivisionProportionalSplitsLTB.Name = "RecursiveDivisionProportionalSplitsLTB";
            this.RecursiveDivisionProportionalSplitsLTB.Size = new System.Drawing.Size(174, 45);
            this.RecursiveDivisionProportionalSplitsLTB.TabIndex = 37;
            this.RecursiveDivisionProportionalSplitsLTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RecursiveDivisionProportionalSplitsLTB.Value = 1000;
            this.RecursiveDivisionProportionalSplitsLTB.ValueChanged += new System.EventHandler(this.SyncRecursiveDivisionParameters);
            // 
            // RecursiveDivisionSplitLocationLabel
            // 
            this.RecursiveDivisionSplitLocationLabel.AutoSize = true;
            this.RecursiveDivisionSplitLocationLabel.Location = new System.Drawing.Point(20, 152);
            this.RecursiveDivisionSplitLocationLabel.Name = "RecursiveDivisionSplitLocationLabel";
            this.RecursiveDivisionSplitLocationLabel.Size = new System.Drawing.Size(87, 13);
            this.RecursiveDivisionSplitLocationLabel.TabIndex = 34;
            this.RecursiveDivisionSplitLocationLabel.Text = "Split location: 0%";
            // 
            // RecursiveDivisionSplitLocationLTB
            // 
            this.RecursiveDivisionSplitLocationLTB.Location = new System.Drawing.Point(141, 152);
            this.RecursiveDivisionSplitLocationLTB.LogMaximum = 1D;
            this.RecursiveDivisionSplitLocationLTB.LogMiddle = 0.5D;
            this.RecursiveDivisionSplitLocationLTB.LogMinimum = 0D;
            this.RecursiveDivisionSplitLocationLTB.Maximum = 1000;
            this.RecursiveDivisionSplitLocationLTB.Name = "RecursiveDivisionSplitLocationLTB";
            this.RecursiveDivisionSplitLocationLTB.Size = new System.Drawing.Size(174, 45);
            this.RecursiveDivisionSplitLocationLTB.TabIndex = 35;
            this.RecursiveDivisionSplitLocationLTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RecursiveDivisionSplitLocationLTB.Value = 500;
            this.RecursiveDivisionSplitLocationLTB.ValueChanged += new System.EventHandler(this.SyncRecursiveDivisionParameters);
            // 
            // RecursiveDivisionFixedSplitsLabel
            // 
            this.RecursiveDivisionFixedSplitsLabel.AutoSize = true;
            this.RecursiveDivisionFixedSplitsLabel.Location = new System.Drawing.Point(20, 119);
            this.RecursiveDivisionFixedSplitsLabel.Name = "RecursiveDivisionFixedSplitsLabel";
            this.RecursiveDivisionFixedSplitsLabel.Size = new System.Drawing.Size(78, 13);
            this.RecursiveDivisionFixedSplitsLabel.TabIndex = 32;
            this.RecursiveDivisionFixedSplitsLabel.Text = "Fixed splits: 0%";
            // 
            // RecursiveDivisionFixedSplitsLTB
            // 
            this.RecursiveDivisionFixedSplitsLTB.Location = new System.Drawing.Point(141, 119);
            this.RecursiveDivisionFixedSplitsLTB.LogMaximum = 1D;
            this.RecursiveDivisionFixedSplitsLTB.LogMiddle = 0.2D;
            this.RecursiveDivisionFixedSplitsLTB.LogMinimum = 0D;
            this.RecursiveDivisionFixedSplitsLTB.Maximum = 1000;
            this.RecursiveDivisionFixedSplitsLTB.Name = "RecursiveDivisionFixedSplitsLTB";
            this.RecursiveDivisionFixedSplitsLTB.Size = new System.Drawing.Size(174, 45);
            this.RecursiveDivisionFixedSplitsLTB.TabIndex = 33;
            this.RecursiveDivisionFixedSplitsLTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RecursiveDivisionFixedSplitsLTB.ValueChanged += new System.EventHandler(this.SyncRecursiveDivisionParameters);
            // 
            // RecursiveDivisionRecursionLocationLabel
            // 
            this.RecursiveDivisionRecursionLocationLabel.AutoSize = true;
            this.RecursiveDivisionRecursionLocationLabel.Location = new System.Drawing.Point(20, 68);
            this.RecursiveDivisionRecursionLocationLabel.Name = "RecursiveDivisionRecursionLocationLabel";
            this.RecursiveDivisionRecursionLocationLabel.Size = new System.Drawing.Size(115, 13);
            this.RecursiveDivisionRecursionLocationLabel.TabIndex = 30;
            this.RecursiveDivisionRecursionLocationLabel.Text = "Recursion location: 0%";
            // 
            // RecursiveDivisionRecursionLocationLTB
            // 
            this.RecursiveDivisionRecursionLocationLTB.Location = new System.Drawing.Point(141, 68);
            this.RecursiveDivisionRecursionLocationLTB.LogMaximum = 1D;
            this.RecursiveDivisionRecursionLocationLTB.LogMiddle = 0.5D;
            this.RecursiveDivisionRecursionLocationLTB.LogMinimum = 0D;
            this.RecursiveDivisionRecursionLocationLTB.Maximum = 1000;
            this.RecursiveDivisionRecursionLocationLTB.Name = "RecursiveDivisionRecursionLocationLTB";
            this.RecursiveDivisionRecursionLocationLTB.Size = new System.Drawing.Size(174, 45);
            this.RecursiveDivisionRecursionLocationLTB.TabIndex = 31;
            this.RecursiveDivisionRecursionLocationLTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RecursiveDivisionRecursionLocationLTB.Value = 1000;
            this.RecursiveDivisionRecursionLocationLTB.ValueChanged += new System.EventHandler(this.SyncRecursiveDivisionParameters);
            // 
            // RecursiveDivisionFixedRecursionLabel
            // 
            this.RecursiveDivisionFixedRecursionLabel.AutoSize = true;
            this.RecursiveDivisionFixedRecursionLabel.Location = new System.Drawing.Point(20, 35);
            this.RecursiveDivisionFixedRecursionLabel.Name = "RecursiveDivisionFixedRecursionLabel";
            this.RecursiveDivisionFixedRecursionLabel.Size = new System.Drawing.Size(98, 13);
            this.RecursiveDivisionFixedRecursionLabel.TabIndex = 28;
            this.RecursiveDivisionFixedRecursionLabel.Text = "Fixed recursion: 0%";
            // 
            // RecursiveDivisionFixedRecursionLTB
            // 
            this.RecursiveDivisionFixedRecursionLTB.Location = new System.Drawing.Point(141, 35);
            this.RecursiveDivisionFixedRecursionLTB.LogMaximum = 1D;
            this.RecursiveDivisionFixedRecursionLTB.LogMiddle = 0.2D;
            this.RecursiveDivisionFixedRecursionLTB.LogMinimum = 0D;
            this.RecursiveDivisionFixedRecursionLTB.Maximum = 1000;
            this.RecursiveDivisionFixedRecursionLTB.Name = "RecursiveDivisionFixedRecursionLTB";
            this.RecursiveDivisionFixedRecursionLTB.Size = new System.Drawing.Size(174, 45);
            this.RecursiveDivisionFixedRecursionLTB.TabIndex = 29;
            this.RecursiveDivisionFixedRecursionLTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RecursiveDivisionFixedRecursionLTB.ValueChanged += new System.EventHandler(this.SyncRecursiveDivisionParameters);
            // 
            // ShowAdvancedSettingsCheckBox
            // 
            this.ShowAdvancedSettingsCheckBox.AutoSize = true;
            this.ShowAdvancedSettingsCheckBox.Checked = true;
            this.ShowAdvancedSettingsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowAdvancedSettingsCheckBox.Location = new System.Drawing.Point(231, 200);
            this.ShowAdvancedSettingsCheckBox.Name = "ShowAdvancedSettingsCheckBox";
            this.ShowAdvancedSettingsCheckBox.Size = new System.Drawing.Size(114, 17);
            this.ShowAdvancedSettingsCheckBox.TabIndex = 27;
            this.ShowAdvancedSettingsCheckBox.Text = "Advanced settings";
            this.ShowAdvancedSettingsCheckBox.UseVisualStyleBackColor = true;
            this.ShowAdvancedSettingsCheckBox.CheckedChanged += new System.EventHandler(this.SyncGroupBoxes);
            // 
            // KruskalGroupBox
            // 
            this.KruskalGroupBox.Controls.Add(this.KruskalShowAllWallCheckingCheckBox);
            this.KruskalGroupBox.Controls.Add(this.KruskalBraidLTB);
            this.KruskalGroupBox.Controls.Add(this.KruskalBraidLabel);
            this.KruskalGroupBox.Location = new System.Drawing.Point(698, 6);
            this.KruskalGroupBox.Name = "KruskalGroupBox";
            this.KruskalGroupBox.Size = new System.Drawing.Size(334, 363);
            this.KruskalGroupBox.TabIndex = 41;
            this.KruskalGroupBox.TabStop = false;
            this.KruskalGroupBox.Text = "Kruskal settings";
            this.KruskalGroupBox.Visible = false;
            // 
            // KruskalShowAllWallCheckingCheckBox
            // 
            this.KruskalShowAllWallCheckingCheckBox.AutoSize = true;
            this.KruskalShowAllWallCheckingCheckBox.Location = new System.Drawing.Point(24, 76);
            this.KruskalShowAllWallCheckingCheckBox.Name = "KruskalShowAllWallCheckingCheckBox";
            this.KruskalShowAllWallCheckingCheckBox.Size = new System.Drawing.Size(134, 17);
            this.KruskalShowAllWallCheckingCheckBox.TabIndex = 42;
            this.KruskalShowAllWallCheckingCheckBox.Text = "Show all wall checking";
            this.KruskalShowAllWallCheckingCheckBox.UseVisualStyleBackColor = true;
            this.KruskalShowAllWallCheckingCheckBox.CheckedChanged += new System.EventHandler(this.SyncKruskalParameters);
            // 
            // KruskalBraidLTB
            // 
            this.KruskalBraidLTB.Location = new System.Drawing.Point(103, 36);
            this.KruskalBraidLTB.LogMaximum = 1D;
            this.KruskalBraidLTB.LogMiddle = 0.5D;
            this.KruskalBraidLTB.LogMinimum = 0D;
            this.KruskalBraidLTB.Maximum = 1000;
            this.KruskalBraidLTB.Name = "KruskalBraidLTB";
            this.KruskalBraidLTB.Size = new System.Drawing.Size(213, 45);
            this.KruskalBraidLTB.TabIndex = 29;
            this.KruskalBraidLTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.KruskalBraidLTB.ValueChanged += new System.EventHandler(this.SyncKruskalParameters);
            // 
            // KruskalBraidLabel
            // 
            this.KruskalBraidLabel.AutoSize = true;
            this.KruskalBraidLabel.Location = new System.Drawing.Point(21, 36);
            this.KruskalBraidLabel.Name = "KruskalBraidLabel";
            this.KruskalBraidLabel.Size = new System.Drawing.Size(51, 13);
            this.KruskalBraidLabel.TabIndex = 28;
            this.KruskalBraidLabel.Text = "Braid: 0%";
            // 
            // BinaryTreeGroupBox
            // 
            this.BinaryTreeGroupBox.Controls.Add(this.BinaryTreeBiasLTB);
            this.BinaryTreeGroupBox.Controls.Add(this.BinaryTreeBiasLabel);
            this.BinaryTreeGroupBox.Controls.Add(this.BinaryTreeSidewinderLTB);
            this.BinaryTreeGroupBox.Controls.Add(this.BinaryTreeSidewinderLabel);
            this.BinaryTreeGroupBox.Location = new System.Drawing.Point(358, 375);
            this.BinaryTreeGroupBox.Name = "BinaryTreeGroupBox";
            this.BinaryTreeGroupBox.Size = new System.Drawing.Size(334, 363);
            this.BinaryTreeGroupBox.TabIndex = 43;
            this.BinaryTreeGroupBox.TabStop = false;
            this.BinaryTreeGroupBox.Text = "Binary tree settings";
            this.BinaryTreeGroupBox.Visible = false;
            // 
            // BinaryTreeBiasLTB
            // 
            this.BinaryTreeBiasLTB.Location = new System.Drawing.Point(103, 75);
            this.BinaryTreeBiasLTB.LogMaximum = 1D;
            this.BinaryTreeBiasLTB.LogMiddle = 0.5D;
            this.BinaryTreeBiasLTB.LogMinimum = 0D;
            this.BinaryTreeBiasLTB.Maximum = 1000;
            this.BinaryTreeBiasLTB.Name = "BinaryTreeBiasLTB";
            this.BinaryTreeBiasLTB.Size = new System.Drawing.Size(213, 45);
            this.BinaryTreeBiasLTB.TabIndex = 33;
            this.BinaryTreeBiasLTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BinaryTreeBiasLTB.Value = 500;
            this.BinaryTreeBiasLTB.ValueChanged += new System.EventHandler(this.SyncBinaryTreeParameters);
            // 
            // BinaryTreeBiasLabel
            // 
            this.BinaryTreeBiasLabel.AutoSize = true;
            this.BinaryTreeBiasLabel.Location = new System.Drawing.Point(21, 75);
            this.BinaryTreeBiasLabel.Name = "BinaryTreeBiasLabel";
            this.BinaryTreeBiasLabel.Size = new System.Drawing.Size(47, 13);
            this.BinaryTreeBiasLabel.TabIndex = 32;
            this.BinaryTreeBiasLabel.Text = "Bias: 0%";
            // 
            // BinaryTreeSidewinderLTB
            // 
            this.BinaryTreeSidewinderLTB.Location = new System.Drawing.Point(102, 34);
            this.BinaryTreeSidewinderLTB.LogMaximum = 1D;
            this.BinaryTreeSidewinderLTB.LogMiddle = 0.5D;
            this.BinaryTreeSidewinderLTB.LogMinimum = 0D;
            this.BinaryTreeSidewinderLTB.Maximum = 1000;
            this.BinaryTreeSidewinderLTB.Name = "BinaryTreeSidewinderLTB";
            this.BinaryTreeSidewinderLTB.Size = new System.Drawing.Size(213, 45);
            this.BinaryTreeSidewinderLTB.TabIndex = 31;
            this.BinaryTreeSidewinderLTB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.BinaryTreeSidewinderLTB.ValueChanged += new System.EventHandler(this.SyncBinaryTreeParameters);
            // 
            // BinaryTreeSidewinderLabel
            // 
            this.BinaryTreeSidewinderLabel.AutoSize = true;
            this.BinaryTreeSidewinderLabel.Location = new System.Drawing.Point(20, 34);
            this.BinaryTreeSidewinderLabel.Name = "BinaryTreeSidewinderLabel";
            this.BinaryTreeSidewinderLabel.Size = new System.Drawing.Size(79, 13);
            this.BinaryTreeSidewinderLabel.TabIndex = 30;
            this.BinaryTreeSidewinderLabel.Text = "Sidewinder: 0%";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 614);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(144, 27);
            this.SaveButton.TabIndex = 44;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
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
            this.RendererDelayLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.SyncRunnerParameters);
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
            this.GeneratorDelayLogarithmicTrackBar.ValueChanged += new System.EventHandler(this.SyncRunnerParameters);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 899);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.BinaryTreeGroupBox);
            this.Controls.Add(this.KruskalGroupBox);
            this.Controls.Add(this.ShowAdvancedSettingsCheckBox);
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
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.GrowingTreeGroupBox.ResumeLayout(false);
            this.GrowingTreeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeSparsenessNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeTreesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeRunLogarithmicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBraidLogarithmicTrackBar)).EndInit();
            this.BiasesGroupBox.ResumeLayout(false);
            this.BiasesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBiasDownLogarithmicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBiasRightLogarithmicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBiasLeftLogarithmicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBiasUpLogarithmicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrowingTreeBreadthLogarithmicTrackBar)).EndInit();
            this.RecursiveDivisionGroupBox.ResumeLayout(false);
            this.RecursiveDivisionGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RecursiveDivisionReverseOrderLTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecursiveDivisionProportionalSplitsLTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecursiveDivisionSplitLocationLTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecursiveDivisionFixedSplitsLTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecursiveDivisionRecursionLocationLTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecursiveDivisionFixedRecursionLTB)).EndInit();
            this.KruskalGroupBox.ResumeLayout(false);
            this.KruskalGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KruskalBraidLTB)).EndInit();
            this.BinaryTreeGroupBox.ResumeLayout(false);
            this.BinaryTreeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryTreeBiasLTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryTreeSidewinderLTB)).EndInit();
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
        private LogarithmicTrackBar GrowingTreeBiasDownLogarithmicTrackBar;
        private LogarithmicTrackBar GrowingTreeBiasRightLogarithmicTrackBar;
        private LogarithmicTrackBar GrowingTreeBiasLeftLogarithmicTrackBar;
        private LogarithmicTrackBar GrowingTreeBiasUpLogarithmicTrackBar;
        private ArrowCrossShape arrowCrossShape1;
        private System.Windows.Forms.Button GrowingTreeResetBiasesButton;
        private System.Windows.Forms.CheckBox ShowAdvancedSettingsCheckBox;
        private System.Windows.Forms.NumericUpDown GrowingTreeSparsenessNumericUpDown;
        private System.Windows.Forms.Label GrowingTreeSparsenessLabel;
        private System.Windows.Forms.Label RecursiveDivisionRecursionLocationLabel;
        private LogarithmicTrackBar RecursiveDivisionRecursionLocationLTB;
        private System.Windows.Forms.Label RecursiveDivisionFixedRecursionLabel;
        private LogarithmicTrackBar RecursiveDivisionFixedRecursionLTB;
        private System.Windows.Forms.Label RecursiveDivisionSplitLocationLabel;
        private LogarithmicTrackBar RecursiveDivisionSplitLocationLTB;
        private System.Windows.Forms.Label RecursiveDivisionFixedSplitsLabel;
        private LogarithmicTrackBar RecursiveDivisionFixedSplitsLTB;
        private System.Windows.Forms.Label RecursiveDivisionProportionalSplitsLabel;
        private LogarithmicTrackBar RecursiveDivisionProportionalSplitsLTB;
        private System.Windows.Forms.Label RecursiveDivisionReverseOrderLabel;
        private LogarithmicTrackBar RecursiveDivisionReverseOrderLTB;
        private System.Windows.Forms.CheckBox RecursiveDivisionShowInitializationStepCheckBox;
        private System.Windows.Forms.CheckBox RecursiveDivisionProcessSingleCellBlocksCheckBox;
        private System.Windows.Forms.GroupBox KruskalGroupBox;
        private System.Windows.Forms.CheckBox KruskalShowAllWallCheckingCheckBox;
        private LogarithmicTrackBar KruskalBraidLTB;
        private System.Windows.Forms.Label KruskalBraidLabel;
        private System.Windows.Forms.GroupBox BinaryTreeGroupBox;
        private LogarithmicTrackBar BinaryTreeSidewinderLTB;
        private System.Windows.Forms.Label BinaryTreeSidewinderLabel;
        private LogarithmicTrackBar BinaryTreeBiasLTB;
        private System.Windows.Forms.Label BinaryTreeBiasLabel;
        private System.Windows.Forms.Button SaveButton;
    }
}

