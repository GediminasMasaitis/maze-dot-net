using System;
using System.Collections.Generic;
using System.Linq;

namespace Maze.Generator.Common
{
    public class Point
    {
        public Point(params int[] coords)
        {
            if (coords.Length == 0)
            {
                // throw new ArgumentException("Point cannot be zero-dimensional, provide at least one dimension");

                // Why can't it, old me?
            }

            Coordinates = coords;
        }

        public int Dimensions => Coordinates.Length;
        public int[] Coordinates { get; }

        protected bool Equals(Point other)
        {
            //return Coordinates.SequenceEqual(other.Coordinates);
            if (Dimensions != other.Dimensions)
            {
                return false;
            }
            for (var i = 0; i < Dimensions; i++)
            {
                if (Coordinates[i] != other[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            //var hash = Coordinates.Aggregate((x, n) => x ^ n.GetHashCode());
            int hash = 0;
            //const int mul = 31;
            //const int mul = 839;
            const int mul = 56921;
            unchecked
            {
                foreach (var coordinate in Coordinates)
                {
                    hash = hash * mul + coordinate;
                }
            }

            return hash;
        }

        private static void DimensionCheck(Point c1, Point c2)
        {
            if (c1.Dimensions != c2.Dimensions)
            {
                throw new Exception("Point dimension mismatch");
            }
        }

        public static Point operator +(Point c1, Point c2)
        {
            DimensionCheck(c1, c2);
            var coords = c1.Coordinates.Select((x, i) => x + c2.Coordinates[i]).ToArray();
            return new Point(coords);
        }

        public static Point operator -(Point c1, Point c2)
        {
            DimensionCheck(c1, c2);
            var coords = c1.Coordinates.Select((x, i) => x - c2.Coordinates[i]).ToArray();
            return new Point(coords);
        }

        public static Point operator *(Point c1, Point c2)
        {
            DimensionCheck(c1, c2);
            var coords = c1.Coordinates.Select((x, i) => x * c2.Coordinates[i]).ToArray();
            return new Point(coords);
        }

        public static Point operator /(Point c1, Point c2)
        {
            DimensionCheck(c1, c2);
            var coords = c1.Coordinates.Select((x, i) => x / c2.Coordinates[i]).ToArray();
            return new Point(coords);
        }

        public static Point operator +(Point c1, int scalar)
        {
            var coords = c1.Coordinates.Select(x => x + scalar).ToArray();
            return new Point(coords);
        }

        public static Point operator -(Point c1, int scalar)
        {
            var coords = c1.Coordinates.Select(x => x - scalar).ToArray();
            return new Point(coords);
        }

        public static Point operator *(Point c1, int scalar)
        {
            var coords = c1.Coordinates.Select(x => x * scalar).ToArray();
            return new Point(coords);
        }

        public static Point operator /(Point c1, int scalar)
        {
            var coords = c1.Coordinates.Select(x => x / scalar).ToArray();
            return new Point(coords);
        }

        public static Point operator -(Point c1)
        {
            var coords = c1.Coordinates.Select(x => -x).ToArray();
            return new Point(coords);
        }

        public int this[int i]
        {
            get { return Coordinates[i]; }
            set { Coordinates[i] = value; }
        }

        public override string ToString()
        {
            var coordinatesStr = "[" + Coordinates.Select(x => x.ToString()).Aggregate((x, n) => x + "; " + n) + "]";
            return "Dimensions: " + Dimensions + ", Coordinates: " + coordinatesStr;
        }

        public static Point CreateSameAllDimensions(int dimensions, int distance)
        {
            var coords = Enumerable.Repeat(distance, dimensions).ToArray();
            return new Point(coords);
        }

        public static List<Point> GeneratePerpendicularOffsets(int dimensions, bool includeSelf = false)
        {
            var offsets = new List<Point>();

            for (var i = 0; i < dimensions; i++)
            {
                var coordinateNegative = CreateSameAllDimensions(dimensions, 0);
                coordinateNegative[i] = -1;
                offsets.Add(coordinateNegative);

                var coordinatePositive = CreateSameAllDimensions(dimensions, 0);
                coordinatePositive[i] = 1;
                offsets.Add(coordinatePositive);
            }

            if (includeSelf)
            {
                var self = CreateSameAllDimensions(dimensions, 0);
                offsets.Add(self);
            }

            return offsets;
        }

        public static List<Point> GenerateAllOffsets(int dimensions, bool includeSelf)
        {
            if (dimensions < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(dimensions));
            }

            var offsets = new List<int[]>
            {
                new int[0]
            };

            for (var i = 0; i < dimensions; i++)
            {
                var newOffsets = new List<int[]>();
                foreach (var coordinates in offsets)
                {
                    for (var newCoordinate = -1; newCoordinate <= 1; newCoordinate++)
                    {
                        var newCoordinates = new int[coordinates.Length + 1];
                        newCoordinates[coordinates.Length] = newCoordinate;
                        Array.Copy(coordinates, 0, newCoordinates, 0, coordinates.Length);
                        newOffsets.Add(newCoordinates);
                    }
                }
                offsets = newOffsets;
            }

            var pointsEnumerable = offsets.Select(x => new Point(x));
            List<Point> points;
            if (includeSelf)
            {
                points = pointsEnumerable.ToList();
            }
            else
            {
                var self = CreateSameAllDimensions(dimensions, 0);
                points = pointsEnumerable.Where(x => !x.Equals(self)).ToList();
            }

            return points;
        }
    }
}