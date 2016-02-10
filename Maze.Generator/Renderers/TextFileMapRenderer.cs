using System.IO;
using System.Text;
using Maze.Generator.Cells;
using Maze.Generator.Maps;

namespace Maze.Generator.Renderers
{
    public class TextFileMapRenderer : TextMapRenderer
    {
        public TextFileMapRenderer(IMap map, string filePath) : base(map, false)
        {
            FileStream = File.OpenWrite(filePath);
        }

        private FileStream FileStream { get; }

        public override void TextOut(string str, ICell cell = null)
        {
            var strBytes = Encoding.UTF8.GetBytes(str);
            FileStream.Write(strBytes,0,strBytes.Length);
        }

        public override void Clear()
        {

        }

        public override void Dispose()
        {
            FileStream.Dispose();
        }
    }
}