using System;
using Maze.Generator.Cells;
using Maze.Generator.Common;
using Maze.Generator.Exceptions;
using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Generators.BinaryTree
{
    public class BinaryTreeMazeGenerator : MazeGeneratorBase
    {
        public BinaryTreeMazeGenerator(IMap map, Random random = null) : base(map, random)
        {
        }

        private IMap _map;
        public override IMap Map
        {
            get { return _map; }
            protected set
            {
                if (value.Infinite)
                {
                    throw new MapInfiniteException(false, value.Infinite);
                }
                if (value.Dimensions != 2)
                {
                    // TODO: Find out if possible on higher dimensions
                    throw new IncorrectDimensionsException(new[] { 2 }, value.Dimensions);
                }
                _map = value;
                CurrentSetLength = 1;
                CurrentPoint = Point.CreateSameAllDimensions(Map.Dimensions, 1);
            }
        }

        private double _useSidewinder;
        public double UseSidewinder
        {
            get { return _useSidewinder; }
            set
            {
                DoubleParameterCheck(value);
                _useSidewinder = value;
            }
        }

        private double _verticalBias;
        public double VerticalBias
        {
            get { return _verticalBias; }
            set
            {
                DoubleParameterCheck(value, -1);
                _verticalBias = value;
            }
        }

        public BinaryTreeBias Bias { get; set; }

        private int CurrentSetLength { get; set; }
        private Point CurrentPoint { get; set; }

        public override MazeGenerationResults Generate()
        {
            var results = new MazeGenerationResults();

            var currentCoords = (int[])CurrentPoint.Coordinates.Clone();
            currentCoords[0] += 2;
            
            if (currentCoords[0] >= Map.Size[0])
            {
                currentCoords[0] = 1;
                currentCoords[1] += 2;
                CurrentSetLength = 0;
            }

            if (currentCoords[1] >= Map.Size[1])
            {
                results.ResultsType = GenerationResultsType.GenerationCompleted;
                return results;
            }

            CurrentPoint = new Point(currentCoords);


            bool digHorizontal;
            var useBinaryTree = RNG.NextDouble() > UseSidewinder;

            //var dirX = binaryTreeValue == 0 && (NWBiasRadioButton.Checked || SWBiasRadioButton.Checked) ? -1 : 1;
            //var dirY = binaryTreeValue == 0 && (SWBiasRadioButton.Checked || SEBiasRadioButton.Checked) ? 1 : -1;
            var dirX = useBinaryTree && (Bias == BinaryTreeBias.NorthWest || Bias == BinaryTreeBias.SouthWest) ? -1 : 1;
            var dirY = Bias == BinaryTreeBias.SouthWest || Bias == BinaryTreeBias.SouthEast ? 1 : -1;

            var horizontalPoint = new Point(currentCoords[0] + dirX * 2, currentCoords[1]);
            var verticalPoint = new Point(currentCoords[0], currentCoords[1] + dirY * 2);

            //var canGoHorizontal = _mazeRectangle.Contains(i + dirX * 2, j);
            //var canGoVertical = _mazeRectangle.Contains(i, j + dirY * 2);
            var canGoHorizontal = Map.CellExists(horizontalPoint);
            var canGoVertical = Map.CellExists(verticalPoint);

            if (!canGoHorizontal && !canGoVertical)
            {
                return results;
                //continue;
            }
            if (canGoHorizontal && canGoVertical)
            {
                digHorizontal = RNG.NextDouble()*2 - 1 > VerticalBias;
            }
            else 
            {
                digHorizontal = canGoHorizontal;
            }
                    

            if (digHorizontal)
            {
                CurrentSetLength++;
                var horizontalPathPoint = new Point(currentCoords[0] + dirX, currentCoords[1]);
                ChangeCell(results, horizontalPathPoint, CellState.Empty, CellDisplayState.Path);
                ChangeCell(results, horizontalPoint, CellState.Empty, CellDisplayState.Path);
                //_mazeMatrix[i + dirX, j] = CellState.Walkway;
                //_mazeMatrix[i + dirX * 2, j] = CellState.Walkway;
            }
            else
            {
                var rand = useBinaryTree ? 0 : RNG.Next(0, CurrentSetLength) * 2;
                CurrentSetLength = 1;
                var verticalPathPoint = new Point(currentCoords[0] - rand, currentCoords[1] + dirY);
                ChangeCell(results, verticalPathPoint, CellState.Empty, CellDisplayState.Path);
                //_mazeMatrix[i - rand, j + dirY] = CellState.Walkway;
            }
            ChangeCell(results, CurrentPoint, CellState.Empty, CellDisplayState.Path);
            //_mazeMatrix[i, j] = CellState.Walkway;

            return results;
        }
    }
}
