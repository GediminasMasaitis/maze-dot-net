using System.Drawing;
using Maze.Core.Maps;
using Point = Maze.Core.Common.Point;

namespace Maze.Drawing.Renderers
{
    public class ImageMapRenderer : GraphicsMapRenderer
    {
        public ImageMapRenderer(IMap map, Image image) : base(map, new Point(image.Width, image.Height), GetGraphicsFromImage(image))
        {
            Image = image;
            Cache = true;
        }

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
    }
}