using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Maze.Core.Maps;
using Maze.Core.Results;
using Maze.Drawing.Common;
using Point = Maze.Core.Common.Point;

namespace Maze.Drawing.Renderers
{
    public class BRGifMapRenderer : DrawingMapRenderer
    {
        public BRGifMapRenderer(IMap map, Point targetSize, string filePath, int frameDelay = 10) : base(map, targetSize)
        {
            FilePath = filePath;
            FrameDelay = frameDelay;
            var ms = new MemoryStream();
            GifImage = new GifImage(ms);
            GifImage.DefaultFrameDelay = FrameDelay;
            GifImage.DefaultWidth = targetSize[0];
            GifImage.DefaultHeight = targetSize[1];

            Brushes = new Dictionary<Color, Brush>();
            foreach (var color in Colors)
            {
                Brushes.Add(color.Value, new SolidBrush(color.Value));
            }

            var initialImage = new Bitmap(targetSize[0], targetSize[1]);
            //var initialGraphics = Graphics.FromImage(initialImage);
            //initialGraphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(0,0,initialImage.Width, initialImage.Height));
            GifImage.AddFrame(initialImage, FrameDelay);
        }

        public string FilePath { get; set; }
        public int FrameDelay { get; set; }

        protected IDictionary<Color, Brush> Brushes { get; }

        private GifImage GifImage { get; set; }
        private IList<ColoredPolygon> Polygons { get; set; }

        public override void RenderStep(MazeGenerationResults results)
        {
            Polygons = new List<ColoredPolygon>();
            base.RenderStep(results);
            var allPoints = Polygons.SelectMany(x => x.Points).ToArray();
            var commonPolygon = new Polygon(allPoints);
            var boundingRectangle = commonPolygon.GetBoundingRectangle();
            var bmp = new Bitmap(boundingRectangle.Width, boundingRectangle.Height);
            var graphics = Graphics.FromImage(bmp);

            foreach (var polygon in Polygons)
            {
                var adjustedPoints = polygon.Points.Select(x => new System.Drawing.Point(x.X - boundingRectangle.X, x.Y - boundingRectangle.Y)).ToArray();
                graphics.FillPolygon(Brushes[polygon.Color], adjustedPoints);
            }

            GifImage.AddFrame(bmp, FrameDelay, boundingRectangle.X, boundingRectangle.Y);
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

        protected override void DrawPolygon(Point mapPoint, ColoredPolygon polygon)
        {
            Polygons.Add(polygon);
        }
    }
}