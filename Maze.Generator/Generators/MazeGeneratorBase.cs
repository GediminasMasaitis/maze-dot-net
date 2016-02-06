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
        public virtual IMap Map { get; protected set; }

        protected void DoubleParameterCheck(double parameter)
        {
            if (parameter < 0 || parameter > 1)
            {
                throw new ArgumentException("Value must be between 0 and 1");
            }
        }

        public abstract MazeGenerationResults Generate();
    }
}