﻿using System;
using System.Collections.Generic;
using Maze.Core.Cells;
using Maze.Core.Common;
using Maze.Core.Exceptions;
using Maze.Core.Maps;
using Maze.Core.Results;

namespace Maze.Core.Generators.Kruskal
{
    public class KruskalMazeGenerator : MazeGeneratorBase
    {
        public KruskalMazeGenerator(IMap map, Random random = null) : base(map, random)
        {
        }

        private ConnectingTree<Point> Tree { get; set; }
        private LinkedList<Point> Walls { get; set; }

        private IMap _map;
        public override IMap Map
        {
            get => _map;
            protected set
            {
                if (value.Infinite)
                {
                    throw new IncorrectFinityException(false, value.Infinite);
                }
                if (value.Dimensions != 2)
                {
                    // TODO: Make it do all dimensions, if possible.
                    throw new IncorrectDimensionsException(new[] { 2 }, value.Dimensions);
                }
                _map = value;
                Tree = new ConnectingTree<Point>(true);
                Walls = GenerateWallsLinkedList(value);
                Walls.Shuffle();
            }
        }

        public bool ShowAllWallChecking { get; set; }

        private double _looping;
        public double Looping
        {
            get => _looping;
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Value must be between 0 and 1");
                }
                _looping = value;
            }
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


        public override MazeGenerationResults Generate()
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

            var wallA = new Point(wall[0] - x, wall[1] - y);
            var wallB = new Point(wall[0] + x, wall[1] + y);
            var connected = Tree.AreConnected(wallA, wallB);

            var loop = RNG.NextDouble() < Looping;

            var wallPoint = new Point(wall[0], wall[1]);
            var wallCell = Map.GetCell(wallPoint);
            if (loop || !connected)
            {
                
                var sidePoint1 = new Point(wall[0] - x, wall[1] - y);
                var sidePoint2 = new Point(wall[0] + x, wall[1] + y);

                
                var sideCell1 = Map.GetCell(sidePoint1);
                var sideCell2 = Map.GetCell(sidePoint2);

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
                    Tree.Connect(wallA, wallB);
                }

            }
            else
            {
                if (ShowAllWallChecking)
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
