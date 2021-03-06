﻿namespace Maze.Core.Generators.Decorators
{
    public interface IMazeGeneratorDecorator : IMazeGeneratorDecorator<IMazeGenerator>
    {

    }

    public interface IMazeGeneratorDecorator<TMazeGenerator> : IMazeGenerator
        where TMazeGenerator : IMazeGenerator
    {
        TMazeGenerator InnerGenerator { get; }
    }
}