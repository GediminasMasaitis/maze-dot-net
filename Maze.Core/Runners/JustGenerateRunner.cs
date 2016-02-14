using Maze.Core.Generators;
using Maze.Core.Results;

namespace Maze.Core.Runners
{
    public class JustGenerateRunner
    {
        private IMazeGenerator Generator { get; }

        public JustGenerateRunner(IMazeGenerator generator)
        {
            Generator = generator;
        }

        public void GenerateCompletely()
        {
            MazeGenerationResults results;
            do
            {
                results = Generator.Generate();
            } while (results.ResultsType != GenerationResultsType.GenerationCompleted);
        }
    }
}
