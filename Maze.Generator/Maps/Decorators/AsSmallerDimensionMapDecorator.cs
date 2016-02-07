using System.Collections.Generic;
using System.Linq;
using Maze.Generator.Cells;

namespace Maze.Generator.Maps.Decorators
{
    public class AsSmallerDimensionMapDecorator : AsSmallerDimensionMapDecorator<IMap>, IMapDecorator
    {
        public AsSmallerDimensionMapDecorator(IMap map, int[] extraLayers = null) : base(map, extraLayers)
        {
        }
    }

    public class AsSmallerDimensionMapDecorator<TMap> : IMapDecorator<TMap>
        where TMap : IMap
    {
        public AsSmallerDimensionMapDecorator(TMap map, int[] extraLayers = null)
        {
            InnerMap = map;
            ExtraLayers = extraLayers ?? new int[0];

        }

        public TMap InnerMap { get; }
        public IList<int> ExtraLayers { get; set; }

        public bool CellExists(Point point)
        {
            var newPoint = AddExtraLayers(point);
            return InnerMap.CellExists(newPoint);
        }

        public ICell GetCell(Point point)
        {
            var newPoint = AddExtraLayers(point);
            return InnerMap.GetCell(newPoint);
        }

        public void SetCell(ICell cell, Point point)
        {
            var newPoint = AddExtraLayers(point);
            InnerMap.SetCell(cell, newPoint);
        }

        private Point AddExtraLayers(Point point)
        {
            var allCoords = new int[point.Dimensions + ExtraLayers.Count];
            for (var i = 0; i < point.Coordinates.Length; i++)
            {
                var coordinate = point.Coordinates[i];
                allCoords[i] = coordinate;
            }
            for (var i = 0; i < ExtraLayers.Count; i++)
            {
                var coordinate = ExtraLayers[i];
                allCoords[point.Dimensions + i] = coordinate;
            }
            var newPoint = new Point(allCoords);
            return newPoint;
        }

        public bool Infinite => InnerMap.Infinite;
        public int Dimensions => InnerMap.Dimensions - ExtraLayers.Count;

        public Point Size
        {
            get
            {
                if (!InnerMap.Infinite)
                {
                   var size = new Point(InnerMap.Size.Coordinates.Take(Dimensions).ToArray());
                   return size;
                }
                return null;
            }
        }
    }
}