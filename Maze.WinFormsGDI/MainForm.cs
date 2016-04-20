using System;
using System.Diagnostics;
using System.Drawing;
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

namespace Maze.WinFormsGDI
{
    public partial class MainForm : Form
    {
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
            get { return (MazeGenerationAlgorithm)AlgorithmComboBox.SelectedItem; }
            set { AlgorithmComboBox.SelectedItem = value; }
        }
        private bool TrackChanges
        {
            get { return TrackChangesCheckBox.Checked; }
            set { TrackChangesCheckBox.Checked = value; }
        }

        private double GrowingTreeBreadth => GrowingTreeBreadthLogarithmicTrackBar.LogValue;
        private double GrowingTreeRun => GrowingTreeRunLogarithmicTrackBar.LogValue;
        private double GrowingTreeBraid => GrowingTreeBraidLogarithmicTrackBar.LogValue;
        private int GrowingTreeTrees => (int)GrowingTreeTreesNumericUpDown.Value;


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
            var delayTimeSpan = TimeSpan.FromTicks((long) (delayMiliseconds*TimeSpan.TicksPerMillisecond));
            return delayTimeSpan;
        }

        private void AlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SyncGroupBoxes();
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
            var rng = new Random();
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
                    displayMap.Offset = displayMap.Size/2 - results.Results[0].Point;
                }
            };
            Runner.AfterRender += results => { rendererSteps++; };
            Runner.Start();
        }

        private void SyncAll()
        {
            SyncGroupBoxes();
            SyncRunnerParameters();
            SyncAllGeneratorParameters();
        }
        
        private void SyncGroupBoxes()
        {
            var currentAlgorithm = CurrentAlgorithm;
            GrowingTreeGroupBox.Visible = currentAlgorithm == MazeGenerationAlgorithm.GrowingTree;
            RecursiveDivisionGroupBox.Visible = currentAlgorithm == MazeGenerationAlgorithm.RecursiveDivision;
        }

        private void SyncRunnerParameters()
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

        private void SyncAllGeneratorParameters()
        {
            SyncGrowingTreeParameters();
            SyncRecursiveDivisionParameters();
        }

        private void SyncGrowingTreeParameters()
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
            var realRun = Math.Abs(run - 1) < 0.0000001 ? double.MaxValue : 1/(1 - run) - 1;
            GrowingTreeMazeGenerator.Runs[0] = realRun;
            GrowingTreeMazeGenerator.LastChanceLooping = braid;
            GrowingTreeMazeGenerator.TreeCount = GrowingTreeTrees;
        }

        private void SyncRecursiveDivisionParameters()
        {
            if (RecursiveDivisionMazeGenerator == null)
            {
                return;
            }
        }

        private void TrackChangesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MapRenderer.ForceRerender = TrackChanges;
        }

        private void GeneratorDelayLogarithmicTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SyncRunnerParameters();
        }

        private void RendererDelayLogarithmicTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SyncRunnerParameters();
        }

        private void BreadthLogarithmicTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SyncGrowingTreeParameters();
        }

        private void GrowingTreeRunLogarithmicTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SyncGrowingTreeParameters();
        }

        private void GrowingTreeBraidLogarithmicTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SyncGrowingTreeParameters();
        }
    }
}
