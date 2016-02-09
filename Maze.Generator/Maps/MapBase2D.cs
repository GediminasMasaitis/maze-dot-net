using System;
using System.Collections;
using System.Collections.Generic;
using Maze.Generator.Cells;
using Maze.Generator.Common;

namespace Maze.Generator.Maps
{
    public abstract class MapBase2D : IMap
    {
        private void Coord2DCheck(Point point)
        {
            if (point.Dimensions != 2)
            {
                throw new ArgumentException("Point must be two-dimensional.", nameof(point));
            }
        }

        //public abstract IEnumerable<ICell> FindCells();

        public bool CellExists(Point point)
        {
            return CellExists2D(point);
        }

        public ICell GetCell(Point point)
        {
            Coord2DCheck(point);
            return GetCell2D(point);
        }

        public void SetCell(ICell cell, Point point)
        {
            Coord2DCheck(point);
            SetCell2D(cell, point);
        }

        public abstract bool CellExists2D(Point point);
        public abstract ICell GetCell2D(Point point);
        public abstract void SetCell2D(ICell cell, Point point);

        public abstract bool Infinite { get; }
        public abstract Point Size { get; }
        public int Dimensions => 2;
        //public abstract IEnumerator<ICell> GetEnumerator();
        //IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}