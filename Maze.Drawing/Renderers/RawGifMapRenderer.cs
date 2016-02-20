using System.Drawing;
using System.IO;
using Maze.Core.Maps;
using Maze.Core.Results;
using Maze.Drawing.Common;
using Point = Maze.Core.Common.Point;

namespace Maze.Drawing.Renderers
{
    public class RawGifMapRenderer : ImageMapRenderer
    {
        public RawGifMapRenderer(IMap map, Point targetSize, string filePath, int frameDelay = 10) : base(map, new Bitmap(targetSize[0], targetSize[1]))
        {
            FilePath = filePath;
            FrameDelay = frameDelay;
            var ms = new MemoryStream();
            GifImage = new GifImage(ms);
            GifImage.DefaultFrameDelay = FrameDelay;
            GifImage.DefaultWidth = targetSize[0];
            GifImage.DefaultHeight = targetSize[1];
        }

        public string FilePath { get; set; }
        public int FrameDelay { get; set; }

        private GifImage GifImage { get; set; }

        public override void Render(MazeGenerationResults results)
        {
            base.Render(results);
            GifImage.AddFrame(Image, FrameDelay);
            if (results.ResultsType == GenerationResultsType.GenerationCompleted)
            {
                GifImage.Complete();
                GifImage.OutStream.Position = 0;
                using (var fs = new FileStream(FilePath, FileMode.Create))
                {
                    GifImage.OutStream.CopyTo(fs);
                }
            }
        }
    }
}