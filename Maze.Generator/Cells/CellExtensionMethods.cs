using System;

namespace Maze.Generator.Cells
{
    public static class CellExtensionMethods
    {
        public static CellState ToCellState(this CellDisplayState displayState)
        {
            switch (displayState)
            {
                case CellDisplayState.Wall:
                    return CellState.Filled;
                case CellDisplayState.PathWillReturn:
                    return CellState.Empty;
                case CellDisplayState.Path:
                    return CellState.Empty;
                default:
                    throw new ArgumentOutOfRangeException(nameof(displayState), displayState, null);
            }
        }
    }
}
