using Maze.Core.Cells;
using Maze.Core.Common;

namespace Maze.Core.Maps
{
    public interface IMap : IMap<ICell>
    {
        
    }

    public interface IMap<TCell>// : IEnumerable<TCell>
        where TCell : ICell
    {
        //IEnumerable<TCell> FindCells();
        bool CellExists(Point point);
        TCell GetCell(Point point);
        void SetCell(TCell cell, Point point);

        bool Infinite { get; }
        int Dimensions { get; }

        /// <summary>
        /// <code>null</code> = infinite map
        /// </summary>
        Point Size { get; }
    }
}