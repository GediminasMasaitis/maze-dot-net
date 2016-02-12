using System.Drawing;
using System.Windows.Forms;
using Maze.Core.Maps;
using Maze.Core.Results;
using Maze.Drawing.Renderers;

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

        protected override void DrawRectangle(Rectangle rectangle, Color color)
        {
            base.DrawRectangle(rectangle, color);
            PictureBox.Invalidate(rectangle);
        }
    }
}