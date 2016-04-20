using System;
using System.Collections.Generic;
using Maze.Core.Cells;
using Maze.Core.Common;
using Maze.Core.Exceptions;
using Maze.Core.Maps;
using Maze.Core.Results;

namespace Maze.Core.Generators.RecursiveDivision
{
    public class RecursiveDivisionMazeGenerator : MazeGeneratorBase
    {
        public RecursiveDivisionMazeGenerator(IMap map, Random random = null) : base(map, random)
        {
            ShowMapInitializationStep = true;
            ProcessSingleCellBlocks = false;
            Biases = new[] {1d, 1d};
            ProportionalSplits = 0.5;
            FixedSplits = 0;
            FixedSplitLocation = 0.5;
            FixedRecursion = 1;
            FixedRecursionLocation = 1;
            ReverseRecursionOrder = 0;
        }

        private IMap _map;
        public override IMap Map
        {
            get { return _map; }
            protected set
            {
                if (value.Infinite)
                {
                    throw new IncorrectFinityException(false, value.Infinite);
                }
                if (value.Dimensions != 2)
                {
                    // TODO: Make possible on all dimensions. On a 3D map, instead of walls generate planes and punch a hole..
                    throw new IncorrectDimensionsException(new[] { 2 }, value.Dimensions);
                }
                _map = value;
                Rectangles = new List<Rectangle>();
                CurrentIteration = 0;
            }
        }

        public bool ProcessSingleCellBlocks { get; set; }
        public double[] Biases { get; }
        public bool ShowMapInitializationStep { get; }

        private double _proportionalSplits;
        public double ProportionalSplits
        {
            get { return _proportionalSplits; }
            set
            {
                DoubleParameterCheck(value);
                _proportionalSplits = value;
            }
        }

        private double _fixedSplits;
        public double FixedSplits
        {
            get { return _fixedSplits; }
            set
            {
                DoubleParameterCheck(value);
                _fixedSplits = value;
            }
        }

        private double _fixedSplitLocation;
        public double FixedSplitLocation
        {
            get { return _fixedSplitLocation; }
            set
            {
                DoubleParameterCheck(value);
                _fixedSplitLocation = value;
            }
        }

        private double _fixedRecursion;
        public double FixedRecursion
        {
            get { return _fixedRecursion; }
            set
            {
                DoubleParameterCheck(value);
                _fixedRecursion = value;
            }
        }

        private double _fixedRecursionLocation;
        public double FixedRecursionLocation
        {
            get { return _fixedRecursionLocation; }
            set
            {
                DoubleParameterCheck(value);
                _fixedRecursionLocation = value;
            }
        }

        private double _reverseRecursionOrder;
        public double ReverseRecursionOrder
        {
            get { return _reverseRecursionOrder; }
            set
            {
                DoubleParameterCheck(value);
                _reverseRecursionOrder = value;
            }
        }

        private int CurrentIteration { get; set; }
        private IList<Rectangle> Rectangles { get; set; }
        private Rectangle CurrentRectangle { get; set; }
        private Point InitialPoint { get; set; }
        private Point LastPoint { get; set; }
        //private Point LastOffset { get; set; }
        private bool Vertical { get; set; }

        public override MazeGenerationResults Generate()
        {
            if (CurrentIteration++ == 0)
            {
                var mapInitializationResults = InitializeMap();
                var pointFrom = Point.CreateSameAllDimensions(Map.Dimensions, 0);
                var mapRect = new Rectangle(pointFrom+1, Map.Size-1);
                Rectangles.Add(mapRect);
                if (ShowMapInitializationStep)
                {
                    return mapInitializationResults;
                }
            }
            
            if (CurrentRectangle == null)
            {
                if (Rectangles.Count != 0)
                {
                    BeginNewRectangle();
                }
                else
                {
                    return new MazeGenerationResults(GenerationResultsType.GenerationCompleted);
                }
            }

            var results = new MazeGenerationResults();
            var offset = Vertical ? new Point(1, 0) : new Point(0, 1);
            var currentPoint = LastPoint + offset;
            if (!CurrentRectangle.Contains(currentPoint))
            {
                var rects = new List<Rectangle>
                {
                    new Rectangle(CurrentRectangle.From, currentPoint)
                };
                Point path;
                Point newRectFrom;
                if (Vertical)
                {
                    newRectFrom = new Point(CurrentRectangle.From[0], LastPoint[1]+1);
                    var pathCoord = RNG.Next(InitialPoint[0]/2, LastPoint[0]/2)*2 + 1;
                    path = new Point(pathCoord, InitialPoint[1]);
                }
                else
                {
                    newRectFrom = new Point(LastPoint[0]+1, CurrentRectangle.From[1]);
                    var pathCoord = RNG.Next(InitialPoint[1]/2, LastPoint[1]/2)*2 + 1;
                    path = new Point(InitialPoint[0], pathCoord);
                }
                
                ChangeCell(results, path, CellState.Empty, CellDisplayState.Path);

                var newRect = new Rectangle(newRectFrom, CurrentRectangle.To);
                rects.Add(newRect);

                var doReverseRecursionOrder = ReverseRecursionOrder > RNG.NextDouble();
                if (doReverseRecursionOrder)
                {
                    rects.Reverse();
                }

                foreach (var rect in rects)
                {
                    if (rect.Size[0] > 2 || rect.Size[1] > 2)
                    {
                        if (ProcessSingleCellBlocks || (rect.Size[0] > 1 && rect.Size[1] > 1))
                        {
                            Rectangles.Add(rect);
                        }
                    }
                }

                CurrentRectangle = null;
            }
            else
            {
                ChangeCell(results, currentPoint, CellState.Filled, CellDisplayState.Wall);
                LastPoint = currentPoint;
            }
            return results;
        }

        private void BeginNewRectangle()
        {
            var rectangleIndex = GetNextRectangleIndex();
            CurrentRectangle = Rectangles[rectangleIndex];
            Rectangles.RemoveAt(rectangleIndex);
            
            var size = CurrentRectangle.Size;
            if (size[0] <= 2)
            {
                Vertical = true;
            }
            else if (size[1] <= 2)
            {
                Vertical = false;
            }
            else
            {
                var horizontalChance = Biases[0];
                var verticalChance = Biases[1];
                var proportionalSplitsMultiplier = Math.Abs(ProportionalSplits - 1) < 0.000001 ? double.MaxValue :  1 /(1 - ProportionalSplits) - 1;
                if (size[0] > size[1])
                {
                    horizontalChance *= proportionalSplitsMultiplier;
                }
                else if(size[0] < size[1])
                {
                    verticalChance *= proportionalSplitsMultiplier;
                }

                var sum = horizontalChance + verticalChance;
                Vertical = verticalChance > RNG.NextDouble()*sum;
            }


            if (Vertical)
            {
                var randPart = GetRandomPart(size[1]);
                var coord = CurrentRectangle.From[1]-1 + randPart;
                InitialPoint = new Point(CurrentRectangle.From[0] - 1, coord);
            }
            else
            {
                var randPart = GetRandomPart(size[0]);
                var coord = CurrentRectangle.From[0]-1 + randPart;
                InitialPoint = new Point(coord, CurrentRectangle.From[1] - 1);
            }
            LastPoint = InitialPoint;
        }

        private int GetNextRectangleIndex()
        {
            int rectangleIndex;
            var doFixedRecursion = FixedRecursion > RNG.NextDouble();
            if (doFixedRecursion)
            {
                rectangleIndex = Convert.ToInt32((Rectangles.Count - 1)*FixedRecursionLocation);
            }
            else
            {
                rectangleIndex = RNG.Next(0, Rectangles.Count);
            }
            return rectangleIndex;
        }

        private int GetRandomPart(int size)
        {
            // TODO: With FixedSplitLocation = 1 it breaks the end of generation. Need to fix
            size -= 4;
            var doFixedSplit = FixedSplits > RNG.NextDouble();
            int randPart;

            if (doFixedSplit)
            {
                randPart = (int)(size * FixedSplitLocation);
            }
            else
            {
                randPart = RNG.Next(0, size/2)*2;
            }

            if (randPart % 2 == 1)
            {
                randPart++;
            }

            randPart += 2;
            return randPart;
        }

        private MazeGenerationResults InitializeMap()
        {
            var results = new MazeGenerationResults();
            for (var i = 1; i < Map.Size[0] - 1; i++)
            {
                for (var j = 1; j < Map.Size[1] - 1; j++)
                {
                    var point = new Point(i, j);
                    ChangeCell(results,point,CellState.Empty, CellDisplayState.Path);
                }
            }
            return results;
        }
    }
}
