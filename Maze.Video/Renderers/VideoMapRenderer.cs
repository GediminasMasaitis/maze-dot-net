using System.Drawing;
using AForge.Video.FFMPEG;
using Maze.Core.Maps;
using Maze.Core.Results;
using Maze.Drawing.Renderers;

namespace Maze.Video.Renderers
{
    public class VideoMapRenderer : ImageMapRenderer
    {
        public VideoMapRenderer(IMap map, Image image) : base(map, image)
        {
            Video = new VideoFileWriter();
            Video.Open("test.mp4", image.Width, image.Height, 60, VideoCodec.MPEG4, 1600000);
        }

        private VideoFileWriter Video { get; }

        public override void Render(MazeGenerationResults results)
        {
            base.Render(results);
            // TODO: fix ugly casting later.
            var bmp = (Bitmap) Image;
            Video.WriteVideoFrame(bmp);

            if (results.ResultsType == GenerationResultsType.GenerationCompleted)
            {
                Video.Close();
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            Video.Dispose();
        }
    }
}
