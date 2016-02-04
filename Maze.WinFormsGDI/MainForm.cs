using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maze.Generator;
using Maze.Generator.Generators;
using Maze.Generator.Generators.Decorators;
using Maze.Generator.Generators.GrowingTree;
using Maze.Generator.Maps;
using Maze.Generator.Renderers;
using Maze.Generator.Results;
using Point = Maze.Generator.Point;

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

        private async void GenerateButton_Click(object sender, EventArgs e)
        {
            var track = false;
            var map = new FiniteMap2D(249,249);
            //var map = new InfiniteMap(2);
            var displayMap = new AsFiniteMapDecorator(map, map.Size ?? new Point(49, 49));
            var innerGenerator = new GrowingTreeMazeGenerator(map);
            //var innerGenerator = new KruskalMazeGenerator(map);
            //innerGenerator.GenerationParameters.Breadth = 1;
            IMazeGenerator generator = new ActiveCellsMazeGeneratorDecorator(innerGenerator);
            //IMazeGenerator generator = innerGenerator;
            var renderer = new PictureBoxMapRenderer(MainPictureBox, map);
            var generatorDelay = 1d;
            var rendererDelay = 1000d / 60d;
            var generatorDelaySpan = TimeSpan.FromTicks((long)(generatorDelay * TimeSpan.TicksPerMillisecond));
            var rendererDelaySpan = TimeSpan.FromTicks((long)(rendererDelay * TimeSpan.TicksPerMillisecond));
            var runner = new MazeGenerationRunner(generator, renderer, true, generatorDelaySpan, rendererDelaySpan);
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
                /*Console.WriteLine("Generated steps: " + generatorSteps);
                Console.WriteLine("Rendered steps: " + rendererSteps);
                if (results.ResultsType == GenerationResultsType.GenerationCompleted)
                {
                    Console.WriteLine("Completed!");
                }*/
            };
            runner.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(MainPictureBox.Width, MainPictureBox.Height);
            MainPictureBox.Image = bitmap;

            var locked = new LockBitmap(bitmap);

            var sw = new Stopwatch();
            sw.Start();
            using (locked.LockBits())
            {
                for (int i = 0; i < MainPictureBox.Width; i++)
                {
                    for (int j = 0; j < MainPictureBox.Height; j++)
                    {
                        locked.SetPixel(i,j,Color.Blue);
                    }
                }
            }
            sw.Stop();
            MessageBox.Show(sw.Elapsed.TotalMilliseconds.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(MainPictureBox.Width, MainPictureBox.Height);
            MainPictureBox.Image = bitmap;

            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < MainPictureBox.Width; i++)
            {
                for (int j = 0; j < MainPictureBox.Height; j++)
                {
                    bitmap.SetPixel(i, j, Color.Red);
                }
            }
            sw.Stop();
            MessageBox.Show(sw.Elapsed.TotalMilliseconds.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var bitmap = new Bitmap(MainPictureBox.Width, MainPictureBox.Height);
            MainPictureBox.Image = bitmap;
            var graphics = Graphics.FromImage(bitmap);

            var sw = new Stopwatch();
            sw.Start();
            var size = 1;
            for (int i = 0; i < MainPictureBox.Width; i+= size)
            {
                for (int j = 0; j < MainPictureBox.Height; j+= size)
                {
                    graphics.FillRectangle(Brushes.Green, i, j, size, size);
                }
            }
            //graphics.FillRectangle(Brushes.Green, 100, 100, 400, 400);
            sw.Stop();
            MessageBox.Show(sw.Elapsed.TotalMilliseconds.ToString());
        }
    }
}
