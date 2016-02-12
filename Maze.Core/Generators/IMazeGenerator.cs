using Maze.Core.Maps;
using Maze.Core.Results;

namespace Maze.Core.Generators
{
    public interface IMazeGenerator
    {
        IMap Map { get; }
        MazeGenerationResults Generate();
    }

}