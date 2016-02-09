using System.Linq;
using Maze.Generator.Cells;
using Maze.Generator.Common;

namespace Maze.Generator.Maps.Decorators
{
    public class TransposeMapDecorator : TransposeMapDecorator<IMap>, IMapDecorator
    {
        public TransposeMapDecorator(IMap innerMap) : base(innerMap)
        {
        }
    }

    public class TransposeMapDecorator<TMap> : IMapDecorator<TMap>
        where TMap : IMap
    {
        public TransposeMapDecorator(TMap innerMap)
        {
            InnerMap = innerMap;
        }

        public bool CellExists(Point point)
        {
            var transmutedPoint = TransposePoint(point);
            var cellExists = InnerMap.CellExists(transmutedPoint);
            return cellExists;
        }

        public ICell GetCell(Point point)
        {
            var transmutedPoint = TransposePoint(point);
            var cell = InnerMap.GetCell(transmutedPoint);
            return cell;
        }

        public void SetCell(ICell cell, Point point)
        {
            var transmutedPoint = TransposePoint(point);
            InnerMap.SetCell(cell, transmutedPoint);
        }

        private Point TransposePoint(Point point)
        {
            var reversedCoords = point.Coordinates.Reverse().ToArray();
            var transmutedPoint = new Point(reversedCoords);
            return transmutedPoint;
        }

        public bool Infinite => InnerMap.Infinite;
        public int Dimensions => InnerMap.Dimensions;

        public Point Size
        {
            get
            {
                var transmutedSize = TransposePoint(InnerMap.Size);
                return transmutedSize;
            }
        }

        public TMap InnerMap { get; }
    }
}