using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maze.Generator;
using Maze.Generator.Generators;
using Maze.Generator.Generators.Decorators;
using Maze.Generator.Generators.GrowingTree;
using Maze.Generator.Generators.Kruskal;
using Maze.Generator.Maps;
using Maze.Generator.Results;
using OpenTK.Graphics.OpenGL;

namespace Maze.WinFormsOpenTK
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private bool Loaded { get; set; }

        private void MainGLControl_Load(object sender, EventArgs e)
        {
            Loaded = true;
        }



        private IMap Map;
        private IMazeGenerator MazeGenerator;
        private GLControlMapRenderer MapRenderer;

        private async void GenerateButton_Click(object sender, EventArgs e)
        {
            if (!Loaded)
            {
                return;
            }
            Map = new FiniteMap2D(199,199);
            //Map = new FiniteMap2D(49, 49);
            //Map = new InfiniteMapDecorator(Map);
            //Map = new InfiniteMap(2);

            //var kruskalGenerator = new KruskalMazeGenerator(Map);
            //kruskalGenerator.GenerationParameters.Looping = 0;

            var growingTreeGenerator = new GrowingTreeMazeGenerator(Map);

            var activeGenerator = new ActiveCellsMazeGeneratorDecorator(growingTreeGenerator);
            MazeGenerator = activeGenerator;
            
            if (MapRenderer == null)
            {
                MapRenderer = new GLControlMapRenderer(MainGLControl, Map);
            }
            else
            {
                MapRenderer.SetMap(Map);
            }
            
            //var runner = new Ma
        }

    }
}
