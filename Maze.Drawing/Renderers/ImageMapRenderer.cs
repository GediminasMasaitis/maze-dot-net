using System.Drawing;
using Maze.Core.Maps;
using Maze.Core.Results;
using Maze.Drawing.Common;
using Point = Maze.Core.Common.Point;

namespace Maze.Drawing.Renderers
{
    public class ImageMapRenderer : GraphicsMapRenderer
    {
        public ImageMapRenderer(IMap map, Image image) : base(map, image.Size.ToMazePoint(), GetGraphicsFromImage(image))
        {
            Cache = true;
            SaveImageOnCompletion = false;
            ImagePath = @".\maze.png";
            Image = image;
        }

        public bool SaveImageOnCompletion { get; set; }
        public string ImagePath { get; set; }

        private Image _image;
        public Image Image
        {
            get => _image;
            set
            {
                _image = value;
                Graphics = GetGraphicsFromImage(Image);
                TargetSize = Image.Size.ToMazePoint();
                if (Map != null)
                {
                    RenderMap(true);
                }
            }
        }

        private static Graphics GetGraphicsFromImage(Image image)
        {
            var graphics = Graphics.FromImage(image);
            return graphics;
        }

        public override void RenderStep(MazeGenerationResults results)
        {
            base.RenderStep(results);
            if (results.ResultsType == GenerationResultsType.GenerationCompleted && SaveImageOnCompletion)
            {
                SaveImage(false);
            }
        }

        public void SaveImage(bool rerender = true)
        {
            if (rerender)
            {
                RenderMap();
            }
            Image.Save(ImagePath);
        }

        private void SaveImage(Image image, string path)
        {
        }
    }
}