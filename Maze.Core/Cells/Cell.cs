namespace Maze.Core.Cells
{
    public class Cell : ICell
    {
        public Cell(CellState state = CellState.Filled, CellDisplayState displayState = CellDisplayState.Wall)
        {
            State = state;
            DisplayState = displayState;
        }

        public CellState State { get; set; }
        public CellDisplayState DisplayState { get; set; }

        //public CellState State { get; private set; }

        public override string ToString()
        {
            return "State: " + State;
        }
    }
}