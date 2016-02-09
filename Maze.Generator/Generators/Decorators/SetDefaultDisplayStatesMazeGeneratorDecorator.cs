using System;
using Maze.Generator.Cells;
using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Generators.Decorators
{
    public class SetDefaultDisplayStatesMazeGeneratorDecorator : SetDefaultDisplayStatesMazeGeneratorDecorator<IMazeGenerator>
    {
        public SetDefaultDisplayStatesMazeGeneratorDecorator(IMazeGenerator generator) : base(generator)
        {
        }
    }

    public class SetDefaultDisplayStatesMazeGeneratorDecorator<TMazeGenerator> : IMazeGeneratorDecorator<TMazeGenerator>
        where TMazeGenerator : IMazeGenerator
    {
        public SetDefaultDisplayStatesMazeGeneratorDecorator(TMazeGenerator generator)
        {
            InnerGenerator = generator;
        }

        public TMazeGenerator InnerGenerator { get; }
        public IMap Map => InnerGenerator.Map;

        public MazeGenerationResults Generate()
        {
            var results = InnerGenerator.Generate();
            foreach (var result in results.Results)
            {
                if (result.DisplayState != CellDisplayState.Unspecified)
                {
                    continue;
                }
                switch (result.State)
                {
                    case CellState.Filled:
                        result.DisplayState = CellDisplayState.Path;
                        break;
                    case CellState.Empty:
                        result.DisplayState = CellDisplayState.Wall;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            foreach (var result in results.Results)
            {
                var point = result.Point;
                var cell = InnerGenerator.Map.GetCell(point);
                cell.DisplayState = result.DisplayState;
            }
            return results;
        }
    }
}