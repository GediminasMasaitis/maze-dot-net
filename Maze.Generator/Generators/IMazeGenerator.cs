using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Generators
{
    public interface IMazeGenerator
    {
        IMap Map { get; }
        MazeGenerationResults Generate();
    }

}