using System;
using Maze.Core.Results;

namespace Maze.Core.Renderers
{
    public interface IContinuousMapRenderer : IDisposable
    {
        void RenderStep(MazeGenerationResults results);
    }
}