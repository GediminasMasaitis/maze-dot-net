using System;

namespace Maze.Generator.Generators.AldousBroder
{
    public class AldousBroderMazeGeneratorParameters
    {
        private double _looping;

        public double Looping
        {
            get { return _looping; }
            set
            {
                ParameterCheck(value);
                _looping = value;
            }
        }

        private void ParameterCheck(double parameter)
        {
            if (parameter < 0 || parameter > 1)
            {
                throw new ArgumentException("Value must be between 0 and 1");
            }
        }
    }
}