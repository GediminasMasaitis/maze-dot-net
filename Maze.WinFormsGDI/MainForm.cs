using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Maze.Core.Generators;
using Maze.Core.Generators.Decorators;
using Maze.Core.Generators.GrowingTree;
using Maze.Core.Generators.RecursiveDivision;
using Maze.Core.Maps;
using Maze.Core.Maps.Decorators;
using Maze.Core.Runners;
using Point = Maze.Core.Common.Point;

namespace Maze.WinFormsGDI
{
    public partial class MainForm : Form
    {
        private IMap Map;
        private GrowingTreeMazeGenerator MazeGenerator;
        private PictureBoxMapRenderer MapRenderer;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private async void GenerateButton_Click(object sender, EventArgs e)
        {
            var track = false;
            var map = new FiniteMap2D(49,49);
            //var map = new InfiniteMap(2);
            var displayMap = new AsFiniteMapDecorator(map, map.Size ?? new Point(49, 49));
            var innerGenerator = new GrowingTreeMazeGenerator(map);
            //var innerGenerator = new KruskalMazeGenerator(map);
            //innerGenerator.Sparseness = 4;
            //innerGenerator.Breadth = 1;
            IMazeGenerator generator = new ActiveCellsMazeGeneratorDecorator(innerGenerator);
            //IMazeGenerator generator = innerGenerator;
            DoubleBuffered = true;
            var renderer = new PictureBoxMapRenderer(map,MainPictureBox);
            //renderer.SaveImageOnCompletion = true;
            //renderer.ForceRerender = true;
            var generatorDelay = 10d;
            var rendererDelay = 1000d / 60d;
            var generatorDelaySpan = TimeSpan.FromTicks((long)(generatorDelay * TimeSpan.TicksPerMillisecond));
            var rendererDelaySpan = TimeSpan.FromTicks((long)(rendererDelay * TimeSpan.TicksPerMillisecond));
            var runner = new MazeGenerationRunner(generator, renderer, generatorDelaySpan, rendererDelaySpan, true);
            var generatorSteps = 0;
            var rendererSteps = 0;
            runner.AfterGenerate += results =>
            {
                generatorSteps++;
            };
            runner.BeforeRender += results =>
            {
                if (track && results.Results.Count > 0)
                {
                    displayMap.Offset = displayMap.Size / 2 - results.Results[0].Point;
                }
            };
            runner.AfterRender += results =>
            {
                rendererSteps++;
            };
            runner.Start();
        }
    }
}
