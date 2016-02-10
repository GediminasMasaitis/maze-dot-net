using Maze.Generator.Cells;
using Maze.Generator.Common;

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

        public override string ToString()
        {
            return nameof(Point) + ": " + Point + ", " + nameof(State) + ": " + State + ", " + nameof(DisplayState) + ": " + DisplayState;
        }
    }
}
