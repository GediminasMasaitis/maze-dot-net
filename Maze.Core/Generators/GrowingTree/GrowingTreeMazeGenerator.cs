using System;
using System.Collections.Generic;
using System.Linq;
using Maze.Core.Cells;
using Maze.Core.Common;
using Maze.Core.Maps;
using Maze.Core.Results;

namespace Maze.Core.Generators.GrowingTree
{
    public class GrowingTreeMazeGenerator : MazeGeneratorBase
    {
        public GrowingTreeMazeGenerator(IMap map, Random rng = null) : base(map, rng)
        {
            TreeCount = 1;
            Sparseness = 2;
            Biases = Enumerable.Repeat(1d, map.Dimensions*2).ToArray();
            Runs = Enumerable.Repeat(1d, map.Dimensions*2).ToArray();
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

        private ConnectingTree<Tree> TreeTree { get; set; }
        private IDictionary<Point, Tree> CellsTreeDict { get; set; }
        private IList<Tree> RunningTrees { get; set; }
        private IList<Tree> StoppedTrees { get; set; }
        
        private IMap _map;
        public override IMap Map
        {
            get => _map;
            protected set => _map = value;
        }

        public int TreeCount { get; set; }
        public double[] Biases { get; }
        public double[] Runs { get; }
        private double _breadth;
        public double Breadth
        {
            get => _breadth;
            set
            {
                DoubleParameterCheck(value);
                _breadth = value;
            }
        }

        private double _firstChanceLooping;
        public double FirstChanceLooping
        {
            get => _firstChanceLooping;
            set
            {
                DoubleParameterCheck(value);
                _firstChanceLooping = value;
            }
        }

        private double _lastChanceLooping;
        public double LastChanceLooping
        {
            get => _lastChanceLooping;
            set
            {
                DoubleParameterCheck(value);
                _lastChanceLooping = value;
            }
        }

        private double _dontGoBackAfterLooping;
        public double DontGoBackAfterLooping
        {
            get => _dontGoBackAfterLooping;
            set
            {
                DoubleParameterCheck(value);
                _dontGoBackAfterLooping = value;
            }
        }

        private double _blocking;
        public double Blocking
        {
            get => _blocking;
            set
            {
                DoubleParameterCheck(value);
                _blocking = value;
            }
        }

        private int _sparseness;
        public int Sparseness
        {
            get => _sparseness;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(Sparseness) + " should be at least 1");
                }
                _sparseness = value;
            }
        }

        private bool LastLooped { get; set; }
        private int CurrentIteration { get; set; }
        public override MazeGenerationResults Generate()
        {
            var results = new MazeGenerationResults();
            if (CurrentIteration == 0)
            {
                InitializeMap();
            }

            var treeIndex = CurrentIteration%RunningTrees.Count;
            var tree = RunningTrees[treeIndex];
            var path = tree.Path;
            CurrentIteration++;
            if (path.Count == 0)
            {
                return InitializeTree(path, results, tree);
            }

            var doBreadth = RNG.NextDouble() < Breadth;
            var doFirstChanceLooping = RNG.NextDouble() < FirstChanceLooping;
            var doLastChanceLooping = RNG.NextDouble() < LastChanceLooping;
            var dontGoBackAfterLooping = RNG.NextDouble() < DontGoBackAfterLooping;
            var doBlocking = RNG.NextDouble() < Blocking;

            var currentCoordinateIndex = doBreadth && path.Count > 1 ? RNG.Next(1, path.Count/Sparseness+1)*Sparseness : path.Count - 1;
            var currentPoint = path[currentCoordinateIndex];

            var offsets = currentPoint.GetAxisOffsets();
            var biases = GetCurrentOffsetProbabilities(tree.LastOffset);
            
            var lastChanceLooping = false;
            while (offsets.Count > 0)
            {
                var offsetIndex = PickNextDirection(biases, offsets);
                var offset = offsets[offsetIndex];
                var points = new List<Point>(Sparseness);
                {
                    for (var i = 1; i <= Sparseness; i++)
                    {
                        var point = currentPoint + (offset * i);
                        points.Add(point);
                    }
                }
                var firstPoint = points[0];
                var lastPoint = points[^1];
                var lastCellExists = Map.CellExists(lastPoint);
                var testCell = lastCellExists ? Map.GetCell(lastChanceLooping ? firstPoint : lastPoint) : null;
                
                if (testCell == null || doBlocking || (!doFirstChanceLooping && testCell.State != CellState.Filled))
                {
                    offsets.RemoveAt(offsetIndex);
                    biases.RemoveAt(offsetIndex);
                    if (!lastChanceLooping && offsets.Count == 0)
                    {
                        offsets = currentPoint.GetAxisOffsets();
                        biases = Biases.ToList();
                        lastChanceLooping = true;
                    }
                    continue;
                }

                var cells = points.Select(x => Map.GetCell(x)).ToList();
                var lastCell = cells[^1];

                var wouldLoop = lastCell.State == CellState.Empty;

                Tree otherTree;
                var treeJoinForceConnect = CellsTreeDict.TryGetValue(lastPoint, out otherTree) && TreeTree.Connect(tree, otherTree);

                if (wouldLoop)
                {
                    if (!doLastChanceLooping && !treeJoinForceConnect)
                    {
                        break;
                    }
                }

                tree.LastOffset = offset;
                
                if (!dontGoBackAfterLooping && LastLooped && wouldLoop)
                {
                    // TODO: Fix going back with first chance looping.
                    break;
                }

                if (!treeJoinForceConnect && !wouldLoop)
                {
                    CellsTreeDict.Add(lastPoint, tree);
                }

                LastLooped = wouldLoop;

                for (var i = 0; i < points.Count; i++)
                {
                    var point = points[i];
                    var cell = cells[i];
                    cell.State = CellState.Empty;
                    if (wouldLoop)
                    {
                        cell.DisplayState = CellDisplayState.Path;
                    }
                    else
                    {
                        cell.DisplayState = CellDisplayState.PathWillReturn;
                        path.Push(point);
                    }
                    var result = new MazeGenerationResult(point, cell.State, cell.DisplayState);
                    results.Add(result);
                }

                return results;
            }

            if (path.Count <= 1)
            {
                return CompleteTree(treeIndex, results);
            }

            if (currentCoordinateIndex != 0)
            {
                for (var i = 0; i < Sparseness; i++)
                {
                    var coord = path[currentCoordinateIndex - i];
                    path.RemoveAt(currentCoordinateIndex - i);
                    var lastCell = Map.GetCell(coord);
                    lastCell.DisplayState = CellDisplayState.Path;
                    var lastResult = new MazeGenerationResult(coord, lastCell.State, lastCell.DisplayState);
                    results.Results.Add(lastResult);
                }
            }
            return results;
        }

        private MazeGenerationResults CompleteTree(int treeIndex, MazeGenerationResults results)
        {
            var tree = RunningTrees[treeIndex];
            RunningTrees.RemoveAt(treeIndex);
            StoppedTrees.Add(tree);
            if (RunningTrees.Count == 0)
            {
                // TODO: Doesn't generate a full-braid map if nothing looped into the start point before. Fix to have full-braid maps in the future.
                return new MazeGenerationResults(GenerationResultsType.GenerationCompleted);
            }
            return results;
        }

        private int PickNextDirection(IList<double> directionProbabilities, ICollection<Point> offsets)
        {
            var biasTotal = directionProbabilities.Sum();
            var biasMultiplier = RNG.NextDouble();
            var biasThreshold = biasMultiplier*biasTotal;
            int offsetIndex;
            if (biasTotal == 0)
            {
                offsetIndex = RNG.Next(0, offsets.Count);
            }
            else
            {
                var currentThreshold = 0d;
                for (offsetIndex = 0; offsetIndex < directionProbabilities.Count; offsetIndex++)
                {
                    currentThreshold += directionProbabilities[offsetIndex];
                    if (currentThreshold > biasThreshold)
                    {
                        break;
                    }
                }
            }
            return offsetIndex;
        }

        private MazeGenerationResults InitializeTree(ICollection<Point> path, MazeGenerationResults results, Tree tree)
        {
            Point startingPoint;
            ICell startingCell;
            do
            {
                // TODO: This one is retarded. Need to think of a better way.
                startingPoint = MazeGenerationUtils.PickStartingPoint(Map, RNG);
                startingCell = Map.GetCell(startingPoint);
            } while (startingCell.State == CellState.Empty);
            path.Add(startingPoint);
            ChangeCell(results, startingPoint, CellState.Empty, CellDisplayState.Path);
            CellsTreeDict.Add(startingPoint, tree);
            return results;
        }

        private void InitializeMap()
        {
            RunningTrees = new List<Tree>();
            StoppedTrees = new List<Tree>();
            TreeTree = new ConnectingTree<Tree>(true);
            CellsTreeDict = new Dictionary<Point, Tree>();
            for (var i = 0; i < TreeCount; i++)
            {
                var newTree = new Tree();
                TreeTree.Add(newTree);
                RunningTrees.Add(newTree);
            }
        }

        private class OffsetInfo
        {
            public int Dimension { get; set; }
            public bool Forward { get; set; }
            public int Direction { get; set; }
        }

        private OffsetInfo GetOffsetInfo(Point offset)
        {
            var info = new OffsetInfo();
            var lastPositive = Array.IndexOf(offset.Coordinates, 1);
            var lastNegative = Array.IndexOf(offset.Coordinates, -1);

            info.Dimension = lastNegative == -1 ? lastPositive : lastNegative;
            info.Forward = lastNegative == -1;
            info.Direction = info.Dimension * 2;
            if (info.Forward)
            {
                info.Direction++;
            }
            return info;
        }

        private IList<double> GetCurrentOffsetProbabilities(Point lastOffset = null)
        {
            IList<double> probabilities;
            if (lastOffset != null)
            {
                // TODO: Possibly optimize this search.
                var lastOffsetInfo = GetOffsetInfo(lastOffset);

                probabilities = new List<double>(Biases.Length);
                for (var i = 0; i < Biases.Length; i++)
                {
                    var runIndex = i - lastOffsetInfo.Direction;
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

                    var bias = initialBias * run;
                    probabilities.Add(bias);
                }
            }
            else
            {
                probabilities = Biases.ToList();
            }
            return probabilities;
        }
    }
}