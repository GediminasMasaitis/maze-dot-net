using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Maze.Generator;
using Maze.Generator.Cells;
using Maze.Generator.Maps;
using Maze.Generator.Renderers;
using Maze.Generator.Results;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using Point = Maze.Generator.Point;

namespace Maze.WinFormsOpenTK
{
    class GLControlMapRenderer : IMapRenderer, IDisposable
    {
        public GLControlMapRenderer(GLControl target, IMap map)
        {
            if (map.Dimensions != 2)
            {
                throw new ArgumentException(nameof(GLControlMapRenderer) + @" can only render 2D maps", nameof(map));
            }

            Colors = new Dictionary<CellDisplayState, Color>
            {
                { CellDisplayState.Wall, Color.Black },
                { CellDisplayState.PathWillReturn, Color.BurlyWood },
                { CellDisplayState.Path, Color.Green },
                { CellDisplayState.Active, Color.Brown }
            };

            Map = map;
            Target = target;
            ResultsQueue = new Queue<MazeGenerationResults>();
            ResultsQueueSynchro = new object();
            Target.Paint += Target_Paint;
            RenderingStopwatch = new Stopwatch();
            RenderingStopwatch.Start();
            RecalculateParameters(true);
            SetupViewport();
            Clear();
        }

        public IDictionary<CellDisplayState, Color> Colors { get; }

        private IMap Map { get; set; }
        private GLControl Target { get; }
        
        //private IDictionary<> 
        private MyQuad[,] LocalBuffer { get; set; }
        private Queue<MazeGenerationResults> ResultsQueue { get; set; }
        private object ResultsQueueSynchro { get; set; }
        private bool AllowResultQueue { get; } = false;
        private bool RenderUsingResultQueue { get; set; }
        private Stopwatch RenderingStopwatch { get; }


        private int InfiniteMapWidth { get; set; }
        private int InfiniteMapHeight { get; set; }
        private int MapWidth { get; set; }
        private int MapHeight { get; set; }
        private int OffsetX { get; set; }
        private int OffsetY { get; set; }
        private int CellWidth { get; set; }
        private int CellHeight { get; set; }
        private int TotalWidth { get; set; }
        private int TotalHeight { get; set; }
        private bool ClearRequested { get; set; }
        public double MininumRenderInterval { get; set; }


        #region OpenGLRendering

        private void Target_Paint(object sender, PaintEventArgs e)
        {
            if (ClearRequested)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                ClearRequested = false;
            }
            if (RenderUsingResultQueue)
            {
                RenderResultsBothBuffers();
            }
            else
            {
                RenderLocalBuffer();
            }
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
                GL.Color3(quad.Color);

                var rect = quad.Rectangle;               
                GL.Vertex2(rect.Left, rect.Bottom);
                GL.Vertex2(rect.Left, rect.Top);
                GL.Vertex2(rect.Right, rect.Top);
                GL.Vertex2(rect.Right, rect.Bottom);
            }

            GL.End();
            Target.SwapBuffers();
        }

        private void RenderResultsBothBuffers()
        {
            Queue<MazeGenerationResults> copiedQueue;
            lock (ResultsQueueSynchro)
            {
                copiedQueue = ResultsQueue;
                ResultsQueue = new Queue<MazeGenerationResults>();
            }

            RenderResultsQueue(copiedQueue);
            Target.SwapBuffers();
            //Target.SwapBuffers();
            //Target.SwapBuffers();
            RenderResultsQueue(copiedQueue);
        }

        private void RenderResultsQueue(Queue<MazeGenerationResults> queue)
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            GL.Begin(PrimitiveType.Quads);
            foreach (var results in queue)
            {
                foreach (var result in results.Results)
                {
                    var color = Colors[result.DisplayState];
                    var rect = MapPointToRectangle(result.Point);

                    GL.Color3(color);
                    RenderRectangle(rect);
                }
            }
            
            GL.End();
        }

        private static void RenderRectangle(Rectangle rect)
        {
            GL.Vertex2(rect.Left, rect.Bottom);
            GL.Vertex2(rect.Left, rect.Top);
            GL.Vertex2(rect.Right, rect.Top);
            GL.Vertex2(rect.Right, rect.Bottom);
        }
        #endregion

        private void RecalculateParameters(bool squareCells)
        {
            if (Map.Infinite)
            {
                RenderUsingResultQueue = false;
                MapWidth = 129;
                MapHeight = 129;
                RecalculateParametersInner(true);
            }
            else
            {
                RenderUsingResultQueue = AllowResultQueue;
                MapWidth = Map.Size[0];
                MapHeight = Map.Size[1];
                RecalculateParametersInner(squareCells);
            }
        }

        private void RecalculateParametersInner(bool squareCells)
        {
            CellWidth = Target.Width / MapWidth;
            CellHeight = Target.Height / MapHeight;
            if (squareCells)
            {
                if (CellWidth > CellHeight)
                {
                    CellWidth = CellHeight;
                }
                else
                {
                    CellHeight = CellWidth;
                }
            }
            TotalWidth = CellWidth * MapWidth;
            TotalHeight = CellHeight * MapHeight;

            OffsetX = (Target.Width - TotalWidth)/2;
            OffsetY = (Target.Height - TotalHeight)/2;
        }

        public void Render(MazeGenerationResults results)
        {
            if (Map.Infinite)
            {
                RenderInfinite(results);
            }
            else
            {
                RenderFinite(results);
            }
        }

        private bool RenderInfinite(MazeGenerationResults results)
        {
            //var needToRender = NeedToRender(results);
            //if (!needToRender)
            //{
            //    return false;
            //}
            //var chunkWidth = MapWidth/2;
            //var chunkHeight = MapWidth/2;

            var chunkWidth = 1;
            var chunkHeight = 1;

            var lastResult = results.Results[0];
            var lastPoint = lastResult.Point;

            //var lastChunk = lastPoint / chunkSize;

            var x = lastPoint[0];
            var y = lastPoint[1];

            x = x / chunkWidth * chunkWidth;
            y = y / chunkHeight * chunkHeight;

            x = x - MapWidth / 2;
            y = y - MapHeight / 2;

            LocalBuffer = new MyQuad[MapWidth, MapHeight];

            for (var i = 0; i < MapWidth; i++)
            {
                for (var j = 0; j < MapHeight; j++)
                {
                    var fakePoint = new Point(i, j);
                    var realPoint = new Point(i + x, j + y);
                    var cell = Map.GetCell(realPoint);
                    var displayState = cell.DisplayState;
                    var color = Colors[displayState];
                    //DrawCell(fakePoint, color, true);
                    var rect = MapPointToRectangle(fakePoint);
                    var quad = new MyQuad(color, rect);
                    LocalBuffer[i, j] = quad;
                }
            }
            // TODO: add later
            //AddResultsToLocalBuffer(results);
            UpdateTarget();
            return true;
        }

        /*private bool NeedToRender(MazeGenerationResults results)
        {
            var elapsed = RenderingStopwatch.Elapsed.TotalMilliseconds >= MininumRenderInterval;
            var completed = results.ResultsType == GenerationResultsType.GenerationCompleted;
            if (elapsed || completed)
            {
                RenderingStopwatch.Restart();
                return true;
            }
            return false;
        }*/

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

        private bool RenderFinite(MazeGenerationResults results)
        {
            if (RenderUsingResultQueue)
            {
                lock (ResultsQueueSynchro)
                {
                    ResultsQueue.Enqueue(results);
                }
            }

            //var needToRender = NeedToRender(results);
            //if (!needToRender)
            //{
            //    return false;
            //}

            if(!RenderUsingResultQueue)
            {
                LocalBuffer = new MyQuad[MapWidth, MapHeight];
                for (var i = 0; i < MapWidth; i++)
                {
                    for (var j = 0; j < MapHeight; j++)
                    {
                        var point = new Point(i, j);
                        var cell = Map.GetCell(point);
                        var displayState = cell.DisplayState;
                        var color = Colors[displayState];
                        var rect = MapPointToRectangle(point);
                        var quad = new MyQuad(color, rect);
                        LocalBuffer[i, j] = quad;
                    }
                }
                //AddResultsToLocalBuffer(results);
            }
            UpdateTarget();
            return true;
        }

        private void AddResultsToLocalBuffer(MazeGenerationResults results)
        {
            foreach (var result in results.Results)
            {
                var point = result.Point;
                var state = result.DisplayState;
                var color = Colors[state];
                var rect = MapPointToRectangle(point);
                var quad = new MyQuad(color, rect);
                LocalBuffer[point[0], point[1]] = quad;
            }
        }

        class MyQuad
        {
            public MyQuad(Color color, Rectangle rectangle)
            {
                Color = color;
                Rectangle = rectangle;
            }

            public Color Color { get; }
            public Rectangle Rectangle { get; }

        }

        public Rectangle MapPointToRectangle(Point point)
        {
            var cornerX = OffsetX + point[0]*CellWidth;
            var cornerY = OffsetY + point[1]*CellHeight;
            var rect = new Rectangle(cornerX, cornerY, CellWidth, CellHeight);
            return rect;
        }

        public void Dispose()
        {
            Clear();
            Target.Paint += Target_Paint;
        }

        public void SetMap(IMap map)
        {
            Map = map;
            RecalculateParameters(true);
        }
    }
}