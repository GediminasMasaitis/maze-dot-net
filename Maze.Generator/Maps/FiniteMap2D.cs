using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Maze.Generator.Cells;

namespace Maze.Generator.Maps
{
    public class FiniteMap2D : MapBase2D
    {

        public FiniteMap2D(int width, int height)
        {
            Size = new Point(width, height);
            InnerCells = new ICell[width, height];
            for (var i = 0; i < Width; i++)
            {
                for (var j = 0; j < Heigth; j++)
                {
                    InnerCells[i,j] = new Cell();
                }
            }
        }

        private ICell[,] InnerCells { get; }
        //public override IEnumerable<ICell> FindCells() => InnerCells.Cast<ICell>();

        public override bool CellExists2D(Point point)
        {
            return point[0] >= 0 && point[1] >= 0 && InnerCells.GetLength(0) > point[0] && InnerCells.GetLength(1) > point[1];
        }

        public override ICell GetCell2D(Point point)
        {
            /*if (!CellExists2D(point))
            {
                throw new ArgumentOutOfRangeException();
            }*/
            return InnerCells[point[0], point[1]];
        }

        public override void SetCell2D(ICell cell, Point point)
        {
            if (!CellExists2D(point))
            {
                throw new ArgumentOutOfRangeException();
            }
            InnerCells[point[0], point[1]] = cell;
        }

        public int Width => Size[0];
        public int Heigth => Size[1];
        public override bool Infinite => false;
        public override Point Size { get; }
        //public override IEnumerator<ICell> GetEnumerator()
        //{
        //    return new GenericEnumerator<ICell>(Cells.GetEnumerator());
        //}
    }

    class GenericEnumerator<T> : IEnumerator<T>
    {
        public GenericEnumerator(IEnumerator innerEnumerator)
        {
            InnerEnumerator = innerEnumerator;
        }

        public IEnumerator InnerEnumerator { get; }
        public bool MoveNext() => InnerEnumerator.MoveNext();

        public void Reset() => InnerEnumerator.Reset();
        T IEnumerator<T>.Current => (T) Current;

        public object Current => InnerEnumerator.Current;
        public void Dispose()
        {
            
        }
    }
}