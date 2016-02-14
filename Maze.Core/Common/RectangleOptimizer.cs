using System;
using System.Collections.Generic;
using System.Linq;
using Maze.Core.Cells;

namespace Maze.Core.Common
{
    public class RectangleOptimizer
    {
        public IList<Rectangle> Optimize(IDictionary<Point, ICell> initialDict, CellState targetState)
        {
            var rectangles = new List<Rectangle>();
            var cells = initialDict.Where(x => x.Value.State == targetState).ToDictionary(x=>x.Key, x=>x.Value);
            while (cells.Count > 0)
            {
                var pair = cells.First();
                var point = pair.Key;
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
                            ICell currentCell;
                            if (cells.TryGetValue(currentPoint, out currentCell))
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
                    cells.Remove(maxOtherPoint);
                }
                cells.Remove(point);
            }

            return rectangles;
        }
    }
}
