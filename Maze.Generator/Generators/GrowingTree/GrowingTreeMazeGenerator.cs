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
                var startingCoord = MazeGenerationUtils.PickStartingPoint(Map, RNG);

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

            var offsets = MazeGenerationUtils.GenerateNewOffsets(Map);

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
    }
}