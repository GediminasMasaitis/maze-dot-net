using System;

namespace Maze.Core.Renderers
{
    public interface IInstantMapRenderer : IDisposable
    {
        void RenderMap();
    }
}