using System;

namespace Maze.Core.Exceptions
{
    public class IncorrectFinityException : Exception
    {
        public IncorrectFinityException(bool? expectedInfinite = null, bool? foundInfinite = null, string message = "Incorect map finity type") : base(message)
        {
            ExpectedInfinite = expectedInfinite;
            FoundInfinite = foundInfinite;
        }

        public bool? ExpectedInfinite { get; }
        public bool? FoundInfinite { get; }
    }
}