using System;
using Maze.Core.Cells;
using Maze.Core.Common;
using Maze.Core.Maps;
using Maze.Core.Results;

namespace Maze.Core.Generators
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

        // ReSharper disable once UnusedParameter.Global
        protected void DoubleParameterCheck(double parameter, double minValue = 0, double maxValue = 1)
        {
            if (parameter < minValue || parameter > maxValue)
            {
                throw new ArgumentException("Value must be between " + minValue + " and " + maxValue);
            }
        }

        protected void ChangeCell(MazeGenerationResults results, Point point, CellState state, CellDisplayState displayState)
        {
            var cell = Map.GetCell(point);
            ChangeCell(results, point, cell, state, displayState);
        }

        protected void ChangeCell(MazeGenerationResults results, Point point, ICell cell, CellState state, CellDisplayState displayState)
        {
            cell.State = state;
            cell.DisplayState = displayState;
            var result = new MazeGenerationResult(point, state, displayState);
            results?.Add(result);
        }

        public abstract MazeGenerationResults Generate();
    }
}