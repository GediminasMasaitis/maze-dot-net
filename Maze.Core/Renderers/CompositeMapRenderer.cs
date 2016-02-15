using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Core.Results;

namespace Maze.Core.Renderers
{
    public class CompositeMapRenderer : IMapRenderer
    {
        public CompositeMapRenderer(params IMapRenderer[] renderers)
        {
            Renderers = renderers;
        }

        public IMapRenderer[] Renderers { get; set; }
        public void Dispose()
        {
            foreach (var renderer in Renderers)
            {
                renderer.Dispose();
            }
        }

        public void Render(MazeGenerationResults results)
        {
            foreach (var renderer in Renderers)
            {
                renderer.Render(results);
            }
        }
    }
}
