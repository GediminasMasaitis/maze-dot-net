using System;
using System.Collections.Generic;
using Maze.Generator.Cells;
using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Generators.GrowingTree
{
    public class GrowingTreeMazeGenerator : MazeGeneratorBase, IParametrizedMazeGenerator<GrowingTreeMazeGeneratorParameters>
    {
        public GrowingTreeMazeGenerator(IMap map, GrowingTreeMazeGeneratorParameters parameters = null) : base(map)
        {
            //Path = new LinkedList<Point>();
            Path = new List<Point>();
            New = true;
            GenerationParameters = parameters ?? new GrowingTreeMazeGeneratorParameters();
        }

        //public LinkedList<Point> Path { get; }
        public List<Point> Path { get; }

        public bool New { get; private set; }

        public GrowingTreeMazeGeneratorParameters GenerationParameters { get; set; }

        public override MazeGenerationResults Generate()
        {
            var results = new MazeGenerationResults(GenerationResultsType.Success);
            if (Path.Count == 0)
            {
                Point startingCoord;
                if (Map.Infinite)
                {
                    startingCoord = Point.CreateSameAllDimensions(Map.Dimensions, 0);
                }
                else
                {
                    var corner1 = Point.CreateSameAllDimensions(Map.Dimensions, 1);
                    var corner2 = Map.Size;
                    startingCoord = CreateRandomCoordinate(corner1, corner2);
                }

                Path.Add(startingCoord);
                var cell = Map.GetCell(startingCoord);
                //cell.State = CellDisplayState.Path;
                cell.State = CellState.Empty;
                cell.DisplayState = CellDisplayState.Path;

                var change = new MazeGenerationResult(startingCoord, cell.State, cell.DisplayState);

                results.Add(change);
                New = false;
                return results;
            }

            var doBreadth = RNG.NextDouble() < GenerationParameters.Breadth;
            var doFirstChanceLooping = RNG.NextDouble() < GenerationParameters.FirstChanceLooping;
            var doLastChanceLooping = RNG.NextDouble() < GenerationParameters.LastChanceLooping;

            var currentCoordinateIndex = doBreadth && Path.Count > 1 ? RNG.Next(1, Path.Count/2+1)*2 : Path.Count - 1;
            var currentCoordinate = Path[currentCoordinateIndex];

            var offsets = GenerateNewOffsets();

            while (offsets.Count > 0)
            {
                var offsetIndex = RNG.Next(0, offsets.Count);
                var offset = offsets[offsetIndex];
                var pathToCellCoord = currentCoordinate + offset;
                var otherCellCoord = currentCoordinate + (offset*2);
                var cellExists = Map.CellExists(otherCellCoord);
                if (!cellExists)
                {
                    offsets.RemoveAt(offsetIndex);
                    continue;
                }
                var cell = Map.GetCell(otherCellCoord);
                if (!doFirstChanceLooping && cell.State != CellState.Filled)
                {
                    offsets.RemoveAt(offsetIndex);
                    continue;
                }

                var otherCell = Map.GetCell(otherCellCoord);
                var pathToCell = Map.GetCell(pathToCellCoord);

                otherCell.State = CellState.Empty;
                pathToCell.State = CellState.Empty;

                otherCell.DisplayState = CellDisplayState.PathWillReturn;
                pathToCell.DisplayState = CellDisplayState.PathWillReturn;

                var otherResult = new MazeGenerationResult(otherCellCoord, otherCell.State, otherCell.DisplayState);
                var pathResult = new MazeGenerationResult(pathToCellCoord, pathToCell.State, pathToCell.DisplayState);

                results.Results.Add(otherResult);
                results.Results.Add(pathResult);

                Path.Push(pathToCellCoord);
                Path.Push(otherCellCoord);

                return results;
            }

            if (Path.Count <= 1)
            {
                results.ResultsType = GenerationResultsType.GenerationCompleted;
                return new MazeGenerationResults(GenerationResultsType.GenerationCompleted);
            }

            if (currentCoordinateIndex != 0)
            {
                var lastCoord = Path[currentCoordinateIndex];
                Path.RemoveAt(currentCoordinateIndex);
                var lastCell = Map.GetCell(lastCoord);
                lastCell.DisplayState = CellDisplayState.Path;
                var lastResult = new MazeGenerationResult(lastCoord, lastCell.State, lastCell.DisplayState);
                results.Results.Add(lastResult);


                var secondLastCoord = Path[currentCoordinateIndex - 1];
                Path.RemoveAt(currentCoordinateIndex - 1);
                var secondLastCell = Map.GetCell(secondLastCoord);
                secondLastCell.DisplayState = CellDisplayState.Path;
                var secondLastResult = new MazeGenerationResult(secondLastCoord, secondLastCell.State, secondLastCell.DisplayState);
                results.Results.Add(secondLastResult);
            }
            return results;
        }

        private Point CreateRandomCoordinate(Point corner1, Point corner2)
        {
            if (Map.Dimensions != corner1.Dimensions)
            {
                throw new ArgumentException("Point dimensions doesn't match map dimensions", nameof(corner1));
            }
            if (Map.Dimensions != corner2.Dimensions)
            {
                throw new ArgumentException("Point dimensions doesn't match map dimensions", nameof(corner2));
            }

            var coords = new int[Map.Dimensions];
            for (var i = 0; i < Map.Dimensions; i++)
            {
                coords[i] = RNG.Next(corner1[i], corner2[i] / 2) * 2 - 1;
            }
            var resultCoord = new Point(coords);
            return resultCoord;
        }

        private List<Point> GenerateNewOffsets()
        {
            var offsets = new List<Point>();

            for (var i = 0; i < Map.Dimensions; i++)
            {
                var coordinateNegative = Point.CreateSameAllDimensions(Map.Dimensions, 0);
                coordinateNegative[i] = -1;
                offsets.Add(coordinateNegative);

                var coordinatePositive = Point.CreateSameAllDimensions(Map.Dimensions, 0);
                coordinatePositive[i] = 1;
                offsets.Add(coordinatePositive);
            }
            return offsets;
        }

    }
}