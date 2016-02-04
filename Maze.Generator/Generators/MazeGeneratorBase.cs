using System;
using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Generators
{
    public abstract class MazeGeneratorBase : IMazeGenerator
    {
        public MazeGeneratorBase(IMap map, Random random = null)
        {
            Map = map;
            RNG = random ?? new Random();
        }
        protected Random RNG { get; }
        public IMap Map { get; }

        public abstract MazeGenerationResults Generate();
    }
}