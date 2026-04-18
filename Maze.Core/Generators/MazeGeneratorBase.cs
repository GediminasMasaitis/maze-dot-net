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
            RNG = random ?? new Random();
            Map = map;
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

        protected static Point PickStartingPoint(IMap map, Random rng = null)
        {
            if (rng == null)
            {
                rng = new Random();
            }
            Point startingCoord;
            if (map.Infinite)
            {
                startingCoord = Point.CreateSameAllDimensions(map.Dimensions, 0);
            }
            else
            {
                var corner1 = Point.CreateSameAllDimensions(map.Dimensions, 1);
                var corner2 = map.Size;
                startingCoord = PickRandomPointBetweenTwoPoints(map, corner1, corner2, rng);
            }
            return startingCoord;
        }

        private static Point PickRandomPointBetweenTwoPoints(IMap map, Point corner1, Point corner2, Random rng = null)
        {
            if (map.Dimensions != corner1.Dimensions)
            {
                throw new ArgumentException("Point dimensions doesn't match map dimensions", nameof(corner1));
            }
            if (map.Dimensions != corner2.Dimensions)
            {
                throw new ArgumentException("Point dimensions doesn't match map dimensions", nameof(corner2));
            }
            if (rng == null)
            {
                rng = new Random();
            }
            var coords = new int[map.Dimensions];
            for (var i = 0; i < map.Dimensions; i++)
            {
                coords[i] = rng.Next(corner1[i], corner2[i] / 2) * 2 - 1;
            }
            var resultCoord = new Point(coords);
            return resultCoord;
        }

        public abstract MazeGenerationResults Generate();
    }
}