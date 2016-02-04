using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Generator.Exceptions;
using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Generators.GameOfLife
{
    public class GameOfLifeGenerator : IMazeGenerator
    {
        public IMap Map { get; }

        public GameOfLifeGenerator(IMap map)
        {
            if (map.Dimensions != 2)
            {
                throw new IncorrectDimensionsException(2, map.Dimensions);
            }
            Map = map;
        }

        public MazeGenerationResults Generate()
        {
            throw new NotImplementedException();
        }
    }
}
