using System;
using System.Windows.Forms;
using Maze.Core.Common;
using Maze.Core.Maps;
using Maze.Core.Results;
using Maze.Drawing.Renderers;

namespace Maze.WinFormsGDI
{
    // TODO: Flickers a lot. Needs some double-buffering or something.
    internal class ControlMapRenderer : GraphicsMapRenderer
    {
        public ControlMapRenderer(IMap map, Control control) : base(map, new Point(control.Width, control.Height), control.CreateGraphics())
        {
            RefreshSynchro = new object();
            Control = control;
            Control.Paint += ControlOnPaint;
        }

        private void ControlOnPaint(object sender, PaintEventArgs paintEventArgs)
        {
            RenderMap();
        }

        private object RefreshSynchro { get; }
        private Control Control { get; }
        private IAsyncResult RefreshAsyncResult { get; set; }

        public override void RenderStep(MazeGenerationResults results)
        {
            if (RefreshAsyncResult?.IsCompleted ?? true)
            {
                RefreshAsyncResult = Control.BeginInvoke(new MethodInvoker(() => Control.Refresh()));
            }
        }

        public override void Dispose()
        {
            Control.Paint -= ControlOnPaint;
        }
    }
}