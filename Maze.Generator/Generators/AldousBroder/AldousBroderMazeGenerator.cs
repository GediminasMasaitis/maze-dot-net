using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Generator.Cells;
using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Generators.AldousBroder
{
    public class AldousBroderMazeGenerator : IParametrizedMazeGenerator<AldousBroderMazeGeneratorParameters>
    {
        public IMap Map { get; private set; }
        private Random RNG { get; }
        public AldousBroderMazeGeneratorParameters GenerationParameters { get; set; }
        private Point CurrentPoint { get; set; }
        private HashSet<Point> RemainingPoints { get; set; }

        public AldousBroderMazeGenerator(IMap map, Random rng = null, AldousBroderMazeGeneratorParameters generationParameters = null)
        {
            SetMap(map);
            RNG = rng ?? new Random();
            GenerationParameters = generationParameters ?? new AldousBroderMazeGeneratorParameters();
        }

        private void SetMap(IMap map)
        {
            Map = map;
            if (!Map.Infinite)
            {
                RemainingPoints = new HashSet<Point>();
                for (var i = 1; i < Map.Size[0] - 1; i += 2)
                {
                    for (var j = 1; j < Map.Size[0] -1; j += 2)
                    {
                        var point = new Point(i,j);
                        RemainingPoints.Add(point);
                    }
                }
            }
        }

        public MazeGenerationResults Generate()
        {
            var results = new MazeGenerationResults();

            if (!Map.Infinite)
            {
                // TODO: Ending generation sometimes ends prematurely. Find out why and fix.
                if (RemainingPoints.Count == 0)
                {
                    results.ResultsType = GenerationResultsType.GenerationCompleted;
                    return results;
                }
            }

            if (CurrentPoint == null)
            {
                CurrentPoint = MazeGenerationUtils.PickStartingPoint(Map, RNG);
                var cell = Map.GetCell(CurrentPoint);

                cell.State = CellState.Empty;
                cell.DisplayState = CellDisplayState.Path;

                results.Add(new MazeGenerationResult(CurrentPoint, cell.State, cell.DisplayState));
                return results;
            }

            var doLooping = RNG.NextDouble() < GenerationParameters.Looping;
            var offsets = MazeGenerationUtils.GenerateNewOffsets(Map);

            Point pathToCellPoint = null;
            Point otherCellPoint = null;
            while (offsets.Count > 0)
            {
                var offsetIndex = RNG.Next(0, offsets.Count);
                var offset = offsets[offsetIndex];
                pathToCellPoint = CurrentPoint + offset;
                otherCellPoint = CurrentPoint + offset*2;
                var cellExists = Map.CellExists(otherCellPoint);
                if (cellExists)
                {
                    break;
                }
                offsets.RemoveAt(offsetIndex);
            }

            var otherCell = Map.GetCell(otherCellPoint);
            var pathToCell = Map.GetCell(pathToCellPoint);

            if (doLooping || otherCell.State == CellState.Filled)
            {
                otherCell.State = CellState.Empty;
                pathToCell.State = CellState.Empty;
            }

            RemainingPoints.Remove(otherCellPoint);

            otherCell.DisplayState = otherCell.State == CellState.Empty ? CellDisplayState.Path : CellDisplayState.Wall;
            pathToCell.DisplayState = pathToCell.State == CellState.Empty ? CellDisplayState.Path : CellDisplayState.Wall;

            var otherResult = new MazeGenerationResult(otherCellPoint, otherCell.State, otherCell.DisplayState);
            var pathResult = new MazeGenerationResult(pathToCellPoint, pathToCell.State, pathToCell.DisplayState);

            results.Results.Add(otherResult);
            results.Results.Add(pathResult);

            CurrentPoint = otherCellPoint;

            return results;
            
        }
    }
}
