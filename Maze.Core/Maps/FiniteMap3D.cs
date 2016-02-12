using Maze.Core.Cells;
using Maze.Core.Common;

namespace Maze.Core.Maps
{
    public class FiniteMap3D : IMap
    {
        public FiniteMap3D(int width, int height, int depth)
        {
            Size = new Point(width, height, depth);
            InnerCells = new ICell[width, height, depth];
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Height; j++)
                {
                    for (var k = 0; k < Depth; k++)
                    {
                        InnerCells[i, j, k] = new Cell();
                    }
                }
            }
        }

        private int Width => Size[0];
        private int Height => Size[1];
        private int Depth => Size[2];

        private ICell[,,] InnerCells { get; }

        public bool CellExists(Point point)
        {
            return point[0] >= 0 && point[1] >= 0 && point[2] >= 0 && InnerCells.GetLength(0) > point[0] && InnerCells.GetLength(1) > point[1] && InnerCells.GetLength(2) > point[2];
        }

        public ICell GetCell(Point point)
        {
            return InnerCells[point[0], point[1], point[2]];
        }

        public void SetCell(ICell cell, Point point)
        {
            InnerCells[point[0], point[1], point[2]] = cell;
        }

        public bool Infinite => false;
        public int Dimensions => 3;
        public Point Size { get; }
    }
}