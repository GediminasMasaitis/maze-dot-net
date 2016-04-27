using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Maze.Core.Cells;
using Maze.Core.Maps;
using Maze.Core.Results;
using Maze.Drawing.Common;
using Maze.Drawing.Renderers;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using Point = Maze.Core.Common.Point;

namespace Maze.WinFormsOpenTK
{
    class GLControlMapRenderer : DrawingMapRenderer
    {
        public GLControlMapRenderer(GLControl target, IMap map) : base(map, new Point(target.Width, target.Height))
        {
            LocalBuffer = new RectangleWithColor[map.Size[0],map.Size[1]];
            Target = target;
            Target.Paint += Target_Paint;
            SetupViewport();
            Clear();
        }

        private GLControl Target { get; }
        
        private RectangleWithColor[,] LocalBuffer { get; set; }

        private bool ClearRequested { get; set; }

        private void Target_Paint(object sender, PaintEventArgs e)
        {
            if (ClearRequested)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                ClearRequested = false;
            }

            RenderLocalBuffer();
        }

        public void Clear()
        {
            ClearRequested = true;
        }

        private void SetupViewport()
        {
            GL.ClearColor(Colors[CellDisplayState.Wall]);
            int w = Target.Width;
            int h = Target.Height;
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
            GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
        }

        private void RenderLocalBuffer()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (LocalBuffer == null)
            {
                return;
            }
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Begin(PrimitiveType.Quads);

            foreach (var quad in LocalBuffer)
            {
                if(quad == null)
                {
                    continue;
                }
                GL.Color3(quad.Color);
                var rect = quad.Rectangle;
                RenderRectangle(rect);
            }

            GL.End();
            Target.SwapBuffers();
        }

        private static void RenderRectangle(Rectangle rect)
        {
            GL.Vertex2(rect.Left, rect.Bottom);
            GL.Vertex2(rect.Left, rect.Top);
            GL.Vertex2(rect.Right, rect.Top);
            GL.Vertex2(rect.Right, rect.Bottom);
        }
        
        private void UpdateTarget()
        {
            if (Target.InvokeRequired)
            {
                Target.Invoke(new MethodInvoker(() =>
                {
                    Target.Invalidate();
                    Target.Update();
                }));
            }
            else
            {
                Target.Invalidate();
                Target.Update();
            }
        }

        public override void RenderStep(MazeGenerationResults results)
        {
            base.RenderStep(results);
            UpdateTarget();
        }

        protected override void DrawPolygon(Point mapPoint, ColoredPolygon polygon)
        {
            throw new NotImplementedException();
        }

        /*protected override void DrawRectangle(Point mapPoint, Rectangle rectangle, Color color)
        {
            var quad = new RectangleWithColor(color, rectangle);
            LocalBuffer[mapPoint[0], mapPoint[1]] = quad;
        }*/

        public override void Dispose()
        {
            base.Dispose();
            Clear();
            Target.Paint += Target_Paint;
        }

    }
}