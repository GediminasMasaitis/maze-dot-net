using System;
using System.Collections.Generic;
using System.Drawing;
using Maze.Core.Cells;
using Maze.Core.Exceptions;
using Maze.Core.Maps;
using Maze.Core.Renderers;
using Maze.Core.Results;
using Maze.Drawing.Common;
using Point = Maze.Core.Common.Point;

namespace Maze.Drawing.Renderers
{
    public abstract class DrawingMapRenderer : IFullMapRenderer
    {
        public DrawingMapRenderer(IMap map, Point targetSize)
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
            get => _map;
            set
            {
                _map = value;
                MapCache = new Dictionary<Point, Color>();
            }
        }

        private static readonly double Sqrt2 = Math.Sqrt(2);
        private static readonly double Sqrt3 = Math.Sqrt(3);

        private bool _hexagonMode;
        public bool HexagonMode
        {
            get => _hexagonMode;
            set
            {
                if (!Equals(value, _hexagonMode))
                {
                    _hexagonMode = value;
                    RecalculateParameters(true);
                }
            }
        }

        private Point _targetSize;
        public Point TargetSize
        {
            get => _targetSize;
            set
            {
                if (!Equals(value, _targetSize))
                {
                    _targetSize = value;
                    RecalculateParameters(true);
                }
            }
        }
        public bool ForceRerender { get; set; }
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
        private double CellVertexDistance { get; set; }

        private void RecalculateParameters(bool squareCells)
        {
            MapWidth = Map.Size[0];
            MapHeight = Map.Size[1];
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
            if (HexagonMode)
            {
                CellHeight = (int)(CellHeight * Sqrt3 / 2);
                CellVertexDistance = 1/Sqrt3;
            }
            else
            {
                CellVertexDistance = 1/Sqrt2;
            }
            TotalWidth = CellWidth * MapWidth;
            TotalHeight = CellHeight * MapHeight;

            OffsetX = (TargetSize[0] - TotalWidth) / 2;
            OffsetY = (TargetSize[1] - TotalHeight) / 2;
        }

        public virtual void RenderStep(MazeGenerationResults results)
        {
            if (ForceRerender)
            {
                RenderMap();
            }
            else
            {
                RenderResults(results);
            }
        }

        public void RenderMap()
        {
            RenderMap(false);
        }

        public void RenderMap(bool disableCacheReading)
        {
            for (var i = 0; i < Map.Size[0]; i++)
            {
                for (var j = 0; j < Map.Size[1]; j++)
                {
                    var point = new Point(i, j);
                    var cell = Map.GetCell(point);
                    var displayState = cell.DisplayState;
                    var color = Colors[displayState];
                    DrawCell(point, color, disableCacheReading);
                }
            }
        }

        protected void RenderResults(MazeGenerationResults results)
        {
            foreach (var result in results.Results)
            {
                var displayState = result.DisplayState;
                var color = Colors[displayState];
                DrawCell(result.Point, color);
            }
        }

        private void DrawCell(Point point, Color color, bool disableCacheReading = false)
        {
            if (Cache)
            {
                if (!disableCacheReading)
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
                }
                MapCache[point] = color;
            }
            var poly = HexagonMode ? MapPointToHexagon(point) : MapPointToRectangle(point);
            var coloredPoly = new ColoredPolygon(poly.Points, color);
            DrawPolygon(point, coloredPoly);
        }

        private Polygon MapPointToRectangle(Point point)
        {
            var centerPoint = GetRectangleCenterPoint(point);
            var points = new System.Drawing.Point[4];
            for (var i = 0; i < points.Length; i++)
            {
                points[i] = GetPolygonCorner(centerPoint, i, 90, 45);
            }
            var polygon = new Polygon(points);
            return polygon;
        }

        private System.Drawing.Point GetRectangleCenterPoint(Point mapPoint)
        {
            var centerPoint = new System.Drawing.Point(OffsetX + mapPoint[0] * CellWidth + CellWidth / 2, OffsetY + mapPoint[1] * CellHeight + CellHeight / 2);
            return centerPoint;
        }
        private System.Drawing.Point GetHexagonCenterPoint(Point mapPoint)
        {
            var xPart = Convert.ToInt32(OffsetX + mapPoint[0]* CellWidth + CellWidth / 2);
            var yPart = Convert.ToInt32(OffsetY + mapPoint[1]* CellHeight + CellHeight / 2);
            if (mapPoint[1]%2 == 0)
            {
                xPart += CellWidth / 2;
            }
            var centerPoint = new System.Drawing.Point(xPart, yPart);
            return centerPoint;
        }

        private Polygon MapPointToHexagon(Point point)
        {
            var centerPoint = GetHexagonCenterPoint(point);
            var points = new System.Drawing.Point[6];
            for (var i = 0; i < points.Length; i++)
            {
                points[i] = GetPolygonCorner(centerPoint, i,60,30);
            }
            var polygon = new Polygon(points);
            return polygon;
        }

        private System.Drawing.Point GetPolygonCorner(System.Drawing.Point centerPoint, int corner, double cornerAngle, double angleOffset)
        {
            var angleDeg = cornerAngle * corner + angleOffset;
            var angleRad = Math.PI/180*angleDeg;
            var xPart = CellWidth * Math.Cos(angleRad) * CellVertexDistance;
            var yPart = CellWidth * Math.Sin(angleRad) * CellVertexDistance;
            var pointX = Convert.ToInt32(centerPoint.X + xPart);
            var pointY = Convert.ToInt32(centerPoint.Y + yPart);
            var drawingPoint = new System.Drawing.Point(pointX, pointY);
            return drawingPoint;
        }

        protected abstract void DrawPolygon(Point mapPoint, ColoredPolygon polygon);

        public virtual void Dispose()
        {
            
        }
    }
}