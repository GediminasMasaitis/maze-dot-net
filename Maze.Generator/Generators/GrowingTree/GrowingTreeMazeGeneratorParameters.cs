using System;

namespace Maze.Generator.Generators.GrowingTree
{
    public class GrowingTreeMazeGeneratorParameters
    {
        private double _breadth;
        private double _lastChanceLooping;
        private double _firstChanceLooping;
        private double _horizontalBias;
        private double _verticalBias;

        public GrowingTreeMazeGeneratorParameters(double breadth = 0, double lastCanceLooping = 0, double firstChanceLooping = 0)
        {
            Breadth = breadth;
            LastChanceLooping = lastCanceLooping;
            FirstChanceLooping = firstChanceLooping;
        }

        public double Breadth
        {
            get { return _breadth; }
            set
            {
                ParameterCheck(value);
                _breadth = value;
            }
        }

        public double LastChanceLooping
        {
            get { return _lastChanceLooping; }
            set
            {
                ParameterCheck(value);
                _lastChanceLooping = value;
            }
        }

        public double FirstChanceLooping
        {
            get { return _firstChanceLooping; }
            set
            {
                ParameterCheck(value);
                _firstChanceLooping = value;
            }
        }

        public double HorizontalBias
        {
            get { return _horizontalBias; }
            set
            {
                ParameterCheck(value);
                _horizontalBias = value;
            }
        }

        public double VerticalBias
        {
            get { return _verticalBias; }
            set
            {
                ParameterCheck(value);
                _verticalBias = value;
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