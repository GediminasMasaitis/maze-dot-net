using System;
using Maze.Core.Exceptions;
using Maze.Core.Maps;
using Maze.Core.Results;

namespace Maze.Core.Generators.RecursiveDivision
{
    class RecursiveDivisionMazeGenerator : MazeGeneratorBase
    {
        public RecursiveDivisionMazeGenerator(IMap map, Random random = null) : base(map, random)
        {

        }

        private IMap _map;
        public override IMap Map
        {
            get { return _map; }
            protected set
            {
                if (value.Infinite)
                {
                    throw new IncorrectFinityException(false, value.Infinite);
                }
                if (value.Dimensions != 2)
                {
                    // TODO: Make possible on all dimensions. On a 3D map, instead of walls generate planes and punch a hole..
                    throw new IncorrectDimensionsException(new[] { 2 }, value.Dimensions);
                }
                _map = value;
            }
        }

        public override MazeGenerationResults Generate()
        {
            var results = new MazeGenerationResults();
            return results;
        }
    }
}
