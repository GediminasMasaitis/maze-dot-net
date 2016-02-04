using System;
using System.Collections.Generic;
using System.Linq;
using Maze.Generator.Cells;

namespace Maze.Generator.Results
{
    public class MazeGenerationResult
    {
        public MazeGenerationResult(Point point, CellState state, CellDisplayState displayState)
        {
            Point = point;
            State = state;
            DisplayState = displayState;
        }

        public Point Point { get; set; }
        public CellState State { get; set; }
        public CellDisplayState DisplayState { get; set; }
    }
}
