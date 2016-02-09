using System;
using System.Collections.Generic;
using System.Text;
using Maze.Generator.Cells;
using Maze.Generator.Common;
using Maze.Generator.Exceptions;
using Maze.Generator.Maps;
using Maze.Generator.Results;

namespace Maze.Generator.Renderers
{
    public abstract class TextMapRenderer : IMapRenderer
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

        public void Render(MazeGenerationResults results)
        {
            RenderMap(Map);
        }        

        private void RenderMap(IMap map)
        {
            if (map.Infinite)
            {
                throw new MapInfiniteException(false, map.Infinite);
            }
            if (map.Dimensions != 2 && map.Dimensions != 3)
            {
                throw new IncorrectDimensionsException(new[] { 2, 3 }, map.Dimensions);
            }
            if (ShouldClear)
            {
                Clear();
            }
            var builder = new StringBuilder();
            for (var i = 0; i < map.Size[0]; i++)
            {
                for (var j = 0; j < map.Size[1]; j++)
                {
                    var point = Map.Dimensions == 2 ? new Point(i, j) : new Point(i, j, Layer);
                    var cell = map.GetCell(point);
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