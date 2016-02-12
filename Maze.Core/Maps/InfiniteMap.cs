using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Maze.Core.Cells;
using Maze.Core.Common;

namespace Maze.Core.Maps
{
    public class InfiniteMap : IMap
    {
        public InfiniteMap(int dimensions)
        {
            Dimensions = dimensions;
            InnerCells = new Dictionary<Point, ICell>();
        }

        private IDictionary<Point, ICell> InnerCells { get; }
        //public IEnumerable<ICell> FindCells() => InnerCells.Values;

        private void PointDimensionCheck(Point point)
        {
            if (point.Dimensions != Dimensions)
            {
                throw new ArgumentException("Point has an icorrect amount of dimensions (has " + point.Dimensions + ", should be " + Dimensions + ")");
            }
        }

        //public IEnumerable<ICell> CellsA => Cells;

        public bool CellExists(Point point)
        {
            PointDimensionCheck(point);
            //GetBuckets(Cells);
            if (!InnerCells.ContainsKey(point))
            {
                var cell = new Cell();
                InnerCells.Add(point,cell);
                //AddToCustomDict(point);
            }
            return true;
        }

        private IDictionary<int, IList<Point>> CustomDict { get; set; } = new Dictionary<int, IList<Point>>();

        private void AddToCustomDict(Point point)
        {
            var hash = point.GetHashCode();

            if (!CustomDict.ContainsKey(hash))
            {
                CustomDict.Add(hash, new List<Point>());
            }

            if(InnerCells.Count > 50000)
            { 
                var counts = CustomDict.Values.Select(x => x.Count);
                var distribution = counts.GroupBy(x => x, (i,x) => new KeyValuePair<int, int>(i, x.Count())).OrderBy(x=>x.Key).ToDictionary(x=>x.Key, x=>x.Value);

                var average = distribution.Sum(x => x.Key*x.Value)/(double)CustomDict.Count;
            }

            CustomDict[hash].Add(point);
        }

        private int[] GetBuckets(IDictionary<Point, ICell> dict)
        {
            var field = dict.GetType().GetField("buckets", BindingFlags.NonPublic | BindingFlags.Instance);
            var buckets = (int[])field?.GetValue(dict);
            var ordered = buckets?.OrderByDescending(x => x).ToArray();
            return ordered;
        }

        public ICell GetCell(Point point)
        {
            //CellExists(point);
            PointDimensionCheck(point);
            ICell cell;
            var success = InnerCells.TryGetValue(point, out cell);
            if (!success)
            {
                cell = new Cell();
                InnerCells.Add(point, cell);
            }
            return cell;
        }

        public void SetCell(ICell cell, Point point)
        {
            InnerCells[point] = cell;
        }

        public bool Infinite => true;
        public int Dimensions { get; }
        public Point Size => null;

        //IEnumerator<ICell> IEnumerable<ICell>.GetEnumerator() => Cells.Values.GetEnumerator();
        //public IEnumerator GetEnumerator() => Cells.Values.GetEnumerator();
    }
}