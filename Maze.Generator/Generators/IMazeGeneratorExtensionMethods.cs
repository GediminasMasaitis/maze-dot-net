using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Generator.Runners;

namespace Maze.Generator.Generators
{
    public static class MazeGeneratorExtensionMethods
    {
        public static void GenerateCompletely(this IMazeGenerator generator)
        {
            var runner = new JustGenerateRunner(generator);
            runner.GenerateCompletely();
        }
    }
}
