using System;

namespace Maze.Generator.Exceptions
{
    public class MapInfiniteException : Exception
    {
        public MapInfiniteException(bool? expectedInfinite = null, bool? foundInfinite = null, string message = "Incorect map finity type") : base(message)
        {
            ExpectedInfinite = expectedInfinite;
            FoundInfinite = foundInfinite;
        }

        public bool? ExpectedInfinite { get; }
        public bool? FoundInfinite { get; }
    }
}