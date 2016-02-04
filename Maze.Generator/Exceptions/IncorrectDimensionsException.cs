using System;

namespace Maze.Generator.Exceptions
{
    public class IncorrectDimensionsException : Exception
    {
        public IncorrectDimensionsException(int? expectedDimensions = null, int? foundDimensions = null, string message = "Incorrect count of dimension") : base(message)
        {
            ExpectedDimensions = expectedDimensions;
            FoundDimensions = foundDimensions;
        }

        public int? ExpectedDimensions { get; }
        public int? FoundDimensions { get; }
    }
}