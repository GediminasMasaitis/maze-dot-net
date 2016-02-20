using System.Drawing;
using System.Windows.Forms;
using Maze.Core.Maps;
using Maze.Core.Results;
using Maze.Drawing.Common;
using Maze.Drawing.Renderers;
using Point = Maze.Core.Common.Point;

namespace Maze.WinFormsGDI
{
    internal class PictureBoxMapRenderer : ImageMapRenderer
    {
        public PictureBoxMapRenderer(IMap map, PictureBox pictureBox) : base(map, MakeImageForPictureBox(pictureBox))
        {
            PictureBox = pictureBox;
        }

        private static Image MakeImageForPictureBox(PictureBox target)
        {
            var bitmap = new Bitmap(target.Width, target.Height);
            target.Image = bitmap;
            return bitmap;
        }
        
        private PictureBox PictureBox { get; }
       
        private void UpdateTarget()
        {
            if (PictureBox.InvokeRequired)
            {
                PictureBox.Invoke(new MethodInvoker(() =>
                {
                    PictureBox.Update();
                }));
            }
            else
            {
                PictureBox.Update();
            }
        }

        public override void Render(MazeGenerationResults results)
        {
            base.Render(results);
            UpdateTarget();
        }
        
        protected override void DrawPolygon(Point mapPoint, ColoredPolygon polygon)
        {
            base.DrawPolygon(mapPoint, polygon);
            var invalidateRect = polygon.GetSurroundingRectangle();
            PictureBox.Invalidate(invalidateRect);
        }
    }
}