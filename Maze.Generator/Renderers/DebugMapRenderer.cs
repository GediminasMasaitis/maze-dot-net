using System.Diagnostics;
using Maze.Generator.Maps;

namespace Maze.Generator.Renderers
{
    // LOL
    public class DebugMapRenderer : TextMapRenderer
    {
        public DebugMapRenderer(IMap map) : base(map, false)
        {
        }

        public override void TextOut(string str)
        {
            Debug.Write(str);
        }

    }
}