using System.Collections.Generic;
using System.Linq;
using Maze.Core.Cells;
using Maze.Core.Maps;
using Maze.Core.Results;

namespace Maze.Core.Generators.Decorators
{
    public class ActiveCellsMazeGeneratorDecorator : ActiveCellsMazeGeneratorDecorator<IMazeGenerator>
    {
        public ActiveCellsMazeGeneratorDecorator(IMazeGenerator innerGenerator, int activeForSteps = 1, bool alterMap = true) : base(innerGenerator, activeForSteps, alterMap)
        {
        }
    }

    public class ActiveCellsMazeGeneratorDecorator<TMazeGenerator> : IMazeGeneratorDecorator<TMazeGenerator>
        where TMazeGenerator : IMazeGenerator
    {
        public ActiveCellsMazeGeneratorDecorator(TMazeGenerator generator, int activeForSteps = 1, bool alterMap = true)
        {
            InnerGenerator = generator;
            ActiveForSteps = activeForSteps;
            AlterMap = alterMap;
            PreviousResults = new Queue<MazeGenerationResults>();
        }

        public TMazeGenerator InnerGenerator { get; }
        public int ActiveForSteps { get; set; }
        public bool AlterMap { get; set; }
        public IMap Map => InnerGenerator.Map;
        private Queue<MazeGenerationResults> PreviousResults { get; set; }

        public MazeGenerationResults Generate()
        {
            var results = InnerGenerator.Generate();
            var points = results.Results.Select(x => x.Point).ToList();

            var newResults = new MazeGenerationResults(results.ResultsType);
            foreach (var result in results.Results)
            {
                var newResult = new MazeGenerationResult(result.Point, result.State, CellDisplayState.Active);
                newResults.Results.Add(newResult);
            }

            if (PreviousResults.Count >= ActiveForSteps)
            {
                var previousResult = PreviousResults.Dequeue();
                while (PreviousResults.Count >= ActiveForSteps)
                {
                    var otherResult = PreviousResults.Dequeue();
                    previousResult = MazeGenerationResults.Merge(new []{previousResult, otherResult}, true);
                }
                var nonOverlapping = previousResult.Results.Where(x => !points.Contains(x.Point)).ToList();
                foreach (var result in nonOverlapping)
                {
                    var newResult = new MazeGenerationResult(result.Point, result.State, result.DisplayState);
                    newResults.Results.Add(newResult);
                }
            }

            PreviousResults.Enqueue(results);

            // TODO: if generation ended, get all results from queue

            if (AlterMap)
            {
                foreach (var result in newResults.Results)
                {
                    if (Map.CellExists(result.Point))
                    {
                        var cell = Map.GetCell(result.Point);
                        cell.DisplayState = result.DisplayState;
                    }
                }
            }

            return newResults;
        }

    }
}
