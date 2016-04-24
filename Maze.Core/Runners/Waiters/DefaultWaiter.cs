using System;
using System.Threading;

namespace Maze.Core.Runners.Waiters
{
    class DefaultWaiter : IWaiter
    {
        public void Wait(TimeSpan delay)
        {
            Thread.Sleep(delay);
        }
    }
}
