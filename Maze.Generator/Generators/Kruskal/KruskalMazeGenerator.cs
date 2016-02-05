using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Generator.Cells;
using Maze.Generator.Exceptions;
using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Generators.Kruskal
{
    public class KruskalMazeGenerator : IParametrizedMazeGenerator<KruskalMazeGeneratorParameters>
    {
        public KruskalMazeGenerator(IMap map, KruskalMazeGeneratorParameters generationParameters = null, Random random = null)
        {
            SetMap(map);
            RNG = random ?? new Random();
            GenerationParameters = generationParameters ?? new KruskalMazeGeneratorParameters();
        }

        private Random RNG { get; }
        public IMap Map { get; private set; }
        private KruskalTree Tree { get; set; }
        private LinkedList<Point> Walls { get; set; }

        public KruskalMazeGeneratorParameters GenerationParameters { get; set; }

        public void SetMap(IMap map)
        {
            if (map.Infinite)
            {
                throw new MapInfiniteException("Kruskal maze generation algorithm doesn't support infinite maps", false, map.Infinite);
            }
            if (map.Dimensions != 2)
            {
                // For now
                throw new IncorrectDimensionsException(expectedDimensions: 2, foundDimensions: map.Dimensions, message: "Kruskal maze generation algorithm requires 2D maps");
            }
            Tree = new KruskalTree(map.Size[0], map.Size[1]);
            Map = map;

            Walls = GenerateWallsLinkedList(Map);
            Walls.Shuffle();
        }

        private LinkedList<Point> GenerateWallsLinkedList(IMap map)
        {
            var walls = new LinkedList<Point>();
            for (var i = 1; i < map.Size[0] - 1; i++)
            {
                var extra = i%2 == 0 ? 1 : 0;
                for (var j = 2 - extra; j < map.Size[1] - 2 + extra; j += 2)
                {
                    var point = new Point(i, j);
                    var cell = map.GetCell(point);
                    var state = cell.State;
                    if (state == CellState.Filled)
                    {
                        walls.AddLast(point);
                    }
                }
            }
            return walls;
        }


        public MazeGenerationResults Generate()
        {
            var results = new MazeGenerationResults(GenerationResultsType.Success);
            if (Walls.Count == 0)
            {
                results.ResultsType = GenerationResultsType.GenerationCompleted;
                return results;
            }

            var wall = Walls.First.Value;
            Walls.RemoveFirst();
            var x = 0;
            var y = 0;
            if (wall[0]%2 == 0 && wall[1]%2 == 1)
            {
                x = 1;
            }
            else if (wall[0]%2 == 1 && wall[1]%2 == 0)
            {
                y = 1;
            }

            var connected = Tree.AreConnected(wall[0] - x, wall[1] - y, wall[0] + x, wall[1] + y);

            var loop = RNG.NextDouble() < GenerationParameters.Looping;

            var wallPoint = new Point(wall[0], wall[1]);
            var wallCell = Map.GetCell(wallPoint);
            if (loop || !connected)
            {
                
                var sidePoint1 = new Point(wall[0] - x, wall[1] - y);
                var sidePoint2 = new Point(wall[0] + x, wall[1] + y);

                
                var sideCell1 = Map.GetCell(sidePoint1);
                var sideCell2 = Map.GetCell(sidePoint2);

                //results.Add(new MazeGenerationResult(wallPoint, wallCell.State, CellDisplayState.Path));
                //results.Add(new MazeGenerationResult(sidePoint1, sideCell1.State, CellDisplayState.Path));
                //results.Add(new MazeGenerationResult(sidePoint2, sideCell2.State, CellDisplayState.Path));

                wallCell.State = CellState.Empty;
                sideCell1.State = CellState.Empty;
                sideCell2.State = CellState.Empty;

                wallCell.DisplayState = CellDisplayState.Path;
                sideCell1.DisplayState = CellDisplayState.Path;
                sideCell2.DisplayState = CellDisplayState.Path;

                results.Add(new MazeGenerationResult(wallPoint, wallCell.State, wallCell.DisplayState));
                results.Add(new MazeGenerationResult(sidePoint1, sideCell1.State, sideCell1.DisplayState));
                results.Add(new MazeGenerationResult(sidePoint2, sideCell2.State, sideCell2.DisplayState));

                if (!connected)
                {
                    Tree.Connect(wall[0] - x, wall[1] - y, wall[0] + x, wall[1] + y);
                }

                //DrawCell(wall.X - x, wall.Y - y, MazeColors.Walkway.Brush);
                //DrawCell(wall.X, wall.Y, MazeColors.Walkway.Brush);
                //DrawCell(wall.X + x, wall.Y + y, MazeColors.Walkway.Brush);


            }
            else
            {
                if (GenerationParameters.ShowAllWallChecking)
                {
                    results.Add(new MazeGenerationResult(wallPoint, wallCell.State, wallCell.DisplayState));
                }
                else
                {
                    return Generate();
                }
            }

            return results;
        }
    }
}
