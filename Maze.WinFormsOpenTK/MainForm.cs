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
using Maze.Core.Generators;
using Maze.Core.Generators.Decorators;
using Maze.Core.Generators.GrowingTree;
using Maze.Core.Maps;
using Maze.Core.Runners;
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

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            if (!Loaded)
            {
                return;
            }
            var map = new FiniteMap2D(49,49);
            var growingTreeGenerator = new GrowingTreeMazeGenerator(map);
            var activeGenerator = new ActiveCellsMazeGeneratorDecorator(growingTreeGenerator);
            var renderer = new GLControlMapRenderer(MainGLControl, map);
            var runner = new MazeGenerationRunner(activeGenerator, renderer);
            runner.Start();
        }

    }
}
