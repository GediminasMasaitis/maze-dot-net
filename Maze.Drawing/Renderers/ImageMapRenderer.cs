using System.Collections.Generic;
using System.Drawing;
using Maze.Core.Maps;
using Point = Maze.Core.Common.Point;

namespace Maze.Drawing.Renderers
{
    public class ImageMapRenderer : GraphicMapRenderer
    {
        public ImageMapRenderer(IMap map, Image image) : base(map, new Point(image.Width, image.Height))
        {
            Image = image;
            Cache = true;
            Brushes = new Dictionary<Color, Brush>();
            foreach (var color in Colors)
            {
                Brushes.Add(color.Value, new SolidBrush(color.Value));
            }
        }

        private IDictionary<Color, Brush> Brushes { get; }

        private Image _image;
        public Image Image
        {
            get { return _image; }
            set
            {
                _image = value;
                Graphics = Graphics.FromImage(Image);
            }
        }

        private Graphics Graphics { get; set; }

        protected override void DrawRectangle(Rectangle rectangle, Color color)
        {
            var brush = Brushes[color];
            Graphics.FillRectangle(brush, rectangle);
        }
    }
}