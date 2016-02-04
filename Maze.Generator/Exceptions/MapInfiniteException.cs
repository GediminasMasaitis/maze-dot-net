using System;

namespace Maze.Generator.Exceptions
{
    public class MapInfiniteException : Exception
    {
        public MapInfiniteException(string message = "", bool? shouldBeInfinite = null, bool? wasInfinite = null) : base(message)
        {
            ShouldBeInfinite = shouldBeInfinite;
            WasInfinite = wasInfinite;
        }

        public bool? ShouldBeInfinite { get; }
        public bool? WasInfinite { get; }
    }
}