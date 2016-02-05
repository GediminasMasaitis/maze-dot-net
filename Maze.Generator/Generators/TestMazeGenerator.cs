using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Generator.Cells;
using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Generators
{
    public class TestMazeGenerator : MazeGeneratorBase
    {
        public Queue<MazeGenerationResults> ResultsQueue { get; set; }
        

        public TestMazeGenerator(IMap map, Random random = null) : base(map, random)
        {
            ResultsQueue = new Queue<MazeGenerationResults>();

            var results = new MazeGenerationResults();
            A(results, 5,5);
            A(results, 5,6);
            ResultsQueue.Enqueue(results);

            results = new MazeGenerationResults();
            A(results, 5, 7);
            A(results, 5, 8);
            ResultsQueue.Enqueue(results);

            results = new MazeGenerationResults();
            A(results, 5, 7);
            A(results, 5, 6);
            ResultsQueue.Enqueue(results);

            results = new MazeGenerationResults();
            A(results, 6, 6);
            A(results, 7, 6);
            ResultsQueue.Enqueue(results);
        }

        private void A(MazeGenerationResults results, int x, int y, CellState state = CellState.Empty, CellDisplayState displayState = CellDisplayState.Path)
        {
            var point = new Point(x,y);
            //var cell = Map.GetCell(point);
            //cell.State = state;
            //cell.DisplayState = displayState;
            var result = new MazeGenerationResult(point, state, displayState);
            results.Add(result);
        }

        public override MazeGenerationResults Generate()
        {
            if (ResultsQueue.Count > 0)
            {
                var results =  ResultsQueue.Dequeue();
                foreach (var result in results.Results)
                {
                    var cell = Map.GetCell(result.Point);
                    cell.State = result.State;
                    cell.DisplayState = result.DisplayState;
                }
                return results;
            }
            else
            {
                return new MazeGenerationResults(GenerationResultsType.GenerationCompleted);
            }
        }
    }
}
