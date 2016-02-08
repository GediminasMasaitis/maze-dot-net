# Maze.NET
An extensive library for generating maze models, and rendering them to different targets.

## Code example
```csharp
IMap map = new FiniteMap2D(49,49);
IMazeGenerator generator = new GrowingTreeMazeGenerator(map);
IMapRenderer = new ConsoleMapRenderer(map);
var runner = new MazeGenerationRunner(generator, renderer);
runner.Start(); 
```