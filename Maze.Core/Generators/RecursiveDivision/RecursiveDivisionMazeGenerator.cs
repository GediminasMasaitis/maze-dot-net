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
            Biases = new[] {1d, 1d};
            ProportionalSplits = 1;
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
        public double[] Biases { get; }
        public bool ShowMapInitializationStep { get; }
        public double ProportionalSplits { get; set; }


        private int CurrentIteration { get; set; }

        private class Rectangle
        {
            public Rectangle(Point from, Point to)
            {
                From = from;
                To = to;
                Size = To - From;
            }

            public Point From { get; }
            public Point To { get; }
            public Point Size { get; }

            public bool Contains(Point point)
            {
                var contains = point[0] >= From[0] && point[1] >= From[1] && point[0] < To[0] && point[1] < To[1];
                return contains;
            }

            public override string ToString()
            {
                return "From " + From + " to " + To + "; Size: " + Size;
            }
        }

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
                while (Rectangles.Count != 0)
                {
                    var success = BeginNewRectangle();
                    if (success)
                    {
                        break;
                    }
                }
                if (CurrentRectangle == null)
                {
                    return new MazeGenerationResults(GenerationResultsType.GenerationCompleted);
                }
            }

            var results = new MazeGenerationResults();
            var offset = Vertical ? new Point(1, 0) : new Point(0, 1);
            var currentPoint = LastPoint + offset;
            if (!CurrentRectangle.Contains(currentPoint))
            {
                Rectangle rectA;
                Rectangle rectB;
                Point path;
                if (Vertical)
                {
                    rectA = new Rectangle(CurrentRectangle.From, currentPoint);
                    var newPoint = new Point(CurrentRectangle.From[0], LastPoint[1]+1);
                    rectB = new Rectangle(newPoint, CurrentRectangle.To);
                    var pathCoord = RNG.Next(InitialPoint[0]/2, LastPoint[0]/2)*2 + 1;
                    path = new Point(pathCoord, InitialPoint[1]);
                }
                else
                {
                    rectA = new Rectangle(CurrentRectangle.From, currentPoint);
                    var newPoint = new Point(LastPoint[0]+1, CurrentRectangle.From[1]);
                    rectB = new Rectangle(newPoint, CurrentRectangle.To);
                    var pathCoord = RNG.Next(InitialPoint[1]/2, LastPoint[1]/2) * 2 + 1;
                    path = new Point(InitialPoint[0], pathCoord);
                }

                ChangeCell(results, path, CellState.Empty, CellDisplayState.Path);

                var addA = rectA.Size[0] > 2 || rectA.Size[1] > 2;
                var addB = rectB.Size[0] > 2 || rectB.Size[1] > 2;

                if (addA)
                {
                    Rectangles.Add(rectA);
                }
                if (addB)
                {
                    Rectangles.Add(rectB);
                }
                CurrentRectangle = null;
                //return Generate();
            }
            else
            {
                ChangeCell(results, currentPoint, CellState.Filled, CellDisplayState.Wall);
                LastPoint = currentPoint;
            }
            return results;
        }

        private bool BeginNewRectangle()
        {
            //var rectangleIndex = Rectangles.Count - 1;
            var rectangleIndex = 0;
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
                if (size[0] > size[1])
                {
                    horizontalChance *= ProportionalSplits;
                }
                else if(size[0] < size[1])
                {
                    verticalChance *= ProportionalSplits;
                }

                var sum = horizontalChance + verticalChance;
                Vertical = verticalChance > RNG.NextDouble()*sum;
            }

            if (Vertical)
            {
                //var randPart = 2;
                //var randPart = RNG.Next(1, size[1]/2)*2;
                var randPart = size[1]/2;
                if (randPart % 2 == 1)
                {
                    randPart++;
                }
                var coord = CurrentRectangle.From[1]-1 + randPart;
                InitialPoint = new Point(CurrentRectangle.From[0] - 1, coord);
            }
            else
            {
                //var randPart = 2;
                //var randPart = RNG.Next(1, size[0] / 2) * 2;
                var randPart = size[0]/2;
                if (randPart%2==1)
                {
                    randPart++;
                }
                var coord = CurrentRectangle.From[0]-1 + randPart;
                InitialPoint = new Point(coord, CurrentRectangle.From[1] - 1);
            }
            LastPoint = InitialPoint;
            return true;
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
