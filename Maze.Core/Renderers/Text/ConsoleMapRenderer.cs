using System;
using System.Collections.Generic;
using Maze.Core.Cells;
using Maze.Core.Maps;

namespace Maze.Core.Renderers.Text
{
    public class ConsoleMapRenderer : TextMapRenderer
    {
        private int ClearedBefore { get; set; }
        public IDictionary<CellDisplayState, ConsoleColor> Colors { get; set; }
        public bool ShouldColor { get; set; }
        public ConsoleMapRenderer(IMap map, bool shouldClear, bool shouldColor) : base(map, shouldClear)
        {
            Bulk = !shouldColor;
            ShouldColor = shouldColor;
            Colors = new Dictionary<CellDisplayState, ConsoleColor>
            {
                { CellDisplayState.Active, ConsoleColor.Red },
                { CellDisplayState.Path, ConsoleColor.Green },
                { CellDisplayState.PathWillReturn, ConsoleColor.Yellow },
                { CellDisplayState.Wall, ConsoleColor.Gray },
                { CellDisplayState.Unspecified, ConsoleColor.Gray }
            };
        }


        public override void TextOut(string str, ICell cell = null)
        {
            if (ShouldColor && cell != null)
            {
                var color = Colors[cell.DisplayState];
                Console.ForegroundColor = color;
            }
            Console.Write(str);
        }

        
        public override void Clear()
        {
            if (ClearedBefore > 50)
            {
                Console.Clear();
                ClearedBefore = 0;
            }
            else
            {
                Console.SetCursorPosition(0, 0);
                ClearedBefore++;
            }
        }
    }
}