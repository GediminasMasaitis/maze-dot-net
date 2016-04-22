using System;
using System.Collections.Generic;
using System.Drawing;
using Maze.Core.Maps;
using Maze.Drawing.Common;
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

        protected IDictionary<Color, Brush> Brushes { get; }

        protected override void DrawPolygon(Point mapPoint, ColoredPolygon polygon)
        {
            var brush = Brushes[polygon.Color];
            try
            {
                Graphics.FillPolygon(brush, polygon.Points);
            }
            catch (InvalidOperationException ex) when(ex.Message == @"Object is currently in use elsewhere.")
            {
                // TODO: handle this in a proper way
            }
        }
    }
}