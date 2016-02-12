using Maze.Core.Runners;

namespace Maze.Core.Generators
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
