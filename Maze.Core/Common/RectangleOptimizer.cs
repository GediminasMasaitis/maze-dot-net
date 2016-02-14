using System;
using System.Collections.Generic;
using System.Linq;
using Maze.Core.Cells;

namespace Maze.Core.Common
{
    public class RectangleOptimizer
    {
        public IDictionary<CellState, IList<Rectangle>> OptimizeAll(IDictionary<Point, ICell> cells)
        {
            var allRectangles = new Dictionary<CellState, IList<Rectangle>>();
            var allStates = Enum.GetValues(typeof (CellState)).Cast<CellState>();
            foreach (var cellState in allStates)
            {
                var pointsEnum = cells.Where(x => x.Value.State == cellState).Select(x => x.Key);
                var optimizedRectangles = Optimize(pointsEnum);
                allRectangles.Add(cellState, optimizedRectangles);
            }
            return allRectangles;
        }

        public IList<Rectangle> Optimize(IDictionary<Point, ICell> cells, CellState targetState)
        {
            var pointsEnum = cells.Where(x => x.Value.State == targetState).Select(x => x.Key);
            return Optimize(pointsEnum);
        }

        public IList<Rectangle> Optimize(IEnumerable<Point> points)
        {
            var pointSet = new HashSet<Point>(points);
            var rectangles = new List<Rectangle>();
            while (pointSet.Count > 0)
            {
                var point = pointSet.First();
                var offsets = Point.GeneratePerpendicularOffsets(point.Dimensions);
                List<Point> maxOtherPoints = null;
                Point maxFirstPoint = null;
                Point maxLastPoint = null;
                for (var i = 0; i < offsets.Count; i += 2)
                {
                    var otherPoints = new List<Point>();
                    var firstPoint = point;
                    var lastPoint = point;
                    for (var j = 0; j < 2; j++)
                    {
                        var offset = offsets[i+j];
                        var previousPoint = point;
                        while (true)
                        {
                            var currentPoint = previousPoint + offset;
                            if (pointSet.Contains(currentPoint))
                            {
                                otherPoints.Add(currentPoint);
                                previousPoint = currentPoint;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (j == 0)
                        {
                            firstPoint = previousPoint;
                        }
                        else
                        {
                            lastPoint = previousPoint;
                        }
                    }
                    if (maxOtherPoints == null || otherPoints.Count > maxOtherPoints.Count)
                    {
                        maxOtherPoints = otherPoints;
                        maxFirstPoint = firstPoint;
                        maxLastPoint = lastPoint;
                    }
                }
                var rect = new Rectangle(maxFirstPoint, maxLastPoint, true);
                rectangles.Add(rect);
                foreach (var maxOtherPoint in maxOtherPoints)
                {
                    pointSet.Remove(maxOtherPoint);
                }
                pointSet.Remove(point);
            }

            return rectangles;
        }
    }
}
