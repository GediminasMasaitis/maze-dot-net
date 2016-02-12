using System;
using Maze.Core.Results;

namespace Maze.Core.Renderers
{
    public interface IMapRenderer: IDisposable
    {
        void Render(MazeGenerationResults results);
    }

}