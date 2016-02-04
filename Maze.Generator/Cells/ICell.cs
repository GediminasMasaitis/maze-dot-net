namespace Maze.Generator.Cells
{
    public interface ICell
    {
        CellState State { get; set; }
        CellDisplayState DisplayState { get; set; }
    }
}