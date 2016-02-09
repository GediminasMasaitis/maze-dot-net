using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Maze.Generator;
using Maze.Generator.Cells;
using Maze.Generator.Maps;
using Maze.Generator.Renderers;
using Maze.Generator.Results;
using Point = Maze.Generator.Common.Point;

namespace Maze.WinFormsGDI
{
    abstract class GraphicMapRendererBase : IMapRenderer
    {
        public IMap Map { get; }
        public Point TargetSize { get; set; }
        public IDictionary<CellDisplayState, Color> Colors { get; }
        public GraphicMapRendererBase(IMap map, Point targetSize)
        {
            if (map.Dimensions != 2)
            {
                throw new ArgumentException(nameof(PictureBoxMapRenderer) + @" can only render 2D maps", nameof(map));
            }
            Map = map;
            TargetSize = targetSize;
            Colors = new Dictionary<CellDisplayState, Color>
            {
                { CellDisplayState.Wall, Color.Black },
                { CellDisplayState.PathWillReturn, Color.BurlyWood },
                { CellDisplayState.Path, Color.Green },
                { CellDisplayState.Active, Color.Brown },
                { CellDisplayState.Unspecified, Color.Magenta }
            };

            RecalculateParameters(true);
        }

        private IDictionary<Point, Brush> MapCache;

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

        public void RecalculateParametersInner(bool squareCells)
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

        public abstract void Render(MazeGenerationResults results);
        public virtual void Dispose()
        {
            
        }

    }

    class PictureBoxMapRenderer : IMapRenderer
    {
        public PictureBoxMapRenderer(PictureBox target, IMap map)
        {
            if (map.Dimensions != 2)
            {
                throw new ArgumentException(nameof(PictureBoxMapRenderer) + @" can only render 2D maps", nameof(map));
            }
            Map = map;
            Target = target;
            Bitmap = new Bitmap(target.Width, target.Height);
            target.Image = Bitmap;
            Graphics = Graphics.FromImage(Bitmap);
            MapCache = new Dictionary<Point, Brush>();

            Colors = new Dictionary<CellDisplayState, Color>
            {
                { CellDisplayState.Wall, Color.Black },
                { CellDisplayState.PathWillReturn, Color.BurlyWood },
                { CellDisplayState.Path, Color.Green },
                { CellDisplayState.Active, Color.Brown },
                { CellDisplayState.Unspecified, Color.Magenta }
            };

            Brushes = new Dictionary<CellDisplayState, Brush>();
            Pens = new Dictionary<CellDisplayState, Pen>();

            foreach (var color in Colors)
            {
                Brushes.Add(color.Key, new SolidBrush(color.Value));
                Pens.Add(color.Key, new Pen(color.Value));
            }

            RecalculateParameters(true);
        }

        public Dictionary<CellDisplayState, Color> Colors { get; }
        public Dictionary<CellDisplayState, Brush> Brushes { get; }
        public Dictionary<CellDisplayState, Pen> Pens { get; }
        private IMap Map { get; set; }
        private IDictionary<Point, Brush> MapCache;
        private PictureBox Target { get; }
        private Bitmap Bitmap { get; }
        private Graphics Graphics { get; }

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

        public void RecalculateParametersInner(bool squareCells)
        {
            CellWidth = Bitmap.Width / MapWidth;
            CellHeight = Bitmap.Height / MapHeight;
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

            OffsetX = (Bitmap.Width - TotalWidth)/2;
            OffsetY = (Bitmap.Height - TotalHeight)/2;
        }

        public void Render(MazeGenerationResults results)
        {
            if (Map.Infinite)
            {
                RenderInfinite(results);
            }
            else
            {
                RenderFinite(results);
            }
        }

        private void RenderInfinite(MazeGenerationResults results)
        {
            var chunkWidth = MapWidth/2;
            var chunkHeight = MapWidth/2;

            //var chunkWidth = 1;
            //var chunkHeight = 1;

            var lastResult = results.Results[0];
            var lastPoint = lastResult.Point;

            //var lastChunk = lastPoint / chunkSize;

            var x = lastPoint[0];
            var y = lastPoint[1];

            x = x/chunkWidth*chunkWidth;
            y = y/chunkHeight*chunkHeight;

            x = x - MapWidth/2;
            y = y - MapHeight/2;

            for (var i = 0; i < MapWidth; i++)
            {
                for (var j = 0; j < MapHeight; j++)
                {
                    var fakePoint = new Point(i, j);
                    var realPoint = new Point(i + x, j + y);
                    var cell = Map.GetCell(realPoint);
                    var displayState = cell.DisplayState;
                    var brush = Brushes[displayState];
                    DrawCell(fakePoint, brush, true);
                }
            }
            UpdateTarget();
        }

        private void UpdateTarget()
        {
            if (Target.InvokeRequired)
            {
                Target.Invoke(new MethodInvoker(() =>
                {
                    Target.Update();
                }));
            }
            else
            {
                Target.Update();
            }
        }

        private void RenderFinite(MazeGenerationResults results)
        {
            foreach (var result in results.Results)
            {
                var state = result.DisplayState;
                var brush = Brushes[state];
                DrawCell(result.Point, brush, true);
            }
            UpdateTarget();
        }

        public void DrawCell(Point point, Brush brush, bool invalidate)
        {
            Brush cachedBrush;
            var exists = MapCache.TryGetValue(point, out cachedBrush);
            if (exists)
            {
                if (ReferenceEquals(cachedBrush, brush))
                {
                    return;
                }
            }
            var rect = MapPointToRectangle(point);
            Graphics.FillRectangle(brush, rect);
            if (invalidate)
            {
                Target.Invalidate(rect);
            }
            MapCache[point] = brush;
        }

        public Rectangle MapPointToRectangle(Point point)
        {
            var cornerX = OffsetX + point[0]*CellWidth;
            var cornerY = OffsetY + point[1]*CellHeight;
            var rect = new Rectangle(cornerX, cornerY, CellWidth, CellHeight);
            return rect;
        }

        public void Dispose()
        {
            
        }
    }
}