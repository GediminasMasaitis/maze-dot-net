using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Core.Results;

namespace Maze.Core.Renderers.Decorators
{
    public class InstantAsFullMapRendererDecorator : IFullMapRenderer
    {
        public IInstantMapRenderer InstantMapRenderer { get; set; }
        public bool RenderEveryStep { get; set; }

        public InstantAsFullMapRendererDecorator(IInstantMapRenderer instantMapRenderer, bool renderEveryStep)
        {
            InstantMapRenderer = instantMapRenderer;
            RenderEveryStep = renderEveryStep;
        }

        public void Dispose()
        {
            InstantMapRenderer.Dispose();
        }

        public void RenderMap()
        {
            InstantMapRenderer.RenderMap();
        }

        public void RenderStep(MazeGenerationResults results)
        {
            if (RenderEveryStep || results.ResultsType == GenerationResultsType.GenerationCompleted)
            {
                InstantMapRenderer.RenderMap();
            }
        }
    }
}
