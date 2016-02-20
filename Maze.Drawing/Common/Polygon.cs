using System.Drawing;

namespace Maze.Drawing.Common
{
    public class Polygon
    {
        public Polygon(Point[] points)
        {
            Points = points;
        }

        public Point[] Points { get; }

        public Rectangle GetSurroundingRectangle()
        {
            var minX = int.MaxValue;
            var maxX = int.MinValue;
            var minY = int.MaxValue;
            var maxY = int.MinValue;

            foreach (var point in Points)
            {
                if (point.X < minX)
                {
                    minX = point.X;
                }
                if (point.X > maxX)
                {
                    maxX = point.X;
                }
                if (point.Y < minY)
                {
                    minY = point.Y;
                }
                if (point.Y > maxY)
                {
                    maxY = point.Y;
                }
            }

            var rect = new Rectangle(minX, minY, maxX - minX, maxY - minY);
            return rect;
        }
    }
}