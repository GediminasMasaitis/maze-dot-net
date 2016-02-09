using System.Collections;
using System.Collections.Generic;
using Maze.Generator.Cells;
using Maze.Generator.Common;

namespace Maze.Generator.Maps
{
    public class InfiniteMapDecorator : InfiniteMapDecorator<IMap>
    {
        public InfiniteMapDecorator(IMap innerMap) : base(innerMap)
        {
        }
    }

    public class InfiniteMapDecorator<TMap> : IMap
        where TMap : IMap
    {
        private readonly IEnumerable<ICell> _cells;

        public InfiniteMapDecorator(TMap innerMap)
        {
            InnerMap = innerMap;
        }
        
        private TMap InnerMap { get; }

        public IEnumerable<ICell> FindCells()
        {
            return _cells;
        }

        public bool CellExists(Point point) => InnerMap.CellExists(point);

        public ICell GetCell(Point point)
        {
            if (CellExists(point))
            {
                return InnerMap.GetCell(point);
            }
            return null;
        }

        public void SetCell(ICell cell, Point point) => InnerMap.SetCell(cell, point);

        public bool Infinite => true;
        public int Dimensions => InnerMap.Dimensions;
        public Point Size => null;
        //public IEnumerator<ICell> GetEnumerator() =>InnerMap.GetEnumerator();

        //IEnumerator IEnumerable.GetEnumerator() => InnerMap.GetEnumerator();
    }
}