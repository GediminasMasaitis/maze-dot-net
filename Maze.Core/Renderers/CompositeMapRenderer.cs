using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Core.Results;

namespace Maze.Core.Renderers
{
    public class CompositeMapRenderer : IFullMapRenderer
    {
        public CompositeMapRenderer(params IFullMapRenderer[] renderers)
        {
            Renderers = renderers;
        }

        public IFullMapRenderer[] Renderers { get; set; }
        public void Dispose()
        {
            foreach (var renderer in Renderers)
            {
                renderer?.Dispose();
            }
        }

        public void RenderMap()
        {
            foreach (var renderer in Renderers)
            {
                renderer?.RenderMap();
            }
        }

        public void RenderStep(MazeGenerationResults results)
        {
            foreach (var renderer in Renderers)
            {
                renderer?.RenderStep(results);
            }
        }
    }
}
