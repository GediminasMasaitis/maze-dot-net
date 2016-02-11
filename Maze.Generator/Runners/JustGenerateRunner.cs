using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Generator.Generators;
using Maze.Generator.Results;

namespace Maze.Generator.Runners
{
    class JustGenerateRunner
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
