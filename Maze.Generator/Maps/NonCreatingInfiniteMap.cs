﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Generator.Cells;

namespace Maze.Generator.Maps
{
    public class NonCreatingInfiniteMap : IMap
    {
        public NonCreatingInfiniteMap(int dimensions)
        {
            Dimensions = dimensions;
            Cells = new Dictionary<Point, ICell>();
        }

        public IDictionary<Point, ICell> Cells { get; }

        public bool CellExists(Point point)
        {
            return Cells.ContainsKey(point);
        }

        public ICell GetCell(Point point)
        {
            return Cells[point];
        }

        public void SetCell(ICell cell, Point point)
        {
            Cells[point] = cell;
        }

        public void RemoveCell(Point point)
        {
            Cells.Remove(point);
        }

        public bool Infinite => true;
        public int Dimensions { get; }
        public Point Size => null;
    }
}
