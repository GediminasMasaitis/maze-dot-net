using System;

namespace Maze.Core.Renderers
{
    public interface IInstantaneousMapRenderer : IDisposable
    {
        void RenderMap();
    }
}