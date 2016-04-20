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
        }

        private MazeGenerationAlgorithm CurrentAlgorithm
        {
            get { return (MazeGenerationAlgorithm) AlgorithmComboBox.SelectedItem; }
            set { AlgorithmComboBox.SelectedItem = value; }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private TimeSpan GetTimeSpanFromTextBox(TextBox textBox)
        {
            var delayMiliseconds = Convert.ToDouble(textBox.Text);
            var delayTimeSpan = TimeSpan.FromTicks((long)(delayMiliseconds * TimeSpan.TicksPerMillisecond));
            return delayTimeSpan;
        }

        private TimeSpan CurrentGeneratorDelay => GetTimeSpanFromTextBox(GeneratorDelayTextBox);
        private TimeSpan CurrentRendererDelay => GetTimeSpanFromTextBox(RendererDelayTextBox);

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
            var renderer = new PictureBoxMapRenderer(displayMap, MainPictureBox);
            Runner = new MazeGenerationRunner(activeCellsGenerator, renderer, CurrentGeneratorDelay, CurrentRendererDelay, true);
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
            if (Runner == null)
            {
                return;
            }
            Runner.GeneratorMinCycleTime = CurrentGeneratorDelay;
            Runner.RendererMinCycleTime = CurrentRendererDelay;
        }

        private void GeneratorDelayTextBox_TextChanged(object sender, EventArgs e)
        {
            SyncRunnerParameters();
        }

        private void RendererDelayTextBox_TextChanged(object sender, EventArgs e)
        {
            SyncRunnerParameters();
        }
    }
}
