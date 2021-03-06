﻿using Maze.Core.Exceptions;

namespace Maze.Core.Common
{
    public class Rectangle
    {
        public Rectangle(Point from, Point to, bool toInclusive = false)
        {
            if (from.Dimensions != to.Dimensions)
            {
                throw new IncorrectDimensionsException(new []{ from.Dimensions }, to.Dimensions);
            }
            From = from;
            To = to;
            ToInclusive = toInclusive;
            Size = To - From;
            if (ToInclusive)
            {
                Size += 1;
            }
        }

        public Point From { get; }
        public Point To { get; }
        public bool ToInclusive { get; }
        public Point Size { get; }
        public int Dimensions => From.Dimensions;

        public bool Contains(Point point)
        {
            var contains = point[0] >= From[0] && point[1] >= From[1] && point[0] < To[0] && point[1] < To[1];
            return contains;
        }

        public override string ToString()
        {
            return "From " + From + " to " + To + "; Size: " + Size;
        }
    }
}