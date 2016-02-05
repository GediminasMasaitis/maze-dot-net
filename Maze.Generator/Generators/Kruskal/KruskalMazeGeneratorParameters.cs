using System;

namespace Maze.Generator.Generators.Kruskal
{
    public class KruskalMazeGeneratorParameters
    {
        private double _looping;

        public KruskalMazeGeneratorParameters(double looping = 0, bool showAllWallChecking = false)
        {
            Looping = looping;
            ShowAllWallChecking = showAllWallChecking;
        }
        public bool ShowAllWallChecking { get; }
        public double Looping
        {
            get { return _looping; }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Value must be between 0 and 1");
                }
                _looping = value;
            }
        }
    }
}