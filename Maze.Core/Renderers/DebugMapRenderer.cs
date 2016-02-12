using System.Diagnostics;
using Maze.Core.Cells;
using Maze.Core.Maps;

namespace Maze.Core.Renderers
{
    // LOL
    public class DebugMapRenderer : TextMapRenderer
    {
        public DebugMapRenderer(IMap map) : base(map, false)
        {
        }

        public override void TextOut(string str, ICell cell = null)
        {
            Debug.Write(str);
        }

    }
}