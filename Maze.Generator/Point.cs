using System;
using System.Linq;

namespace Maze.Generator
{
    public class Point
    {
        public Point(params int[] coords)
        {
            if (coords.Length == 0)
            {
                throw new ArgumentException("Point cannot be zero-dimensional, provide at least one dimension");
            }

            Coordinates = coords;
        }

        public static Point CreateSameAllDimensions(int dimensions, int distance)
        {
            var coords = Enumerable.Repeat(distance, dimensions).ToArray();
            return new Point(coords);
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
    }
}