using System;

namespace Maze.Core.Runners.Waiters
{
    interface IWaiter
    {
        void Wait(TimeSpan delay);
    }
}