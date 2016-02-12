using System.Collections.Generic;
using System.Drawing;
using Maze.Core.Maps;
using Point = Maze.Core.Common.Point;

namespace Maze.Drawing.Renderers
{
    public class GraphicsMapRenderer : DrawingMapRenderer
    {
        public GraphicsMapRenderer(IMap map, Point targetSize, Graphics graphics) : base(map, targetSize)
        {
            Graphics = graphics;
            Brushes = new Dictionary<Color, Brush>();
            foreach (var color in Colors)
            {
                Brushes.Add(color.Value, new SolidBrush(color.Value));
            }
        }

        protected Graphics Graphics { get; set; }

        private IDictionary<Color, Brush> Brushes { get; }

        protected override void DrawRectangle(Rectangle rectangle, Color color)
        {
            var brush = Brushes[color];
            Graphics.FillRectangle(brush, rectangle);
        }
    }
}