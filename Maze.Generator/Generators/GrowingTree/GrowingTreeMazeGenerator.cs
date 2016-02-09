using System;
using System.Collections.Generic;
using System.Linq;
using Maze.Generator.Cells;
using Maze.Generator.Common;
using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Generators.GrowingTree
{
    public class GrowingTreeMazeGenerator : MazeGeneratorBase
    {
        public GrowingTreeMazeGenerator(IMap map, Random rng = null) : base(map, rng)
        {
            //Path = new LinkedList<Point>();
            TreeCount = 1;
            Biases = Enumerable.Repeat(1d, map.Dimensions*2).ToArray();
            Runs = Enumerable.Repeat(1d, map.Dimensions*2).ToArray();
        }

        private IList<Tree> RunningTrees { get; set; }
        private IList<Tree> StoppedTrees { get; set; }

        private enum MyEnum
        {
            
        }

        private class Tree
        {
            public Tree()
            {
                Path = new List<Point>();
            }
            public List<Point> Path { get; }
            public Point LastOffset { get; set; }
        }

        private IMap _map;
        public override IMap Map
        {
            get { return _map; }
            protected set
            {
                _map = value;
            }
        }

        public int TreeCount { get; set; }
        public double[] Biases { get; }
        public double[] Runs { get; }

        private double _breadth;
        public double Breadth
        {
            get { return _breadth; }
            set
            {
                DoubleParameterCheck(value);
                _breadth = value;
            }
        }

        private double _firstChanceLooping;
        public double FirstChanceLooping
        {
            get { return _firstChanceLooping; }
            set
            {
                DoubleParameterCheck(value);
                _firstChanceLooping = value;
            }
        }

        private double _lastChanceLooping;
        public double LastChanceLooping
        {
            get { return _lastChanceLooping; }
            set
            {
                DoubleParameterCheck(value);
                _lastChanceLooping = value;
            }
        }

        private double _goBackAfterLooping;
        public double GoBackAfterLooping
        {
            get { return _goBackAfterLooping; }
            set
            {
                DoubleParameterCheck(value);
                _goBackAfterLooping = value;
            }
        }

        private double _blocking;
        public double Blocking
        {
            get { return _blocking; }
            set
            {
                DoubleParameterCheck(value);
                _blocking = value;
            }
        }

        private bool LastLooped { get; set; }
        private int CurrentLoop { get; set; }
        public override MazeGenerationResults Generate()
        {
            var results = new MazeGenerationResults();
            if (CurrentLoop == 0)
            {
                RunningTrees = new List<Tree>();
                StoppedTrees = new List<Tree>();
                for (var i = 0; i < TreeCount; i++)
                {
                    var newTree = new Tree();
                    RunningTrees.Add(newTree);
                }
            }

            var treeIndex = CurrentLoop%RunningTrees.Count;
            var tree = RunningTrees[treeIndex];
            var path = tree.Path;
            CurrentLoop++;
            if (path.Count == 0)
            {
                var startingPoint = MazeGenerationUtils.PickStartingPoint(Map, RNG);
                path.Add(startingPoint);
                ChangeCell(results,startingPoint,CellState.Empty, CellDisplayState.Path);
                return results;
            }

            var doBreadth = RNG.NextDouble() < Breadth;
            var doFirstChanceLooping = RNG.NextDouble() < FirstChanceLooping;
            var doLastChanceLooping = RNG.NextDouble() < LastChanceLooping;
            var doGoBackAfterLooping = RNG.NextDouble() < GoBackAfterLooping;
            var doBlocking = RNG.NextDouble() < Blocking;

            var currentCoordinateIndex = doBreadth && path.Count > 1 ? RNG.Next(1, path.Count/2+1)*2 : path.Count - 1;
            var currentCoordinate = path[currentCoordinateIndex];

            var offsets = Point.GeneratePerpendicularOffsets(Map.Dimensions);
            IList<double> biases;
            if (tree.LastOffset != null)
            {
                // TODO: Possibly optimize this search.
                var lastPositive = Array.IndexOf(tree.LastOffset.Coordinates, 1);
                var lastNegative = Array.IndexOf(tree.LastOffset.Coordinates, -1);

                var lastDimension = lastNegative == -1 ? lastPositive : lastNegative;
                var lastForward = lastNegative == -1;

                var lastDirection = lastDimension*2;
                if (lastForward)
                {
                    lastDirection++;
                }

                biases = new List<double>(Biases.Length);
                for (var i = 0; i < Biases.Length; i++)
                {
                    var runIndex = i - lastDirection;
                    while (runIndex < 0)
                    {
                        runIndex += Biases.Length;
                    }
                    while (runIndex >= Biases.Length)
                    {
                        runIndex -= Biases.Length;
                    }
                    var run = Runs[runIndex];
                    var initialBias = Biases[i];

                    var bias = initialBias*run;
                    biases.Add(bias);
                }
            }
            else
            {
                biases = Biases.ToList();
            }

            var lastChanceLooping = false;

            //if(!doGoBackAfterLooping || !LastLooped)
            while (offsets.Count > 0)
            {
                var biasTotal = biases.Sum();
                var biasMultiplier = RNG.NextDouble();
                var biasThreshold = biasMultiplier * biasTotal;
                int offsetIndex;
                if (biasTotal == 0)
                {
                    offsetIndex = RNG.Next(0, offsets.Count);
                }
                else
                {
                    var currentThreshold = 0d;
                    for (offsetIndex = 0; offsetIndex < biases.Count; offsetIndex++)
                    {
                        currentThreshold += biases[offsetIndex];
                        if (currentThreshold > biasThreshold)
                        {
                            break;
                        }
                    }
                }
                var offset = offsets[offsetIndex];
                var pathToCellCoord = currentCoordinate + offset;
                var otherCellCoord = currentCoordinate + (offset*2);
                var cellExists = Map.CellExists(otherCellCoord);
                var cell = cellExists ? Map.GetCell(lastChanceLooping ? pathToCellCoord : otherCellCoord) : null;
                if (cell == null || doBlocking || (!doFirstChanceLooping && cell.State != CellState.Filled))
                {
                    offsets.RemoveAt(offsetIndex);
                    biases.RemoveAt(offsetIndex);
                    if (doLastChanceLooping && !lastChanceLooping && offsets.Count == 0)
                    {
                        offsets = Point.GeneratePerpendicularOffsets(Map.Dimensions);
                        biases = Biases.ToList();
                        lastChanceLooping = true;
                    }
                    continue;
                }

                tree.LastOffset = offset;

                var otherCell = Map.GetCell(otherCellCoord);
                var pathToCell = Map.GetCell(pathToCellCoord);

                var wouldLoop = otherCell.State == CellState.Empty;

                if (doGoBackAfterLooping && LastLooped && wouldLoop)
                {
                    // TODO: Fix going back with first chance looping.
                    break;
                }

                LastLooped = wouldLoop;

                otherCell.State = CellState.Empty;
                pathToCell.State = CellState.Empty;

                if (wouldLoop)
                {
                    otherCell.DisplayState = CellDisplayState.Path;
                    pathToCell.DisplayState = CellDisplayState.Path;
                }
                else
                {
                    otherCell.DisplayState = CellDisplayState.PathWillReturn;
                    pathToCell.DisplayState = CellDisplayState.PathWillReturn;
                    path.Push(pathToCellCoord);
                    path.Push(otherCellCoord);
                }

                var otherResult = new MazeGenerationResult(otherCellCoord, otherCell.State, otherCell.DisplayState);
                var pathResult = new MazeGenerationResult(pathToCellCoord, pathToCell.State, pathToCell.DisplayState);

                results.Results.Add(otherResult);
                results.Results.Add(pathResult);

                return results;
            }

            if (path.Count <= 1)
            {
                RunningTrees.RemoveAt(treeIndex);
                StoppedTrees.Add(tree);
                if (RunningTrees.Count == 0)
                {
                    // TODO: Doesn't generate a full-braid map if nothing looped into the start point before. Fix to have full-braid maps in the future.
                    results.ResultsType = GenerationResultsType.GenerationCompleted;
                    return new MazeGenerationResults(GenerationResultsType.GenerationCompleted);
                }
                return results;
            }

            if (currentCoordinateIndex != 0)
            {
                var lastCoord = path[currentCoordinateIndex];
                path.RemoveAt(currentCoordinateIndex);
                var lastCell = Map.GetCell(lastCoord);
                lastCell.DisplayState = CellDisplayState.Path;
                var lastResult = new MazeGenerationResult(lastCoord, lastCell.State, lastCell.DisplayState);
                results.Results.Add(lastResult);


                var secondLastCoord = path[currentCoordinateIndex - 1];
                path.RemoveAt(currentCoordinateIndex - 1);
                var secondLastCell = Map.GetCell(secondLastCoord);
                secondLastCell.DisplayState = CellDisplayState.Path;
                var secondLastResult = new MazeGenerationResult(secondLastCoord, secondLastCell.State, secondLastCell.DisplayState);
                results.Results.Add(secondLastResult);
            }
            return results;
        }
    }
}