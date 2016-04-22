using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maze.Core.Common;

namespace Maze.Drawing.Common
{
    public static class ExtensionMethods
    {
        public static Point ToMazePoint(this System.Drawing.Point point)
        {
            return new Point(point.X, point.X);
        }

        public static Point ToMazePoint(this System.Drawing.Size size)
        {
            return new Point(size.Width, size.Height);
        }

        public static System.Drawing.Point ToDrawingPoint(this Point point)
        {
            return new System.Drawing.Point(point[0], point[1]);
        }
    }
}
