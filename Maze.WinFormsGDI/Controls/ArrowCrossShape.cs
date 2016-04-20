using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.WinFormsGDI.Controls
{
    class ArrowCrossShape : PolygonShape
    {
        public ArrowCrossShape()
        {
            Polygon = CalculateArrowPoints();
            PolygonSize = 10;
            SyncSizedPolygon();
        }

        private static Point[] CalculateArrowPoints()
        {
            var basePoints = new Point[]
            {
                new Point(5, 0),
                new Point(7, 2),
                new Point(6, 2),
                new Point(6, 4),
            };
            var quarterPoints = basePoints.Concat(basePoints.Reverse().Skip(1).Select(x => new Point(10 - x.Y, 10 - x.X))).ToArray();
            var halfPoints = quarterPoints.Concat(quarterPoints.Reverse().Skip(1).Select(x => new Point(x.X, 10 - x.Y))).ToArray();
            var fullPoints = halfPoints.Concat(halfPoints.Reverse().Skip(1).Select(x => new Point(10 - x.X, x.Y))).Skip(1).ToArray();
            return fullPoints;
        }
    }
}
