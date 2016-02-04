using System;
using System.Collections.Generic;
using System.Text;
using Maze.Generator.Cells;
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
            /*DisplayChars = new Dictionary<CellState, string>
            {
                { CellState.Wall, "#" },
                { CellState.Empty, " " }
            };*/
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
        public IDictionary<CellDisplayState, string> DisplayChars { get; set; }
        //public IDictionary<CellState, string> DisplayChars { get; set; }

        public void Render(MazeGenerationResults results)
        {
            RenderMap(Map);
        }        

        private void RenderMap(IMap map)
        {
            if (map.Infinite)
            {
                throw new MapInfiniteException("Map cannot be infinite using this renderer", false, map.Infinite);
            }
            if (map.Dimensions != 2)
            {
                throw new IncorrectDimensionsException(expectedDimensions: 2, foundDimensions: map.Dimensions, message: "Map can only be two-dimensional using this renderer");
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
                    var cell = map.GetCell(new Point(i, j));
                    var state = cell.DisplayState;
                    var ch = DisplayChars[state];
                    //TextOut(ch);
                    builder.Append(ch);
                }
                //TextOut(Environment.NewLine);
                builder.AppendLine();
            }
            //TextOut(Environment.NewLine);
            builder.AppendLine();
            var finalStr = builder.ToString();
            TextOut(finalStr);
        }

        public abstract void TextOut(string str);

        public virtual void Clear()
        {
            
        }

        public virtual void Dispose()
        {
            
        }
    }
}