using System.Collections.Generic;
using System.Linq;
using Maze.Core.Cells;
using Maze.Core.Common;
using Maze.Core.Exceptions;
using Maze.Core.Maps;
using Maze.Core.Results;

namespace Maze.Core.Generators.GameOfLife
{
    public class GameOfLifeGenerator : IMazeGenerator
    {
        public IMap Map => InnerMap;

        public NonCreatingInfiniteMap InnerMap { get; }

        public HashSet<int> DieIf { get; set; }
        public HashSet<int> BornIf { get; set; }

        public GameOfLifeGenerator(NonCreatingInfiniteMap map)
        {
            if (map.Dimensions != 2)
            {
                throw new IncorrectDimensionsException(new [] { 2 }, map.Dimensions);
            }
            InnerMap = map;
            DieIf = new HashSet<int> { 0, 1, 4, 5, 6, 7, 8 };
            BornIf = new HashSet<int> { 3 };
        }

        public MazeGenerationResults Generate()
        {
            var results = new MazeGenerationResults();
            var targets = new Dictionary<Point, bool>();
            var offsets = new Point(new int[2]).GetAllOffsets();

            foreach (var cell in InnerMap.Cells)
            {
                var cellNeighbors = offsets.Select(x => x + cell.Key);
                foreach (var cellNeighbor in cellNeighbors)
                {
                    var neighborIsAlive = Map.CellExists(cellNeighbor);
                    targets[cellNeighbor] = neighborIsAlive;
                }
                targets[cell.Key] = true;
            }

            foreach (var target in targets)
            {
                var targetNeighbours = offsets.Select(x => x + target.Key);
                var aliveTargetNeighbours = offsets.Where(x => Map.CellExists(x));
                var aliveNeighbourCount = aliveTargetNeighbours.Count();

                if (target.Value) // Alive
                {
                    if (DieIf.Contains(aliveNeighbourCount))
                    {
                        InnerMap.RemoveCell(target.Key);
                        results.Results.Add(new MazeGenerationResult(target.Key, CellState.Empty, CellDisplayState.Path));
                    }
                }
                else // Dead
                {
                    if (BornIf.Contains(aliveNeighbourCount))
                    {
                        InnerMap.SetCell(new Cell(CellState.Filled, CellDisplayState.Wall), target.Key);
                        results.Results.Add(new MazeGenerationResult(target.Key, CellState.Filled, CellDisplayState.Wall));
                    }
                }
            }
            return results;
        }
    }
}
