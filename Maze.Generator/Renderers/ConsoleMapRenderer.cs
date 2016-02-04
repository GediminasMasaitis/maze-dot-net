using System;
using Maze.Generator.Maps;

namespace Maze.Generator.Renderers
{
    public class ConsoleMapRenderer : TextMapRenderer
    {
        public ConsoleMapRenderer(IMap map, bool shouldClear) : base(map, shouldClear)
        {
        }

        private int ClearedBefore { get; set; }

        public override void TextOut(string str)
        {
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