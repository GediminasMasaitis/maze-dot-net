using System;
using Maze.Core.Common;
using Maze.Core.Maps;

namespace Maze.Core.Generators
{
    public static class MazeGenerationUtils
    {
        public static Point PickStartingPoint(IMap map, Random rng = null)
        {
            if (rng == null)
            {
                rng = new Random();
            }
            Point startingCoord;
            if (map.Infinite)
            {
                startingCoord = Point.CreateSameAllDimensions(map.Dimensions, 0);
            }
            else
            {
                var corner1 = Point.CreateSameAllDimensions(map.Dimensions, 1);
                var corner2 = map.Size;
                startingCoord = PickRandomPointBetweenTwoPoints(map, corner1, corner2, rng);
            }
            return startingCoord;
        }

        public static Point PickRandomPointBetweenTwoPoints(IMap map, Point corner1, Point corner2, Random rng = null)
        {
            if (map.Dimensions != corner1.Dimensions)
            {
                throw new ArgumentException("Point dimensions doesn't match map dimensions", nameof(corner1));
            }
            if (map.Dimensions != corner2.Dimensions)
            {
                throw new ArgumentException("Point dimensions doesn't match map dimensions", nameof(corner2));
            }
            if (rng == null)
            {
                rng = new Random();
            }
            var coords = new int[map.Dimensions];
            for (var i = 0; i < map.Dimensions; i++)
            {
                coords[i] = rng.Next(corner1[i], corner2[i]/2)*2 - 1;
            }
            var resultCoord = new Point(coords);
            return resultCoord;
        }
    }
}