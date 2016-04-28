using System;
using System.Collections.Generic;
using System.Text;
using Maze.Core.Cells;
using Maze.Core.Common;
using Maze.Core.Exceptions;
using Maze.Core.Maps;
using Maze.Core.Results;

namespace Maze.Core.Renderers.Text
{
    public abstract class TextMapRenderer : IInstantMapRenderer
    {
        public TextMapRenderer(IMap map, bool shouldClear)
        {
            Map = map;
            ShouldClear = shouldClear;
            DisplayChars = new Dictionary<CellDisplayState, string>
            {
                { CellDisplayState.Wall, "#" },
                { CellDisplayState.PathWillReturn, "." },
                { CellDisplayState.Path, " " },
                { CellDisplayState.Active, "X"},
                { CellDisplayState.Unspecified, "?" }
            };
        }

        public IMap Map { get; }
        public bool ShouldClear { get; set; }
        public int Layer { get; set; }
        public IDictionary<CellDisplayState, string> DisplayChars { get; set; }
        public virtual bool Bulk { get; set; }

        public void RenderStep(MazeGenerationResults results)
        {
            RenderMap();
        }        

        public void RenderMap()
        {
            if (Map.Infinite)
            {
                throw new IncorrectFinityException(false, Map.Infinite);
            }
            if (Map.Dimensions != 2 && Map.Dimensions != 3)
            {
                throw new IncorrectDimensionsException(new[] { 2, 3 }, Map.Dimensions);
            }
            if (ShouldClear)
            {
                Clear();
            }
            var builder = new StringBuilder();
            for (var i = 0; i < Map.Size[0]; i++)
            {
                for (var j = 0; j < Map.Size[1]; j++)
                {
                    var point = Map.Dimensions == 2 ? new Point(i, j) : new Point(i, j, Layer);
                    var cell = Map.GetCell(point);
                    var state = cell.DisplayState;
                    var ch = DisplayChars[state];
                    if (Bulk)
                    {
                        builder.Append(ch);
                    }
                    else
                    {
                        TextOut(ch, cell);
                    }
                }
                if (Bulk)
                {
                    builder.AppendLine();
                }
                else
                {
                    TextOut(Environment.NewLine);
                }   
            }
            if (Bulk)
            {
                builder.AppendLine();
                var finalStr = builder.ToString();
                TextOut(finalStr);
            }
            else
            {
                TextOut(Environment.NewLine);
            }
        }

        public abstract void TextOut(string str, ICell cell = null);

        public virtual void Clear()
        {
            
        }

        public virtual void Dispose()
        {
            
        }
    }
}