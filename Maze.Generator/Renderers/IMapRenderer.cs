using System;
using Maze.Generator.Results;

namespace Maze.Generator.Renderers
{
    public interface IMapRenderer: IDisposable
    {
        void Render(MazeGenerationResults results);
    }

}