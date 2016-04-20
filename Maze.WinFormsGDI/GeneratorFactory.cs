using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Core.Generators;
using Maze.Core.Generators.AldousBroder;
using Maze.Core.Generators.BinaryTree;
using Maze.Core.Generators.GrowingTree;
using Maze.Core.Generators.Kruskal;
using Maze.Core.Generators.RecursiveDivision;
using Maze.Core.Maps;

namespace Maze.WinFormsGDI
{
    class GeneratorFactory : IGeneratorFactory
    {
        public IMazeGenerator GetGenerator(MazeGenerationAlgorithm algorithm, IMap map, Random rng = null)
        {
            switch (algorithm)
            {
                case MazeGenerationAlgorithm.GrowingTree:
                    return new GrowingTreeMazeGenerator(map, rng);
                case MazeGenerationAlgorithm.Kruskal:
                    return new KruskalMazeGenerator(map, rng);
                case MazeGenerationAlgorithm.RecursiveDivision:
                    return new RecursiveDivisionMazeGenerator(map, rng);
                case MazeGenerationAlgorithm.BinaryTree:
                    return new BinaryTreeMazeGenerator(map, rng);
                case MazeGenerationAlgorithm.AldousBroder:
                    return new AldousBroderMazeGenerator(map, rng);
                default:
                    throw new ArgumentOutOfRangeException(nameof(algorithm), algorithm, null);
            }
        }

        public IEnumerable<MazeGenerationAlgorithm> GetAvailableAlgorithms()
        {
            var values = Enum.GetValues(typeof (MazeGenerationAlgorithm));
            return values.Cast<MazeGenerationAlgorithm>();
        }
    }
}
