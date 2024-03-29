﻿using System;
using System.Windows.Forms;
using Maze.Core.Generators;
using Maze.Core.Generators.AldousBroder;
using Maze.Core.Generators.BinaryTree;
using Maze.Core.Generators.Decorators;
using Maze.Core.Generators.GrowingTree;
using Maze.Core.Generators.Kruskal;
using Maze.Core.Generators.RecursiveDivision;
using Maze.Core.Maps;
using Maze.Core.Maps.Decorators;
using Maze.Core.Runners;
using Maze.WinFormsGDI.Controls;
using Maze.WinFormsGDI.ExtensionMethods;
using Point = Maze.Core.Common.Point;

namespace Maze.WinFormsGDI.Forms
{
    public partial class MainForm : Form
    {
        private FormWindowState LastWindowState { get; set; }
        private IMap Map { get; set; }
        private GrowingTreeMazeGenerator GrowingTreeMazeGenerator { get; set; }
        private KruskalMazeGenerator KruskalMazeGenerator { get; set; }
        private RecursiveDivisionMazeGenerator RecursiveDivisionMazeGenerator { get; set; }
        private BinaryTreeMazeGenerator BinaryTreeMazeGenerator { get; set; }
        private AldousBroderMazeGenerator AldousBroderMazeGenerator { get; set; }
        private IMazeGenerator MazeGenerator { get; set; }
        private PictureBoxMapRenderer MapRenderer { get; set; }
        private IGeneratorFactory GeneratorFactory { get; }
        private MazeGenerationRunner Runner { get; set; }

        private TimeSpan CurrentGeneratorDelay => GetTimeSpanFromLogarithmicTrackBar(GeneratorDelayLogarithmicTrackBar);
        private TimeSpan CurrentRendererDelay => GetTimeSpanFromLogarithmicTrackBar(RendererDelayLogarithmicTrackBar);
        private MazeGenerationAlgorithm CurrentAlgorithm
        {
            get => (MazeGenerationAlgorithm)AlgorithmComboBox.SelectedItem;
            set => AlgorithmComboBox.SelectedItem = value;
        }
        private bool TrackChanges
        {
            get => TrackChangesCheckBox.Checked;
            set => TrackChangesCheckBox.Checked = value;
        }

        private bool ShowAdvancedSettings
        {
            get => ShowAdvancedSettingsCheckBox.Checked;
            set => ShowAdvancedSettingsCheckBox.Checked = value;
        }

        private double GrowingTreeBreadth => GrowingTreeBreadthLogarithmicTrackBar.LogValue;
        private double GrowingTreeRun => GrowingTreeRunLogarithmicTrackBar.LogValue;
        private double GrowingTreeBraid => GrowingTreeBraidLogarithmicTrackBar.LogValue;
        private int GrowingTreeTrees => (int)GrowingTreeTreesNumericUpDown.Value;
        private int GrowingTreeSparseness => (int)GrowingTreeSparsenessNumericUpDown.Value;
        private double GrowingTreeBiasUp => GrowingTreeBiasUpLogarithmicTrackBar.LogValue;
        private double GrowingTreeBiasDown => GrowingTreeBiasDownLogarithmicTrackBar.LogValue;
        private double GrowingTreeBiasLeft => GrowingTreeBiasLeftLogarithmicTrackBar.LogValue;
        private double GrowingTreeBiasRight => GrowingTreeBiasRightLogarithmicTrackBar.LogValue;

        private double RecursiveDivisionFixedRecursion => RecursiveDivisionFixedRecursionLTB.LogValue;
        private double RecursiveDivisionRecursionLocation => RecursiveDivisionRecursionLocationLTB.LogValue;
        private double RecursiveDivisionFixedSplits => RecursiveDivisionFixedSplitsLTB.LogValue;
        private double RecursiveDivisionSplitLocation => RecursiveDivisionSplitLocationLTB.LogValue;
        private double RecursiveDivisionProportionalSplits => RecursiveDivisionProportionalSplitsLTB.LogValue;
        private double RecursiveDivisionReverseOrder => RecursiveDivisionReverseOrderLTB.LogValue;
        private bool RecursiveDivisionProcessSingleCellBlocks => RecursiveDivisionProcessSingleCellBlocksCheckBox.Checked;
        private bool RecursiveDivisionShowInitializationStep => RecursiveDivisionShowInitializationStepCheckBox.Checked;

        private double KruskalBraid => KruskalBraidLTB.LogValue;
        private bool KruskalShowAllWallChekcing => KruskalShowAllWallCheckingCheckBox.Checked;

        private double BinaryTreeSidewinder => BinaryTreeSidewinderLTB.LogValue;
        private double BinaryTreeVerticalBias => BinaryTreeBiasLTB.LogValue;

        public MainForm()
        {
            InitializeComponent();
            GeneratorFactory = new GeneratorFactory();
            InitializeManual();
        }

        private void InitializeManual()
        {
            var algorithms = GeneratorFactory.GetAvailableAlgorithms();
            foreach (var mazeGenerationAlgorithm in algorithms)
            {
                AlgorithmComboBox.Items.Add(mazeGenerationAlgorithm);
            }
            AlgorithmComboBox.SelectedIndex = 0;
            RecursiveDivisionGroupBox.Location = GrowingTreeGroupBox.Location;
            KruskalGroupBox.Location = GrowingTreeGroupBox.Location;
            BinaryTreeGroupBox.Location = GrowingTreeGroupBox.Location;
            LastWindowState = WindowState;
            SyncAll();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopRunner();
        }

        private TimeSpan GetTimeSpanFromTextBox(TextBox textBox)
        {
            var delayMiliseconds = Convert.ToDouble(textBox.Text);
            return MilisecondsToTimeSpan(delayMiliseconds);
        }

        private TimeSpan GetTimeSpanFromLogarithmicTrackBar(LogarithmicTrackBar trackBar)
        {
            var delayMiliseconds = Convert.ToDouble(trackBar.LogValue);
            return MilisecondsToTimeSpan(delayMiliseconds);
        }

        private static TimeSpan MilisecondsToTimeSpan(double delayMiliseconds)
        {
            var delayTimeSpan = TimeSpan.FromTicks((long)(delayMiliseconds * TimeSpan.TicksPerMillisecond));
            return delayTimeSpan;
        }
        private double ExtendDoubleVal(double val)
        {
            var extendedVal = Math.Abs(val - 1) < 0.0000001 ? double.MaxValue / 1000000 : 1 / (1 - val) - 1;
            return extendedVal;
        }

        private void StopRunner()
        {
            Runner?.Stop();
            Runner = null;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            StopRunner();
            var width = Convert.ToInt32(WidthTextBox.Text);
            var height = Convert.ToInt32(HeightTextBox.Text);
            if (InfiniteMapCheckBox.Checked)
            {
                Map = new InfiniteMap(2);
            }
            else
            {
                Map = new FiniteMap2D(width, height);
            }

            Random rng;
            if (string.IsNullOrWhiteSpace(SeedTextBox.Text))
            {
                rng = new Random();
            }
            else
            {
                var seedValid = int.TryParse(SeedTextBox.Text, out var seed);
                if (!seedValid)
                {
                    MessageBox.Show("Seed must be a number, or empty to use a random seed.", "Invalid seed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                rng = new Random(seed);
            }
            
            switch (CurrentAlgorithm)
            {
                case MazeGenerationAlgorithm.GrowingTree:
                    GrowingTreeMazeGenerator = new GrowingTreeMazeGenerator(Map, rng);
                    MazeGenerator = GrowingTreeMazeGenerator;
                    break;
                case MazeGenerationAlgorithm.Kruskal:
                    KruskalMazeGenerator = new KruskalMazeGenerator(Map, rng);
                    MazeGenerator = KruskalMazeGenerator;
                    break;
                case MazeGenerationAlgorithm.RecursiveDivision:
                    RecursiveDivisionMazeGenerator = new RecursiveDivisionMazeGenerator(Map, rng);
                    MazeGenerator = RecursiveDivisionMazeGenerator;
                    break;
                case MazeGenerationAlgorithm.BinaryTree:
                    BinaryTreeMazeGenerator = new BinaryTreeMazeGenerator(Map, rng);
                    MazeGenerator = BinaryTreeMazeGenerator;
                    break;
                case MazeGenerationAlgorithm.AldousBroder:
                    AldousBroderMazeGenerator = new AldousBroderMazeGenerator(Map, rng);
                    MazeGenerator = AldousBroderMazeGenerator;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            SyncAllGeneratorParameters();
            var activeCellsGenerator = new ActiveCellsMazeGeneratorDecorator(MazeGenerator);
            var displayMap = new AsFiniteMapDecorator(Map, Map.Size ?? new Point(width, height));
            MapRenderer = new PictureBoxMapRenderer(displayMap, MainPictureBox);
            Runner = new MazeGenerationRunner(activeCellsGenerator, MapRenderer, CurrentGeneratorDelay, CurrentRendererDelay, true);
            var generatorSteps = 0;
            var rendererSteps = 0;
            Runner.AfterGenerate += results => { generatorSteps++; };
            Runner.BeforeRender += results =>
            {
                if (TrackChanges && results.Results.Count > 0)
                {
                    displayMap.Offset = displayMap.Size / 2 - results.Results[0].Point;
                }
            };
            Runner.AfterRender += results => { rendererSteps++; };
            Runner.Start();
        }

        private void SyncAll(object sender = null, EventArgs e = null)
        {
            SyncGroupBoxes(sender, e);
            SyncRunnerParameters(sender, e);
            SyncAllGeneratorParameters(sender, e);
        }

        private void SyncGroupBoxes(object sender = null, EventArgs e = null)
        {
            var currentAlgorithm = CurrentAlgorithm;
            var showAdvancedSettings = ShowAdvancedSettings;
            GrowingTreeGroupBox.Visible = currentAlgorithm == MazeGenerationAlgorithm.GrowingTree && showAdvancedSettings;
            RecursiveDivisionGroupBox.Visible = currentAlgorithm == MazeGenerationAlgorithm.RecursiveDivision && showAdvancedSettings;
            KruskalGroupBox.Visible = currentAlgorithm == MazeGenerationAlgorithm.Kruskal && showAdvancedSettings;
            BinaryTreeGroupBox.Visible = currentAlgorithm == MazeGenerationAlgorithm.BinaryTree && showAdvancedSettings;
        }

        private void SyncRunnerParameters(object sender = null, EventArgs e = null)
        {
            var generatorDelay = CurrentGeneratorDelay;
            var rendererDelay = CurrentRendererDelay;
            GeneratorDelayLabel.Text = @"Generator delay: " + generatorDelay.ToSuffixedString();
            RendererDelayLabel.Text = @"Renderer delay: " + rendererDelay.ToSuffixedString();
            if (Runner == null)
            {
                return;
            }
            Runner.GeneratorMinCycleTime = generatorDelay;
            Runner.RendererMinCycleTime = rendererDelay;
        }

        private void SyncAllGeneratorParameters(object sender = null, EventArgs e = null)
        {
            SyncGrowingTreeParameters(sender, e);
            SyncRecursiveDivisionParameters(sender, e);
            SyncKruskalParameters(sender, e);
            SyncBinaryTreeParameters(sender, e);
        }

        private void SyncGrowingTreeParameters(object sender = null, EventArgs e = null)
        {
            var breadth = GrowingTreeBreadth;
            var run = GrowingTreeRun;
            var braid = GrowingTreeBraid;
            GrowingTreeBreadthLabel.Text = @"Breadth: " + breadth.ToString("0.0%");
            GrowingTreeRunLabel.Text = @"Run: " + run.ToString("0.0%");
            GrowingTreeBraidLabel.Text = @"Braid: " + braid.ToString("0.0%");
            if (GrowingTreeMazeGenerator == null)
            {
                return;
            }
            GrowingTreeMazeGenerator.Breadth = breadth;
            GrowingTreeMazeGenerator.Runs[0] = ExtendDoubleVal(run);
            GrowingTreeMazeGenerator.LastChanceLooping = braid;
            GrowingTreeMazeGenerator.TreeCount = GrowingTreeTrees;
            GrowingTreeMazeGenerator.Sparseness = GrowingTreeSparseness;
            GrowingTreeMazeGenerator.Biases[2] = ExtendDoubleVal(GrowingTreeBiasUp);
            GrowingTreeMazeGenerator.Biases[3] = ExtendDoubleVal(GrowingTreeBiasDown);
            GrowingTreeMazeGenerator.Biases[0] = ExtendDoubleVal(GrowingTreeBiasLeft);
            GrowingTreeMazeGenerator.Biases[1] = ExtendDoubleVal(GrowingTreeBiasRight);
        }

        private void SyncRecursiveDivisionParameters(object sender = null, EventArgs e = null)
        {
            var fixedRecursion = RecursiveDivisionFixedRecursion;
            var recursionLocation = RecursiveDivisionRecursionLocation;
            var fixedSplits = RecursiveDivisionFixedSplits;
            var splitLocation = RecursiveDivisionSplitLocation;
            var proportionalSplits = RecursiveDivisionProportionalSplits;
            var reverseOrder = RecursiveDivisionReverseOrder;
            var showInitializationStep = RecursiveDivisionShowInitializationStep;
            var processSingleCellBlocks = RecursiveDivisionProcessSingleCellBlocks;
            RecursiveDivisionFixedRecursionLabel.Text = @"Fixed recursion: " + fixedRecursion.ToString("0.0%");
            RecursiveDivisionRecursionLocationLabel.Text = @"Recursion location: " + recursionLocation.ToString("0.0%");
            RecursiveDivisionFixedSplitsLabel.Text = @"Fixed splits: " + fixedSplits.ToString("0.0%");
            RecursiveDivisionSplitLocationLabel.Text = @"Split location: " + splitLocation.ToString("0.0%");
            RecursiveDivisionProportionalSplitsLabel.Text = @"Proportional splits: " + proportionalSplits.ToString("0.0%");
            RecursiveDivisionReverseOrderLabel.Text = @"Reverse order: " + reverseOrder.ToString("0.0%");
            if (RecursiveDivisionMazeGenerator == null)
            {
                return;
            }
            RecursiveDivisionMazeGenerator.FixedRecursion = fixedRecursion;
            RecursiveDivisionMazeGenerator.FixedRecursionLocation = recursionLocation;
            RecursiveDivisionMazeGenerator.FixedSplits = fixedSplits;
            RecursiveDivisionMazeGenerator.FixedSplitLocation = splitLocation;
            RecursiveDivisionMazeGenerator.ProportionalSplits = proportionalSplits;
            RecursiveDivisionMazeGenerator.ReverseRecursionOrder = reverseOrder;
            RecursiveDivisionMazeGenerator.ShowMapInitializationStep = showInitializationStep;
            RecursiveDivisionMazeGenerator.ProcessSingleCellBlocks = processSingleCellBlocks;
        }

        private void SyncKruskalParameters(object sender = null, EventArgs e = null)
        {
            var braid = KruskalBraid;
            KruskalBraidLabel.Text = @"Braid: " + braid.ToString("0.0%");
            if (KruskalMazeGenerator == null)
            {
                return;
            }
            KruskalMazeGenerator.Looping = braid;
            KruskalMazeGenerator.ShowAllWallChecking = KruskalShowAllWallChekcing;
        }

        private void SyncBinaryTreeParameters(object sender = null, EventArgs e = null)
        {
            var sidewinder = BinaryTreeSidewinder;
            var verticalBias = BinaryTreeVerticalBias;
            BinaryTreeSidewinderLabel.Text = @"Sidewinder: " + sidewinder.ToString("0.0%");
            BinaryTreeBiasLabel.Text = @"Bias: " + verticalBias.ToString("0.0%");
            if (BinaryTreeMazeGenerator == null)
            {
                return;
            }
            BinaryTreeMazeGenerator.UseSidewinder = sidewinder;
            BinaryTreeMazeGenerator.VerticalBias = verticalBias;
        }

        private void TrackChangesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MapRenderer.ForceRerender = TrackChanges;
        }

        private void GrowingTreeResetBiasesButton_Click(object sender, EventArgs e)
        {
            GrowingTreeBiasUpLogarithmicTrackBar.Value = 500;
            GrowingTreeBiasDownLogarithmicTrackBar.Value = 500;
            GrowingTreeBiasLeftLogarithmicTrackBar.Value = 500;
            GrowingTreeBiasRightLogarithmicTrackBar.Value = 500;
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            MapRenderer?.SyncSize();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState != LastWindowState && WindowState != FormWindowState.Minimized)
            {
                MapRenderer?.SyncSize();
                LastWindowState = WindowState;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            new SaveForm(Map).Show();
        }
    }
}
