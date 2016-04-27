using System;
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
        public bool AutoSyncSize { get; set; }
        private PictureBox PictureBox { get; }
        
        public PictureBoxMapRenderer(IMap map, PictureBox pictureBox) : base(map, MakeImageForPictureBox(pictureBox))
        {
            UpdateTargetInnerInvoker = UpdateTargetInner;
            PictureBox = pictureBox;
            PictureBox.SizeChanged += PictureBoxResize;
        }

        public void SyncSize()
        {
            PictureBox.Image = MakeImageForPictureBox(PictureBox);
            Image = PictureBox.Image;
        }

        private void PictureBoxResize(object sender, System.EventArgs e)
        {
            if (AutoSyncSize)
            {
                SyncSize();
            }
        }

        private static Image MakeImageForPictureBox(PictureBox target)
        {
            var bitmap = new Bitmap(target.Width, target.Height);
            target.Image = bitmap;
            return bitmap;
        }
        
        private void UpdateTarget()
        {
            if (PictureBox.InvokeRequired)
            {
                try
                {
                    PictureBox.Invoke(UpdateTargetInnerInvoker);
                }
                catch (ObjectDisposedException)
                {
                    // Om nom nom.
                }
            }
            else
            {
                UpdateTargetInner();
            }
        }

        private MethodInvoker UpdateTargetInnerInvoker { get; }

        private void UpdateTargetInner()
        {
            PictureBox.Update();
        }

        public override void RenderStep(MazeGenerationResults results)
        {
            base.RenderStep(results);
            UpdateTarget();
        }
        
        protected override void DrawPolygon(Point mapPoint, ColoredPolygon polygon)
        {
            if (PictureBox == null)
            {
                return;
            }
            base.DrawPolygon(mapPoint, polygon);
            var invalidateRect = polygon.GetBoundingRectangle();
            PictureBox.Invalidate(invalidateRect);
        }

        public override void Dispose()
        {
            PictureBox.SizeChanged -= PictureBoxResize;
            base.Dispose();
        }
    }
}