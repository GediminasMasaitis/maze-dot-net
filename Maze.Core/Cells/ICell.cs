namespace Maze.Core.Cells
{
    public interface ICell
    {
        CellState State { get; set; }
        CellDisplayState DisplayState { get; set; }
    }
}