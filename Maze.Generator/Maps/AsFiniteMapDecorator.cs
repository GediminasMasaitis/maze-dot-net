using Maze.Generator.Cells;

namespace Maze.Generator.Maps
{
    public class AsFiniteMapDecorator : AsFiniteMapDecorator<IMap>
    {
        public AsFiniteMapDecorator(IMap innerMap, Point size, Point offset = null) : base(innerMap, size, offset)
        {
        }
    }

    public class AsFiniteMapDecorator<TMap> : IMap
        where TMap : IMap
    {
        public AsFiniteMapDecorator(TMap innerMap, Point size, Point offset = null)
        {
            InnerMap = innerMap;
            Size = size;
            Offset = offset ?? Point.CreateSameAllDimensions(InnerMap.Dimensions,0);
        }

        public TMap InnerMap { get; }

        //public IEnumerable<ICell> FindCells() => InnerMap.FindCells();

        public bool CellExists(Point point)
        {
            for (var i = 0; i < point.Coordinates.Length; i++)
            {
                var coordinate = point.Coordinates[i];
                //if (coordinate < Offset[i])
                if (coordinate < 0)
                {
                    return false;
                }
                //if (coordinate >= Offset[i] + Size[i])
                if (coordinate >= Size[i])
                {
                    return false;
                }
            }
            return true;
        }

        /*private Point FindActiveCell(IMap map)
        {
            for(var i = 0; i < )
            return null;
        }*/

        public ICell GetCell(Point point)
        {
            var offsettedPoint = point - Offset;
            var innerContains = InnerMap.CellExists(offsettedPoint);
            if (!innerContains)
            {
                return new Cell(CellState.Filled, CellDisplayState.Unspecified);
            }
            return InnerMap.GetCell(offsettedPoint);
        }

        public void SetCell(ICell cell, Point point) => InnerMap.SetCell(cell, point);

        public bool Infinite => false;

        public int Dimensions => InnerMap.Dimensions;

        public Point Size { get; set; }

        public Point Offset { get; set; }

        //public IEnumerator<ICell> GetEnumerator() => InnerMap.GetEnumerator();

        //IEnumerator IEnumerable.GetEnumerator() => InnerMap.GetEnumerator();
    }
}