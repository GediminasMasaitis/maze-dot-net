using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Maze.Generator.Cells;
using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Generators.Decorators
{
    public class ActiveCellsMazeGeneratorDecorator : ActiveCellsMazeGeneratorDecorator<IMazeGenerator>
    {
        public ActiveCellsMazeGeneratorDecorator(IMazeGenerator generator, bool alterMap = true) : base(generator, alterMap)
        {
        }
    }

    public class ActiveCellsMazeGeneratorDecorator<TMazeGenerator> : IMazeGenerator where TMazeGenerator : IMazeGenerator
    {
        public ActiveCellsMazeGeneratorDecorator(TMazeGenerator generator, bool alterMap = true)
        {
            Generator = generator;
            AlterMap = alterMap;
            AllResults = new List<IList<MazeGenerationResult>>();
        }

        public TMazeGenerator Generator { get; }
        public bool AlterMap { get; set; }
        public IMap Map => Generator.Map;

        private MazeGenerationResults LastResults { get; set; }

        public MazeGenerationResults Generate()
        {
            var results = Generator.Generate();
            var points = results.Results.Select(x => x.Point).ToList();

            var newResults = new MazeGenerationResults(results.ResultsType);
            foreach (var result in results.Results)
            {
                var newResult = new MazeGenerationResult(result.Point, result.State, CellDisplayState.Active);
                newResults.Results.Add(newResult);
            }

            if (LastResults != null)
            {
                var nonOverlapping = LastResults.Results.Where(x => !points.Contains(x.Point)).ToList();
                foreach (var result in nonOverlapping)
                {
                    var newResult = new MazeGenerationResult(result.Point, result.State, result.DisplayState);
                    newResults.Results.Add(newResult);
                }
            }

            LastResults = results;

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

            AllResults.Add(newResults.Results);
            return newResults;
        }

        private IList<IList<MazeGenerationResult>> AllResults { get; }
    }
}
