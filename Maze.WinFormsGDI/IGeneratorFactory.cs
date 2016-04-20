using System;
using System.Collections.Generic;
using Maze.Core.Generators;
using Maze.Core.Maps;

namespace Maze.WinFormsGDI
{
    interface IGeneratorFactory
    {
        IEnumerable<MazeGenerationAlgorithm> GetAvailableAlgorithms();
        IMazeGenerator GetGenerator(MazeGenerationAlgorithm algorithm, IMap map, Random rng = null);
    }
}