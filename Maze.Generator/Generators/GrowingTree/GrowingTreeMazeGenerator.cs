using System;
using System.Collections.Generic;
using System.Linq;
using Maze.Generator.Cells;
using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Generators.GrowingTree
{
    public class GrowingTreeMazeGenerator : MazeGeneratorBase
    {
        public GrowingTreeMazeGenerator(IMap map, Random rng = null) : base(map, rng)
        {
            //Path = new LinkedList<Point>();
            Path = new List<Point>();
            New = true;
            Biases = Enumerable.Repeat(1d, map.Dimensions*2).ToArray();
            Runs = Enumerable.Repeat(1d, map.Dimensions*2).ToArray();
        }

        //public LinkedList<Point> Path { get; }
        public List<Point> Path { get; }

        public bool New { get; private set; }

        private double _breadth;
        private double _lastChanceLooping;
        private double _firstChanceLooping;
        private double _horizontalBias;
        private double _verticalBias;

        public double Breadth
        {
            get { return _breadth; }
            set
            {
                ParameterCheck(value);
                _breadth = value;
            }
        }

        public double LastChanceLooping
        {
            get { return _lastChanceLooping; }
            set
            {
                ParameterCheck(value);
                _lastChanceLooping = value;
            }
        }

        public double FirstChanceLooping
        {
            get { return _firstChanceLooping; }
            set
            {
                ParameterCheck(value);
                _firstChanceLooping = value;
            }
        }

        public double[] Biases { get; }
        public double[] Runs { get; }

        private void ParameterCheck(double parameter)
        {
            if (parameter < 0 || parameter > 1)
            {
                throw new ArgumentException("Value must be between 0 and 1");
            }
        }


        public override MazeGenerationResults Generate()
        {
            var results = new MazeGenerationResults();
            if (Path.Count == 0)
            {
                var startingCoord = MazeGenerationUtils.PickStartingPoint(Map, RNG);

                Path.Add(startingCoord);
                var cell = Map.GetCell(startingCoord);
                //cell.State = CellDisplayState.Path;
                cell.State = CellState.Empty;
                cell.DisplayState = CellDisplayState.Path;

                var change = new MazeGenerationResult(startingCoord, cell.State, cell.DisplayState);

                results.Add(change);
                New = false;
                return results;
            }

            var doBreadth = RNG.NextDouble() < Breadth;
            var doFirstChanceLooping = RNG.NextDouble() < FirstChanceLooping;
            var doLastChanceLooping = RNG.NextDouble() < LastChanceLooping;

            var currentCoordinateIndex = doBreadth && Path.Count > 1 ? RNG.Next(1, Path.Count/2+1)*2 : Path.Count - 1;
            var currentCoordinate = Path[currentCoordinateIndex];

            var offsets = Point.GeneratePerpendicularOffsets(Map.Dimensions);
            var biases = Biases.ToList();
            var lastChanceLooping = false;

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
                if (!cellExists)
                {
                    offsets.RemoveAt(offsetIndex);
                    biases.RemoveAt(offsetIndex);
                    continue;
                }

                var cell = Map.GetCell(lastChanceLooping ? pathToCellCoord : otherCellCoord);
                if (!doFirstChanceLooping && cell.State != CellState.Filled)
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

                var otherCell = Map.GetCell(otherCellCoord);
                var pathToCell = Map.GetCell(pathToCellCoord);

                otherCell.State = CellState.Empty;
                pathToCell.State = CellState.Empty;

                otherCell.DisplayState = CellDisplayState.PathWillReturn;
                pathToCell.DisplayState = CellDisplayState.PathWillReturn;

                var otherResult = new MazeGenerationResult(otherCellCoord, otherCell.State, otherCell.DisplayState);
                var pathResult = new MazeGenerationResult(pathToCellCoord, pathToCell.State, pathToCell.DisplayState);

                results.Results.Add(otherResult);
                results.Results.Add(pathResult);

                Path.Push(pathToCellCoord);
                Path.Push(otherCellCoord);

                return results;
            }

            if (Path.Count <= 1)
            {
                results.ResultsType = GenerationResultsType.GenerationCompleted;
                return new MazeGenerationResults(GenerationResultsType.GenerationCompleted);
            }

            if (currentCoordinateIndex != 0)
            {
                var lastCoord = Path[currentCoordinateIndex];
                Path.RemoveAt(currentCoordinateIndex);
                var lastCell = Map.GetCell(lastCoord);
                lastCell.DisplayState = CellDisplayState.Path;
                var lastResult = new MazeGenerationResult(lastCoord, lastCell.State, lastCell.DisplayState);
                results.Results.Add(lastResult);


                var secondLastCoord = Path[currentCoordinateIndex - 1];
                Path.RemoveAt(currentCoordinateIndex - 1);
                var secondLastCell = Map.GetCell(secondLastCoord);
                secondLastCell.DisplayState = CellDisplayState.Path;
                var secondLastResult = new MazeGenerationResult(secondLastCoord, secondLastCell.State, secondLastCell.DisplayState);
                results.Results.Add(secondLastResult);
            }
            return results;
        }
    }
}