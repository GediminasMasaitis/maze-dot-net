using System.Collections.Generic;
using System.Drawing;
using Maze.Core.Cells;
using Maze.Core.Exceptions;
using Maze.Core.Maps;
using Maze.Core.Renderers;
using Maze.Core.Results;
using Point = Maze.Core.Common.Point;

namespace Maze.Drawing.Renderers
{
    public abstract class GraphicMapRenderer : IMapRenderer
    {
        public GraphicMapRenderer(IMap map, Point targetSize)
        {
            if (map.Dimensions != 2)
            {
                throw new IncorrectDimensionsException(new []{2}, map.Dimensions);
            }
            if (map.Infinite)
            {
                throw new IncorrectFinityException(false, map.Infinite);
            }
            Map = map;
            Colors = new Dictionary<CellDisplayState, Color>
            {
                { CellDisplayState.Wall, Color.Black },
                { CellDisplayState.PathWillReturn, Color.BurlyWood },
                { CellDisplayState.Path, Color.Green },
                { CellDisplayState.Active, Color.Brown },
                { CellDisplayState.Unspecified, Color.Magenta }
            };
            TargetSize = targetSize;
        }

        private IMap _map;
        public IMap Map
        {
            get { return _map; }
            set
            {
                _map = value;
                MapCache = new Dictionary<Point, Color>();
            }
        }

        private Point _targetSize;
        public Point TargetSize
        {
            get { return _targetSize; }
            set
            {
                _targetSize = value;
                RecalculateParameters(true);
            }
        }

        public bool Cache { get; set; }
        public IDictionary<CellDisplayState, Color> Colors { get; }

        private IDictionary<Point, Color> MapCache { get; set; }

        private int MapWidth { get; set; }
        private int MapHeight { get; set; }
        private int OffsetX { get; set; }
        private int OffsetY { get; set; }
        private int CellWidth { get; set; }
        private int CellHeight { get; set; }
        private int TotalWidth { get; set; }
        private int TotalHeight { get; set; }

        private void RecalculateParameters(bool squareCells)
        {
            if (Map.Infinite)
            {
                MapWidth = 49;
                MapHeight = 49;
                RecalculateParametersInner(true);
            }
            else
            {
                MapWidth = Map.Size[0];
                MapHeight = Map.Size[1];
                RecalculateParametersInner(squareCells);
            }
        }

        private void RecalculateParametersInner(bool squareCells)
        {
            CellWidth = TargetSize[0] / MapWidth;
            CellHeight = TargetSize[1] / MapHeight;
            if (squareCells)
            {
                if (CellWidth > CellHeight)
                {
                    CellWidth = CellHeight;
                }
                else
                {
                    CellHeight = CellWidth;
                }
            }
            TotalWidth = CellWidth * MapWidth;
            TotalHeight = CellHeight * MapHeight;

            OffsetX = (TargetSize[0] - TotalWidth) / 2;
            OffsetY = (TargetSize[1] - TotalHeight) / 2;
        }

        public virtual void Render(MazeGenerationResults results)
        {
            foreach (var result in results.Results)
            {
                var displayState = result.DisplayState;
                var color = Colors[displayState];
                DrawCell(result.Point, color);
            }
        }

        private void DrawCell(Point point, Color color)
        {
            if (Cache)
            {
                Color cachedColor;
                var exists = MapCache.TryGetValue(point, out cachedColor);
                if (exists)
                {
                    if (cachedColor.Equals(color))
                    {
                        return;
                    }
                }
                MapCache[point] = color;
            }
            var rect = MapPointToRectangle(point);
            DrawRectangle(rect, color);
        }

        protected abstract void DrawRectangle(Rectangle rectangle, Color color);

        private Rectangle MapPointToRectangle(Point point)
        {
            var cornerX = OffsetX + point[0] * CellWidth;
            var cornerY = OffsetY + point[1] * CellHeight;
            var rect = new Rectangle(cornerX, cornerY, CellWidth, CellHeight);
            return rect;
        }

        public virtual void Dispose()
        {
            
        }
    }
}