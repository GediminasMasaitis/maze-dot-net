using System.Drawing;

namespace Maze.Drawing.Common
{
    public class ColoredPolygon : Polygon
    {
        public ColoredPolygon(Polygon polygon, Color color) : this(polygon.Points, color)
        {
        }

        public ColoredPolygon(Point[] points, Color color) : base(points)
        {
            Color = color;
        }

        public Color Color { get; }
    }
}