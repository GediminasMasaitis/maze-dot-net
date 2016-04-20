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
                var algorithmStr = mazeGenerationAlgorithm.ToString();
                AlgorithmComboBox.Items.Add(mazeGenerationAlgorithm);
            }
            AlgorithmComboBox.SelectedIndex = 0;
            SyncRunnerParameters();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
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

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            var track = false;
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
                    //GrowingTreeMazeGenerator.Breadth = 1;
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

            var activeCellsGenerator = new ActiveCellsMazeGeneratorDecorator(MazeGenerator);
            var displayMap = new AsFiniteMapDecorator(Map, Map.Size ?? new Point(width, height));
            MapRenderer = new PictureBoxMapRenderer(displayMap, MainPictureBox);
            Runner = new MazeGenerationRunner(activeCellsGenerator, MapRenderer, CurrentGeneratorDelay, CurrentRendererDelay, true);
            var generatorSteps = 0;
            var rendererSteps = 0;
            Runner.AfterGenerate += results => { generatorSteps++; };
            Runner.BeforeRender += results =>
            {
                if (track && results.Results.Count > 0)
                {
                    displayMap.Offset = displayMap.Size/2 - results.Results[0].Point;
                }
            };
            Runner.AfterRender += results => { rendererSteps++; };
            Runner.Start();
        }

        private void SyncRunnerParameters()
        {
            var generatorDelay = CurrentGeneratorDelay;
            var rendererDelay = CurrentRendererDelay;
            GeneratorDelayLabel.Text = @"Generator delay: " + TimeSpanToString(generatorDelay);
            RendererDelayLabel.Text = @"Renderer delay: " + TimeSpanToString(rendererDelay);
            if (Runner == null)
            {
                return;
            }
            Runner.GeneratorMinCycleTime = generatorDelay;
            Runner.RendererMinCycleTime = rendererDelay;
        }

        private string TimeSpanToString(TimeSpan span)
        {
            if (span.TotalSeconds > 1)
            {
                return span.TotalSeconds.ToString("0.00") + " s.";
            }
            if (span.TotalMilliseconds > 1)
            {
                return span.TotalMilliseconds.ToString("0.0") + " ms.";
            }
            return (span.TotalMilliseconds * 1000).ToString("000") + " μs.";
        }

        private void GeneratorDelayLogarithmicTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SyncRunnerParameters();
        }

        private void RendererDelayLogarithmicTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SyncRunnerParameters();
        }
    }
}
