using System.Drawing;
using Maze.Core.Maps;
using Maze.Core.Results;
using Point = Maze.Core.Common.Point;

namespace Maze.Drawing.Renderers
{
    public class ImageMapRenderer : GraphicsMapRenderer
    {
        public ImageMapRenderer(IMap map, Image image) : base(map, new Point(image.Width, image.Height), GetGraphicsFromImage(image))
        {
            Image = image;
            Cache = true;
            SaveImageOnCompletion = false;
            ImagePath = @".\maze.png";
        }

        public bool SaveImageOnCompletion { get; set; }
        public string ImagePath { get; set; }

        private Image _image;
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                Graphics = GetGraphicsFromImage(Image);
            }
        }

        private static Graphics GetGraphicsFromImage(Image image)
        {
            var graphics = Graphics.FromImage(image);
            return graphics;
        }

        public override void Render(MazeGenerationResults results)
        {
            base.Render(results);
            if (results.ResultsType == GenerationResultsType.GenerationCompleted && SaveImageOnCompletion)
            {
                Image.Save(ImagePath);
            }
        }

        private void SaveImage(Image image, string path)
        {
        }
    }
}