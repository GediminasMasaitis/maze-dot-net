using System.Drawing;

namespace Maze.WinFormsOpenTK
{
    class RectangleWithColor
    {
        public RectangleWithColor(Color color, Rectangle rectangle)
        {
            Color = color;
            Rectangle = rectangle;
        }

        public Color Color { get; }
        public Rectangle Rectangle { get; }

    }
}